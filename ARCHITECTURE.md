# Mansis / Uyanık POS v2 — Mimari Sözleşme (Single Source of Truth)

> Bu dosya tüm AI araçlarının (Claude Design, Claude Code, Codex) ve geliştiricinin uyması gereken **tek bağlayıcı referanstır**. Bir çelişki olursa bu dosya kazanır. Araçlara özel kural dosyaları (`CLAUDE.md`, `AGENTS.md`, `.cursorrules`) bu dosyaya atıf yapar, onu tekrar etmez.

**Versiyon:** 1.0 · **Tarih:** Haziran 2026 · **Sahip:** Mustafa

---

## 0. Kesinleşmiş Kararlar (DEĞİŞMEZ)

Bu kararlar alınmıştır; araçlar bunları sorgulamadan uygular.

| # | Karar | Gerekçe |
|---|-------|---------|
| K1 | **Backend = .NET 10 LTS**, MİGRATE edilir (sıfırdan değil) | İş kuralları ve 103 migration kodda gömülü değer taşır; sıfırdan yazım finansal risktir |
| K2 | **Backend mimari = Modüler Monolit + Clean Architecture** | Sipariş/stok/cüzdan/puan sıkı bağlı; microservice erken karmaşıklık |
| K3 | **DB = PostgreSQL 16+** (MySQL 8.4 düşük-risk alternatif) | Transaction, JSONB, materialized view, raporlama gücü |
| K4 | **Admin Panel = React + TypeScript** (web) | Flutter Web tablo/form ağırlıklı panelde zayıf; React olgun |
| K5 | **POS = Web/PWA** (React + TS), offline PWA | Kurulum/güncelleme derdi biter; her cihazda çalışır |
| K6 | **POS donanım köprüsü = Go servis** (localhost:9100) | Tek dosya, bağımsız binary, çapraz platform (Win/Mac/Linux) |
| K7 | **Mobil Sadakat App = Flutter** (iOS + Android) | Tek kod tabanı, native plugin (push/QR/biometric) |
| K8 | **Müşteri Web = Next.js** | SSR/SEO, multi-tenant tema |
| K9 | **Realtime = SignalR**, **Jobs = Hangfire/Quartz**, **Log = Serilog+OpenTelemetry** | .NET native |
| K10 | **Tüm API client'ları OpenAPI'den OTOMATİK üretilir** — elle yazılmaz | Üç araç da aynı kontratı görür; tutarlılık |
| K11 | **Güvenlik Faz 0 önce** — hiçbir secret koda yazılmaz | Mevcut sızıntılar; env/secret manager zorunlu |
| K12 | **Finansal/stok/puan = append-only ledger**, hard-delete YOK | Para tutarlılığı |

---

## 1. Tek Kelimeyle İş Bölümü

- **Backend (.NET 10)**: MİGRATE — hassas, elle kontrollü → birincil araç **Codex/Cursor**, gözden geçirme zorunlu.
- **Yeni Frontend (Admin, POS, Müşteri Web)**: REWRITE — üretken → **Claude Code** (kod) + **Claude Design** (görsel/UI iterasyonu).
- **Mobil + Go köprü**: REWRITE/yeni → **Claude Code** veya **Codex**.

---

## 2. Repo / Klasör Yapısı (monorepo önerisi)

```
mansis-pos-v2/
├── ARCHITECTURE.md            ← BU DOSYA (single source of truth)
├── CLAUDE.md                  ← Claude Code kuralları (→ ARCHITECTURE.md'ye atıf)
├── AGENTS.md                  ← Codex kuralları (→ ARCHITECTURE.md'ye atıf)
├── .cursorrules               ← Cursor kuralları (→ ARCHITECTURE.md'ye atıf)
├── docs/
│   ├── DESIGN_SYSTEM.md        ← tasarım token'ları, bileşen sözleşmesi
│   ├── API_CONTRACT.md         ← OpenAPI üretim & client kuralları
│   ├── WORKFLOW.md             ← üç aracın nasıl birlikte çalışacağı
│   └── DEFINITION_OF_DONE.md   ← her PR'ın geçmesi gereken kontrol listesi
├── contracts/
│   └── openapi.yaml            ← TEK API kontratı (elle güncellenir, client üretilir)
├── backend/                   ← .NET 10 (Codex/Cursor sahası)
│   ├── src/Mansis.Pos.Api
│   ├── src/Mansis.Pos.Application
│   ├── src/Mansis.Pos.Domain
│   ├── src/Mansis.Pos.Infrastructure
│   ├── src/Mansis.Pos.Workers
│   └── src/Mansis.Pos.Contracts
├── admin-web/                 ← React + TS (Claude Code/Design sahası)
├── pos-web/                   ← React + TS PWA (Claude Code/Design sahası)
├── customer-web/              ← Next.js
├── mobile/                    ← Flutter (Claude Code/Codex)
├── print-bridge/             ← Go servis
└── packages/
    ├── design-tokens/         ← paylaşılan tasarım token'ları (JSON)
    ├── api-client-ts/         ← OpenAPI'den ÜRETİLEN TS client (elle düzenleme YOK)
    └── api-client-dart/       ← OpenAPI'den ÜRETİLEN Dart client (elle düzenleme YOK)
```

---

## 3. Sınır Kuralları (araçlar bunları İHLAL ETMEZ)

1. **API client elle yazılmaz.** `packages/api-client-*` klasörleri üretilmiştir; içine elle kod yazmak yasaktır. Endpoint eksikse önce `contracts/openapi.yaml` güncellenir, sonra client yeniden üretilir.
2. **Secret koda girmez.** Hiçbir araç connection string, token, parola, API key yazmaz. `.env` / secret manager + `*.example` dosyaları kullanılır.
3. **Tasarım token'ları kopyalanmaz.** Renk/spacing/tipografi hardcoded yazılmaz; `packages/design-tokens`'tan import edilir (bkz. DESIGN_SYSTEM.md).
4. **Tenant filtresi atlanmaz.** Backend'de her sorgu/komut `company_id` scope'undan geçer (EF global query filter). Araç bunu bypass eden kod yazamaz.
5. **Finansal işlemler transaction içinde.** order + payment + stock + wallet + loyalty tek transaction; idempotency_key zorunlu (offline sipariş).
6. **Mevcut backend kuralları korunur.** Migrate sırasında bir iş kuralının ne yaptığı belirsizse, araç onu SİLMEZ/DEĞİŞTİRMEZ; `// TODO: verify rule` notu bırakıp geliştiriciye sorar.

---

## 4. Teknoloji Sürüm Sabitleri

| Alan | Sürüm |
|------|-------|
| .NET | 10 LTS |
| EF Core | 10 |
| PostgreSQL | 16+ |
| React | 18+ (TypeScript strict) |
| Node | 20 LTS |
| Flutter | stable (3.x) |
| Go | 1.22+ |
| Next.js | 14+ |

---

## 5. Faz Sırası (araçlar bu sırayı bozmaz)

- **Faz 0** Güvenlik temizliği (secret rotate, env'e taşıma) — KOD ÜRETİMİNDEN ÖNCE
- **Faz 1** Backend migrate + OpenAPI kontratı + client üretimi
- **Faz 2** Sadakat backend genişletmesi
- **Faz 3** Mobil sadakat MVP
- **Faz 4** Admin + POS web (paralel) + Go köprü
- **Faz 5** Müşteri web + geçiş

> Faz 1'de OpenAPI kontratı netleşmeden frontend/mobil üretimine geçilmez (client'lar oradan üretilecek).
