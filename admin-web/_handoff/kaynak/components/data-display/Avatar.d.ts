import * as React from "react";
export type AvatarSize = "xs" | "sm" | "md" | "lg" | "xl" | number;
export type AvatarStatus = "online" | "busy" | "away" | "offline";

/**
 * User avatar — photo `src`, or auto-colored initials from `name`.
 * @startingPoint section="Components" subtitle="Avatar, badge, tag, progress" viewport="700x220"
 */
export interface AvatarProps extends React.HTMLAttributes<HTMLSpanElement> {
  src?: string;
  name?: string;
  size?: AvatarSize;
  status?: AvatarStatus;
  ring?: boolean;
}
export function Avatar(props: AvatarProps): JSX.Element;

export interface AvatarGroupProps {
  people: AvatarProps[];
  size?: AvatarSize;
  max?: number;
  className?: string;
}
export function AvatarGroup(props: AvatarGroupProps): JSX.Element;
