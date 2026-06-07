# CODEX - Faz 4 Paketi (Sadakat Motoru + Deploy + CI)

> AGENTS.md + ARCHITECTURE.md kurallarina uy. Adim 16-20'yi kesintisiz yurut. Backend cekirdegi Faz 1-3 calisiyor; bu paket sadakat is mantigini ekler ve Hetzner deploy'a hazirlar. Her adim: dotnet build/test yesil -> commit -> STEP_LOG. Belirsizlik -> TODO + DUR. Raporlar CODEX_RAPOR_FORMATLARI formatinda.

## Calisma kurallari
- DB: PostgreSQL/Npgsql. Tum puan/bakiye islemleri append-only ledger; silme yok, reversal var.
- Tenant scope her sorguda. Finansal islem tek transaction.
- Tablolar Faz 1-3'te kuruldu: loyalty_accounts, loyalty_point_transactions, loyalty_tiers, earn_rules, rewards, reward_redemptions, campaigns, device_tokens, customer_card_tokens.

## ADIM 16 - Puan kazanma (EarnRule motoru)
- Order tamamlandiginda earn_rules degerlendir: points_per_currency/amount_per_point, min_order, gecerlilik tarihi, kapsam (tum/sube/kategori).
- tier multiplier uygula.
- loyalty_point_transactions'a +puan satiri yaz: type=earn, source_order_id, expires_at = earn_rule.expiry_days.
- loyalty_accounts.point_balance + lifetime_points guncelle.
- Order cancel/refund puan reversal'i yazar.

## ADIM 17 - Tier motoru
- lifetime_points esiklerine gore tier yukseltme.
- Tier degisiminde ledger/audit notu.
- Downgrade kurali belirsizse TODO + DUR.

## ADIM 18 - Odul kullanma (Reward redemption)
- rewards: point_cost, reward_type.
- Redemption: yeterli puan kontrolu -> loyalty_point_transactions'a -puan -> reward_redemptions kaydi -> tek transaction.
- Sipariste odul kullanimi order_id ile iliskilenir; iptalde puan iadesi reversal.
- Yetersiz puan 400.

## ADIM 19 - Kampanya degerlendirme
- campaigns: campaign_type, rule jsonb/text, start/end, target_tier.
- Siparis aninda uygun kampanyalari degerlendir: ekstra puan / indirim / damga.
- Cakisan kampanya onceligi TODO + DUR.

## ADIM 20 - Hetzner deploy hazirligi + CI
- Dockerfile API multi-stage build.
- docker-compose.prod.yml: API + PostgreSQL 16, volume, restart policy; secret env'den.
- Migration deploy stratejisi.
- CI workflow: build + test + ephemeral PostgreSQL ile faz3-smoke + loyalty smoke.
- README Hetzner deploy adimlari.

## Sadakat smoke
order create -> puan kazanimi -> reward redeem -> order cancel -> puan reversal -> kampanya ekstra puan/indirim kontrolu.
