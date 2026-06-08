/* Public Profile view — hero, tabs, about, skills, contributors, donut. */
const P = window.MetronicDesignSystem_a73f8f;

const PROF_CSS = `
.pf-hero{display:flex;flex-direction:column;align-items:center;text-align:center;gap:6px;padding:8px 0 22px;}
.pf-hero h2{font:var(--fw-semibold) 20px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);margin-top:12px;}
.pf-hero .meta{display:flex;align-items:center;gap:14px;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-muted);}
.pf-hero .meta span{display:inline-flex;align-items:center;gap:6px;}
.pf-actions{display:flex;gap:8px;margin-top:12px;}
.pf-tabs-wrap{border-bottom:1px solid var(--border-default);margin-bottom:20px;}
.pf-cols{display:grid;grid-template-columns:340px 1fr;gap:18px;align-items:start;}
.pf-about{display:flex;flex-direction:column;gap:0;}
.pf-about .r{display:flex;justify-content:space-between;gap:12px;padding:9px 0;border-bottom:1px solid var(--border-default);font-size:13px;}
.pf-about .r:last-child{border-bottom:0;}
.pf-about .k{color:var(--text-muted);font-weight:var(--fw-medium);}
.pf-about .v{color:var(--text-heading);font-weight:var(--fw-semibold);}
.pf-skills{display:flex;flex-wrap:wrap;gap:8px;}
.pf-contrib{display:flex;align-items:center;gap:12px;padding:10px 0;border-bottom:1px solid var(--border-default);}
.pf-contrib:last-child{border-bottom:0;}
.pf-contrib b{font:var(--fw-semibold) 13px/1.3 var(--font-sans);color:var(--text-heading);}
.pf-contrib span{font:var(--fw-regular) 12px/1.3 var(--font-sans);color:var(--text-muted);}
.pf-donut-wrap{display:flex;align-items:center;gap:20px;}
.pf-donut-leg{display:flex;flex-direction:column;gap:8px;}
.pf-donut-leg div{display:flex;align-items:center;gap:8px;font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-body);}
.pf-donut-leg .dot{width:8px;height:8px;border-radius:2px;}
.pf-blog{display:flex;align-items:center;justify-content:space-between;gap:18px;background:linear-gradient(120deg,var(--color-primary-soft),var(--surface-card));}
`;
function injectProf(){if(document.getElementById('mt-prof-css'))return;const e=document.createElement('style');e.id='mt-prof-css';e.textContent=PROF_CSS;document.head.appendChild(e);}

function Donut({segments,size=140}){
  const r=size/2-14, c=2*Math.PI*r; let off=0;
  return (
    <svg viewBox={`0 0 ${size} ${size}`} style={{width:size,height:size}}>
      <circle cx={size/2} cy={size/2} r={r} fill="none" stroke="var(--color-grey-200)" strokeWidth="14"/>
      {segments.map((s,i)=>{const len=c*s.v/100;const el=<circle key={i} cx={size/2} cy={size/2} r={r} fill="none" stroke={s.color} strokeWidth="14" strokeDasharray={`${len} ${c-len}`} strokeDashoffset={-off} transform={`rotate(-90 ${size/2} ${size/2})`} strokeLinecap="round"/>;off+=len;return el;})}
      <text x={size/2} y={size/2-2} textAnchor="middle" fontSize="22" fontWeight="700" fill="var(--text-heading)" fontFamily="var(--font-sans)">82%</text>
      <text x={size/2} y={size/2+15} textAnchor="middle" fontSize="10" fill="var(--text-muted)" fontFamily="var(--font-sans)">Resolved</text>
    </svg>
  );
}

function MiniArea({vals}){
  const w=560,h=170,pad=18;
  const max=Math.max(...vals)*1.15,min=Math.min(...vals)*0.8,dx=(w-pad*2)/(vals.length-1);
  const pts=vals.map((v,i)=>[pad+i*dx,h-pad-((v-min)/(max-min))*(h-pad*2)]);
  let d=`M ${pts[0][0]} ${pts[0][1]}`;
  for(let i=0;i<pts.length-1;i++){const[x0,y0]=pts[i],[x1,y1]=pts[i+1],cx=(x0+x1)/2;d+=` C ${cx} ${y0} ${cx} ${y1} ${x1} ${y1}`;}
  const area=`${d} L ${pts[pts.length-1][0]} ${h-pad} L ${pts[0][0]} ${h-pad} Z`;
  return (
    <svg viewBox={`0 0 ${w} ${h}`} style={{width:'100%',height:'auto'}}>
      <defs><linearGradient id="pffill" x1="0" y1="0" x2="0" y2="1"><stop offset="0%" stopColor="var(--color-primary)" stopOpacity="0.18"/><stop offset="100%" stopColor="var(--color-primary)" stopOpacity="0"/></linearGradient></defs>
      <path d={area} fill="url(#pffill)"/>
      <path d={d} fill="none" stroke="var(--color-primary)" strokeWidth="2.5"/>
    </svg>
  );
}

function ProfileView(){
  React.useEffect(()=>{injectProf();},[]);
  const { Card, CardHeader, CardBody, Button, Badge, Avatar, Tabs, Tag, Icon } = P;
  const contributors=[
    {name:"Emma Smith",role:"Sanat Yönetmeni",badge:"success"},
    {name:"Sean Bean",role:"Geliştirici",badge:"primary"},
    {name:"Brian Cox",role:"Web Tasarımcı",badge:"warning"},
    {name:"Mikaela Collins",role:"Tasarım Direktörü",badge:"info"},
  ];
  return (
    <React.Fragment>
      <div className="pf-hero">
        <Avatar name="Jenny Klabber" size={88} ring status="online" />
        <h2>Jenny Klabber</h2>
        <div className="meta">
          <span><Icon name="category" size={14}/> Uyanık</span>
          <span><Icon name="home" size={14}/> İstanbul, Türkiye</span>
          <span><Icon name="messages" size={14}/> jenny@uyanik.com</span>
        </div>
        <div className="pf-actions">
          <Button color="accent" iconStart="profile-circle">Bağlan</Button>
          <Button variant="outline" color="dark" iconStart="share">Paylaş</Button>
        </div>
      </div>

      <div className="pf-tabs-wrap">
        <Tabs tabs={[{id:'p',label:'Profil'},{id:'pr',label:'Projeler'},{id:'w',label:'İş'},{id:'t',label:'Takımlar'},{id:'n',label:'Ağ'},{id:'a',label:'Etkinlik'}]} defaultValue="p" />
      </div>

      <div className="pf-cols">
        <div style={{display:'flex',flexDirection:'column',gap:18}}>
          <Card>
            <CardHeader title="Hakkında" />
            <CardBody>
              <div className="pf-about">
                <div className="r"><span className="k">Yaş</span><span className="v">32</span></div>
                <div className="r"><span className="k">Şehir</span><span className="v">İstanbul</span></div>
                <div className="r"><span className="k">Bölge</span><span className="v">Marmara</span></div>
                <div className="r"><span className="k">Ülke</span><span className="v">Türkiye</span></div>
                <div className="r"><span className="k">Posta kodu</span><span className="v">34000</span></div>
                <div className="r"><span className="k">Telefon</span><span className="v">+90 555 123 45 67</span></div>
              </div>
            </CardBody>
          </Card>
          <Card>
            <CardHeader title="Yetenekler" />
            <CardBody>
              <div className="pf-skills">
                {["Web Tasarım","Kod İnceleme","Figma","Ürün","WebRTC","Yapay Zeka","noCode","Markalaşma"].map(s=>(<Tag key={s}>{s}</Tag>))}
              </div>
            </CardBody>
          </Card>
        </div>

        <div style={{display:'flex',flexDirection:'column',gap:18}}>
          <Card>
            <CardBody>
              <div className="pf-blog">
                <div style={{flex:1}}>
                  <div style={{font:'var(--fw-semibold) 16px/1.3 var(--font-sans)',color:'var(--text-heading)',letterSpacing:'var(--ls-tight)'}}>Blogumuzda yaratıcı iş birliklerini keşfet</div>
                  <div style={{font:'var(--fw-regular) 13px/1.5 var(--font-sans)',color:'var(--text-muted)',margin:'8px 0 14px',maxWidth:420}}>Heyecan verici iş birliği fırsatlarını, konuk yazıları ve daha fazlasını keşfet. Bilgini paylaş, kitleni büyüt.</div>
                  <Button color="primary" variant="light" size="sm" iconStart="rocket">Başla</Button>
                </div>
                <Icon name="rocket" size={64} color="var(--color-primary)"/>
              </div>
            </CardBody>
          </Card>
          <Card>
            <CardHeader title="Satış Özeti" subtitle="Son 12 ay" toolbar={<Badge color="success" variant="light">+39%</Badge>} />
            <CardBody>
              <div style={{display:'flex',alignItems:'baseline',gap:10,marginBottom:4}}>
                <span style={{font:'var(--fw-bold) 24px/1 var(--font-sans)',color:'var(--text-heading)',letterSpacing:'var(--ls-tight)'}}>87.455 ₺</span>
                <span style={{font:'var(--fw-medium) 12px/1 var(--font-sans)',color:'var(--text-muted)'}}>Mart 2024 satışları</span>
              </div>
              <MiniArea vals={[20,30,22,38,28,46,34,40,30,44,36,50]}/>
            </CardBody>
          </Card>
          <div style={{display:'grid',gridTemplateColumns:'1fr 1fr',gap:18}}>
            <Card>
              <CardHeader title="Katkıda Bulunanlar" toolbar={<Button variant="link" size="sm">Tümü</Button>} />
              <CardBody>
                {contributors.map((c,i)=>(
                  <div className="pf-contrib" key={i}>
                    <Avatar name={c.name} size={36}/>
                    <div style={{flex:1}}><b>{c.name}</b><div><span>{c.role}</span></div></div>
                    <Badge color={c.badge} variant="light" size="sm">●</Badge>
                  </div>
                ))}
              </CardBody>
            </Card>
            <Card>
              <CardHeader title="Destek" subtitle="Destek talepleri" />
              <CardBody>
                <div className="pf-donut-wrap">
                  <Donut segments={[{v:54,color:'var(--color-primary)'},{v:28,color:'var(--color-success)'},{v:18,color:'var(--color-warning)'}]}/>
                  <div className="pf-donut-leg">
                    <div><span className="dot" style={{background:'var(--color-primary)'}}/>ERP</div>
                    <div><span className="dot" style={{background:'var(--color-success)'}}/>CRM</div>
                    <div><span className="dot" style={{background:'var(--color-warning)'}}/>DMS</div>
                  </div>
                </div>
              </CardBody>
            </Card>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
}

window.ProfileView = ProfileView;
