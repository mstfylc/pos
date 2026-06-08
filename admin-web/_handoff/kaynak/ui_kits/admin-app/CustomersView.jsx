/* Screens 10-11 — Müşteriler + Müşteri Detayı (Tabs). window.CustomersView */
const CVMDS = window.MetronicDesignSystem_a73f8f;

const CV_CSS = `
.cv-cust{display:flex;align-items:center;gap:11px;}
.cv-cust__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.cv-cust__t span{font:var(--fw-regular) 11.5px/1 var(--font-sans);color:var(--text-muted);}
.cv-bal{font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.cv-pts{font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--color-accent);font-variant-numeric:tabular-nums;display:inline-flex;align-items:center;gap:5px;}
.cv-tier{display:inline-flex;align-items:center;gap:6px;font:var(--fw-semibold) 11.5px/1 var(--font-sans);padding:5px 10px;border-radius:999px;}
.cv-tier__d{width:8px;height:8px;border-radius:50%;}
.cv-tier--altin{background:var(--color-accent-soft);color:var(--color-accent-accent,#b5701b);}
.cv-tier--gumus{background:var(--color-grey-100);color:var(--text-body);}
.cv-tier--bronz{background:#f3e7da;color:#9a6b3f;}

/* detail */
.cd{display:flex;flex-direction:column;gap:20px;}
.cd-hero{display:flex;align-items:center;gap:18px;background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);padding:20px 22px;flex-wrap:wrap;}
.cd-hero__id{display:flex;align-items:center;gap:15px;flex:1;min-width:240px;}
.cd-hero__t b{font:var(--fw-bold) 19px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);display:flex;align-items:center;gap:10px;}
.cd-hero__t .meta{font:var(--fw-regular) 12.5px/1.5 var(--font-sans);color:var(--text-muted);margin-top:5px;display:flex;gap:14px;flex-wrap:wrap;}
.cd-hero__t .meta span{display:inline-flex;align-items:center;gap:5px;}
.cd-hero__stats{display:flex;gap:12px;}
.cd-stat{min-width:120px;padding:12px 16px;border-radius:var(--radius-md);background:var(--color-grey-50);border:1px solid var(--border-default);}
.cd-stat.acc{background:var(--color-accent-soft);border-color:#f1d2a8;}
.cd-stat__l{font:var(--fw-medium) 10.5px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;color:var(--text-placeholder);}
.cd-stat__v{font:var(--fw-bold) 20px/1 var(--font-sans);color:var(--text-heading);margin-top:7px;font-variant-numeric:tabular-nums;}
.cd-stat.acc .cd-stat__v{color:var(--color-accent-accent,#b5701b);}
.cd-panel{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.cd-panel__tabs{padding:4px 14px 0;border-bottom:1px solid var(--border-default);}
.cd-panel__body{padding:18px 20px;}
.cd-tbl{width:100%;border-collapse:collapse;}
.cd-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 0 11px;border-bottom:1px solid var(--border-default);}
.cd-tbl td{padding:11px 0;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);vertical-align:middle;}
.cd-tbl tr:last-child td{border-bottom:0;}
.cd-tbl .num{text-align:right;font-variant-numeric:tabular-nums;white-space:nowrap;}
.cd-mv{display:flex;align-items:center;gap:10px;}
.cd-mv__ic{width:30px;height:30px;border-radius:8px;flex:none;display:flex;align-items:center;justify-content:center;}
.cd-mv__t b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.cd-mv__t span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.cd-amt-pos{color:var(--color-success);font-weight:var(--fw-bold);}
.cd-amt-neg{color:var(--text-heading);font-weight:var(--fw-bold);}
.cd-note{display:flex;align-items:center;gap:8px;font:var(--fw-medium) 11.5px/1.4 var(--font-sans);color:var(--text-muted);background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:9px 12px;margin-bottom:14px;}
.cd-addr-grid{display:grid;grid-template-columns:1fr 1fr;gap:12px;}
@media(max-width:640px){.cd-addr-grid{grid-template-columns:1fr;}}
.cd-addr{border:1px solid var(--border-default);border-radius:var(--radius-md);padding:14px 16px;}
.cd-addr b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:flex;align-items:center;gap:8px;}
.cd-addr p{font:var(--fw-regular) 12.5px/1.6 var(--font-sans);color:var(--text-muted);margin-top:7px;}
.cd-sec-card{display:flex;align-items:flex-start;gap:14px;border:1px solid var(--border-default);border-radius:var(--radius-md);padding:16px 18px;margin-bottom:12px;}
.cd-sec-card__ic{width:40px;height:40px;border-radius:10px;background:var(--color-primary-soft);display:flex;align-items:center;justify-content:center;flex:none;}
.cd-sec-card__t b{font:var(--fw-semibold) 13.5px/1.3 var(--font-sans);color:var(--text-heading);display:block;}
.cd-sec-card__t span{font:var(--fw-regular) 12px/1.5 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;}
`;
function injectCV(){ if(document.getElementById('cv-css'))return; const e=document.createElement('style');e.id='cv-css';e.textContent=CV_CSS;document.head.appendChild(e); }

const TIERS={altin:{label:"Altın",cls:"altin",dot:"#e08a2b"},gumus:{label:"Gümüş",cls:"gumus",dot:"#9aa0ad"},bronz:{label:"Bronz",cls:"bronz",dot:"#b07a44"}};
function Tier({t}){ const m=TIERS[t]; return <span className={"cv-tier cv-tier--"+m.cls}><span className="cv-tier__d" style={{background:m.dot}}/>{m.label}</span>; }

const CV_NAMES=["Ahmet Yılmaz","Zeynep Korkmaz","Can Öztürk","Elif Aydın","Murat Çelik","Deniz Arslan","Selin Şahin","Burak Demir","Ece Yıldız","Mert Koç","Aslı Kaya","Emre Polat","Gizem Acar","Onur Taş","Ceren Ak","Kaan Er","Pınar Su","Tolga Bay","Nazlı Tan","Serkan Ün","Buse Al","Cem Or","Derya Ay","Hakan Iş"];
function buildCustomers(){
  const tiers=["altin","gumus","bronz","gumus","bronz","altin"];
  return CV_NAMES.map((name,i)=>{
    const tier=tiers[i%tiers.length];
    const balance=[0,45,120,260,30,500,75,0,180][i%9]*((i%3)+1);
    const points=tier==="altin"?1200+i*40:tier==="gumus"?500+i*25:120+i*12;
    const d=String(1+(i%28)).padStart(2,"0"), mo=String(1+(i%12)).padStart(2,"0");
    return { id:i, name, tier, balance, points,
      phone:"0532 "+(100+i)+" 45 "+String(10+i).slice(-2),
      email:name.toLowerCase().replace(/ /g,".").replace(/ç/g,"c").replace(/ş/g,"s").replace(/ı/g,"i").replace(/ğ/g,"g").replace(/ü/g,"u").replace(/ö/g,"o")+"@eposta.com",
      join:`${d}.${mo}.2024`,
    };
  });
}
const CV_DATA=buildCustomers();
const CV_PAGE=10;

function fmtTL(n){ return n.toLocaleString("tr-TR")+" ₺"; }

const BAL_MOVES=[
  {type:"yukleme",label:"Bakiye yükleme",desc:"Kredi kartı",date:"05.06.2026",amt:200,bal:380},
  {type:"harcama",label:"Sipariş ödemesi",desc:"UYK-2041",date:"04.06.2026",amt:-120,bal:180},
  {type:"iade",label:"İade",desc:"UYK-2038",date:"02.06.2026",amt:45,bal:300},
  {type:"harcama",label:"Sipariş ödemesi",desc:"UYK-2031",date:"28.05.2026",amt:-95,bal:255},
  {type:"yukleme",label:"Bakiye yükleme",desc:"Havale",date:"20.05.2026",amt:350,bal:350},
];
const PT_MOVES=[
  {type:"kazanim",label:"Puan kazanımı",desc:"UYK-2041 · 120 ₺",date:"04.06.2026",amt:12},
  {type:"kullanim",label:"Puan kullanımı",desc:"Ödül: Filtre Kahve",date:"01.06.2026",amt:-150},
  {type:"kazanim",label:"Puan kazanımı",desc:"UYK-2031 · 95 ₺",date:"28.05.2026",amt:9},
  {type:"sure",label:"Süresi dolan puan",desc:"2025 bakiyesi",date:"15.05.2026",amt:-40},
  {type:"kazanim",label:"Kampanya bonusu",desc:"Hoş geldin",date:"02.05.2026",amt:200},
];
const CUST_ORDERS=[
  {no:"UYK-2041",date:"04.06.2026",total:120,status:"tamamlandi"},
  {no:"UYK-2038",date:"02.06.2026",total:260,status:"iade"},
  {no:"UYK-2031",date:"28.05.2026",total:95,status:"tamamlandi"},
  {no:"UYK-2022",date:"19.05.2026",total:430,status:"tamamlandi"},
];
const BAL_ICON={yukleme:["check-circle","var(--color-success-soft)","var(--color-success)"],harcama:["handcart","var(--color-primary-soft)","var(--color-primary)"],iade:["share","var(--color-grey-100)","var(--text-muted)"]};
const PT_ICON={kazanim:["star","var(--color-accent-soft)","var(--color-accent)"],kullanim:["heart","var(--color-primary-soft)","var(--color-primary)"],sure:["time","var(--color-grey-100)","var(--text-muted)"]};

function CustomerDetail({ customer, onBack }){
  const { Tabs, Button, StatusBadge } = CVMDS;
  const toast = CVMDS.ToastProvider.useToast();
  const [tab,setTab]=React.useState("bakiye");
  const tabs=[{id:"bakiye",label:"Bakiye Hareketleri"},{id:"puan",label:"Puan Hareketleri"},{id:"siparis",label:"Siparişler",count:CUST_ORDERS.length},{id:"adres",label:"Adresler"},{id:"guvenlik",label:"Güvenlik"}];

  return (
    <div className="cd">
      <div className="cd-hero">
        <div className="cd-hero__id">
          <CVMDS.Avatar name={customer.name} size={56}/>
          <div className="cd-hero__t">
            <b>{customer.name} <Tier t={customer.tier}/></b>
            <div className="meta">
              <span><CVMDS.Icon name="message-notif" size={13} color="var(--text-placeholder)"/>{customer.phone}</span>
              <span><CVMDS.Icon name="messages" size={13} color="var(--text-placeholder)"/>{customer.email}</span>
              <span><CVMDS.Icon name="calendar" size={13} color="var(--text-placeholder)"/>Üyelik {customer.join}</span>
            </div>
          </div>
        </div>
        <div className="cd-hero__stats">
          <div className="cd-stat"><div className="cd-stat__l">Bakiye</div><div className="cd-stat__v">{fmtTL(customer.balance)}</div></div>
          <div className="cd-stat acc"><div className="cd-stat__l">Puan</div><div className="cd-stat__v">{customer.points.toLocaleString("tr-TR")}</div></div>
        </div>
      </div>

      <div className="cd-panel">
        <div className="cd-panel__tabs"><Tabs tabs={tabs} value={tab} onChange={setTab}/></div>
        <div className="cd-panel__body">
          {tab==="bakiye" && <>
            <div className="cd-note"><CVMDS.Icon name="shield-search" size={14} color="var(--text-muted)"/>Bakiye hareketleri yalnızca eklenir (append-only) — kayıtlar silinmez veya düzenlenmez.</div>
            <table className="cd-tbl"><thead><tr><th>Hareket</th><th>Tarih</th><th className="num">Tutar</th><th className="num">Bakiye</th></tr></thead><tbody>
              {BAL_MOVES.map((m,i)=>{ const ic=BAL_ICON[m.type]; return (
                <tr key={i}><td><div className="cd-mv"><span className="cd-mv__ic" style={{background:ic[1]}}><CVMDS.Icon name={ic[0]} size={15} color={ic[2]}/></span><div className="cd-mv__t"><b>{m.label}</b><span>{m.desc}</span></div></div></td>
                <td>{m.date}</td><td className={"num "+(m.amt>0?"cd-amt-pos":"cd-amt-neg")}>{m.amt>0?"+":""}{fmtTL(m.amt)}</td><td className="num" style={{color:"var(--text-muted)"}}>{fmtTL(m.bal)}</td></tr>
              );})}
            </tbody></table>
          </>}
          {tab==="puan" && <>
            <div className="cd-note"><CVMDS.Icon name="shield-search" size={14} color="var(--text-muted)"/>Puan hareketleri append-only kaydedilir; süresi dolan puanlar otomatik düşülür.</div>
            <table className="cd-tbl"><thead><tr><th>Hareket</th><th>Tarih</th><th className="num">Puan</th></tr></thead><tbody>
              {PT_MOVES.map((m,i)=>{ const ic=PT_ICON[m.type]; return (
                <tr key={i}><td><div className="cd-mv"><span className="cd-mv__ic" style={{background:ic[1]}}><CVMDS.Icon name={ic[0]} size={15} color={ic[2]}/></span><div className="cd-mv__t"><b>{m.label}</b><span>{m.desc}</span></div></div></td>
                <td>{m.date}</td><td className={"num "+(m.amt>0?"cd-amt-pos":"cd-amt-neg")}>{m.amt>0?"+":""}{m.amt.toLocaleString("tr-TR")}</td></tr>
              );})}
            </tbody></table>
          </>}
          {tab==="siparis" && <table className="cd-tbl"><thead><tr><th>Sipariş No</th><th>Tarih</th><th className="num">Tutar</th><th className="num">Durum</th></tr></thead><tbody>
            {CUST_ORDERS.map((o,i)=>(<tr key={i}><td><span style={{font:"var(--fw-semibold) 12.5px/1 var(--font-mono)",color:"var(--text-heading)"}}>{o.no}</span></td><td>{o.date}</td><td className="num" style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{fmtTL(o.total)}</td><td className="num"><StatusBadge status={o.status}/></td></tr>))}
          </tbody></table>}
          {tab==="adres" && <div className="cd-addr-grid">
            <div className="cd-addr"><b><CVMDS.Icon name="home" size={15} color="var(--color-primary)"/>Ev <CVMDS.Badge color="primary" variant="light" size="sm">Varsayılan</CVMDS.Badge></b><p>Çayyolu Mah. 2851. Cad. No:12 D:4<br/>Çankaya / Ankara<br/>{customer.phone}</p></div>
            <div className="cd-addr"><b><CVMDS.Icon name="folder" size={15} color="var(--text-muted)"/>İş</b><p>Üniversiteler Mah. İhsan Doğramacı Blv.<br/>Çankaya / Ankara<br/>{customer.phone}</p></div>
          </div>}
          {tab==="guvenlik" && <>
            <div className="cd-sec-card"><span className="cd-sec-card__ic"><CVMDS.Icon name="key" size={19} color="var(--color-primary)"/></span><div className="cd-sec-card__t" style={{flex:1}}><b>Parola sıfırlama</b><span>Müşteriye e-posta ile parola sıfırlama bağlantısı gönderilir. Mevcut parola görüntülenemez.</span></div><Button variant="outline" color="dark" iconStart="share" onClick={()=>toast({type:"success",title:"Bağlantı gönderildi",description:`${customer.email} adresine sıfırlama bağlantısı iletildi.`})}>Bağlantı gönder</Button></div>
            <div className="cd-sec-card"><span className="cd-sec-card__ic" style={{background:"var(--color-grey-100)"}}><CVMDS.Icon name="time" size={19} color="var(--text-muted)"/></span><div className="cd-sec-card__t"><b>Son giriş</b><span>06.06.2026 · 14:22 · Mobil uygulama (iOS)</span></div></div>
          </>}
        </div>
      </div>
    </div>
  );
}

function AddCustomerForm({ onCancel, onSave }){
  const { Input, Select, Button } = CVMDS;
  const today=new Date(); const j=`${String(today.getDate()).padStart(2,"0")}.${String(today.getMonth()+1).padStart(2,"0")}.${today.getFullYear()}`;
  const [v,setV]=React.useState({name:"",phone:"",email:"",tier:"bronz",balance:"",points:""});
  const [err,setErr]=React.useState({});
  const [tried,setTried]=React.useState(false);
  function validate(s){
    const e={};
    if(!s.name.trim()) e.name="Ad soyad zorunludur.";
    if(!s.phone.trim()) e.phone="Telefon zorunludur.";
    else if(s.phone.replace(/\D/g,"").length<10) e.phone="Geçerli bir telefon girin.";
    if(s.email && !/^[^@\s]+@[^@\s]+\.[^@\s]+$/.test(s.email)) e.email="Geçerli bir e-posta girin.";
    if(s.balance && (isNaN(Number(s.balance))||Number(s.balance)<0)) e.balance="Geçerli bir tutar girin.";
    if(s.points && (isNaN(Number(s.points))||Number(s.points)<0)) e.points="Geçerli bir puan girin.";
    setErr(e); return Object.keys(e).length===0;
  }
  function set(k,val){ const ns={...v,[k]:val}; setV(ns); if(tried) validate(ns); }
  function submit(){ setTried(true); if(validate(v)) onSave({name:v.name.trim(),phone:v.phone.trim(),email:v.email.trim()||(v.name.trim().toLowerCase().replace(/\s+/g,".")+"@eposta.com"),tier:v.tier,balance:Number(v.balance)||0,points:Number(v.points)||0,join:j}); }
  return (
    <div style={{display:"flex",flexDirection:"column",gap:16}}>
      <Input label="Ad Soyad" required placeholder="Örn. Ayşe Demir" value={v.name} onChange={e=>set("name",e.target.value)} error={err.name}/>
      <div style={{display:"grid",gridTemplateColumns:"1fr 1fr",gap:14}}>
        <Input label="Telefon" required placeholder="05•• ••• •• ••" value={v.phone} onChange={e=>set("phone",e.target.value)} error={err.phone} iconLead="message-notif"/>
        <Select label="Başlangıç seviyesi" value={v.tier} onChange={e=>set("tier",e.target.value)}>
          <option value="bronz">Bronz</option><option value="gumus">Gümüş</option><option value="altin">Altın</option>
        </Select>
      </div>
      <Input label="E-posta" placeholder="opsiyonel" value={v.email} onChange={e=>set("email",e.target.value)} error={err.email} hint={err.email?undefined:"Boş bırakılırsa otomatik oluşturulur"} iconLead="messages"/>
      <div style={{display:"grid",gridTemplateColumns:"1fr 1fr",gap:14}}>
        <Input label="Başlangıç bakiyesi" placeholder="0" value={v.balance} onChange={e=>set("balance",e.target.value)} error={err.balance} hint={err.balance?undefined:"₺"}/>
        <Input label="Başlangıç puanı" placeholder="0" value={v.points} onChange={e=>set("points",e.target.value)} error={err.points}/>
      </div>
      <div style={{display:"flex",justifyContent:"flex-end",gap:10,paddingTop:4}}>
        <Button variant="ghost" color="dark" onClick={onCancel}>İptal</Button>
        <Button color="accent" iconStart="check-circle" onClick={submit}>Müşteriyi kaydet</Button>
      </div>
    </div>
  );
}

function CustomersView(){
  React.useEffect(()=>{injectCV();},[]);
  const { DataGrid, Button, Input, Select, Drawer, Switch } = CVMDS;
  const toast = CVMDS.ToastProvider.useToast();
  const [data,setData]=React.useState(CV_DATA);
  const [addOpen,setAddOpen]=React.useState(false);
  const [loading,setLoading]=React.useState(true);
  const [demo,setDemo]=React.useState("full");
  const [q,setQ]=React.useState("");
  const [tier,setTier]=React.useState("");
  const [sort,setSort]=React.useState({key:"name",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [sel,setSel]=React.useState(null);

  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),600); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,tier]);

  const filtered=React.useMemo(()=>{
    let r=data.filter(c=>(!q||c.name.toLowerCase().includes(q.toLowerCase())||c.phone.includes(q))&&(!tier||c.tier===tier));
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{let x=a[sort.key],y=b[sort.key];if(typeof x==="string")return x.localeCompare(y,"tr")*dir;return (x-y)*dir;});
    return r;
  },[data,q,tier,sort]);
  const total=filtered.length, rows=filtered.slice((page-1)*CV_PAGE,page*CV_PAGE);
  const es=window.effState(demo,{loading,rows,total});

  if(sel) return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Müşteri & Sadakat","Müşteriler",sel.name]} title="Müşteri Detayı"
        actions={<Button variant="ghost" color="dark" iconStart="chevron-left" onClick={()=>setSel(null)}>Listeye dön</Button>}/>
      <CustomerDetail customer={sel} onBack={()=>setSel(null)}/>
    </React.Fragment>
  );

  const columns=[
    { key:"name", header:"Ad Soyad", sortable:true, render:c=><div className="cv-cust"><CVMDS.Avatar name={c.name} size={32}/><div className="cv-cust__t"><b>{c.name}</b><span>{c.email}</span></div></div> },
    { key:"phone", header:"Telefon", render:c=><span style={{font:"var(--fw-medium) 12.5px/1 var(--font-sans)"}}>{c.phone}</span> },
    { key:"balance", header:"Bakiye", align:"right", sortable:true, render:c=><span className="cv-bal">{fmtTL(c.balance)}</span> },
    { key:"points", header:"Puan", align:"right", sortable:true, render:c=><span className="cv-pts"><CVMDS.Icon name="star" size={13} color="var(--color-accent)"/>{c.points.toLocaleString("tr-TR")}</span> },
    { key:"tier", header:"Tier", render:c=><Tier t={c.tier}/> },
    { key:"join", header:"Kayıt Tarihi", align:"right", render:c=><span style={{color:"var(--text-muted)",fontSize:12.5}}>{c.join}</span> },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Müşteri & Sadakat","Müşteriler"]} title="Müşteriler"
        desc={`${data.length} kayıtlı müşteri`}
        actions={<><window.StatePreviewSeg demo={demo} setDemo={setDemo}/><Button color="accent" iconStart="plus-squared" onClick={()=>setAddOpen(true)}>Müşteri Ekle</Button></>}/>
      <div className="as-filter">
        <div style={{width:280}}><Input iconLead="magnifier" placeholder="Ad soyad veya telefon…" value={q} onChange={e=>setQ(e.target.value)}/></div>
        <div style={{width:160}}><Select value={tier} onChange={e=>setTier(e.target.value)}>
          <option value="">Tüm seviyeler</option><option value="altin">Altın</option><option value="gumus">Gümüş</option><option value="bronz">Bronz</option></Select></div>
        <div className="as-filter__sp"/>
        {(q||tier)&&<Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setTier("");}}>Temizle</Button>}
      </div>
      <DataGrid columns={columns} rows={es.rows} loading={es.loading} error={es.error} onRetry={()=>setDemo("full")}
        empty={{icon:"people",title:(q||tier)?"Müşteri bulunamadı":"Henüz müşteri yok",subtitle:(q||tier)?"Filtreleri değiştirip tekrar deneyin.":"İlk müşteriyi ekleyin.",action:(q||tier)?<Button variant="light" size="sm" onClick={()=>{setQ("");setTier("");}}>Filtreleri temizle</Button>:<Button color="accent" size="sm" iconStart="plus-squared" onClick={()=>setAddOpen(true)}>Müşteri Ekle</Button>}}
        sort={sort} onSortChange={setSort} page={page} pageSize={CV_PAGE} total={es.total} onPageChange={setPage}
        rowKey={c=>c.id} onRowClick={c=>setSel(c)}/>

      <Drawer open={addOpen} onClose={()=>setAddOpen(false)} size="md" title="Yeni Müşteri" subtitle="Sadakat programına yeni müşteri ekleyin">
        <AddCustomerForm onCancel={()=>setAddOpen(false)} onSave={(c)=>{
          const id=Math.max(...data.map(d=>d.id))+1;
          setData([{...c,id},...data]);
          setAddOpen(false);
          toast({type:"success",title:"Müşteri eklendi",description:`${c.name} sadakat programına kaydedildi.`});
        }}/>
      </Drawer>
    </React.Fragment>
  );
}
window.CustomersView = CustomersView;
