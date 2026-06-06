# CLAUDE.md — Claude Code Talimatları

> Bu projede çalışırken ÖNCE `ARCHITECTURE.md` (repo kökü) ve `docs/DESIGN_SYSTEM.md` + `docs/WORKFLOW.md` dosyalarını oku. Onlar bağlayıcıdır; bu dosya yalnızca Claude Code'a özel ek kuralları içerir.

## Rolün
Yeni frontend (admin-web, pos-web, customer-web), mobil (Flutter) ve Go köprü üretimi. Claude Design'da onaylanan tasarımları koda dökmek.

## Çalıştığın klasörler
`admin-web/`, `pos-web/`, `customer-web/`, `mobile/`, `print-bridge/`. `backend/` ve `contracts/` Codex'in sahasıdır; oraya dokunman gerekirse önce belirt.

## Mutlak kurallar
1. **API tipi/fetch YAZMA.** `packages/api-client-ts` (web) veya `packages/api-client-dart` (mobil) import et. Endpoint eksikse kod yazma; "openapi.yaml'a şu endpoint eklenmeli" diye bildir.
2. **Token hardcode ETME.** Renk/spacing/tipografi `packages/design-tokens`'tan gelir. Tailwind config token'lara map'lidir; sınıfları oradan kullan.
3. **Secret YAZMA.** `.env` + `*.example`. Connection string, token, key asla koda girmez.
4. **Her veri ekranında 4 state**: loading, empty, error, success. Atlama.
5. **Bileşen sözleşmesine uy** (DESIGN_SYSTEM.md §2). Yeni buton/input icat etme; mevcut bileşenleri kullan/genişlet.
6. **TypeScript strict.** `any` kullanma; üretilen tipleri kullan.

## POS web'e özel
- Dokunmatik hedefler ≥ 48px, satış kartları ≥ 80×80px.
- Offline: Service Worker + IndexedDB outbox. Sipariş offline'da kuyruğa, online'da idempotency_key ile gönderilir.
- Fiş: `http://localhost:9100/print`'e POST. Köprü erişilemezse uyarı + retry; satışı bloklamaz.

## Mobil (Flutter) özel
- State: Riverpod. Network: Dio + üretilen Dart client. Yerel: Hive/SQLite.
- Token'lar `ThemeData`'ya map; hardcoded Color yok.
- QR: süreli token (customer_card_tokens), statik kart no ödeme yetkisi vermez.

## Çalışma tarzı
- Tek seferde tek ekran/modül üret; "tüm paneli kur" deme.
- Üretmeden önce ilgili tasarım onaylı mı kontrol et; değilse Claude Design adımını hatırlat.
- İş bitince `docs/DEFINITION_OF_DONE.md` listesini kendi çıktına uygula.
- Mevcut bir dosyayı değiştireceksen önce oku; körlemesine üzerine yazma.
