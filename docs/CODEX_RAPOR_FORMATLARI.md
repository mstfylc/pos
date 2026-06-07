# Codex Rapor Formatları

> Token tasarrufu kuralı: Codex raporları SOHBETE uzun uzun yazmaz. Raporları repoya dosya olarak yazar ve commit'ler. Geliştirici gerektiğinde tek dosyayı iletir. Formatlar kısadır; gereksiz açıklama, tekrar, envanter dökümü YOK.

## Nereye yazılır
- Adım raporu: `docs/reports/STEP_LOG.md` (her adımda 4 satır EKLENİR, üzerine yazılmaz).
- Paket sonu raporu: `docs/reports/PACKAGE_REPORT.md` (paket bitince doldurulur/güncellenir).
- DUR listesi: aynı PACKAGE_REPORT.md içinde "DUR LİSTESİ" başlığı altında.

---

## FORMAT 1 — Adım raporu (STEP_LOG.md'ye eklenir, her adım 4 satır)
```
### [tarih saat] ADIM <n> — <kısa ad> — branch: <branch> — build: YEŞİL/KIRMIZI
- Yapılan: <tek cümle>
- Dosya/commit: <n dosya>, commit <hash kısa>
- Takılan: yok / <tek cümle>
```
Kurallar: 4 satırı geçme. Kod parçası, envanter, uzun gerekçe yazma. "Takılan: yok" ise o kadar.

---

## FORMAT 2 — Paket sonu raporu (PACKAGE_REPORT.md)
```
# FAZ 1 PAKET RAPORU — <tarih>

## Tamamlanan
| Adım | Branch | Build | Commit |
|------|--------|-------|--------|
| 3 İskelet | feat/be-skeleton | YEŞİL | <hash> |
| 4 Domain | feat/be-domain | YEŞİL | <hash> |
| 5 Ledger+Sadakat | feat/be-ledger | YEŞİL | <hash> |
| 6 OpenAPI | feat/be-openapi | YEŞİL | <hash> |

## DUR LİSTESİ (karar bekleyen)
| # | Konum (dosya) | Eski davranış | Sorulan karar |
|---|---------------|---------------|---------------|
| 1 | <dosya:satır> | <1 cümle> | <1 cümle soru> |

## Davranış değişiklikleri (ledger reversal vb.)
| # | Konum | Eski | Yeni (uygulanan) |
|---|-------|------|------------------|

## Sıradaki öneri
- <1-2 madde>
```
Kurallar: tablo dışı uzun metin yazma. Her hücre tek cümle. Çözülen şeyleri DUR listesine koyma; sadece karar bekleyenler.

---

## Sohbete ne gelir
Geliştirici bana yalnızca PACKAGE_REPORT.md içeriğini iletir (tek dosya, kısa). STEP_LOG ara takip içindir, sohbete gerekmez. Böylece sohbet token'ı minimumda kalır.
