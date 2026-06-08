/* Runtime bridge — defines the newer DS components on the namespace when the
   compiled _ds_bundle.js predates them (the bundle regenerates at turn
   boundaries). Loaded as text/babel AFTER _ds_bundle.js. Each definition is
   guarded so once the bundle ships these, this file is a no-op.
   Source of truth lives in components/**; keep in sync. */
(function(){
  const ns = window.MetronicDesignSystem_a73f8f = window.MetronicDesignSystem_a73f8f || {};
  const Icon = ns.Icon;
  function inject(id, css){ if(document.getElementById(id))return; const e=document.createElement('style');e.id=id;e.textContent=css;document.head.appendChild(e); }

  /* ---------- StatusBadge ---------- */
  const STATUS_MAP = {
    "alindi":{label:"Alındı",tone:"info"},"hazirlaniyor":{label:"Hazırlanıyor",tone:"warning"},
    "tamamlandi":{label:"Tamamlandı",tone:"success"},"teslim":{label:"Teslim edildi",tone:"primary"},
    "iptal":{label:"İptal",tone:"danger"},"iade":{label:"İade",tone:"secondary"},
    "normal":{label:"Normal",tone:"success"},"esik-alti":{label:"Eşik altı",tone:"accent"},"tukendi":{label:"Tükendi",tone:"danger"},
    "talep":{label:"Talep",tone:"info"},"onaylandi":{label:"Onaylandı",tone:"warning"},"teslim-alindi":{label:"Teslim alındı",tone:"success"},
    "odendi":{label:"Ödendi",tone:"success"},"bekliyor":{label:"Bekliyor",tone:"warning"},
    "aktif":{label:"Aktif",tone:"success"},"pasif":{label:"Pasif",tone:"secondary"},
    "online":{label:"Çevrimiçi",tone:"success"},"offline":{label:"Çevrimdışı",tone:"warning"},
  };
  if(!ns.StatusBadge){
    ns.STATUS_MAP = STATUS_MAP;
    ns.StatusBadge = function StatusBadge({status,label,tone,size="md",solid=false,className="",...rest}){
      const Badge = ns.Badge;
      const e = status?STATUS_MAP[String(status).toLowerCase()]:null;
      return <Badge color={tone||(e&&e.tone)||"secondary"} variant={solid?"solid":"light"} size={size} dot pill className={className} {...rest}>{label||(e&&e.label)||status||"—"}</Badge>;
    };
  }

  /* ---------- DataGrid ---------- */
  if(!ns.DataGrid){
    inject('mt-datagrid-styles', `
.mtdg{display:flex;flex-direction:column;background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.mtdg__scroll{overflow-x:auto;}
.mtdg__table{width:100%;border-collapse:collapse;font-family:var(--font-sans);}
.mtdg__th{position:sticky;top:0;background:var(--color-grey-50);text-align:left;white-space:nowrap;font:var(--fw-semibold) 10.5px/1 var(--font-sans);letter-spacing:.05em;text-transform:uppercase;color:var(--text-muted);padding:13px 16px;border-bottom:1px solid var(--border-default);}
.mtdg__th--sortable{cursor:pointer;user-select:none;}
.mtdg__th--sortable:hover{color:var(--text-heading);}
.mtdg__th-in{display:inline-flex;align-items:center;gap:5px;}
.mtdg__sort{display:inline-flex;flex-direction:column;line-height:0;color:var(--border-strong);}
.mtdg__sort .on{color:var(--color-primary);}
.mtdg__td{padding:13px 16px;border-bottom:1px solid var(--border-default);vertical-align:middle;font:var(--fw-medium) 13px/1.4 var(--font-sans);color:var(--text-body);}
.mtdg__row{transition:background .12s;}
.mtdg__row--click{cursor:pointer;}
.mtdg__row--click:hover{background:var(--color-grey-50);}
.mtdg__tbody tr:last-child .mtdg__td{border-bottom:0;}
.mtdg__actions{display:flex;align-items:center;gap:4px;justify-content:flex-end;}
.mtdg__state{display:flex;flex-direction:column;align-items:center;justify-content:center;gap:13px;padding:64px 24px;text-align:center;}
.mtdg__state-ic{width:60px;height:60px;border-radius:var(--radius-lg);display:flex;align-items:center;justify-content:center;}
.mtdg__state-t{font:var(--fw-semibold) 15px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.mtdg__state-s{font:var(--fw-regular) 13px/1.5 var(--font-sans);color:var(--text-muted);max-width:360px;}
.mtdg__sk{height:13px;border-radius:5px;background:linear-gradient(90deg,var(--color-grey-100) 25%,var(--color-grey-200) 37%,var(--color-grey-100) 63%);background-size:400% 100%;animation:mtdgsk 1.3s ease infinite;}
@keyframes mtdgsk{0%{background-position:100% 50%;}100%{background-position:0 50%;}}
.mtdg__foot{display:flex;align-items:center;justify-content:space-between;gap:16px;padding:13px 16px;border-top:1px solid var(--border-default);background:var(--surface-card);flex-wrap:wrap;}
.mtdg__count{font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-muted);}
.mtdg__count b{color:var(--text-heading);font-weight:var(--fw-semibold);}
.mtdg__pager{display:flex;align-items:center;gap:4px;}
.mtdg__pg{appearance:none;min-width:32px;height:32px;padding:0 8px;border:1px solid var(--border-default);background:var(--surface-card);border-radius:var(--radius-sm);cursor:pointer;font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-body);display:inline-flex;align-items:center;justify-content:center;transition:all .12s;}
.mtdg__pg:hover:not(:disabled){border-color:var(--color-primary);color:var(--color-primary);}
.mtdg__pg--on{background:var(--color-primary);border-color:var(--color-primary);color:#fff;}
.mtdg__pg:disabled{opacity:.45;cursor:not-allowed;}
.mtdg__ell{padding:0 4px;color:var(--text-placeholder);font-size:12px;}`);
    const pageList=(page,tp)=>{const o=[];if(tp<=7){for(let i=1;i<=tp;i++)o.push(i);return o;}o.push(1);if(page>3)o.push("…");for(let i=Math.max(2,page-1);i<=Math.min(tp-1,page+1);i++)o.push(i);if(page<tp-2)o.push("…");o.push(tp);return o;};
    ns.DataGrid=function DataGrid({columns=[],rows=[],loading=false,error=null,onRetry,empty={},sort,onSortChange,page=1,pageSize=10,total,onPageChange,onRowClick,rowKey,className="",footerNote,dense=false}){
      const totalCount=typeof total==="number"?total:rows.length;
      const totalPages=Math.max(1,Math.ceil(totalCount/pageSize));
      const from=totalCount===0?0:(page-1)*pageSize+1, to=Math.min(page*pageSize,totalCount);
      const doSort=(c)=>{if(!c.sortable||!onSortChange)return;const dir=sort&&sort.key===c.key&&sort.dir==="asc"?"desc":"asc";onSortChange({key:c.key,dir});};
      const head=<thead><tr>{columns.map(c=>(
        <th key={c.key} className={"mtdg__th"+(c.sortable?" mtdg__th--sortable":"")} style={{width:c.width,textAlign:c.align||"left"}} onClick={()=>doSort(c)}>
          <span className="mtdg__th-in" style={{justifyContent:c.align==="right"?"flex-end":undefined}}>{c.header}{c.sortable&&<span className="mtdg__sort"><Icon name="chevron-up" size={9} className={sort&&sort.key===c.key&&sort.dir==="asc"?"on":""}/><Icon name="chevron-down" size={9} className={sort&&sort.key===c.key&&sort.dir==="desc"?"on":""}/></span>}</span>
        </th>))}</tr></thead>;
      let body;
      if(loading){body=<tbody className="mtdg__tbody">{Array.from({length:Math.min(pageSize,8)}).map((_,r)=><tr key={r}>{columns.map((c,ci)=><td key={c.key} className="mtdg__td"><div className="mtdg__sk" style={{width:ci===0?"70%":(c.align==="right"?"40%":"55%"),marginLeft:c.align==="right"?"auto":0}}/></td>)}</tr>)}</tbody>;}
      else if(error){body=<tbody><tr><td colSpan={columns.length}><div className="mtdg__state"><div className="mtdg__state-ic" style={{background:"var(--color-danger-soft)"}}><Icon name="cross-circle" size={28} color="var(--color-danger)"/></div><div className="mtdg__state-t">Veriler yüklenemedi</div><div className="mtdg__state-s">{typeof error==="string"?error:"Bir hata oluştu. Lütfen tekrar deneyin."}</div>{onRetry&&<button className="mtdg__pg" style={{height:36,padding:"0 16px"}} onClick={onRetry}><Icon name="share" size={14} style={{marginRight:6}}/>Tekrar dene</button>}</div></td></tr></tbody>;}
      else if(rows.length===0){body=<tbody><tr><td colSpan={columns.length}><div className="mtdg__state"><div className="mtdg__state-ic" style={{background:"var(--color-grey-100)"}}><Icon name={empty.icon||"files"} size={28} color="var(--text-placeholder)"/></div><div className="mtdg__state-t">{empty.title||"Kayıt bulunamadı"}</div><div className="mtdg__state-s">{empty.subtitle||"Henüz veri yok."}</div>{empty.action}</div></td></tr></tbody>;}
      else{body=<tbody className="mtdg__tbody">{rows.map((row,ri)=><tr key={rowKey?rowKey(row):ri} className={"mtdg__row"+(onRowClick?" mtdg__row--click":"")} onClick={onRowClick?()=>onRowClick(row):undefined}>{columns.map(c=><td key={c.key} className={"mtdg__td"+(c.className?" "+c.className:"")} style={{textAlign:c.align||"left",paddingTop:dense?9:undefined,paddingBottom:dense?9:undefined}}>{c.render?c.render(row):row[c.key]}</td>)}</tr>)}</tbody>;}
      const showFooter=!loading&&!error&&rows.length>0&&onPageChange;
      return <div className={"mtdg "+className}><div className="mtdg__scroll"><table className="mtdg__table">{head}{body}</table></div>{showFooter&&<div className="mtdg__foot"><span className="mtdg__count">{footerNote||<>Toplam <b>{totalCount.toLocaleString("tr-TR")}</b> kayıttan <b>{from}–{to}</b> arası</>}</span><div className="mtdg__pager"><button className="mtdg__pg" disabled={page<=1} onClick={()=>onPageChange(page-1)}><Icon name="chevron-left" size={14}/></button>{pageList(page,totalPages).map((p,i)=>p==="…"?<span key={"e"+i} className="mtdg__ell">…</span>:<button key={p} className={"mtdg__pg"+(p===page?" mtdg__pg--on":"")} onClick={()=>onPageChange(p)}>{p}</button>)}<button className="mtdg__pg" disabled={page>=totalPages} onClick={()=>onPageChange(page+1)}><Icon name="chevron-right" size={14}/></button></div></div>}</div>;
    };
  }

  /* ---------- Overlays: Modal + Drawer ---------- */
  if(!ns.Modal || !ns.Drawer){
    inject('mt-overlay-styles', `
.mtov{position:fixed;inset:0;z-index:1000;display:flex;}
.mtov__scrim{position:absolute;inset:0;background:rgba(15,23,42,.46);backdrop-filter:blur(1.5px);animation:mtovFade .18s ease;}
@keyframes mtovFade{from{opacity:0;}to{opacity:1;}}
.mtmodal{position:relative;margin:auto;background:var(--surface-card);border-radius:16px;box-shadow:0 24px 64px rgba(15,23,42,.24);width:100%;display:flex;flex-direction:column;max-height:calc(100vh - 48px);animation:mtmodalIn .2s cubic-bezier(.2,.8,.3,1);overflow:hidden;}
@keyframes mtmodalIn{from{opacity:0;transform:translateY(12px) scale(.98);}to{opacity:1;transform:none;}}
.mtmodal--sm{max-width:420px;}.mtmodal--md{max-width:560px;}.mtmodal--lg{max-width:760px;}
.mtmodal__hd{display:flex;align-items:flex-start;gap:14px;padding:22px 24px 0;}
.mtmodal__hd-ic{width:44px;height:44px;border-radius:var(--radius-md);flex:none;display:flex;align-items:center;justify-content:center;}
.mtmodal__hd-tx{flex:1;min-width:0;}
.mtmodal__title{font:var(--fw-bold) 17px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.mtmodal__sub{font:var(--fw-regular) 13px/1.5 var(--font-sans);color:var(--text-muted);margin-top:4px;}
.mtmodal__x{appearance:none;border:0;background:none;cursor:pointer;color:var(--text-placeholder);padding:5px;border-radius:8px;flex:none;}
.mtmodal__x:hover{background:var(--color-grey-100);color:var(--text-heading);}
.mtmodal__body{padding:18px 24px 4px;overflow-y:auto;}
.mtmodal__foot{display:flex;align-items:center;justify-content:flex-end;gap:10px;padding:18px 24px 22px;}
.mtov--drawer{justify-content:flex-end;}
.mtdrawer{position:relative;height:100%;background:var(--surface-card);box-shadow:-12px 0 48px rgba(15,23,42,.16);display:flex;flex-direction:column;width:100%;animation:mtdrawerIn .24s cubic-bezier(.2,.8,.3,1);}
@keyframes mtdrawerIn{from{transform:translateX(28px);opacity:.6;}to{transform:none;opacity:1;}}
.mtdrawer--sm{max-width:400px;}.mtdrawer--md{max-width:520px;}.mtdrawer--lg{max-width:720px;}.mtdrawer--xl{max-width:920px;}
.mtdrawer__hd{display:flex;align-items:center;gap:12px;padding:18px 22px;border-bottom:1px solid var(--border-default);flex:none;}
.mtdrawer__hd-tx{flex:1;min-width:0;}
.mtdrawer__title{font:var(--fw-bold) 16px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.mtdrawer__sub{font:var(--fw-regular) 12.5px/1.4 var(--font-sans);color:var(--text-muted);margin-top:3px;}
.mtdrawer__x{appearance:none;border:0;background:var(--color-grey-100);cursor:pointer;color:var(--text-body);width:34px;height:34px;border-radius:9px;display:flex;align-items:center;justify-content:center;flex:none;transition:background .12s;}
.mtdrawer__x:hover{background:var(--color-grey-200);}
.mtdrawer__body{flex:1;overflow-y:auto;padding:22px;}
.mtdrawer__foot{display:flex;align-items:center;gap:10px;padding:16px 22px;border-top:1px solid var(--border-default);flex:none;background:var(--surface-card);}`);
    const useEsc=(open,onClose)=>{React.useEffect(()=>{if(!open)return;const k=e=>{if(e.key==="Escape"&&onClose)onClose();};document.addEventListener("keydown",k);const p=document.body.style.overflow;document.body.style.overflow="hidden";return()=>{document.removeEventListener("keydown",k);document.body.style.overflow=p;};},[open,onClose]);};
    const TONE={primary:["var(--color-primary-soft)","var(--color-primary)"],danger:["var(--color-danger-soft)","var(--color-danger)"],warning:["var(--color-warning-soft)","var(--color-warning-accent)"],success:["var(--color-success-soft)","var(--color-success)"],accent:["var(--color-accent-soft)","var(--color-accent)"]};
    ns.Modal=function Modal({open,onClose,title,subtitle,icon,tone="primary",size="md",children,footer,closeOnScrim=true}){
      useEsc(open,onClose); if(!open)return null; const[bg,fg]=TONE[tone]||TONE.primary;
      return <div className="mtov" role="dialog" aria-modal="true"><div className="mtov__scrim" onClick={closeOnScrim?onClose:undefined}/><div className={"mtmodal mtmodal--"+size}>{(title||icon)&&<div className="mtmodal__hd">{icon&&<div className="mtmodal__hd-ic" style={{background:bg}}><Icon name={icon} size={22} color={fg}/></div>}<div className="mtmodal__hd-tx">{title&&<div className="mtmodal__title">{title}</div>}{subtitle&&<div className="mtmodal__sub">{subtitle}</div>}</div>{onClose&&<button className="mtmodal__x" onClick={onClose} aria-label="Kapat"><Icon name="cross-circle" size={19}/></button>}</div>}{children!=null&&<div className="mtmodal__body">{children}</div>}{footer&&<div className="mtmodal__foot">{footer}</div>}</div></div>;
    };
    ns.Drawer=function Drawer({open,onClose,title,subtitle,size="md",children,footer,closeOnScrim=true}){
      useEsc(open,onClose); if(!open)return null;
      return <div className="mtov mtov--drawer" role="dialog" aria-modal="true"><div className="mtov__scrim" onClick={closeOnScrim?onClose:undefined}/><div className={"mtdrawer mtdrawer--"+size}><div className="mtdrawer__hd"><div className="mtdrawer__hd-tx">{title&&<div className="mtdrawer__title">{title}</div>}{subtitle&&<div className="mtdrawer__sub">{subtitle}</div>}</div>{onClose&&<button className="mtdrawer__x" onClick={onClose} aria-label="Kapat"><Icon name="cross-circle" size={18}/></button>}</div><div className="mtdrawer__body">{children}</div>{footer&&<div className="mtdrawer__foot">{footer}</div>}</div></div>;
    };
  }

  /* ---------- Toast ---------- */
  if(!ns.ToastProvider){
    inject('mt-toast-styles', `
.mttoasts{position:fixed;top:18px;right:18px;z-index:1100;display:flex;flex-direction:column;gap:10px;width:340px;max-width:calc(100vw - 36px);pointer-events:none;}
.mttoast{pointer-events:auto;display:flex;align-items:flex-start;gap:11px;background:var(--surface-card);border:1px solid var(--border-default);border-left-width:3px;border-radius:var(--radius-md);box-shadow:var(--shadow-lg);padding:13px 14px;animation:mttoastIn .22s cubic-bezier(.2,.8,.3,1);}
@keyframes mttoastIn{from{opacity:0;transform:translateX(24px);}to{opacity:1;transform:none;}}
.mttoast--success{border-left-color:var(--color-success);}.mttoast--error{border-left-color:var(--color-danger);}.mttoast--warning{border-left-color:var(--color-warning);}.mttoast--info{border-left-color:var(--color-primary);}
.mttoast__ic{flex:none;width:30px;height:30px;border-radius:8px;display:flex;align-items:center;justify-content:center;}
.mttoast--success .mttoast__ic{background:var(--color-success-soft);}.mttoast--error .mttoast__ic{background:var(--color-danger-soft);}.mttoast--warning .mttoast__ic{background:var(--color-warning-soft);}.mttoast--info .mttoast__ic{background:var(--color-primary-soft);}
.mttoast__tx{flex:1;min-width:0;}
.mttoast__t{font:var(--fw-semibold) 13px/1.35 var(--font-sans);color:var(--text-heading);}
.mttoast__d{font:var(--fw-regular) 12px/1.45 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.mttoast__x{appearance:none;border:0;background:none;cursor:pointer;color:var(--text-placeholder);padding:2px;border-radius:6px;flex:none;}
.mttoast__x:hover{background:var(--color-grey-100);color:var(--text-heading);}`);
    const TI={success:"check-circle",error:"cross-circle",warning:"shield-search",info:"message-notif"};
    const TC={success:"var(--color-success)",error:"var(--color-danger)",warning:"var(--color-warning-accent)",info:"var(--color-primary)"};
    const Ctx=React.createContext({push:()=>{}});
    const useToast=()=>React.useContext(Ctx).push;
    ns.ToastProvider=function ToastProvider({children}){
      const[items,setItems]=React.useState([]);
      const push=React.useCallback((t)=>{const id=Math.random().toString(36).slice(2);const it={id,type:"info",duration:3800,...(typeof t==="string"?{title:t}:t)};setItems(s=>[...s,it]);if(it.duration>0)setTimeout(()=>setItems(s=>s.filter(x=>x.id!==id)),it.duration);},[]);
      const dismiss=React.useCallback(id=>setItems(s=>s.filter(x=>x.id!==id)),[]);
      return <Ctx.Provider value={{push}}>{children}<div className="mttoasts">{items.map(it=><div key={it.id} className={"mttoast mttoast--"+it.type}><div className="mttoast__ic"><Icon name={TI[it.type]} size={17} color={TC[it.type]}/></div><div className="mttoast__tx"><div className="mttoast__t">{it.title}</div>{it.description&&<div className="mttoast__d">{it.description}</div>}</div><button className="mttoast__x" onClick={()=>dismiss(it.id)} aria-label="Kapat"><Icon name="cross-circle" size={16}/></button></div>)}</div></Ctx.Provider>;
    };
    ns.ToastProvider.useToast=useToast;
    ns.useToast=useToast;
  }
})();
