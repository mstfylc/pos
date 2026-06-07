# SUNUCU HAZIRLIK RAPORU - 2026-06-07

## On Kontrol
| Kontrol | Sonuc |
|---------|-------|
| OS | Ubuntu 24.04.4 LTS |
| RAM | 3.7Gi toplam, 3.2Gi uygun |
| Disk | 75G toplam, 67G uygun, %8 kullanim |
| Docker | Eksikti; kuruldu |
| Docker Compose | Eksikti; kuruldu |
| UFW | Aktif; 22/80/443 disinda inbound kapali |
| Fail2ban | Eksikti; kuruldu ve aktif |
| Acik portlar | SSH ve local DNS listener disinda public servis yok |
| Mevcut uygulama servisi | Calisan app/container gorulmedi |

## Yapilan Hazirlik
| Adim | Durum |
|------|-------|
| Docker Engine | Kuruldu ve servis aktif |
| Docker Compose plugin | Kuruldu |
| PostgreSQL 16 zemini | docker-compose.prod ile calismaya hazir; deploy henuz yapilmadi |
| UFW firewall | 22/80/443 allow, default incoming deny |
| Fail2ban | Aktif |
| SSH hardening | root key-only, password ve keyboard-interactive login kapali |
| Production env | Yeni guclu secret'larla sunucuda olusturuldu; repoya yazilmadi |

## Production Env
| Konum | Durum |
|-------|-------|
| /opt/uyanik/.env | Olusturuldu, chmod 600, root:root |
| Secret degerleri | Sohbete, repoya, commit mesajina veya koda yazilmadi |

## Deploy Durumu
| Kalem | Durum |
|-------|-------|
| Gercek uygulama deploy'u | YAPILMADI |
| docker-compose.prod calistirma | BEKLIYOR |
| Deploy'a hazir mi | Evet; onay bekliyor |

## Sonraki Onay
- Onay verilirse production deploy icin repo sunucuya alinip docker-compose.prod ile uygulama baslatilacak.
