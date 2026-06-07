# POS BACKEND PAKET RAPORU - 2026-06-07

## Tamamlanan
| Adim | Branch | Build | Commit |
|------|--------|-------|--------|
| Offline order + manuel indirim | main | YESIL | HEAD |
| POS katalog + musteri tanima + loyalty preview | main | YESIL | HEAD |
| OpenAPI + TS/Dart client + test | main | YESIL | HEAD |

## DUR LISTESI (karar bekleyen)
| # | Konum (dosya) | Eski davranis | Sorulan karar |
|---|---------------|---------------|---------------|
| - | - | - | Yok |

## Davranis degisiklikleri
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|
| 1 | app/order create | Online stok kontrolu zorunluydu | OfflineOrder=true ise idempotency ile kayit alinir ve stok yetersizligi senkron sonrasi ele alinacak sekilde atlanir |
| 2 | app/order create | Siparis aninda manuel indirim kaydi yoktu | DiscountUsageLog ve OrderDiscount satirlari scope/aylik limit kontroluyle yazilir |
| 3 | app/pos/{posId}/products | POS ekranina ozel katalog yoktu | POS bazli fiyat override, StoreProduct stok ve kategori renk/sekil gruplari doner |
| 4 | app/customers/identify | POS musteri tanima endpoint'i yoktu | Sureli QR token veya kart no hash eslesmesiyle bakiye/puan/tier doner |
| 5 | app/loyalty/preview | Siparis olusturmadan sadakat onizleme yoktu | Sepete gore kazanilacak puan, kampanya etkisi ve kullanilabilir oduller hesaplanir |

## Siradaki oneri
- Vardiya/gun sonu modulu ayrica tasarlanacak; bu pakette sadece TODO notu birakildi.
