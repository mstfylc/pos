param(
    [switch]$Smoke
)

$ErrorActionPreference = "Stop"

$BackendRoot = Split-Path -Parent $PSScriptRoot
$RepoRoot = Split-Path -Parent $BackendRoot
$EnvPath = Join-Path $BackendRoot ".env"
$EnvExamplePath = Join-Path $BackendRoot ".env.example"
$ComposePath = Join-Path $BackendRoot "docker-compose.yml"
$ProjectPath = Join-Path $BackendRoot "src/Mansis.Pos.Api/Mansis.Pos.Api.csproj"

if (-not (Test-Path -LiteralPath $EnvPath)) {
    Copy-Item -LiteralPath $EnvExamplePath -Destination $EnvPath
    Write-Host "Created backend/.env from backend/.env.example. Edit local-only values when needed."
}

Get-Content -LiteralPath $EnvPath | ForEach-Object {
    if ($_ -match '^\s*#' -or $_ -notmatch '=') { return }
    $parts = $_ -split '=', 2
    [Environment]::SetEnvironmentVariable($parts[0].Trim(), $parts[1].Trim(), "Process")
}

docker compose --env-file $EnvPath -f $ComposePath up -d postgres
if ($LASTEXITCODE -ne 0) {
    throw "Docker PostgreSQL could not be started. Is Docker Desktop running?"
}

if ($Smoke) {
    & (Join-Path $BackendRoot "smoke/faz3-smoke.ps1")
    exit $LASTEXITCODE
}

Push-Location $RepoRoot
try {
    dotnet run --no-launch-profile --project $ProjectPath
}
finally {
    Pop-Location
}
