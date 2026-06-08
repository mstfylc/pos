# Uyanık Design System — Proje Kuralları

Bu projede TÜM ekranlar şu kurallara uyar (kullanıcının kural bloğu, kalıcı):

## Marka
- Lacivert `#1F3864` **yapısal**: menü, başlık, link, nötr aksiyon.
- Turuncu `#E08A2B` **SADECE tek primary CTA** için. Bir ekranda **en fazla bir** dolu turuncu buton.
- Secondary = lacivert outline / nötr. Tertiary = ghost. Silme = kırmızı (`danger`).

## Durumlar
- Her veri ekranı 4 durum: **yükleniyor, boş (empty + aksiyon), hata, dolu.**

## Bileşenler (DS — yeni icat etme)
- Primitifler: Button, IconButton, Input, Select, Textarea, Checkbox, Radio, Switch, Card, Badge, Avatar, Tabs, Tag, Alert, Progress, Icon.
- Bu projede eklenen ortak bileşenler: **DataGrid, Modal, Drawer, Toast (ToastProvider/useToast), StatusBadge, FilterBar, PageHeader, EmptyState, AdminShell.**
- Hepsi `window.MetronicDesignSystem_a73f8f` altında.

## Tablolar
- DataGrid: sunucu-taraflı his veren sayfalama/sıralama/filtre; boş/yükleniyor/hata dahil.

## Formlar
- label + hint + inline hata. Kaydet (primary) / İptal (ghost). Zorunlu alan `*`.

## Genel
- Dil: **Türkçe**. Para **₺**, tarih **GG.AA.YYYY**.
- Tüm admin ekranları aynı kabuğu paylaşır (sol menü + üst bar) → `AdminShell`.
- Responsive + erişilebilir (label/focus/kontrast).

## Mimari
- Admin kabuğu + ortak bileşenler: `ui_kits/admin/` ve `components/`.
- Her ekran tek HTML entry'de view olarak router ile bağlanır (sidebar gezinir).
- Yüzeyler: Admin paneli, POS (dokunmatik PWA), Müşteri Web, Mobil sadakat (telefon çerçevesi).
