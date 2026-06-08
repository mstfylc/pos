import React from "react";

/* Domain status dictionary — Turkish labels + tone mapping.
   tone → Badge color. Keys are normalized (lowercase, ascii-ish). */
const STATUS_MAP = {
  // Sipariş
  "alindi":        { label: "Alındı",        tone: "info" },
  "hazirlaniyor":  { label: "Hazırlanıyor",  tone: "warning" },
  "tamamlandi":    { label: "Tamamlandı",    tone: "success" },
  "teslim":        { label: "Teslim edildi", tone: "primary" },
  "iptal":         { label: "İptal",         tone: "danger" },
  "iade":          { label: "İade",          tone: "secondary" },
  // Stok
  "normal":        { label: "Normal",        tone: "success" },
  "esik-alti":     { label: "Eşik altı",     tone: "accent" },
  "tukendi":       { label: "Tükendi",       tone: "danger" },
  // Transfer / satın alma
  "talep":         { label: "Talep",         tone: "info" },
  "onaylandi":     { label: "Onaylandı",     tone: "warning" },
  "teslim-alindi": { label: "Teslim alındı", tone: "success" },
  "odendi":        { label: "Ödendi",        tone: "success" },
  "bekliyor":      { label: "Bekliyor",      tone: "warning" },
  // Genel
  "aktif":         { label: "Aktif",         tone: "success" },
  "pasif":         { label: "Pasif",         tone: "secondary" },
  "online":        { label: "Çevrimiçi",     tone: "success" },
  "offline":       { label: "Çevrimdışı",    tone: "warning" },
};

/* StatusBadge — semantic state pill. Pass a known `status` key for an automatic
   label+tone, or override with `label`/`tone`. Renders a dotted light Badge. */
export function StatusBadge({ status, label, tone, size = "md", solid = false, className = "", ...rest }) {
  // Lazy import Badge from the same bundle namespace to avoid a hard cyclic import.
  const Badge = (typeof window !== "undefined" && window.MetronicDesignSystem_a73f8f && window.MetronicDesignSystem_a73f8f.Badge) || _FallbackBadge;
  const entry = status ? STATUS_MAP[String(status).toLowerCase()] : null;
  const finalTone = tone || (entry && entry.tone) || "secondary";
  const finalLabel = label || (entry && entry.label) || status || "—";
  return (
    <Badge color={finalTone} variant={solid ? "solid" : "light"} size={size} dot pill className={className} {...rest}>
      {finalLabel}
    </Badge>
  );
}

function _FallbackBadge({ children }) { return <span>{children}</span>; }

export { STATUS_MAP };
