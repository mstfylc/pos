import * as React from "react";
export interface ProgressProps extends React.HTMLAttributes<HTMLDivElement> {
  /** 0–100 */
  value?: number;
  color?: "primary" | "success" | "danger" | "warning" | "info" | "dark";
  size?: "sm" | "md" | "lg" | number;
}
export function Progress(props: ProgressProps): JSX.Element;
