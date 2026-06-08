import * as React from "react";
export interface ToastInput {
  title: React.ReactNode;
  description?: React.ReactNode;
  type?: "success" | "error" | "warning" | "info";
  duration?: number;
}
/**
 * ToastProvider — wrap the app once; renders the top-right stack.
 * Use ToastProvider.useToast() (or the exported useToast) to push messages.
 *
 * @startingPoint section="Components" subtitle="Bildirim — toast yığını" viewport="420x320"
 */
export interface ToastProviderProps { children?: React.ReactNode; }
export declare function ToastProvider(props: ToastProviderProps): JSX.Element & {
  useToast(): (t: string | ToastInput) => void;
};
export declare function useToast(): (t: string | ToastInput) => void;
