import React from "react";
import { Icon } from "../Icon/Icon.jsx";

/* Inject Metronic button styles once */
const CSS = `
.mtbtn{display:inline-flex;align-items:center;justify-content:center;gap:var(--mtbtn-gap,6px);
  font-family:var(--font-sans);font-weight:var(--fw-semibold);letter-spacing:var(--ls-tight);
  border:1px solid transparent;border-radius:var(--radius-sm);cursor:pointer;white-space:nowrap;
  transition:background-color .15s,border-color .15s,color .15s,box-shadow .15s;text-decoration:none;
  user-select:none;-webkit-appearance:none;}
.mtbtn:focus-visible{outline:none;box-shadow:0 0 0 3px var(--ring-primary);}
.mtbtn:disabled,.mtbtn[aria-disabled="true"]{opacity:.5;pointer-events:none;}
.mtbtn--sm{height:30px;padding:0 12px;font-size:12px;--mtbtn-gap:6px;}
.mtbtn--md{height:36px;padding:0 14px;font-size:13px;--mtbtn-gap:6px;}
.mtbtn--lg{height:44px;padding:0 18px;font-size:14px;--mtbtn-gap:8px;}
.mtbtn--full{width:100%;}
.mtbtn--icon.mtbtn--sm{width:30px;padding:0;}
.mtbtn--icon.mtbtn--md{width:36px;padding:0;}
.mtbtn--icon.mtbtn--lg{width:44px;padding:0;}
/* SOLID */
.mtbtn--solid{color:#fff;}
.mtbtn--solid.c-primary{background:var(--color-primary);}
.mtbtn--solid.c-primary:hover{background:var(--color-primary-active);}
.mtbtn--solid.c-success{background:var(--color-success);}
.mtbtn--solid.c-success:hover{background:var(--color-success-active);}
.mtbtn--solid.c-danger{background:var(--color-danger);}
.mtbtn--solid.c-danger:hover{background:var(--color-danger-active);}
.mtbtn--solid.c-warning{background:var(--color-warning);color:var(--color-coal-900);}
.mtbtn--solid.c-warning:hover{background:var(--color-warning-active);}
.mtbtn--solid.c-info{background:var(--color-info);}
.mtbtn--solid.c-info:hover{background:var(--color-info-active);}
.mtbtn--solid.c-dark{background:var(--color-coal-900);}
.mtbtn--solid.c-dark:hover{background:#000;}
.mtbtn--solid.c-secondary{background:var(--color-grey-100);color:var(--text-heading);}
.mtbtn--solid.c-secondary:hover{background:var(--color-grey-200);}
.mtbtn--solid.c-accent{background:var(--color-accent);color:#fff;}
.mtbtn--solid.c-accent:hover{background:var(--color-accent-active);}
/* LIGHT (soft tint) */
.mtbtn--light.c-primary{background:var(--color-primary-soft);color:var(--color-primary);}
.mtbtn--light.c-primary:hover{background:var(--color-primary);color:#fff;}
.mtbtn--light.c-success{background:var(--color-success-soft);color:var(--color-success-accent);}
.mtbtn--light.c-success:hover{background:var(--color-success);color:#fff;}
.mtbtn--light.c-danger{background:var(--color-danger-soft);color:var(--color-danger);}
.mtbtn--light.c-danger:hover{background:var(--color-danger);color:#fff;}
.mtbtn--light.c-warning{background:var(--color-warning-soft);color:var(--color-warning-accent);}
.mtbtn--light.c-warning:hover{background:var(--color-warning);color:var(--color-coal-900);}
.mtbtn--light.c-info{background:var(--color-info-soft);color:var(--color-info);}
.mtbtn--light.c-info:hover{background:var(--color-info);color:#fff;}
.mtbtn--light.c-secondary,.mtbtn--light.c-dark{background:var(--color-grey-100);color:var(--text-heading);}
.mtbtn--light.c-secondary:hover,.mtbtn--light.c-dark:hover{background:var(--color-grey-200);}
.mtbtn--light.c-accent{background:var(--color-accent-soft);color:var(--color-accent-accent);}
.mtbtn--light.c-accent:hover{background:var(--color-accent);color:#fff;}
/* OUTLINE */
.mtbtn--outline{background:transparent;}
.mtbtn--outline.c-primary{border-color:var(--border-strong);color:var(--text-heading);}
.mtbtn--outline.c-primary:hover{border-color:var(--color-primary);color:var(--color-primary);background:var(--color-primary-soft);}
.mtbtn--outline.c-success{border-color:var(--color-success);color:var(--color-success-accent);}
.mtbtn--outline.c-success:hover{background:var(--color-success);color:#fff;border-color:var(--color-success);}
.mtbtn--outline.c-danger{border-color:var(--color-danger);color:var(--color-danger);}
.mtbtn--outline.c-danger:hover{background:var(--color-danger);color:#fff;}
.mtbtn--outline.c-dark{border-color:var(--color-coal-900);color:var(--color-coal-900);}
.mtbtn--outline.c-dark:hover{background:var(--color-coal-900);color:#fff;}
.mtbtn--outline.c-accent{border-color:var(--color-accent);color:var(--color-accent-accent);}
.mtbtn--outline.c-accent:hover{background:var(--color-accent);color:#fff;border-color:var(--color-accent);}
/* GHOST */
.mtbtn--ghost{background:transparent;color:var(--text-body);}
.mtbtn--ghost:hover{background:var(--color-grey-100);color:var(--text-heading);}
.mtbtn--ghost.c-primary{color:var(--color-primary);}
.mtbtn--ghost.c-primary:hover{background:var(--color-primary-soft);}
.mtbtn--ghost.c-danger{color:var(--color-danger);}
.mtbtn--ghost.c-danger:hover{background:var(--color-danger-soft);}
.mtbtn--ghost.c-accent{color:var(--color-accent-accent);}
.mtbtn--ghost.c-accent:hover{background:var(--color-accent-soft);}
/* LINK */
.mtbtn--link{background:transparent;height:auto!important;padding:0!important;border:0;color:var(--color-primary);}
.mtbtn--link:hover{color:var(--color-primary-active);text-decoration:none;}
`;

export function injectButtonStyles() {
  if (typeof document === "undefined" || document.getElementById("mt-button-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-button-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

function useStyles() {
  React.useEffect(() => { injectButtonStyles(); }, []);
}

const ICON_SIZE = { sm: 14, md: 16, lg: 18 };

/**
 * Button — the primary action control.
 */
export function Button({
  children,
  variant = "solid",
  color = "primary",
  size = "md",
  iconStart,
  iconEnd,
  fullWidth = false,
  disabled = false,
  as = "button",
  className = "",
  ...rest
}) {
  useStyles();
  const Tag = as;
  const cls = [
    "mtbtn",
    `mtbtn--${variant}`,
    `mtbtn--${size}`,
    `c-${color}`,
    fullWidth ? "mtbtn--full" : "",
    className,
  ].filter(Boolean).join(" ");
  const isz = ICON_SIZE[size];
  return (
    <Tag className={cls} disabled={Tag === "button" ? disabled : undefined} aria-disabled={disabled || undefined} {...rest}>
      {iconStart && <Icon name={iconStart} size={isz} />}
      {children}
      {iconEnd && <Icon name={iconEnd} size={isz} />}
    </Tag>
  );
}
