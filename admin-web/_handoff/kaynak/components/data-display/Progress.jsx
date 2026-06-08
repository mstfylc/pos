import React from "react";

const CSS = `
.mtprogress{width:100%;height:var(--mtprog-h,8px);background:var(--color-grey-200);border-radius:999px;overflow:hidden;}
.mtprogress__bar{height:100%;border-radius:999px;transition:width .3s var(--ease-default);}
.mtprogress__bar.p-primary{background:var(--color-primary);}
.mtprogress__bar.p-success{background:var(--color-success);}
.mtprogress__bar.p-danger{background:var(--color-danger);}
.mtprogress__bar.p-warning{background:var(--color-warning);}
.mtprogress__bar.p-info{background:var(--color-info);}
.mtprogress__bar.p-dark{background:var(--color-coal-900);}
`;

function inject() {
  if (typeof document === "undefined" || document.getElementById("mt-progress-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-progress-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

const H = { sm: 5, md: 8, lg: 12 };

/** Horizontal progress bar (0–100). */
export function Progress({ value = 0, color = "primary", size = "md", className = "", style = {}, ...rest }) {
  React.useEffect(() => { inject(); }, []);
  const h = typeof size === "number" ? size : H[size];
  return (
    <div className={"mtprogress " + className} style={{ "--mtprog-h": h + "px", ...style }} role="progressbar" aria-valuenow={value} aria-valuemin={0} aria-valuemax={100} {...rest}>
      <div className={"mtprogress__bar p-" + color} style={{ width: Math.max(0, Math.min(100, value)) + "%" }} />
    </div>
  );
}
