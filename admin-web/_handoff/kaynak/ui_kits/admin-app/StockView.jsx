/* Screen 7 — Stok / Depo. window.StockView */
const SVMDS = window.MetronicDesignSystem_a73f8f;

const SV_CSS = `
.sv-prod{display:flex;align-items:center;gap:11px;}
.sv-cover{width:34px;height:34px;border-radius:9px;display:flex;align-items:center;justify-content:center;box-shadow:0 1px 4px rgba(0,0,0,.16);flex:none;}
.sv-cover span{font:var(--fw-bold) 10px/1 var(--font-sans);color:rgba(255,255,255,.95);}
.sv-prod__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.sv-prod__t span{font:var(--fw-regular) 11px/1 var(--font-mono);color:var(--text-muted);}
.sv-qty{font:var(--fw-bold) 14px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.sv-qty.low{color:var(--color-accent);}
.sv-thr{font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-muted);font-variant-numeric:tabular-nums;}
.sv-diff{font:var(--fw-semibold) 12.5px/1 var(--font-sans);font-variant-numeric:tabular-nums;}
.sv-diff.pos{color:var(--color-success);} .sv-diff.neg{color:var(--color-danger);} .sv-diff.zero{color:var(--text-placeholder);}
.sv-mv-tbl{width:100%;border-collapse:collapse;}
.sv-mv-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 16px 11px;border-bottom:1px solid var(--border-default);}
.sv-mv-tbl td{padding:11px 16px;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);vertical-align:middle;}
.sv-mv-tbl tr:last-child td{border-bottom:0;}
.sv-mv-tbl .num{text-align:right;font-variant-numeric:tabular-nums;white-space:nowrap;}
.sv-mv-type{display:inline-flex;align-items:center;gap:6px;font:var(--fw-semibold) 12px/1 var(--font-sans);}
.sv-mv-type__d{width:7px;height:7px;border-radius:2px;}
.sv-summary{display:grid;grid-template-columns:repeat(3,1fr);gap:14px;margin-bottom:18px;}
.sv-sum{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);padding:15px 17px;display:flex;align-items:center;gap:13px;}
.sv-sum.warn{border-color:#f1d2a8;background:var(--color-accent-soft);}
.sv-sum__ic{width:40px;height:40px;border-radius:10px;display:flex;align-items:center;justify-content:center;flex:none;}
.sv-sum__v{font:var(--fw-bold) 21px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.sv-sum__l{font:var(--fw-medium) 12px/1.3 var(--font-sans);color:var(--text-muted);margin-top:4px;}
.sc-bar{display:flex;align-items:center;gap:10px;padding:12px 14px;background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);margin-bottom:14px;}
.sc-bar__sp{flex:1;}
.sc-sum{display:flex;gap:18px;}
.sc-sum__i{display:flex;flex-direction:column;}
.sc-sum__i b{font:var(--fw-bold) 17px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.sc-sum__i span{font:var(--fw-medium) 10.5px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);margin-top:4px;}
.sc-sum__i.diff b{color:var(--color-accent);}
.sc-tbl{width:100%;border-collapse:collapse;}
.sc-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 0 11px;border-bottom:1px solid var(--border-default);position:sticky;top:0;background:var(--surface-card);}
.sc-tbl th.cin{color:var(--color-primary);}
.sc-tbl td{padding:9px 0;border-bottom:1px solid var(--border-default);vertical-align:middle;}
.sc-tbl td.cincell{background:var(--color-primary-soft);border-radius:8px;}
.sc-tbl tr:last-child td{border-bottom:0;}
.sc-tbl .num{text-align:right;font-variant-numeric:tabular-nums;}
.sc-cover{width:32px;height:32px;border-radius:8px;display:flex;align-items:center;justify-content:center;box-shadow:0 1px 3px rgba(0,0,0,.16);flex:none;}
.sc-cover span{font:var(--fw-bold) 9px/1 var(--font-sans);color:rgba(255,255,255,.95);}
.sc-prod{display:flex;align-items:center;gap:10px;}
.sc-prod__t b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.sc-prod__t span{font:var(--fw-regular) 10.5px/1 var(--font-mono);color:var(--text-muted);}
.sc-exp{font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-muted);font-variant-numeric:tabular-nums;}
.sc-in{width:84px;height:40px;text-align:right;border:1.5px solid var(--border-strong);border-radius:var(--radius-md);padding:0 11px;font:var(--fw-bold) 15px/1 var(--font-sans);color:var(--text-heading);background:var(--surface-card);outline:none;font-variant-numeric:tabular-nums;}
.sc-in::placeholder{font-weight:var(--fw-regular);color:var(--text-placeholder);}
.sc-in:focus{border-color:var(--color-primary);box-shadow:0 0 0 3px var(--color-primary-soft);}
.sc-in.filled{border-color:var(--color-primary);background:var(--color-primary-soft);color:var(--color-primary);}
.sc-diff{font:var(--fw-bold) 12.5px/1 var(--font-sans);font-variant-numeric:tabular-nums;}
.sc-diff.pos{color:var(--color-success);}.sc-diff.neg{color:var(--color-danger);}.sc-diff.zero{color:var(--text-placeholder);}.sc-diff.empty{color:var(--border-strong);}
/* stock entry modal form */
.sm-form{display:flex;flex-direction:column;gap:18px;}
.sm-field{display:flex;flex-direction:column;gap:7px;}
.sm-label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);}
.sm-label i{color:var(--color-danger);font-style:normal;}
.sm-stock{display:flex;align-items:center;gap:12px;background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:13px 16px;}
.sm-stock__i{display:flex;flex-direction:column;gap:4px;min-width:54px;}
.sm-stock__i span{font:var(--fw-medium) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);}
.sm-stock__i b{font:var(--fw-bold) 22px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.sm-stock__i.new b{color:var(--color-success);}
.sm-stock__i.err b{color:var(--color-danger);}
.sm-stock__ar{display:flex;align-items:center;}
.sm-stepper{display:flex;align-items:center;gap:0;border:1.5px solid var(--border-strong);border-radius:var(--radius-md);overflow:hidden;width:fit-content;background:var(--surface-card);}
.sm-step{appearance:none;border:0;background:var(--color-grey-50);cursor:pointer;width:44px;height:48px;display:flex;align-items:center;justify-content:center;transition:background .12s;}
.sm-step:hover{background:var(--color-grey-100);}
.sm-qty{width:96px;height:48px;border:0;border-left:1.5px solid var(--border-default);border-right:1.5px solid var(--border-default);text-align:center;font:var(--fw-bold) 20px/1 var(--font-sans);color:var(--text-heading);outline:none;font-variant-numeric:tabular-nums;background:var(--surface-card);}
.sm-qty:focus{background:var(--color-primary-soft);}
.sm-unit{padding:0 14px;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-muted);}
.sm-err{display:flex;align-items:center;gap:6px;font:var(--fw-medium) 11.5px/1.3 var(--font-sans);color:var(--color-danger);margin-top:2px;}
`;
function injectSV(){ if(document.getElementById('sv-css'))return; const e=document.createElement('style');e.id='sv-css';e.textContent=SV_CSS;document.head.appendChild(e); }

const SV_COVERS=["#3a2417","#6f4a2f","#1f5e7a","#9a4a1f","#1f6e8a","#7a1f3d"];
const SV_WAREHOUSES=["Çayyolu Deposu","Bağdat Cad. Deposu","Merkez Depo"];
const SV_PROD=[
  {name:"Çekirdek Kahve 1kg",sku:"UYK-D001",qty:4,thr:10,last:6},
  {name:"Süt 1L",sku:"UYK-D002",qty:8,thr:24,last:12},
  {name:"Filtre Kağıdı (100'lü)",sku:"UYK-D003",qty:6,thr:8,last:7},
  {name:"Karton Bardak (S)",sku:"UYK-D004",qty:240,thr:100,last:240},
  {name:"Vanilya Şurubu",sku:"UYK-D005",qty:3,thr:6,last:5},
  {name:"Cheesecake (bütün)",sku:"UYK-D006",qty:2,thr:6,last:4},
  {name:"Brownie Tepsi",sku:"UYK-D007",qty:9,thr:6,last:9},
  {name:"Kruvasan (donuk)",sku:"UYK-D008",qty:14,thr:8,last:14},
  {name:"Karamel Şurubu",sku:"UYK-D009",qty:2,thr:6,last:5},
  {name:"Sahlep Karışımı",sku:"UYK-D010",qty:7,thr:10,last:8},
  {name:"Çay (1kg)",sku:"UYK-D011",qty:12,thr:5,last:12},
  {name:"Soda (24'lü koli)",sku:"UYK-D012",qty:18,thr:8,last:16},
].map((p,i)=>({...p,id:i,diff:p.qty-p.last,wh:SV_WAREHOUSES[i%3],cover:SV_COVERS[i%SV_COVERS.length],init:p.name.split(" ").slice(0,2).map(w=>w[0]).join("").toUpperCase()}));

const MV_TYPES={
  giris:{label:"Giriş",color:"#0bc33f"},cikis:{label:"Çıkış",color:"#ed143b"},
  imha:{label:"İmha",color:"#78829d"},transfer:{label:"Transfer",color:"#4921ea"},
  siparis:{label:"Sipariş",color:"#1f3864"},satinalma:{label:"Satın Alma",color:"#e08a2b"},
};
const SV_MOVES=[
  {type:"satinalma",prod:"Çekirdek Kahve 1kg",qty:20,date:"05.06.2026",by:"Mert Demir",note:"Fatura #A-1042"},
  {type:"siparis",prod:"Süt 1L",qty:-4,date:"05.06.2026",by:"POS-1",note:"Günlük üretim"},
  {type:"imha",prod:"Cheesecake (bütün)",qty:-2,date:"04.06.2026",by:"Selin Aydın",note:"Son kullanma tarihi"},
  {type:"transfer",prod:"Kruvasan (donuk)",qty:-5,date:"04.06.2026",by:"Ece Kaya",note:"→ Bağdat Cad. Deposu"},
  {type:"giris",prod:"Karton Bardak (S)",qty:200,date:"03.06.2026",by:"Mert Demir",note:"Manuel giriş"},
  {type:"cikis",prod:"Vanilya Şurubu",qty:-1,date:"03.06.2026",by:"Burak Şahin",note:"Açılan şişe"},
  {type:"satinalma",prod:"Süt 1L",qty:24,date:"02.06.2026",by:"Mert Demir",note:"Fatura #A-1038"},
];
const SV_PAGE=8;

function CountSheet({ products, onSearch, q, setQ, counts, setCount }){
  const filtered=products.filter(p=>!q||p.name.toLowerCase().includes(q.toLowerCase())||p.sku.toLowerCase().includes(q.toLowerCase()));
  const counted=Object.keys(counts).filter(k=>counts[k]!=="").length;
  const totalDiff=products.reduce((s,p)=>{ const c=counts[p.id]; return c===undefined||c===""?s:s+(Number(c)-p.qty); },0);
  return (
    <div>
      <div className="sc-bar">
        <div className="sc-sum">
          <div className="sc-sum__i"><b>{counted}/{products.length}</b><span>Sayılan</span></div>
          <div className={"sc-sum__i diff"}><b>{totalDiff>0?"+":""}{totalDiff}</b><span>Net fark</span></div>
        </div>
        <div className="sc-bar__sp"/>
        <div style={{width:220}}><SVMDS.Input size="sm" iconLead="magnifier" placeholder="Ürün veya kod…" value={q} onChange={e=>setQ(e.target.value)}/></div>
      </div>
      <table className="sc-tbl">
        <thead><tr><th>Ürün</th><th>Depo</th><th className="num">Sistem</th><th className="num cin">Sayım ▼</th><th className="num">Fark</th></tr></thead>
        <tbody>
          {filtered.map(p=>{ const c=counts[p.id]; const has=c!==undefined&&c!==""; const diff=has?Number(c)-p.qty:null;
            return (
              <tr key={p.id}>
                <td><div className="sc-prod"><div className="sc-cover" style={{background:p.cover}}><span>{p.init}</span></div><div className="sc-prod__t"><b>{p.name}</b><span>{p.sku}</span></div></div></td>
                <td><span style={{font:"var(--fw-medium) 11.5px/1 var(--font-sans)",color:"var(--text-muted)"}}>{p.wh}</span></td>
                <td className="num"><span className="sc-exp">{p.qty}</span></td>
                <td className="num cincell"><input className={"sc-in"+(has?" filled":"")} type="number" inputMode="numeric" placeholder={""+p.qty} value={c===undefined?"":c} onChange={e=>setCount(p.id,e.target.value)}/></td>
                <td className="num"><span className={"sc-diff "+(!has?"empty":diff>0?"pos":diff<0?"neg":"zero")}>{!has?"—":(diff>0?"+":"")+diff}</span></td>
              </tr>
            );})}
        </tbody>
      </table>
    </div>
  );
}

function StockView(){
  React.useEffect(()=>{injectSV();},[]);
  const { DataGrid, StatusBadge, Button, Input, Select, Tabs, Modal, Drawer, Textarea } = SVMDS;
  const toast = SVMDS.ToastProvider.useToast();
  const [tab,setTab]=React.useState("stok");
  const [loading,setLoading]=React.useState(true);
  const [q,setQ]=React.useState("");
  const [wh,setWh]=React.useState("");
  const [lowOnly,setLowOnly]=React.useState(false);
  const [sort,setSort]=React.useState({key:"name",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [modal,setModal]=React.useState(null); // {kind:'giris'|'cikis'|'imha', prod?}
  const [mProd,setMProd]=React.useState("");
  const [mQty,setMQty]=React.useState("");
  const [mReason,setMReason]=React.useState("");
  function openModal(kind,prod){ setModal({kind,prod}); setMProd(prod?String(prod.id):""); setMQty(""); setMReason(""); }
  function closeModal(){ setModal(null); setMProd(""); setMQty(""); setMReason(""); }
  const [countOpen,setCountOpen]=React.useState(false);
  const [countQ,setCountQ]=React.useState("");
  const [counts,setCounts]=React.useState({});
  function setCount(id,val){ setCounts(c=>({...c,[id]:val})); }
  function applyCount(){
    const n=Object.keys(counts).filter(k=>counts[k]!=="").length;
    toast({type:"success",title:"Sayım kaydedildi",description:`${n} ürün sayıldı · stok sistemde güncellendi.`});
    setCountOpen(false);setCounts({});setCountQ("");
  }

  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),550); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,wh,lowOnly]);

  const lowCount=SV_PROD.filter(p=>p.qty<p.thr).length;
  const filtered=React.useMemo(()=>{
    let r=SV_PROD.filter(p=>(!q||p.name.toLowerCase().includes(q.toLowerCase())||p.sku.toLowerCase().includes(q.toLowerCase()))&&(!wh||p.wh===wh)&&(!lowOnly||p.qty<p.thr));
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{let x=a[sort.key],y=b[sort.key];if(typeof x==="string")return x.localeCompare(y,"tr")*dir;return (x-y)*dir;});
    return r;
  },[q,wh,lowOnly,sort]);
  const total=filtered.length, rows=filtered.slice((page-1)*SV_PAGE,page*SV_PAGE);

  const MODAL_META={
    giris:{t:"Stok Girişi",sub:"Depoya ürün girişi yapın",cta:"Girişi kaydet",tone:"success",ic:"plus-squared",pos:true,kind:"giris"},
    cikis:{t:"Stok Çıkışı",sub:"Depodan ürün çıkışı yapın",cta:"Çıkışı kaydet",tone:"warning",ic:"minus-squared",pos:false,kind:"cikis"},
    imha:{t:"İmha",sub:"Bozuk / süresi geçmiş ürünü düşün",cta:"İmhayı kaydet",tone:"danger",ic:"trash",pos:false,reason:true,kind:"imha"},
  };
  function submitModal(){
    const meta=MODAL_META[modal.kind];
    const prod=SV_PROD.find(p=>String(p.id)===String(mProd));
    toast({type:"success",title:meta.t+" kaydedildi",description:`${meta.pos?"+":"-"}${mQty||0} adet · ${prod?prod.name:"ürün"}${mReason?" · "+mReason:""}`});
    closeModal();
  }
  const meta = modal?MODAL_META[modal.kind]:null;
  const reasonRequired = meta && meta.reason;
  const selProd = SV_PROD.find(p=>String(p.id)===String(mProd));
  const qtyNum = Number(mQty)||0;
  const newStock = selProd ? (meta&&meta.pos ? selProd.qty+qtyNum : selProd.qty-qtyNum) : null;
  const submitDisabled = !mProd || !mQty.trim() || qtyNum<=0 || (reasonRequired && !mReason.trim()) || (newStock!==null && newStock<0);

  const columns=[
    { key:"name", header:"Ürün", sortable:true, render:p=><div className="sv-prod"><div className="sv-cover" style={{background:p.cover}}><span>{p.init}</span></div><div className="sv-prod__t"><b>{p.name}</b><span>{p.sku}</span></div></div> },
    { key:"wh", header:"Depo", render:p=><span style={{fontSize:12.5}}>{p.wh}</span> },
    { key:"qty", header:"Mevcut", align:"right", sortable:true, render:p=><span className={"sv-qty"+(p.qty<p.thr?" low":"")}>{p.qty}</span> },
    { key:"thr", header:"Eşik", align:"right", render:p=><span className="sv-thr">{p.thr}</span> },
    { key:"last", header:"Son Sayım", align:"right", render:p=><span className="sv-thr">{p.last}</span> },
    { key:"diff", header:"Fark", align:"right", render:p=><span className={"sv-diff "+(p.diff>0?"pos":p.diff<0?"neg":"zero")}>{p.diff>0?"+":""}{p.diff}</span> },
    { key:"_st", header:"Durum", align:"right", render:p=>p.qty<p.thr?<StatusBadge status="esik-alti"/>:<StatusBadge status="normal"/> },
    { key:"_act", header:"", align:"right", width:120, render:p=>(
      <div style={{display:"flex",gap:2,justifyContent:"flex-end"}}>
        <SVMDS.IconButton size="sm" variant="ghost" color="success" icon="plus-squared" aria-label="Giriş" onClick={e=>{e.stopPropagation();openModal("giris",p);}}/>
        <SVMDS.IconButton size="sm" variant="ghost" color="warning" icon="minus-squared" aria-label="Çıkış" onClick={e=>{e.stopPropagation();openModal("cikis",p);}}/>
        <SVMDS.IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="İmha" onClick={e=>{e.stopPropagation();openModal("imha",p);}}/>
      </div>) },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Genel","Stok / Depo"]} title="Stok / Depo"
        desc={`${SV_PROD.length} ürün · ${lowCount} eşik altı`}
        actions={<>
          <Button variant="outline" color="dark" iconStart="verify" onClick={()=>setCountOpen(true)}>Sayım Başlat</Button>
          <Button color="accent" iconStart="plus-squared" onClick={()=>openModal("giris",null)}>Stok Girişi</Button>
        </>}/>

      <div className="sv-summary">
        <div className="sv-sum"><span className="sv-sum__ic" style={{background:"var(--color-primary-soft)"}}><SVMDS.Icon name="folder" size={20} color="var(--color-primary)"/></span><div><div className="sv-sum__v">{SV_PROD.length}</div><div className="sv-sum__l">Takip edilen ürün</div></div></div>
        <div className="sv-sum warn"><span className="sv-sum__ic" style={{background:"#fff"}}><SVMDS.Icon name="dots-square" size={20} color="var(--color-accent)"/></span><div><div className="sv-sum__v" style={{color:"var(--color-accent-accent,#b5701b)"}}>{lowCount}</div><div className="sv-sum__l">Eşik-altı ürün</div></div></div>
        <div className="sv-sum"><span className="sv-sum__ic" style={{background:"var(--color-success-soft)"}}><SVMDS.Icon name="chart-line-up" size={20} color="var(--color-success)"/></span><div><div className="sv-sum__v">{SV_MOVES.length}</div><div className="sv-sum__l">Bugünkü hareket</div></div></div>
      </div>

      <div style={{marginBottom:16}}><Tabs tabs={[{id:"stok",label:"Stok Durumu"},{id:"hareket",label:"Stok Hareketleri",count:SV_MOVES.length}]} value={tab} onChange={setTab}/></div>

      {tab==="stok" ? <>
        <div className="as-filter">
          <div style={{width:260}}><Input iconLead="magnifier" placeholder="Ürün veya stok kodu…" value={q} onChange={e=>setQ(e.target.value)}/></div>
          <div style={{width:180}}><Select value={wh} onChange={e=>setWh(e.target.value)}>
            <option value="">Tüm depolar</option>{SV_WAREHOUSES.map(w=><option key={w} value={w}>{w}</option>)}</Select></div>
          <Button variant={lowOnly?"solid":"outline"} color={lowOnly?"accent":"dark"} size="md" iconStart="dots-square" onClick={()=>setLowOnly(v=>!v)}>Eşik altı{lowOnly?" ✓":""}</Button>
          <div className="as-filter__sp"/>
          {(q||wh||lowOnly)&&<Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setWh("");setLowOnly(false);}}>Temizle</Button>}
        </div>
        <DataGrid columns={columns} rows={rows} loading={loading}
          empty={{icon:"folder",title:(q||wh||lowOnly)?"Sonuç yok":"Stok kaydı yok",subtitle:(q||wh||lowOnly)?"Filtreleri değiştirin.":"Ürün eklendiğinde stok burada görünür.",action:(q||wh||lowOnly)?<Button variant="light" size="sm" onClick={()=>{setQ("");setWh("");setLowOnly(false);}}>Filtreleri temizle</Button>:null}}
          sort={sort} onSortChange={setSort} page={page} pageSize={SV_PAGE} total={total} onPageChange={setPage} rowKey={p=>p.id}/>
      </> : (
        <div style={{background:"var(--surface-card)",border:"1px solid var(--border-default)",borderRadius:"var(--radius-lg)",boxShadow:"var(--shadow-sm)",overflow:"hidden"}}>
          <div style={{display:"flex",alignItems:"center",gap:8,padding:"13px 16px",borderBottom:"1px solid var(--border-default)",font:"var(--fw-medium) 11.5px/1.4 var(--font-sans)",color:"var(--text-muted)"}}>
            <SVMDS.Icon name="shield-search" size={14} color="var(--text-muted)"/>Stok hareketleri yalnızca eklenir (append-only) — kayıtlar silinemez veya değiştirilemez.
          </div>
          <table className="sv-mv-tbl"><thead><tr><th>Tip</th><th>Ürün</th><th>Açıklama</th><th>Tarih</th><th>İşlem</th><th className="num">Miktar</th></tr></thead><tbody>
            {SV_MOVES.map((m,i)=>{ const t=MV_TYPES[m.type]; return (
              <tr key={i}>
                <td><span className="sv-mv-type" style={{color:t.color}}><span className="sv-mv-type__d" style={{background:t.color}}/>{t.label}</span></td>
                <td style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{m.prod}</td>
                <td style={{color:"var(--text-muted)"}}>{m.note}</td>
                <td>{m.date}</td>
                <td style={{color:"var(--text-muted)"}}>{m.by}</td>
                <td className="num" style={{fontWeight:"var(--fw-bold)",color:m.qty>0?"var(--color-success)":"var(--text-heading)"}}>{m.qty>0?"+":""}{m.qty}</td>
              </tr>
            );})}
          </tbody></table>
        </div>
      )}

      <Modal open={!!modal} onClose={closeModal} tone={meta?meta.tone:"primary"} icon={meta?meta.ic:""}
        title={meta?meta.t:""} subtitle={meta?meta.sub:""}
        footer={<>
          <Button variant="ghost" color="dark" onClick={closeModal}>İptal</Button>
          <Button color={meta&&meta.tone==="danger"?"danger":"accent"} iconStart="check-circle" disabled={submitDisabled} onClick={submitModal}>{meta?meta.cta:"Kaydet"}</Button>
        </>}>
        <div className="sm-form">
          <div className="sm-field">
            <label className="sm-label">Ürün <i>*</i></label>
            <Select value={mProd} onChange={e=>setMProd(e.target.value)} disabled={!!(modal&&modal.prod)}>
              <option value="">Ürün seçin…</option>
              {SV_PROD.map(p=><option key={p.id} value={p.id}>{p.name} — {p.sku} ({p.wh})</option>)}
            </Select>
          </div>
          {selProd && (
            <div className="sm-stock">
              <div className="sm-stock__i"><span>Mevcut</span><b>{selProd.qty}</b></div>
              <div className="sm-stock__ar"><SVMDS.Icon name="chevron-right" size={16} color="var(--text-placeholder)"/></div>
              <div className={"sm-stock__i"+(newStock<0?" err":" new")}><span>Yeni stok</span><b>{mQty.trim()?newStock:"—"}</b></div>
              <div className="sm-stock__i"><span>Eşik</span><b style={{color:"var(--text-muted)"}}>{selProd.thr}</b></div>
            </div>
          )}
          <div className="sm-field">
            <label className="sm-label">{meta&&meta.pos?"Giriş miktarı":meta&&meta.kind==="imha"?"İmha miktarı":"Çıkış miktarı"} <i>*</i></label>
            <div className="sm-stepper">
              <button type="button" className="sm-step" onClick={()=>setMQty(String(Math.max(0,qtyNum-1)))} aria-label="Azalt"><SVMDS.Icon name="minus-squared" size={18} color="var(--text-body)"/></button>
              <input className="sm-qty" type="number" inputMode="numeric" min="0" placeholder="0" value={mQty} onChange={e=>setMQty(e.target.value)} autoFocus/>
              <button type="button" className="sm-step" onClick={()=>setMQty(String(qtyNum+1))} aria-label="Artır"><SVMDS.Icon name="plus-squared" size={18} color="var(--text-body)"/></button>
              <span className="sm-unit">adet</span>
            </div>
            {newStock!==null && newStock<0 && <div className="sm-err"><SVMDS.Icon name="cross-circle" size={13} color="var(--color-danger)"/>Çıkış mevcut stoktan fazla olamaz.</div>}
          </div>
          {reasonRequired && (
            <div className="sm-field">
              <label className="sm-label">İmha nedeni <i>*</i></label>
              <Textarea rows={2} placeholder="Örn. son kullanma tarihi, hasar, fire…" value={mReason} onChange={e=>setMReason(e.target.value)}/>
            </div>
          )}
        </div>
      </Modal>

      <Drawer open={countOpen} onClose={()=>{setCountOpen(false);setCounts({});setCountQ("");}} size="lg"
        title="Stok Sayımı" subtitle={`${SV_PROD.length} ürün · fiili sayımı girin, fark otomatik hesaplanır`}
        footer={<>
          <Button variant="ghost" color="dark" onClick={()=>{setCountOpen(false);setCounts({});setCountQ("");}}>İptal</Button>
          <Button color="accent" iconStart="check-circle" disabled={Object.keys(counts).filter(k=>counts[k]!=="").length===0} onClick={applyCount}>Sayımı kaydet</Button>
        </>}>
        <CountSheet products={SV_PROD} q={countQ} setQ={setCountQ} counts={counts} setCount={setCount}/>
      </Drawer>
    </React.Fragment>
  );
}
window.StockView = StockView;
