# Design Brief — B5: Ayarlar → Görünüm / Tema

> Faz A · admin-web (+ tüm app'lerde tema toggle) · backend: 🎯 `company_settings` tema alanları (Codex). Konvansiyon: `A2-pos-satis-ekrani.md`. Detay: `../THEMING.md`.

## 1. Amaç
İşletmenin marka temasını seçmesi (galeri), ve kullanıcıların açık/koyu + palet tercihini değiştirmesi. Arayüz tek renge kilitli değil.

## 2. Ekran / bileşenler
### a) İşletme teması (tenant admin — Ayarlar → Görünüm)
- **Palet galerisi**: kartlar (Lacivert/Turuncu varsayılan, Yeşil/Amber, Mor/Teal, Antrasit/Mavi, Bordo/Altın) — her kart canlı önizleme (primary/accent örneği).
- **Logo yükle** + önizleme.
- (İleride) **özel renk**: color picker → primary/accent.
- "Kaydet" → tüm personele yansır.

### b) Kullanıcı tercihi (her kullanıcı, üst bar/menü)
- **Açık / Koyu / Sistem** toggle.
- (Ops.) yerel palet override.

## 3. DS bileşen eşlemesi
Card (palet kartı, seçili StatusBadge), Switch/SegmentedControl (light/dark/system), color picker (ileride), Button, Toast, canlı önizleme alanı.

## 4. Veri kaynakları
| Veri | Endpoint (🎯 Codex) |
|---|---|
| Tenant tema oku/yaz | `GET/PUT /api/v1/admin/settings/theme` (`theme_palette_id`, `brand_primary?`, `brand_accent?`, `logo_url`, `theme_mode_default`) |
| Kullanıcı tercihi | client (localStorage / cihaz) |

## 5. 4 state
loading: ayar yükleniyor · empty: — · error: "Kaydedilemedi" · success: "Tema güncellendi", anında uygula (runtime).

## 6. Özel kurallar
- Renkler semantic token; değişim runtime (rebuild yok).
- Önizleme gerçek bileşenlerle (buton/kart/badge) gösterilir.
- Öncelik: tenant marka = varsayılan; kullanıcı kendi cihazında ezebilir (THEMING §4).

## 7. "Yakında"
- Özel hex renk seçici (🔜 — başta galeri) · mobil son-müşteri ayrı teması (🔜) · tam white-label (🔜).
