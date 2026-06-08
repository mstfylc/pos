import type { ReactNode } from "react";

export interface DashboardViewProps {
  /** Tarih aralığı anahtarı: today | yesterday | 7d | 30d | month | custom */
  range?: string;
  /** Sidebar/aksiyon yönlendirmesi — nav id'si alır (örn. "stock", "orders") */
  onNavigate?: (id: string) => void;
}

export default function DashboardView(props: DashboardViewProps): ReactNode;
