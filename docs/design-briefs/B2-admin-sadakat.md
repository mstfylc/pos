# Design Brief — B2: Admin Sadakat Yönetimi

> Faz A · admin-web · backend hazır. Konvansiyon: `A2-pos-satis-ekrani.md`. Mevcut Campaigns sayfası referans alınabilir.

## 1. Amaç
Sadakat programının tüm tanımları: kazanım kuralları, seviyeler, ödüller, kampanyalar, damga kartları, müşteri puan/cüzdan düzeltmeleri.

## 2. Ekran grubu
- **Earn rules** (kazanım): amountPerPoint, min order, scope (All/Branch/Category), tarih, çarpan.
- **Tiers** (seviye): minimumPoints, earnMultiplier, aktif.
- **Rewards** (ödül): requiredPoints, tip (indirim/ücretsiz ürün), bağlı ürün.
- **Campaigns**: tip (ekstra puan/indirim/damga), RuleJson, priority, maxTotalDiscount, hedef tier, tarih.
- **Stamp cards**: damga kuralları.
- **Müşteri düzeltme**: wallet-adjustments, loyalty-adjustments (bakiye/puan ekle-çıkar, sebep).

## 3. DS bileşen eşlemesi
DataTable (liste), Form (Input/Select/Switch/DatePicker), Modal (oluştur/düzenle), Tabs, StatusBadge (aktif/pasif), Toast.

## 4. Veri kaynakları
`admin/earn-rules`, `admin/loyalty-tiers`, `admin/rewards`, `admin/campaigns`, `admin/stamp-cards`, `admin/customers/{id}/wallet-adjustments`, `admin/customers/{id}/loyalty-adjustments` (hepsi CRUD ✅).

## 5. 4 state
loading skeleton · empty "Tanım yok + Ekle" · error retry · success Toast.

## 6. Özel kurallar
- Campaign çakışma: aynı tipte priority en yüksek tek kampanya (kuralı UI açıklasın).
- maxTotalDiscount cap'i form validasyonunda hatırlat.
- Düzeltmeler append-only ledger (geri alınamaz, ters kayıtla düzeltilir).

## 7. "Yakında"
- Kampanya RuleJson görsel kural editörü (🔜 — başta ham JSON/temel form) · sadakat raporu (🔜).
