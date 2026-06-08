/* eslint-disable */
import React from "react";
import { Card, CardHeader, CardBody, CardFooter, Badge, Button, Icon } from "@/design-system";

/* Uyanık Kütüphane — dashboard content: stat cards, weekly sales chart, top products, live orders. */

const LIB_DASH_CSS = `
.lbd-grid{display:grid;grid-template-columns:repeat(4,1fr);gap:18px;}
.lbd-stat{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);
  box-shadow:var(--shadow-sm);padding:18px 18px 16px;display:flex;flex-direction:column;gap:16px;position:relative;}
.lbd-stat--warn{border-color:#F1D2A8;background:linear-gradient(180deg,var(--color-accent-soft) 0%,var(--surface-card) 60%);}
.lbd-stat__top{display:flex;align-items:flex-start;justify-content:space-between;}
.lbd-stat__ic{width:44px;height:44px;border-radius:var(--radius-md);display:flex;align-items:center;justify-content:center;color:#fff;flex:none;}
.lbd-stat__big{font:var(--fw-bold) 30px/1 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.lbd-stat__lbl{font:var(--fw-medium) 13px/1.3 var(--font-sans);color:var(--text-muted);margin-top:6px;display:flex;align-items:center;gap:6px;}
.lbd-stat__warnlink{appearance:none;border:0;background:none;cursor:pointer;display:inline-flex;align-items:center;gap:4px;
  font:var(--fw-semibold) 12px/1 var(--font-sans);color:var(--color-accent);padding:0;}
.lbd-stat__warnlink:hover{color:var(--color-accent-active,#c6751c);}

.lbd-delta{display:inline-flex;align-items:center;gap:3px;font:var(--fw-semibold) 12px/1 var(--font-sans);
  padding:5px 8px;border-radius:var(--radius-sm,6px);}
.lbd-delta--up{color:var(--color-success);background:var(--color-success-soft,#E6F9EC);}
.lbd-delta--flat{color:var(--text-muted);background:var(--color-grey-100);}

.lbd-row{display:grid;grid-template-columns:7fr 5fr;gap:18px;margin-top:18px;align-items:start;}

/* chart */
.lbd-chart-hd{display:flex;align-items:center;justify-content:space-between;gap:16px;}
.lbd-chart-sum{display:flex;align-items:baseline;gap:10px;margin:14px 0 4px;}
.lbd-chart-sum b{font:var(--fw-bold) 26px/1 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.lbd-chart-sum span{font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-muted);}
.lbd-seg{display:inline-flex;background:var(--color-grey-100);border-radius:var(--radius-md);padding:3px;gap:2px;}
.lbd-seg button{appearance:none;border:0;cursor:pointer;background:none;font:var(--fw-semibold) 12.5px/1 var(--font-sans);
  color:var(--text-muted);padding:7px 14px;border-radius:7px;transition:all .13s;}
.lbd-seg button.on{background:var(--surface-card);color:var(--text-heading);box-shadow:var(--shadow-sm);}
.lbd-bar{cursor:pointer;transition:opacity .12s;}
.lbd-bar:hover{opacity:.82;}

/* products table */
.lbd-tbl{width:100%;border-collapse:collapse;}
.lbd-tbl th{text-align:left;font:var(--fw-semibold) 10.5px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;
  color:var(--text-placeholder);padding:0 0 13px;border-bottom:1px solid var(--border-default);}
.lbd-tbl td{padding:12px 0;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 13px/1.3 var(--font-sans);color:var(--text-body);vertical-align:middle;}
.lbd-tbl tr:last-child td{border-bottom:0;}
.lbd-book{display:flex;align-items:center;gap:13px;}
.lbd-cover{width:38px;height:38px;border-radius:10px;flex:none;display:flex;align-items:center;justify-content:center;
  box-shadow:0 2px 5px rgba(0,0,0,.14);overflow:hidden;}
.lbd-cover span{font:var(--fw-bold) 12px/1 var(--font-sans);color:rgba(255,255,255,.95);}
.lbd-book__t{display:flex;flex-direction:column;gap:3px;}
.lbd-book__t b{font:var(--fw-semibold) 13.5px/1.2 var(--font-sans);color:var(--text-heading);}
.lbd-book__t span{font:var(--fw-regular) 11.5px/1 var(--font-sans);color:var(--text-muted);}
.lbd-rank{width:20px;font:var(--fw-bold) 12px/1 var(--font-sans);color:var(--text-placeholder);text-align:center;}
.lbd-num{font:var(--fw-semibold) 13.5px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}

/* live orders */
.lbd-live-hd{display:flex;align-items:center;gap:8px;}
.lbd-pulse{width:8px;height:8px;border-radius:999px;background:var(--color-success);position:relative;}
.lbd-pulse::after{content:"";position:absolute;inset:-4px;border-radius:999px;border:2px solid var(--color-success);
  opacity:.5;animation:lbdPulse 1.8s ease-out infinite;}
@keyframes lbdPulse{0%{transform:scale(.6);opacity:.6;}100%{transform:scale(1.6);opacity:0;}}
.lbd-feed{display:flex;flex-direction:column;}
.lbd-order{display:flex;align-items:center;gap:13px;padding:13px 0;border-bottom:1px solid var(--border-default);}
.lbd-order:last-child{border-bottom:0;padding-bottom:0;}
.lbd-order:first-child{padding-top:0;}
.lbd-order__ic{width:38px;height:38px;border-radius:var(--radius-md);flex:none;display:flex;align-items:center;justify-content:center;
  background:var(--color-primary-soft);}
.lbd-order__m{flex:1;min-width:0;display:flex;flex-direction:column;gap:3px;}
.lbd-order__m b{font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-heading);white-space:nowrap;}
.lbd-order__m span{font:var(--fw-medium) 11.5px/1 var(--font-sans);color:var(--text-muted);display:flex;align-items:center;gap:5px;}
.lbd-order__r{display:flex;flex-direction:column;align-items:flex-end;gap:5px;flex:none;}
.lbd-order__amt{font:var(--fw-bold) 13.5px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
`;

function injectLibDash(){ if(document.getElementById('lb-dash-css'))return; const e=document.createElement('style');e.id='lb-dash-css';e.textContent=LIB_DASH_CSS;document.head.appendChild(e);}

/* ---- Weekly bar chart ---- */
function WeeklyBars({ data, unit }){
  const w=640, h=230, padL=40, padR=10, padT=14, padB=30;
  const max = Math.max(...data.map(d=>d.v));
  const niceMax = Math.ceil(max/4)*4;
  const innerW = w-padL-padR, innerH = h-padT-padB;
  const n = data.length;
  const slot = innerW/n;
  const bw = Math.min(34, slot*0.5);
  const [hover, setHover] = React.useState(null);
  const avg = data.reduce((a,d)=>a+d.v,0)/n;
  const avgY = padT + innerH - (avg/niceMax)*innerH;
  const peakIdx = data.reduce((mi,d,i,arr)=>d.v>arr[mi].v?i:mi,0);
  return (
    <svg viewBox={`0 0 ${w} ${h}`} style={{width:'100%',height:'auto',display:'block'}}>
      <defs>
        <linearGradient id="lbdbar" x1="0" y1="0" x2="0" y2="1">
          <stop offset="0%" stopColor="var(--color-primary)"/>
          <stop offset="100%" stopColor="var(--color-primary-accent,#14233f)"/>
        </linearGradient>
      </defs>
      {[0,0.25,0.5,0.75,1].map((g,i)=>{
        const y=padT+g*innerH; const val=Math.round(niceMax*(1-g));
        return (<g key={i}>
          <line x1={padL} x2={w-padR} y1={y} y2={y} stroke="var(--border-default)" strokeDasharray={i===4?"0":"4 5"}/>
          <text x={padL-10} y={y+4} textAnchor="end" fontSize="10.5" fontFamily="var(--font-sans)" fill="var(--text-placeholder)">{val}b</text>
        </g>);
      })}
      <line x1={padL} x2={w-padR} y1={avgY} y2={avgY} stroke="var(--color-accent)" strokeWidth="1.5" strokeDasharray="5 4" opacity="0.7"/>
      <text x={w-padR} y={avgY-6} textAnchor="end" fontSize="10" fontFamily="var(--font-sans)" fontWeight="600" fill="var(--color-accent)">ort {avg.toFixed(1)}b</text>
      {data.map((d,i)=>{
        const x=padL+slot*i+slot/2;
        const bh=(d.v/niceMax)*innerH;
        const y=padT+innerH-bh;
        const isPeak=i===peakIdx, isHover=hover===i;
        return (
          <g key={i} onMouseEnter={()=>setHover(i)} onMouseLeave={()=>setHover(null)} className="lbd-bar">
            <rect x={x-bw/2} y={padT} width={bw} height={innerH} fill="transparent"/>
            <rect x={x-bw/2} y={y} width={bw} height={bh} rx="5" fill={isPeak?"url(#lbdbar)":"var(--color-primary-soft)"}/>
            {isPeak && <rect x={x-bw/2} y={y} width={bw} height={bh} rx="5" fill="none"/>}
            {(isHover||isPeak) && <text x={x} y={y-8} textAnchor="middle" fontSize="11" fontWeight="700" fontFamily="var(--font-sans)" fill={isPeak?"var(--color-primary)":"var(--text-body)"}>{d.v.toLocaleString('tr-TR')}b ₺</text>}
            <text x={x} y={h-10} textAnchor="middle" fontSize="11.5" fontFamily="var(--font-sans)" fontWeight={isPeak?"700":"500"} fill={isPeak?"var(--text-heading)":"var(--text-muted)"}>{d.l}</text>
          </g>
        );
      })}
    </svg>
  );
}

function StatCard({icon,bg,big,label,delta,deltaDir,warn,onWarn}){
  return (
    <div className={"lbd-stat"+(warn?" lbd-stat--warn":"")}>
      <div className="lbd-stat__top">
        <div className="lbd-stat__ic" style={{background:bg}}><Icon name={icon} size={23} color="#fff"/></div>
        {delta && <span className={"lbd-delta "+(deltaDir==='up'?'lbd-delta--up':'lbd-delta--flat')}>
          {deltaDir==='up' && <Icon name="chart-line-up" size={13} color="var(--color-success)"/>}{delta}
        </span>}
      </div>
      <div>
        <div className="lbd-stat__big">{big}</div>
        <div className="lbd-stat__lbl">
          {label}
          {warn && <button className="lbd-stat__warnlink" onClick={onWarn}>İncele <Icon name="chevron-right" size={12} color="var(--color-accent)"/></button>}
        </div>
      </div>
    </div>
  );
}

const COVERS = [
  {c:"#3a2417",i:"CL"},{c:"#6f4a2f",i:"FK"},{c:"#9a4a1f",i:"CP"},{c:"#7a1f3d",i:"CK"},{c:"#1f5e7a",i:"CB"},
];
const TOP_PRODUCTS = [
  {t:"Caffè Latte",a:"Espresso Bazlı",qty:248,rev:"19.840 ₺",revN:19840},
  {t:"Filtre Kahve",a:"Filtre Kahve",qty:210,rev:"13.650 ₺",revN:13650},
  {t:"Cappuccino",a:"Espresso Bazlı",qty:186,rev:"13.950 ₺",revN:13950},
  {t:"Cheesecake",a:"Tatlı",qty:142,rev:"15.620 ₺",revN:15620},
  {t:"Cold Brew",a:"Soğuk Kahve",qty:98,rev:"8.820 ₺",revN:8820},
];

const ORDER_STATUS = {
  prep:{label:"Hazırlanıyor",color:"warning"},
  done:{label:"Tamamlandı",color:"success"},
  ship:{label:"Teslim edildi",color:"primary"},
  cancel:{label:"İptal",color:"danger"},
};
const LIVE_ORDERS = [
  {no:"UYK-2048",branch:"Çayyolu",amt:"248 ₺",st:"prep",t:"2 dk"},
  {no:"UYK-2047",branch:"Bağdat Cad.",amt:"512 ₺",st:"done",t:"5 dk"},
  {no:"UYK-2046",branch:"Çayyolu",amt:"96 ₺",st:"prep",t:"8 dk"},
  {no:"UYK-2045",branch:"Alsancak",amt:"1.340 ₺",st:"ship",t:"14 dk"},
  {no:"UYK-2044",branch:"Çayyolu",amt:"72 ₺",st:"cancel",t:"21 dk"},
  {no:"UYK-2043",branch:"Bağdat Cad.",amt:"430 ₺",st:"done",t:"26 dk"},
];

const RANGE_DATA = {
  today:     { ciro:"12.450 ₺", cd:"%8", siparis:"184", sd:"%5", uye:"1.240", ud:"+32",
               chartTotal:"12.450 ₺", chartNote:"%8 düne göre", peakNote:"bugün",
               bars:[{l:"09",v:0.9},{l:"11",v:1.8},{l:"13",v:2.6},{l:"15",v:1.9},{l:"17",v:2.4},{l:"19",v:1.6},{l:"21",v:1.25}], unit:"b ₺" },
  yesterday: { ciro:"11.530 ₺", cd:"%3", siparis:"171", sd:"%2", uye:"1.236", ud:"+18",
               chartTotal:"11.530 ₺", chartNote:"%4 önceki güne göre", peakNote:"dün",
               bars:[{l:"09",v:0.8},{l:"11",v:1.6},{l:"13",v:2.4},{l:"15",v:2.1},{l:"17",v:2.2},{l:"19",v:1.4},{l:"21",v:1.05}], unit:"b ₺" },
  "7d":      { ciro:"73.450 ₺", cd:"%12", siparis:"1.184", sd:"%9", uye:"1.240", ud:"+86",
               chartTotal:"73.450 ₺", chartNote:"%12 geçen haftaya göre", peakNote:"Cmt",
               bars:[{l:"Pzt",v:8.2},{l:"Sal",v:9.4},{l:"Çar",v:7.1},{l:"Per",v:11.3},{l:"Cum",v:12.45},{l:"Cmt",v:14.8},{l:"Paz",v:10.2}], unit:"b ₺" },
  "30d":     { ciro:"312.800 ₺", cd:"%18", siparis:"4.920", sd:"%14", uye:"1.240", ud:"+240",
               chartTotal:"312.800 ₺", chartNote:"%18 önceki 30 güne göre", peakNote:"4. hafta",
               bars:[{l:"1.H",v:68},{l:"2.H",v:74},{l:"3.H",v:79},{l:"4.H",v:91}], unit:"b ₺" },
  month:     { ciro:"168.200 ₺", cd:"%15", siparis:"2.640", sd:"%11", uye:"1.240", ud:"+128",
               chartTotal:"168.200 ₺", chartNote:"%15 geçen aya göre", peakNote:"3. hafta",
               bars:[{l:"1.H",v:38},{l:"2.H",v:42},{l:"3.H",v:48},{l:"4.H",v:40}], unit:"b ₺" },
  custom:    { ciro:"73.450 ₺", cd:"%12", siparis:"1.184", sd:"%9", uye:"1.240", ud:"+86",
               chartTotal:"73.450 ₺", chartNote:"seçili aralık", peakNote:"zirve",
               bars:[{l:"Pzt",v:8.2},{l:"Sal",v:9.4},{l:"Çar",v:7.1},{l:"Per",v:11.3},{l:"Cum",v:12.45},{l:"Cmt",v:14.8},{l:"Paz",v:10.2}], unit:"b ₺" },
};

function LibraryDashboard({ range="7d", onNavigate }){
  React.useEffect(()=>{injectLibDash();},[]);
  const [topSort, setTopSort] = React.useState("qty");
  const d = RANGE_DATA[range] || RANGE_DATA["7d"];
  const weekData = d.bars;
  const sortedTop = React.useMemo(()=>{
    const arr=[...TOP_PRODUCTS].sort((a,b)=>topSort==="qty"?b.qty-a.qty:b.revN-a.revN);
    const totalQty=arr.reduce((s,p)=>s+p.qty,0), totalRev=arr.reduce((s,p)=>s+p.revN,0);
    return arr.map((p,i)=>({...p,_cov:COVERS[i],_pct:Math.round((topSort==="qty"?p.qty/totalQty:p.revN/totalRev)*100)}));
  },[topSort]);

  return (
    <React.Fragment>
      {/* Stat cards */}
      <div className="lbd-grid">
        <StatCard icon="price-tag" bg="var(--color-primary)" big={d.ciro} label="Ciro" delta={d.cd} deltaDir="up"/>
        <StatCard icon="handcart" bg="var(--color-info)" big={d.siparis} label="Sipariş adedi" delta={d.sd} deltaDir="up"/>
        <StatCard icon="dots-square" bg="var(--color-accent)" big="7 ürün" label="Eşik-altı stok" warn onWarn={()=>onNavigate&&onNavigate("stock")}/>
        <StatCard icon="heart" bg="var(--color-success)" big={d.uye} label="Aktif sadakat üyesi" delta={d.ud} deltaDir="up"/>
      </div>

      <div className="lbd-row">
        {/* Weekly sales chart */}
        <Card>
          <CardHeader
            title="Satış trendi"
            subtitle="Çayyolu Şubesi"
            toolbar={
              <Button size="sm" variant="light" iconStart="chart-line-up" onClick={()=>onNavigate&&onNavigate("reports")}>Raporlar</Button>
            }
          />
          <CardBody>
            <div className="lbd-chart-sum">
              <b>{d.chartTotal}</b>
              <Badge color="success" variant="light" dot>{d.chartNote}</Badge>
            </div>
            <WeeklyBars data={weekData} unit={d.unit}/>
          </CardBody>
        </Card>

        {/* Live order feed */}
        <Card>
          <CardHeader
            title={<span className="lbd-live-hd"><span className="lbd-pulse"></span>Canlı sipariş akışı</span>}
            subtitle="Tüm şubeler"
            toolbar={<Button size="sm" variant="light" iconEnd="chevron-right" onClick={()=>onNavigate&&onNavigate("orders")}>Tümü</Button>}
          />
          <CardBody>
            <div className="lbd-feed">
              {LIVE_ORDERS.map((o,i)=>{
                const s=ORDER_STATUS[o.st];
                return (
                  <div className="lbd-order" key={i}>
                    <div className="lbd-order__ic"><Icon name="handcart" size={18} color="var(--color-primary)"/></div>
                    <div className="lbd-order__m">
                      <b>{"#"+o.no}</b>
                      <span style={{whiteSpace:'nowrap'}}><Icon name="home" size={12} color="var(--text-placeholder)"/>{o.branch} · {o.t} önce</span>
                    </div>
                    <div className="lbd-order__r">
                      <span className="lbd-order__amt">{o.amt}</span>
                      <Badge color={s.color} variant="light" size="sm">{s.label}</Badge>
                    </div>
                  </div>
                );
              })}
            </div>
          </CardBody>
        </Card>
      </div>

      {/* Best-selling products */}
      <div style={{marginTop:18}}>
        <Card>
          <CardHeader
            title="En çok satan ürünler"
            subtitle={"Bu hafta · "+(topSort==="qty"?"adet":"ciro")+" bazında"}
            toolbar={<div className="lbd-seg">
              <button className={topSort==="qty"?"on":""} onClick={()=>setTopSort("qty")}>Adet</button>
              <button className={topSort==="rev"?"on":""} onClick={()=>setTopSort("rev")}>Ciro</button>
            </div>}
          />
          <CardBody>
            <table className="lbd-tbl">
              <thead><tr>
                <th style={{width:32}}>#</th>
                <th>Ürün</th>
                <th style={{textAlign:'right'}}>Satış adedi</th>
                <th style={{textAlign:'right'}}>Ciro</th>
                <th style={{width:90,textAlign:'right'}}>Pay</th>
              </tr></thead>
              <tbody>
                {sortedTop.map((p,i)=>{
                  const cov=p._cov;
                  const pct=p._pct;
                  return (
                    <tr key={i}>
                      <td><div className="lbd-rank">{i+1}</div></td>
                      <td>
                        <div className="lbd-book">
                          <div className="lbd-cover" style={{background:cov.c}}><span>{cov.i}</span></div>
                          <div className="lbd-book__t"><b>{p.t}</b><span>{p.a}</span></div>
                        </div>
                      </td>
                      <td style={{textAlign:'right'}}><span className="lbd-num">{p.qty}</span> <span style={{color:'var(--text-muted)',fontSize:11}}>adet</span></td>
                      <td style={{textAlign:'right'}}><span className="lbd-num">{p.rev}</span></td>
                      <td style={{textAlign:'right'}}><Badge color={i===0?"primary":"secondary"} variant="light" size="sm">%{pct}</Badge></td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </CardBody>
          <CardFooter>
            <span style={{font:'var(--fw-medium) 12px/1 var(--font-sans)',color:'var(--text-muted)'}}>Menüdeki 29 üründen ilk 5'i</span>
            <div style={{marginLeft:'auto'}}><Button size="sm" variant="ghost" iconEnd="chevron-right" onClick={()=>onNavigate&&onNavigate("products")}>Tüm ürünler</Button></div>
          </CardFooter>
        </Card>
      </div>
    </React.Fragment>
  );
}

export default LibraryDashboard;
