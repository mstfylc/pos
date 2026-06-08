import React from "react";
import { Icon } from "../Icon/Icon.jsx";
import { injectOverlayStyles, useEscClose, TONE_BG } from "./overlayShared.jsx";

/** Centered modal dialog with optional icon, title, subtitle and footer actions. */
export function Modal({ open, onClose, title, subtitle, icon, tone = "primary", size = "md", children, footer, closeOnScrim = true }) {
  React.useEffect(() => { injectOverlayStyles(); }, []);
  useEscClose(open, onClose);
  if (!open) return null;
  const [bg, fg] = TONE_BG[tone] || TONE_BG.primary;
  return (
    <div className="mtov" role="dialog" aria-modal="true">
      <div className="mtov__scrim" onClick={closeOnScrim ? onClose : undefined} />
      <div className={"mtmodal mtmodal--" + size}>
        {(title || icon) && (
          <div className="mtmodal__hd">
            {icon && <div className="mtmodal__hd-ic" style={{ background: bg }}><Icon name={icon} size={22} color={fg} /></div>}
            <div className="mtmodal__hd-tx">
              {title && <div className="mtmodal__title">{title}</div>}
              {subtitle && <div className="mtmodal__sub">{subtitle}</div>}
            </div>
            {onClose && <button className="mtmodal__x" onClick={onClose} aria-label="Kapat"><Icon name="cross-circle" size={19} /></button>}
          </div>
        )}
        {children != null && <div className="mtmodal__body">{children}</div>}
        {footer && <div className="mtmodal__foot">{footer}</div>}
      </div>
    </div>
  );
}
