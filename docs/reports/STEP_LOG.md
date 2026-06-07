### 2026-06-07 03:00 ADIM 3 - Iskelet - branch: feat/be-skeleton - build: YESIL
- Yapilan: .NET 10 Clean Architecture iskeleti, Serilog/OpenAPI/CORS/JWT/SignalR/EF/Hangfire temelleri kuruldu.
- Dosya/commit: 24 dosya, commit 04e29fe
- Takilan: yok
### 2026-06-07 03:05 ADIM 4 - Domain - branch: feat/be-domain - build: YESIL
- Yapilan: Legacy cekirdek entity/enum envanteri Domain'e Guid id, audit, tenant scope ve EF mapping iskeletiyle tasindi.
- Dosya/commit: 17 dosya, commit 957f8a4
- Takilan: yok
### 2026-06-07 03:10 ADIM 5 - Ledger+Sadakat - branch: feat/be-ledger - build: YESIL
- Yapilan: Coklu odeme, append-only stock/wallet/loyalty ledger, token ve sadakat modelleri ile EF migration eklendi.
- Dosya/commit: 11 dosya, commit 384c609
- Takilan: yok
### 2026-06-07 03:17 ADIM 6 - OpenAPI - branch: feat/be-openapi - build: YESIL
- Yapilan: Admin/App/Loyalty/Stock tag'li OpenAPI kontrati ve TS/Dart codegen client'lari uretildi.
- Dosya/commit: 77 dosya, commit 22d5669
- Takilan: yok
### 2026-06-07 03:43 ADIM 7 - Order Create - branch: feat/order-create-usecase - build: YESIL
- Yapilan: Idempotent order create use-case tek transaction graph'i, PaymentSummary ve kritik testlerle eklendi.
- Dosya/commit: 17 dosya, commit 612cd47
- Takilan: yok
### 2026-06-07 03:53 ADIM 8 - Order Cancel/Refund - branch: feat/order-cancel-refund-usecase - build: YESIL
- Yapilan: Reason zorunlu cancel/refund use-case append-only reversal satirlariyla stok, bakiye ve puani geri alacak sekilde eklendi.
- Dosya/commit: 13 dosya, commit 46c1004
- Takilan: yok
### 2026-06-07 03:56 ADIM 9 - Kritik Index Review - branch: feat/model-index-review - build: YESIL
- Yapilan: Order, katalog, musteri, discount usage ve link tablolarina kritik PostgreSQL indeksleri eklendi.
- Dosya/commit: 4 dosya, commit 701b32f
- Takilan: yok
### 2026-06-07 04:07 ADIM 10 - Order API - branch: feat/api-order-endpoints - build: YESIL
- Yapilan: App order create/cancel/refund endpointleri use-case servislerine baglandi ve OpenAPI/client uretimi yenilendi.
- Dosya/commit: 30 dosya, commit 054cf1f
- Takilan: yok
### 2026-06-07 04:14 ADIM 11 - Core CRUD API - branch: feat/api-core-crud - build: YESIL
- Yapilan: Product, category, customer, order list, store, pos ve discount admin/app endpointleri repository servislerine baglandi.
- Dosya/commit: 61 dosya, commit 97929b6
- Takilan: yok
### 2026-06-07 04:19 ADIM 12 - Auth API - branch: feat/api-auth-endpoints - build: YESIL
- Yapilan: Login, refresh token rotation ve musteri OTP iskeleti AllowAnonymous auth endpointleriyle eklendi.
- Dosya/commit: 37 dosya, commit 4050574
- Takilan: legacy password hash algoritmasi dogrulanacak.
### 2026-06-07 04:23 ADIM 13 - Smoke - branch: feat/api-smoke-verification - build: YESIL
- Yapilan: API ayaga kalkti, OpenAPI 200 dondu, OTP 200 dondu, order create auth korumasina 401 ile ulasti.
- Dosya/commit: 0 dosya, commit yok
- Takilan: tam order create smoke icin PostgreSQL seed ve auth token gerekli.
