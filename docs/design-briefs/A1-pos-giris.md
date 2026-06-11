# Design Brief — A1: POS Giriş / Cihaz Seçimi

> Faz A · pos-web · Öncelik 1. Konvansiyon: `A2-pos-satis-ekrani.md`.

## 1. Amaç
Kasiyerin hızlı ve güvenli oturum açması; hangi POS/şube cihazında çalışıldığının seçimi. Dokunmatik, sade.

## 2. Layout bölgeleri
- Ortada marka logosu + giriş kartı (Metronic auth stili, lacivert zemin/pattern).
- **İki giriş yöntemi**: (a) e-posta/kullanıcı + parola, (b) **PIN ile hızlı giriş** (numpad) — vardiya içinde personel değişimi için.
- Giriş sonrası **POS/cihaz seçimi**: şube → POS listesi (kart). Cihaz hatırlanır (bir dahaki açılışta atlanır).

## 3. DS bileşen eşlemesi
Card (auth), Input (email/parola), Button primary/lg (loading zorunlu), numpad (PIN — POS uzantı bileşeni), Select/Card (POS seçimi), Alert (hata).

## 4. Veri kaynakları
| Veri | Endpoint |
|---|---|
| Giriş | `POST /api/v1/auth/login` |
| Token yenile | `POST /api/v1/auth/refresh` |
| POS listesi | `GET /api/v1/app/pos?companyId` |

> `must_change_password=true` ise parola değiştirme ekranına yönlendir.

## 5. 4 state
- loading: buton spinner · empty: POS yoksa "Tanımlı POS yok" · error: "Geçersiz kimlik" Alert · success: panele/satış ekranına geçiş.

## 6. Özel kurallar
- PIN ekranı dokunmatik ≥48px tuşlar.
- Hatalı denemede kilitleme/gecikme (güvenlik) — görsel geri bildirim.
- Token client'ta güvenli saklanır; secret/hardcode yok.

## 7. "Yakında"
- Biyometrik / kart ile giriş (🔜).
