import type { IconName } from "@/design-system";

/* Sol menü tanımı — 15 view, 3 bölüm. Sıra ve etiketler handoff AdminShell ile birebir. */

export interface NavItem {
  id: string;
  label: string;
  path: string;
  icon: IconName;
  /** Yetki anahtarı — auth.can() ile filtrelenir (şimdilik hepsi açık) */
  perm: string;
  /** Sağda rozet (örn. bekleyen sipariş sayısı) */
  count?: string;
}

export interface NavSection {
  sec: string;
  items: NavItem[];
}

export const NAV: NavSection[] = [
  {
    sec: "Genel",
    items: [
      { id: "home", label: "Ana Sayfa", path: "/", icon: "home", perm: "dashboard.view" },
      { id: "orders", label: "Siparişler", path: "/orders", icon: "handcart", perm: "order.view", count: "12" },
      { id: "products", label: "Ürünler", path: "/products", icon: "notepad-bookmark", perm: "product.view" },
      { id: "categories", label: "Kategoriler", path: "/categories", icon: "category", perm: "category.view" },
      { id: "stock", label: "Stok / Depo", path: "/stock", icon: "folder", perm: "stock.view" },
      { id: "transfer", label: "Stok Transferi", path: "/transfer", icon: "share", perm: "transfer.view" },
      { id: "purchase", label: "Satın Alma", path: "/purchase", icon: "files", perm: "purchase.view" },
    ],
  },
  {
    sec: "Müşteri & Sadakat",
    items: [
      { id: "customers", label: "Müşteriler", path: "/customers", icon: "people", perm: "customer.view" },
      { id: "discounts", label: "İndirim", path: "/discounts", icon: "price-tag", perm: "discount.view" },
      { id: "campaigns", label: "Kampanyalar", path: "/campaigns", icon: "rocket", perm: "campaign.view" },
      { id: "loyalty", label: "Sadakat", path: "/loyalty", icon: "heart", perm: "loyalty.view" },
    ],
  },
  {
    sec: "Yönetim",
    items: [
      { id: "users", label: "Kullanıcılar", path: "/users", icon: "profile-circle", perm: "user.view" },
      { id: "roles", label: "Roller & Yetkiler", path: "/roles", icon: "key", perm: "role.view" },
      { id: "company", label: "Şirket / Şube / POS", path: "/company", icon: "dots-square", perm: "company.view" },
      { id: "reports", label: "Raporlar", path: "/reports", icon: "chart-line-up", perm: "report.view" },
      { id: "settings", label: "Ayarlar", path: "/settings", icon: "setting-2", perm: "settings.view" },
    ],
  },
];

export const ALL_ITEMS: NavItem[] = NAV.flatMap((s) => s.items);

export function itemByPath(pathname: string): NavItem | undefined {
  return ALL_ITEMS.find((i) => i.path === pathname);
}

export function pathForId(id: string): string {
  return ALL_ITEMS.find((i) => i.id === id)?.path ?? "/";
}
