# AGENTS.md — Codex Talimatları

> ÖNCE repo kökündeki `ARCHITECTURE.md` ve `docs/WORKFLOW.md` + `docs/DEFINITION_OF_DONE.md` dosyalarını oku. Onlar bağlayıcıdır; bu dosya Codex'e özel ek kuralları içerir.

## Rolün
Backend (.NET 10) migrate ve yeni modüller; OpenAPI kontratının sahibi; API client üretimi; CI/CD ve migration'lar.

## Çalıştığın klasörler
`backend/`, `contracts/`, ve client üretim komutları (`packages/api-client-*` ÜRETİR ama elle düzenlemez). Frontend/mobil klasörleri Claude Code'un sahasıdır.

## Mutlak kurallar
1. **Backend MİGRATE edilir, sıfırdan yazılmaz.** Mevcut iş kuralı/hesaplama belirsizse SİLME/DEĞİŞTİRME; `// TODO: verify rule (eski davranış: ...)` notu bırak ve sor.
2. **OpenAPI kontratının tek sahibi sensin.** Yeni/değişen endpoint → önce `contracts/openapi.yaml` güncelle → sonra codegen ile `api-client-ts` ve `api-client-dart` yeniden üret. Client'ları elle yazma.
3. **Secret YAZMA.** appsettings'e connection string/secret girmez. Environment variable / user-secrets / secret manager. `appsettings.example.json` placeholder ile.
4. **Tenant scope zorunlu.** Her sorgu EF global query filter ile `company_id`'ye bağlı. Bypass eden kod yazma.
5. **Finansal işlemler atomik.** order + order_payments + stock_movements + wallet_transactions + loyalty_point_transactions TEK transaction. Offline sipariş için `idempotency_key` zorunlu.
6. **Append-only.** stock_movements, wallet_transactions, loyalty_point_transactions, audit_logs, order_status_history hard-delete edilmez.
7. **Auth sırası**: UseAuthentication → UseAuthorization (eski kodda ters; düzelt).

## Mimari katmanlar (uy)
`Api → Application (UseCases/MediatR, Validators) → Domain (saf) → Infrastructure (EF, dış servis)`. Controller'a iş mantığı koyma; use-case'e koy. Validation FluentValidation.

## Migration disiplini
- EF Core migration'ları küçük ve adlandırılmış. Yıkıcı (drop/rename) migration'da veri taşıma adımını da yaz.
- Eski MySQL → yeni şema veri taşıma script'leri `backend/migration-scripts/` altında, idempotent.

## Çalışma tarzı
- Tek seferde tek modül/endpoint grubu. Büyük "tüm backend" görevi alma.
- Her PR `docs/DEFINITION_OF_DONE.md`'den geçer (test + tenant + transaction + secret kontrolü).
