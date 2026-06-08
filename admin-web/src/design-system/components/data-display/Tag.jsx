import React from "react";
import { Icon } from "../Icon/Icon.jsx";

const CSS = `
.mttag{display:inline-flex;align-items:center;gap:6px;height:26px;padding:0 4px 0 10px;border-radius:var(--radius-sm);
  background:var(--color-grey-100);border:1px solid var(--border-default);font:var(--fw-medium) 12px/1 var(--font-sans);
  color:var(--text-body);white-space:nowrap;}
.mttag--removable{padding-right:4px;}
.mttag:not(.mttag--removable){padding-right:10px;}
.mttag__x{display:inline-flex;align-items:center;justify-content:center;width:18px;height:18px;border-radius:var(--radius-xs);
  background:none;border:0;cursor:pointer;color:var(--text-muted);transition:all .12s;}
.mttag__x:hover{background:var(--color-grey-300);color:var(--text-heading);}
.mtseparator{border:0;background:var(--border-default);}
.mtseparator--h{height:1px;width:100%;margin:0;}
.mtseparator--v{width:1px;align-self:stretch;min-height:16px;margin:0;}
`;

function inject() {
  if (typeof document === "undefined" || document.getElementById("mt-tag-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-tag-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

/** Chip / token — selections, filters, keywords. Optional leading icon and remove button. */
export function Tag({ children, icon, onRemove, className = "", ...rest }) {
  React.useEffect(() => { inject(); }, []);
  return (
    <span className={"mttag " + (onRemove ? "mttag--removable " : "") + className} {...rest}>
      {icon && <Icon name={icon} size={13} />}
      <span>{children}</span>
      {onRemove && (
        <button type="button" className="mttag__x" aria-label="Remove" onClick={onRemove}>
          <span className="mt-icon" style={{ width: 10, height: 10 }} dangerouslySetInnerHTML={{ __html: '<svg viewBox="0 0 10 10" fill="none" style="width:100%;height:100%;display:block"><path d="M1 1l8 8M9 1l-8 8" stroke="currentColor" stroke-width="1.6" stroke-linecap="round"/></svg>' }} />
        </button>
      )}
    </span>
  );
}

/** Thin divider line. */
export function Separator({ orientation = "horizontal", className = "", style = {} }) {
  React.useEffect(() => { inject(); }, []);
  return <hr className={"mtseparator mtseparator--" + (orientation === "vertical" ? "v" : "h") + " " + className} style={style} />;
}
