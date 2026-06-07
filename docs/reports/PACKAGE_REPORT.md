# FAZ 3 KAPANIS RAPORU - 2026-06-07

## Tamamlanan
| Adim | Branch | Build | Commit |
|------|--------|-------|--------|
| 14 Auth+Seed+Smoke Kapanis | feat/faz3-auth-seed-smoke-closeout | YESIL | fec7b13 |

## DUR LISTESI (karar bekleyen)
| # | Konum (dosya) | Eski davranis | Sorulan karar |
|---|---------------|---------------|---------------|
| - | - | - | Bekleyen DUR yok. |

## Davranis degisiklikleri (ledger reversal vb.)
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|
| 1 | backend/src/Mansis.Pos.Infrastructure/Auth/Argon2idPasswordHasher.cs | Canli auth legacy HMAC varsayimina bagliydi. | Canli personel/superadmin auth Argon2id hasher'a baglandi. |
| 2 | backend/src/Mansis.Pos.Infrastructure/Auth/HmacPasswordVerifier.cs | HMAC verifier aktif DI adayiydi. | Obsolete legacy import only olarak isaretlendi ve live auth DI yolundan cikarildi. |
| 3 | backend/src/Mansis.Pos.Infrastructure/Persistence/DbBootstrapHostedService.cs | Superadmin/seed yoktu. | Env'den superadmin Argon2id hash ile must_change_password=true olusturulur; company/branch/store/pos/product/customer seed edilir. |
| 4 | docker-compose.yml | Yerel PostgreSQL compose yoktu. | PostgreSQL 16 compose ve env placeholder akisi eklendi. |
| 5 | backend/smoke/faz3-smoke.ps1 | Gercek order smoke otomasyonu yoktu. | Login, idempotent order, ledger, cancel reversal, yetersiz stok/bakiye edge kontrolleri otomatik script'e alindi. |
| 6 | docs/reports/STEP_LOG.md | Legacy algoritma notu DUR olarak duruyordu. | Legacy algoritma HMACSHA512 key=salt, UTF8(password), 64 hash/128 salt olarak not edildi; canli auth'a tasinmadi. |

## Siradaki oneri
- Docker Desktop acikken `backend/smoke/faz3-smoke.ps1` kosup sonucu CI smoke'a tasiyin.
- Admin panelde superadmin ilk giriste zorunlu sifre degistirme ekranina yonlendirilsin.
