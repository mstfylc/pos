# FAZ 3 PAKET RAPORU - 2026-06-07

## Tamamlanan
| Adim | Branch | Build | Commit |
|------|--------|-------|--------|
| 10 Order API | feat/api-order-endpoints | YESIL | 054cf1f |
| 11 Core CRUD API | feat/api-core-crud | YESIL | 97929b6 |
| 12 Auth API | feat/api-auth-endpoints | YESIL | 4050574 |
| 13 Smoke | feat/api-smoke-verification | YESIL | yok |

## DUR LISTESI (karar bekleyen)
| # | Konum (dosya) | Eski davranis | Sorulan karar |
|---|---------------|---------------|---------------|
| 1 | backend/src/Mansis.Pos.Infrastructure/Auth/HmacPasswordVerifier.cs | Legacy user password hash algoritmasi kesin degil. | HMACSHA512 salt+hash varsayimi onaylansin mi? |

## Davranis degisiklikleri (ledger reversal vb.)
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|
| 1 | backend/src/Mansis.Pos.Api/Controllers/AppOrdersController.cs | Order use-case'leri HTTP'den cagrilmiyordu. | Create/cancel/refund endpointleri use-case servislerine baglandi; idempotency header/body desteklendi. |
| 2 | backend/src/Mansis.Pos.Api/Controllers/AdminCoreController.cs | Core CRUD endpointleri repository'ye bagli degildi. | Admin product/category/customer/order/store/pos/discount endpointleri tenant filtreli EF store'a baglandi. |
| 3 | backend/src/Mansis.Pos.Api/Controllers/AppCatalogController.cs | App katalog/order list okuma endpointleri yoktu. | App list endpointleri admin'den ayri tag ve route ile eklendi. |
| 4 | backend/src/Mansis.Pos.Api/Controllers/AuthController.cs | Auth endpointleri yoktu. | Login, refresh rotation ve OTP iskeleti AllowAnonymous olarak eklendi. |
| 5 | contracts/openapi.yaml | Kontrat Faz 2 endpointlerini kapsamiyordu. | OpenAPI admin/app/auth endpointleriyle senkronlandi ve TS/Dart client'lar uretildi. |

## Siradaki oneri
- PostgreSQL seed verisiyle gercek order create smoke testi ekle.
- Legacy password hash algoritmasini eski backend'den kesinlestir.
