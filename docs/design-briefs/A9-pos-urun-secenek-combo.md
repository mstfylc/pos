# Design Brief — A9: Ürün Seçenek / Combo / Varyant Paneli

> Faz A (tasarım) · pos-web · **Design-first**: arayüz tam tasarlanır, backend (Codex) buna göre eklenir. A2 satış ekranının alt akışı (ürüne dokununca açılır).
> Konvansiyon: `A2-pos-satis-ekrani.md`. Ürün kurgusu: A2 §4b.
> **Backend durumu:** Alt ürün/varyant verisi yeni `PosProductSaleDto`'da yok ve order create alt satır almıyor → bu ekran **gerçek tasarlanır ama bağlanınca devreye girer**. Şimdilik örnek veriyle çizilir; menüde combo'lu ürünlerde tetiklenir.

## 1. Amaç
Bir ürün **varyantlı** (boy/tip) veya **seçenekli/combo** (ProductSubProduct, Visible) ise; kasiyer sepete eklemeden önce **seçim** yapar. Reçete çıkarma ("soğansız"), ekstra ekleme, adet/miktar ve not da burada.

## 2. Ne zaman açılır
- Ürün kartına dokunulduğunda: ürünün **görünür alt ürünü** (`ProductSubProduct.Visible=true`) **veya** **varyantı** (`Main/ParentId`) varsa → panel açılır.
- Yoksa → doğrudan sepete (+1 / tartı), panel açılmaz.

## 3. Layout (modal/panel)
```
┌─────────────────────────────────────────────┐
│ [foto] Ürün adı            base fiyat · birim │
├─────────────────────────────────────────────┤
│ VARYANT (varsa): ( ) Küçük ( ) Orta ( ) Büyük │  ← radyo, fiyat değişir
│                                               │
│ SEÇENEK / EKSTRA (ProductSubProduct Visible): │
│   [✓] Peynir +₺10   [ ] Sos +₺5   [+]/[−] adet│  ← Default seçili gelir
│                                               │
│ ÇIKAR (reçete): [soğansız] [acısız] ...        │
│                                               │
│ ADET / MİKTAR: [−] 1 [+]   (tartılıysa numpad) │
│ NOT: [__________]                              │
├─────────────────────────────────────────────┤
│ Özet: base + seçenekler = TOPLAM   [SEPETE EKLE]│
└─────────────────────────────────────────────┘
```

## 4. Bölümler ve kurallar
- **Varyant** (`Main/ParentId`): tekli seçim (radyo); seçime göre fiyat/stok değişir. Zorunlu (bir varyant seçilmeden eklenemez).
- **Seçenek/ekstra** (`ProductSubProduct`): `Visible=true` olanlar listelenir; `Default=true` önceden seçili; `Quantity` adet; `Price` = fiyat farkı (+₺). Zorunlu/opsiyonel grup ayrımı (tasarım: grup başlığı + "1 seçin"/"çoklu").
- **Çıkar/reçete**: bileşeni çıkarma çipleri (fiyat değişmez).
- **Adet/miktar**: Adet ürün stepper; tartılı (Gram/ML) numpad (A2 §4b).
- **Not**: satır notu (mutfağa).
- **Özet fiyat**: base (POS override ?? base) + seçenek farkları, canlı güncellenir.

## 5. DS bileşen eşlemesi
Modal/Drawer (büyük, dokunmatik), Radio (varyant), Checkbox + Stepper (seçenek/adet), Tag/Chip (çıkar), Input (not), Button primary/lg (Sepete ekle), Badge (+₺ farkı).

## 6. Veri kaynakları
| Veri | Durum |
|---|---|
| Ürün varyantları (Main/ParentId) | 🔜 `PosProductSaleDto`'da yok → Codex ekleyecek |
| Alt ürün/seçenek (Visible/Default/Quantity/Price) | 🔜 `PosProductSaleDto.subProducts[]` Codex ekleyecek |
| Sepete yazım | 🔜 `CreateAppOrderLineRequest`'e alt ürün/varyant satırı Codex ekleyecek |

> Tasarım örnek veriyle yapılır. Backend gelince bağlanır.

## 7. 4 state
- loading: seçenekler yükleniyor (skeleton) · empty: seçeneksiz ürün → panel açılmaz · error: "Seçenekler yüklenemedi" · success: seçim + canlı toplam.

## 8. Özel kurallar
- Zorunlu varyant/grup seçilmeden "Sepete ekle" **pasif**.
- Sepette bu satır seçenekleriyle özetlenir (ör. "Pizza · Büyük · +Peynir · soğansız").
- Düzenleme: sepetteki seçenekli satıra dokununca panel tekrar açılır.
- Dokunmatik ≥48px.

## 9. Backend ihtiyacı (Codex — bu tasarım onaylanınca)
1. `PosProductSaleDto`: `variants[]` (parentId/options) + `subProducts[]` (id, name, visible, default, quantity, price).
2. `CreateAppOrderLineRequest`: `subProducts[]` / `variantId` + (combo'da) alt ürün stok düşümü kuralı.
3. Combo fiyatlama: base + seçenek `Price` farkları toplamı.
