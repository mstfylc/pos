param(
    [string]$BaseUrl = "http://localhost:5254",
    [string]$Project = ""
)

$ErrorActionPreference = "Stop"

$BackendRoot = Split-Path -Parent $PSScriptRoot
$RepoRoot = Split-Path -Parent $BackendRoot
$EnvPath = Join-Path $BackendRoot ".env"
$EnvExamplePath = Join-Path $BackendRoot ".env.example"
$ComposePath = Join-Path $BackendRoot "docker-compose.yml"
if ([string]::IsNullOrWhiteSpace($Project)) {
    $Project = Join-Path $BackendRoot "src/Mansis.Pos.Api/Mansis.Pos.Api.csproj"
}

if (-not (Test-Path -LiteralPath $EnvPath)) {
    Copy-Item -LiteralPath $EnvExamplePath -Destination $EnvPath
    Write-Host "Created backend/.env from backend/.env.example. Edit local-only values when needed."
}

Get-Content -LiteralPath $EnvPath | ForEach-Object {
    if ($_ -match '^\s*#' -or $_ -notmatch '=') { return }
    $parts = $_ -split '=', 2
    [Environment]::SetEnvironmentVariable($parts[0].Trim(), $parts[1].Trim(), "Process")
}

function Assert-Equal($Actual, $Expected, $Message) {
    if ($Actual -ne $Expected) {
        throw "$Message expected=$Expected actual=$Actual"
    }
}

function Invoke-Json($Method, $Uri, $Body = $null, $Token = $null, $Headers = @{}) {
    $requestHeaders = @{}
    foreach ($key in $Headers.Keys) { $requestHeaders[$key] = $Headers[$key] }
    if ($Token) { $requestHeaders["Authorization"] = "Bearer $Token" }
    $json = if ($Body) { $Body | ConvertTo-Json -Depth 12 } else { $null }
    return Invoke-RestMethod -Method $Method -Uri $Uri -Headers $requestHeaders -Body $json -ContentType "application/json"
}

function DbScalar([string]$Sql) {
    return (docker compose --env-file $EnvPath -f $ComposePath exec -T postgres psql -U mansis -d mansis_pos -tAc $Sql).Trim()
}

function DbDecimal([string]$Sql) {
    return [decimal](DbScalar $Sql)
}

if ([string]::IsNullOrWhiteSpace($env:POSTGRES_PASSWORD)) { $env:POSTGRES_PASSWORD = "change-me-local-only" }
if ([string]::IsNullOrWhiteSpace($env:SUPERADMIN_EMAIL)) { $env:SUPERADMIN_EMAIL = "admin@example.local" }
if ([string]::IsNullOrWhiteSpace($env:SUPERADMIN_PASSWORD)) { $env:SUPERADMIN_PASSWORD = "change-me-local-only" }
if ([string]::IsNullOrWhiteSpace($env:JWT_SECRET)) { $env:JWT_SECRET = "change-me-local-only-change-me-local-only" }
if ([string]::IsNullOrWhiteSpace($env:CORS_ALLOWED_ORIGINS)) { $env:CORS_ALLOWED_ORIGINS = "http://localhost:3000" }
$env:COMPANY_ID = "10000000-0000-0000-0000-000000000001"
$env:DB_CONNECTION_STRING = "Host=localhost;Port=5432;Database=mansis_pos;Username=mansis;Password=$($env:POSTGRES_PASSWORD)"
$env:AUTO_MIGRATE = "true"
$env:SEED_DATABASE = "true"
$env:ASPNETCORE_ENVIRONMENT = "Development"
$env:ASPNETCORE_URLS = $BaseUrl

docker compose --env-file $EnvPath -f $ComposePath up -d postgres | Out-Host
if ($LASTEXITCODE -ne 0) {
    throw "Docker PostgreSQL could not be started. Is Docker Desktop running?"
}

$out = Join-Path $PSScriptRoot "api-out.log"
$err = Join-Path $PSScriptRoot "api-err.log"
Remove-Item -LiteralPath $out, $err -ErrorAction SilentlyContinue
$api = Start-Process -FilePath dotnet -ArgumentList @("run", "--no-launch-profile", "--project", $Project) -WorkingDirectory $RepoRoot -RedirectStandardOutput $out -RedirectStandardError $err -PassThru -WindowStyle Hidden

try {
    $openApiReady = $false
    for ($i = 0; $i -lt 60; $i++) {
        try {
            $status = (Invoke-WebRequest -Uri "$BaseUrl/openapi/v1.json" -UseBasicParsing -TimeoutSec 2).StatusCode
            if ($status -eq 200) { $openApiReady = $true; break }
        } catch {
            Start-Sleep -Seconds 2
        }
    }
    if (-not $openApiReady) { throw "OpenAPI endpoint did not become ready." }

    $login = Invoke-Json Post "$BaseUrl/api/v1/auth/login" @{
        companyId = $env:COMPANY_ID
        username = $env:SUPERADMIN_EMAIL
        password = $env:SUPERADMIN_PASSWORD
    }
    if (-not $login.accessToken) { throw "Login did not return access token." }
    Assert-Equal $login.mustChangePassword $true "Superadmin mustChangePassword"

    $orderBody = @{
        companyId = $env:COMPANY_ID
        posId = "10000000-0000-0000-0000-000000000004"
        userId = "10000000-0000-0000-0000-000000000006"
        customerId = "10000000-0000-0000-0000-000000000012"
        shippingType = "Self"
        orderTime = "2026-06-07T00:00:00Z"
        lines = @(@{ productId = "10000000-0000-0000-0000-000000000010"; quantity = 2; unitPrice = 10; taxAmount = 0 })
        payments = @(@{ paymentType = "Cash"; amount = 20; currency = "TRY" })
    }

    $runKey = "smoke-" + [Guid]::NewGuid().ToString("N")
    $stockBefore = DbDecimal "select quantity from pos.store_products where store_id='10000000-0000-0000-0000-000000000003' and product_id='10000000-0000-0000-0000-000000000010';"
    $walletBefore = DbDecimal "select balance from pos.wallet_accounts where id='10000000-0000-0000-0000-000000000013';"
    $loyaltyBefore = DbDecimal "select point_balance from pos.loyalty_accounts where id='10000000-0000-0000-0000-000000000014';"

    $headers = @{ "Idempotency-Key" = "$runKey-order" }
    $created = Invoke-Json Post "$BaseUrl/api/v1/app/orders" $orderBody $login.accessToken $headers
    $duplicate = Invoke-Json Post "$BaseUrl/api/v1/app/orders" $orderBody $login.accessToken $headers
    Assert-Equal $created.orderId $duplicate.orderId "Idempotent order id"
    Assert-Equal $duplicate.existing $true "Duplicate idempotency result"

    Assert-Equal (DbScalar "select count(*) from pos.orders where idempotency_key='$runKey-order';") "1" "Order row count"
    Assert-Equal (DbDecimal "select quantity from pos.store_products where store_id='10000000-0000-0000-0000-000000000003' and product_id='10000000-0000-0000-0000-000000000010';") ($stockBefore - 2) "Stock after create"
    Assert-Equal (DbDecimal "select balance from pos.wallet_accounts where id='10000000-0000-0000-0000-000000000013';") ($walletBefore - 20) "Wallet after create"
    $earnedPoints = DbDecimal "select coalesce(sum(points),0) from pos.loyalty_point_transactions where order_id='$($created.orderId)' and points > 0;"
    Assert-Equal (DbDecimal "select point_balance from pos.loyalty_accounts where id='10000000-0000-0000-0000-000000000014';") ($loyaltyBefore + $earnedPoints) "Loyalty after create"

    $cancel = Invoke-Json Post "$BaseUrl/api/v1/app/orders/$($created.orderId)/cancel" @{
        companyId = $env:COMPANY_ID
        userId = "10000000-0000-0000-0000-000000000006"
        reason = "smoke cancel"
    } $login.accessToken
    Assert-Equal $cancel.orderState "Cancelled" "Cancel state"
    Assert-Equal (DbDecimal "select quantity from pos.store_products where store_id='10000000-0000-0000-0000-000000000003' and product_id='10000000-0000-0000-0000-000000000010';") $stockBefore "Stock after cancel"
    Assert-Equal (DbDecimal "select balance from pos.wallet_accounts where id='10000000-0000-0000-0000-000000000013';") $walletBefore "Wallet after cancel"
    Assert-Equal (DbDecimal "select point_balance from pos.loyalty_accounts where id='10000000-0000-0000-0000-000000000014';") $loyaltyBefore "Loyalty after cancel"
    Assert-Equal (DbScalar "select count(*) from pos.stock_movements where operation_id='$($created.orderId)' and reversal_of_id is not null;") "1" "Stock reversal count"

    try {
        Invoke-Json Post "$BaseUrl/api/v1/app/orders" @{
            companyId = $env:COMPANY_ID
            posId = "10000000-0000-0000-0000-000000000004"
            userId = "10000000-0000-0000-0000-000000000006"
            customerId = "10000000-0000-0000-0000-000000000012"
            shippingType = "Self"
            orderTime = "2026-06-07T00:05:00Z"
            lines = @(@{ productId = "10000000-0000-0000-0000-000000000011"; quantity = 2; unitPrice = 15; taxAmount = 0 })
            payments = @(@{ paymentType = "Cash"; amount = 30; currency = "TRY" })
        } $login.accessToken @{ "Idempotency-Key" = "$runKey-insufficient-stock" } | Out-Null
        throw "Insufficient stock request unexpectedly succeeded."
    } catch {
        if ($_.Exception.Response.StatusCode.value__ -ne 400) { throw }
    }

    try {
        Invoke-Json Post "$BaseUrl/api/v1/app/orders" @{
            companyId = $env:COMPANY_ID
            posId = "10000000-0000-0000-0000-000000000004"
            userId = "10000000-0000-0000-0000-000000000006"
            customerId = "10000000-0000-0000-0000-000000000012"
            shippingType = "Self"
            orderTime = "2026-06-07T00:10:00Z"
            lines = @(@{ productId = "10000000-0000-0000-0000-000000000010"; quantity = 1; unitPrice = 2000; taxAmount = 0 })
            payments = @(@{ paymentType = "Cash"; amount = 2000; currency = "TRY" })
        } $login.accessToken @{ "Idempotency-Key" = "$runKey-insufficient-wallet" } | Out-Null
        throw "Insufficient wallet request unexpectedly succeeded."
    } catch {
        if ($_.Exception.Response.StatusCode.value__ -ne 400) { throw }
    }

    Write-Host "FAZ3 smoke OK"
}
finally {
    if ($api -and -not $api.HasExited) {
        Stop-Process -Id $api.Id -Force
    }
}
