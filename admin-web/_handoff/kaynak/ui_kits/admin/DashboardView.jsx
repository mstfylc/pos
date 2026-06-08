/* Dashboard view — stat cards, earnings chart, highlights, teams table. */
const D = window.MetronicDesignSystem_a73f8f;

const DASH_CSS = `
.dw-grid{display:grid;grid-template-columns:repeat(4,1fr);gap:18px;}
.dw-stat{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);
  box-shadow:var(--shadow-sm);padding:18px;display:flex;flex-direction:column;gap:14px;}
.dw-stat__ic{width:42px;height:42px;border-radius:var(--radius-md);display:flex;align-items:center;justify-content:center;color:#fff;}
.dw-stat__big{font:var(--fw-bold) 28px/1 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.dw-stat__lbl{font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-muted);margin-top:5px;}
.dw-row{display:grid;grid-template-columns:5fr 7fr;gap:18px;margin-top:18px;}
.dw-row2{display:grid;grid-template-columns:7fr 5fr;gap:18px;margin-top:18px;}
.dw-legend{display:flex;flex-direction:column;gap:11px;}
.dw-leg{display:flex;align-items:center;gap:10px;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-body);}
.dw-leg .dot{width:9px;height:9px;border-radius:3px;flex:none;}
.dw-leg .val{margin-left:auto;color:var(--text-heading);font-weight:var(--fw-semibold);}
.dw-leg .pct{width:42px;text-align:right;color:var(--text-muted);font-size:12px;}
.dw-table{width:100%;border-collapse:collapse;}
.dw-table th{text-align:left;font:var(--fw-semibold) 11px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;
  color:var(--text-placeholder);padding:0 0 12px;border-bottom:1px solid var(--border-default);}
.dw-table td{padding:13px 0;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 13px/1.3 var(--font-sans);color:var(--text-body);}
.dw-table tr:last-child td{border-bottom:0;}
.dw-team{display:flex;align-items:center;gap:11px;}
.dw-team b{color:var(--text-heading);font-weight:var(--fw-semibold);font-size:13.5px;}
.dw-team span{color:var(--text-muted);font-size:12px;}
.dw-stars{display:flex;gap:2px;color:var(--color-warning);}
`;

function injectDash(){ if(document.getElementById('mt-dash-css'))return; const e=document.createElement('style');e.id='mt-dash-css';e.textContent=DASH_CSS;document.head.appendChild(e);}

function smoothPath(vals, w, h, pad){
  const max=Math.max(...vals)*1.15, min=Math.min(...vals)*0.85;
  const dx=(w-pad*2)/(vals.length-1);
  const pts=vals.map((v,i)=>[pad+i*dx, h-pad-((v-min)/(max-min))*(h-pad*2)]);
  let d=`M ${pts[0][0]} ${pts[0][1]}`;
  for(let i=0;i<pts.length-1;i++){
    const [x0,y0]=pts[i],[x1,y1]=pts[i+1],cx=(x0+x1)/2;
    d+=` C ${cx} ${y0} ${cx} ${y1} ${x1} ${y1}`;
  }
  return {d, pts, area:`${d} L ${pts[pts.length-1][0]} ${h-pad} L ${pts[0][0]} ${h-pad} Z`};
}

function AreaChart({ vals, peak }){
  const w=620,h=220,pad=24;
  const {d,pts,area}=smoothPath(vals,w,h,pad);
  const months=["Oca","Şub","Mar","Nis","May","Haz","Tem","Ağu","Eyl","Eki","Kas","Ara"];
  const pk=pts[peak];
  return (
    <svg viewBox={`0 0 ${w} ${h+24}`} style={{width:'100%',height:'auto',display:'block'}}>
      <defs>
        <linearGradient id="dwfill" x1="0" y1="0" x2="0" y2="1">
          <stop offset="0%" stopColor="var(--color-primary)" stopOpacity="0.18"/>
          <stop offset="100%" stopColor="var(--color-primary)" stopOpacity="0"/>
        </linearGradient>
      </defs>
      {[0,0.25,0.5,0.75,1].map((g,i)=>(<line key={i} x1={pad} x2={w-pad} y1={pad+g*(h-pad*2)} y2={pad+g*(h-pad*2)} stroke="var(--border-default)" strokeDasharray="4 5"/>))}
      <path d={area} fill="url(#dwfill)"/>
      <path d={d} fill="none" stroke="var(--color-primary)" strokeWidth="2.5" strokeLinecap="round"/>
      <line x1={pk[0]} x2={pk[0]} y1={pk[1]} y2={h-pad} stroke="var(--color-primary)" strokeDasharray="4 4" opacity="0.5"/>
      <circle cx={pk[0]} cy={pk[1]} r="5" fill="var(--surface-card)" stroke="var(--color-primary)" strokeWidth="3"/>
      {months.map((m,i)=>(<text key={m} x={pad+i*((w-pad*2)/11)} y={h+12} fill="var(--text-placeholder)" fontSize="11" fontFamily="var(--font-sans)" textAnchor="middle">{m}</text>))}
    </svg>
  );
}

function StatCard({icon,bg,big,label}){
  return (
    <div className="dw-stat">
      <div className="dw-stat__ic" style={{background:bg}}><D.Icon name={icon} size={22} color="#fff"/></div>
      <div><div className="dw-stat__big">{big}</div><div className="dw-stat__lbl">{label}</div></div>
    </div>
  );
}

function Stars({n}){return <div className="dw-stars">{Array.from({length:5}).map((_,i)=><D.Icon key={i} name="star" size={14} color={i<n?'var(--color-warning)':'var(--border-strong)'}/>)}</div>;}

function DashboardView(){
  React.useEffect(()=>{injectDash();},[]);
  const { Card, CardHeader, CardBody, CardFooter, Badge, Progress, Button, AvatarGroup, Avatar, Tabs, IconButton } = D;
  const teams=[
    {name:"KeenThemes",sub:"2 saat önce aktif",rating:5,mod:"21 Eki 2024"},
    {name:"Fireart Studio",sub:"Tasarım ekibi",rating:5,mod:"15 Eki 2024"},
    {name:"Outsourced",sub:"Mühendislik",rating:4,mod:"10 Eki 2024"},
    {name:"Pixel Labs",sub:"Ürün",rating:5,mod:"05 Eki 2024"},
  ];
  return (
    <React.Fragment>
      <div className="dw-grid">
        <StatCard icon="people" bg="#1f3864" big="9,3B" label="Harika üyeler"/>
        <StatCard icon="notepad" bg="#0bc33f" big="24B" label="Ders görüntüleme"/>
        <StatCard icon="messages" bg="#e08a2b" big="608" label="Yeni aboneler"/>
        <StatCard icon="rocket" bg="#4921ea" big="2,5B" label="Yayın izleyicisi"/>
      </div>

      <div className="dw-row2">
        <Card>
          <CardHeader title="Kazançlar" subtitle="Aylık gelir trendi" toolbar={<Badge color="success" variant="light" dot>+24%</Badge>} />
          <CardBody>
            <div style={{display:'flex',alignItems:'baseline',gap:10,marginBottom:6}}>
              <span style={{font:'var(--fw-bold) 26px/1 var(--font-sans)',color:'var(--text-heading)',letterSpacing:'var(--ls-tight)'}}>34.233 ₺</span>
              <span style={{font:'var(--fw-medium) 12px/1 var(--font-sans)',color:'var(--text-muted)'}}>Haziran 2024 satışları</span>
            </div>
            <AreaChart vals={[18,24,16,28,22,40,30,26,34,29,38,33]} peak={5}/>
          </CardBody>
        </Card>
        <Card>
          <CardHeader title="Öne Çıkanlar" toolbar={<IconButton icon="more" aria-label="Daha fazla"/>} />
          <CardBody>
            <div style={{font:'var(--fw-medium) 12px/1 var(--font-sans)',color:'var(--text-muted)'}}>Tüm zamanların satışı</div>
            <div style={{display:'flex',alignItems:'center',gap:8,margin:'6px 0 16px'}}>
              <span style={{font:'var(--fw-bold) 28px/1 var(--font-sans)',color:'var(--text-heading)',letterSpacing:'var(--ls-tight)'}}>295.700 ₺</span>
              <Badge color="success" variant="light">+2.7%</Badge>
            </div>
            <div style={{display:'flex',height:8,borderRadius:999,overflow:'hidden',marginBottom:18}}>
              <div style={{flex:'0 0 52%',background:'var(--color-primary)'}}/>
              <div style={{flex:'0 0 24%',background:'var(--color-success)'}}/>
              <div style={{flex:'1',background:'var(--color-warning)'}}/>
            </div>
            <div className="dw-legend">
              <div className="dw-leg"><span className="dot" style={{background:'var(--color-primary)'}}/>Online Mağaza<span className="val">172.000 ₺</span><span className="pct">52%</span></div>
              <div className="dw-leg"><span className="dot" style={{background:'var(--color-success)'}}/>Facebook<span className="val">85.000 ₺</span><span className="pct">24%</span></div>
              <div className="dw-leg"><span className="dot" style={{background:'var(--color-warning)'}}/>Instagram<span className="val">36.000 ₺</span><span className="pct">24%</span></div>
            </div>
          </CardBody>
        </Card>
      </div>

      <div style={{marginTop:18}}>
        <Card>
          <CardHeader title="Takımlar" subtitle="52 takım" toolbar={<Button size="sm" variant="light" iconStart="plus-squared">Takım ekle</Button>} />
          <CardBody>
            <table className="dw-table">
              <thead><tr><th>Takım</th><th>Puan</th><th>Son güncelleme</th><th style={{textAlign:'right'}}>Üyeler</th></tr></thead>
              <tbody>
                {teams.map((t,i)=>(
                  <tr key={i}>
                    <td><div className="dw-team"><Avatar name={t.name} size={36}/><div><b>{t.name}</b><div><span>{t.sub}</span></div></div></div></td>
                    <td><Stars n={t.rating}/></td>
                    <td>{t.mod}</td>
                    <td><div style={{display:'flex',justifyContent:'flex-end'}}><AvatarGroup max={3} size={30} people={[{name:"A B"},{name:"C D"},{name:"E F"},{name:"G H"},{name:"I J"}]}/></div></td>
                  </tr>
                ))}
              </tbody>
            </table>
          </CardBody>
          <CardFooter><span style={{font:'var(--fw-medium) 12px/1 var(--font-sans)',color:'var(--text-muted)'}}>52 kayıttan 1–4 arası</span><div style={{marginLeft:'auto'}}><Button size="sm" variant="ghost" iconEnd="chevron-right">Sonraki</Button></div></CardFooter>
        </Card>
      </div>
    </React.Fragment>
  );
}

window.DashboardView = DashboardView;
