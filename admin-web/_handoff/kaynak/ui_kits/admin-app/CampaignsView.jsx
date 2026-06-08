/* Screen 14 — İndirim & Kampanya. window.CampaignsView */
const CMMDS = window.MetronicDesignSystem_a73f8f;

const CM_CSS = `
.cm-name{display:flex;align-items:center;gap:11px;}
.cm-name__ic{width:36px;height:36px;border-radius:9px;display:flex;align-items:center;justify-content:center;flex:none;}
.cm-name__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.cm-name__t span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.cm-code{font:var(--fw-semibold) 12px/1 var(--font-mono);color:var(--color-primary);background:var(--color-primary-soft);padding:4px 9px;border-radius:6px;display:inline-block;}
.cm-val{font:var(--fw-bold) 13px/1 var(--font-sans);color:var(--text-heading);}
.cm-prog{display:flex;flex-direction:column;gap:5px;min-width:96px;}
.cm-prog__bar{height:6px;border-radius:3px;background:var(--color-grey-100);overflow:hidden;}
.cm-prog__fill{height:100%;border-radius:3px;background:var(--color-primary);}
.cm-prog__t{font:var(--fw-medium) 10.5px/1 var(--font-sans);color:var(--text-muted);}
.cm-form{display:flex;flex-direction:column;gap:16px;}
.cm-grid{display:grid;grid-template-columns:1fr 1fr;gap:14px;}
.cm-full{grid-column:1/-1;}
.cm-field{display:flex;flex-direction:column;gap:7px;}
.cm-label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);}
.cm-label i{color:var(--color-danger);font-style:normal;}
.cm-types{display:grid;grid-template-columns:1fr 1fr;gap:10px;}
.cm-type{appearance:none;cursor:pointer;border:1.5px solid var(--border-default);background:var(--surface-card);border-radius:var(--radius-md);padding:13px 14px;text-align:left;transition:all .12s;display:flex;align-items:center;gap:11px;}
.cm-type:hover{border-color:var(--border-strong);}
.cm-type.on{border-color:var(--color-primary);background:var(--color-primary-soft);}
.cm-type__ic{width:34px;height:34px;border-radius:9px;background:var(--color-grey-100);display:flex;align-items:center;justify-content:center;flex:none;}
.cm-type.on .cm-type__ic{background:var(--color-primary);}
.cm-type__t b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.cm-type__t span{font:var(--fw-regular) 10.5px/1.3 var(--font-sans);color:var(--text-muted);display:block;margin-top:2px;}
.cm-switch{display:flex;align-items:center;justify-content:space-between;gap:12px;padding:13px 15px;border:1px solid var(--border-default);border-radius:var(--radius-md);background:var(--color-grey-50);}
.cm-switch__tx b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.cm-switch__tx span{font:var(--fw-regular) 11.5px/1.4 var(--font-sans);color:var(--text-muted);display:block;margin-top:2px;}
`;
function injectCM(){ if(document.getElementById('cm-css'))return; const e=document.createElement('style');e.id='cm-css';e.textContent=CM_CSS;document.head.appendChild(e); }

const CM_TYPES={
  yuzde:{label:"Yüzde İndirim",bg:"#4921ea",icon:"price-tag",hint:"Toplam tutardan %"},
  tutar:{label:"Tutar İndirim",bg:"#1f3864",icon:"price-tag",hint:"Sabit ₺ indirim"},
  bxgy:{label:"Al-Kazan",bg:"#2f6e3a",icon:"handcart",hint:"3 al 2 öde vb."},
  ikram:{label:"İkram / Hediye",bg:"#9a4a1f",icon:"heart",hint:"Ücretsiz ürün"},
};
function cmBuild(){
  const rows=[
    {name:"Hafta İçi Sabah Kahvesi",type:"yuzde",val:"%20",code:"SABAH20",used:340,limit:1000,start:"01.06.2026",end:"30.06.2026",active:true,scope:"Espresso Bazlı"},
    {name:"Öğrenciye Özel",type:"yuzde",val:"%15",code:"OGRENCI",used:212,limit:0,start:"01.05.2026",end:"31.08.2026",active:true,scope:"Tüm menü"},
    {name:"İkinci Kahve Bizden",type:"bxgy",val:"2 al 1 öde",code:"2AL1ODE",used:88,limit:200,start:"05.06.2026",end:"12.06.2026",active:true,scope:"Sıcak kahveler"},
    {name:"100₺ Üzeri 20₺ İndirim",type:"tutar",val:"20 ₺",code:"UYE20",used:540,limit:0,start:"01.04.2026",end:"31.12.2026",active:true,scope:"Min. 100 ₺"},
    {name:"Doğum Günü İkramı",type:"ikram",val:"Ücretsiz tatlı",code:"DOGUMGUNU",used:64,limit:0,start:"01.01.2026",end:"31.12.2026",active:true,scope:"Sadakat üyeleri"},
    {name:"Açılış Kampanyası",type:"yuzde",val:"%30",code:"ACILIS30",used:1000,limit:1000,start:"01.03.2026",end:"15.03.2026",active:false,scope:"Tüm menü"},
    {name:"Yağmurlu Gün Sıcak Çikolata",type:"tutar",val:"10 ₺",code:"YAGMUR",used:30,limit:150,start:"10.06.2026",end:"20.06.2026",active:false,scope:"Sıcak içecekler"},
  ];
  return rows.map((r,i)=>({...r,id:i}));
}
const CM_DATA=cmBuild();
const CM_PAGE=8;

function CampaignForm({ initial, onCancel, onSave }){
  const { Input, Select, Switch, Button } = CMMDS;
  const isEdit=!!initial;
  const [v,setV]=React.useState(()=>({name:initial?.name||"",type:initial?.type||"yuzde",val:initial?.val||"",code:initial?.code||"",start:initial?.start||"",end:initial?.end||"",limit:initial?.limit||0,scope:initial?.scope||"",active:initial?.active!==false}));
  const [err,setErr]=React.useState({});
  const [tried,setTried]=React.useState(false);
  function set(k,val){ setV(s=>({...s,[k]:val})); if(tried) validate({...v,[k]:val}); }
  function validate(s){ const e={}; if(!s.name.trim())e.name="Kampanya adı zorunludur."; if(!s.val.trim())e.val="Değer zorunludur."; if(!s.code.trim())e.code="Kupon kodu zorunludur."; setErr(e); return !Object.keys(e).length; }
  function submit(){ setTried(true); if(validate(v)) onSave(v); }
  return (
    <div className="cm-form">
      <div className="cm-field">
        <label className="cm-label">Kampanya Tipi <i>*</i></label>
        <div className="cm-types">
          {Object.entries(CM_TYPES).map(([k,t])=>(
            <button key={k} type="button" className={"cm-type"+(v.type===k?" on":"")} onClick={()=>set("type",k)}>
              <span className="cm-type__ic"><CMMDS.Icon name={t.icon} size={16} color={v.type===k?"#fff":"var(--text-muted)"}/></span>
              <span className="cm-type__t"><b>{t.label}</b><span>{t.hint}</span></span>
            </button>
          ))}
        </div>
      </div>
      <div className="cm-field"><label className="cm-label">Kampanya Adı <i>*</i></label><Input placeholder="Örn. Hafta İçi Sabah Kahvesi" value={v.name} onChange={e=>set("name",e.target.value)} error={err.name}/></div>
      <div className="cm-grid">
        <div className="cm-field"><label className="cm-label">İndirim Değeri <i>*</i></label><Input placeholder={v.type==="yuzde"?"%20":v.type==="tutar"?"20 ₺":"2 al 1 öde"} value={v.val} onChange={e=>set("val",e.target.value)} error={err.val}/></div>
        <div className="cm-field"><label className="cm-label">Kupon Kodu <i>*</i></label><Input placeholder="SABAH20" value={v.code} onChange={e=>set("code",e.target.value.toUpperCase())} error={err.code}/></div>
        <div className="cm-field"><label className="cm-label">Başlangıç</label><Input placeholder="GG.AA.YYYY" value={v.start} onChange={e=>set("start",e.target.value)} iconLead="calendar"/></div>
        <div className="cm-field"><label className="cm-label">Bitiş</label><Input placeholder="GG.AA.YYYY" value={v.end} onChange={e=>set("end",e.target.value)} iconLead="calendar"/></div>
        <div className="cm-field"><label className="cm-label">Kullanım Limiti</label><Input type="number" placeholder="0 = sınırsız" value={v.limit} onChange={e=>set("limit",e.target.value)}/></div>
        <div className="cm-field"><label className="cm-label">Kapsam</label><Input placeholder="Tüm menü / kategori" value={v.scope} onChange={e=>set("scope",e.target.value)}/></div>
      </div>
      <div className="cm-switch"><div className="cm-switch__tx"><b>Aktif</b><span>Pasif kampanyalar POS ve uygulamada uygulanmaz.</span></div><Switch checked={v.active} onChange={e=>set("active",e.target.checked)}/></div>
      <div style={{display:"flex",justifyContent:"flex-end",gap:10,paddingTop:4}}>
        <Button variant="ghost" color="dark" onClick={onCancel}>İptal</Button>
        <Button color="accent" iconStart="check-circle" onClick={submit}>{isEdit?"Değişiklikleri kaydet":"Kampanya oluştur"}</Button>
      </div>
    </div>
  );
}

function CampaignsView(){
  React.useEffect(()=>{injectCM();},[]);
  const { DataGrid, StatusBadge, Button, Input, Select, Drawer, Modal, Badge } = CMMDS;
  const toast = CMMDS.ToastProvider.useToast();
  const [loading,setLoading]=React.useState(true);
  const [demo,setDemo]=React.useState("full");
  const [q,setQ]=React.useState("");
  const [type,setType]=React.useState("");
  const [status,setStatus]=React.useState("");
  const [sort,setSort]=React.useState({key:"name",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [data,setData]=React.useState(CM_DATA);
  const [drawer,setDrawer]=React.useState(null);
  const [del,setDel]=React.useState(null);

  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),550); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,type,status]);

  const filtered=React.useMemo(()=>{
    let r=data.filter(c=>(!q||c.name.toLowerCase().includes(q.toLowerCase())||c.code.toLowerCase().includes(q.toLowerCase()))&&(!type||c.type===type)&&(!status||(status==="active"?c.active:!c.active)));
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{let x=a[sort.key],y=b[sort.key];if(typeof x==="string")return x.localeCompare(y,"tr")*dir;return (x-y)*dir;});
    return r;
  },[data,q,type,status,sort]);
  const total=filtered.length, rows=filtered.slice((page-1)*CM_PAGE,page*CM_PAGE);
  const es=window.effState(demo,{loading,rows,total});

  function onSave(v){
    if(drawer.mode==="add"){ const id=Math.max(...data.map(d=>d.id))+1; setData([{...v,id,used:0,limit:Number(v.limit)||0},...data]); toast({type:"success",title:"Kampanya oluşturuldu",description:`“${v.name}” · ${v.code}`}); }
    else { setData(data.map(d=>d.id===drawer.camp.id?{...d,...v,limit:Number(v.limit)||0}:d)); toast({type:"success",title:"Kampanya güncellendi",description:v.name}); }
    setDrawer(null);
  }
  function confirmDelete(){ setData(data.filter(d=>d.id!==del.id)); toast({type:"error",title:"Kampanya silindi",description:del.name}); setDel(null); }

  const columns=[
    { key:"name", header:"Kampanya", sortable:true, render:c=>{ const t=CM_TYPES[c.type]; return <div className="cm-name"><div className="cm-name__ic" style={{background:t.bg}}><CMMDS.Icon name={t.icon} size={18} color="#fff"/></div><div className="cm-name__t"><b>{c.name}</b><span>{c.scope}</span></div></div>; } },
    { key:"type", header:"Tip", render:c=><Badge color="secondary" variant="light" size="sm">{CM_TYPES[c.type].label}</Badge> },
    { key:"val", header:"Değer", render:c=><span className="cm-val">{c.val}</span> },
    { key:"code", header:"Kupon", render:c=><span className="cm-code">{c.code}</span> },
    { key:"used", header:"Kullanım", render:c=>{
      if(!c.limit) return <span style={{font:"var(--fw-medium) 12px/1 var(--font-sans)",color:"var(--text-muted)"}}>{c.used} · sınırsız</span>;
      const pct=Math.min(100,Math.round(c.used/c.limit*100));
      return <div className="cm-prog"><div className="cm-prog__bar"><div className="cm-prog__fill" style={{width:pct+"%",background:pct>=100?"var(--color-danger)":"var(--color-primary)"}}/></div><span className="cm-prog__t">{c.used}/{c.limit} (%{pct})</span></div>;
    } },
    { key:"end", header:"Bitiş", align:"right", render:c=><span style={{fontSize:12.5,color:"var(--text-muted)"}}>{c.end}</span> },
    { key:"active", header:"Durum", render:c=><StatusBadge status={c.active?"aktif":"pasif"}/> },
    { key:"_act", header:"", align:"right", width:96, render:c=>(
      <div style={{display:"flex",gap:2,justifyContent:"flex-end"}}>
        <CMMDS.IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={e=>{e.stopPropagation();setDrawer({mode:"edit",camp:c});}}/>
        <CMMDS.IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="Sil" onClick={e=>{e.stopPropagation();setDel(c);}}/>
      </div>) },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Müşteri & Sadakat","İndirim & Kampanya"]} title="İndirim & Kampanya"
        desc={`${data.length} kampanya · ${data.filter(c=>c.active).length} aktif`}
        actions={<><window.StatePreviewSeg demo={demo} setDemo={setDemo}/><Button color="accent" iconStart="plus-squared" onClick={()=>setDrawer({mode:"add"})}>Kampanya Oluştur</Button></>}/>
      <div className="as-filter">
        <div style={{width:260}}><Input iconLead="magnifier" placeholder="Kampanya adı veya kupon…" value={q} onChange={e=>setQ(e.target.value)}/></div>
        <div style={{width:170}}><Select value={type} onChange={e=>setType(e.target.value)}><option value="">Tüm tipler</option>{Object.entries(CM_TYPES).map(([k,t])=><option key={k} value={k}>{t.label}</option>)}</Select></div>
        <div style={{width:150}}><Select value={status} onChange={e=>setStatus(e.target.value)}><option value="">Tüm durumlar</option><option value="active">Aktif</option><option value="passive">Pasif</option></Select></div>
        <div className="as-filter__sp"/>
        {(q||type||status)&&<Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setType("");setStatus("");}}>Temizle</Button>}
      </div>
      <DataGrid columns={columns} rows={es.rows} loading={es.loading} error={es.error} onRetry={()=>setDemo("full")}
        empty={{icon:"price-tag",title:(q||type||status)?"Kampanya bulunamadı":"Henüz kampanya yok",subtitle:(q||type||status)?"Filtreleri değiştirin.":"İlk kampanyanızı oluşturun.",action:(q||type||status)?<Button variant="light" size="sm" onClick={()=>{setQ("");setType("");setStatus("");}}>Filtreleri temizle</Button>:<Button color="accent" size="sm" iconStart="plus-squared" onClick={()=>setDrawer({mode:"add"})}>Kampanya Oluştur</Button>}}
        sort={sort} onSortChange={setSort} page={page} pageSize={CM_PAGE} total={es.total} onPageChange={setPage} rowKey={c=>c.id} onRowClick={c=>setDrawer({mode:"edit",camp:c})}/>

      <Drawer open={!!drawer} onClose={()=>setDrawer(null)} size="lg" title={drawer?.mode==="add"?"Yeni Kampanya":"Kampanyayı Düzenle"} subtitle={drawer?.mode==="add"?"İndirim veya kampanya tanımla":drawer?.camp?.code}>
        {drawer && <CampaignForm initial={drawer.mode==="edit"?drawer.camp:null} onCancel={()=>setDrawer(null)} onSave={onSave}/>}
      </Drawer>
      <Modal open={!!del} onClose={()=>setDel(null)} icon="trash" tone="danger" title="Kampanyayı sil?" subtitle={del?`“${del.name}” kalıcı olarak silinecek.`:""}
        footer={<><Button variant="ghost" color="dark" onClick={()=>setDel(null)}>İptal</Button><Button color="danger" iconStart="trash" onClick={confirmDelete}>Evet, sil</Button></>}/>
    </React.Fragment>
  );
}
window.CampaignsView = CampaignsView;
