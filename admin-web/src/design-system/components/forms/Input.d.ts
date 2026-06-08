import * as React from "react";
import { IconName } from "../Icon/Icon";

export type FieldSize = "sm" | "md" | "lg";

/**
 * Text input with label, hint, error and optional lead/trail icons.
 *
 * @startingPoint section="Components" subtitle="Form fields — inputs, select, toggles" viewport="700x340"
 */
export interface InputProps extends React.InputHTMLAttributes<HTMLInputElement> {
  label?: string;
  hint?: string;
  error?: string;
  required?: boolean;
  size?: FieldSize;
  /** Leading KeenIcon */
  iconLead?: IconName;
  /** Trailing KeenIcon */
  iconTrail?: IconName;
}

export function Input(props: InputProps): JSX.Element;
export function injectFormStyles(): void;
