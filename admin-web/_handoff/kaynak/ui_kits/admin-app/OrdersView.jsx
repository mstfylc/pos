/* Screens 2-3 — Sipariş Listesi + Sipariş Detayı (Drawer). window.OrdersView */
const OVMDS = window.MetronicDesignSystem_a73f8f;

const OV_CSS = `
.ov-no{font:var(--fw-semibold) 13px/1 var(--font-mono);color:var(--text-heading);}
.ov-cust{display:flex;align-items:center;gap:9px;}
.ov-cust__t b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.ov-cust__t span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.ov-amt{font:var(--fw-bold) 13px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.ov-dt{font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);}
.ov-dt span{display:block;font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.ov-pay{display:inline-flex;align-items:center;gap:5px;font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-body);}
.ov-pay__d{width:7px;height:7px;border-radius:2px;flex:none;}

/* ---- detail ---- */
.od{display:flex;flex-direction:column;gap:20px;}
.od-hd{display:flex;align-items:flex-start;justify-content:space-between;gap:16px;padding-bottom:18px;border-bottom:1px solid var(--border-default);}
.od-hd__no{font:var(--fw-bold) 19px/1 var(--font-mono);color:var(--text-heading);letter-spacing:-0.01em;}
.od-hd__meta{font:var(--fw-regular) 12px/1.5 var(--font-sans);color:var(--text-muted);margin-top:6px;}
.od-grid2{display:grid;grid-template-columns:1fr 1fr;gap:12px;}
.od-info{background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:12px 14px;}
.od-info__l{font:var(--fw-medium) 10.5px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;color:var(--text-placeholder);}
.od-info__v{font:var(--fw-semibold) 13px/1.3 var(--font-sans);color:var(--text-heading);margin-top:5px;display:flex;align-items:center;gap:7px;}
.od-sec{font:var(--fw-semibold) 11px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.06em;color:var(--text-muted);margin-bottom:11px;}
.od-tbl{width:100%;border-collapse:collapse;}
.od-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 0 9px;border-bottom:1px solid var(--border-default);}
.od-tbl td{padding:10px 0;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);vertical-align:top;}
.od-tbl tr:last-child td{border-bottom:0;}
.od-tbl .num{text-align:right;font-variant-numeric:tabular-nums;white-space:nowrap;}
.od-li b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.od-li span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.od-pay-row{display:flex;align-items:center;justify-content:space-between;padding:10px 12px;border:1px solid var(--border-default);border-radius:var(--radius-md);margin-bottom:8px;}
.od-pay-row:last-child{margin-bottom:0;}
.od-pay-row__l{display:flex;align-items:center;gap:9px;font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);}
.od-pay-row__ic{width:30px;height:30px;border-radius:8px;background:var(--color-primary-soft);display:flex;align-items:center;justify-content:center;flex:none;}
.od-pay-row__v{font:var(--fw-bold) 13px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.od-sum{background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:14px 16px;}
.od-sum__r{display:flex;align-items:center;justify-content:space-between;padding:6px 0;font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-body);}
.od-sum__r.tot{border-top:1px solid var(--border-default);margin-top:6px;padding-top:11px;font:var(--fw-bold) 16px/1 var(--font-sans);color:var(--text-heading);}
.od-sum__r .v{font-variant-numeric:tabular-nums;}
.od-sum__r .disc{color:var(--color-success);}
.od-loyal{display:flex;gap:10px;}
.od-loyal__card{flex:1;border:1px solid var(--border-default);border-radius:var(--radius-md);padding:13px 14px;}
.od-loyal__card b{font:var(--fw-bold) 18px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;display:flex;align-items:center;gap:6px;}
.od-loyal__card span{font:var(--fw-medium) 11.5px/1 var(--font-sans);color:var(--text-muted);margin-top:5px;display:block;}
.od-loyal__card.earn b{color:var(--color-accent);}
/* timeline */
.od-tl{display:flex;flex-direction:column;}
.od-tl__i{display:flex;gap:12px;padding-bottom:16px;position:relative;}
.od-tl__i:last-child{padding-bottom:0;}
.od-tl__i::before{content:"";position:absolute;left:8px;top:18px;bottom:-2px;width:2px;background:var(--border-default);}
.od-tl__i:last-child::before{display:none;}
.od-tl__dot{width:18px;height:18px;border-radius:50%;flex:none;display:flex;align-items:center;justify-content:center;z-index:1;background:var(--surface-card);box-shadow:0 0 0 3px var(--surface-card);}
.od-tl__c{display:flex;flex-direction:column;gap:2px;padding-top:0;}
.od-tl__c b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);}
.od-tl__c span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
`;
function injectOV(){ if(document.getElementById('ov-css'))return; const e=document.createElement('style');e.id='ov-css';e.textContent=OV_CSS;document.head.appendChild(e); }

const PAY = {
  nakit:{label:"Nakit",color:"#0bc33f",icon:"price-tag"},
  kart:{label:"Kart",color:"#4921ea",icon:"price-tag"},
  yemek:{label:"Yemek Kartı",color:"#e08a2b",icon:"price-tag"},
  puan:{label:"Puan",color:"#1f3864",icon:"star"},
  karisik:{label:"Karışık",color:"#78829d",icon:"dots-square"},
};
const BRANCHES=["Çayyolu","Bağdat Cad.","Alsancak"];
const CASHIERS=["Selin Aydın","Mert Demir","Ece Kaya","Burak Şahin"];
const CUSTOMERS=["Ahmet Yılmaz","Zeynep Korkmaz","Can Öztürk","Elif Aydın","Murat Çelik","Deniz Arslan","Misafir"];

function fmtPrice(n){ return n.toLocaleString("tr-TR")+" ₺"; }

function buildOrders(){
  const statuses=["alindi","hazirlaniyor","tamamlandi","tamamlandi","tamamlandi","iptal","iade"];
  const itemsPool=[["Caffè Latte",80],["Americano",60],["Filtre Kahve",65],["Cappuccino",75],["Cheesecake",110],["Cold Brew",90],["Brownie",95],["Kruvasan",70],["Sıcak Çikolata",70],["Limonata",55]];
  const out=[];
  for(let i=0;i<46;i++){
    const no="UYK-"+(2048-i);
    const st=statuses[i%statuses.length];
    const branch=BRANCHES[i%BRANCHES.length];
    const cashier=CASHIERS[i%CASHIERS.length];
    const customer=CUSTOMERS[i%CUSTOMERS.length];
    const nItems=1+(i%4);
    const items=[]; let subtotal=0;
    for(let j=0;j<nItems;j++){
      const p=itemsPool[(i+j)%itemsPool.length]; const qty=1+((i+j)%3);
      const lineDisc=(i+j)%5===0?Math.round(p[1]*0.1):0;
      const lineTotal=p[1]*qty-lineDisc; subtotal+=lineTotal;
      items.push({name:p[0],qty,unit:p[1],lineDisc,lineTotal});
    }
    const discount=i%4===0?Math.round(subtotal*0.05):0;
    const grand=subtotal-discount;
    const kdv=Math.round(grand-grand/1.1);
    // payment
    let payments, payKey;
    if(i%6===0){ payments=[{type:"nakit",amount:Math.round(grand*0.6)},{type:"kart",amount:grand-Math.round(grand*0.6)}]; payKey="karisik"; }
    else if(i%3===0){ payments=[{type:"nakit",amount:grand}]; payKey="nakit"; }
    else if(i%3===1){ payments=[{type:"kart",amount:grand}]; payKey="kart"; }
    else { payments=[{type:"yemek",amount:grand}]; payKey="yemek"; }
    const paid=payments.reduce((a,p)=>a+p.amount,0);
    const change=payKey==="nakit"?Math.max(0,(Math.ceil(grand/10)*10)-grand):0;
    const day=String(7-(i%6)).padStart(2,"0");
    const hh=String(9+(i%9)).padStart(2,"0"), mm=String((i*7)%60).padStart(2,"0");
    out.push({
      no, status:st, branch, pos:"POS-"+(1+(i%3)), cashier, customer,
      phone: customer==="Misafir"?null:"0532 "+(100+i)+" 45 "+String(10+i).slice(-2),
      date:`${day}.06.2026`, time:`${hh}:${mm}`,
      items, subtotal, discount, kdv, grand, payments, payKey, paid, change,
      pointsEarned: customer==="Misafir"?0:Math.round(grand/10),
      pointsUsed: i%7===0?120:0,
      id:i,
    });
  }
  return out;
}
const OV_DATA=buildOrders();
const OV_PAGE=10;

function OrderDetail({ order, onCancel }){
  const { Button, StatusBadge } = OVMDS;
  const histBase=[
    {status:"alindi",label:"Sipariş alındı",time:order.time,by:order.cashier},
    {status:"hazirlaniyor",label:"Hazırlanmaya başlandı",time:addMin(order.time,2),by:order.cashier},
    {status:"tamamlandi",label:"Tamamlandı / teslim",time:addMin(order.time,9),by:order.cashier},
  ];
  let history;
  if(order.status==="alindi") history=histBase.slice(0,1);
  else if(order.status==="hazirlaniyor") history=histBase.slice(0,2);
  else if(order.status==="iptal") history=[histBase[0],{status:"iptal",label:"Sipariş iptal edildi",time:addMin(order.time,4),by:order.cashier}];
  else if(order.status==="iade") history=[...histBase,{status:"iade",label:"İade işlendi",time:addMin(order.time,40),by:order.cashier}];
  else history=histBase;
  const canCancel=order.status==="alindi"||order.status==="hazirlaniyor"||order.status==="tamamlandi";

  return (
    <div className="od">
      <div className="od-hd">
        <div>
          <div className="od-hd__no">{order.no}</div>
          <div className="od-hd__meta">{order.date} · {order.time} · {order.branch} · {order.pos}</div>
        </div>
        <StatusBadge status={order.status} size="lg"/>
      </div>

      <div className="od-grid2">
        <div className="od-info"><div className="od-info__l">Müşteri</div><div className="od-info__v"><OVMDS.Avatar name={order.customer} size={22}/>{order.customer}</div></div>
        <div className="od-info"><div className="od-info__l">Kasiyer</div><div className="od-info__v">{order.cashier}</div></div>
      </div>

      <div>
        <div className="od-sec">Ürünler</div>
        <table className="od-tbl">
          <thead><tr><th>Ürün</th><th className="num">Adet</th><th className="num">Birim</th><th className="num">İnd.</th><th className="num">Toplam</th></tr></thead>
          <tbody>
            {order.items.map((it,i)=>(
              <tr key={i}>
                <td><div className="od-li"><b>{it.name}</b></div></td>
                <td className="num">{it.qty}×</td>
                <td className="num">{fmtPrice(it.unit)}</td>
                <td className="num">{it.lineDisc?<span style={{color:"var(--color-success)"}}>-{fmtPrice(it.lineDisc)}</span>:"—"}</td>
                <td className="num" style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{fmtPrice(it.lineTotal)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="od-grid2" style={{alignItems:"start"}}>
        <div>
          <div className="od-sec">Ödeme Kırılımı</div>
          {order.payments.map((p,i)=>{ const meta=PAY[p.type]; return (
            <div className="od-pay-row" key={i}>
              <span className="od-pay-row__l"><span className="od-pay-row__ic"><OVMDS.Icon name={meta.icon} size={15} color="var(--color-primary)"/></span>{meta.label}</span>
              <span className="od-pay-row__v">{fmtPrice(p.amount)}</span>
            </div>
          );})}
          <div className="od-pay-row" style={{background:"var(--color-grey-50)",border:"0"}}>
            <span className="od-pay-row__l" style={{color:"var(--text-muted)",fontWeight:"var(--fw-medium)"}}>Para üstü</span>
            <span className="od-pay-row__v" style={{color:order.change?"var(--text-heading)":"var(--text-placeholder)"}}>{fmtPrice(order.change)}</span>
          </div>
        </div>
        <div>
          <div className="od-sec">Özet</div>
          <div className="od-sum">
            <div className="od-sum__r"><span>Ara toplam</span><span className="v">{fmtPrice(order.subtotal)}</span></div>
            <div className="od-sum__r"><span>KDV (dahil)</span><span className="v">{fmtPrice(order.kdv)}</span></div>
            {order.discount>0 && <div className="od-sum__r"><span>İndirim</span><span className="v disc">-{fmtPrice(order.discount)}</span></div>}
            <div className="od-sum__r tot"><span>Genel toplam</span><span className="v">{fmtPrice(order.grand)}</span></div>
          </div>
        </div>
      </div>

      <div>
        <div className="od-sec">Sadakat</div>
        <div className="od-loyal">
          <div className="od-loyal__card earn"><b><OVMDS.Icon name="star" size={16} color="var(--color-accent)"/>+{order.pointsEarned}</b><span>Kazanılan puan</span></div>
          <div className="od-loyal__card"><b>{order.pointsUsed||0}</b><span>Kullanılan puan</span></div>
        </div>
      </div>

      <div>
        <div className="od-sec">Durum Geçmişi</div>
        <div className="od-tl">
          {history.map((h,i)=>{ const last=i===history.length-1; const danger=h.status==="iptal"||h.status==="iade";
            return (
            <div className="od-tl__i" key={i}>
              <div className="od-tl__dot"><OVMDS.Icon name={danger?"cross-circle":(last?"check-circle":"time")} size={18} color={danger?"var(--color-danger)":(last?"var(--color-success)":"var(--color-primary)")}/></div>
              <div className="od-tl__c"><b>{h.label}</b><span>{order.date} · {h.time} · {h.by}</span></div>
            </div>
          );})}
        </div>
      </div>

      {canCancel && (
        <div style={{display:"flex",gap:10,borderTop:"1px solid var(--border-default)",paddingTop:16}}>
          <Button variant="outline" color="danger" iconStart="cross-circle" onClick={()=>onCancel("iptal")}>Siparişi iptal et</Button>
          {order.status==="tamamlandi" && <Button variant="outline" color="dark" iconStart="share" onClick={()=>onCancel("iade")}>İade başlat</Button>}
        </div>
      )}
    </div>
  );
}
function addMin(t,m){ const[h,mm]=t.split(":").map(Number); const tot=h*60+mm+m; return String(Math.floor(tot/60)%24).padStart(2,"0")+":"+String(tot%60).padStart(2,"0"); }

function OrdersView(){
  React.useEffect(()=>{injectOV();},[]);
  const { DataGrid, StatusBadge, Button, Input, Select, Drawer, Modal, Textarea } = OVMDS;
  const toast = OVMDS.ToastProvider.useToast();
  const [loading,setLoading]=React.useState(true);
  const [demo,setDemo]=React.useState("full");
  const [q,setQ]=React.useState("");
  const [range,setRange]=React.useState("");
  const [branch,setBranch]=React.useState("");
  const [status,setStatus]=React.useState("");
  const [pay,setPay]=React.useState("");
  const [sort,setSort]=React.useState({key:"no",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [data,setData]=React.useState(OV_DATA);
  const [detail,setDetail]=React.useState(null);
  const [cancel,setCancel]=React.useState(null); // {order, mode}
  const [reason,setReason]=React.useState("");

  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),600); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,range,branch,status,pay]);

  const filtered=React.useMemo(()=>{
    let r=data.filter(o=>
      (!q || o.no.toLowerCase().includes(q.toLowerCase()) || o.customer.toLowerCase().includes(q.toLowerCase())) &&
      (!branch || o.branch===branch) && (!status || o.status===status) && (!pay || o.payKey===pay)
    );
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{ let x=a[sort.key],y=b[sort.key]; if(typeof x==="string")return x.localeCompare(y,"tr")*dir; return (x-y)*dir; });
    return r;
  },[data,q,branch,status,pay,sort]);
  const total=filtered.length;
  const rows=filtered.slice((page-1)*OV_PAGE,page*OV_PAGE);
  const es=window.effState(demo,{loading,rows,total});

  function doCancel(){
    const mode=cancel.mode;
    setData(data.map(o=>o.id===cancel.order.id?{...o,status:mode}:o));
    setDetail(d=>d&&d.id===cancel.order.id?{...d,status:mode}:d);
    toast({type:mode==="iptal"?"error":"warning",title:mode==="iptal"?"Sipariş iptal edildi":"İade başlatıldı",description:`${cancel.order.no} · ${reason||"Neden belirtilmedi"}`});
    setCancel(null); setReason("");
  }

  const columns=[
    { key:"no", header:"Sipariş No", sortable:true, render:o=><span className="ov-no">{o.no}</span> },
    { key:"date", header:"Tarih / Saat", sortable:true, render:o=><div className="ov-dt">{o.date}<span>{o.time}</span></div> },
    { key:"branch", header:"Şube", render:o=><span>{o.branch}<br/><span style={{font:"var(--fw-regular) 10.5px/1 var(--font-mono)",color:"var(--text-muted)"}}>{o.pos}</span></span> },
    { key:"cashier", header:"Kasiyer", render:o=><span style={{fontSize:12.5}}>{o.cashier}</span> },
    { key:"customer", header:"Müşteri", render:o=>(
      <div className="ov-cust"><OVMDS.Avatar name={o.customer} size={26}/><div className="ov-cust__t"><b>{o.customer}</b>{o.phone&&<span>{o.phone}</span>}</div></div>) },
    { key:"grand", header:"Tutar", align:"right", sortable:true, render:o=><span className="ov-amt">{fmtPrice(o.grand)}</span> },
    { key:"payKey", header:"Ödeme", render:o=>{ const m=PAY[o.payKey]; return <span className="ov-pay"><span className="ov-pay__d" style={{background:m.color}}/>{m.label}</span>; } },
    { key:"status", header:"Durum", align:"right", render:o=><StatusBadge status={o.status}/> },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader
        crumb={["Genel","Siparişler"]} title="Siparişler"
        desc={`${data.length} sipariş · ${data.filter(o=>o.status==="hazirlaniyor").length} hazırlanıyor`}
        actions={<><window.StatePreviewSeg demo={demo} setDemo={setDemo}/><Button variant="outline" color="dark" iconStart="files" onClick={()=>toast({type:"success",title:"Dışa aktarılıyor",description:`${total} sipariş CSV olarak hazırlanıyor…`})}>Dışa aktar</Button></>}
      />

      <div className="as-filter">
        <div style={{width:240}}><Input iconLead="magnifier" placeholder="Sipariş no veya müşteri…" value={q} onChange={e=>setQ(e.target.value)}/></div>
        <div style={{width:150}}><Select value={range} onChange={e=>setRange(e.target.value)}>
          <option value="">Tüm tarihler</option><option>Bugün</option><option>Son 7 gün</option><option>Bu ay</option></Select></div>
        <div style={{width:150}}><Select value={branch} onChange={e=>setBranch(e.target.value)}>
          <option value="">Tüm şubeler</option>{BRANCHES.map(b=><option key={b} value={b}>{b}</option>)}</Select></div>
        <div style={{width:160}}><Select value={status} onChange={e=>setStatus(e.target.value)}>
          <option value="">Tüm durumlar</option><option value="alindi">Alındı</option><option value="hazirlaniyor">Hazırlanıyor</option><option value="tamamlandi">Tamamlandı</option><option value="iptal">İptal</option><option value="iade">İade</option></Select></div>
        <div style={{width:140}}><Select value={pay} onChange={e=>setPay(e.target.value)}>
          <option value="">Tüm ödemeler</option><option value="nakit">Nakit</option><option value="kart">Kart</option><option value="yemek">Yemek Kartı</option><option value="karisik">Karışık</option></Select></div>
        <div className="as-filter__sp"/>
        {(q||range||branch||status||pay)&&<Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setRange("");setBranch("");setStatus("");setPay("");}}>Temizle</Button>}
      </div>

      <DataGrid columns={columns} rows={es.rows} loading={es.loading} error={es.error} onRetry={()=>setDemo("full")}
        empty={{icon:"handcart",title:(q||branch||status||pay)?"Sipariş bulunamadı":"Henüz sipariş yok",subtitle:(q||branch||status||pay)?"Filtreleri değiştirip tekrar deneyin.":"Yeni siparişler burada listelenir.",
          action:(q||branch||status||pay)?<Button variant="light" size="sm" onClick={()=>{setQ("");setRange("");setBranch("");setStatus("");setPay("");}}>Filtreleri temizle</Button>:null}}
        sort={sort} onSortChange={setSort} page={page} pageSize={OV_PAGE} total={es.total} onPageChange={setPage}
        rowKey={o=>o.id} onRowClick={o=>setDetail(o)}/>

      <Drawer open={!!detail} onClose={()=>setDetail(null)} size="lg"
        title={detail?`Sipariş ${detail.no}`:""} subtitle={detail?`${detail.branch} · ${detail.date}`:""}>
        {detail && <OrderDetail order={detail} onCancel={(mode)=>setCancel({order:detail,mode})}/>}
      </Drawer>

      <Modal open={!!cancel} onClose={()=>{setCancel(null);setReason("");}} tone={cancel?.mode==="iade"?"warning":"danger"}
        icon={cancel?.mode==="iade"?"share":"cross-circle"}
        title={cancel?.mode==="iade"?"İade başlat":"Siparişi iptal et"}
        subtitle={cancel?`${cancel.order.no} · ${fmtPrice(cancel.order.grand)} — işlem geri alınamaz.`:""}
        footer={<>
          <Button variant="ghost" color="dark" onClick={()=>{setCancel(null);setReason("");}}>Vazgeç</Button>
          <Button color="danger" iconStart="check-circle" disabled={!reason.trim()} onClick={doCancel}>{cancel?.mode==="iade"?"İadeyi onayla":"İptali onayla"}</Button>
        </>}>
        <Textarea label="İşlem nedeni" required rows={3} placeholder="Neden zorunludur (örn. müşteri vazgeçti, yanlış ürün)…"
          value={reason} onChange={e=>setReason(e.target.value)}/>
      </Modal>
    </React.Fragment>
  );
}
window.OrdersView = OrdersView;
