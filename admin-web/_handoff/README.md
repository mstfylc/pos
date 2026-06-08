# Handoff: Uyanık — Tüm Yüzeyler (Web Sistemi)

## Genel Bakış
Bu paket, **Uyanık** (kahve/kütüphane zinciri) dijital sisteminin tüm ana ekranlarını içerir:
yönetim paneli, giriş ekranı, müşteri mağazası + sadakat ve şube dashboard'u. Hepsi
tek bir tasarım sistemi (Uyanık DS — Metronic tabanlı, lacivert + turuncu marka) üzerine kuruludur.

## Bu Tasarım Dosyaları Hakkında
`ekranlar/` klasöründeki HTML dosyaları **tasarım referanslarıdır** — niyet edilen görünümü ve
davranışı gösteren, tek dosyada çalışan (offline, çift tıkla açılır) prototiplerdir. Doğrudan
production'a kopyalanacak kod değildir.

Görev: bu HTML tasarımlarını **hedef kod tabanının kendi ortamında yeniden oluşturmaktır**
(React, Vue, vb. — mevcut desen ve kütüphanelerle). Henüz bir ortam yoksa, projeye en uygun
framework'ü seçip tasarımları orada hayata geçirin. Bu prototipler React + Babel (in-browser)
ile yazılmıştır; gerçek üründe derlenmiş bir kurulum kullanın.

`design_handoff/kaynak/` içinde düzenlenebilir tüm kaynak (token CSS'leri, bileşen JSX/d.ts,
ekran view'ları, marka assetleri) bulunur — birebir değer çıkarmak için bunu referans alın.

## Fidelity
**Yüksek (hi-fi).** Renkler, tipografi, boşluklar ve etkileşimler nihaidir. UI'ı kod tabanının
kendi kütüphaneleriyle **piksel düzeyinde** yeniden kurun. Tüm değerler CSS custom property
(token) olarak `design_handoff/kaynak/tokens/` içinde tanımlıdır — sabit değer (magic number)
yazmayın, token'ları taşıyın.

---

## Ürün Kuralları (proje genel — CLAUDE.md)
Bu kurallar **tüm ekranlarda** geçerlidir:

- **Lacivert `#1F3864` yapısaldır**: menü, başlık, link, nötr aksiyon.
- **Turuncu `#E08A2B` SADECE tek primary CTA içindir.** Bir ekranda **en fazla bir** dolu turuncu buton.
- Secondary = lacivert outline / nötr · Tertiary = ghost · Silme = kırmızı (danger).
- Her **veri ekranı** dört durum gösterir: **yükleniyor · boş (+ aksiyon) · hata · dolu.**
- Dil **Türkçe**; para **₺**; tarih **GG.AA.YYYY**.
- Tüm admin ekranları aynı kabuğu paylaşır (sol menü + üst bar) → `AdminShell`.
- Yeni bileşen icat etme — DS primitiflerini kullan.
- Responsive + erişilebilir (label / focus / kontrast).

---

## Yüzeyler / Ekranlar

### 1. Yönetim Paneli — `ekranlar/Yönetim Paneli.html`
Çok ekranlı admin uygulaması. Sol menü + üst bar (AdminShell) içinde router ile 15 view.

**Layout:** Sol sabit sidebar (260px, lacivert `#1F3864`) · üst bar (şube seçici, arama, bildirim,
kullanıcı menüsü) · içerik alanı (max ~1180px, `PageHeader` + view gövdesi).

**View'lar (sidebar):** Ana Sayfa, Siparişler, Ürünler, Kategoriler, Stok/Depo, Stok Transferi,
Satın Alma, Müşteriler, İndirim & Kampanya, Sadakat, Kullanıcılar, Roller & Yetkiler,
Şirket/Şube/POS, **Raporlar**, Ayarlar.

**Önemli view'lar:**
- **Ana Sayfa** — KPI kartları (ciro, sipariş, eşik-altı stok, sadakat üyesi), satış trendi bar
  grafiği, canlı sipariş akışı, en çok satan ürünler tablosu. Sağ üstte tarih aralığı seçici +
  tek turuncu CTA "POS'u Aç".
- **Raporlar** — iki sekme:
  - **Rapor Oluştur** (rapor oluşturucu): sol konfig kolonu [rapor türü (7) · tarih aralığı ·
    kırılım · filtreler · sütun seç/gizle · zamanlama toggle · "Raporu Hazırla" CTA] →
    sağda canlı önizleme [KPI şeridi + sıralanabilir/sayfalı DataGrid] → alt bar [format:
    Tablo/PDF/Excel/CSV + Yazdır + İndir]. **CSV ve Excel gerçekten indirilir** (Blob),
    PDF yazdırma penceresi açar. Dört durum (dolu/yükleniyor/boş/hata) preview seg ile gezilebilir.
  - **Genel Bakış**: özet KPI pano + kategori dağılımı + ödeme kırılımı.
  - Rapor türleri: Satış Özeti, Ürün Satışları, Stok Durumu, Ödeme Kırılımı, Müşteri & Sadakat,
    Personel Performansı, İade & İptal. Her tür kendi sütun setini ve (varsa) kırılım seçeneklerini taşır.
- **Ürünler / Siparişler / Müşteriler / Stok / Satın Alma / Transfer** — `DataGrid` tabanlı liste +
  `Drawer` detay/form + `Modal` silme onayı. Hepsi dört durumlu. Filtre barı (Input arama + Select'ler).
- **Kategoriler / Kullanıcılar / Roller / Kampanya / Ayarlar / Sadakat / Şirket** — form + tab tabanlı
  konfigürasyon ekranları (`Tabs`, `Switch`, `Input`, `Select`).

### 2. Giriş Ekranı — `ekranlar/Giriş Ekranı.html`
Ortalanmış login kartı (≈400px, `--radius-2xl`, `--shadow-lg`), noktalı arka plan deseni.
Marka kilidi (logo + "Uyanık" wordmark), e-posta/şifre `Input` (lead ikon), "Beni hatırla" `Checkbox`,
tek turuncu CTA "Giriş Yap", "Şifremi unuttum" link.

### 3. Mağaza & Sadakat — `ekranlar/Mağaza & Sadakat.html`
Müşteriye dönük web mağazası. `StoreShell` kabuğu (üst bar: logo, gezinme, sadakat puanı rozeti,
sepet) içinde view router:
- **Storefront** — ürün ızgarası, kategori filtreleri, sepete ekle.
- **Ürün Detay** — görsel + açıklama + "Sepete ekle".
- **Checkout** — sepet kalemleri (adet +/–), sadakat puanı kullan `Switch`, toplam, sipariş ver.
- **Sipariş Tamam** — onay ekranı.
- **Hesap** — profil, 2FA/bildirim `Switch`'leri.

### 4. Kütüphane Dashboard — `ekranlar/Kütüphane Dashboard.html`
Tek şube yönetim panosu: özet KPI'lar, satış trendi, canlı sipariş akışı. (Yönetim Paneli'nin
Ana Sayfa'sıyla aynı `LibraryDashboard` bileşenini kullanır.)

---

## Etkileşim & Davranış
- **Navigasyon:** sidebar/router state ile view değişir (gerçek üründe route'lara bağlayın).
- **DataGrid:** sunucu-taraflı his — kontrollü `sort`, `page/pageSize/total`, `onSortChange`,
  `onPageChange`. Boş/yükleniyor/hata durumları bileşen içinde.
- **Drawer/Modal:** scrim + Esc ile kapanır; footer'da tek primary aksiyon.
- **Toast:** `ToastProvider` + `useToast()` ile push; success/error/info/warning.
- **Rapor indirme:** CSV (`text/csv`, UTF-8 BOM, `;` ayraç), Excel (`application/vnd.ms-excel`,
  HTML tablo), PDF (yeni pencere + `window.print`).
- **Geçişler:** `--transition-base` (0.2s, `cubic-bezier(0.4,0,0.2,1)`); hover'da hafif
  `translateY(-1px)` + gölge yükselmesi kartlarda.
- **Erişilebilirlik:** her input'ta label, görünür focus ring (`--shadow-focus`), 44px+ dokunma hedefi.

## State Yönetimi
- View/route state (aktif ekran), filtre state'leri (arama, kategori, durum), sayfalama+sıralama,
  drawer/modal açık/kapalı, form değerleri + inline hata, toast kuyruğu.
- Rapor oluşturucu: `type`, `group`, `range` (+ özel tarih), filtreler, gizli sütunlar, format,
  `ran/stale/state` (önizleme yaşam döngüsü), `page/sort`.
- Gerçek üründe: liste verileri için sunucu sorgusu (sayfalama/sıralama/filtre parametreleriyle).

## Tasarım Token'ları
Tam tanımlar: `design_handoff/kaynak/tokens/` (`colors.css`, `typography.css`, `spacing.css`,
`fonts.css`, `base.css`). Tek giriş: `styles.css` (hepsini `@import` eder).

**Renk (Light):**
- Primary (navy): `--color-primary #1f3864` · active `#162a4c` · soft `#eaeef4`
- Accent/CTA (orange): `--color-accent #e08a2b` · active `#c6751c` · soft `#fbf1e4`
- Success `#0bc33f` · Danger `#ed143b` · Warning `#fec524` · Info `#4921ea` (her biri soft varyantlı)
- Metin: heading `#1b1c22` · body `#4b5675` · muted `#78829d` · placeholder `#99a1b7`
- Yüzey: page `#fcfcfc` · card `#ffffff` · muted `#f9f9f9` · border `#f1f1f4` / strong `#dbdfe9`
- Grey ramp 50→950 · Dark tema `[data-theme="dark"]` ile opt-in (tam set tokens/colors.css'te).

**Tipografi:** `Inter` (sans, workhorse 500) · `JetBrains Mono` (mono/sayısal).
Ölçek: 2xs 11 · xs 12 · **sm 13 (body)** · base 14 · md 15 · lg 16 · xl 18 · 2xl 20 · 3xl 22 ·
4xl 26 · 5xl 32 · 6xl 38 · display 50. Ağırlık 400/500/600/700. ls-tight `-0.01em` başlıklarda.

**Boşluk (0.25rem taban):** 4 · 8 · 12 · 16 · 20 · 24 · 28 · 32 · 40 · 48 · 64.

**Radius:** xs 4 · sm 6 (buton/input/badge) · md 8 · **lg 12 (kart)** · xl 16 · 2xl 20 · full 999.

**Gölge (yumuşak, düşük opaklık):** xs/sm (kart) · md (raised) · lg (dropdown) · xl (modal) ·
focus `0 0 0 3px var(--ring-primary)`.

## Bileşenler (Uyanık DS)
Namespace: `window.MetronicDesignSystem_a73f8f`. API sözleşmeleri `kaynak/components/**/*.d.ts`.
- **Primitifler:** Button, IconButton, Input, Select, Textarea, Checkbox, Radio, Switch, Card
  (+Header/Body/Footer), Badge, Avatar(+Group), Tabs, Tag, Separator, Alert, Progress, Icon (KeenIcons).
- **Bileşik:** DataGrid, Modal, Drawer, ToastProvider/useToast, StatusBadge.
- **Uygulama kabuğu:** AdminShell + PageHeader (`kaynak/ui_kits/admin-app/AdminShell.jsx`),
  StoreShell (`kaynak/ui_kits/store/`).

## Assetler
`design_handoff/kaynak/assets/`:
- **Logo:** `logo-mark.svg` (navy), `logo-mark-dark.svg`, owl varyantları, `logo-badge.svg`.
- **İkonlar:** `icons/*.svg` (49 KeenIcons, `fill="currentColor"`); plain HTML için `icons.js`.
  React'te `<Icon name="...">` ile kullanılır (inline SVG map).
- **Desenler:** `patterns/pattern-dots.svg`, `pattern-grid.svg`.
- **Ürün görseli:** `products/sneaker.png` (placeholder; gerçek ürün görselleriyle değiştirin).

## Dosyalar
- `ekranlar/*.html` — 4 standalone ekran (çift tıkla çalışır; font'lar online iken Google Fonts'tan gelir).
- `design_handoff/kaynak/` — düzenlenebilir kaynak:
  - `styles.css` + `tokens/` — tüm tasarım token'ları
  - `components/` — DS primitif + bileşik bileşenler (`.jsx` + `.d.ts` API)
  - `ui_kits/admin-app/` — admin ekranları (her view ayrı `.jsx`; `ReportBuilder.jsx` rapor oluşturucu)
  - `ui_kits/store/`, `ui_kits/library/` — mağaza ve şube panosu
  - `assets/` — logo, ikon, desen, görseller
  - `readme.md` — DS tasarım rehberi · `CLAUDE.md` — ürün kuralları
- `../readme.md` — tasarım sistemi rehberi (paket kökünde de var).
