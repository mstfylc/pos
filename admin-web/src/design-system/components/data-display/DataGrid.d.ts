import * as React from "react";

export interface DataGridColumn<Row = any> {
  key: string;
  header: React.ReactNode;
  width?: number | string;
  align?: "left" | "right" | "center";
  sortable?: boolean;
  className?: string;
  render?: (row: Row) => React.ReactNode;
}
export interface DataGridEmpty {
  icon?: string;
  title?: string;
  subtitle?: string;
  action?: React.ReactNode;
}
/**
 * DataGrid — table with sort, pagination and the four required states
 * (loading / empty / error / full). Server-side feel: pass page, pageSize,
 * total and handle onPageChange / onSortChange.
 *
 * @startingPoint section="Components" subtitle="Veri tablosu — sıralama, sayfalama, 4 durum" viewport="900x520"
 */
export interface DataGridProps<Row = any> {
  columns: DataGridColumn<Row>[];
  rows: Row[];
  loading?: boolean;
  error?: string | boolean | null;
  onRetry?: () => void;
  empty?: DataGridEmpty;
  sort?: { key: string; dir: "asc" | "desc" };
  onSortChange?: (s: { key: string; dir: "asc" | "desc" }) => void;
  page?: number;
  pageSize?: number;
  total?: number;
  onPageChange?: (page: number) => void;
  onRowClick?: (row: Row) => void;
  rowKey?: (row: Row) => string | number;
  footerNote?: React.ReactNode;
  dense?: boolean;
  className?: string;
}
export declare function DataGrid<Row = any>(props: DataGridProps<Row>): JSX.Element;
