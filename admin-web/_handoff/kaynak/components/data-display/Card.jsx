import React from "react";

const CSS = `
.mtcard{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);
  box-shadow:var(--shadow-sm);overflow:hidden;}
.mtcard--flush{box-shadow:none;}
.mtcard__header{display:flex;align-items:center;justify-content:space-between;gap:12px;
  padding:16px 20px;border-bottom:1px solid var(--border-default);min-height:60px;box-sizing:border-box;}
.mtcard__title{font:var(--fw-semibold) 15px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);margin:0;}
.mtcard__subtitle{font:var(--fw-regular) 12px/1.4 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.mtcard__toolbar{display:flex;align-items:center;gap:8px;}
.mtcard__body{padding:20px;}
.mtcard__footer{display:flex;align-items:center;gap:10px;padding:16px 20px;border-top:1px solid var(--border-default);}
`;

function inject() {
  if (typeof document === "undefined" || document.getElementById("mt-card-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-card-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

/** Card container. Compose with CardHeader / CardBody / CardFooter. */
export function Card({ children, flush = false, className = "", style = {}, ...rest }) {
  React.useEffect(() => { inject(); }, []);
  return <div className={"mtcard " + (flush ? "mtcard--flush " : "") + className} style={style} {...rest}>{children}</div>;
}

export function CardHeader({ title, subtitle, toolbar, children, className = "", ...rest }) {
  return (
    <div className={"mtcard__header " + className} {...rest}>
      {children || (
        <div>
          {title && <h3 className="mtcard__title">{title}</h3>}
          {subtitle && <div className="mtcard__subtitle">{subtitle}</div>}
        </div>
      )}
      {toolbar && <div className="mtcard__toolbar">{toolbar}</div>}
    </div>
  );
}

export function CardBody({ children, className = "", style = {}, ...rest }) {
  return <div className={"mtcard__body " + className} style={style} {...rest}>{children}</div>;
}

export function CardFooter({ children, className = "", ...rest }) {
  return <div className={"mtcard__footer " + className} {...rest}>{children}</div>;
}
