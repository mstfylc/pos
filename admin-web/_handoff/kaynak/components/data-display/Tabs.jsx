import React from "react";

const CSS = `
.mttabs{display:flex;align-items:center;gap:4px;border-bottom:1px solid var(--border-default);}
.mttabs--pills{border-bottom:0;gap:6px;}
.mttab{appearance:none;background:none;border:0;cursor:pointer;font-family:var(--font-sans);
  font-weight:var(--fw-semibold);font-size:13px;letter-spacing:var(--ls-tight);color:var(--text-muted);
  padding:10px 12px;position:relative;display:inline-flex;align-items:center;gap:7px;transition:color .15s;white-space:nowrap;}
.mttab:hover{color:var(--text-heading);}
.mttab--active{color:var(--color-primary);}
.mttabs:not(.mttabs--pills) .mttab--active::after{content:"";position:absolute;left:8px;right:8px;bottom:-1px;height:2px;
  background:var(--color-primary);border-radius:2px;}
.mttabs--pills .mttab{border-radius:var(--radius-sm);padding:7px 14px;}
.mttabs--pills .mttab--active{background:var(--color-primary);color:#fff;}
.mttabs--pills .mttab:hover:not(.mttab--active){background:var(--color-grey-100);}
.mttab__count{font-size:11px;font-weight:var(--fw-semibold);color:var(--text-muted);background:var(--color-grey-100);
  border-radius:999px;padding:1px 7px;}
.mttab--active .mttab__count{background:var(--color-primary-soft);color:var(--color-primary);}
`;

function inject() {
  if (typeof document === "undefined" || document.getElementById("mt-tabs-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-tabs-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

/**
 * Tab bar. `tabs` = [{ id, label, count? }]. Controlled via `value`/`onChange`,
 * or uncontrolled with `defaultValue`.
 */
export function Tabs({ tabs = [], value, defaultValue, onChange, variant = "underline", className = "" }) {
  React.useEffect(() => { inject(); }, []);
  const [internal, setInternal] = React.useState(defaultValue ?? (tabs[0] && tabs[0].id));
  const active = value !== undefined ? value : internal;
  const select = (id) => { if (value === undefined) setInternal(id); onChange && onChange(id); };
  return (
    <div className={"mttabs " + (variant === "pills" ? "mttabs--pills " : "") + className} role="tablist">
      {tabs.map((t) => (
        <button
          key={t.id}
          role="tab"
          aria-selected={active === t.id}
          className={"mttab" + (active === t.id ? " mttab--active" : "")}
          onClick={() => select(t.id)}
        >
          {t.label}
          {t.count != null && <span className="mttab__count">{t.count}</span>}
        </button>
      ))}
    </div>
  );
}
