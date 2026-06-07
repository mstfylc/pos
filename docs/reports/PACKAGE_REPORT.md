# FAZ 1 PAKET RAPORU - 2026-06-07

## Tamamlanan
| Adim | Branch | Build | Commit |
|------|--------|-------|--------|
| 3 Iskelet | feat/be-skeleton | YESIL | 04e29fe |
| 4 Domain | feat/be-domain | YESIL | 957f8a4 |
| 5 Ledger+Sadakat | feat/be-ledger | YESIL | 384c609 |
| 6 OpenAPI | feat/be-openapi | YESIL | 22d5669 |

## DUR LISTESI (karar bekleyen)
| # | Konum (dosya) | Eski davranis | Sorulan karar |
|---|---------------|---------------|---------------|
| 1 | backend/src/Mansis.Pos.Domain/Entities/OrderEntities.cs | Order tek PaymentType tasiyordu. | Coklu odeme sonrasi eski PaymentType rapor/filtre uyumlulugu nasil korunacak? |
| 2 | backend/src/Mansis.Pos.Domain/Entities/LedgerEntities.cs | Stok/bakiye/indirim hareketleri eski sistemde silinebiliyordu. | Reversal kayitlari icin UI/API'de iptal nedeni zorunlu olsun mu? |

## Davranis degisiklikleri (ledger reversal vb.)
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|
| 1 | backend/src/Mansis.Pos.Domain/Entities/OrderEntities.cs | Order.PaymentType tek enum alaniydi. | OrderPayment satirlari append-only olarak eklendi. |
| 2 | backend/src/Mansis.Pos.Infrastructure/Persistence/PosDbContext.cs | Ledger benzeri satirlar silinebiliyordu. | IAppendOnly satir delete islemleri SaveChanges seviyesinde engellendi. |
| 3 | contracts/openapi.yaml | Frontend/mobil icin kontrat yoktu. | Admin/App/Loyalty/Stock tag'li OpenAPI ve uretilmis TS/Dart client eklendi. |

## Siradaki oneri
- Adim 4-5 modelleri icin kritik iliski ve indeksleri legacy davranisla review et.
- Order create use-case'i icin transaction + idempotency_key uygulamasina gec.
