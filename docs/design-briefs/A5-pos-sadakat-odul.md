# Design Brief — A5: Sadakat Paneli + Ödül Kullanımı

> Faz A · pos-web · Öncelik 2. Konvansiyon: `A2-pos-satis-ekrani.md`. Müşteri bağlıyken A2 sağ panelinde/alt çekmecede görünür.

## 1. Amaç
Sepete bağlı müşteri için **anlık sadakat etkisini** göstermek (kazanılacak puan, uygulanan kampanya) ve **ödül kullandırmak** (puan → indirim/ücretsiz ürün).

## 2. Layout bölgeleri
- **Önizleme kartı**: "Bu satışta +X puan" · uygulanan kampanya(lar) · mevcut puan/tier.
- **Ödüller listesi**: kullanılabilir ödüller (yeterli puan varsa aktif, yoksa "X puan gerekli" pasif).
- Ödül seç → sepete indirim/ücretsiz ürün olarak yansır (redemption code üretilir).

## 3. DS bileşen eşlemesi
Card (önizleme, accent/turuncu vurgu), List (ödüller), Button (kullan), StatusBadge (puan/tier), Progress (tier ilerleme — ops.).

## 4. Veri kaynakları
| Veri | Endpoint |
|---|---|
| Sadakat önizleme | `POST /api/v1/app/loyalty/preview` (sepet + customerId) |
| Ödül kullan | `POST /api/v1/app/loyalty/rewards/{rewardId}/redeem` |

## 5. 4 state
- loading: spinner · empty: müşteri yoksa panel gizli / "Müşteri ekleyince görünür" · error: "Önizleme alınamadı" (satışı bloklamaz) · success: puan/kampanya gösterimi.

## 6. Özel kurallar
- Önizleme satışı **bloklamaz**; hata olsa da satış sürer.
- Puan yetersizse ödül pasif + gerekli puan etiketi.
- Redeem geri alınabilir (satış iptalinde reversal — backend yapar).

## 7. "Yakında"
- Damga kartı (stamp) ilerleme görseli POS'ta (🟡) · kişiye özel teklif (🔜).
