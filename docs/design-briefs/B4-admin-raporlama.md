# Design Brief — B4: Raporlama + Dashboard

> Faz A · admin-web · 🟡 kısmi backend. Konvansiyon: `A2-pos-satis-ekrani.md`. Mevcut DashboardPage (mock) gerçek veriye bağlanır.

## 1. Amaç
Yönetim özeti (KPI/dashboard) ve operasyonel raporlar. Hangi raporun backend'i hazır net ayrılır; eksikler "Yakında".

## 2. Ekran grubu
- **Dashboard**: KPI kartları (günlük satış, sipariş sayısı, ort. sepet), satış trendi grafiği, en çok satanlar, canlı sipariş. (Şu an mock → özet endpoint netleşince bağla.)
- **Giriş ürün raporu**: ✅ `reports/entry-products`.
- **Satış raporu**: `admin/orders` listesinden gün/ürün/personel/ödeme tipi kırılımı (🟡 özet endpoint sınırlı).
- **Kâr/zarar**: 🟡 (envanter dökümante; endpoint doğrulanmalı).
- **Stok raporu**: movements özetinden.

## 3. DS bileşen eşlemesi
Card (KPI), Chart (trend — DS grafik bileşeni/uyumlu kütüphane), DataTable (rapor), Tabs, tarih aralığı seçici, Export butonu.

## 4. Veri kaynakları
`reports/entry-products` ✅ · `admin/orders` (liste) ✅ · dashboard özet & kâr/zarar & sadakat raporu = **🟡/🔜 Codex netleştirmeli**.

## 5. 4 state
loading skeleton kartlar · empty "Seçili aralıkta veri yok" · error retry · success grafik/tablo.

## 6. Özel kurallar
- Tarih aralığı + şube filtresi tüm raporlarda.
- Export (CSV) standart.
- Backend'i olmayan rapor sekmeleri **"Yakında" rozeti + disabled**.

## 7. "Yakında"
- Z/gün sonu raporu (A7 modülüne bağlı) · sadakat raporu · gelişmiş kâr/zarar (🔜).
