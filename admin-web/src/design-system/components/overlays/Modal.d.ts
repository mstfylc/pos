import * as React from "react";
/**
 * Modal — centered dialog with optional icon, title, subtitle and footer.
 * Closes on scrim click and Escape. Keep a single primary action in the footer.
 *
 * @startingPoint section="Components" subtitle="Modal diyalog — onay / form" viewport="640x440"
 */
export interface ModalProps {
  open: boolean;
  onClose?: () => void;
  title?: React.ReactNode;
  subtitle?: React.ReactNode;
  icon?: string;
  tone?: "primary" | "danger" | "warning" | "success" | "accent";
  size?: "sm" | "md" | "lg";
  children?: React.ReactNode;
  footer?: React.ReactNode;
  closeOnScrim?: boolean;
}
export declare function Modal(props: ModalProps): JSX.Element | null;
