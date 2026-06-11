# Design Brief — B1: Admin Stok Modülü

> Faz A · admin-web · düşük risk (backend hazır). Konvansiyon: `A2-pos-satis-ekrani.md`. Mevcut admin DS (Metronic) kullanılır.

## 1. Amaç
Mağaza stok yönetimi: hareket geçmişi (append-only ledger), giriş/çıkış/imha/sayım, şubeler arası transfer.

## 2. Ekran grubu (sekme/alt sayfa)
- **Stok hareketleri**: filtreli DataTable (mağaza/ürün/tarih/tip), append-only.
- **Stok giriş / çıkış**: ürün + miktar + sebep formu.
- **Sayım**: ürün listesi → sayılan miktar → fark (StockDiff) hesaplanır.
- **İmha/fire**: ürün + miktar + sebep.
- **Transfer**: oluştur (kaynak→hedef, satırlar) → onayla → teslim al (kısmi miktar) → iptal. Durum akışı StatusBadge.

## 3. DS bileşen eşlemesi
DataTable (sunucu pagination/filter), Form (Input/Select), Modal, StatusBadge (transfer durumu), Button, Toast.

## 4. Veri kaynakları
| İşlem | Endpoint |
|---|---|
| Hareketler | `GET /api/v1/stock/movements` |
| Giriş/Çıkış | `POST /api/v1/stock/stock-in` · `stock-out` |
| İmha | `POST /api/v1/stock/destroy` |
| Sayım | `POST /api/v1/stock/count` |
| Transfer | `POST /api/v1/stock/transfers` + `/{id}/confirm` · `/receive` · `/cancel` |

## 5. 4 state
- loading: skeleton tablo · empty: "Hareket yok" · error: "Yüklenemedi · Tekrar dene" · success: tablo/form sonucu Toast.

## 6. Özel kurallar
- Düşük stok eşiği (Threshold) görsel uyarı.
- Transfer teslimde **kısmi miktar** desteği (ReceivedQuantity).
- Append-only: kayıt silinmez; düzeltme ters hareketle.

## 7. "Yakında"
- Barkod ile sayım (🔜) · reçete bazlı otomatik düşüm (combo'ya bağlı, 🔜).
