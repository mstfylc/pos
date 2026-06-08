import React from "react";
import { Icon } from "../Icon/Icon.jsx";
import { injectFormStyles } from "./Input.jsx";

/** Multi-line text input. */
export function Textarea({ label, hint, error, required = false, id, rows = 4, className = "", ...rest }) {
  React.useEffect(() => { injectFormStyles(); }, []);
  const fid = id || (label ? "mt-" + label.replace(/\s+/g, "-").toLowerCase() : undefined);
  const ta = (
    <textarea id={fid} rows={rows} className={"mtinput" + (error ? " mtinput--err" : "") + (className ? " " + className : "")} aria-invalid={!!error} {...rest} />
  );
  if (!label && !hint && !error) return ta;
  return (
    <div className="mtfield">
      {label && <label className="mtfield__label" htmlFor={fid}>{label}{required && <span className="req">*</span>}</label>}
      {ta}
      {(error || hint) && <span className={"mtfield__hint" + (error ? " err" : "")}>{error || hint}</span>}
    </div>
  );
}

/** Native select styled as a Metronic field, with chevron affordance. */
export function Select({ label, hint, error, required = false, size = "md", id, children, className = "", ...rest }) {
  React.useEffect(() => { injectFormStyles(); }, []);
  const fid = id || (label ? "mt-" + label.replace(/\s+/g, "-").toLowerCase() : undefined);
  const field = (
    <div className="mtinput-wrap mtselect-wrap">
      <select id={fid} className={["mtinput", `mtinput--${size}`, error ? "mtinput--err" : "", className].filter(Boolean).join(" ")} {...rest}>
        {children}
      </select>
      <Icon className="trail" name="chevron-down" size={16} />
    </div>
  );
  if (!label && !hint && !error) return field;
  return (
    <div className="mtfield">
      {label && <label className="mtfield__label" htmlFor={fid}>{label}{required && <span className="req">*</span>}</label>}
      {field}
      {(error || hint) && <span className={"mtfield__hint" + (error ? " err" : "")}>{error || hint}</span>}
    </div>
  );
}
