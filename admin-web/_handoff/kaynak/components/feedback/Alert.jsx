import React from "react";
import { Icon } from "../Icon/Icon.jsx";

const CSS = `
.mtalert{display:flex;align-items:flex-start;gap:12px;padding:14px 16px;border-radius:var(--radius-lg);
  font-family:var(--font-sans);border:1px solid transparent;}
.mtalert__icon{flex:none;margin-top:1px;}
.mtalert__content{flex:1;display:flex;flex-direction:column;gap:2px;}
.mtalert__title{font-weight:var(--fw-semibold);font-size:13px;letter-spacing:var(--ls-tight);color:var(--text-heading);}
.mtalert__text{font-weight:var(--fw-regular);font-size:12.5px;line-height:1.5;color:var(--text-body);}
.mtalert__close{flex:none;background:none;border:0;cursor:pointer;color:var(--text-muted);padding:2px;border-radius:var(--radius-xs);line-height:0;}
.mtalert__close:hover{color:var(--text-heading);}
.mtalert--solid .mtalert__title,.mtalert--solid .mtalert__text,.mtalert--solid .mtalert__close{color:#fff;}
.mtalert--light.a-primary{background:var(--color-primary-soft);border-color:transparent;color:var(--color-primary);}
.mtalert--light.a-success{background:var(--color-success-soft);color:var(--color-success-accent);}
.mtalert--light.a-danger{background:var(--color-danger-soft);color:var(--color-danger);}
.mtalert--light.a-warning{background:var(--color-warning-soft);color:var(--color-warning-accent);}
.mtalert--light.a-info{background:var(--color-info-soft);color:var(--color-info);}
.mtalert--solid.a-primary{background:var(--color-primary);}
.mtalert--solid.a-success{background:var(--color-success);}
.mtalert--solid.a-danger{background:var(--color-danger);}
.mtalert--solid.a-warning{background:var(--color-warning);}
.mtalert--solid.a-info{background:var(--color-info);}
.mtalert--solid .mtalert__icon{color:#fff;}
.mtalert--outline{background:var(--surface-card);}
.mtalert--outline.a-primary{border-color:var(--color-primary);}
.mtalert--outline.a-danger{border-color:var(--color-danger);}
`;

function inject() {
  if (typeof document === "undefined" || document.getElementById("mt-alert-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-alert-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

const DEFAULT_ICON = { primary: "shield-search", success: "check-circle", danger: "cross-circle", warning: "shield-search", info: "shield-search" };

/** Inline contextual message banner. */
export function Alert({ children, title, color = "primary", variant = "light", icon, onClose, className = "", ...rest }) {
  React.useEffect(() => { inject(); }, []);
  const ic = icon === undefined ? DEFAULT_ICON[color] : icon;
  return (
    <div className={["mtalert", `mtalert--${variant}`, `a-${color}`, className].filter(Boolean).join(" ")} role="alert" {...rest}>
      {ic && <Icon className="mtalert__icon" name={ic} size={18} />}
      <div className="mtalert__content">
        {title && <div className="mtalert__title">{title}</div>}
        {children && <div className="mtalert__text">{children}</div>}
      </div>
      {onClose && (
        <button className="mtalert__close" aria-label="Dismiss" onClick={onClose}>
          <span className="mt-icon" style={{ width: 14, height: 14 }} dangerouslySetInnerHTML={{ __html: '<svg viewBox="0 0 12 12" fill="none" style="width:100%;height:100%;display:block"><path d="M1.5 1.5l9 9M10.5 1.5l-9 9" stroke="currentColor" stroke-width="1.6" stroke-linecap="round"/></svg>' }} />
        </button>
      )}
    </div>
  );
}
