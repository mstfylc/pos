import React from "react";
import { Icon } from "../Icon/Icon.jsx";

const CSS = `
.mtdg{display:flex;flex-direction:column;background:var(--surface-card);border:1px solid var(--border-default);
  border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.mtdg__scroll{overflow-x:auto;}
.mtdg__table{width:100%;border-collapse:collapse;font-family:var(--font-sans);}
.mtdg__th{position:sticky;top:0;background:var(--color-grey-50);text-align:left;white-space:nowrap;
  font:var(--fw-semibold) 10.5px/1 var(--font-sans);letter-spacing:.05em;text-transform:uppercase;
  color:var(--text-muted);padding:13px 16px;border-bottom:1px solid var(--border-default);}
.mtdg__th--sortable{cursor:pointer;user-select:none;}
.mtdg__th--sortable:hover{color:var(--text-heading);}
.mtdg__th-in{display:inline-flex;align-items:center;gap:5px;}
.mtdg__sort{display:inline-flex;flex-direction:column;line-height:0;color:var(--border-strong);}
.mtdg__sort .on{color:var(--color-primary);}
.mtdg__td{padding:13px 16px;border-bottom:1px solid var(--border-default);vertical-align:middle;
  font:var(--fw-medium) 13px/1.4 var(--font-sans);color:var(--text-body);}
.mtdg__row{transition:background .12s;}
.mtdg__row--click{cursor:pointer;}
.mtdg__row--click:hover{background:var(--color-grey-50);}
.mtdg__tbody tr:last-child .mtdg__td{border-bottom:0;}
.mtdg__num{font-variant-numeric:tabular-nums;}
.mtdg__actions{display:flex;align-items:center;gap:4px;justify-content:flex-end;}
/* state panels */
.mtdg__state{display:flex;flex-direction:column;align-items:center;justify-content:center;gap:13px;
  padding:64px 24px;text-align:center;}
.mtdg__state-ic{width:60px;height:60px;border-radius:var(--radius-lg);display:flex;align-items:center;justify-content:center;}
.mtdg__state-t{font:var(--fw-semibold) 15px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.mtdg__state-s{font:var(--fw-regular) 13px/1.5 var(--font-sans);color:var(--text-muted);max-width:360px;}
/* skeleton */
.mtdg__sk{height:13px;border-radius:5px;background:linear-gradient(90deg,var(--color-grey-100) 25%,var(--color-grey-200) 37%,var(--color-grey-100) 63%);
  background-size:400% 100%;animation:mtdgsk 1.3s ease infinite;}
@keyframes mtdgsk{0%{background-position:100% 50%;}100%{background-position:0 50%;}}
.mtdg__spin{width:30px;height:30px;border-radius:50%;border:3px solid var(--color-grey-200);border-top-color:var(--color-primary);
  animation:mtdgspin .8s linear infinite;}
@keyframes mtdgspin{to{transform:rotate(360deg);}}
/* footer / pagination */
.mtdg__foot{display:flex;align-items:center;justify-content:space-between;gap:16px;padding:13px 16px;
  border-top:1px solid var(--border-default);background:var(--surface-card);flex-wrap:wrap;}
.mtdg__count{font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-muted);}
.mtdg__count b{color:var(--text-heading);font-weight:var(--fw-semibold);}
.mtdg__pager{display:flex;align-items:center;gap:4px;}
.mtdg__pg{appearance:none;min-width:32px;height:32px;padding:0 8px;border:1px solid var(--border-default);background:var(--surface-card);
  border-radius:var(--radius-sm);cursor:pointer;font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-body);
  display:inline-flex;align-items:center;justify-content:center;transition:all .12s;}
.mtdg__pg:hover:not(:disabled){border-color:var(--color-primary);color:var(--color-primary);}
.mtdg__pg--on{background:var(--color-primary);border-color:var(--color-primary);color:#fff;}
.mtdg__pg:disabled{opacity:.45;cursor:not-allowed;}
.mtdg__ell{padding:0 4px;color:var(--text-placeholder);font-size:12px;}
`;

function injectDataGridStyles() {
  if (typeof document === "undefined" || document.getElementById("mt-datagrid-styles")) return;
  const el = document.createElement("style"); el.id = "mt-datagrid-styles"; el.textContent = CSS; document.head.appendChild(el);
}

function pageList(page, totalPages) {
  const out = []; const add = (v) => out.push(v);
  if (totalPages <= 7) { for (let i = 1; i <= totalPages; i++) add(i); return out; }
  add(1);
  if (page > 3) add("…");
  for (let i = Math.max(2, page - 1); i <= Math.min(totalPages - 1, page + 1); i++) add(i);
  if (page < totalPages - 2) add("…");
  add(totalPages);
  return out;
}

/**
 * DataGrid — table with sort, pagination and loading / empty / error / full states.
 * columns: [{ key, header, width, align, sortable, render(row), className }]
 */
export function DataGrid({
  columns = [], rows = [], loading = false, error = null, onRetry,
  empty = {}, sort, onSortChange, page = 1, pageSize = 10, total,
  onPageChange, onRowClick, rowKey, className = "", footerNote, dense = false,
}) {
  React.useEffect(() => { injectDataGridStyles(); }, []);
  const totalCount = typeof total === "number" ? total : rows.length;
  const totalPages = Math.max(1, Math.ceil(totalCount / pageSize));
  const from = totalCount === 0 ? 0 : (page - 1) * pageSize + 1;
  const to = Math.min(page * pageSize, totalCount);

  function handleSort(col) {
    if (!col.sortable || !onSortChange) return;
    const dir = sort && sort.key === col.key && sort.dir === "asc" ? "desc" : "asc";
    onSortChange({ key: col.key, dir });
  }

  const head = (
    <thead>
      <tr>
        {columns.map((c) => (
          <th key={c.key} className={"mtdg__th" + (c.sortable ? " mtdg__th--sortable" : "")}
              style={{ width: c.width, textAlign: c.align || "left" }} onClick={() => handleSort(c)}>
            <span className="mtdg__th-in" style={{ justifyContent: c.align === "right" ? "flex-end" : undefined }}>
              {c.header}
              {c.sortable && (
                <span className="mtdg__sort">
                  <Icon name="chevron-up" size={9} className={sort && sort.key === c.key && sort.dir === "asc" ? "on" : ""} />
                  <Icon name="chevron-down" size={9} className={sort && sort.key === c.key && sort.dir === "desc" ? "on" : ""} />
                </span>
              )}
            </span>
          </th>
        ))}
      </tr>
    </thead>
  );

  let body;
  if (loading) {
    body = (
      <tbody className="mtdg__tbody">
        {Array.from({ length: Math.min(pageSize, 8) }).map((_, r) => (
          <tr key={r}>
            {columns.map((c, ci) => (
              <td key={c.key} className="mtdg__td">
                <div className="mtdg__sk" style={{ width: ci === 0 ? "70%" : (c.align === "right" ? "40%" : "55%"), marginLeft: c.align === "right" ? "auto" : 0 }} />
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    );
  } else if (error) {
    body = (
      <tbody><tr><td colSpan={columns.length}>
        <div className="mtdg__state">
          <div className="mtdg__state-ic" style={{ background: "var(--color-danger-soft)" }}><Icon name="cross-circle" size={28} color="var(--color-danger)" /></div>
          <div className="mtdg__state-t">Veriler yüklenemedi</div>
          <div className="mtdg__state-s">{typeof error === "string" ? error : "Bir hata oluştu. Lütfen tekrar deneyin."}</div>
          {onRetry && <button className="mtdg__pg" style={{ height: 36, padding: "0 16px" }} onClick={onRetry}><Icon name="share" size={14} style={{ marginRight: 6 }} />Tekrar dene</button>}
        </div>
      </td></tr></tbody>
    );
  } else if (rows.length === 0) {
    body = (
      <tbody><tr><td colSpan={columns.length}>
        <div className="mtdg__state">
          <div className="mtdg__state-ic" style={{ background: "var(--color-grey-100)" }}><Icon name={empty.icon || "files"} size={28} color="var(--text-placeholder)" /></div>
          <div className="mtdg__state-t">{empty.title || "Kayıt bulunamadı"}</div>
          <div className="mtdg__state-s">{empty.subtitle || "Henüz veri yok."}</div>
          {empty.action}
        </div>
      </td></tr></tbody>
    );
  } else {
    body = (
      <tbody className="mtdg__tbody">
        {rows.map((row, ri) => (
          <tr key={rowKey ? rowKey(row) : ri} className={"mtdg__row" + (onRowClick ? " mtdg__row--click" : "")}
              onClick={onRowClick ? () => onRowClick(row) : undefined}>
            {columns.map((c) => (
              <td key={c.key} className={"mtdg__td" + (c.className ? " " + c.className : "")}
                  style={{ textAlign: c.align || "left", paddingTop: dense ? 9 : undefined, paddingBottom: dense ? 9 : undefined }}>
                {c.render ? c.render(row) : row[c.key]}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    );
  }

  const showFooter = !loading && !error && rows.length > 0 && onPageChange;

  return (
    <div className={"mtdg " + className}>
      <div className="mtdg__scroll">
        <table className="mtdg__table">{head}{body}</table>
      </div>
      {showFooter && (
        <div className="mtdg__foot">
          <span className="mtdg__count">{footerNote || <>Toplam <b>{totalCount.toLocaleString("tr-TR")}</b> kayıttan <b>{from}–{to}</b> arası</>}</span>
          <div className="mtdg__pager">
            <button className="mtdg__pg" disabled={page <= 1} onClick={() => onPageChange(page - 1)}><Icon name="chevron-left" size={14} /></button>
            {pageList(page, totalPages).map((p, i) => p === "…"
              ? <span key={"e" + i} className="mtdg__ell">…</span>
              : <button key={p} className={"mtdg__pg" + (p === page ? " mtdg__pg--on" : "")} onClick={() => onPageChange(p)}>{p}</button>)}
            <button className="mtdg__pg" disabled={page >= totalPages} onClick={() => onPageChange(page + 1)}><Icon name="chevron-right" size={14} /></button>
          </div>
        </div>
      )}
    </div>
  );
}
