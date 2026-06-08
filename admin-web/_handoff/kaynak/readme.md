# Uyanık Design System

A navy-and-orange brand design system built on the structural foundations of **Metronic v9.4.13** (KeenThemes), re-themed for **Uyanık** — a customer loyalty + commerce brand. It keeps Metronic's clean enterprise scaffolding (white cards, soft shadows, dense Inter type, KeenIcons) and re-skins it to the Uyanık palette: **navy `#1F3864`** as the structural/primary color and **orange `#E08A2B`** as the accent reserved for calls-to-action.

## Source
- **Figma:** `Metronic_v9.4.13.fig` (KeenThemes). Pages explored: Layouts, Components, Store (Retail & Inventory), Dashboards, Public Profiles, My Account, Network, Authentication, Overlays, Docs, Visuals. Colors and the semantic ramp were lifted from the file's Figma **Variables** (Light + Dark modes); button/field metrics and the logo geometry from the component frames.
- No codebase was supplied — everything here is reconstructed from the Figma design data, not from Metronic's shipped HTML/CSS.

> ⚠️ **Font substitution.** The UI font **Inter** and code font **JetBrains Mono** are loaded from Google Fonts (exact matches). The brand wordmark in the source uses **Museo Sans 900**, which is not freely licensable — it is substituted with a heavy Inter and the `METRONIC` wordmark is set in `--font-wordmark`. If you have the real Museo Sans files, drop them in and add a `@font-face`. (See *Open questions* at the bottom.)

---

## Content fundamentals
How Metronic writes — mirror this for on-brand copy.

- **Voice:** plain, professional, product-focused. It names features and numbers, not feelings. Reads like a capable B2B SaaS.
- **Person:** addresses the user as **you** ("Join us to share your insights"); UI labels are nouns/short verbs ("Connect", "Get started", "Add team", "View all teams").
- **Casing:** **Title Case for buttons & nav** ("Public Profile", "My Account", "Get Started"); **Sentence case for body copy and helper text**. Section eyebrows in the sidebar are **ALL-CAPS** with wide tracking (USER, PAGES, APPS).
- **Headings:** short and literal — "Dashboard", "Earnings", "Highlights", "Teams", "About", "Sales Overview". Often paired with a muted one-line subtitle ("Central hub for personal customization").
- **Numbers as hero:** compact metrics are a core motif — `9.3k`, `$295.7k`, `+2.7%`, `$34,233`. Growth deltas are colored (green up / red down) and frequently shown as a soft badge.
- **Microcopy:** encouraging but brief ("New here? Create an account", "Don't receive an email? Resend").
- **No emoji.** None in the product UI. Iconography carries all visual shorthand.
- **Tone example:** *"Unlock creative partnerships on our blog — explore exciting collaboration opportunities, guest posts and more. Join us to share your insights and grow your audience."*

---

## Visual foundations
- **Color.** **Brand split — navy is structural, orange is the CTA.** Primary navy `#1379F0`→`#1F3864` (active `#162A4C`, soft `#EAEEF4`, accent `#14233F`) drives nav-active, links, headers, footers and section chrome. Accent orange `#E08A2B` (active `#C6751C`, soft `#FBF1E4`) is reserved for primary actions — `<Button color="accent">`, cart badges, points/loyalty. Full semantic set keeps its rungs (success `#0BC33F`, danger `#ED143B`, warning `#FEC524`, info `#4921EA`). Neutrals are a true-grey ramp (`grey-50 #F9F9F9` → `grey-950 #151516`) **plus** a separate bluish **"coal"** text ramp — heading `#1B1C22`, body `#4B5675`, muted `#78829D`, placeholder `#99A1B7`. A complete **dark theme** is defined under `[data-theme="dark"]` (navy lightens to `#3F5D92`, orange to `#EB9C45` for contrast).
- **Type.** Inter everywhere; **Medium (500) is the default UI weight**, Semibold (600) for headings/labels, Bold (700) for hero numbers. Dense scale — body is **13px**, labels 14px, captions 11–12px; headings step 16 → 20 → 26 → 38 → 50. Medium-and-up weights carry **−0.01em** tracking. JetBrains Mono for code/numerics.
- **Spacing.** 0.25rem base (4-px grid): 4·8·12·16·20·24·32·40·48·64. Cards pad 20px; headers 16–20px.
- **Radii.** Buttons / inputs / badges **6px**; cards **12px**; feature panels 16–20px; pills/avatars full.
- **Shadows.** Deliberately **soft and low-opacity** — the signature card shadow is `0 3px 4px rgba(0,0,0,.03)`. Raised buttons `0 3px 8px /.07`, dropdowns `0 7px 18px /.09`, modals `0 10px 35px /.10`. Depth comes from **1px borders** (`#F1F1F4` subtle, `#DBDFE9` strong) far more than from shadow.
- **Surfaces & layout.** App canvas is near-white `#FCFCFC`; content sits in white cards. Fixed 248px sidebar + sticky 64px topbar; 28px content padding. Generous card grids (2–4 columns).
- **Backgrounds.** Mostly flat white/grey. Marketing/auth panels use **subtle dotted/grid patterns** (`assets/patterns/`) and gentle radial tints — never loud full-bleed gradients. Decorative blue glow blobs appear behind hero art at low opacity.
- **Borders define cards**, not heavy shadow: 1px `--border-default` + 12px radius + `--shadow-sm`.
- **Imagery.** Clean studio product shots and line-art spot **illustrations** (cool, friendly, light palette). Avatars are round; when no photo, **auto-colored initials** (see `Avatar`).
- **Motion.** Quick and functional: 150–200ms ease `cubic-bezier(.4,0,.2,1)`. Hover = background/҂color shift (e.g. light buttons *fill in* on hover; ghost items pick up a grey-100 wash). Focus = 3px primary ring. No bounce, no decorative looping animation. Charts ease-in their lines.
- **Press/hover states.** Solid buttons darken to their `-active` rung; light buttons swap to the solid fill; nav items get `primary-soft` bg + primary text when active.

---

## Iconography
- **KeenIcons** — Metronic's in-house set. This system ships the **outline ("Filled" stroke) variant**: 49 curated SVGs in `assets/icons/`, all authored with `fill="currentColor"` so they take the CSS `color` of any ancestor.
- **Delivery.** Because external SVGs can't inherit `currentColor` reliably via `<img>`/`mask`, icons are **inlined**. Two front-ends to the same data:
  - `assets/icons.js` — drop-in `<script>` for plain HTML. Exposes `window.mtIconSVG(name)` and auto-hydrates any `<i data-icon="home"></i>`.
  - `<Icon name="…" />` — the React component (`components/Icon/`), with the full map embedded so it's self-contained.
- **Coverage:** navigation (element-11, profile-circle, setting-2, rocket, category…), actions (plus-squared, trash, filter, magnifier, share…), content (folder, files, notepad, calendar, chart-line-up…), social/marks (verify, star, heart, like) and chevrons (down/up/left/right, derived from the real KeenIcons chevron path).
- A couple of duotone glyphs (folder, notepad) render as solid silhouettes — that matches Metronic's filled style. **No emoji, no unicode glyphs** are used as icons. When you need an icon not in the set, pull the matching KeenIcon SVG from the Figma `Visuals/Icons` page rather than hand-drawing one.
- **Logo.** The Uyanık mark is an **owl** — navy `#142A3D` head/body, light-blue `#8BB4DE` wings + book, an orange `#FDA331` beak and a yellow `#FFCB43` idea-spark. Two forms: **`logo-mark.svg`** is the clean **frameless owl** (use inline next to the wordmark — sidebar, header, login); **`logo-badge.svg`** / `logo-mark-dark.svg` is the **rounded-square badge** (app-icon / dark backgrounds). Three thematic owls also ship: **book** (primary), **laptop** (`logo-owl-laptop.svg`), **coffee** (`logo-owl-coffee.svg`). All extracted as vector from the brand PDF. Pair the mark with the `Uyanık` wordmark in `--font-wordmark` (navy, Inter heavy).

---

## Index / manifest
**Root**
- `styles.css` — the single entry point consumers link (import list only).
- `tokens/` — `colors.css`, `typography.css`, `spacing.css`, `fonts.css`, `base.css`.
- `readme.md` — this guide. `SKILL.md` — Agent-Skill front-matter wrapper.

**Assets** (`assets/`)
- `logo-mark.svg` (frameless owl), `logo-badge.svg` / `logo-mark-dark.svg` (badge), `logo-owl-laptop.svg`, `logo-owl-coffee.svg` · `icons/` (49 KeenIcons) · `icons.js` (inline icon runtime) · `patterns/` (dotted + grid brand patterns) · `products/` (demo imagery).

**Foundation cards** (`guidelines/`) — specimen cards rendered in the Design System tab: colors (primary, semantic, neutral, text/surfaces), type (scale, weights, mono), spacing (radii, shadows, scale), brand (logo, iconography).

**Components** (`components/`) — React primitives, bundled to `window.MetronicDesignSystem_a73f8f`. Button & Badge carry an extra **`accent`** color (Uyanık orange) for CTAs:
- `Icon/` — `Icon`
- `buttons/` — `Button`, `IconButton`
- `forms/` — `Input`, `Textarea`, `Select`, `Checkbox`, `Radio`, `Switch`
- `data-display/` — `Card` (+`CardHeader/Body/Footer`), `Badge`, `StatusBadge`, `Avatar` (+`AvatarGroup`), `Tabs`, `Progress`, `Tag`, `Separator`, `DataGrid`
- `overlays/` — `Modal`, `Drawer`, `ToastProvider` (+`useToast`)
- `feedback/` — `Alert`

> **Application components** (added for the Uyanık admin/POS/web/mobile build): `StatusBadge` (Turkish status dictionary — sipariş/stok/genel), `DataGrid` (sort + pagination + the four required states: loading/empty/error/full), `Modal`, `Drawer`, `ToastProvider`/`useToast`. A runtime bridge `ui_kits/shared/ds-runtime.jsx` mirrors these so consuming pages work even before the turn-boundary bundle regenerates — load it (as `text/babel`) right after `_ds_bundle.js`; it self-skips once the bundle ships them.

**UI kits** (`ui_kits/`)
- `admin/` — interactive Metronic-style admin: Sign-in → Dashboard → Public Profile, with the sidebar/topbar shell and a **light/dark theme toggle** in the topbar.
- `admin-app/` — **Uyanık Kütüphane yönetim paneli** (Turkish): shared 15-item `AdminShell` (navy sidebar + topbar with branch selector, search, notifications, user menu) and a view router. Screens built: **Ana Sayfa** (dashboard — stat cards, weekly sales chart, top products, live order feed) and **Ürünler** (DataGrid list with filters + 4 states, add/edit **Drawer** form with inline validation, delete-confirm **Modal**, success/error **Toast**). Remaining admin/POS/web/mobile screens are scaffolded in priority order. One filled orange CTA per screen.
- `shared/` — `logo.js` (owl mark as data URI), `ds-runtime.jsx` (component runtime bridge).
- `store/` — interactive **Uyanık Store & Loyalty** storefront (Turkish): shop → product → checkout → order confirmation, plus **My Account** (loyalty tier, orders, points, security). Shows navy structure + orange CTAs in a customer-facing context.

---

## Brand notes (Uyanık)
- **Navy `#1F3864` = structure** (nav, headers, footers, links, the tier card). **Orange `#E08A2B` = action.**
- **Button hierarchy (strict).** Orange `accent` solid is reserved for the **single primary conversion CTA per screen** (e.g. *Sepete ekle*, *Siparişi tamamla*, hero shop, *Giriş yap*, *Bağlan*) — **at most one filled orange button on screen**. Routine form saves (*Kaydet*, *Güncelle*) use **navy solid** (`color="primary"`), never orange. Secondary actions use **navy/dark outline** or **neutral light**; tertiary actions use **ghost** (text only). Cancel/dismiss = ghost.
- The default token theme is light; add `data-theme="dark"` (or class `dark`) on `<html>` to switch. Both kits and the dark specimen card demonstrate it.
- Customer-facing copy in the Store kit is **Turkish**; the admin kit stays English. Keep Title Case for actions, sentence case for body.

---

## Open questions for the user
1. **Museo Sans** — confirmed unavailable; the `Uyanık` wordmark stays in heavy **Inter**. Swap later if a brand font is licensed.
2. Store imagery uses one real photo re-tinted per colorway — **send real Uyanık product photography** to replace the placeholders for production.
3. Want the **admin kit** also fully translated to Turkish, or kept as an internal-tools (English) surface?
