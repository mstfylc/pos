import React from "react";

const CSS = `
.mtbadge{display:inline-flex;align-items:center;gap:5px;font-family:var(--font-sans);font-weight:var(--fw-semibold);
  letter-spacing:var(--ls-tight);border-radius:var(--radius-sm);white-space:nowrap;line-height:1;}
.mtbadge--sm{height:18px;padding:0 6px;font-size:10px;}
.mtbadge--md{height:22px;padding:0 8px;font-size:11px;}
.mtbadge--lg{height:26px;padding:0 10px;font-size:12px;}
.mtbadge__dot{width:6px;height:6px;border-radius:50%;background:currentColor;}
.mtbadge--pill{border-radius:999px;}
/* solid */
.mtbadge--solid.b-primary{background:var(--color-primary);color:#fff;}
.mtbadge--solid.b-success{background:var(--color-success);color:#fff;}
.mtbadge--solid.b-danger{background:var(--color-danger);color:#fff;}
.mtbadge--solid.b-warning{background:var(--color-warning);color:var(--color-coal-900);}
.mtbadge--solid.b-info{background:var(--color-info);color:#fff;}
.mtbadge--solid.b-dark{background:var(--color-coal-900);color:#fff;}
.mtbadge--solid.b-secondary{background:var(--color-grey-200);color:var(--text-heading);}
.mtbadge--solid.b-accent{background:var(--color-accent);color:#fff;}
/* light (soft tint) */
.mtbadge--light.b-primary{background:var(--color-primary-soft);color:var(--color-primary);}
.mtbadge--light.b-success{background:var(--color-success-soft);color:var(--color-success-accent);}
.mtbadge--light.b-danger{background:var(--color-danger-soft);color:var(--color-danger);}
.mtbadge--light.b-warning{background:var(--color-warning-soft);color:var(--color-warning-accent);}
.mtbadge--light.b-info{background:var(--color-info-soft);color:var(--color-info);}
.mtbadge--light.b-secondary,.mtbadge--light.b-dark{background:var(--color-grey-100);color:var(--text-body);}
.mtbadge--light.b-accent{background:var(--color-accent-soft);color:var(--color-accent-accent);}
/* outline */
.mtbadge--outline{background:transparent;box-shadow:inset 0 0 0 1px var(--border-strong);color:var(--text-body);}
.mtbadge--outline.b-primary{box-shadow:inset 0 0 0 1px var(--color-primary);color:var(--color-primary);}
.mtbadge--outline.b-success{box-shadow:inset 0 0 0 1px var(--color-success);color:var(--color-success-accent);}
.mtbadge--outline.b-danger{box-shadow:inset 0 0 0 1px var(--color-danger);color:var(--color-danger);}
`;

export function injectBadgeStyles() {
  if (typeof document === "undefined" || document.getElementById("mt-badge-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-badge-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

/** Status / category label. */
export function Badge({ children, variant = "light", color = "primary", size = "md", dot = false, pill = false, className = "", ...rest }) {
  React.useEffect(() => { injectBadgeStyles(); }, []);
  const cls = ["mtbadge", `mtbadge--${variant}`, `mtbadge--${size}`, `b-${color}`, pill ? "mtbadge--pill" : "", className].filter(Boolean).join(" ");
  return (
    <span className={cls} {...rest}>
      {dot && <span className="mtbadge__dot" />}
      {children}
    </span>
  );
}
