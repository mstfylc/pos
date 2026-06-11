# Design Brief — B3: Admin Satınalma + Yapı + Yetki

> Faz A · admin-web · backend hazır. Konvansiyon: `A2-pos-satis-ekrani.md`.

## 1. Amaç
İşletme yapısı, personel yetkilendirme ve satınalma/tedarikçi yönetimi. Üç ilişkili alan, tek brief.

## 2. Ekran grupları
### a) Satınalma
- **Tedarikçiler**: ad, yetkili, vergi, vade, açılış bakiyesi.
- **Satınalma siparişi**: tedarikçi + mağaza + satır kalemleri (ürün/miktar/fiyat/vergi) → mal kabul → stok girişi.

### b) Yapı
- **Şube / Mağaza / POS** CRUD (hiyerarşi).

### c) Yetki
- **Kullanıcı** CRUD (zaten var, genişlet: PIN/kart).
- **Rol** + **Permission** ataması (role-permissions matrisi).
- **Atama**: personel → şube/POS/mağaza (assignments).

## 3. DS bileşen eşlemesi
DataTable, Form (satır ekleme tablolu — satınalma kalemleri), Modal, Tabs, Checkbox matrisi (permissions), StatusBadge, Toast.

## 4. Veri kaynakları
`admin/suppliers`, `admin/purchases`, `admin/branches`, `admin/stores`, `admin/pos`, `admin/users`, `admin/roles`, `admin/permissions`, `admin/roles/{id}/permissions`, `admin/assignments` (✅).

## 5. 4 state
loading skeleton · empty "+ Ekle" · error retry · success Toast.

## 6. Özel kurallar
- Satınalma "Received" olunca stok girişi tetiklenir (backend yapar; UI durumu gösterir).
- Permission matrisi: rol × yetki checkbox; tenant scope.
- Cari/vade alanları para birimi token'lı.

## 7. "Yakında"
- Tedarikçi cari ekstre/ödeme takibi (🟡) · satınalma onay akışı/bütçe (🔜).
