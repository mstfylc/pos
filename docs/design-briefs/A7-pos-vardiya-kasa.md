# Design Brief — A7: Vardiya / Kasa / Z-Raporu

> Faz A · pos-web · Öncelik 3. **🎯 Backend YOK → design-first; Codex append-only ledger ile yapacak.** Konvansiyon: `A2-pos-satis-ekrani.md`. Benchmark: tüm POS'larda standart (Loyverse/Adisyo/Square).

## 1. Amaç
Kasiyerin vardiya/kasa yönetimi: açılış nakdi → gün içi nakit hareketleri → kapanış sayımı + fark → X/Z raporu.

## 2. Layout bölgeleri / akış
1. **Kasa aç**: açılış nakdi gir → vardiya başlar.
2. **Gün içi**: para giriş/çıkış (paid in/out) — sebep + tutar.
3. **X raporu** (ara): o ana kadar satış/ödeme tipi özeti (vardiya kapanmaz).
4. **Kasa kapat**: sayılan nakit gir → **beklenen vs sayılan fark** → onayla.
5. **Z raporu**: kapanışta otomatik özet (toplam satış, ödeme tipi kırılımı, iptal/iade, nakit fark) → yazdır.

## 3. DS bileşen eşlemesi
Card (özet), Input/numpad (tutar), Button (aç/kapat/rapor), DataTable (hareketler), StatusBadge (fark +/−), print akışı (A6).

## 4. Veri kaynakları (🎯 — Codex eklemeli, openapi.yaml → codegen)
| Veri | Önerilen endpoint (henüz YOK) |
|---|---|
| Kasa aç | `POST /api/v1/app/shifts/open` |
| Para giriş/çıkış | `POST /api/v1/app/shifts/{id}/cash-movement` |
| X raporu | `GET /api/v1/app/shifts/{id}/x-report` |
| Kasa kapat | `POST /api/v1/app/shifts/{id}/close` |
| Z raporu | `GET /api/v1/app/shifts/{id}/z-report` |

> Append-only ledger; hard-delete yok. Tasarım onaylanınca Codex kontratı yazar.

## 5. 4 state
- loading · empty: "Açık vardiya yok · Kasa aç" · error: fark onayı/yetki hatası · success: vardiya açık/kapalı + Z çıktısı.

## 6. Özel kurallar
- Açık vardiya yokken satışa izin politikası (karar: Codex'e sorulacak).
- Fark (açık/kapalı) görünür ve nedeni notlanabilir.
- Z raporu değiştirilemez kayıt.

## 7. "Yakında"
- Çoklu kasa/çekmece, banka/POS cihazı mutabakatı (🔜).
