import * as React from "react";
/**
 * Drawer — right-side sliding panel for detail views and forms.
 *
 * @startingPoint section="Components" subtitle="Sağ çekmece — detay / form" viewport="560x600"
 */
export interface DrawerProps {
  open: boolean;
  onClose?: () => void;
  title?: React.ReactNode;
  subtitle?: React.ReactNode;
  size?: "sm" | "md" | "lg" | "xl";
  children?: React.ReactNode;
  footer?: React.ReactNode;
  closeOnScrim?: boolean;
}
export declare function Drawer(props: DrawerProps): JSX.Element | null;
