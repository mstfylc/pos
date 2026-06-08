# Uyanık Admin Web

React 19 + TypeScript + Vite + Tailwind v4 yönetim paneli.
Tasarım kaynağı: `_handoff/kaynak/` (Uyanık DS — Metronic tabanlı, lacivert + turuncu).

## Çalıştırma

```bash
npm install
npm run dev        # http://localhost:5173
npm run build      # tsc -b && vite build (tip kontrolü + prod build)
npm run typecheck  # sadece tip kontrolü
```

> Demo giriş: geçerli bir e-posta + herhangi bir parola → panele yönlendirir.
> Gerçek kimlik doğrulama + veri sonraki pakette (openapi `@mansis/api-client-ts`).

## Yapı

```
src/
├── design-system/     # Handoff DS (21 bileşen .jsx + .d.ts, tokens, assets) — vendored
│   └── index.ts        # barrel: uygulama DS'i SADECE buradan import eder
├── shell/             # AdminShell (sol menü + üst bar), nav tanımı
├── pages/             # LoginPage, DashboardPage (+ DashboardView), PlaceholderPage
├── lib/               # auth (mock + yetki iskeleti), assets
└── styles/index.css   # webfont + Tailwind + DS tokens + @theme
```

## Kurallar (bkz. kök `CLAUDE.md` / `ARCHITECTURE.md`)

- API tipi/fetch elle YAZILMAZ → `@mansis/api-client-ts` (OpenAPI'den üretilir).
- Renk/spacing/tipografi hardcode EDİLMEZ → DS token'ları (`design-system/tokens`).
- **Token tek kaynağı (admin-web):** Uyanık DS CSS = `_handoff/kaynak/tokens/*.css`
  (`src/design-system/tokens`'a taşındı). `packages/design-tokens/tokens.json` bunun
  TÜREVİDİR; **çelişirse DS CSS kazanır.** Tam birleştirme ileride; şu an değerler örtüşür.
- Yeni buton/input icat etme → DS primitiflerini kullan/genişlet.
- Her veri ekranı 4 durum: loading · empty · error · success.

## Bu paketin kapsamı (ilk iskelet)

✅ Çalışan iskelet: Login + Dashboard (mock data), AdminShell + react-router (15 view, yetki iskeleti),
21 DS bileşeni + tokens + marka assetleri, `@mansis/api-client-ts` bağımlılığı (kurulu, çağrı yok).
Diğer 14 view şimdilik "Geliştiriliyor" yer tutucu — sonraki paketlerde gerçek ekrana dönüşecek.
