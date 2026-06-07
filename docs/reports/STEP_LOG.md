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
### 2026-06-07 04:40 ADIM 14 - Faz 3 Kapanis - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: Canli auth Argon2id'e alindi, superadmin seed/docker/smoke/README eklendi, legacy HMAC import-only yapildi.
- Dosya/commit: 23 dosya, commit fec7b13
- Takilan: Docker daemon kapali oldugu icin otomatik smoke bu ortamda kosamadi.
### 2026-06-07 05:03 ADIM 15 - Local Compose Smoke - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: backend/.env.example tamamlandi, backend klasorunden compose/smoke akisi duzeltildi ve gercek Faz3 smoke PASS aldi.
- Dosya/commit: 7 dosya, commit 465f44d
- Takilan: yok
### 2026-06-07 05:22 ADIM 16 - Loyalty Earn - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: EarnRule motoru, expiry, tier multiplier, lifetime_points ve order cancel puan reversal'i eklendi.
- Dosya/commit: 14 dosya, commit a079256
- Takilan: yok
### 2026-06-07 05:30 ADIM 17 - Loyalty Tier - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: lifetime_points esigine gore tier upgrade ve ledger aciklama notu eklendi.
- Dosya/commit: 4 dosya, commit e78bdb3
- Takilan: tier downgrade kurali karar bekliyor.
### 2026-06-07 05:42 ADIM 18 - Reward Redemption - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: Reward redeem use-case/API/EF store ve order cancel redemption reversal'i eklendi.
- Dosya/commit: 13 dosya, commit 811acf1
- Takilan: yok
### 2026-06-07 05:53 ADIM 19 - Campaign Evaluation - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: Campaign rule JSON ile ekstra puan ve sabit indirim degerlendirmesi order create akimina baglandi.
- Dosya/commit: 6 dosya, commit ac8aa0a
- Takilan: kampanya cakisma onceligi karar bekliyor.
### 2026-06-07 06:10 ADIM 20 - Deploy CI Smoke - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: Dockerfile, prod compose, CI workflow, loyalty seed/smoke ve README deploy adimlari eklendi.
- Dosya/commit: 7 dosya, commit 15096ef
- Takilan: yok
### 2026-06-07 06:04 ADIM 21 - Tier Karari - branch: feat/faz3-auth-seed-smoke-closeout - build: YESIL
- Yapilan: Tier downgrade DUR kapatildi; upgrade-only karar kod yorumuna ve paket raporuna islendi.
- Dosya/commit: 2 dosya, commit 66a6af9
- Takilan: kampanya cakisma onceligi karar bekliyor.
### 2026-06-07 06:22 ADIM 22 - Campaign Conflict - branch: main - build: YESIL
- Yapilan: Ayni tip kampanyada highest priority tek secim, farkli tip birlikte uygulama ve max_total_discount cap kuralina gecildi.
- Dosya/commit: 8 dosya, commit bef13af
- Takilan: yok
### [2026-06-07 16:25] ADIM POS backend eksikleri - branch: main - build: YESIL
- Yapilan: Offline order, manuel indirim, POS katalog, musteri QR/kart tanima ve loyalty preview API'leri eklendi.
- Dosya/commit: POS backend + OpenAPI/client + test dosyalari, commit bekliyor.
- Takilan: yok.
