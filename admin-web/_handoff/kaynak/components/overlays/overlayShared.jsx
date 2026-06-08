import React from "react";

/* Shared overlay styles + helpers for Modal and Drawer. Not a DS component
   (no .d.ts) — internal module imported by Modal.jsx / Drawer.jsx. */

const CSS = `
.mtov{position:fixed;inset:0;z-index:1000;display:flex;}
.mtov__scrim{position:absolute;inset:0;background:rgba(15,23,42,.46);backdrop-filter:blur(1.5px);animation:mtovFade .18s ease;}
@keyframes mtovFade{from{opacity:0;}to{opacity:1;}}
.mtmodal{position:relative;margin:auto;background:var(--surface-card);border-radius:16px;
  box-shadow:0 24px 64px rgba(15,23,42,.24);width:100%;display:flex;flex-direction:column;
  max-height:calc(100vh - 48px);animation:mtmodalIn .2s cubic-bezier(.2,.8,.3,1);overflow:hidden;}
@keyframes mtmodalIn{from{opacity:0;transform:translateY(12px) scale(.98);}to{opacity:1;transform:none;}}
.mtmodal--sm{max-width:420px;} .mtmodal--md{max-width:560px;} .mtmodal--lg{max-width:760px;}
.mtmodal__hd{display:flex;align-items:flex-start;gap:14px;padding:22px 24px 0;}
.mtmodal__hd-ic{width:44px;height:44px;border-radius:var(--radius-md);flex:none;display:flex;align-items:center;justify-content:center;}
.mtmodal__hd-tx{flex:1;min-width:0;}
.mtmodal__title{font:var(--fw-bold) 17px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.mtmodal__sub{font:var(--fw-regular) 13px/1.5 var(--font-sans);color:var(--text-muted);margin-top:4px;}
.mtmodal__x{appearance:none;border:0;background:none;cursor:pointer;color:var(--text-placeholder);padding:5px;border-radius:8px;flex:none;}
.mtmodal__x:hover{background:var(--color-grey-100);color:var(--text-heading);}
.mtmodal__body{padding:18px 24px 4px;overflow-y:auto;}
.mtmodal__foot{display:flex;align-items:center;justify-content:flex-end;gap:10px;padding:18px 24px 22px;}
.mtov--drawer{justify-content:flex-end;}
.mtdrawer{position:relative;height:100%;background:var(--surface-card);box-shadow:-12px 0 48px rgba(15,23,42,.16);
  display:flex;flex-direction:column;width:100%;animation:mtdrawerIn .24s cubic-bezier(.2,.8,.3,1);}
@keyframes mtdrawerIn{from{transform:translateX(28px);opacity:.6;}to{transform:none;opacity:1;}}
.mtdrawer--sm{max-width:400px;} .mtdrawer--md{max-width:520px;} .mtdrawer--lg{max-width:720px;} .mtdrawer--xl{max-width:920px;}
.mtdrawer__hd{display:flex;align-items:center;gap:12px;padding:18px 22px;border-bottom:1px solid var(--border-default);flex:none;}
.mtdrawer__hd-tx{flex:1;min-width:0;}
.mtdrawer__title{font:var(--fw-bold) 16px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.mtdrawer__sub{font:var(--fw-regular) 12.5px/1.4 var(--font-sans);color:var(--text-muted);margin-top:3px;}
.mtdrawer__x{appearance:none;border:0;background:var(--color-grey-100);cursor:pointer;color:var(--text-body);
  width:34px;height:34px;border-radius:9px;display:flex;align-items:center;justify-content:center;flex:none;transition:background .12s;}
.mtdrawer__x:hover{background:var(--color-grey-200);}
.mtdrawer__body{flex:1;overflow-y:auto;padding:22px;}
.mtdrawer__foot{display:flex;align-items:center;gap:10px;padding:16px 22px;border-top:1px solid var(--border-default);flex:none;background:var(--surface-card);}
`;

export function injectOverlayStyles() {
  if (typeof document === "undefined" || document.getElementById("mt-overlay-styles")) return;
  const el = document.createElement("style"); el.id = "mt-overlay-styles"; el.textContent = CSS; document.head.appendChild(el);
}

export function useEscClose(open, onClose) {
  React.useEffect(() => {
    if (!open) return;
    function onKey(e) { if (e.key === "Escape" && onClose) onClose(); }
    document.addEventListener("keydown", onKey);
    const prev = document.body.style.overflow; document.body.style.overflow = "hidden";
    return () => { document.removeEventListener("keydown", onKey); document.body.style.overflow = prev; };
  }, [open, onClose]);
}

export const TONE_BG = {
  primary: ["var(--color-primary-soft)", "var(--color-primary)"],
  danger:  ["var(--color-danger-soft)", "var(--color-danger)"],
  warning: ["var(--color-warning-soft)", "var(--color-warning-accent)"],
  success: ["var(--color-success-soft)", "var(--color-success)"],
  accent:  ["var(--color-accent-soft)", "var(--color-accent)"],
};
