# Çalışma Akışı — Üç Aracın Birlikte Çalışması

> Claude Design + Claude Code + Codex'in çakışmadan, tutarlı kod üretmesi için iş akışı. Hepsi `ARCHITECTURE.md` ve `DESIGN_SYSTEM.md`'ye uyar.

---

## 1. Rol Dağılımı

| Araç | Birincil görev | Dokunduğu klasörler |
|------|----------------|---------------------|
| **Claude Design** | UI/UX görsel tasarımı, ekran akışı, prototip iterasyonu | (kod değil) → spec + görsel üretir |
| **Claude Code** | Yeni frontend & mobil üretimi, tasarımı koda dökme, Go köprü | admin-web/, pos-web/, customer-web/, mobile/, print-bridge/ |
| **Codex** | Backend migrate & yeni modüller, OpenAPI, client üretimi, CI | backend/, contracts/, packages/api-client-* (üretim komutu) |

> Kesin kural değil ama **varsayılan**: yeni üretim büyük parça → Claude Code; mevcut backend'e hassas dokunuş → Codex (gözden geçirilerek).

---

## 2. Altın Kural: Tek Yönlü Bağımlılık

```
contracts/openapi.yaml   (TEK kaynak — elle güncellenir)
        │  codegen
        ├──────────────► packages/api-client-ts   → admin-web, pos-web, customer-web kullanır
        └──────────────► packages/api-client-dart → mobile kullanır
```

- Frontend/mobil **asla** kendi API tipini yazmaz; üretilen client'ı import eder.
- Yeni endpoint gerekiyorsa: (1) Codex `openapi.yaml`'ı günceller → (2) codegen çalışır → (3) Claude Code üretilen client'ı kullanır.
- Bu sıra bozulmaz; aksi halde tip uyuşmazlığı/çift kaynak çıkar.

---

## 3. Eşzamanlı Çalışma — Çakışmayı Önleme

1. **Klasör sahipliği**: Bir araç başka aracın birincil klasöründe çalışırken önce o klasörün sahibinin kuralına (üst tablo) uyar. Mümkünse aynı anda aynı klasörde iki araç çalıştırma.
2. **Branch disiplini**: Her iş kendi feature branch'inde (`feat/admin-product-list`, `feat/backend-loyalty-module`). Main'e doğrudan yazılmaz.
3. **Küçük PR**: Bir araca tek seferde tek ekran / tek modül / tek endpoint grubu verilir. "Tüm admin paneli" gibi dev görev verilmez.
4. **Kontrat değişimi tek elden**: `openapi.yaml`'ı aynı anda iki araç değiştirmez; backend (Codex) sahibidir.

---

## 4. Tipik Döngü (yeni bir ekran örneği)

```
1. Claude Design   → "Ürün listesi ekranı" tasarla, akış+state'leri belirle, görsel onayla
2. Codex           → gereken endpoint'ler openapi.yaml'da var mı? yoksa ekle → codegen
3. Claude Code     → onaylı tasarım + api-client-ts + DESIGN_SYSTEM ile ekranı kur
4. Geliştirici     → DEFINITION_OF_DONE kontrol listesi → PR review → merge
```

---

## 5. Bağlam Verme (her araca aynı şekilde)

Her araca görev verirken başına şunu ekle:

> "Önce repo kökündeki ARCHITECTURE.md ve docs/DESIGN_SYSTEM.md'yi oku. Bu dosyalardaki kararlara ve sınır kurallarına uy. API tipi yazma — packages/api-client-* kullan. Secret yazma. Token hardcode etme."

Araçların kendi kural dosyaları (CLAUDE.md, AGENTS.md, .cursorrules) bunu zaten içerir; manuel oturumlarda da hatırlat.

---

## 6. Anti-Pattern'ler (yapma)

- ❌ İki araca aynı anda aynı dosyayı yazdırmak
- ❌ Frontend'de elle API tipi/fetch yazmak (client üretilmişken)
- ❌ "Tüm sistemi kur" gibi tek dev prompt
- ❌ openapi.yaml'ı frontend tarafından değiştirmek
- ❌ Tasarım onaylanmadan ekran kodu üretmek (tutarsız UI riski)
- ❌ Mevcut backend iş kuralını anlamadan silmek/değiştirmek
