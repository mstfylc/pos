# ENTRY PRODUCT SEVIYE 1 RAPORU - 2026-06-07

## Tamamlanan
| Adim | Branch | Build | Commit |
|------|--------|-------|--------|
| Entry order line + migration | main | YESIL | HEAD |
| Manual branch setting + TODO auto | main | YESIL | HEAD |
| Entry delivery report + OpenAPI/client/test | main | YESIL | HEAD |

## DUR LISTESI (karar bekleyen)
| # | Konum (dosya) | Eski davranis | Sorulan karar |
|---|---------------|---------------|---------------|
| - | - | - | Yok |

## Davranis degisiklikleri
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|
| 1 | app/orders lines | EntryProduct sadece urun bayragiydi | isEntry=true satirlar sadece EntryProduct=true urunlerde kabul edilir |
| 2 | order_product | Giris teslim satiri ayrismiyordu | is_entry alani eklendi; entry satir total 0, stok normal duser |
| 3 | branches | Giris takip modu yoktu | entry_tracking_mode Manual default ile eklendi; Auto Seviye 2 TODO |
| 4 | reports/entry-products | Teslim raporu yoktu | Tarih/sube/POS/urun/adet kirilimli rapor endpoint'i eklendi |

## Siradaki oneri
- Seviye 2 icin auto hak takibi ayri entitlement/usage ledger tasarimi ile ele alinmali.
