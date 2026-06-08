/* My Account — loyalty tier, profile, orders, security. window.AccountView */
const AV = window.MetronicDesignSystem_a73f8f;

const AV_CSS = `
.av-wrap{display:grid;grid-template-columns:260px 1fr;gap:24px;align-items:start;}
.av-side{display:flex;flex-direction:column;gap:8px;}
.av-navbtn{display:flex;align-items:center;gap:11px;padding:11px 13px;border:0;background:none;border-radius:var(--radius-md);
  cursor:pointer;font:var(--fw-medium) 13.5px/1 var(--font-sans);color:var(--text-body);text-align:left;width:100%;transition:all .12s;}
.av-navbtn:hover{background:var(--color-grey-100);color:var(--text-heading);}
.av-navbtn.active{background:var(--color-primary-soft);color:var(--color-primary);font-weight:var(--fw-semibold);}
.av-tier{border-radius:var(--radius-xl);padding:20px;color:#fff;background:linear-gradient(125deg,var(--color-primary),var(--color-primary-active));margin-bottom:18px;position:relative;overflow:hidden;}
.av-tier__glow{position:absolute;right:-30px;top:-30px;width:160px;height:160px;border-radius:50%;background:radial-gradient(circle,var(--color-accent),transparent 70%);opacity:.5;}
.av-tier__row{display:flex;align-items:center;justify-content:space-between;position:relative;}
.av-tier h3{font:var(--fw-bold) 20px/1 var(--font-sans);color:#fff;letter-spacing:-0.01em;}
.av-tier small{font:var(--fw-medium) 12px/1 var(--font-sans);color:rgba(255,255,255,.7);}
.av-tier__pts{font:var(--fw-bold) 34px/1 var(--font-sans);letter-spacing:-0.02em;margin:14px 0 4px;position:relative;}
.av-tier__bar{height:7px;border-radius:999px;background:rgba(255,255,255,.2);overflow:hidden;margin-top:12px;position:relative;}
.av-tier__bar i{display:block;height:100%;background:var(--color-accent);border-radius:999px;}
.av-grid2{display:grid;grid-template-columns:1fr 1fr;gap:14px;}
.av-grid2 .full{grid-column:1/-1;}
.av-order{display:flex;align-items:center;gap:14px;padding:14px 0;border-bottom:1px solid var(--border-default);}
.av-order:last-child{border-bottom:0;}
.av-order__img{width:54px;height:54px;border-radius:var(--radius-md);background:var(--color-grey-50);display:flex;align-items:center;justify-content:center;flex:none;}
.av-order__img img{width:80%;transform:rotate(-6deg);}
.av-order__main{flex:1;}
.av-order__main b{font:var(--fw-semibold) 13.5px/1.3 var(--font-sans);color:var(--text-heading);}
.av-order__main span{font:var(--fw-regular) 12px/1.4 var(--font-sans);color:var(--text-muted);}
`;
function injectAV(){if(document.getElementById('mt-av-css'))return;const e=document.createElement('style');e.id='mt-av-css';e.textContent=AV_CSS;document.head.appendChild(e);}
const AIMG="../../assets/products/sneaker.png";

function AccountView(){
  React.useEffect(()=>{injectAV();},[]);
  const { Card, CardHeader, CardBody, CardFooter, Button, Input, Select, Switch, Badge, Avatar, Icon, Progress } = AV;
  const [tab,setTab]=React.useState("profile");
  const NAV=[{id:"profile",label:"Profil",icon:"profile-circle"},{id:"orders",label:"Siparişlerim",icon:"notepad"},{id:"loyalty",label:"Sadakat & Puan",icon:"star"},{id:"security",label:"Güvenlik",icon:"key"}];
  const orders=[
    {id:"#UYN-20268",date:"3 Haz 2026",total:"2.890 ₺",status:["success","Hazırlanıyor"],hue:0},
    {id:"#UYN-19980",date:"21 May 2026",total:"4.380 ₺",status:["primary","Teslim edildi"],hue:130},
    {id:"#UYN-19654",date:"2 May 2026",total:"1.790 ₺",status:["primary","Teslim edildi"],hue:200},
  ];
  return (
    <div className="av-wrap">
      <div className="av-side">
        <div style={{display:'flex',alignItems:'center',gap:11,padding:'4px 6px 14px'}}>
          <Avatar name="Jenny Klabber" size={46} status="online"/>
          <div><div style={{font:'var(--fw-semibold) 14px/1.2 var(--font-sans)',color:'var(--text-heading)'}}>Jenny Klabber</div><div style={{font:'var(--fw-regular) 12px/1.3 var(--font-sans)',color:'var(--text-muted)'}}>Altın üye</div></div>
        </div>
        {NAV.map(n=>(<button key={n.id} className={"av-navbtn"+(tab===n.id?" active":"")} onClick={()=>setTab(n.id)}><Icon name={n.icon} size={18}/>{n.label}</button>))}
        <button className="av-navbtn" style={{color:'var(--color-danger)'}}><Icon name="exit-right" size={18}/>Çıkış yap</button>
      </div>

      <div>
        {tab==="loyalty" || tab==="profile" ? (
          <div className="av-tier">
            <div className="av-tier__glow"></div>
            <div className="av-tier__row"><div><small>Sadakat seviyesi</small><h3>Altın Üye</h3></div><Icon name="star" size={30} color="var(--color-accent)"/></div>
            <div className="av-tier__pts">2.480 <span style={{font:'var(--fw-medium) 14px/1 var(--font-sans)',color:'rgba(255,255,255,.7)'}}>puan</span></div>
            <small style={{position:'relative'}}>Platin seviyeye 1.250 puan kaldı</small>
            <div className="av-tier__bar"><i style={{width:'66%'}}></i></div>
          </div>
        ) : null}

        {tab==="profile" && (
          <Card>
            <CardHeader title="Profil bilgileri" subtitle="Hesap ve iletişim detayların" />
            <CardBody>
              <div className="av-grid2">
                <Input label="Ad" defaultValue="Jenny" />
                <Input label="Soyad" defaultValue="Klabber" />
                <Input className="full" label="E-posta" defaultValue="jenny@uyanik.com" iconLead="messages" />
                <Input label="Telefon" defaultValue="+90 555 123 45 67" />
                <Select label="Dil"><option>Türkçe</option><option>English</option></Select>
              </div>
            </CardBody>
            <CardFooter><div style={{marginLeft:'auto',display:'flex',gap:10}}><Button variant="ghost">Vazgeç</Button><Button color="primary" iconStart="check-circle">Değişiklikleri kaydet</Button></div></CardFooter>
          </Card>
        )}

        {tab==="orders" && (
          <Card>
            <CardHeader title="Siparişlerim" subtitle="Son 3 sipariş" />
            <CardBody>
              {orders.map(o=>(
                <div className="av-order" key={o.id}>
                  <div className="av-order__img"><img src={AIMG} alt="" style={{filter:`hue-rotate(${o.hue}deg)`}}/></div>
                  <div className="av-order__main"><b>{o.id}</b><div><span>{o.date} · {o.total}</span></div></div>
                  <Badge color={o.status[0]} variant="light">{o.status[1]}</Badge>
                  <Button variant="outline" color="dark" size="sm">Detay</Button>
                </div>
              ))}
            </CardBody>
          </Card>
        )}

        {tab==="loyalty" && (
          <Card>
            <CardHeader title="Puan geçmişi" />
            <CardBody>
              {[["Triumph ISO Koşu siparişi","+2.890","success"],["Hediye kartı kullanımı","−500","danger"],["Doğum günü bonusu","+1.000","success"],["Velocity Antrenman siparişi","+2.190","success"]].map((r,i)=>(
                <div className="av-order" key={i} style={{borderBottom:i<3?'1px solid var(--border-default)':'0'}}>
                  <div className="av-order__img" style={{background:'var(--color-accent-soft)'}}><Icon name="star" size={22} color="var(--color-accent)"/></div>
                  <div className="av-order__main"><b>{r[0]}</b><div><span>Uyanık Sadakat</span></div></div>
                  <Badge color={r[2]} variant="light">{r[1]} puan</Badge>
                </div>
              ))}
            </CardBody>
          </Card>
        )}

        {tab==="security" && (
          <Card>
            <CardHeader title="Güvenlik" subtitle="Şifre ve oturum ayarları" />
            <CardBody>
              <div className="av-grid2">
                <Input className="full" label="Mevcut şifre" type="password" defaultValue="password" iconLead="key" />
                <Input label="Yeni şifre" type="password" />
                <Input label="Yeni şifre (tekrar)" type="password" />
              </div>
              <div style={{marginTop:18,display:'flex',flexDirection:'column',gap:14}}>
                <Switch label="İki adımlı doğrulama (2FA)" defaultChecked />
                <Switch label="Yeni cihaz girişlerinde e-posta bildirimi" defaultChecked />
                <Switch label="Kampanya ve puan bildirimleri" />
              </div>
            </CardBody>
            <CardFooter><div style={{marginLeft:'auto'}}><Button color="primary" iconStart="check-circle">Güncelle</Button></div></CardFooter>
          </Card>
        )}
      </div>
    </div>
  );
}

window.AccountView = AccountView;
