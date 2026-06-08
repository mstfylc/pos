import React from "react";

const CSS = `
.mtavatar{position:relative;display:inline-flex;align-items:center;justify-content:center;flex:none;
  border-radius:50%;overflow:visible;font-family:var(--font-sans);font-weight:var(--fw-semibold);color:#fff;}
.mtavatar__img{width:100%;height:100%;border-radius:50%;object-fit:cover;display:block;}
.mtavatar__initials{width:100%;height:100%;border-radius:50%;display:flex;align-items:center;justify-content:center;letter-spacing:var(--ls-tight);}
.mtavatar--ring .mtavatar__img,.mtavatar--ring .mtavatar__initials{box-shadow:0 0 0 2px var(--surface-card),0 0 0 4px var(--color-primary);}
.mtavatar__status{position:absolute;bottom:0;right:0;border-radius:50%;border:2px solid var(--surface-card);}
.mtavatar__status.online{background:var(--color-success);}
.mtavatar__status.busy{background:var(--color-danger);}
.mtavatar__status.away{background:var(--color-warning);}
.mtavatar__status.offline{background:var(--color-grey-400);}
.mtavatargroup{display:inline-flex;align-items:center;}
.mtavatargroup .mtavatar{box-shadow:0 0 0 2px var(--surface-card);border-radius:50%;}
.mtavatargroup__more{display:inline-flex;align-items:center;justify-content:center;border-radius:50%;
  background:var(--color-grey-100);color:var(--text-body);font-family:var(--font-sans);font-weight:var(--fw-semibold);
  box-shadow:0 0 0 2px var(--surface-card);flex:none;}
`;

function inject() {
  if (typeof document === "undefined" || document.getElementById("mt-avatar-styles")) return;
  const el = document.createElement("style");
  el.id = "mt-avatar-styles";
  el.textContent = CSS;
  document.head.appendChild(el);
}

const PALETTE = ["#1379f0", "#0bc33f", "#4921ea", "#ff6f1e", "#f8285a", "#676a72"];
function colorFor(str = "") {
  let h = 0;
  for (let i = 0; i < str.length; i++) h = str.charCodeAt(i) + ((h << 5) - h);
  return PALETTE[Math.abs(h) % PALETTE.length];
}
function initials(name = "") {
  return name.trim().split(/\s+/).slice(0, 2).map((w) => w[0]).join("").toUpperCase();
}

const SIZES = { xs: 24, sm: 32, md: 40, lg: 48, xl: 64 };

/** User avatar — photo or auto-colored initials, with optional status dot. */
export function Avatar({ src, name = "", size = "md", status, ring = false, className = "", style = {}, ...rest }) {
  React.useEffect(() => { inject(); }, []);
  const px = typeof size === "number" ? size : SIZES[size];
  const fontSize = Math.round(px * 0.38);
  const dot = Math.max(8, Math.round(px * 0.26));
  return (
    <span className={"mtavatar " + (ring ? "mtavatar--ring " : "") + className} style={{ width: px, height: px, ...style }} {...rest}>
      {src
        ? <img className="mtavatar__img" src={src} alt={name} />
        : <span className="mtavatar__initials" style={{ background: colorFor(name), fontSize }}>{initials(name)}</span>}
      {status && <span className={"mtavatar__status " + status} style={{ width: dot, height: dot }} />}
    </span>
  );
}

/** Overlapping avatar stack with an optional "+N" overflow. */
export function AvatarGroup({ people = [], size = "md", max = 4, className = "" }) {
  React.useEffect(() => { inject(); }, []);
  const px = typeof size === "number" ? size : SIZES[size];
  const overlap = Math.round(px * 0.3);
  const shown = people.slice(0, max);
  const extra = people.length - shown.length;
  return (
    <span className={"mtavatargroup " + className}>
      {shown.map((p, i) => (
        <span key={i} style={{ marginLeft: i === 0 ? 0 : -overlap, zIndex: i }}>
          <Avatar {...p} size={px} />
        </span>
      ))}
      {extra > 0 && (
        <span className="mtavatargroup__more" style={{ width: px, height: px, marginLeft: -overlap, fontSize: Math.round(px * 0.34) }}>+{extra}</span>
      )}
    </span>
  );
}
