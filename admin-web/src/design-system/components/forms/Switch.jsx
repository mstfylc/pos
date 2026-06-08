import React from "react";
import { injectChoiceStyles } from "./Checkbox.jsx";

/** Toggle switch with optional label. */
export function Switch({ label, className = "", ...rest }) {
  React.useEffect(() => { injectChoiceStyles(); }, []);
  return (
    <label className={"mtswitch " + className}>
      <input type="checkbox" role="switch" {...rest} />
      <span className="mttrack"><span className="mtknob" /></span>
      {label && <span>{label}</span>}
    </label>
  );
}
