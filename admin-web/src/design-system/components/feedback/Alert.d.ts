import * as React from "react";
import { IconName } from "../Icon/Icon";

/**
 * Inline contextual banner.
 * @startingPoint section="Components" subtitle="Alert banners — all colors" viewport="700x240"
 */
export interface AlertProps extends React.HTMLAttributes<HTMLDivElement> {
  title?: React.ReactNode;
  color?: "primary" | "success" | "danger" | "warning" | "info";
  variant?: "light" | "solid" | "outline";
  /** KeenIcon name, or null to hide */
  icon?: IconName | null;
  /** Show a dismiss button */
  onClose?: () => void;
}
export function Alert(props: AlertProps): JSX.Element;
