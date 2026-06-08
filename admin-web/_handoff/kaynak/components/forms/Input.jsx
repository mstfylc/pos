import React from "react";
import { Icon } from "../Icon/Icon.jsx";

const CSS = `
.mtfield{display:flex;flex-direction:column;gap:6px;}
.mtfield__label{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.mtfield__label .req{color:var(--color-danger);margin-left:2px;}
.mtfield__hint{font:var(--fw-regular) 12px/1.4 var(--font-sans);color:var(--text-muted);}
.mtfield__hint.err{color:var(--color-danger);}
.mtinput-wrap{position:relative;display:flex;align-items:center;}
.mtinput-wrap .mt-icon{position:absolute;color:var(--text-muted);pointer-events:none;}
.mtinput-wrap .mt-icon.lead{left:12px;}
.mtinput-wrap .mt-icon.trail{right:12px;}
.mtinput{width:100%;font-family:var(--font-sans);font-size:13px;font-weight:var(--fw-medium);color:var(--text-heading);
  background:var(--surface-card);border:1px solid var(--border-input);border-radius:var(--radius-sm);
  transition:border-color .15s,box-shadow .15s;outline:none;-webkit-appearance:none;box-sizing:border-box;}
.mtinput::placeholder{color:var(--text-placeholder);font-weight:var(--fw-regular);}
.mtinput:hover{border-color:var(--color-grey-400);}
.mtinput:focus{border-color:var(--color-primary);box-shadow:0 0 0 3px var(--ring-primary);}
.mtinput:disabled{background:var(--color-grey-100);color:var(--text-muted);cursor:not-allowed;}
.mtinput--sm{height:34px;padding:0 12px;font-size:12px;}
.mtinput--md{height:40px;padding:0 12px;}
.mtinput--lg{height:46px;padding:0 14px;font-size:14px;}
.mtinput--has-lead{padding-left:36px;}
.mtinput--has-trail{padding-right:36px;}
.mtinput--err{border-color:var(--color-danger);}
.mtinput--err:focus{box-shadow:0 0 0 3px var(--color-danger-transparent);}
textarea.mtinput{height:auto;padding:10px 12px;line-height:1.5;resize:vertical;min-height:84px;}
select.mtinput{cursor:pointer;background-image:none;padding-right:36px;}
.mtselect-wrap .mt-icon.trail{pointer-events:none;}
`;

export function injectFormStyles() {
  if (typeof document === "undefined" || document.getElementById("mt-form-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-form-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

/**
 * Text Input with optional label, hint, error and lead/trail icons.
 */
export function Input({
  label,
  hint,
  error,
  required = false,
  size = "md",
  iconLead,
  iconTrail,
  id,
  className = "",
  ...rest
}) {
  React.useEffect(() => { injectFormStyles(); }, []);
  const fid = id || (label ? "mt-" + label.replace(/\s+/g, "-").toLowerCase() : undefined);
  const cls = [
    "mtinput", `mtinput--${size}`,
    iconLead ? "mtinput--has-lead" : "",
    iconTrail ? "mtinput--has-trail" : "",
    error ? "mtinput--err" : "",
    className,
  ].filter(Boolean).join(" ");
  const input = (
    <div className="mtinput-wrap">
      {iconLead && <Icon className="lead" name={iconLead} size={16} />}
      <input id={fid} className={cls} aria-invalid={!!error} {...rest} />
      {iconTrail && <Icon className="trail" name={iconTrail} size={16} />}
    </div>
  );
  if (!label && !hint && !error) return input;
  return (
    <div className="mtfield">
      {label && <label className="mtfield__label" htmlFor={fid}>{label}{required && <span className="req">*</span>}</label>}
      {input}
      {(error || hint) && <span className={"mtfield__hint" + (error ? " err" : "")}>{error || hint}</span>}
    </div>
  );
}
