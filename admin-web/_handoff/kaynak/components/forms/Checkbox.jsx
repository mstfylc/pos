import React from "react";
import { Icon } from "../Icon/Icon.jsx";

const CSS = `
.mtchoice{display:inline-flex;align-items:center;gap:9px;cursor:pointer;font:var(--fw-medium) 13px/1.3 var(--font-sans);color:var(--text-body);user-select:none;}
.mtchoice input{position:absolute;opacity:0;width:0;height:0;}
.mtbox{width:18px;height:18px;flex:none;border:1.5px solid var(--border-strong);border-radius:5px;background:var(--surface-card);
  display:inline-flex;align-items:center;justify-content:center;transition:all .15s;color:#fff;}
.mtbox .mt-icon{opacity:0;transform:scale(.6);transition:all .12s;}
.mtchoice:hover .mtbox{border-color:var(--color-primary);}
.mtchoice input:checked + .mtbox{background:var(--color-primary);border-color:var(--color-primary);}
.mtchoice input:checked + .mtbox .mt-icon{opacity:1;transform:scale(1);}
.mtchoice input:focus-visible + .mtbox{box-shadow:0 0 0 3px var(--ring-primary);}
.mtchoice input:disabled ~ *{opacity:.5;}
.mtchoice--radio .mtbox{border-radius:50%;}
.mtradiodot{width:8px;height:8px;border-radius:50%;background:#fff;opacity:0;transform:scale(.4);transition:all .12s;}
.mtchoice input:checked + .mtbox .mtradiodot{opacity:1;transform:scale(1);}
.mtswitch{display:inline-flex;align-items:center;gap:10px;cursor:pointer;font:var(--fw-medium) 13px/1.3 var(--font-sans);color:var(--text-body);user-select:none;}
.mtswitch input{position:absolute;opacity:0;width:0;height:0;}
.mttrack{width:38px;height:22px;flex:none;border-radius:999px;background:var(--color-grey-300);position:relative;transition:background .18s;}
.mtknob{position:absolute;top:2px;left:2px;width:18px;height:18px;border-radius:50%;background:#fff;box-shadow:0 1px 3px rgba(0,0,0,.2);transition:transform .18s;}
.mtswitch input:checked + .mttrack{background:var(--color-primary);}
.mtswitch input:checked + .mttrack .mtknob{transform:translateX(16px);}
.mtswitch input:focus-visible + .mttrack{box-shadow:0 0 0 3px var(--ring-primary);}
.mtswitch input:disabled ~ *{opacity:.5;}
`;

export function injectChoiceStyles() {
  if (typeof document === "undefined" || document.getElementById("mt-choice-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-choice-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

/** Checkbox with label. */
export function Checkbox({ label, className = "", ...rest }) {
  React.useEffect(() => { injectChoiceStyles(); }, []);
  return (
    <label className={"mtchoice " + className}>
      <input type="checkbox" {...rest} />
      <span className="mtbox">
        <span className="mt-icon" style={{ width: 12, height: 12 }} dangerouslySetInnerHTML={{ __html: '<svg viewBox="0 0 12 10" fill="none" style="width:100%;height:100%;display:block"><path d="M1 5.2 4.3 8.5 11 1.5" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/></svg>' }} />
      </span>
      {label && <span>{label}</span>}
    </label>
  );
}
