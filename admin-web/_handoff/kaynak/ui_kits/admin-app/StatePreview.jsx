/* Shared 4-state preview helper — keeps all data screens consistent
   (yükleniyor / boş / hata / dolu). window.StatePreviewSeg + window.effState */
(function(){
  const CSS=`
.as-statepv{display:flex;align-items:center;gap:8px;padding-left:10px;margin-left:2px;border-left:1px solid var(--border-default);}
.as-statepv__l{font:var(--fw-medium) 10.5px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);}
.as-statepv__seg{display:inline-flex;background:var(--color-grey-100);border-radius:9px;padding:3px;gap:2px;}
.as-statepv__seg button{appearance:none;border:0;cursor:pointer;background:none;font:var(--fw-semibold) 11.5px/1 var(--font-sans);color:var(--text-muted);padding:6px 11px;border-radius:6px;transition:all .12s;}
.as-statepv__seg button.on{background:var(--surface-card);color:var(--text-heading);box-shadow:var(--shadow-sm);}
@media(max-width:560px){ .as-statepv{display:none;} }
`;
  function inject(){ if(document.getElementById('as-statepv-css'))return; const e=document.createElement('style');e.id='as-statepv-css';e.textContent=CSS;document.head.appendChild(e); }

  function StatePreviewSeg({ demo, setDemo }){
    React.useEffect(()=>{ inject(); },[]);
    const opts=[["full","Dolu"],["loading","Yükleniyor"],["empty","Boş"],["error","Hata"]];
    return (
      <span className="as-statepv" title="Durum önizlemesi">
        <span className="as-statepv__l">Önizleme</span>
        <span className="as-statepv__seg">
          {opts.map(([k,l])=>(<button key={k} className={demo===k?"on":""} onClick={()=>setDemo(k)}>{l}</button>))}
        </span>
      </span>
    );
  }

  // Maps a demo flag onto DataGrid props alongside the live loading/rows/total.
  function effState(demo, { loading, rows, total, errMsg }){
    return {
      loading: demo==="loading" || loading,
      error: demo==="error" ? (errMsg||"Sunucuya bağlanılamadı (503). Lütfen tekrar deneyin.") : null,
      rows: demo==="empty" ? [] : rows,
      total: demo==="empty" ? 0 : total,
    };
  }

  window.StatePreviewSeg = StatePreviewSeg;
  window.effState = effState;
})();
