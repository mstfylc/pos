# Codex ile İlk Oturum — Adım Adım Komut & Prompt Seti

> Bu dosyadaki komutları kendi makinende terminalde, prompt'ları Codex'e veriyorsun. Sırayı bozma. Her prompt'un başına standart bağlam cümlesi zaten ekli.

---

## ADIM 0 — Repoları hazırla (terminal, senin makinen)

```bash
# 1) Yeni v2 reposunu klonla
git clone https://github.com/mstfylc/pos.git
cd pos

# 2) Bu başlangıç paketini repo köküne aç (indirdiğin zip'i)
#    -> ARCHITECTURE.md, AGENTS.md, CLAUDE.md, .cursorrules, docs/, packages/, klasör iskeleti vb. gelir

# 3) Eski backend'i AYRI klasöre, repo DIŞINA klonla (salt-okunur referans)
cd ..
git clone <ESKI_MANSIS_POS_WS_REPO_URL> mansis_pos_ws_legacy
#    (Bitbucket'taki mansis_pos_ws — referans amaçlı; pos repo'suna KARIŞMAZ)

# 4) İlk commit (henüz kod yok, sadece iskelet + governance)
cd pos
git checkout -b chore/bootstrap
git add .
git commit -m "chore: governance + iskelet + tasarım sistemi"
git push -u origin chore/bootstrap
```

> Not: Eski repo `pos`'un dışında durur, `.gitignore`'a gerek yok; yanlışlıkla içine kopyalama.

---

## ADIM 1 — Codex'i başlat ve tanıt

Codex'i `pos/` klasöründe aç. İlk prompt:

```
Önce repo kökündeki ARCHITECTURE.md, AGENTS.md ve docs/CODEX_BRIEF.md + docs/DEFINITION_OF_DONE.md dosyalarını oku. Bunlar bağlayıcı. Özetle bana: (1) hangi kararlara uyacağını, (2) hangi klasörlerin senin sahan olduğunu, (3) ihlal etmeyeceğin sınır kurallarını. Henüz kod yazma; sadece anladığını teyit et.
```

Bu, Codex'in kuralları yüklediğini doğrular. Yanlış anladıysa düzelt, sonra devam.

---

## ADIM 2 — Eski kodu referans olarak tara (henüz yazma)

```
Eski .NET Core 3.1 backend'i ../mansis_pos_ws_legacy klasöründe salt-okunur referans olarak inceleyeceksin; oraya YAZMA. Şunları çıkar ve bana özetle: (1) tüm entity'ler ve alanları, (2) enum'lar, (3) controller'lar ve endpoint'leri, (4) dikkat çeken iş kuralları (sipariş/indirim/bakiye/stok hesapları), (5) sızmış secret'lar (yeni repoya ASLA taşınmayacak liste). Tablo halinde ver.
```

---

## ADIM 3 — Backend solution iskeleti (Clean Architecture)

```
backend/ altında .NET 10 LTS ile Clean Architecture solution kur:
- Mansis.Pos.Api (ASP.NET Core Web API, OpenAPI, SignalR hub iskeleti)
- Mansis.Pos.Application (MediatR/CQRS, DTO, FluentValidation)
- Mansis.Pos.Domain (entity, enum, domain servis — saf)
- Mansis.Pos.Infrastructure (EF Core 10, PostgreSQL, repository)
- Mansis.Pos.Workers (Hangfire iskeleti)
- Mansis.Pos.Contracts
Program.cs'te: Serilog, OpenAPI, CORS (whitelist), JWT auth (UseAuthentication ÖNCE, sonra UseAuthorization), EF DbContext (env'den connection string). Secret YOK; appsettings.example.json'a placeholder. Derlenebilir boş iskelet üret, çalıştığını doğrula.
```

Terminalde doğrula:
```bash
cd backend && dotnet build
```

---

## ADIM 4 — Domain modellerini migrate et

```
../mansis_pos_ws_legacy referansından çekirdek entity'leri Domain'e taşı: Company, Branch, Pos, Store, User, Role, Permission, RolePermission, Product, Category, CategoryColor/Shape, PosProduct, StoreProduct, StoreProductMovement, Order, OrderProduct, Discount, Customer, CustomerBalanceMovement, Card, Address/City/Town, Supplier, Purchase.
Kurallar: audit alanları (CreatedAt/By, UpdatedAt/By, DeletedAt, Active) ve ilişkiler korunur. id'ler uuid. Belirsiz iş kuralında // TODO: verify rule (eski davranış: ...) bırak. EF Core configuration'ları Infrastructure'da Fluent API ile. PostgreSQL'e uygun tipler.
```

---

## ADIM 5 — Teknik iyileştirmeler + sadakat tabloları

```
Şu iyileştirmeleri ekle (ARCHITECTURE.md ve master rapordaki şemaya göre):
1. order_payments (çoklu/bölünmüş ödeme) — Order.PaymentType tek enum yerine satır tablosu.
2. Append-only ledger: stock_movements, wallet_accounts+wallet_transactions, loyalty_accounts+loyalty_point_transactions. Hard-delete yok.
3. refresh_tokens, password_reset_tokens.
4. Tenant: EF Core global query filter ile company_id otomatik filtre.
5. Sadakat: loyalty_tiers, earn_rules, rewards, reward_redemptions, campaigns (genişletilmiş), device_tokens.
EF migration üret ve adlandır.
```

---

## ADIM 6 — OpenAPI kontratı + client üretimi

```
contracts/openapi.yaml üret: endpoint'leri admin (/api/v1/admin/...) ve app (/api/v1/app/...) olarak tag'le. ProblemDetails hata formatı, enum'lar string, tarih ISO8601/UTC, para decimal(string). docs/API_CONTRACT.md kurallarına uy.
Sonra codegen script ekle: openapi-typescript -> packages/api-client-ts, openapi-generator(dart-dio) -> packages/api-client-dart. Bir 'gen:api' komutu olsun. Client'ları üret; bunlar elle düzenlenmez.
```

---

## ADIM 7 — Commit & gözden geçir

```bash
# Codex her adımda kendi branch'inde commit etti; sen gözden geçir:
git log --oneline
# DEFINITION_OF_DONE listesini uygula, sonra PR aç / merge et
```

---

## Her prompt'a eklenecek standart bağlam (kısayol)
> "ARCHITECTURE.md + AGENTS.md kurallarına uy. Secret yazma. Tenant scope + transaction + idempotency. Belirsiz iş kuralını silme, TODO bırak. Tek adım/küçük commit."

## Sonraki oturum (bu rapor kapsamı dışında, sırada)
Faz 2 tamamlanınca → Faz 3 mobil (Claude Code) ve Faz 4 admin/pos web (Claude Code + Claude Design) başlar; ikisi de bu OpenAPI kontratından üretilen client'ı kullanır.
