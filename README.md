# Mansis POS v2

## Local backend

1. Create a local env file from `backend/.env.example` and set non-production values:

```powershell
Copy-Item backend/.env.example backend/.env
```

2. Start PostgreSQL, apply migrations, seed, and run API:

```powershell
.\backend\scripts\local-up.ps1
```

From inside `backend/`, the same flow is:

```powershell
.\scripts\local-up.ps1
```

OpenAPI: `http://localhost:5254/openapi/v1.json`

## Seed

Seed creates one company, branch, store, POS, two products, one test customer with wallet/loyalty accounts, and one superadmin from `SUPERADMIN_EMAIL` + `SUPERADMIN_PASSWORD`.

Superadmin is created with Argon2id password hash and `must_change_password=true`. Legacy passwords are not imported.

## Smoke

```powershell
.\backend\smoke\faz3-smoke.ps1
```

Or run local setup plus smoke in one command:

```powershell
.\backend\scripts\local-up.ps1 -Smoke
```

The smoke script starts PostgreSQL, runs API with migration/seed enabled, logs in as superadmin, creates an order twice with the same idempotency key, verifies stock/wallet/loyalty ledgers, cancels the order, verifies reversal rows, and checks insufficient stock/balance edges.
