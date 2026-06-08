# Uyanık Admin Web — İlk Paket Raporu (Çalışan İskelet)

**Tarih:** 2026-06-07 · **Branch:** `claude/charming-ramanujan-MM42Y` · **Commit:** `1b2eba8`
**Stack:** React 19 + TypeScript (strict) + Vite 6 + Tailwind v4

---

## Durum

| Kontrol | Sonuç |
|---|---|
| `npm install` | PASS (admin-web) |
| `npm run build` (`tsc -b && vite build`) | **PASS** — tip kontrolü + prod build temiz, uyarısız |
| `npm run dev` (http://localhost:5173) | **PASS** — tüm modüller HTTP 200, transform/resolve hatası yok |
| Login ekranı | Çalışıyor (mock auth → panele yönlendirir) |
| Dashboard | Çalışıyor (mock data: KPI, satış trendi, canlı sipariş, en çok satanlar) |

---

## Yapılanlar (istenen 6 madde)

1. **Proje kuruldu** — `admin-web/` içine React 19 + TS + Vite + Tailwind v4.
2. **Token + stiller bağlandı** — webfont (Inter/JetBrains Mono) + Tailwind + DS token CSS
   (`colors/typography/spacing/base`) + `@theme` marka eşlemesi. Lacivert `#1F3864`,
   turuncu accent `#E08A2B`, dark tema token'ları hazır.
3. **DS taşındı** — `_handoff/kaynak/components` (21 bileşen `.jsx` + `.d.ts`) + `assets`
   (logo, 49 ikon, patterns) → `src/design-system/`. Barrel `src/design-system/index.ts`
   üzerinden tek noktadan import. (Vendored: runtime `.jsx`, tipler `.d.ts`.)
4. **AdminShell + react-router** — 15 view sol menü (3 bölüm), şube seçici, arama,
   bildirim çanı, kullanıcı menüsü, üst bar, içerik alanı. Yetki iskeleti `auth.can()`
   (şimdilik tüm öğeler görünür).
5. **Login + Dashboard** — `LoginPage` (handoff login referansı) + `DashboardPage`
   (handoff `LibraryDashboard` port edildi), mock data. Diğer 14 view "Geliştiriliyor"
   yer tutucu.
6. **api-client-ts** — `@mansis/api-client-ts` bağımlılık olarak eklendi (kurulu, çağrı yok).

---

## Dosya yapısı

```
admin-web/
├── package.json · tsconfig*.json · vite.config.ts · index.html · .env.example · README.md
└── src/
    ├── main.tsx · App.tsx                # giriş + router (BrowserRouter, RequireAuth)
    ├── styles/index.css                  # webfont + Tailwind + DS tokens + @theme
    ├── design-system/                    # VENDORED handoff DS
    │   ├── index.ts                       # barrel (21 bileşen)
    │   ├── components/ · tokens/ · assets/
    ├── shell/
    │   ├── AdminShell.tsx · AdminShell.css · nav.ts   # 15 view sidebar + topbar
    ├── pages/
    │   ├── LoginPage.tsx (+Login.css)
    │   ├── DashboardPage.tsx · DashboardView.jsx (+.d.ts)
    │   └── PlaceholderPage.tsx (+Placeholder.css)
    └── lib/
        ├── auth.ts                        # mock oturum + yetki iskeleti
        └── assets.ts                      # logo/pattern URL importları
```

---

## Çalıştırma

```bash
cd admin-web
npm install
npm run dev        # http://localhost:5173
npm run build      # tsc -b && vite build
npm run typecheck  # sadece tip kontrolü
```

> Demo giriş: geçerli e-posta + herhangi bir parola → panele yönlendirir.

---

## Mimari notlar / kararlar

- **DS vendored kaldı** (`.jsx` + shipped `.d.ts`): `allowJs:true, checkJs:false, skipLibCheck:true`.
  Uygulama kodu (`.tsx`) tam strict; vendored DS bu strictliğin dışında. `any` elle yazılmadı.
- **Runtime/types ayrımı:** barrel `./Button` → TS `.d.ts` (tipler), Vite `.jsx` (runtime).
- **Tailwind v4** `@tailwindcss/vite` ile; marka token'ları `@theme`'e map'li (ileride `bg-brand`).
- **Faz notu:** ARCHITECTURE.md Faz 1'de OpenAPI kontratı netleşmeden veri bağlama yapılmaz —
  bu yüzden bu pakette API çağrısı YOK, sadece client bağımlılığı kuruldu.

---

## Bilinen sınır / sapma

- İstenen "15 view" sidebar'da tam karşılanıyor; ekranlardan yalnızca **Dashboard** gerçek,
  diğer **14'ü yer tutucu** (bu paket Login + Dashboard istiyordu).
- `_handoff/kaynak/ui_kits/admin-app/` altındaki 14 `*View.jsx` (ProductsView, OrdersView…)
  henüz port EDİLMEDİ — sonraki paketlerde DataGrid + Drawer + 4 durum ile bağlanacak.

---

## Sıradaki öneri

Bir veri ekranını uçtan uca bağlamak (örn. **Ürünler**): `ProductsView` portu →
DataGrid (sunucu-taraflı sort/sayfa) + Drawer form + Modal silme + 4 durum
(loading/empty/error/success). Endpoint eksikse `contracts/openapi.yaml`'a bildirilecek.
