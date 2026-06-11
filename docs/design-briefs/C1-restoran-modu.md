# Design Brief — C1: Restoran Modu (Masa / KDS / QR / Kurye)

> **Faz B · pos-web · 🔜 Backend YOK → tasarımda "Yakında" rozeti + disabled.** Konvansiyon: `A2-pos-satis-ekrani.md`. Benchmark: Simpra/Adisyo çekirdeği.

## 1. Amaç
Türkiye restoran pazarının çekirdek modülleri. Faz B'de gerçekleşecek; şimdi **görsel hedef + "Yakında"** olarak tasarlanır ki ürün vizyonu net olsun.

## 2. Ekran grupları (hepsi "Yakında")
- **Masa planı / kat şeması**: salon görünümü, masa durumu (boş/dolu/ödeme bekliyor), masaya sipariş, masa birleştir/böl, hesap böl (split).
- **KDS (mutfak ekranı)**: gelen siparişler istasyon bazlı, hazırlanıyor/hazır, süre takibi, "86" (tükendi) işaretleme.
- **QR menü / garson çağrı**: müşteri masadan QR ile sipariş/çağrı; POS'a düşer.
- **Online sipariş / kurye (canlı panel)**: **Trendyol Yemek · Getir · Yemeksepeti** (+ kendi mobil app) siparişleri tek kuyrukta; **kabul/ret**, hazırlık süresi, hazır/kuryede durumu, kurye atama/teslim takibi. Sesli/görsel uyarı (yeni sipariş). Geçmiş/takip görünümü `A8-pos-siparisler.md`'de (kaynak rozeti + filtre).

## 3. DS bileşen eşlemesi
Masa kartları (özel), KDS ticket kartları, StatusBadge (yoğun renk kodu), Drawer, sürükle-bırak (masa birleştir).

## 4. Veri kaynakları
**Hiçbiri yok (🔜).** Faz B'de Codex restoran modülünü (masa/KDS/online sipariş entity + endpoint) çıkaracak. Tasarım buna girdi olur.

## 5. Tasarım yaklaşımı
- Tüm bu blok **disabled + "Yakında" rozeti**; menüde görünür ama tıklanınca "Bu modül yakında" bilgi ekranı.
- Yine de tam mockup üretilir (Faz B backend kapsamını belirlemek için).

## 7. Not
Bu brief onaylanınca Faz B planı (backend modülü + endpoint listesi) ayrı çıkarılır.
