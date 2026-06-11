# Design Brief — A8: Siparişler (Liste + Detay + İptal/İade)

> Faz A · pos-web (+ admin-web paylaşımlı mantık) · backend ✅. Konvansiyon: `A2-pos-satis-ekrani.md`. Önerilen tasarım sırası: A3 checkout'tan sonra (satılanı görüntüle/yönet).

## 1. Amaç
Geçmiş siparişleri görüntülemek, detayına bakmak, **iptal** ve **iade (refund)** yapmak. POS'ta gün içi satışlar; admin'de tüm siparişler.

## 2. Layout / ekranlar
### a) Sipariş listesi
- Filtre çubuğu: tarih aralığı · durum · POS/şube · ödeme tipi · arama (sipariş no/müşteri).
- DataGrid (sunucu pagination): sipariş no · zaman · müşteri · toplam · ödeme özeti · **durum (StatusBadge)**.
- Satıra tıkla → detay (drawer/sayfa).

### b) Sipariş detay
- Üst: sipariş no, zaman, durum, müşteri, POS/personel.
- Satırlar: ürün · adet · birim fiyat · satır toplam (alt ürün varsa göster — backend gelince).
- Ödemeler: tip + tutar + durum (çoklu ödeme satırları).
- İndirimler / sadakat: uygulanan indirim, kazanılan puan.
- Aksiyonlar: **İptal**, **İade**, Fiş yeniden yazdır.

### c) İptal
- Modal: **Reason zorunlu** → onayla. Sonuç: stok/wallet/loyalty/ödeme **reversal** satırları (silme yok).

### d) İade (refund)
- **Satır bazlı / kısmi** iade: hangi satır/tutar → reason → onayla.

## 3. DS bileşen eşlemesi
DataGrid (filtre+pagination), StatusBadge (OrderState renk kodu), Drawer/Card (detay), Modal (iptal/iade onay — destructive kırmızı), Tag (ödeme tipi), Toast.

## 4. Veri kaynakları
| İşlem | Endpoint |
|---|---|
| Liste (POS) | `GET /api/v1/app/orders?companyId` |
| Liste (admin) | `GET /api/v1/admin/orders` |
| Detay | `GET /api/v1/app/orders/{orderId}` |
| İptal | `POST /api/v1/app/orders/{orderId}/cancel` (reason) |
| İade | `POST /api/v1/app/orders/{orderId}/refund` |

## 5. 4 state
- loading: skeleton tablo/detay · empty: "Bu filtrede sipariş yok" · error: "Yüklenemedi · Tekrar dene" · success: liste/detay.

## 6. Özel kurallar (ARCHITECTURE)
- **Hard-delete yok**: iptal/iade ters kayıt ekler (append-only ledger).
- İptal/iade **Reason zorunlu**.
- OrderState renkleri semantic: Received/Preparing(info) · Completed(success) · Cancelled(danger) · Transferring(warning).
- Çoklu ödemede `PaymentSummary` (tek tip / Mixed) gösterilir.

## 7. "Yakında"
- Alt ürün/combo satır gösterimi (🔜 backend) · sipariş durumu değiştirme/iş akışı (🔜) · sipariş notu/fatura (🔜).
