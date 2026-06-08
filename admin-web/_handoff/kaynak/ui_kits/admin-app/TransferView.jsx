/* Screen 8 — Stok Transferi (şubeler arası). window.TransferView */
const TVMDS = window.MetronicDesignSystem_a73f8f;

const TV_CSS = `
.tv-route{display:flex;align-items:center;gap:9px;font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);}
.tv-route__ar{color:var(--text-placeholder);}
.tv-route__to{color:var(--color-primary);}
.tv-no{font:var(--fw-semibold) 12.5px/1 var(--font-mono);color:var(--text-heading);}
.tv-items-pill{display:inline-flex;align-items:center;gap:5px;font:var(--fw-semibold) 12px/1 var(--font-sans);color:var(--text-body);background:var(--color-grey-100);padding:4px 9px;border-radius:999px;}
/* detail */
.td{display:flex;flex-direction:column;gap:20px;}
.td-route{display:flex;align-items:center;gap:14px;background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:16px 18px;}
.td-route__box{flex:1;text-align:center;}
.td-route__box .l{font:var(--fw-medium) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;color:var(--text-placeholder);}
.td-route__box .v{font:var(--fw-bold) 15px/1.2 var(--font-sans);color:var(--text-heading);margin-top:6px;}
.td-route__ar{width:42px;height:42px;border-radius:50%;background:var(--color-primary-soft);display:flex;align-items:center;justify-content:center;flex:none;}
.td-sec{font:var(--fw-semibold) 11px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.06em;color:var(--text-muted);margin-bottom:11px;}
.td-tbl{width:100%;border-collapse:collapse;}
.td-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 0 9px;border-bottom:1px solid var(--border-default);}
.td-tbl td{padding:10px 0;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);}
.td-tbl tr:last-child td{border-bottom:0;}
.td-tbl .num{text-align:right;font-variant-numeric:tabular-nums;}
.td-tl{display:flex;flex-direction:column;}
.td-tl__i{display:flex;gap:12px;padding-bottom:16px;position:relative;}
.td-tl__i:last-child{padding-bottom:0;}
.td-tl__i::before{content:"";position:absolute;left:8px;top:18px;bottom:-2px;width:2px;background:var(--border-default);}
.td-tl__i:last-child::before{display:none;}
.td-tl__i.done::before{background:var(--color-success);}
.td-tl__dot{width:18px;height:18px;border-radius:50%;flex:none;display:flex;align-items:center;justify-content:center;z-index:1;background:var(--surface-card);box-shadow:0 0 0 3px var(--surface-card);}
.td-tl__c b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.td-tl__c span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.td-tl__i.pending .td-tl__c b{color:var(--text-placeholder);}
.tf-form{display:flex;flex-direction:column;gap:18px;}
.tf-row{display:grid;grid-template-columns:1fr 44px 1fr;gap:10px;align-items:end;}
.tf-arrow{display:flex;align-items:center;justify-content:center;height:42px;color:var(--text-placeholder);}
.tf-add{display:flex;gap:10px;align-items:end;}
.tf-lines{border:1px solid var(--border-default);border-radius:var(--radius-md);overflow:hidden;}
.tf-lines table{width:100%;border-collapse:collapse;}
.tf-lines th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:10px 12px;background:var(--color-grey-50);border-bottom:1px solid var(--border-default);}
.tf-lines td{padding:8px 12px;border-bottom:1px solid var(--border-default);}
.tf-lines tr:last-child td{border-bottom:0;}
.tf-empty{padding:16px 12px;font:var(--fw-regular) 12.5px/1.4 var(--font-sans);color:var(--text-placeholder);text-align:center;}
.tf-addrow{appearance:none;border:0;background:none;cursor:pointer;display:flex;align-items:center;gap:6px;padding:10px 12px;width:100%;font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--color-primary);}
.tf-addrow:hover{background:var(--color-primary-soft);}
.tf-label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);margin-bottom:7px;display:block;}
.tf-label i{color:var(--color-danger);font-style:normal;}
`;
function injectTV(){ if(document.getElementById('tv-css'))return; const e=document.createElement('style');e.id='tv-css';e.textContent=TV_CSS;document.head.appendChild(e); }

const TV_BRANCHES=["Çayyolu Şubesi","Bağdat Caddesi","Alsancak Şubesi","Merkez Depo"];
const TV_PRODUCTS=["Çekirdek Kahve 1kg","Süt 1L","Filtre Kağıdı (100'lü)","Karton Bardak (S)","Vanilya Şurubu","Cheesecake (bütün)","Kruvasan (donuk)","Karamel Şurubu"];

function tvBuild(){
  const sts=["talep","onaylandi","teslim-alindi","teslim-alindi","iptal"];
  const out=[];
  for(let i=0;i<24;i++){
    const from=TV_BRANCHES[(i+3)%4], to=TV_BRANCHES[i%4];
    const st=sts[i%sts.length];
    const nItems=1+(i%3);
    const items=[]; let totalQty=0;
    for(let j=0;j<nItems;j++){ const q=2+((i+j)%8); items.push({name:TV_PRODUCTS[(i+j)%TV_PRODUCTS.length],qty:q}); totalQty+=q; }
    const d=String(1+(i%27)).padStart(2,"0");
    out.push({id:i,no:"TRF-"+(1040-i),from:from===to?TV_BRANCHES[(i+1)%4]:from,to,status:st,items,totalQty,date:`${d}.06.2026`,by:["Mert Demir","Ece Kaya","Selin Aydın"][i%3]});
  }
  return out;
}
const TV_DATA=tvBuild();
const TV_PAGE=8;

function TransferDetail({ t }){
  const { StatusBadge } = TVMDS;
  const steps=[
    {k:"talep",label:"Transfer talebi oluşturuldu",by:t.by},
    {k:"onaylandi",label:"Onaylandı / yola çıktı",by:"Depo sorumlusu"},
    {k:"teslim-alindi",label:"Hedef şubede teslim alındı",by:"Şube sorumlusu"},
  ];
  let activeIdx;
  if(t.status==="talep")activeIdx=0; else if(t.status==="onaylandi")activeIdx=1; else if(t.status==="teslim-alindi")activeIdx=2; else activeIdx=-1;
  return (
    <div className="td">
      <div className="td-route">
        <div className="td-route__box"><div className="l">Kaynak</div><div className="v">{t.from}</div></div>
        <div className="td-route__ar"><TVMDS.Icon name="share" size={18} color="var(--color-primary)"/></div>
        <div className="td-route__box"><div className="l">Hedef</div><div className="v" style={{color:"var(--color-primary)"}}>{t.to}</div></div>
      </div>
      <div style={{display:"flex",alignItems:"center",justifyContent:"space-between"}}>
        <span style={{font:"var(--fw-medium) 12.5px/1 var(--font-sans)",color:"var(--text-muted)"}}>{t.no} · {t.date}</span>
        <StatusBadge status={t.status} size="lg"/>
      </div>
      <div>
        <div className="td-sec">Transfer Kalemleri</div>
        <table className="td-tbl"><thead><tr><th>Ürün</th><th className="num">Miktar</th></tr></thead><tbody>
          {t.items.map((it,i)=><tr key={i}><td style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{it.name}</td><td className="num">{it.qty} adet</td></tr>)}
        </tbody></table>
      </div>
      <div>
        <div className="td-sec">Durum Geçmişi</div>
        <div className="td-tl">
          {t.status==="iptal" ? (
            <React.Fragment>
              <div className="td-tl__i done"><div className="td-tl__dot"><TVMDS.Icon name="check-circle" size={18} color="var(--color-success)"/></div><div className="td-tl__c"><b>Transfer talebi oluşturuldu</b><span>{t.by}</span></div></div>
              <div className="td-tl__i"><div className="td-tl__dot"><TVMDS.Icon name="cross-circle" size={18} color="var(--color-danger)"/></div><div className="td-tl__c"><b>Transfer iptal edildi</b><span>{t.by}</span></div></div>
            </React.Fragment>
          ) : steps.map((s,i)=>{
            const done=i<=activeIdx;
            return (
              <div className={"td-tl__i"+(done?" done":" pending")} key={i}>
                <div className="td-tl__dot"><TVMDS.Icon name={done?"check-circle":"abstract"} size={18} color={done?(i===activeIdx?"var(--color-primary)":"var(--color-success)"):"var(--border-strong)"}/></div>
                <div className="td-tl__c"><b>{s.label}</b><span>{done?s.by:"Bekliyor"}</span></div>
              </div>
            );
          })}
        </div>
      </div>
    </div>
  );
}

function NewTransferForm({ onCancel, onSave }){
  const { Select, Input, Button } = TVMDS;
  const [from,setFrom]=React.useState("");
  const [to,setTo]=React.useState("");
  const [lines,setLines]=React.useState([]);
  const [prod,setProd]=React.useState("");
  const [qty,setQty]=React.useState("");
  const [tried,setTried]=React.useState(false);
  function addLine(){ if(!prod||!qty)return; setLines([...lines,{name:prod,qty:Number(qty)}]); setProd("");setQty(""); }
  const err={from:tried&&!from,to:tried&&!to,same:tried&&from&&to&&from===to,lines:tried&&lines.length===0};
  function submit(){ setTried(true); if(from&&to&&from!==to&&lines.length>0) onSave({from,to,items:lines}); }
  return (
    <div className="tf-form">
      <div>
        <label className="tf-label">Şube Yönü <i>*</i></label>
        <div className="tf-row">
          <Select value={from} onChange={e=>setFrom(e.target.value)} error={err.from?"Kaynak seçin":undefined}>
            <option value="">Kaynak şube…</option>{TV_BRANCHES.map(b=><option key={b} value={b}>{b}</option>)}
          </Select>
          <div className="tf-arrow"><TVMDS.Icon name="share" size={18}/></div>
          <Select value={to} onChange={e=>setTo(e.target.value)} error={err.to?"Hedef seçin":undefined}>
            <option value="">Hedef şube…</option>{TV_BRANCHES.map(b=><option key={b} value={b}>{b}</option>)}
          </Select>
        </div>
        {err.same && <div style={{color:"var(--color-danger)",font:"var(--fw-medium) 11.5px/1.3 var(--font-sans)",marginTop:6,display:"flex",alignItems:"center",gap:5}}><TVMDS.Icon name="cross-circle" size={13} color="var(--color-danger)"/>Kaynak ve hedef aynı olamaz.</div>}
      </div>
      <div>
        <label className="tf-label">Kalem Ekle</label>
        <div className="tf-add">
          <div style={{flex:1}}><Select value={prod} onChange={e=>setProd(e.target.value)}><option value="">Ürün seçin…</option>{TV_PRODUCTS.map(p=><option key={p} value={p}>{p}</option>)}</Select></div>
          <div style={{width:96}}><Input type="number" placeholder="Adet" value={qty} onChange={e=>setQty(e.target.value)}/></div>
          <Button variant="outline" color="dark" iconStart="plus-squared" onClick={addLine}>Ekle</Button>
        </div>
      </div>
      <div className="tf-lines">
        <table><thead><tr><th>Ürün</th><th style={{width:90,textAlign:"right"}}>Miktar</th><th style={{width:44}}></th></tr></thead>
          <tbody>
            {lines.length===0 ? <tr><td colSpan={3}><div className="tf-empty">Henüz kalem yok. Yukarıdan ürün ekleyin.</div></td></tr> :
              lines.map((l,i)=><tr key={i}><td style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{l.name}</td><td style={{textAlign:"right",fontVariantNumeric:"tabular-nums"}}>{l.qty} adet</td><td><TVMDS.IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="Sil" onClick={()=>setLines(lines.filter((_,j)=>j!==i))}/></td></tr>)}
          </tbody>
        </table>
      </div>
      {err.lines && <div style={{color:"var(--color-danger)",font:"var(--fw-medium) 11.5px/1.3 var(--font-sans)",display:"flex",alignItems:"center",gap:5}}><TVMDS.Icon name="cross-circle" size={13} color="var(--color-danger)"/>En az bir kalem ekleyin.</div>}
      <div style={{display:"flex",justifyContent:"flex-end",gap:10,paddingTop:4}}>
        <Button variant="ghost" color="dark" onClick={onCancel}>İptal</Button>
        <Button color="accent" iconStart="check-circle" onClick={submit}>Transfer talebi oluştur</Button>
      </div>
    </div>
  );
}

function TransferView(){
  React.useEffect(()=>{injectTV();},[]);
  const { DataGrid, StatusBadge, Button, Input, Select, Drawer } = TVMDS;
  const toast = TVMDS.ToastProvider.useToast();
  const [loading,setLoading]=React.useState(true);
  const [demo,setDemo]=React.useState("full");
  const [q,setQ]=React.useState("");
  const [status,setStatus]=React.useState("");
  const [sort,setSort]=React.useState({key:"no",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [data,setData]=React.useState(TV_DATA);
  const [detail,setDetail]=React.useState(null);
  const [adding,setAdding]=React.useState(false);

  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),550); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,status]);

  const filtered=React.useMemo(()=>{
    let r=data.filter(t=>(!q||t.no.toLowerCase().includes(q.toLowerCase())||t.from.toLowerCase().includes(q.toLowerCase())||t.to.toLowerCase().includes(q.toLowerCase()))&&(!status||t.status===status));
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{let x=a[sort.key],y=b[sort.key];if(typeof x==="string")return x.localeCompare(y,"tr")*dir;return (x-y)*dir;});
    return r;
  },[data,q,status,sort]);
  const total=filtered.length, rows=filtered.slice((page-1)*TV_PAGE,page*TV_PAGE);
  const es=window.effState(demo,{loading,rows,total});

  function onSave(v){
    const id=Math.max(...data.map(d=>d.id))+1;
    setData([{id,no:"TRF-"+(1041),from:v.from,to:v.to,status:"talep",items:v.items,totalQty:v.items.reduce((s,i)=>s+i.qty,0),date:"07.06.2026",by:"Selin Aydın"},...data]);
    toast({type:"success",title:"Transfer oluşturuldu",description:`${v.from} → ${v.to} · ${v.items.length} kalem`});
    setAdding(false);
  }

  const columns=[
    { key:"no", header:"Transfer No", sortable:true, render:t=><span className="tv-no">{t.no}</span> },
    { key:"route", header:"Yön", render:t=><span className="tv-route">{t.from}<span className="tv-route__ar"><TVMDS.Icon name="share" size={13}/></span><span className="tv-route__to">{t.to}</span></span> },
    { key:"items", header:"Kalem", render:t=><span className="tv-items-pill">{t.items.length} kalem · {t.totalQty} adet</span> },
    { key:"date", header:"Tarih", sortable:true, render:t=><span style={{fontSize:12.5}}>{t.date}</span> },
    { key:"by", header:"Oluşturan", render:t=><span style={{fontSize:12.5,color:"var(--text-muted)"}}>{t.by}</span> },
    { key:"status", header:"Durum", align:"right", render:t=><StatusBadge status={t.status}/> },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Genel","Stok Transferi"]} title="Stok Transferi"
        desc={`${data.length} transfer · ${data.filter(t=>t.status==="talep"||t.status==="onaylandi").length} açık`}
        actions={<><window.StatePreviewSeg demo={demo} setDemo={setDemo}/><Button color="accent" iconStart="plus-squared" onClick={()=>setAdding(true)}>Yeni Transfer</Button></>}/>
      <div className="as-filter">
        <div style={{width:260}}><Input iconLead="magnifier" placeholder="Transfer no veya şube…" value={q} onChange={e=>setQ(e.target.value)}/></div>
        <div style={{width:180}}><Select value={status} onChange={e=>setStatus(e.target.value)}>
          <option value="">Tüm durumlar</option><option value="talep">Talep</option><option value="onaylandi">Onaylandı</option><option value="teslim-alindi">Teslim alındı</option><option value="iptal">İptal</option></Select></div>
        <div className="as-filter__sp"/>
        {(q||status)&&<Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setStatus("");}}>Temizle</Button>}
      </div>
      <DataGrid columns={columns} rows={es.rows} loading={es.loading} error={es.error} onRetry={()=>setDemo("full")}
        empty={{icon:"share",title:(q||status)?"Transfer bulunamadı":"Henüz transfer yok",subtitle:(q||status)?"Filtreleri değiştirin.":"Şubeler arası ilk transferi oluşturun.",action:(q||status)?null:<Button color="accent" size="sm" iconStart="plus-squared" onClick={()=>setAdding(true)}>Yeni Transfer</Button>}}
        sort={sort} onSortChange={setSort} page={page} pageSize={TV_PAGE} total={es.total} onPageChange={setPage} rowKey={t=>t.id} onRowClick={t=>setDetail(t)}/>

      <Drawer open={!!detail} onClose={()=>setDetail(null)} size="md" title={detail?`Transfer ${detail.no}`:""} subtitle={detail?`${detail.from} → ${detail.to}`:""}>
        {detail && <TransferDetail t={detail}/>}
      </Drawer>
      <Drawer open={adding} onClose={()=>setAdding(false)} size="md" title="Yeni Transfer" subtitle="Şubeler arası stok transferi">
        {adding && <NewTransferForm onCancel={()=>setAdding(false)} onSave={onSave}/>}
      </Drawer>
    </React.Fragment>
  );
}
window.TransferView = TransferView;
