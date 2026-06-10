# POS Özellik Haritası — Tasarım Brief'i (Tam Kapsam)

> Amaç: Eksiksiz bir modern POS sisteminin **tüm** özelliklerini Claude Design'da tasarlamak.
> Backend'i hazır olanlar gerçek ekran olarak; bizde **olmayanlar tasarımda "Yakında" (disabled/placeholder) rozetiyle** kalır.
> Bağlayıcı referanslar: `ARCHITECTURE.md`, `docs/DESIGN_SYSTEM.md`, `docs/WORKFLOW.md`.
> Her ekran 4 state taşır: **loading · empty · error · success**. Token/bileşen sözleşmesi DESIGN_SYSTEM.md §2.

## Durum Lejantı

| Rozet | Anlam | Tasarımda nasıl gösterilir |
|---|---|---|
| ✅ Hazır | Backend + üretilmiş client var | Tam fonksiyonel ekran tasarla |
| 🟡 Kısmi | Kısmen var, bazı alan/akış eksik | Tasarla; eksik alanı "Yakında" işaretle, Codex'e DTO notu bırak |
| 🎯 Yakın vade | Backend yok ama **karar: yapılacak** (Codex modülü planlı) | Tam fonksiyonel ekran tasarla; "Yakında" rozeti **koyma** |
| 🔜 Yakında | Bizde backend yok, sonraki faz | Ekranı tasarla ama **"Yakında" rozeti + disabled** |

## Sürüm Hedefi (KARAR — 2026-06-10)

Kademeli strateji: **önce Retail + QSR canlıya, sonra restoran modülü.**

| Faz | Kimlik | Kapsam | Tasarım yaklaşımı |
|---|---|---|---|
| **Faz A (canlı hedef)** | Retail + Hızlı Servis (Square/Loyverse profili) | Satış çekirdeği + sadakat + stok + admin + **vardiya/kasa/Z-raporu** + offline + fiş | ✅ ve 🎯 olanlar gerçek ekran |
| **Faz B (sonra)** | Tam restoran/adisyon (Simpra/Adisyo profili) | Masa planı + KDS + QR menü + garson çağrı + online sipariş/kurye + combo/modifier + hesap böl | 🔜 → tasarımda "Yakında" |

> **Vardiya / kasa aç-kapa / Z-raporu** kararla 🔜'dan **🎯 Faz A**'ya alındı (benchmark: tüm POS'larda standart). Tasarım gerçek ekran olur; Codex backend modülünü çıkarır.

---

## 1. Satış / Checkout (POS çekirdeği) — pos-web

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Kategori + ürün grid (renk/şekil, favori) | ✅ | `app/pos/{posId}/products`, `app/categories` · kart ≥80×80px |
| Ürün arama + barkod okutma | ✅ | products list filtreleri · barkod alanı var |
| Kalıcı sepet (adet artır/azalt, sil, satır notu) | ✅ | client-side · sepet hep görünür |
| Çoklu / bölünmüş ödeme (nakit, kart, yemek kartı, mixed) | ✅ | `app/orders` payments[] · toplam≠sipariş ise "Kapat" pasif |
| Hızlı nakit / para üstü hesaplama | ✅ | client-side hesap |
| Tartılı/adetli ürün (gram, mililitre, adet) | ✅ | ProductUnitType var |
| Manuel indirim (yetki + limit) | ✅ | `app/orders` discounts[] · `app/discounts` |
| Kupon kodu girişi | 🔜 | Order create'te kupon alanı yok |
| Alt ürün / combo / modifier (reçete, seçenek) | 🔜 | Entity (`OrderSubProduct`) var ama create DTO yok → Codex DTO eklemeli |
| Siparişi beklet / park et (hold & recall) | 🔜 | Hold/park modeli yok |
| Müşteri sepete ekle (tanıma) | ✅ | `customers/identify` |
| Fiş yazdır (termal köprü) | 🟡 | `print-bridge` Go servisi **boş** → localhost:9100 tasarımı hazırla |
| Fiş e-posta / SMS gönder | 🔜 | Endpoint yok |
| e-Fatura / e-Arşiv (mali fiş) | 🔜 | Mali entegrasyon yok |
| Sipariş iptal / iade (satır bazlı) | ✅ | `orders/{id}/cancel`, `orders/{id}/refund` · Reason zorunlu |
| Hesabı böl / masa böl (split bill) | 🔜 | Masa modeli yok |

## 2. Müşteri & Sadakat — pos-web + admin-web + mobile

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Müşteri arama (telefon/isim/mail) | ✅ | `app/customers` |
| QR / kart ile tanıma (süreli token) | ✅ | `customers/{id}/card-token`, `customers/identify` |
| Sadakat önizleme (sepette kazanılacak puan/kampanya/ödül) | ✅ | `app/loyalty/preview` |
| Puan kazanma (earn rule) | ✅ | sipariş içinde otomatik |
| Ödül kullanma (redeem) | ✅ | `loyalty/rewards/{id}/redeem` |
| Tier / seviye | ✅ | `admin/loyalty-tiers` |
| Kampanya (extra puan / indirim / damga) | ✅ | `admin/campaigns` |
| Damga kartı (stamp card) | ✅ | `admin/stamp-cards` |
| Cüzdan bakiye yükleme/kullanım | ✅ | `customers/{id}/wallet-adjustments` |
| Hediye kart (gift card, cüzdandan ayrı) | 🟡 | Cüzdan + stamp var; ayrı gift-card akışı yok |
| Müşteri profil / adres / geçmiş | 🟡 | Customer CRUD var; adres/foto DTO sınırlı |

## 3. Stok / Envanter — admin-web

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Stok hareket listesi (append-only ledger) | ✅ | `stock/movements` |
| Stok giriş / çıkış | ✅ | `stock/stock-in`, `stock/stock-out` |
| Sayım (count) | ✅ | `stock/count` |
| İmha / fire | ✅ | `stock/destroy` |
| Şubeler arası transfer (talep/onay/teslim) | ✅ | `stock/transfers` + confirm/receive/cancel |
| Düşük stok / kritik eşik uyarısı | ✅ | StoreProduct.Threshold var |
| Reçete bazlı otomatik stok düşümü | 🟡 | Stocktaking düşümü var; reçete (alt ürün) düşümü combo'ya bağlı (🔜) |

## 4. Satınalma / Tedarikçi — admin-web

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Tedarikçi yönetimi | ✅ | `admin/suppliers` |
| Satınalma siparişi / fatura | ✅ | `admin/purchases` |
| Mal kabul → stok girişi | ✅ | purchase received → stock receipt (son commit) |
| Tedarikçi cari / ödeme takibi | 🟡 | OpeningBalance/Maturity alanları var; cari ekstre endpoint'i yok |

## 5. Vardiya / Kasa / Gün Sonu — pos-web (🎯 Faz A — Codex backend yapacak)

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Kasa açılış (açılış nakdi) | 🎯 | Modül yok → Codex yapacak; tasarım gerçek ekran |
| Vardiya başlat/bitir | 🎯 | Benchmark: Loyverse/Adisyo standart |
| Para giriş/çıkış (paid in/out) | 🎯 | Kasa nakit hareketleri (satış dışı) |
| Kasa kapanış / nakit sayım / fark | 🎯 | Sayılan vs beklenen fark |
| X / Z raporu (gün sonu) | 🎯 | Kapanışta otomatik Z; X ara rapor |

> Faz A kapsamında. Design-first: tasarım önce çıkar, onaylanınca Codex append-only ledger mantığıyla backend modülü ekler.

## 6. Masa / Servis / Mutfak (restoran modu) — pos-web (🔜 Faz B)

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Masa planı / kat şeması | 🔜 | Masa modeli yok |
| Masaya sipariş / masa birleştir-böl | 🔜 | Yok |
| Mutfak ekranı (KDS) | 🔜 | Yok |
| Garson çağırma / sipariş durumu | 🔜 | Yok |
| Kurye / teslimat takibi | 🔜 | ShippingType değerleri var ama modül yok |

> Tüm blok "Yakında". POS restoran moduna gidecekse büyük backend modülü.

## 7. Yönetim / Admin — admin-web

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Ürün CRUD + POS'a özel fiyat | ✅ | `admin/products`, `admin/pos-products` |
| Kategori + renk/şekil | ✅ | `admin/categories`, category-colors/shapes |
| Kullanıcı / rol / yetki | ✅ | `admin/users`, `roles`, `permissions`, `roles/{id}/permissions` |
| Şube / mağaza / POS yapısı | ✅ | `admin/branches`, `stores`, `pos` |
| Personel atama (şube/POS/mağaza) | ✅ | `admin/assignments` |
| İndirim tanımı + kapsam (şube/POS/personel) | ✅ | `admin/discounts` |
| Vergi / KDV yönetimi | 🟡 | TaxType ürün alanında; ayrı vergi ayar ekranı yok |
| Genel ayarlar (tenant tema, para, dil) | 🔜 | Settings modülü/endpoint yok |
| Denetim kaydı (audit log) görüntüleme | 🟡 | Log entity var, okuma endpoint'i yok |

## 8. Raporlama & Dashboard — admin-web

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Dashboard / KPI (satış trendi, en çok satan) | 🟡 | Şu an mock; özet endpoint netleştirilmeli |
| Giriş ürün raporu | ✅ | `reports/entry-products` |
| Kâr / zarar raporu | 🟡 | Envanter dökümante edildi; endpoint doğrulanmalı |
| Satış raporu (gün/ürün/personel/ödeme tipi) | 🟡 | `admin/orders` listesi var; özet rapor endpoint'i sınırlı |
| Z / gün sonu raporu | 🔜 | Vardiya modülüne bağlı (bkz. §5) |
| Stok raporu | 🟡 | movements var; özet rapor ekranı tasarlanmalı |
| Sadakat raporu | 🔜 | Özet rapor endpoint'i yok |

## 9. Sistem / Operasyon (çapraz kesen)

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| Offline mod + IndexedDB outbox + sync | ✅ | `offlineOrder` + `idempotencyKey` · üst barda yeşil/sarı gösterge |
| Yazıcı köprüsü (termal, localhost:9100) | 🟡 | Go servisi boş; protokol tasarlanacak |
| Çoklu dil / çoklu para | 🔜 | i18n/currency altyapısı yok |
| Çoklu tenant tema (runtime renk override) | ✅ | brand.primary/accent token override (DESIGN_SYSTEM §1) |
| Kimlik doğrulama (login / PIN / OTP) | ✅ | `auth/login`, `refresh`, `otp/*` |
| Cihaz / POS oturum yönetimi | ✅ | `app/pos` |

## 10. Müşteri Kanalı — customer-web (Next.js, BOŞ)

| Özellik | Durum | Endpoint / Not |
|---|---|---|
| QR menü / online sipariş | 🔜 | customer-web boş (Faz 5) |
| Müşteri puan/cüzdan self-servis | 🔜 | mobile/customer-web'e bağlı |
| Mobil sadakat app (Flutter) | 🔜 | mobile boş; Dart client hazır (Faz 3) |

---

## Tasarım Sırası Önerisi (Design oturumları)

1. **POS satış çekirdeği** — §1 A1–A3 (grid+sepet+ödeme). Projenin kalbi.
2. **POS müşteri+sadakat** — §2 (tanıma/QR, loyalty preview, redeem).
3. **POS offline+fiş** — §9 (sync göstergesi, yazıcı köprüsü akışı).
4. **POS vardiya/kasa/Z** — §5 (komple "Yakında" ama design-first).
5. **Admin stok + sadakat admin** — §3, §2 admin (düşük risk, backend hazır).
6. **Admin satınalma + yapı + yetki** — §4, §7.
7. **Raporlama + dashboard** — §8.
8. **Restoran modu / masa / KDS** — §6 (hepsi "Yakında").
9. **Müşteri kanalı / mobil** — §10 (Faz 3/5).

## Benchmark — Referans POS'lar (2026-06)

Karar, Türkiye (restoran/adisyon ağırlıklı) ve yurtdışı (retail+QSR) POS'larının özellik setleri incelenerek verildi.

| Özellik | Simpra | Adisyo | Toast | Square | Loyverse | Biz |
|---|:--:|:--:|:--:|:--:|:--:|:--:|
| Masa yön. / kat planı | ✓ | ✓ | ✓ | ✓ | ✓ | 🔜 B |
| KDS mutfak | ✓ | ✓ | ✓ | ✓ | ✓ | 🔜 B |
| QR menü / garson çağrı | ✓ | ✓ | ✓ | ~ | ~ | 🔜 B |
| Online sipariş / kurye | ✓ | ✓ | ✓ | ✓ | ~ | 🔜 B |
| Vardiya + kasa + Z raporu | ✓ | ✓ | ✓ | ✓ | ✓ | 🎯 A |
| Combo / modifier / reçete | ✓ | ✓ | ✓ | ✓ | ✓ | 🔜 B |
| Hesap böl (split check) | ✓ | ✓ | ✓ | ✓ | ✓ | 🔜 B |
| Stok / sayım / barkod | ✓ | ✓ | ✓ | ✓ | ✓ | ✅ |
| Sadakat / kampanya | ✓ | ✓ | ✓ | ✓ | ✓ | ✅ |
| Çok şube merkezi yön. | ✓ | ✓ | ✓ | ✓ | ✓ | ✅ |
| Bulut + offline | ✓ | ✓ | ✓ | ✓ | ✓ | ✅ |
| Cari hesap (veresiye) | ~ | ✓ | ~ | ~ | ~ | 🟡 |

**Çıkarım:** Mevcut backend retail + sadakat (Square/Loyverse) profiline ~%80 hazır. Faz A için tek gerçek eksik vardiya/Z. Türkiye'nin restoran çekirdeği (masa/KDS/QR/kurye) Faz B'de büyük modül.

Kaynaklar: [SimpraPOS](https://simprasuite.com/restaurant-software/pos-system/), [Adisyo](https://adisyo.com/restoran-otomasyon-sistemi), [Toast POS](https://pos.toasttab.com/restaurant-pos), [Square POS](https://squareup.com/us/en/point-of-sale), [Loyverse Shift Management](https://help.loyverse.com/help/shift-management-loyverse-pos), [Lightspeed X/Z Reports](https://shopkeep-support.lightspeedhq.com/support/reporting/z-and-x-reports)

## Her Design Brief'ine Eklenecek Sabit Bağlam
> "Önce ARCHITECTURE.md ve docs/DESIGN_SYSTEM.md'yi oku. Token'lar (lacivert #1F3864 / accent #E08A2B) hardcode edilmez. Yeni buton/input icat etme; bileşen sözleşmesini kullan. Her veri ekranı 4 state taşır. Backend'i olmayan özellikler 'Yakında' rozeti + disabled ile gösterilir."
