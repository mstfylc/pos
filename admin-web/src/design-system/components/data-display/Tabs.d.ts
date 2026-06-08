export interface TabItem {
  id: string;
  label: React.ReactNode;
  /** Optional count pill */
  count?: number;
}
import * as React from "react";
export interface TabsProps {
  tabs: TabItem[];
  value?: string;
  defaultValue?: string;
  onChange?: (id: string) => void;
  variant?: "underline" | "pills";
  className?: string;
}
export function Tabs(props: TabsProps): JSX.Element;
