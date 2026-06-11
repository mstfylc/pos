# Design Brief — A6: Offline Kuyruk + Fiş Köprüsü

> Faz A · pos-web · Öncelik 3 (en riskli entegrasyon). Konvansiyon: `A2-pos-satis-ekrani.md`.

## 1. Amaç
İnternet kesilince satışın durmaması (offline outbox + sync) ve termal fiş yazdırma (Go köprü) — köprü erişilemese bile satış bloklanmaz.

## 2. Layout bölgeleri
- **Üst bar göstergesi (kalıcı)**: yeşil=online · sarı="Çevrimdışı · kuyrukta N sipariş".
- **Sync paneli** (gösterge tıklanınca): bekleyen siparişler listesi, durum (kuyrukta/gönderiliyor/başarılı/çakışma), "şimdi senkronla".
- **Fiş çıktısı akışı**: satış sonrası otomatik yazdır; köprü yoksa modal "Yazıcıya ulaşılamadı · Tekrar dene / Atla".

## 3. DS bileşen eşlemesi
StatusBadge (online/offline), Drawer/Modal (sync paneli), List (kuyruk), Alert (köprü hatası), Toast.

## 4. Veri kaynakları
| Veri | Kaynak |
|---|---|
| Outbox | client · IndexedDB (Service Worker) |
| Senkron | `POST /api/v1/app/orders` (idempotencyKey ile) |
| Fiş | `POST http://localhost:9100/print` (Go köprü — **print-bridge boş, protokol tasarlanacak**) |

## 5. 4 state
- loading: "Senkronlanıyor" · empty: "Bekleyen sipariş yok" · error: çakışma (stok yetersiz vb.) satır kırmızı + sebep · success: "Tümü senkronlandı".

## 6. Özel kurallar (DESIGN_SYSTEM §4)
- Offline sipariş `offlineOrder=true`; online olunca `idempotency_key` ile gönderilir, çift kayıt olmaz.
- Sunucuda stok yetersizse o sipariş çakışma olarak işaretlenir (kullanıcıya net).
- Köprü hatası **satışı bloklamaz**; fiş tekrar denenebilir.

## 7. "Yakında"
- Bulut yazıcı / e-fiş (🔜) · fiş e-posta/SMS (🔜).
