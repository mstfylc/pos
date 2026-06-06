# Definition of Done — Her İş/PR İçin Kontrol Listesi

> Hangi araç üretirse üretsin, bir iş "bitti" sayılmadan önce bu liste geçilir. Araçlara: "İşin sonunda bu listeyi kendi çıktına uygula ve eksikleri tamamla."

## Genel (tüm kod)
- [ ] ARCHITECTURE.md sınır kurallarına uyuldu (§3)
- [ ] Hiçbir secret/token/parola/connection string koda girmedi
- [ ] Hardcoded tasarım token'ı yok (renk/spacing/tipografi import edildi)
- [ ] Tek sorumluluk: PR tek ekran/modül/endpoint grubu kapsıyor (dev PR değil)
- [ ] Anlamlı isimlendirme, ölü kod / yorum kalıntısı yok
- [ ] README/örnek env güncel (yeni env değişkeni eklendiyse *.example'a yazıldı)

## Backend (.NET) — Codex/Cursor
- [ ] İş mantığı Application/Domain'de; Controller ince
- [ ] Validation FluentValidation ile
- [ ] Tenant scope (company_id) her sorgu/komutta uygulanıyor
- [ ] Finansal/stok/puan işlemi TEK transaction içinde
- [ ] Offline gelebilecek işlemlerde idempotency_key destekleniyor
- [ ] Append-only tablolarda hard-delete yok
- [ ] EF migration eklendi ve adlandırıldı; yıkıcıysa veri taşıma adımı var
- [ ] Birim test: kritik use-case (sipariş/iade/puan/transfer) için en az happy + 1 edge
- [ ] OpenAPI kontratı güncellendi (endpoint değiştiyse) ve client yeniden üretildi

## Frontend / Mobil — Claude Code
- [ ] API tipleri üretilen client'tan; elle fetch/type yok
- [ ] 4 state mevcut: loading, empty, error, success
- [ ] Bileşen sözleşmesine uygun (DESIGN_SYSTEM §2); yeni bileşen icat edilmedi
- [ ] Responsive (mobil/geniş) ve erişilebilir (label, focus, kontrast)
- [ ] TypeScript strict / Dart analyzer temiz; any yok
- [ ] Onaylı tasarıma (Claude Design çıktısı) sadık

## POS web özel
- [ ] Offline outbox çalışıyor (kesintide satış, dönüşte idempotent senkron)
- [ ] Yazıcı köprüsü erişilemezse zarif uyarı + retry, satış bloklanmıyor
- [ ] Dokunmatik hedefler ≥ 48px; ödeme 1-2 tık
- [ ] Ödeme toplamı = sipariş toplamı değilse kapat pasif

## Güvenlik (her PR hızlı tarama)
- [ ] Yeni dependency güvenli/güncel mi
- [ ] Yetkilendirme: yeni endpoint AllowAnonymous değil (login/otp/public hariç)
- [ ] Kişisel veri loglanmıyor (KVKK)
