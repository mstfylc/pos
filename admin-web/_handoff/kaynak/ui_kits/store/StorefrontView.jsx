/* Storefront — hero, loyalty banner, product grid. window.StorefrontView + window.STORE_PRODUCTS */
const SF = window.MetronicDesignSystem_a73f8f;

const SF_CSS = `
.sf-hero{display:grid;grid-template-columns:1.1fr .9fr;gap:0;border-radius:var(--radius-2xl);overflow:hidden;
  background:linear-gradient(120deg,var(--color-primary),var(--color-primary-active));color:#fff;margin-bottom:26px;}
.sf-hero__txt{padding:44px 44px 44px;display:flex;flex-direction:column;justify-content:center;gap:14px;}
.sf-hero__ey{font:var(--fw-semibold) 12px/1 var(--font-sans);letter-spacing:.1em;text-transform:uppercase;color:var(--color-accent);}
.sf-hero h1{font:var(--fw-bold) 38px/1.1 var(--font-sans);letter-spacing:-0.02em;color:#fff;max-width:420px;}
.sf-hero p{font:var(--fw-regular) 15px/1.55 var(--font-sans);color:rgba(255,255,255,.78);max-width:400px;}
.sf-hero__img{position:relative;display:flex;align-items:center;justify-content:center;background:radial-gradient(circle at 60% 50%,rgba(224,138,43,.25),transparent 60%);}
.sf-hero__img img{width:90%;transform:rotate(-8deg);filter:drop-shadow(0 30px 40px rgba(0,0,0,.35));}
.sf-loyal{display:flex;align-items:center;gap:16px;background:var(--color-accent-soft);border:1px solid var(--color-accent);
  border-radius:var(--radius-xl);padding:16px 22px;margin-bottom:26px;}
.sf-loyal__ic{width:46px;height:46px;border-radius:var(--radius-md);background:var(--color-accent);color:#fff;display:flex;align-items:center;justify-content:center;flex:none;}
.sf-loyal b{font:var(--fw-semibold) 15px/1.3 var(--font-sans);color:var(--color-accent-accent);letter-spacing:var(--ls-tight);}
.sf-loyal span{font:var(--fw-regular) 13px/1.4 var(--font-sans);color:var(--color-accent-accent);opacity:.85;}
.sf-sec{display:flex;align-items:center;justify-content:space-between;margin-bottom:16px;}
.sf-sec h2{font:var(--fw-semibold) 19px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.sf-grid{display:grid;grid-template-columns:repeat(4,1fr);gap:20px;}
.sf-card{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);overflow:hidden;
  box-shadow:var(--shadow-sm);transition:box-shadow .18s,transform .18s;cursor:pointer;display:flex;flex-direction:column;}
.sf-card:hover{box-shadow:var(--shadow-lg);transform:translateY(-3px);}
.sf-card__media{position:relative;height:170px;display:flex;align-items:center;justify-content:center;background:var(--color-grey-50);}
.sf-card__media img{width:84%;transform:rotate(-6deg);filter:drop-shadow(0 12px 14px rgba(0,0,0,.16));}
.sf-card__tile{width:100%;height:100%;display:flex;align-items:center;justify-content:center;color:#fff;}
.sf-card__tag{position:absolute;top:10px;left:10px;}
.sf-card__fav{position:absolute;top:10px;right:10px;width:30px;height:30px;border-radius:50%;background:var(--surface-card);
  box-shadow:var(--shadow-sm);display:flex;align-items:center;justify-content:center;color:var(--text-muted);}
.sf-card__body{padding:14px 15px 15px;display:flex;flex-direction:column;gap:7px;}
.sf-card__cat{font:var(--fw-medium) 11px/1 var(--font-sans);color:var(--text-muted);text-transform:uppercase;letter-spacing:.05em;}
.sf-card__name{font:var(--fw-semibold) 14.5px/1.3 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.sf-card__rate{display:flex;gap:1px;color:var(--color-warning);}
.sf-card__foot{display:flex;align-items:flex-end;justify-content:space-between;margin-top:4px;}
.sf-card__price b{font:var(--fw-bold) 18px/1 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.sf-card__pts{font:var(--fw-medium) 11px/1.3 var(--font-sans);color:var(--color-accent-accent);margin-top:3px;}
`;
function injectSF(){if(document.getElementById('mt-sf-css'))return;const e=document.createElement('style');e.id='mt-sf-css';e.textContent=SF_CSS;document.head.appendChild(e);}

const IMG = "../../assets/products/sneaker.png";
const STORE_PRODUCTS = [
  {id:1,name:"Triumph ISO Koşu",cat:"Koşu",price:2890,pts:2890,rating:5,hue:0,tag:{t:"Çok satan",c:"accent"}},
  {id:2,name:"Velocity Antrenman",cat:"Antrenman",price:2190,pts:2190,rating:4,hue:130},
  {id:3,name:"Cloud Sprint Pro",cat:"Koşu",price:3250,pts:3250,rating:5,hue:-45,tag:{t:"Yeni",c:"success"}},
  {id:4,name:"Patika Blazer GTX",cat:"Patika",price:3490,pts:3490,rating:5,tile:"var(--color-primary)",icon:"rocket"},
  {id:5,name:"Court Classic",cat:"Yaşam",price:1790,pts:1790,rating:4,hue:200,tag:{t:"%20 indirim",c:"danger"}},
  {id:6,name:"Marathon Elite",cat:"Koşu",price:3990,pts:3990,rating:5,hue:75},
  {id:7,name:"Hediye Kartı 500₺",cat:"Sadakat",price:500,pts:0,rating:5,tile:"var(--color-accent)",icon:"price-tag"},
  {id:8,name:"Studio Trainer",cat:"Antrenman",price:2390,pts:2390,rating:4,hue:160},
];

function Stars({n}){return <div className="sf-card__rate">{Array.from({length:5}).map((_,i)=><SF.Icon key={i} name="star" size={12} color={i<n?'var(--color-warning)':'var(--border-strong)'}/>)}</div>;}

function ProductCard({p,onOpen,onAdd}){
  const { Badge, Icon, IconButton } = SF;
  return (
    <div className="sf-card" onClick={()=>onOpen(p)}>
      <div className="sf-card__media">
        {p.tile
          ? <div className="sf-card__tile" style={{background:p.tile}}><Icon name={p.icon} size={52} color="#fff"/></div>
          : <img src={IMG} alt={p.name} style={{filter:`hue-rotate(${p.hue}deg) drop-shadow(0 12px 14px rgba(0,0,0,.16))`}}/>}
        {p.tag && <span className="sf-card__tag"><Badge color={p.tag.c} variant="solid" size="sm">{p.tag.t}</Badge></span>}
        <div className="sf-card__fav"><Icon name="heart" size={15}/></div>
      </div>
      <div className="sf-card__body">
        <span className="sf-card__cat">{p.cat}</span>
        <span className="sf-card__name">{p.name}</span>
        <Stars n={p.rating}/>
        <div className="sf-card__foot">
          <div className="sf-card__price">
            <b>{p.price.toLocaleString('tr-TR')} ₺</b>
            {p.pts>0 && <div className="sf-card__pts">+{p.pts.toLocaleString('tr-TR')} puan</div>}
          </div>
          <span onClick={(e)=>{e.stopPropagation();onAdd(p);}}>
            <IconButton icon="handcart" variant="light" color="primary" aria-label="Sepete ekle"/>
          </span>
        </div>
      </div>
    </div>
  );
}

function StorefrontView({ onOpen, onAdd }){
  React.useEffect(()=>{injectSF();},[]);
  const { Button, Icon } = SF;
  return (
    <React.Fragment>
      <section className="sf-hero">
        <div className="sf-hero__txt">
          <span className="sf-hero__ey">Yeni Sezon · Sonbahar 2026</span>
          <h1>Her adımda puan kazan, ödülünü seç.</h1>
          <p>Uyanık Sadakat ile alışverişin yarısı kadar puan biriktir, bir sonraki siparişinde harca. Ücretsiz kargo, kolay iade.</p>
          <div><Button color="accent" size="lg" iconStart="rocket">Koleksiyonu keşfet</Button></div>
        </div>
        <div className="sf-hero__img"><img src={IMG} alt="Öne çıkan ürün"/></div>
      </section>

      <div className="sf-loyal">
        <div className="sf-loyal__ic"><Icon name="star" size={24} color="#fff"/></div>
        <div style={{flex:1}}>
          <b>Altın üye oldun — her 100 ₺ için 100 puan!</b><br/>
          <span>Hedefe 1.250 puan kaldı. Platin seviyede kargo her zaman ücretsiz.</span>
        </div>
        <Button variant="outline" color="dark" size="sm">Avantajlar</Button>
      </div>

      <div className="sf-sec"><h2>Senin için seçtiklerimiz</h2><Button variant="link" iconEnd="chevron-right">Tümünü gör</Button></div>
      <div className="sf-grid">
        {STORE_PRODUCTS.map(p=><ProductCard key={p.id} p={p} onOpen={onOpen} onAdd={onAdd}/>)}
      </div>
    </React.Fragment>
  );
}

window.StorefrontView = StorefrontView;
window.STORE_PRODUCTS = STORE_PRODUCTS;
