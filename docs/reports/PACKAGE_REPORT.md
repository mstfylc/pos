# FAZ 3 LOCAL KALDIRMA RAPORU - 2026-06-07

## Tamamlanan
| Adim | Branch | Build | Commit |
|------|--------|-------|--------|
| 15 Local Compose Smoke | feat/faz3-auth-seed-smoke-closeout | YESIL | 465f44d |

## DUR LISTESI (karar bekleyen)
| # | Konum (dosya) | Eski davranis | Sorulan karar |
|---|---------------|---------------|---------------|
| - | - | - | Bekleyen DUR yok. |

## Davranis degisiklikleri (ledger reversal vb.)
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|
| 1 | backend/.env.example | backend klasorunden compose calisinca POSTGRES_PASSWORD bulunamiyordu. | Compose ve API/smoke icin gerekli local placeholder env degiskenleri eklendi; gercek secret commitlenmedi. |
| 2 | backend/docker-compose.yml | Backend klasorunde compose tanimi yoktu. | PostgreSQL 16 servisi backend/.env ile calisacak sekilde eklendi. |
| 3 | backend/scripts/local-up.ps1 | Local ayaga kaldirma birden fazla manuel komut gerektiriyordu. | Tek komut backend/.env uretir, PostgreSQL'i kaldirir ve API'yi ya da smoke'u baslatir. |
| 4 | backend/smoke/faz3-smoke.ps1 | Smoke sabit seed bakiyelerine bagliydi ve backend klasoru disindan varsayim yapiyordu. | Script backend/.env/compose yollarini kendi bulur, migration+seed ile API'yi baslatir ve ledger deltasini baslangica gore dogrular. |
| 5 | backend/src/Mansis.Pos.Api/Program.cs | Enum string JSON gonderimleri model binding'de 400 uretebiliyordu. | JsonStringEnumConverter eklendi; OpenAPI ile uyumlu string enum istekleri kabul edildi. |
| 6 | backend/src/Mansis.Pos.Api/Controllers/AppOrdersController.cs | Order create sonrasi CreatedAtAction eksik route nedeniyle 500 uretebiliyordu. | Yeni order 201 body, idempotent tekrar 200 body doner hale getirildi. |

## Dogrulama
| Kontrol | Sonuc |
|---------|-------|
| docker compose up -d postgres | PASS; mansis-pos-postgres healthy |
| dotnet build | PASS; 0 hata, 0 uyari |
| dotnet test --no-build | PASS; 6/6 test |
| backend/smoke/faz3-smoke.ps1 | PASS; login, idempotency, ledger, cancel reversal, yetersiz stok/bakiye |

## Siradaki oneri
- Bu smoke akisi CI'da ephemeral PostgreSQL ile ayni script uzerinden kosulsun.
