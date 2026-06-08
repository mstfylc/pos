import * as React from "react";

export type IconName =
  | "home" | "profile-circle" | "setting-2" | "setting-4" | "messages" | "message-notif"
  | "rocket" | "people" | "user" | "user-tick" | "user-edit" | "chart-line-up"
  | "chart-pie-simple" | "category" | "calendar" | "folder" | "files" | "notepad"
  | "notepad-edit" | "notepad-bookmark" | "filter" | "magnifier" | "plus-squared"
  | "minus-squared" | "check-circle" | "cross-circle" | "share" | "time" | "trash"
  | "key" | "price-tag" | "handcart" | "verify" | "element-11" | "more" | "menu"
  | "dots-square" | "down-square" | "chevron-down" | "chevron-up" | "chevron-left"
  | "chevron-right" | "heart" | "star" | "like" | "sort" | "exit-right"
  | "shield-search" | "abstract";

/**
 * KeenIcon rendered inline (inherits `currentColor`). The full Metronic
 * KeenIcons outline set, themed by the CSS `color` of any ancestor.
 *
 * @startingPoint section="Foundations" subtitle="KeenIcons icon set" viewport="700x230"
 */
export interface IconProps extends React.HTMLAttributes<HTMLSpanElement> {
  /** Icon name from the KeenIcons set */
  name: IconName;
  /** Pixel size (number) or any CSS length. Default 20 */
  size?: number | string;
  /** Override color; defaults to currentColor */
  color?: string;
}

export function Icon(props: IconProps): JSX.Element;
export const MT_ICONS: Record<string, string>;
export const ICON_NAMES: string[];
