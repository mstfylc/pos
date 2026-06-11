# Design Brief — A4: Müşteri Tanıma (Telefon / QR)

> Faz A · pos-web · Öncelik 2. Konvansiyon: `A2-pos-satis-ekrani.md`. A2'deki "Müşteri ekle" bunu açar.

## 1. Amaç
Satış sırasında müşteriyi tanıyıp sepete bağlamak (puan/cüzdan/kampanya etkinleşsin). İki yol: telefon/isim arama, QR/kart okutma.

## 2. Layout bölgeleri
- Modal: üstte **arama** (telefon/isim/mail) + **QR okut** butonu (kamera).
- Sonuç listesi (müşteri kartları: ad, telefon, puan/tier rozeti, cüzdan).
- Seçilince: müşteri sepete bağlanır; A2'de sadakat paneli + cüzdan görünür.
- "Yeni müşteri" hızlı ekleme (ad + telefon) — minimal.

## 3. DS bileşen eşlemesi
Modal, Input(search), Button (QR okut), List/Card (müşteri), StatusBadge (tier), Avatar.

## 4. Veri kaynakları
| Veri | Endpoint |
|---|---|
| Tanıma (telefon/QR) | `POST /api/v1/app/customers/identify` |
| Müşteri listesi/arama | `GET /api/v1/app/customers?companyId` |
| Müşteri kart token (QR) | `POST /api/v1/app/customers/{customerId}/card-token` |

> QR **süreli token** (customer_card_tokens); statik kart no ödeme yetkisi vermez.

## 5. 4 state
- loading: arama spinner · empty: "Müşteri bulunamadı" + "Yeni ekle" · error: "Tanıma başarısız / token süresi dolmuş" · success: müşteri seçili, panel güncellenir.

## 6. Özel kurallar
- QR süresi dolmuşsa net uyarı + tekrar okut.
- Müşteri kaldır (sepetten ayır) aksiyonu.

## 7. "Yakında"
- Yüz/biyometrik tanıma (🔜) · müşteri sadakat geçmişi detayı POS'ta (🔜).
