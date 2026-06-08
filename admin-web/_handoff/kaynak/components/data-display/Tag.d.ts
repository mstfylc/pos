import * as React from "react";
import { IconName } from "../Icon/Icon";
export interface TagProps extends React.HTMLAttributes<HTMLSpanElement> {
  icon?: IconName;
  /** Show a remove (×) button and handle click */
  onRemove?: () => void;
}
export function Tag(props: TagProps): JSX.Element;

export interface SeparatorProps {
  orientation?: "horizontal" | "vertical";
  className?: string;
  style?: React.CSSProperties;
}
export function Separator(props: SeparatorProps): JSX.Element;
