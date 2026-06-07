# CODEX — Toplu Görev Paketi (Faz 1: Backend Migrate → OpenAPI)

> Bu paket Adım 3→6'yı KESİNTİSİZ yürütmen içindir. AGENTS.md + ARCHITECTURE.md kurallarına uy. Her adım sonunda commit + 3 satır rapor. DUR çizgisine takılırsan dur, biriktirdiğin soruları paketin sonundaki "DUR LİSTESİ" formatında getir.

## Çalışma kuralları (paket boyunca)
- DB: PostgreSQL 16, Npgsql. Connection string env'den (`DB_CONNECTION_STRING`).
- Her adımı kendi branch'inde tut: `feat/be-skeleton`, `feat/be-domain`, `feat/be-ledger`, `feat/be-openapi`.
- Her adım sonunda: `dotnet build` yeşil → commit → 3 satırlık rapor (ne yaptın, kaç dosya, takılan var mı).
- Token verimli: sadece ilgili dosyaları aç, envanteri tekrar dökme.
- Secret yok. Belirsiz kuralı silme → `// TODO: verify rule (eski: ...)` + DUR listesine ekle.

---

## ADIM 3 — Solution iskeleti
backend/ altında .NET 10 Clean Architecture: Api, Application, Domain, Infrastructure, Workers, Contracts.
Program.cs: Serilog, OpenAPI, CORS whitelist, JWT (UseAuthentication→UseAuthorization), EF DbContext (Npgsql, env'den).
Derlenebilir boş iskelet. `dotnet build` → commit (`feat/be-skeleton`).

## ADIM 4 — Domain migrate
Envanterdeki çekirdek entity'leri Domain'e taşı (Company, Branch, Pos, Store, User, Role, Permission, RolePermission, Product, Category, CategoryColor/Shape, PosProduct, StoreProduct, StoreProductMovement, StoreProductTransfer+Detail, Order, OrderProduct, OrderSubProduct, OrderDiscounts, Discount+Branch/Pos/User, DiscountUsageLog, Customer, CustomerAddress, CustomerBalanceMovement, CustomerFavoriteProduct, Card, LoadBalanceRequest, Address/City/Town, Supplier, Purchase+PurchaseProduct, Tag ailesi, ConfigParam, Assignment, ActivityLog'lar).
Kural: audit alanları + ilişkiler korunur, id'ler uuid, enum'lar string. EF config Infrastructure'da Fluent API. PostgreSQL tipleri.
`dotnet build` → commit (`feat/be-domain`).

## ADIM 5 — Teknik iyileştirmeler + sadakat
1. order_payments (çoklu ödeme; Order.PaymentType tek enum yerine satır).
2. Append-only ledger: stock_movements, wallet_accounts+wallet_transactions, loyalty_accounts+loyalty_point_transactions. İptal/iadede SİLME yok → ters (reversal) kayıt. (Eski hard-delete davranışını DEĞİŞTİRDİĞİN her yeri DUR listesine yaz.)
3. refresh_tokens, password_reset_tokens.
4. Tenant: EF global query filter ile company_id otomatik.
5. Sadakat: loyalty_tiers, earn_rules, rewards, reward_redemptions, campaigns (genişletilmiş), device_tokens, customer_card_tokens (süreli QR).
EF migration üret + adlandır. `dotnet build` → commit (`feat/be-ledger`).

## ADIM 6 — OpenAPI + client
contracts/openapi.yaml üret: admin (/api/v1/admin/...) ve app (/api/v1/app/...) tag'leri. ProblemDetails, enum string, tarih ISO8601/UTC, para decimal(string). docs/API_CONTRACT.md'ye uy.
Codegen script (`gen:api`): openapi-typescript→api-client-ts, openapi-generator(dart-dio)→api-client-dart. Client üret. commit (`feat/be-openapi`).

---

## DUR ÇİZGİSİ (bunlarda devam etme, biriktir)
- Belirsiz/şüpheli iş kuralı (ör. OrderSubProduct ProductID/SubProductID eşleşmesi).
- Eski hard-delete → ledger reversal'a çevirdiğin davranış değişiklikleri.
- Çözülemeyen build/bağımlılık (2-3 deneme sonrası).

## RAPORLAMA (docs/CODEX_RAPOR_FORMATLARI.md formatına uy)
- Her adım sonunda: docs/reports/STEP_LOG.md'ye 4 satırlık adım raporu EKLE (sohbete yazma).
- Paket bitince: docs/reports/PACKAGE_REPORT.md doldur (Tamamlanan tablo + DUR LİSTESİ + Davranış değişiklikleri + Sıradaki öneri).
- Raporları repoya commit et. Sohbete uzun çıktı dökme; rapor dosyada durur.
