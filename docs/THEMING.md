# Temalandırma (Theming) — Plan

> **Karar (2026-06-11):** Arayüz tek renge kilitli değil. Token-tabanlı temalama; **hazır palet galerisi + açık/koyu**. Değiştirebilenler: (1) **İşletme (tenant) marka teması**, (2) **kullanıcı açık/koyu + palet**. İleride özel renk (color picker) eklenebilir.
> Bağlayıcı: `DESIGN_SYSTEM.md` §1 (multi-tenant token override). Uygulama: `DESIGN_SYSTEM_CONSOLIDATION.md` (tek token kaynağı + codegen).

## 1. İlke: bileşen renge değil, **semantic token'a** bakar
Hiçbir bileşen `#1F3864` görmez. 3 katmanlı token:

```
1) Primitive   ham palet (gray-0..900, base renkler) — sabit
2) Semantic    role: --color-primary, --color-accent, --surface-bg, --surface-card,
               --text-primary, --text-muted, --border, --success/--warning/--danger/--info
3) Theme       semantic'lere DEĞER atayan set: {palette} × {light|dark}
```
Bileşenler **yalnız semantic** kullanır → tema değişince her şey otomatik döner. Lacivert/turuncu artık "varsayılan tema", "tek seçenek" değil.

## 2. Hazır palet galerisi (öneri — başlangıç seti)
Her palet `primary` + `accent` belirler; nötr/surface açık/koyu ile gelir. Semantic (success/warning/danger/info) tüm paletlerde ortak.

| Palet | primary | accent | Ton |
|---|---|---|---|
| **Lacivert/Turuncu** (varsayılan) | `#1F3864` | `#E08A2B` | Kurumsal, sıcak vurgu |
| **Yeşil/Amber** | `#1E7145` | `#E0A52B` | Taze, restoran/market |
| **Mor/Teal** | `#5B3E9B` | `#1FA8A0` | Modern, genç |
| **Antrasit/Mavi** | `#2B3440` | `#2E75B6` | Nötr, minimal |
| **Bordo/Altın** | `#7A263A` | `#C9961A` | Premium, fine-dining |

> Galeri genişletilebilir; her palet `themes/<id>.json` olarak eklenir.

## 3. Açık / Koyu (light/dark)
Her palet iki yüzeyle gelir:
- **Light**: bg `#F7F9FC`, card `#FFFFFF`, text `#1A1F26` (mevcut neutral skala).
- **Dark**: bg `#1A1F26`, card `#222831`, text `#F7F9FC`, border koyu. primary/accent hafifçe açılır (kontrast).
- Varsayılan: light; "sistem" seçeneği OS tercihini izler.

## 4. Kim neyi değiştirir + öncelik
```
primitive  <  palet(theme)  <  tenant marka override  <  kullanıcı (palet + açık/koyu)
```
| Aktör | Ne seçer | Nerede saklanır |
|---|---|---|
| **İşletme (tenant admin)** | Marka paleti (+ ileride özel hex) + logo | `company_settings` (backend) — tüm personele yansır |
| **Kullanıcı (personel)** | Açık/koyu + (ops.) farklı palet | Yerel (localStorage / cihaz) — kişiye özel |
| **Mobil müşteri** | Açık/koyu (cihaz) | İşletmenin marka temasını görür; ayrı son-müşteri paleti yok (bu turda kapsam dışı) |

> Kullanıcı seçimi tenant varsayılanını **kendi cihazında** ezer; tenant markası org genel varsayılanıdır.

## 5. Çalışma mekanizması
- **Web**: semantic token'lar CSS custom properties (`:root` + `[data-theme][data-mode]`). Tailwind `var(--color-*)`'a map. Tema değişimi = attribute değişimi, **rebuild yok, runtime**.
- **Flutter**: aynı tema JSON'larından `ThemeData` (light/dark) üretilir; `ThemeMode` + tenant brand `company_settings`'ten.
- **Tek kaynak**: `packages/design-tokens` → codegen ile web CSS + Flutter tema (bkz. CONSOLIDATION Adım 1). Paletler ve light/dark **aynı pipeline'dan** üretilir.

## 6. Backend ihtiyacı (Codex)
- `company_settings`: `theme_palette_id`, `brand_primary?`, `brand_accent?`, `logo_url`, `theme_mode_default`.
- `GET/PUT /api/v1/admin/settings/theme` (tenant tema oku/yaz).
- App init'te tenant teması yüklenir; kullanıcı tercihi client'ta.

## 7. Tasarım (Claude Design) etkisi
- Mockup'lar **semantic token** ile çizilir; renkler "primary/accent/surface" olarak adlandırılır, hex gömülmez.
- En az **varsayılan palet + 1 alternatif** ve **light + dark** örneği üretilmeli (token doğru kurulduğunu kanıtlar).
- Tema seçici ekranı: **Ayarlar → Görünüm** (işletme paleti galerisi) ve üst bar/menüde **açık-koyu toggle**.

## 8. Yapılacaklar (özet)
1. tokens.json'u 3 katmana ayır (primitive/semantic/theme) + `themes/` paletleri.
2. Codegen: her palet × light/dark → web CSS + Flutter ThemeData.
3. `packages/ui`: ThemeProvider (data-theme/data-mode), açık-koyu toggle, palet seçici.
4. Backend: `company_settings` tema alanları + endpoint (Codex).
5. Ayarlar → Görünüm ekranı (Design brief: ileride `B5-admin-gorunum-tema.md`).
