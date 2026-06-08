import { type ReactNode } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { Icon, type IconName } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { itemByPath } from "@/shell/nav";
import "./Placeholder.css";

/* Bu pakette hazır olmayan view'lar için yer tutucu.
   Sonraki paketlerde her biri gerçek ekrana dönüşecek. */

interface ReadyScreen {
  path: string;
  label: string;
  icon: IconName;
  desc: string;
}
const READY: ReadyScreen[] = [
  { path: "/", label: "Ana Sayfa", icon: "home", desc: "Genel bakış panosu" },
];

const SOON_DETAIL: Record<string, string> = {
  "/orders": "Sipariş listesi, detay drawer ve durum akışı.",
  "/products": "Katalog yönetimi, ürün formu ve varyantlar.",
  "/categories": "Kategori ağacı, sürükle-bırak sıralama ve ürün sayıları.",
  "/stock": "Stok seviyeleri, hareketler ve eşik uyarıları.",
  "/transfer": "Şubeler arası stok transfer talepleri ve onay akışı.",
  "/purchase": "Tedarikçi siparişleri, irsaliye ve mal kabul.",
  "/customers": "Müşteri profilleri ve sadakat geçmişi.",
  "/campaigns": "İndirim kuralları, kupon ve kampanya zamanlayıcısı.",
  "/loyalty": "Sadakat seviyeleri, puan ve ödül kuralları.",
  "/users": "Personel hesapları, şube ataması ve durum yönetimi.",
  "/roles": "Rol tanımları ve ekran bazında yetki matrisi.",
  "/company": "Şirket bilgileri, şube ve POS cihaz yönetimi.",
  "/reports": "Satış, stok ve sadakat raporları + dışa aktarım.",
  "/settings": "Vergi, para birimi, fiş şablonu ve genel ayarlar.",
};

export function PlaceholderPage(): ReactNode {
  const location = useLocation();
  const navigate = useNavigate();
  const item = itemByPath(location.pathname);
  const title = item?.label ?? "Sayfa";

  return (
    <>
      <PageHeader crumb={["Sayfalar", title]} title={title} />
      <div className="ph-soon">
        <span className="ph-soon__badge"><Icon name="rocket" size={12} color="var(--color-primary)" />Geliştiriliyor</span>
        <div className="ph-soon__t">{title}</div>
        <div className="ph-soon__s">
          {SOON_DETAIL[location.pathname] ?? "Bu ekran öncelik sırasına göre eklenecek."} Bu modül yapım aşamasında — aşağıdaki hazır ekrana geçebilirsin.
        </div>
      </div>
      <div className="ph-divider">Hazır ekranlar</div>
      <div className="ph-grid">
        {READY.map((r) => (
          <button className="ph-card" key={r.path} onClick={() => navigate(r.path)}>
            <span className="ph-card__ic"><Icon name={r.icon} size={18} color="var(--color-primary)" /></span>
            <span className="ph-card__t"><b>{r.label}</b><span>{r.desc}</span></span>
          </button>
        ))}
      </div>
    </>
  );
}
