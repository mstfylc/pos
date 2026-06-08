import * as React from "react";
export type BadgeColor = "primary" | "accent" | "secondary" | "success" | "danger" | "warning" | "info" | "dark";
export interface BadgeProps extends React.HTMLAttributes<HTMLSpanElement> {
  variant?: "solid" | "light" | "outline";
  color?: BadgeColor;
  size?: "sm" | "md" | "lg";
  /** Leading status dot */
  dot?: boolean;
  /** Fully rounded */
  pill?: boolean;
}
export function Badge(props: BadgeProps): JSX.Element;
export function injectBadgeStyles(): void;
