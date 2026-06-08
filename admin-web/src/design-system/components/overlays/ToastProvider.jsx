import React from "react";
import { Icon } from "../Icon/Icon.jsx";

const CSS = `
.mttoasts{position:fixed;top:18px;right:18px;z-index:1100;display:flex;flex-direction:column;gap:10px;
  width:340px;max-width:calc(100vw - 36px);pointer-events:none;}
.mttoast{pointer-events:auto;display:flex;align-items:flex-start;gap:11px;background:var(--surface-card);
  border:1px solid var(--border-default);border-left-width:3px;border-radius:var(--radius-md);
  box-shadow:var(--shadow-lg);padding:13px 14px;animation:mttoastIn .22s cubic-bezier(.2,.8,.3,1);}
@keyframes mttoastIn{from{opacity:0;transform:translateX(24px);}to{opacity:1;transform:none;}}
.mttoast--success{border-left-color:var(--color-success);}
.mttoast--error{border-left-color:var(--color-danger);}
.mttoast--warning{border-left-color:var(--color-warning);}
.mttoast--info{border-left-color:var(--color-primary);}
.mttoast__ic{flex:none;width:30px;height:30px;border-radius:8px;display:flex;align-items:center;justify-content:center;}
.mttoast--success .mttoast__ic{background:var(--color-success-soft);}
.mttoast--error .mttoast__ic{background:var(--color-danger-soft);}
.mttoast--warning .mttoast__ic{background:var(--color-warning-soft);}
.mttoast--info .mttoast__ic{background:var(--color-primary-soft);}
.mttoast__tx{flex:1;min-width:0;}
.mttoast__t{font:var(--fw-semibold) 13px/1.35 var(--font-sans);color:var(--text-heading);}
.mttoast__d{font:var(--fw-regular) 12px/1.45 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.mttoast__x{appearance:none;border:0;background:none;cursor:pointer;color:var(--text-placeholder);padding:2px;border-radius:6px;flex:none;}
.mttoast__x:hover{background:var(--color-grey-100);color:var(--text-heading);}
`;

const TYPE_ICON = { success: "check-circle", error: "cross-circle", warning: "shield-search", info: "message-notif" };
const TYPE_COLOR = { success: "var(--color-success)", error: "var(--color-danger)", warning: "var(--color-warning-accent)", info: "var(--color-primary)" };

const ToastCtx = React.createContext({ push: () => {} });

/** Hook returning push(message | {title, description, type, duration}). */
export function useToast() { return React.useContext(ToastCtx).push; }

/** Wrap the app once; renders the top-right toast stack and provides useToast(). */
export function ToastProvider({ children }) {
  React.useEffect(() => {
    if (typeof document !== "undefined" && !document.getElementById("mt-toast-styles")) {
      const el = document.createElement("style"); el.id = "mt-toast-styles"; el.textContent = CSS; document.head.appendChild(el);
    }
  }, []);
  const [items, setItems] = React.useState([]);
  const push = React.useCallback((t) => {
    const id = Math.random().toString(36).slice(2);
    const item = { id, type: "info", duration: 3800, ...(typeof t === "string" ? { title: t } : t) };
    setItems((s) => [...s, item]);
    if (item.duration > 0) setTimeout(() => setItems((s) => s.filter((x) => x.id !== id)), item.duration);
  }, []);
  const dismiss = React.useCallback((id) => setItems((s) => s.filter((x) => x.id !== id)), []);
  return (
    <ToastCtx.Provider value={{ push }}>
      {children}
      <div className="mttoasts">
        {items.map((it) => (
          <div key={it.id} className={"mttoast mttoast--" + it.type}>
            <div className="mttoast__ic"><Icon name={TYPE_ICON[it.type]} size={17} color={TYPE_COLOR[it.type]} /></div>
            <div className="mttoast__tx">
              <div className="mttoast__t">{it.title}</div>
              {it.description && <div className="mttoast__d">{it.description}</div>}
            </div>
            <button className="mttoast__x" onClick={() => dismiss(it.id)} aria-label="Kapat"><Icon name="cross-circle" size={16} /></button>
          </div>
        ))}
      </div>
    </ToastCtx.Provider>
  );
}

/* Expose the hook as a static so consumers can reach it from the window
   namespace (lowercase exports are not attached to window.<Namespace>). */
ToastProvider.useToast = useToast;
