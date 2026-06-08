import * as React from "react";

/**
 * Semantic state pill with built-in Turkish status dictionary.
 * Pass a known `status` key (alindi, hazirlaniyor, tamamlandi, iptal, iade,
 * normal, esik-alti, tukendi, aktif, pasif, …) for automatic label + tone,
 * or override label/tone manually.
 *
 * @startingPoint section="Components" subtitle="Durum rozeti — sipariş/stok/genel" viewport="480x220"
 */
export interface StatusBadgeProps {
  status?: string;
  label?: string;
  tone?: "primary" | "accent" | "secondary" | "success" | "danger" | "warning" | "info" | "dark";
  size?: "sm" | "md" | "lg";
  solid?: boolean;
  className?: string;
}
export declare function StatusBadge(props: StatusBadgeProps): JSX.Element;
export declare const STATUS_MAP: Record<string, { label: string; tone: string }>;
