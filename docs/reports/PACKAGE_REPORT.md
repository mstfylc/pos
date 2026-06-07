# GRUP 2 PAKET RAPORU - 2026-06-07

## Tamamlanan
| Adim | Branch | Build | Commit |
|------|--------|-------|--------|
| Sadakat admin CRUD | main | YESIL | HEAD |
| StockIn/StockOut/Destroy/StockCount | main | YESIL | HEAD |
| Transfer akisi + OpenAPI/client/test | main | YESIL | HEAD |

## DUR LISTESI (karar bekleyen)
| # | Konum (dosya) | Eski davranis | Sorulan karar |
|---|---------------|---------------|---------------|
| - | - | - | Yok |

## Davranis degisiklikleri
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|
| 1 | admin/earn-rules, loyalty-tiers, rewards, stamp-cards | Sadakat admin yazma yuzeyi yoktu | Tenant scope'lu CRUD ve validation eklendi |
| 2 | loyalty tier | Iptal/iade tier downgrade yapmiyordu | Upgrade-only kuralina dokunulmadi; downgrade eklenmedi |
| 3 | stock/stock-in, stock-out, destroy, count | Stok yazma DTO/endpoint yoktu | StoreProduct ve StockMovement tek transaction ile append-only yazilir |
| 4 | stock/destroy | Sebep alani yoktu | Reason zorunlu, bos istek 400 validation hatasi alir |
| 5 | stock/transfers | Transfer entity vardi, akis endpoint'i yoktu | Talep/onay/teslim/iptal endpointleri ve iptal sebebi alanlari eklendi |

## Siradaki oneri
- Purchase/Supplier CRUD ve purchase->stock entegrasyonu ayri paket olarak ele alinmali.
