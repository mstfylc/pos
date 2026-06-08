import { useCallback, useEffect, useRef, useState, type ReactNode } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Icon, useToast } from "@/design-system";
import { PageHeader } from "@/shell/AdminShell";
import { pathForId } from "@/shell/nav";
import DashboardView from "./DashboardView";

interface RangeOpt {
  id: string;
  label: string;
  desc: string;
}
const RANGES: RangeOpt[] = [
  { id: "today", label: "Bugün", desc: "7 Haziran 2026, Pazar" },
  { id: "yesterday", label: "Dün", desc: "6 Haziran 2026, Cumartesi" },
  { id: "7d", label: "Son 7 gün", desc: "1 – 7 Haziran 2026" },
  { id: "30d", label: "Son 30 gün", desc: "9 Mayıs – 7 Haziran 2026" },
  { id: "month", label: "Bu ay", desc: "Haziran 2026" },
  { id: "custom", label: "Özel aralık…", desc: "Tarih aralığı seç" },
];

interface DateRangePickerProps {
  value: string;
  onChange: (id: string) => void;
}
function DateRangePicker({ value, onChange }: DateRangePickerProps): ReactNode {
  const [open, setOpen] = useState(false);
  const ref = useRef<HTMLDivElement>(null);
  useEffect(() => {
    function h(e: MouseEvent): void {
      if (ref.current && !ref.current.contains(e.target as Node)) setOpen(false);
    }
    document.addEventListener("mousedown", h);
    return () => document.removeEventListener("mousedown", h);
  }, []);
  const cur = RANGES.find((r) => r.id === value) ?? RANGES[0];
  return (
    <div ref={ref} style={{ position: "relative" }}>
      <Button variant="outline" color="dark" iconStart="calendar" iconEnd={open ? "chevron-up" : "chevron-down"} onClick={() => setOpen((o) => !o)}>
        {cur.label}
      </Button>
      {open && (
        <div className="as-menu as-menu--right" style={{ minWidth: 228, top: "calc(100% + 8px)" }}>
          {RANGES.map((r) => (
            <button key={r.id} className={"as-menu__item" + (r.id === value ? " as-menu__item--active" : "")} onClick={() => { onChange(r.id); setOpen(false); }}>
              <Icon name={r.id === "custom" ? "calendar" : "check-circle"} size={16} color={r.id === value ? "var(--color-primary)" : "var(--text-placeholder)"} style={{ opacity: r.id === value || r.id === "custom" ? 1 : 0 }} />
              <span>{r.label}<small>{r.desc}</small></span>
              {r.id === value && <Icon name="check-circle" size={15} color="var(--color-primary)" style={{ marginLeft: "auto" }} />}
            </button>
          ))}
        </div>
      )}
    </div>
  );
}

export function DashboardPage(): ReactNode {
  const navigate = useNavigate();
  const toast = useToast();
  const [range, setRange] = useState("today");
  const cur = RANGES.find((r) => r.id === range) ?? RANGES[0];
  const onNavigate = useCallback((id: string) => navigate(pathForId(id)), [navigate]);

  return (
    <>
      <PageHeader
        crumb={["Genel", "Ana Sayfa"]}
        title="Genel Bakış"
        desc={`Çayyolu Şubesi'nin performansı · ${cur.label} (${cur.desc})`}
        actions={
          <>
            <DateRangePicker value={range} onChange={setRange} />
            <Button color="accent" iconStart="handcart" onClick={() => toast({ type: "info", title: "POS uygulaması", description: "POS ayrı bir uygulamada (dokunmatik kasa) açılır." })}>
              POS'u Aç
            </Button>
          </>
        }
      />
      <DashboardView range={range} onNavigate={onNavigate} />
    </>
  );
}
