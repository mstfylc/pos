# Design Brief — D1: Müşteri Mobil Sadakat App (Flutter)

> **Faz 3 · mobile · 🔜 müşteri backend yüzeyi eksik (önce Codex).** Konvansiyon: `A2-pos-satis-ekrani.md`. Karar: ARCHITECTURE K7. Dart client hazır; uygulama yok.

## 1. Amaç
Müşterinin kendi sadakatini yönettiği mobil app: OTP giriş, sadakat kartı (QR), puan/tier, ödüller, kampanya/damga, geçmiş, profil/cüzdan.

## 2. Ekranlar
- **OTP giriş**: telefon → kod → giriş. (⚠️ backend OTP şu an stub; gerçek SMS+müşteri JWT gerekir.)
- **Ana / sadakat kartı**: puan, tier, **süreli QR** (kasada okutulur).
- **Ödüller**: kullanılabilir ödül kataloğu + kullan.
- **Kampanya / damga**: aktif kampanyalar, damga ilerleme.
- **Geçmiş**: sipariş/puan/cüzdan hareketleri.
- **Profil / cüzdan**: bakiye, kişisel bilgi.

## 3. Platform
Flutter (Material 3), Riverpod, Dio + üretilen Dart client, Hive/SQLite. Token'lar `ThemeData`'ya map (DESIGN_SYSTEM_CONSOLIDATION Adım 5).

## 4. Veri kaynakları — **çoğu EKSİK (🔜 Codex yapacak)**
| İhtiyaç | Durum |
|---|---|
| Gerçek OTP + müşteri JWT | ⚠️ stub → yapılacak |
| Müşteri "kendi" puan/tier/geçmiş | 🔜 endpoint yok (`me/loyalty`) |
| Müşteri cüzdan bakiye/hareket | 🔜 (`me/wallet`) |
| Müşteri sipariş geçmişi | 🔜 (`me/orders`) |
| Müşteri kendi QR token üret | 🟡 (card-token POS-yönlü) |
| Ödül listesi/kullan | 🟡 redeem var, katalog müşteri-yönlü değil |
| Push (FCM/APNs) | 🔜 yok |

## 5. Sıra (kritik)
1. **Codex** → müşteri auth + self-servis endpoint grubu (`contracts/openapi.yaml` → codegen Dart).
2. **Claude Design** → bu ekranlar.
3. **Claude Code** → Flutter app.

> Adım 1 olmadan app anlamlı veri gösteremez. Faz A (POS) ile paralel yürütülebilir (farklı saha).

## 6. 4 state
Her ekran: loading (shimmer) · empty · error · success. QR süresi dolunca yenile.

## 7. "Yakında"
Online sipariş/ödeme app içinden (🔜) · arkadaşa öner/referral (🔜).
