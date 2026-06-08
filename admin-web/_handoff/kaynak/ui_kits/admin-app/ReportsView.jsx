/* Screen 16 — Raporlar. window.ReportsView */
const RPMDS = window.MetronicDesignSystem_a73f8f;

const RP_CSS = `
.rp-kpis{display:grid;grid-template-columns:repeat(4,1fr);gap:16px;}
@media(max-width:900px){.rp-kpis{grid-template-columns:1fr 1fr;}}
.rp-kpi{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);padding:16px 18px;}
.rp-kpi__l{font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-muted);display:flex;align-items:center;gap:7px;}
.rp-kpi__v{font:var(--fw-bold) 26px/1 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);margin-top:11px;font-variant-numeric:tabular-nums;}
.rp-kpi__d{font:var(--fw-semibold) 11.5px/1 var(--font-sans);margin-top:8px;display:inline-flex;align-items:center;gap:4px;}
.rp-kpi__d.up{color:var(--color-success);} .rp-kpi__d.down{color:var(--color-danger);}
.rp-row{display:grid;grid-template-columns:1.6fr 1fr;gap:18px;margin-top:18px;align-items:start;}
@media(max-width:900px){.rp-row{grid-template-columns:1fr;}}
.rp-card{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);}
.rp-card__hd{display:flex;align-items:center;justify-content:space-between;padding:16px 18px;border-bottom:1px solid var(--border-default);}
.rp-card__hd b{font:var(--fw-semibold) 14px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.rp-card__bd{padding:18px;}
.rp-cat{display:flex;flex-direction:column;gap:13px;}
.rp-cat__row{display:flex;align-items:center;gap:11px;}
.rp-cat__dot{width:11px;height:11px;border-radius:3px;flex:none;}
.rp-cat__name{font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-body);flex:1;}
.rp-cat__bar{height:8px;border-radius:4px;background:var(--color-grey-100);width:130px;overflow:hidden;flex:none;}
.rp-cat__fill{height:100%;border-radius:4px;}
.rp-cat__pct{font:var(--fw-semibold) 12px/1 var(--font-sans);color:var(--text-heading);width:40px;text-align:right;font-variant-numeric:tabular-nums;}
.rp-tbl{width:100%;border-collapse:collapse;}
.rp-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 0 11px;border-bottom:1px solid var(--border-default);}
.rp-tbl td{padding:11px 0;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);}
.rp-tbl tr:last-child td{border-bottom:0;}
.rp-tbl .num{text-align:right;font-variant-numeric:tabular-nums;}
.rp-rank{width:22px;height:22px;border-radius:6px;background:var(--color-grey-100);display:inline-flex;align-items:center;justify-content:center;font:var(--fw-bold) 11px/1 var(--font-sans);color:var(--text-muted);}
.rp-rank.top{background:var(--color-accent-soft);color:var(--color-accent-accent,#b5701b);}
.rp-pay{display:flex;flex-direction:column;gap:12px;}
.rp-pay__row{display:flex;align-items:center;gap:11px;}
.rp-pay__ic{width:34px;height:34px;border-radius:9px;display:flex;align-items:center;justify-content:center;flex:none;}
.rp-pay__t{flex:1;}
.rp-pay__t b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.rp-pay__t span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.rp-pay__v{font:var(--fw-bold) 13px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.rp-seg{display:inline-flex;background:var(--color-grey-100);border-radius:9px;padding:3px;gap:2px;}
.rp-seg button{appearance:none;border:0;cursor:pointer;background:none;font:var(--fw-semibold) 12px/1 var(--font-sans);color:var(--text-muted);padding:7px 13px;border-radius:6px;transition:all .12s;}
.rp-seg button.on{background:var(--surface-card);color:var(--text-heading);box-shadow:var(--shadow-sm);}
`;
function injectRP(){ if(document.getElementById('rp-css'))return; const e=document.createElement('style');e.id='rp-css';e.textContent=RP_CSS;document.head.appendChild(e); }

const RP_RANGES={
  "7d":{ciro:"73.450", cd:"+12", siparis:"1.184", basket:"62", newc:"86",
    bars:[{l:"Pzt",v:8.2},{l:"Sal",v:9.4},{l:"Çar",v:7.1},{l:"Per",v:11.3},{l:"Cum",v:12.45},{l:"Cmt",v:14.8},{l:"Paz",v:10.2}]},
  "30d":{ciro:"312.800", cd:"+18", siparis:"4.920", basket:"64", newc:"240",
    bars:[{l:"1.H",v:68},{l:"2.H",v:74},{l:"3.H",v:79},{l:"4.H",v:91}]},
  "year":{ciro:"3.42M", cd:"+22", siparis:"58.400", basket:"59", newc:"2.840",
    bars:[{l:"Oca",v:240},{l:"Şub",v:255},{l:"Mar",v:268},{l:"Nis",v:280},{l:"May",v:298},{l:"Haz",v:312}]},
};
const RP_CATS=[
  {name:"Espresso Bazlı",color:"#3a2417",pct:38},
  {name:"Soğuk Kahve",color:"#1f6e8a",pct:22},
  {name:"Tatlı",color:"#7a1f3d",pct:15},
  {name:"Filtre Kahve",color:"#6f4a2f",pct:12},
  {name:"Atıştırmalık",color:"#2f6e3a",pct:8},
  {name:"Diğer",color:"#9aa0ad",pct:5},
];
const RP_TOP=[
  {name:"Caffè Latte",cat:"Espresso Bazlı",qty:248,rev:"19.840"},
  {name:"Filtre Kahve",cat:"Filtre Kahve",qty:210,rev:"13.650"},
  {name:"Cappuccino",cat:"Espresso Bazlı",qty:186,rev:"13.950"},
  {name:"Cheesecake",cat:"Tatlı",qty:142,rev:"15.620"},
  {name:"Cold Brew",cat:"Soğuk Kahve",qty:98,rev:"8.820"},
];
const RP_PAY=[
  {name:"Kredi/Banka Kartı",sub:"%58 · 687 işlem",val:"42.600",color:"#4921ea",icon:"price-tag"},
  {name:"Nakit",sub:"%28 · 332 işlem",val:"20.570",color:"#0bc33f",icon:"price-tag"},
  {name:"Yemek Kartı",sub:"%10 · 118 işlem",val:"7.345",color:"#e08a2b",icon:"price-tag"},
  {name:"Sadakat Puanı",sub:"%4 · 47 işlem",val:"2.935",color:"#1f3864",icon:"star"},
];

function RPBars({ data }){
  const w=560,h=200,padL=36,padR=8,padT=12,padB=28;
  const max=Math.max(...data.map(d=>d.v)), niceMax=Math.ceil(max/4)*4;
  const innerW=w-padL-padR, innerH=h-padT-padB, n=data.length, slot=innerW/n, bw=Math.min(40,slot*0.5);
  const peak=data.reduce((mi,d,i,a)=>d.v>a[mi].v?i:mi,0);
  return (
    <svg viewBox={`0 0 ${w} ${h}`} style={{width:"100%",height:"auto",display:"block"}}>
      {[0,.25,.5,.75,1].map((g,i)=>{const y=padT+g*innerH;return <g key={i}><line x1={padL} x2={w-padR} y1={y} y2={y} stroke="var(--border-default)" strokeDasharray={i===4?"0":"4 5"}/><text x={padL-8} y={y+4} textAnchor="end" fontSize="10" fontFamily="var(--font-sans)" fill="var(--text-placeholder)">{Math.round(niceMax*(1-g))}b</text></g>;})}
      {data.map((d,i)=>{const x=padL+slot*i+slot/2,bh=(d.v/niceMax)*innerH,y=padT+innerH-bh,isP=i===peak;return <g key={i}><rect x={x-bw/2} y={y} width={bw} height={bh} rx="5" fill={isP?"var(--color-primary)":"var(--color-primary-soft)"}/>{isP&&<text x={x} y={y-7} textAnchor="middle" fontSize="10.5" fontWeight="700" fontFamily="var(--font-sans)" fill="var(--color-primary)">{d.v}b</text>}<text x={x} y={h-9} textAnchor="middle" fontSize="11" fontFamily="var(--font-sans)" fontWeight={isP?"700":"500"} fill={isP?"var(--text-heading)":"var(--text-muted)"}>{d.l}</text></g>;})}
    </svg>
  );
}

function RPOverview(){
  const { Button } = RPMDS;
  const toast = RPMDS.ToastProvider.useToast();
  const [range,setRange]=React.useState("7d");
  const d=RP_RANGES[range];
  const rangeLabel={"7d":"Son 7 gün","30d":"Son 30 gün","year":"Bu yıl"}[range];

  return (
    <React.Fragment>
      <div style={{display:"flex",alignItems:"center",gap:12,marginBottom:18,flexWrap:"wrap"}}>
        <div className="rp-seg">
          {[["7d","7 Gün"],["30d","30 Gün"],["year","Yıl"]].map(([k,l])=><button key={k} className={range===k?"on":""} onClick={()=>setRange(k)}>{l}</button>)}
        </div>
        <span style={{font:"var(--fw-regular) 12.5px/1 var(--font-sans)",color:"var(--text-muted)"}}>Çayyolu Şubesi · {rangeLabel}</span>
        <Button variant="outline" color="dark" iconStart="files" style={{marginLeft:"auto"}} onClick={()=>toast({type:"success",title:"Rapor hazırlanıyor",description:`${rangeLabel} özeti PDF olarak indiriliyor…`})}>Dışa aktar</Button>
      </div>

      <div className="rp-kpis">
        <div className="rp-kpi"><div className="rp-kpi__l"><RPMDS.Icon name="price-tag" size={14} color="var(--color-primary)"/>Toplam Ciro</div><div className="rp-kpi__v">{d.ciro} ₺</div><div className="rp-kpi__d up"><RPMDS.Icon name="chart-line-up" size={12} color="var(--color-success)"/>{d.cd}% geçen döneme göre</div></div>
        <div className="rp-kpi"><div className="rp-kpi__l"><RPMDS.Icon name="handcart" size={14} color="var(--color-primary)"/>Sipariş Adedi</div><div className="rp-kpi__v">{d.siparis}</div><div className="rp-kpi__d up"><RPMDS.Icon name="chart-line-up" size={12} color="var(--color-success)"/>+9% artış</div></div>
        <div className="rp-kpi"><div className="rp-kpi__l"><RPMDS.Icon name="chart-pie-simple" size={14} color="var(--color-primary)"/>Ort. Sepet</div><div className="rp-kpi__v">{d.basket} ₺</div><div className="rp-kpi__d up"><RPMDS.Icon name="chart-line-up" size={12} color="var(--color-success)"/>+3% artış</div></div>
        <div className="rp-kpi"><div className="rp-kpi__l"><RPMDS.Icon name="heart" size={14} color="var(--color-accent)"/>Yeni Üye</div><div className="rp-kpi__v">{d.newc}</div><div className="rp-kpi__d up"><RPMDS.Icon name="chart-line-up" size={12} color="var(--color-success)"/>sadakat</div></div>
      </div>

      <div className="rp-row">
        <div className="rp-card">
          <div className="rp-card__hd"><b>Satış Trendi</b><span style={{font:"var(--fw-semibold) 13px/1 var(--font-sans)",color:"var(--text-heading)"}}>{d.ciro} ₺</span></div>
          <div className="rp-card__bd"><RPBars data={d.bars}/></div>
        </div>
        <div className="rp-card">
          <div className="rp-card__hd"><b>Kategori Dağılımı</b></div>
          <div className="rp-card__bd"><div className="rp-cat">
            {RP_CATS.map((c,i)=>(
              <div className="rp-cat__row" key={i}>
                <span className="rp-cat__dot" style={{background:c.color}}/>
                <span className="rp-cat__name">{c.name}</span>
                <span className="rp-cat__bar"><span className="rp-cat__fill" style={{width:c.pct+"%",background:c.color}}/></span>
                <span className="rp-cat__pct">%{c.pct}</span>
              </div>
            ))}
          </div></div>
        </div>
      </div>

      <div className="rp-row">
        <div className="rp-card">
          <div className="rp-card__hd"><b>En Çok Satan Ürünler</b><Button size="sm" variant="ghost" color="dark" iconEnd="chevron-right" onClick={()=>window.__adminNav&&window.__adminNav("products")}>Ürünler</Button></div>
          <div className="rp-card__bd">
            <table className="rp-tbl"><thead><tr><th style={{width:30}}>#</th><th>Ürün</th><th className="num">Adet</th><th className="num">Ciro</th></tr></thead><tbody>
              {RP_TOP.map((p,i)=><tr key={i}><td><span className={"rp-rank"+(i===0?" top":"")}>{i+1}</span></td><td><b style={{font:"var(--fw-semibold) 13px/1.2 var(--font-sans)",color:"var(--text-heading)"}}>{p.name}</b><div style={{font:"var(--fw-regular) 11px/1 var(--font-sans)",color:"var(--text-muted)",marginTop:2}}>{p.cat}</div></td><td className="num">{p.qty}</td><td className="num" style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{p.rev} ₺</td></tr>)}
            </tbody></table>
          </div>
        </div>
        <div className="rp-card">
          <div className="rp-card__hd"><b>Ödeme Kırılımı</b></div>
          <div className="rp-card__bd"><div className="rp-pay">
            {RP_PAY.map((p,i)=>(
              <div className="rp-pay__row" key={i}>
                <span className="rp-pay__ic" style={{background:p.color+"22"}}><RPMDS.Icon name={p.icon} size={16} color={p.color}/></span>
                <span className="rp-pay__t"><b>{p.name}</b><span>{p.sub}</span></span>
                <span className="rp-pay__v">{p.val} ₺</span>
              </div>
            ))}
          </div></div>
        </div>
      </div>
    </React.Fragment>
  );
}

function ReportsView(){
  React.useEffect(()=>{injectRP();},[]);
  const { Tabs } = RPMDS;
  const [tab,setTab]=React.useState("builder");
  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Yönetim","Raporlar"]} title="Raporlar"
        desc="Hazır panoyu incele ya da kendi raporunu oluşturup PDF / Excel / CSV indir."/>
      <div style={{marginBottom:18}}>
        <Tabs tabs={[{id:"builder",label:"Rapor Oluştur"},{id:"overview",label:"Genel Bakış"}]} value={tab} onChange={setTab}/>
      </div>
      {tab==="overview" ? <RPOverview/> : <window.ReportBuilder/>}
    </React.Fragment>
  );
}
window.ReportsView = ReportsView;
