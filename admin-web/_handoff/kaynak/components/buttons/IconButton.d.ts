import * as React from "react";
import { IconName } from "../Icon/Icon";
import { ButtonVariant, ButtonColor, ButtonSize } from "./Button";

/**
 * Square, single-icon button for toolbars, table actions and the app header.
 */
export interface IconButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
  /** Icon name (required) */
  icon: IconName;
  /** Fill style. Default "ghost" */
  variant?: ButtonVariant;
  /** Semantic color. Default "secondary" */
  color?: ButtonColor;
  /** Size. Default "md" */
  size?: ButtonSize;
  /** Fully rounded (circular) */
  rounded?: boolean;
  /** Accessible label */
  "aria-label"?: string;
}

export function IconButton(props: IconButtonProps): JSX.Element;
