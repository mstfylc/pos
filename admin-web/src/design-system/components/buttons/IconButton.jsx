import React from "react";
import { Icon } from "../Icon/Icon.jsx";
import { injectButtonStyles } from "./Button.jsx";

/**
 * IconButton — a square button containing a single icon.
 * Reuses the Button stylesheet (mtbtn). Common for toolbars,
 * table row actions and the app header.
 */
export function IconButton({
  icon,
  variant = "ghost",
  color = "secondary",
  size = "md",
  disabled = false,
  rounded = false,
  className = "",
  "aria-label": ariaLabel,
  ...rest
}) {
  React.useEffect(() => { injectButtonStyles(); }, []);
  const cls = [
    "mtbtn",
    `mtbtn--${variant}`,
    `mtbtn--${size}`,
    "mtbtn--icon",
    `c-${color}`,
    className,
  ].filter(Boolean).join(" ");
  const isz = { sm: 16, md: 18, lg: 20 }[size];
  return (
    <button
      className={cls}
      disabled={disabled}
      aria-label={ariaLabel}
      style={rounded ? { borderRadius: "var(--radius-full)" } : undefined}
      {...rest}
    >
      <Icon name={icon} size={isz} />
    </button>
  );
}
