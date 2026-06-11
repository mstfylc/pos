# Design Brief'leri — Index & Backlog

> Her ekran Claude Design'da tasarlanır, onaylanınca Claude Code DS token/bileşenleriyle kodlar (WORKFLOW.md §4).
> Ortak konvansiyon ve detay şablonu: **`A2-pos-satis-ekrani.md`** (referans brief). Diğer brief'ler bunu tekrar etmez, atıf yapar.
> Faz kararı: `../POS_FEATURE_MAP.md`. DS: `../DESIGN_SYSTEM_CONSOLIDATION.md`.

## Sıra & durum

| # | Ekran | Faz | App | Backend | Brief | Design |
|---|---|---|---|---|---|---|
| A1 | POS giriş / cihaz seçimi | A | pos-web | ✅ | A1-pos-giris.md | ⬜ |
| A2 | POS satış ana ekranı | A | pos-web | ✅ | A2-pos-satis-ekrani.md | ⬜ |
| A3 | Checkout / ödeme modalı | A | pos-web | ✅ | A3-pos-checkout.md | ⬜ |
| A4 | Müşteri tanıma (telefon/QR) | A | pos-web | ✅ | A4-pos-musteri-tanima.md | ⬜ |
| A5 | Sadakat paneli + ödül kullan | A | pos-web | ✅ | A5-pos-sadakat-odul.md | ⬜ |
| A6 | Offline kuyruk + fiş köprüsü | A | pos-web | 🟡 | A6-pos-offline-fis.md | ⬜ |
| A7 | Vardiya / kasa / Z-raporu | A | pos-web | 🎯 | A7-pos-vardiya-kasa.md | ⬜ |
| B1 | Admin stok modülü | A | admin-web | ✅ | B1-admin-stok.md | ⬜ |
| B2 | Admin sadakat yönetimi | A | admin-web | ✅ | B2-admin-sadakat.md | ⬜ |
| B3 | Admin satınalma + yapı + yetki | A | admin-web | ✅ | B3-admin-satinalma-yapi-yetki.md | ⬜ |
| B4 | Raporlama + dashboard | A | admin-web | 🟡 | B4-admin-raporlama.md | ⬜ |
| C1 | Restoran modu (masa/KDS/QR/kurye) | B | pos-web | 🔜 | C1-restoran-modu.md | ⬜ |
| D1 | Müşteri mobil sadakat app | 3 | mobile | 🔜 | D1-musteri-mobil.md | ⬜ |

Rozet: ✅ hazır · 🟡 kısmi · 🎯 yakın vade (Codex yapacak) · 🔜 yakında (Faz B/3).

## Her brief'in sabit bölümleri
1. Amaç & bağlam · 2. Layout bölgeleri · 3. DS bileşen eşlemesi · 4. Veri kaynakları (endpoint) · 5. 4 state · 6. Etkileşim/özel kurallar · 7. "Yakında" öğeleri.

## Design'a verilecek sabit bağlam (her oturum başı)
> "Önce ARCHITECTURE.md ve docs/DESIGN_SYSTEM.md'yi oku. Metronic görsel temel; token'lar (lacivert #1F3864 / accent #E08A2B) hardcode edilmez. Yeni buton/input icat etme; bileşen sözleşmesini kullan. Her veri ekranı 4 state taşır. Backend'i olmayan özellikler 'Yakında' rozeti + disabled. POS'ta dokunmatik ≥48px, ürün kartı ≥80×80px."
