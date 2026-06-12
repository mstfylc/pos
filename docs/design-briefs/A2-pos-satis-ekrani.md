# Design Brief — A2: POS Satış Ana Ekranı

> **Faz A · pos-web · Öncelik 1 (satış çekirdeği).** Claude Design bu brief'i alır, görsel + akış üretir; onaylanınca Claude Code DS token/bileşenleriyle kodlar.
> Referanslar: `ARCHITECTURE.md`, `docs/DESIGN_SYSTEM.md` (özellikle §4 POS kuralları), `docs/POS_FEATURE_MAP.md` §1.
> Görsel temel: **Metronic** (lacivert/turuncu). Token'lar hardcode edilmez.

## 1. Amaç ve bağlam
Kasiyerin **en az tıkla** satış yaptığı ana ekran. Estetikten önce **hız + hata önleme**. Dokunmatik (tablet/POS terminali). Sürekli açık kalır; gün boyu kullanılır.

Kullanıcı: kasiyer/personel (giriş yapılmış, POS seçilmiş). Tipik akış: ürüne dokun → sepete düşsün → (ops. müşteri tanı) → Ödeme → fiş.

## 2. Layout bölgeleri (yatay tablet, ~1280×800)

```
┌─────────────────────────────────────────────────────────────┐
│ ÜST BAR: logo · POS adı/şube · [Müşteri ekle] · ⚙ · sync●   │  ← offline göstergesi sağda
├──────────────────────────────────────┬──────────────────────┤
│ KATEGORİ ŞERİDİ (yatay, renk/şekil)   │                      │
│ [⭐Favoriler][Tümü][İçecek][Yemek]... │   SEPET (sağ panel)  │
├──────────────────────────────────────┤   - satır listesi    │
│                                       │   - adet +/− · sil   │
│   ÜRÜN GRID (kartlar ≥80×80px)        │   - satır notu       │
│   [Ürün][Ürün][Ürün][Ürün]            │   [İndirim][Kupon🔜]  │
│   [Ürün][Ürün][Ürün][Ürün]            │   Ara toplam         │
│   [Ürün][Ürün][Ürün][Ürün]            │   İndirim / Puan      │
│                                       │   TOPLAM (büyük)     │
│   [🔍 arama / barkod]                  │   ───────────────    │
│                                       │   [ÖDEME] (büyük CTA)│
└──────────────────────────────────────┴──────────────────────┘
```

- **Sepet her zaman görünür** (DESIGN_SYSTEM §4). Mobil/dar ekranda sepet alt çekmeceye iner.
- **Ödeme butonu** sepet toplamı > 0 değilse pasif; tıklanınca **Checkout modalı** açılır (ayrı brief A3).

## 3. Bileşenler ve DS eşlemesi

| Bölge | DS bileşeni | Not (Metronic stili) |
|---|---|---|
| Üst bar | Card/Toolbar + IconButton | POS/şube adı, müşteri çipi, ayar |
| Offline göstergesi | StatusBadge | yeşil=online · sarı="Çevrimdışı · kuyrukta N" |
| Kategori şeridi | Tag/Chip (yatay scroll) | CategoryColor/Shape ile renk-kod; başta **⭐Favoriler** sekmesi |
| Ürün kartı | Card (özel) | ≥80×80px, **küçük ürün foto (thumbnail)** + ad + fiyat; favori ⭐; görsel yoksa placeholder/baş harf; stok yoksa soluk + "Tükendi" |
| İndirim butonu | Button (secondary) | tanımlı indirim seç + yetki + tutar (modal) |
| Kupon butonu | Button (ghost, **disabled** 🔜) | "Yakında" rozeti |
| Arama/barkod | Input (search) | barkod okutmada otomatik sepete ekle |
| Sepet satırı | List item | adet stepper, sil (IconButton), not |
| Toplam alanı | Card | TOPLAM en büyük tipografi (2xl/3xl) |
| Ödeme | Button primary/lg | loading state zorunlu |

> Yeni buton/input icat etme; DS sözleşmesini kullan (DESIGN_SYSTEM §2).

## 4. Veri kaynakları (üretilen client — elle fetch yok)

| Veri | Endpoint | Not |
|---|---|---|
| Kategoriler | `GET /api/v1/app/categories?companyId` | renk/şekil alanları |
| POS ürünleri | `GET /api/v1/app/pos/{posId}/products` | **POS'a özel fiyat + stok**; `image` (ürün görseli) döner → kartta thumbnail |
| Favori ürünler | ürün listesi `favoriteProduct` filtresi | ⭐Favoriler sekmesi (`Product.FavoriteProduct`); müşteri bağlıysa `CustomerFavoriteProduct` |
| Giriş ürünü | ürün `entryProduct` alanı + order `lines[].isEntry` | giriş ürünü ücretsiz satır (₺0), stok düşer, `reports/entry-products` |
| Tanımlı indirimler | `GET /api/v1/app/discounts` | indirim seçici listesi (kapsam: şube/POS/personel) |
| Müşteri tanıma | `POST /api/v1/app/customers/identify` | modal alt akış (telefon/QR) |
| Sadakat önizleme | `POST /api/v1/app/loyalty/preview` | müşteri eklenince sepette "kazanılacak puan" |
| Sipariş oluştur | `POST /api/v1/app/orders` | Checkout modalında (A3) · `idempotencyKey` zorunlu |
| Sepet | client-side | IndexedDB (offline outbox) |

## 4b. Ürün kurgusu — birim · fiyat · vergi · varyant (kritik)
POS kartı basit değil; ürün modeli zengin. `PosProductSaleDto` şunları döner ve UI bunlara uymalı:

### Birim tipi (ProductUnitType: Adet / Gram / ML) ✅
- **Adet**: karta dokun → +1 (mevcut davranış).
- **Gram / ML (tartılı)**: dokununca **miktar/tartı girişi** açılır (numpad, ör. 250 g) → `quantity` o miktar olur. "+1 adet" mantığı bunlarda **çalışmaz**. Kartta birim etiketi (g/ml/adet) görünür.

### Fiyat: base + POS override ✅
- Geçerli fiyat = **`salePrice` (POS override) ?? `baseSalePrice`**. Override varsa kartta küçük "POS fiyatı" işareti.
- Fiyat client'ta uydurulmaz; DTO'dan gelir.

### Vergi (TaxType: %1 / %8 / %18) ✅
- Her ürünün KDV oranı var. Satır vergisi hesaplanır (`lines[].taxAmount`); checkout/fişte **KDV gösterimi**.

### Stok kontrolü ✅
- `stocktaking=true` üründe `stockQuantity` 0 ise "Tükendi", eklenmez. `stocktaking=false` ürün **her zaman** satılır (stok kontrolsüz).

### Combo / alt ürün / varyant — 🔜 backend eksik
- Model destekliyor (`ProductSubProduct` Visible/Default, `Main`/`ParentId`) **ama yeni `PosProductSaleDto` alt ürün/varyant DÖNDÜRMÜYOR** ve order create alt satır almıyor.
- Tasarımda combo/seçenek paneli ve varyant seçimi **"Yakında" + disabled** çizilir.
- **Backend ihtiyacı (Codex):** `PosProductSaleDto`'ya `subProducts[]` (Visible/Default/price) + varyant; `CreateAppOrderLineRequest`'e alt ürün satırı.

## 5. Zorunlu 4 state (her veri bölgesi)

| Bölge | loading | empty | error | success |
|---|---|---|---|---|
| Ürün grid | skeleton kartlar | "Bu kategoride ürün yok" + ikon | "Ürünler yüklenemedi · Tekrar dene" | kart grid |
| Kategori şeridi | skeleton chip | "Kategori yok" | sessiz retry | chip'ler |
| Sepet | — | "Sepet boş · ürün seçin" | — | satırlar + toplam |
| Sadakat paneli | spinner | müşteri yoksa gizli | "Önizleme alınamadı" (satışı bloklamaz) | "Bu satışta +X puan" |

## 6. Etkileşim akışı
1. Ekran açılır → kategoriler + ürünler yüklenir (varsayılan "Tümü").
2. Kategoriye dokun → grid filtrelenir (anında, client-side cache).
3. Ürüne dokun → sepete +1 (görsel/haptik geri bildirim). Tekrar dokun → adet artar.
4. Sepet satırında +/− adet, sil, not ekle.
5. (Ops.) "Müşteri ekle" → identify modalı (telefon/QR) → seçilince sadakat paneli + cüzdan görünür.
6. "ÖDEME" → Checkout modalı (A3): çoklu ödeme, ödeme=toplam kontrolü, idempotency.
7. Başarılı → fiş yazdır (köprü) + sepet temizlenir + toast "Satış tamamlandı".

## 7. POS/dokunmatik kuralları (DESIGN_SYSTEM §4)
- Dokunmatik hedef **≥48px**, ürün/kategori kartı **≥80×80px**.
- Ödeme toplamı sepet toplamına eşit değilse "Kapat" pasif (A3'te).
- Offline durumu üst barda **kalıcı** gösterge.
- Yazıcı köprüsü (localhost:9100) erişilemezse: uyarı + "tekrar dene", **satışı bloklamaz**.
- Renk/spacing/tipografi yalnız token'dan (lacivert #1F3864 / accent #E08A2B).

## 7c. Favoriler · İndirim · Kupon akışları

### Favoriler (✅)
- Kategori şeridinde başta **⭐Favoriler** sekmesi → `favoriteProduct` filtresiyle öne çıkan ürünler.
- Ürün kartında favori işareti (⭐); uzun bas/aksiyon ile favoriye ekle-çıkar (`Product.FavoriteProduct`).
- Müşteri bağlıysa onun favorileri (`CustomerFavoriteProduct`) ayrı gösterilebilir.

### Manuel indirim (✅)
- Sepette **[İndirim]** → modal: `app/discounts`'tan tanımlı indirim seç (yüzde/tutar), **yetkili kullanıcı** (userId) + tutar gir.
- **Limit:** `MaxDiscountAmount`'ı aşan tutarda uyarı/blok; kapsam (şube/POS/personel) dışıysa gösterme.
- Order'a `discounts[]` (discountId, userId, amount) olarak yazılır; sepet toplamı güncellenir.

### Kupon kodu (🔜 — backend yok)
- Sepette **[Kupon]** butonu var ama **disabled + "Yakında" rozeti**.
- Tasarımda kod girme alanı çizilir; aktif değil. Backend ihtiyacı (Codex): kupon/promo doğrulama endpoint'i.

### Giriş ürünü (entry product) (✅)
- Bazı ürünler **giriş ürünü** olabilir (`Product.EntryProduct=true`): müşteriye **ücretsiz** verilir ama **stoktan düşer** ve raporlanır (karşılama ikramı, abonelik/giriş hakkı, personel teslimi vb.).
- Ürün kartında **"Giriş" işareti/rozeti**; sepete eklerken (entry üründe) **"Giriş olarak ekle"** seçeneği.
- Sepet satırında **"Giriş · ₺0"** rozeti; satır **toplama katılmaz** ama stok düşer.
- Order'a `lines[].isEntry=true` yazılır (yalnız `EntryProduct=true` üründe).
- Teslim takibi: `reports/entry-products` (B4 raporlarında).

## 8. Bu ekranda "Yakında" (Faz B — disabled + rozet)
Tasarımda yeri ayrılır ama pasif gösterilir:
- **Combo / modifier seçimi** (ürün varyant/seçenek paneli) — 🔜
- **Siparişi beklet / park et (hold & recall)** — 🔜
- **Hesabı böl (split)** — 🔜
- **Kupon kodu** girişi — 🔜 (buton görünür, pasif)

> Not: **Favoriler ve manuel indirim "Yakında" değil — gerçek, backend hazır.** Sadece kupon Yakında.

## 9. Edge / hata durumları
- Stoğu biten ürün: kart soluk, "Tükendi", eklenmez (Stocktaking=true ürünlerde).
- Offline'a düşüş: üst bar sarıya döner, satış devam eder; siparişler kuyruğa, online olunca idempotency_key ile gönderilir.
- Fiyat/stok güncel değilse: pull-to-refresh / otomatik periyodik tazeleme.
- Ürün görseli (`image`) yoksa: placeholder kutu veya ürün baş harfi; layout bozulmaz.

## 10. Claude Design'dan beklenen çıktı
- Masaüstü/tablet ve dar (POS terminali) için **2 responsive varyant**.
- 4 state'in **görsel mockup**'ları (en az ürün grid + sepet için).
- Etkileşim akışı (tık-tık) ve "Yakında" öğelerinin disabled görünümü.
- Token referanslı renk/spacing (hardcode yok).

---
**Design'a verilecek sabit bağlam:**
> "Önce ARCHITECTURE.md ve docs/DESIGN_SYSTEM.md'yi oku. Metronic görsel temel; token'lar (lacivert #1F3864 / accent #E08A2B) hardcode edilmez. Yeni buton/input icat etme; bileşen sözleşmesini kullan. Her veri ekranı 4 state taşır (loading/empty/error/success). Faz B özellikleri 'Yakında' rozeti + disabled. Dokunmatik ≥48px, ürün kartı ≥80×80px."
