/* Screen 9 — Satın Alma (tedarikçi siparişleri). window.PurchaseView */
const PUMDS = window.MetronicDesignSystem_a73f8f;

const PU_CSS = `
.pu-no{font:var(--fw-semibold) 12.5px/1 var(--font-mono);color:var(--text-heading);}
.pu-sup{display:flex;align-items:center;gap:10px;}
.pu-sup__ic{width:32px;height:32px;border-radius:8px;background:var(--color-primary-soft);display:flex;align-items:center;justify-content:center;flex:none;}
.pu-sup__t b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.pu-sup__t span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.pu-amt{font:var(--fw-bold) 13px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.pd{display:flex;flex-direction:column;gap:20px;}
.pd-grid{display:grid;grid-template-columns:1fr 1fr;gap:12px;}
.pd-info{background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:12px 14px;}
.pd-info .l{font:var(--fw-medium) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;color:var(--text-placeholder);}
.pd-info .v{font:var(--fw-semibold) 13px/1.3 var(--font-sans);color:var(--text-heading);margin-top:5px;}
.pd-sec{font:var(--fw-semibold) 11px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.06em;color:var(--text-muted);margin-bottom:11px;}
.pd-tbl{width:100%;border-collapse:collapse;}
.pd-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 0 9px;border-bottom:1px solid var(--border-default);}
.pd-tbl td{padding:10px 0;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);}
.pd-tbl tr:last-child td{border-bottom:0;}
.pd-tbl .num{text-align:right;font-variant-numeric:tabular-nums;white-space:nowrap;}
.pd-sum{background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:14px 16px;}
.pd-sum__r{display:flex;align-items:center;justify-content:between;justify-content:space-between;padding:6px 0;font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-body);}
.pd-sum__r.tot{border-top:1px solid var(--border-default);margin-top:6px;padding-top:11px;font:var(--fw-bold) 16px/1 var(--font-sans);color:var(--text-heading);}
.pd-sum__r .v{font-variant-numeric:tabular-nums;}
.pu-form{display:flex;flex-direction:column;gap:18px;}
.pu-add{display:flex;gap:10px;align-items:end;}
.pu-lines{border:1px solid var(--border-default);border-radius:var(--radius-md);overflow:hidden;}
.pu-lines table{width:100%;border-collapse:collapse;}
.pu-lines th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:10px 12px;background:var(--color-grey-50);border-bottom:1px solid var(--border-default);}
.pu-lines td{padding:8px 12px;border-bottom:1px solid var(--border-default);}
.pu-lines tr:last-child td{border-bottom:0;}
.pu-empty{padding:16px 12px;font:var(--fw-regular) 12.5px/1.4 var(--font-sans);color:var(--text-placeholder);text-align:center;}
.pu-label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);margin-bottom:7px;display:block;}
.pu-label i{color:var(--color-danger);font-style:normal;}
`;
function injectPU(){ if(document.getElementById('pu-css'))return; const e=document.createElement('style');e.id='pu-css';e.textContent=PU_CSS;document.head.appendChild(e); }

const PU_SUPPLIERS=["Kahve Dünyası Toptan","Anadolu Süt A.Ş.","Paketleme Ltd.","Pastane Tedarik","Şurup İthalat"];
const PU_PRODUCTS=[["Çekirdek Kahve 1kg",110],["Süt 1L",18],["Filtre Kağıdı (100'lü)",45],["Karton Bardak (S)",0.8],["Vanilya Şurubu",95],["Cheesecake (bütün)",180],["Kruvasan (donuk)",12],["Karamel Şurubu",95]];

function puBuild(){
  const sts=["talep","onaylandi","teslim-alindi","teslim-alindi","odendi","iptal"];
  const out=[];
  for(let i=0;i<26;i++){
    const sup=PU_SUPPLIERS[i%PU_SUPPLIERS.length];
    const st=sts[i%sts.length];
    const nItems=1+(i%4);
    const items=[]; let total=0;
    for(let j=0;j<nItems;j++){ const p=PU_PRODUCTS[(i+j)%PU_PRODUCTS.length]; const q=5+((i+j)%20); const line=Math.round(p[1]*q); total+=line; items.push({name:p[0],qty:q,unit:p[1],line}); }
    const d=String(1+(i%27)).padStart(2,"0");
    out.push({id:i,no:"SA-"+(2080-i),supplier:sup,status:st,items,total,date:`${d}.06.2026`,eta:`${String(1+((i+5)%27)).padStart(2,"0")}.06.2026`,by:["Mert Demir","Selin Aydın"][i%2]});
  }
  return out;
}
const PU_DATA=puBuild();
const PU_PAGE=8;
function fmtTL(n){ return n.toLocaleString("tr-TR")+" ₺"; }

function PurchaseDetail({ p, onReceive }){
  const { StatusBadge, Button } = PUMDS;
  const kdv=Math.round(p.total-p.total/1.18);
  return (
    <div className="pd">
      <div style={{display:"flex",alignItems:"center",justifyContent:"space-between"}}>
        <div className="pu-sup"><div className="pu-sup__ic"><PUMDS.Icon name="handcart" size={17} color="var(--color-primary)"/></div><div className="pu-sup__t"><b>{p.supplier}</b><span>{p.no}</span></div></div>
        <StatusBadge status={p.status} size="lg"/>
      </div>
      <div className="pd-grid">
        <div className="pd-info"><div className="l">Sipariş tarihi</div><div className="v">{p.date}</div></div>
        <div className="pd-info"><div className="l">Tahmini teslim</div><div className="v">{p.eta}</div></div>
      </div>
      <div>
        <div className="pd-sec">Kalemler</div>
        <table className="pd-tbl"><thead><tr><th>Ürün</th><th className="num">Adet</th><th className="num">Birim</th><th className="num">Tutar</th></tr></thead><tbody>
          {p.items.map((it,i)=><tr key={i}><td style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{it.name}</td><td className="num">{it.qty}</td><td className="num">{fmtTL(it.unit)}</td><td className="num" style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{fmtTL(it.line)}</td></tr>)}
        </tbody></table>
      </div>
      <div className="pd-sum">
        <div className="pd-sum__r"><span>Ara toplam</span><span className="v">{fmtTL(p.total-kdv)}</span></div>
        <div className="pd-sum__r"><span>KDV (%18)</span><span className="v">{fmtTL(kdv)}</span></div>
        <div className="pd-sum__r tot"><span>Genel toplam</span><span className="v">{fmtTL(p.total)}</span></div>
      </div>
      {(p.status==="talep"||p.status==="onaylandi") && (
        <div style={{display:"flex",justifyContent:"flex-end",gap:10,borderTop:"1px solid var(--border-default)",paddingTop:16}}>
          <Button color="accent" iconStart="check-circle" onClick={()=>onReceive(p)}>Mal kabul yap</Button>
        </div>
      )}
    </div>
  );
}

function NewPurchaseForm({ onCancel, onSave }){
  const { Select, Input, Button } = PUMDS;
  const [sup,setSup]=React.useState("");
  const [eta,setEta]=React.useState("");
  const [lines,setLines]=React.useState([]);
  const [prod,setProd]=React.useState("");
  const [qty,setQty]=React.useState("");
  const [tried,setTried]=React.useState(false);
  function addLine(){ if(!prod||!qty)return; const meta=PU_PRODUCTS.find(p=>p[0]===prod); setLines([...lines,{name:prod,qty:Number(qty),unit:meta[1],line:Math.round(meta[1]*Number(qty))}]); setProd("");setQty(""); }
  const total=lines.reduce((s,l)=>s+l.line,0);
  const err={sup:tried&&!sup,lines:tried&&lines.length===0};
  function submit(){ setTried(true); if(sup&&lines.length>0) onSave({supplier:sup,eta:eta||"—",items:lines,total}); }
  return (
    <div className="pu-form">
      <div>
        <label className="pu-label">Tedarikçi <i>*</i></label>
        <Select value={sup} onChange={e=>setSup(e.target.value)} error={err.sup?"Tedarikçi seçin":undefined}>
          <option value="">Tedarikçi seçin…</option>{PU_SUPPLIERS.map(s=><option key={s} value={s}>{s}</option>)}
        </Select>
      </div>
      <div>
        <label className="pu-label">Tahmini Teslim Tarihi</label>
        <Input placeholder="GG.AA.YYYY" value={eta} onChange={e=>setEta(e.target.value)} iconLead="calendar"/>
      </div>
      <div>
        <label className="pu-label">Kalem Ekle</label>
        <div className="pu-add">
          <div style={{flex:1}}><Select value={prod} onChange={e=>setProd(e.target.value)}><option value="">Ürün seçin…</option>{PU_PRODUCTS.map(p=><option key={p[0]} value={p[0]}>{p[0]} ({fmtTL(p[1])})</option>)}</Select></div>
          <div style={{width:90}}><Input type="number" placeholder="Adet" value={qty} onChange={e=>setQty(e.target.value)}/></div>
          <Button variant="outline" color="dark" iconStart="plus-squared" onClick={addLine}>Ekle</Button>
        </div>
      </div>
      <div className="pu-lines">
        <table><thead><tr><th>Ürün</th><th style={{width:70,textAlign:"right"}}>Adet</th><th style={{width:90,textAlign:"right"}}>Tutar</th><th style={{width:44}}></th></tr></thead>
          <tbody>
            {lines.length===0 ? <tr><td colSpan={4}><div className="pu-empty">Henüz kalem yok.</div></td></tr> :
              lines.map((l,i)=><tr key={i}><td style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{l.name}</td><td style={{textAlign:"right"}}>{l.qty}</td><td style={{textAlign:"right",fontVariantNumeric:"tabular-nums"}}>{fmtTL(l.line)}</td><td><PUMDS.IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="Sil" onClick={()=>setLines(lines.filter((_,j)=>j!==i))}/></td></tr>)}
          </tbody>
        </table>
      </div>
      {err.lines && <div style={{color:"var(--color-danger)",font:"var(--fw-medium) 11.5px/1.3 var(--font-sans)",display:"flex",alignItems:"center",gap:5}}><PUMDS.Icon name="cross-circle" size={13} color="var(--color-danger)"/>En az bir kalem ekleyin.</div>}
      {lines.length>0 && <div style={{display:"flex",justifyContent:"space-between",font:"var(--fw-bold) 15px/1 var(--font-sans)",color:"var(--text-heading)",padding:"4px 2px"}}><span>Toplam</span><span style={{fontVariantNumeric:"tabular-nums"}}>{fmtTL(total)}</span></div>}
      <div style={{display:"flex",justifyContent:"flex-end",gap:10,paddingTop:4}}>
        <Button variant="ghost" color="dark" onClick={onCancel}>İptal</Button>
        <Button color="accent" iconStart="check-circle" onClick={submit}>Satın alma oluştur</Button>
      </div>
    </div>
  );
}

function PurchaseView(){
  React.useEffect(()=>{injectPU();},[]);
  const { DataGrid, StatusBadge, Button, Input, Select, Drawer } = PUMDS;
  const toast = PUMDS.ToastProvider.useToast();
  const [loading,setLoading]=React.useState(true);
  const [demo,setDemo]=React.useState("full");
  const [q,setQ]=React.useState("");
  const [status,setStatus]=React.useState("");
  const [sort,setSort]=React.useState({key:"no",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [data,setData]=React.useState(PU_DATA);
  const [detail,setDetail]=React.useState(null);
  const [adding,setAdding]=React.useState(false);

  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),550); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,status]);

  const filtered=React.useMemo(()=>{
    let r=data.filter(p=>(!q||p.no.toLowerCase().includes(q.toLowerCase())||p.supplier.toLowerCase().includes(q.toLowerCase()))&&(!status||p.status===status));
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{let x=a[sort.key],y=b[sort.key];if(typeof x==="string")return x.localeCompare(y,"tr")*dir;return (x-y)*dir;});
    return r;
  },[data,q,status,sort]);
  const total=filtered.length, rows=filtered.slice((page-1)*PU_PAGE,page*PU_PAGE);
  const es=window.effState(demo,{loading,rows,total});

  function onSave(v){
    const id=Math.max(...data.map(d=>d.id))+1;
    setData([{id,no:"SA-"+2081,supplier:v.supplier,status:"talep",items:v.items,total:v.total,date:"07.06.2026",eta:v.eta,by:"Selin Aydın"},...data]);
    toast({type:"success",title:"Satın alma oluşturuldu",description:`${v.supplier} · ${fmtTL(v.total)}`});
    setAdding(false);
  }
  function onReceive(p){
    setData(data.map(d=>d.id===p.id?{...d,status:"teslim-alindi"}:d));
    setDetail(d=>d&&d.id===p.id?{...d,status:"teslim-alindi"}:d);
    toast({type:"success",title:"Mal kabul yapıldı",description:`${p.no} · stok güncellendi`});
  }

  const columns=[
    { key:"no", header:"Sipariş No", sortable:true, render:p=><span className="pu-no">{p.no}</span> },
    { key:"supplier", header:"Tedarikçi", render:p=><span className="pu-sup"><span className="pu-sup__ic"><PUMDS.Icon name="handcart" size={15} color="var(--color-primary)"/></span><span className="pu-sup__t"><b>{p.supplier}</b><span>{p.items.length} kalem</span></span></span> },
    { key:"date", header:"Tarih", sortable:true, render:p=><span style={{fontSize:12.5}}>{p.date}</span> },
    { key:"eta", header:"Teslim", render:p=><span style={{fontSize:12.5,color:"var(--text-muted)"}}>{p.eta}</span> },
    { key:"total", header:"Tutar", align:"right", sortable:true, render:p=><span className="pu-amt">{fmtTL(p.total)}</span> },
    { key:"status", header:"Durum", align:"right", render:p=><StatusBadge status={p.status}/> },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Genel","Satın Alma"]} title="Satın Alma"
        desc={`${data.length} sipariş · ${data.filter(p=>p.status==="talep"||p.status==="onaylandi").length} açık`}
        actions={<><window.StatePreviewSeg demo={demo} setDemo={setDemo}/><Button color="accent" iconStart="plus-squared" onClick={()=>setAdding(true)}>Yeni Satın Alma</Button></>}/>
      <div className="as-filter">
        <div style={{width:260}}><Input iconLead="magnifier" placeholder="Sipariş no veya tedarikçi…" value={q} onChange={e=>setQ(e.target.value)}/></div>
        <div style={{width:180}}><Select value={status} onChange={e=>setStatus(e.target.value)}>
          <option value="">Tüm durumlar</option><option value="talep">Talep</option><option value="onaylandi">Onaylandı</option><option value="teslim-alindi">Teslim alındı</option><option value="odendi">Ödendi</option><option value="iptal">İptal</option></Select></div>
        <div className="as-filter__sp"/>
        {(q||status)&&<Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setStatus("");}}>Temizle</Button>}
      </div>
      <DataGrid columns={columns} rows={es.rows} loading={es.loading} error={es.error} onRetry={()=>setDemo("full")}
        empty={{icon:"handcart",title:(q||status)?"Sipariş bulunamadı":"Henüz satın alma yok",subtitle:(q||status)?"Filtreleri değiştirin.":"İlk tedarikçi siparişini oluşturun.",action:(q||status)?null:<Button color="accent" size="sm" iconStart="plus-squared" onClick={()=>setAdding(true)}>Yeni Satın Alma</Button>}}
        sort={sort} onSortChange={setSort} page={page} pageSize={PU_PAGE} total={es.total} onPageChange={setPage} rowKey={p=>p.id} onRowClick={p=>setDetail(p)}/>

      <Drawer open={!!detail} onClose={()=>setDetail(null)} size="md" title={detail?`Satın Alma ${detail.no}`:""} subtitle={detail?detail.supplier:""}>
        {detail && <PurchaseDetail p={detail} onReceive={onReceive}/>}
      </Drawer>
      <Drawer open={adding} onClose={()=>setAdding(false)} size="md" title="Yeni Satın Alma" subtitle="Tedarikçi siparişi oluştur">
        {adding && <NewPurchaseForm onCancel={()=>setAdding(false)} onSave={onSave}/>}
      </Drawer>
    </React.Fragment>
  );
}
window.PurchaseView = PurchaseView;
