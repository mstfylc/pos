# DESIGN KIT — Claude Design Oturumu İçin Tek Giriş Noktası

> Her Design oturumunda bunu aç. İçinde: bağlam dosyaları, yapıştır-çalıştır prompt, token değerleri, gerçek bileşen envanteri, kurallar, ekran sırası ve hazır ekran prompt'ları.
> Detay brief'ler: `./` (A1–B5, C1, D1). Faz: `../POS_FEATURE_MAP.md`. Tema: `../THEMING.md`. DS toparlama: `../DESIGN_SYSTEM_CONSOLIDATION.md`.

---

## 1. Oturum nasıl başlar (adımlar)
1. Claude Design'a **bağlam dosyalarını** ver (§2).
2. **Açılış prompt'unu** yapıştır (§3).
3. Tek ekran seç (§7 sıra) → o ekranın **brief'ini** + **ekran prompt'unu** (§8) ver.
4. İtere et: layout → bileşen yerleşimi → token renkleri → 4 state → light/dark + 1 alternatif palet → etkileşim.
5. Onayla → çıktıyı (§9) Claude Code'a devret.

## 2. Bağlam dosyaları (Design'a yükle)
- `ARCHITECTURE.md` · `docs/DESIGN_SYSTEM.md` · `docs/THEMING.md`
- O ekranın brief'i (örn. `docs/design-briefs/A2-pos-satis-ekrani.md`)
- (Ref) `docs/design-briefs/README.md` (sıra/durum)

## 3. Açılış prompt'u (yapıştır)
```
Önce ARCHITECTURE.md ve docs/DESIGN_SYSTEM.md'yi oku. Görsel temel: Metronic
(lacivert/turuncu varsayılan ama tek seçenek değil). Renkler SEMANTIC TOKEN'dan
gelir (primary/accent/surface/text/border/semantic); hex HARDCODE EDİLMEZ.
Arayüz temalanabilir (palet galerisi + açık/koyu, docs/THEMING.md) — bu yüzden
mockup'ları token adlarıyla kur ve en az 1 alternatif palet + light/dark örneği
ver. Yeni buton/input İCAT ETME; aşağıdaki bileşen setini kullan/genişlet.
Her veri ekranı 4 state taşır: loading · empty · error · success. Backend'i
olmayan özellikler "Yakında" rozeti + disabled. POS'ta dokunmatik ≥48px,
ürün kartı ≥80×80px. Tek seferde tek ekran tasarla.
```

## 4. Tasarım token'ları (kaynak: packages/design-tokens/tokens.json)

### Semantic renk rolleri (bileşenler bunları kullanır)
`primary` · `primaryHover` · `accent` · `accentHover` · `surface.bg` · `surface.card` · `surface.border` · `surface.overlay` · `text` (neutral.900) · `text.muted` (neutral.500) · `success` · `warning` · `danger` · `info`

### Palet galerisi (primary / accent) — her biri light+dark
| Palet | primary | accent |
|---|---|---|
| Lacivert/Turuncu (varsayılan) | #1F3864 | #E08A2B |
| Yeşil/Amber | #1E7145 | #E0A52B |
| Mor/Teal | #5B3E9B | #1FA8A0 |
| Antrasit/Mavi | #2B3440 | #2E75B6 |
| Bordo/Altın | #7A263A | #C9961A |

Ortak semantic: success #1E7145 · warning #C9961A · danger #C0392B · info #2E75B6
Light surface: bg #F7F9FC · card #FFFFFF · text #1A1F26 · border #DDE4EE
Dark surface: bg #1A1F26 · card #222831 · text #F7F9FC · border koyu

### Tipografi
Inter · size(px): xs12 sm14 base16 lg18 xl22 2xl28 3xl34 · weight: 400/500/600/700 · line-height: tight1.25 normal1.5

### Spacing / Radius / Shadow / Touch
spacing(px): 4·8·12·16·24·32·48 · radius: sm6 md10 lg16 full · shadow: sm/md/lg
**touch: minTarget 48px · POS kart min 80px**

## 5. Bileşen envanteri (mevcut DS — bunları kullan, yenisini icat etme)
**Buton:** Button (primary/secondary/ghost/danger · sm/md/lg · loading zorunlu) · IconButton
**Form:** Input · Select · Checkbox · Radio · Switch (label+hint+error state)
**Veri:** DataGrid (sunucu pagination/sort/filter, boş/yükleniyor/hata zorunlu) · Card · Badge · StatusBadge · Tag · Tabs · Avatar · Progress
**Geri bildirim:** Alert · ToastProvider (success/warning/danger/info)
**Overlay:** Modal · Drawer
**Diğer:** Icon (49 ikon seti)
**POS uzantısı (yeni, aynı token):** büyük ürün/kategori kartı (≥80px), numpad, sepet satırı, offline StatusBadge varyantı

## 6. Zorunlu kurallar (her ekran)
- **4 state**: loading · empty · error · success — atlanırsa eksik.
- **Token**: renk/spacing/tipografi hardcode yok; semantic token adıyla.
- **Tema**: en az 1 alternatif palet + light/dark örneği.
- **Bileşen sözleşmesi**: §5 setini kullan.
- **POS**: dokunmatik ≥48px, ürün kartı ≥80×80px, sepet hep görünür, ödeme 1-2 tık.
- **Yakında**: backend'siz özellik disabled + rozet.

## 7. Ekran sırası (başlangıç → sona)
1. **A2 POS satış ana ekranı** ← BURADAN BAŞLA
2. A3 Checkout → 3. A1 POS giriş → 4. A4 müşteri tanıma → 5. A5 sadakat/ödül
6. A6 offline/fiş → 7. A7 vardiya/kasa/Z → 8. B5 tema ekranı
9. B1 stok → 10. B2 sadakat admin → 11. B3 satınalma/yapı/yetki → 12. B4 raporlama
13. C1 restoran (Yakında) → 14. D1 müşteri mobil

## 8. Ekran prompt şablonu + ilk örnekler
**Şablon:**
```
docs/design-briefs/<DOSYA>'daki <EKRAN>'ı tasarla. Brief'teki layout bölgeleri,
DS bileşen eşlemesi ve veri kaynaklarına uy. 4 state'i (loading/empty/error/
success) ayrı ayrı göster. Varsayılan palet + 1 alternatif, light + dark ver.
"Yakında" öğelerini disabled+rozet çiz.
```
**A2:** `docs/design-briefs/A2-pos-satis-ekrani.md` — kategori+ürün grid, kalıcı sağ sepet, üst bar offline göstergesi, büyük Ödeme CTA. Tablet + dar POS varyantı.
**A3:** `docs/design-briefs/A3-pos-checkout.md` — çoklu ödeme modalı, kalan≠0 ise CTA pasif, numpad.
**A1:** `docs/design-briefs/A1-pos-giris.md` — email/parola + PIN numpad, sonra POS seçimi.

## 9. Beklenen çıktı (her ekran)
- Masaüstü/tablet + (POS ise) dar varyant — **2 responsive**.
- **4 state** mockup'ları (en az ana veri bölgesi için).
- **Light + dark** ve **≥1 alternatif palet** örneği (token doğruluğunu kanıtlar).
- Etkileşim akışı (tık-tık) + "Yakında" disabled görünümü.
- Renkler token adıyla (hex gömme).

> Onaylanan çıktı → Claude Code: "Onaylı <ekran> tasarımını packages/ui bileşenleri + tokens.json ile kur; DEFINITION_OF_DONE'dan geçir."
