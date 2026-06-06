# CODEX — Başlangıç Brief'i (İlk Oturum)

> Bu dosya Codex'in ilk oturumda izleyeceği yol haritasıdır. Komutlar/promptlar `docs/CODEX_KOMUTLARI.md` içinde. Önce `AGENTS.md` ve `ARCHITECTURE.md` oku.

## Bağlam
- Bu repo (`mstfylc/pos`) yeni **v2** platformudur, temiz başlar.
- Eski backend (`mansis_pos_ws`, .NET Core 3.1) **ayrı klonlanmış salt-okunur referanstır**. Yolu Codex'e oturumda verilir (ör. `../mansis_pos_ws_legacy`). Oradan iş kurallarını/veri modelini okursun ama oraya YAZMAZSIN.
- Strateji: backend **migrate** (sıfırdan değil). Eski mantığı koru, .NET 10'a taşı.

## İlk oturumun hedefi (sırayla)
1. **Faz 0 — Güvenlik temizliği**: Yeni repoya hiç secret girmediğinden emin ol. `.gitignore`, `.env.example`, `appsettings.example.json` zaten var. Eski koddaki sızmış sırları (DB/JWT/SSH/Dropbox/SMS) ASLA yeni repoya taşıma.
2. **Backend iskeleti**: `backend/` altında Clean Architecture solution oluştur (Api / Application / Domain / Infrastructure / Workers / Contracts).
3. **Domain modelleri**: Eski referanstan çekirdek entity'leri (Company, Branch, Pos, Store, User, Role, Permission, Product, Category, Order, Customer, Discount, vb.) .NET 10 + EF Core 10'a taşı. Audit alanları, ilişkiler korunur.
4. **Teknik iyileştirmeler**: order_payments (çoklu ödeme), append-only ledger (stock/wallet/loyalty), refresh_tokens, tenant global query filter.
5. **OpenAPI kontratı**: `contracts/openapi.yaml` üret; admin + app uçlarını tag'le.
6. **Client üretimi kurulumu**: `packages/api-client-ts` ve `api-client-dart` için codegen script'i.

## Sınır kuralları (AGENTS.md'den özet)
- Secret koda girmez · Tenant scope her sorguda · Finansal işlem tek transaction + idempotency_key · Append-only hard-delete yok · Belirsiz iş kuralını silme, `// TODO: verify rule` bırak.

## Çıktı
Her adım kendi feature branch'inde, küçük commit'ler. Her iş `docs/DEFINITION_OF_DONE.md`'den geçer.
