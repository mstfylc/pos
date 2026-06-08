/* Checkout — cart items, shipping, payment, order summary. window.CheckoutView */
const CV = window.MetronicDesignSystem_a73f8f;

const CV_CSS = `
.cv-back{margin-bottom:18px;}
.cv-title{font:var(--fw-bold) 24px/1.2 var(--font-sans);letter-spacing:-0.02em;color:var(--text-heading);margin-bottom:20px;}
.cv-wrap{display:grid;grid-template-columns:1fr 360px;gap:24px;align-items:start;}
.cv-line{display:flex;align-items:center;gap:14px;padding:14px 0;border-bottom:1px solid var(--border-default);}
.cv-line:last-child{border-bottom:0;}
.cv-line__img{width:72px;height:72px;border-radius:var(--radius-md);background:var(--color-grey-50);display:flex;align-items:center;justify-content:center;flex:none;}
.cv-line__img img{width:80%;transform:rotate(-6deg);}
.cv-line__img .mt-icon{color:#fff;}
.cv-line__main{flex:1;min-width:0;}
.cv-line__name{font:var(--fw-semibold) 14px/1.3 var(--font-sans);color:var(--text-heading);}
.cv-line__meta{font:var(--fw-regular) 12px/1.4 var(--font-sans);color:var(--text-muted);}
.cv-qty{display:flex;align-items:center;gap:0;border:1px solid var(--border-strong);border-radius:var(--radius-sm);overflow:hidden;}
.cv-qty button{width:30px;height:30px;border:0;background:var(--surface-card);cursor:pointer;color:var(--text-body);font-size:15px;display:flex;align-items:center;justify-content:center;}
.cv-qty button:hover{background:var(--color-grey-100);}
.cv-qty span{width:34px;text-align:center;font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-heading);}
.cv-line__price{font:var(--fw-bold) 15px/1 var(--font-sans);color:var(--text-heading);width:90px;text-align:right;letter-spacing:var(--ls-tight);}
.cv-form{display:grid;grid-template-columns:1fr 1fr;gap:14px;}
.cv-form .full{grid-column:1/-1;}
.cv-pay{display:flex;gap:10px;}
.cv-paycard{flex:1;border:1px solid var(--border-strong);border-radius:var(--radius-md);padding:13px;display:flex;align-items:center;gap:10px;cursor:pointer;font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-body);}
.cv-paycard.active{border-color:var(--color-primary);background:var(--color-primary-soft);color:var(--color-primary);}
.cv-sum__row{display:flex;justify-content:space-between;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-body);padding:7px 0;}
.cv-sum__row.acc{color:var(--color-accent-accent);}
.cv-sum__total{display:flex;justify-content:space-between;align-items:baseline;padding-top:13px;margin-top:6px;border-top:1px solid var(--border-default);}
.cv-sum__total b{font:var(--fw-bold) 22px/1 var(--font-sans);color:var(--text-heading);letter-spacing:-0.02em;}
.cv-redeem{display:flex;align-items:center;gap:10px;background:var(--color-accent-soft);border-radius:var(--radius-md);padding:12px 14px;margin:14px 0;}
.cv-redeem b{font:var(--fw-semibold) 13px/1.3 var(--font-sans);color:var(--color-accent-accent);}
.cv-redeem span{font:var(--fw-regular) 11.5px/1.3 var(--font-sans);color:var(--color-accent-accent);opacity:.85;}
.cv-done{max-width:460px;margin:40px auto;text-align:center;display:flex;flex-direction:column;align-items:center;gap:14px;}
.cv-done__ic{width:84px;height:84px;border-radius:50%;background:var(--color-success-soft);color:var(--color-success);display:flex;align-items:center;justify-content:center;}
.cv-done h1{font:var(--fw-bold) 26px/1.2 var(--font-sans);letter-spacing:-0.02em;color:var(--text-heading);}
.cv-done p{font:var(--fw-regular) 14px/1.6 var(--font-sans);color:var(--text-muted);}
`;
function injectCV(){if(document.getElementById('mt-cv-css'))return;const e=document.createElement('style');e.id='mt-cv-css';e.textContent=CV_CSS;document.head.appendChild(e);}
const CIMG="../../assets/products/sneaker.png";
const tl=n=>n.toLocaleString('tr-TR');

function CheckoutView({ cart, onInc, onDec, onRemove, onPlace, onBack }){
  React.useEffect(()=>{injectCV();},[]);
  const { Card, CardHeader, CardBody, Button, Input, Select, Badge, Switch, Icon } = CV;
  const [pay,setPay]=React.useState("card");
  const [redeem,setRedeem]=React.useState(true);
  const items = cart.length?cart:[];
  const subtotal = items.reduce((s,p)=>s+p.price*p.qty,0);
  const earn = items.reduce((s,p)=>s+(p.pts||0)*p.qty,0);
  const ptsDiscount = redeem ? Math.min(1240, Math.round(subtotal*0.1)) : 0;
  const total = subtotal - ptsDiscount;

  if(items.length===0){
    return (
      <div className="cv-done">
        <div className="cv-done__ic"><Icon name="handcart" size={40}/></div>
        <h1>Sepetin boş</h1>
        <p>Henüz ürün eklemedin. Koleksiyonu keşfet ve puan kazanmaya başla.</p>
        <Button color="accent" size="lg" onClick={onBack}>Alışverişe başla</Button>
      </div>
    );
  }
  return (
    <React.Fragment>
      <div className="cv-back"><Button variant="ghost" size="sm" iconStart="chevron-left" onClick={onBack}>Alışverişe devam et</Button></div>
      <div className="cv-title">Sepet & Ödeme</div>
      <div className="cv-wrap">
        <div style={{display:'flex',flexDirection:'column',gap:20}}>
          <Card>
            <CardHeader title={`Sepetim (${items.length})`} />
            <CardBody>
              {items.map(p=>(
                <div className="cv-line" key={p.id}>
                  <div className="cv-line__img" style={p.tile?{background:p.tile}:null}>
                    {p.tile?<Icon name={p.icon} size={30}/>:<img src={CIMG} alt="" style={{filter:`hue-rotate(${p.hue||0}deg)`}}/>}
                  </div>
                  <div className="cv-line__main">
                    <div className="cv-line__name">{p.name}</div>
                    <div className="cv-line__meta">{p.cat} · Beden 42 · Lacivert</div>
                  </div>
                  <div className="cv-qty"><button onClick={()=>onDec(p)}>−</button><span>{p.qty}</span><button onClick={()=>onInc(p)}>+</button></div>
                  <div className="cv-line__price">{tl(p.price*p.qty)} ₺</div>
                  <Button variant="ghost" size="sm" color="danger" iconStart="trash" aria-label="Kaldır" onClick={()=>onRemove(p)} />
                </div>
              ))}
            </CardBody>
          </Card>
          <Card>
            <CardHeader title="Teslimat adresi" />
            <CardBody>
              <div className="cv-form">
                <Input label="Ad" defaultValue="Jenny" />
                <Input label="Soyad" defaultValue="Klabber" />
                <Input className="full" label="Adres" defaultValue="Bağdat Cad. No: 124, Kadıköy" />
                <Input label="Şehir" defaultValue="İstanbul" />
                <Select label="İl"><option>İstanbul</option><option>Ankara</option><option>İzmir</option></Select>
              </div>
            </CardBody>
          </Card>
          <Card>
            <CardHeader title="Ödeme yöntemi" />
            <CardBody>
              <div className="cv-pay">
                <div className={"cv-paycard"+(pay==="card"?" active":"")} onClick={()=>setPay("card")}><Icon name="price-tag" size={18}/>Kredi kartı</div>
                <div className={"cv-paycard"+(pay==="points"?" active":"")} onClick={()=>setPay("points")}><Icon name="star" size={18}/>Puanla öde</div>
                <div className={"cv-paycard"+(pay==="cod"?" active":"")} onClick={()=>setPay("cod")}><Icon name="handcart" size={18}/>Kapıda</div>
              </div>
              {pay==="card" && <div className="cv-form" style={{marginTop:14}}>
                <Input className="full" label="Kart numarası" defaultValue="4242 4242 4242 4242" iconLead="price-tag" />
                <Input label="Son kullanma" defaultValue="08 / 28" />
                <Input label="CVC" defaultValue="123" />
              </div>}
            </CardBody>
          </Card>
        </div>

        <Card>
          <CardHeader title="Sipariş özeti" />
          <CardBody>
            <div className="cv-sum__row"><span>Ara toplam</span><span>{tl(subtotal)} ₺</span></div>
            <div className="cv-sum__row"><span>Kargo</span><span style={{color:'var(--color-success)',fontWeight:600}}>Ücretsiz</span></div>
            {ptsDiscount>0 && <div className="cv-sum__row acc"><span>Puan indirimi</span><span>−{tl(ptsDiscount)} ₺</span></div>}
            <div className="cv-redeem">
              <Icon name="star" size={20} color="var(--color-accent)"/>
              <div style={{flex:1}}><b>2.480 puanını kullan</b><br/><span>Bu siparişte {tl(1240)} ₺ indirim</span></div>
              <Switch checked={redeem} onChange={e=>setRedeem(e.target.checked)} />
            </div>
            <div className="cv-sum__total"><span style={{font:'var(--fw-semibold) 14px/1 var(--font-sans)',color:'var(--text-heading)'}}>Toplam</span><b>{tl(total)} ₺</b></div>
            <div style={{marginTop:8,marginBottom:14}}><Badge color="accent" variant="light">Bu siparişten +{tl(earn)} puan kazanacaksın</Badge></div>
            <Button color="accent" size="lg" fullWidth iconStart="check-circle" onClick={onPlace}>Siparişi tamamla</Button>
          </CardBody>
        </Card>
      </div>
    </React.Fragment>
  );
}

function OrderDone({ onBack }){
  React.useEffect(()=>{injectCV();},[]);
  const { Button, Icon } = CV;
  return (
    <div className="cv-done">
      <div className="cv-done__ic"><Icon name="check-circle" size={44}/></div>
      <h1>Siparişin alındı!</h1>
      <p>#UYN-20268 numaralı siparişin hazırlanıyor. Kazandığın puanlar hesabına eklendi ve bir sonraki alışverişinde kullanıma hazır.</p>
      <div style={{display:'flex',gap:10}}>
        <Button variant="outline" color="dark" onClick={onBack}>Alışverişe devam</Button>
        <Button color="accent" iconStart="notepad">Siparişi takip et</Button>
      </div>
    </div>
  );
}

window.CheckoutView = CheckoutView;
window.OrderDone = OrderDone;
