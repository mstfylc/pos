import React from "react";
import { Icon } from "../Icon/Icon.jsx";
import { injectOverlayStyles, useEscClose } from "./overlayShared.jsx";

/** Right-side sliding drawer for detail views and forms. */
export function Drawer({ open, onClose, title, subtitle, size = "md", children, footer, closeOnScrim = true }) {
  React.useEffect(() => { injectOverlayStyles(); }, []);
  useEscClose(open, onClose);
  if (!open) return null;
  return (
    <div className="mtov mtov--drawer" role="dialog" aria-modal="true">
      <div className="mtov__scrim" onClick={closeOnScrim ? onClose : undefined} />
      <div className={"mtdrawer mtdrawer--" + size}>
        <div className="mtdrawer__hd">
          <div className="mtdrawer__hd-tx">
            {title && <div className="mtdrawer__title">{title}</div>}
            {subtitle && <div className="mtdrawer__sub">{subtitle}</div>}
          </div>
          {onClose && <button className="mtdrawer__x" onClick={onClose} aria-label="Kapat"><Icon name="cross-circle" size={18} /></button>}
        </div>
        <div className="mtdrawer__body">{children}</div>
        {footer && <div className="mtdrawer__foot">{footer}</div>}
      </div>
    </div>
  );
}
