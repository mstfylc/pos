# Tasarım Sistemi — Mansis / Uyanık POS v2

> Claude Design ve Claude Code bu dosyayı her UI üretiminden önce okur. Amaç: hangi araç/oturumda üretilirse üretilsin ekranlar **aynı görünsün**. Token'lar `packages/design-tokens/tokens.json` içinde tek kaynaktan tutulur; kodda hardcoded renk/spacing YASAKTIR.

---

## 1. Tasarım Token'ları (tokens.json ile senkron)

### Renkler
```json
{
  "color": {
    "brand":   { "primary": "#1F3864", "primaryHover": "#2E5596", "accent": "#E08A2B" },
    "semantic":{ "success": "#1E7145", "warning": "#C9961A", "danger": "#C0392B", "info": "#2E75B6" },
    "neutral": { "0":"#FFFFFF","50":"#F7F9FC","100":"#EEF2F7","200":"#DDE4EE","300":"#C2CCD9","500":"#6B7785","700":"#3A434F","900":"#1A1F26" },
    "surface": { "bg":"#F7F9FC","card":"#FFFFFF","border":"#DDE4EE","overlay":"rgba(26,31,38,.45)" }
  }
}
```
- **brand.primary** = ana marka (lacivert), butonlar/başlıklar. **accent** = sadakat/CTA vurgusu (turuncu).
- Multi-tenant: her tenant `brand.primary` ve `accent`'i `company_settings`'ten override edebilir. Bileşenler token'a baktığı için tema runtime değişir.

### Tipografi
```
font-family: "Inter", system-ui, sans-serif   (mobil: Flutter → Inter / SF)
scale (px):  xs 12 · sm 14 · base 16 · lg 18 · xl 22 · 2xl 28 · 3xl 34
weight:      regular 400 · medium 500 · semibold 600 · bold 700
line-height: tight 1.25 · normal 1.5
```

### Spacing & Radius & Shadow
```
spacing (px): 4 · 8 · 12 · 16 · 24 · 32 · 48
radius (px):  sm 6 · md 10 · lg 16 · full 9999
shadow: sm 0 1 2 rgba(0,0,0,.06) · md 0 4 12 rgba(0,0,0,.08) · lg 0 12 32 rgba(0,0,0,.12)
```

---

## 2. Bileşen Sözleşmesi (hepsi token kullanır)

Her platformda **aynı isim ve davranışla** bileşenler bulunur:

| Bileşen | Kural |
|---------|-------|
| Button | variant: primary / secondary / ghost / danger · size: sm/md/lg · loading state zorunlu |
| Input / Select | label + hint + error state · validation FluentValidation/zod ile eşleşir |
| DataTable | sunucu-taraflı pagination/sort/filter · boş/yükleniyor/hata state'leri zorunlu |
| Modal / Dialog | onaylama, form, silme (destructive kırmızı) |
| Toast | success/warning/danger/info — semantic renkler |
| Card / Portlet | başlık + aksiyon alanı + içerik |
| FormLayout | tek sütun (mobil) / iki sütun (geniş) responsive |
| EmptyState | her liste ekranında "veri yok" görseli + aksiyon |
| StatusBadge | OrderState, transfer durumu, sync durumu için renk kodlu |

**Zorunlu state'ler (her veri ekranı):** loading · empty · error · success. Bir araç bunları atlarsa eksik kabul edilir.

---

## 3. Platforma Göre UI Stack

| Uygulama | Bileşen kütüphanesi |
|----------|---------------------|
| admin-web | React + **shadcn/ui** veya MUI + Tailwind (token'lar Tailwind config'e map edilir) |
| pos-web | React + Tailwind, **büyük dokunmatik hedefler** (min 48px), az tıkla satış |
| mobile | Flutter, Material 3, token'lar `ThemeData`'ya map edilir |
| customer-web | Next.js + Tailwind |

---

## 4. POS Web'e Özel Tasarım Kuralları (kritik)

POS satış hızı odaklıdır; estetikten önce **hız ve hata önleme**:
- Ürün/kategori kartları büyük, dokunmatik (≥ 80×80px), renk/şekil ile ayrışır (mevcut CategoryColor/Shape mantığı).
- Sepet her zaman görünür; ödeme 1-2 tık.
- Offline durumu üst barda kalıcı gösterge (yeşil=online / sarı=offline kuyrukta N sipariş).
- Ödeme toplamı sipariş toplamına eşit değilse "kapat" butonu pasif.
- Yazıcı köprüsü (localhost:9100) erişilemezse fiş yerine uyarı + tekrar dene.

---

## 5. Claude Design → Kod Akışı

1. **Claude Design**'da ekran görsel olarak iterasyona sokulur (layout, akış, durum). Çıktı: ekran spesifikasyonu + görsel.
2. Onaylanan tasarım, **token ve bileşen sözleşmesine** referansla Claude Code'a verilir: "DESIGN_SYSTEM.md token'larıyla, şu bileşenleri kullanarak bu ekranı kur."
3. Claude Code üretirken hardcoded değer kullanmaz; `design-tokens`'tan import eder.
4. Üretilen ekran DEFINITION_OF_DONE kontrol listesinden geçer.
