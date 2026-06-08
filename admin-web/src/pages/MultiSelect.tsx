import { type ReactNode } from "react";

export interface MultiOption {
  id: string;
  label: string;
}

interface Props {
  options: MultiOption[];
  selected: Set<string>;
  onToggle: (id: string) => void;
  emptyText?: string;
}

/** Basit çoklu seçim (checkbox listesi) — scope/atama alanları için. */
export function MultiSelect({ options, selected, onToggle, emptyText = "Seçenek yok." }: Props): ReactNode {
  if (options.length === 0) return <div className="fm-multi"><div className="fm-multi__empty">{emptyText}</div></div>;
  return (
    <div className="fm-multi">
      {options.map((o) => (
        <label className="fm-multi__row" key={o.id}>
          <input type="checkbox" checked={selected.has(o.id)} onChange={() => onToggle(o.id)} />
          <span>{o.label}</span>
        </label>
      ))}
    </div>
  );
}
