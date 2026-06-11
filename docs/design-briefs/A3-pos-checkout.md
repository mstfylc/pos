# Design Brief — A3: Checkout / Ödeme Modalı

> Faz A · pos-web · Öncelik 1 (satış akışını kapatır). Konvansiyon: `A2-pos-satis-ekrani.md`. A2'deki "ÖDEME" CTA bunu açar.

## 1. Amaç
Sepeti kesinleştirip **çoklu/bölünmüş ödeme** almak, ödeme = sipariş toplamı kontrolüyle hatasız kapanış, idempotency ile çift-kayıt önleme.

## 2. Layout bölgeleri
```
┌──────────────────────────────────────────┐
│ Sipariş özeti (satırlar, toplam büyük)     │
├──────────────────────────────────────────┤
│ Ödeme tipleri: [Nakit][Kart][Yemek K.]    │
│ Eklenen ödemeler listesi (tip + tutar)     │
│ Kalan: X ₺   (0 olunca yeşil)              │
│ [Hızlı nakit: tam/yuvarla] · numpad        │
├──────────────────────────────────────────┤
│ [Vazgeç]              [SATIŞI TAMAMLA]     │  ← kalan≠0 ise pasif
└──────────────────────────────────────────┘
```

## 3. DS bileşen eşlemesi
Modal (büyük), List (ödeme satırları), Button (ödeme tipleri + CTA), numpad (POS uzantı), StatusBadge (kalan/üstü), Toast (sonuç).

## 4. Veri kaynakları
| Veri | Endpoint |
|---|---|
| Sipariş oluştur | `POST /api/v1/app/orders` (lines, payments[], customerId?, offlineOrder, idempotencyKey) |

- **idempotencyKey** her satışta üretilir (offline outbox kalıcı tutar).
- `payments[]` çoklu satır; summary backend'de türetilir (tek tip → o tip, çok tip → Mixed).

## 5. 4 state
- loading: "Satış işleniyor" (buton spinner, çift tık engeli) · empty: yok · error: 400'de "Ödeme toplamı eşleşmiyor / stok yetersiz" net mesaj · success: "Satış tamamlandı" → fiş yazdır → sepet temizlenir.

## 6. Özel kurallar (DESIGN_SYSTEM §4)
- **Kalan ≠ 0 ise "Satışı Tamamla" pasif.**
- Para üstü: nakit > kalan ise "Para üstü: X ₺" göster.
- Offline'da: satış kuyruğa, "Çevrimdışı kaydedildi · senkronlanacak" bilgisi.
- Başarıdan sonra fiş köprüsü hatası satışı bloklamaz (bkz. A6).

## 7. "Yakında"
- Cüzdan/puan ile ödeme satırı (🟡 — wallet otomatik düşüyor, UI ayrı ele alır) · Kupon kodu (🔜) · Bahşiş (🔜).
