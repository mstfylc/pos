# Mansis POS v2

## Local backend

1. Create a local env file from `.env.example` and set non-production values.
2. Start PostgreSQL:

```powershell
docker compose up -d postgres
```

3. Run API with migration and seed enabled:

```powershell
$env:DB_CONNECTION_STRING="Host=localhost;Port=5432;Database=mansis_pos;Username=mansis;Password=$env:POSTGRES_PASSWORD"
$env:JWT_SECRET=$env:JWT_SECRET
$env:CORS_ALLOWED_ORIGINS="http://localhost:3000"
$env:COMPANY_ID="10000000-0000-0000-0000-000000000001"
$env:SUPERADMIN_EMAIL=$env:SUPERADMIN_EMAIL
$env:SUPERADMIN_PASSWORD=$env:SUPERADMIN_PASSWORD
$env:AUTO_MIGRATE="true"
$env:SEED_DATABASE="true"
dotnet run --project backend/src/Mansis.Pos.Api/Mansis.Pos.Api.csproj
```

OpenAPI: `http://localhost:5254/openapi/v1.json`

## Seed

Seed creates one company, branch, store, POS, two products, one test customer with wallet/loyalty accounts, and one superadmin from `SUPERADMIN_EMAIL` + `SUPERADMIN_PASSWORD`.

Superadmin is created with Argon2id password hash and `must_change_password=true`. Legacy passwords are not imported.

## Smoke

```powershell
.\backend\smoke\faz3-smoke.ps1
```

The smoke script starts PostgreSQL, runs API with migration/seed enabled, logs in as superadmin, creates an order twice with the same idempotency key, verifies stock/wallet/loyalty ledgers, cancels the order, verifies reversal rows, and checks insufficient stock/balance edges.
