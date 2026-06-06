# API Kontratı ve Client Üretimi

> `contracts/openapi.yaml` tüm istemcilerin tek API kaynağıdır. Sahibi backend tarafıdır (Codex). Frontend/mobil bu kontrattan ÜRETİLEN client'ları kullanır; kendi tipini yazmaz.

## 1. Akış
```
backend değişir → contracts/openapi.yaml güncellenir → codegen → api-client-ts + api-client-dart yenilenir → frontend/mobil yeni client'ı kullanır
```

## 2. OpenAPI üretimi (.NET 10)
- .NET 10 built-in OpenAPI desteği ile şema otomatik üretilir; manuel düzenleme minimumda tutulur.
- Endpoint'ler iki gruba etiketlenir (tag): `admin`, `app` (POS/mobil/web ortak).
- ProblemDetails standart hata formatı; her endpoint olası 4xx/5xx döner.

## 3. Client üretimi (codegen)
| Hedef | Araç | Çıktı |
|-------|------|-------|
| TypeScript | `openapi-typescript` + `openapi-fetch` (veya orval) | packages/api-client-ts |
| Dart | `openapi-generator` (dart-dio) | packages/api-client-dart |

Üretim komutu repo script'i olarak (`pnpm gen:api`, `make gen-api`) sabitlenir; CI'da kontrat değişince otomatik çalışır.

## 4. Sözleşme kuralları
- **Kırıcı değişiklik** (alan silme/tip değiştirme) versiyon artışı gerektirir (`/api/v1` → `/api/v2`).
- Yeni alan eklemek geriye uyumludur; serbest.
- Tüm tarih alanları ISO 8601 / UTC. Para alanları `decimal` (string serileştirme, float değil).
- Enum'lar string olarak serileştirilir (OrderState: "Received" gibi), sayı değil.

## 5. Endpoint isimlendirme
- Admin: `/api/v1/admin/...` · App (POS/mobil/web): `/api/v1/app/...`
- Kaynak çoğul, kebab yok camel yok → düz: `/products`, `/stock-transfers`, `/loyalty/account`
- Aksiyon endpoint'leri fiil ile: `/orders/{id}/cancel`, `/pos-devices/{id}/activation-code`

## 6. Kim ne yapar
- **Codex**: openapi.yaml'ı günceller, codegen'i çalıştırır, client'ları commit'ler.
- **Claude Code**: üretilen client'ı import eder, asla elle endpoint/tip yazmaz.
- **Çakışma**: openapi.yaml'ı aynı anda iki kişi/araç değiştirmez.
