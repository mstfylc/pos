import * as React from "react";
import { IconName } from "../Icon/Icon";

export type ButtonVariant = "solid" | "light" | "outline" | "ghost" | "link";
export type ButtonColor = "primary" | "accent" | "secondary" | "success" | "danger" | "warning" | "info" | "dark";
export type ButtonSize = "sm" | "md" | "lg";

/**
 * Primary action control. Metronic button system: solid / light (soft tint) /
 * outline / ghost / link, in every semantic color and three sizes.
 *
 * @startingPoint section="Components" subtitle="Button — all variants & colors" viewport="700x320"
 */
export interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  /** Fill style. Default "solid" */
  variant?: ButtonVariant;
  /** Semantic color. Default "primary" */
  color?: ButtonColor;
  /** Size. Default "md" */
  size?: ButtonSize;
  /** Leading icon name */
  iconStart?: IconName;
  /** Trailing icon name */
  iconEnd?: IconName;
  /** Stretch to container width */
  fullWidth?: boolean;
  /** Render as another element (e.g. "a") */
  as?: "button" | "a";
}

export function Button(props: ButtonProps): JSX.Element;
export function injectButtonStyles(): void;
