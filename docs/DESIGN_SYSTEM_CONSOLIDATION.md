# Tasarım Sistemi Konsolidasyonu — Plan / ADR

> **Karar:** Yeni DS kurmuyoruz. Mevcut Metronic-türevi DS'i **paylaşılan, çok-platformlu** tek tasarım sistemine toparlıyoruz; **tek token kaynağı = `packages/design-tokens/tokens.json`**.
> Tarih: 2026-06-11 · Kapsam: admin-web, pos-web, customer-web, mobile · Sahibi: frontend (Claude Code), token kaynağı paylaşımlı.
> Bağlayıcı: `ARCHITECTURE.md` (§3 sınır kuralları), `docs/DESIGN_SYSTEM.md`, `docs/WORKFLOW.md`.

## 1. Neden (bağlam)
Mevcut durumda DS üç parça hâlinde var ama **dağınık ve admin-web'e kilitli**:

| Parça | Konum | Sorun |
|---|---|---|
| Sözleşme | `docs/DESIGN_SYSTEM.md` | ✅ sağlam |
| Token kaynağı | `packages/design-tokens/tokens.json` | ✅ tam, ama tek başına kullanılmıyor |
| Bileşenler | `admin-web/src/design-system/` (21 `.jsx` + `.d.ts`) | ❌ sadece admin-web'de; pos/customer kopyalamak zorunda kalır |
| Token (kopya) | `admin-web/src/design-system/tokens/*.css` | ❌ **ikinci token kaynağı** → drift riski (README: "çelişirse DS CSS kazanır") |

pos-web başlamak üzere; şimdi toparlanmazsa **token drift'i üç uygulamada** yaşanır ve 3 kat refactor gerekir.

## 2. Hedef mimari: tek DS, çok platform

```
packages/design-tokens/tokens.json   ← TEK token kaynağı (renk/font/spacing/radius/shadow)
        │  codegen (Style Dictionary tarzı)
        ├──► packages/ui   (React + TS bileşenleri + üretilen CSS/Tailwind teması)
        │         └── admin-web · pos-web · customer-web  bunu import eder
        └──► mobile (Flutter)  ThemeData  ← aynı token'lardan üretilir
```

- **React tarafı**: `packages/ui` paketi tüm web uygulamaları besler. Bileşen tek yerde tanımlı, üç kez yazılmaz.
- **Flutter tarafı**: ayrı bileşen implementasyonu (Material 3) ama **aynı tokens.json**'dan ThemeData. Renk/spacing tek kaynaktan.
- **POS özel primitifler** (büyük dokunmatik kart, numpad): `packages/ui` içinde **uzantı**, yeni DS değil.

## 3. İlkeler (değişmez)
1. **Tek token kaynağı `tokens.json`.** Web CSS/Tailwind teması ve Flutter ThemeData **bundan üretilir**; elle ikinci kopya tutulmaz.
2. **Hardcoded değer yasak** (ARCHITECTURE §3.3): renk/spacing/tipografi token'dan.
3. **Bileşen icat etme** (CLAUDE.md 5): DESIGN_SYSTEM.md §2 sözleşmesindeki bileşenler kullanılır/genişletilir.
4. **TypeScript strict** (CLAUDE.md 6): yeni/taşınan bileşen `.tsx`, `any` yok.
5. **Multi-tenant**: `brand.primary` / `brand.accent` runtime'da `company_settings`'ten override (token CSS değişkenleri üstünden).

## 4. Adımlar (kodlama ayrı görevlerde; bu doküman plan)

### Adım 1 — Token codegen (tek kaynak, **çok temalı**)
- `tokens.json` **3 katmana** ayrılır: primitive / semantic / theme (bkz. `THEMING.md`). Bileşenler yalnız semantic kullanır.
- Paletler `themes/<id>.json` (Lacivert/Turuncu varsayılan + alternatifler) × **light/dark**.
- `tokens.json` → üretim: web için CSS değişkenleri (`[data-theme][data-mode]`) + Tailwind `var()` map; mobil için Dart `ThemeData` (light/dark).
- Araç önerisi: Style Dictionary (veya Node script). Çıktı `packages/design-tokens/dist/`.
- `admin-web/src/design-system/tokens/*.css` elle kaynak olmaktan çıkar → **üretilen** dosyaya bağlanır. Drift biter.
- **Çıktı tüm paletleri + light/dark'ı kapsar**; tema değişimi runtime (rebuild yok).

### Adım 2 — `packages/ui` paketini çıkar
- `admin-web/src/design-system/components` → `packages/ui/src` taşınır (barrel export korunur).
- admin-web bu paketi import eder (lokal kopya kalkar).
- pos-web ve customer-web **ilk günden** `packages/ui`'yi kullanır.

### Adım 3 — `.jsx` → `.tsx` strict geçiş (kademeli)
- Bileşen başına: `.jsx` + el `.d.ts` → tek `.tsx` (props tipi gerçek). Önce en çok kullanılanlar (Button, Input, Card, DataGrid, Modal, Toast, StatusBadge).
- Geçiş bitene kadar `allowJs` köprüsü kalır; biten bileşen strict olur.

### Adım 4 — POS uzantıları
- `packages/ui` içine POS primitifleri: büyük ürün/kategori kartı (≥80×80px), numpad, sepet satırı, offline StatusBadge varyantı. Aynı token'lar.

### Adım 5 — Flutter tema
- `tokens.json` → Dart token dosyası (codegen) → `ThemeData`. Bileşenler Material 3; renk/spacing hardcoded değil.

## 5. Sıra ve bağımlılık
- **Adım 1–2 pos-web başlamadan önce** yapılmalı (kritik yol; drift'i önler).
- Adım 3 paralel/kademeli, bloklamaz.
- Adım 4 pos-web ekranlarıyla birlikte.
- Adım 5 mobil (Faz 3) başlarken.

## 6. Definition of Done (bu konsolidasyon için)
- [ ] tokens.json tek kaynak; web+mobil temaları ondan üretiliyor.
- [ ] admin-web ikinci token CSS'ini elle tutmuyor (üretilen).
- [ ] `packages/ui` var; admin-web oradan import ediyor.
- [ ] pos-web/customer-web `packages/ui` tüketmeye hazır.
- [ ] Taşınan bileşenler strict `.tsx`, `any` yok.
- [ ] DESIGN_SYSTEM.md bileşen sözleşmesi korunuyor (isim/davranış aynı).

## 7. Kapsam dışı (bu iş değil)
- Yeni görsel dil / marka değişimi (Metronic + lacivert/turuncu kararı sabit).
- Yeni bileşen kütüphanesine geçiş (shadcn/MUI tartışması ayrı; mevcut sözleşme yeterli).
