import React from "react";
import { injectChoiceStyles } from "./Checkbox.jsx";

/** Radio button with label. Group by sharing the same `name`. */
export function Radio({ label, className = "", ...rest }) {
  React.useEffect(() => { injectChoiceStyles(); }, []);
  return (
    <label className={"mtchoice mtchoice--radio " + className}>
      <input type="radio" {...rest} />
      <span className="mtbox"><span className="mtradiodot" /></span>
      {label && <span>{label}</span>}
    </label>
  );
}
