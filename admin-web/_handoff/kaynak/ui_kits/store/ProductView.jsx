/* Product detail — gallery, info, size/color, add to cart. window.ProductView */
const PV = window.MetronicDesignSystem_a73f8f;

const PV_CSS = `
.pv-back{margin-bottom:18px;}
.pv-wrap{display:grid;grid-template-columns:1.05fr .95fr;gap:34px;align-items:start;}
.pv-gallery{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-xl);overflow:hidden;}
.pv-stage{height:420px;display:flex;align-items:center;justify-content:center;background:var(--color-grey-50);}
.pv-stage img{width:78%;transform:rotate(-7deg);filter:drop-shadow(0 26px 30px rgba(0,0,0,.2));}
.pv-thumbs{display:flex;gap:10px;padding:14px;}
.pv-thumb{width:66px;height:66px;border-radius:var(--radius-md);background:var(--color-grey-50);border:2px solid transparent;
  display:flex;align-items:center;justify-content:center;cursor:pointer;}
.pv-thumb.active{border-color:var(--color-primary);}
.pv-thumb img{width:80%;}
.pv-info{display:flex;flex-direction:column;gap:16px;}
.pv-cat{font:var(--fw-semibold) 12px/1 var(--font-sans);color:var(--color-accent-accent);text-transform:uppercase;letter-spacing:.06em;}
.pv-info h1{font:var(--fw-bold) 28px/1.15 var(--font-sans);letter-spacing:-0.02em;color:var(--text-heading);}
.pv-rate{display:flex;align-items:center;gap:8px;}
.pv-rate .stars{display:flex;gap:2px;color:var(--color-warning);}
.pv-rate small{font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-muted);}
.pv-price{display:flex;align-items:baseline;gap:12px;}
.pv-price b{font:var(--fw-bold) 30px/1 var(--font-sans);letter-spacing:-0.02em;color:var(--text-heading);}
.pv-price s{font:var(--fw-medium) 17px/1 var(--font-sans);color:var(--text-placeholder);}
.pv-desc{font:var(--fw-regular) 14px/1.6 var(--font-sans);color:var(--text-body);}
.pv-opt__lbl{font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-heading);margin-bottom:9px;}
.pv-sizes{display:flex;gap:8px;flex-wrap:wrap;}
.pv-size{min-width:46px;height:42px;padding:0 10px;border-radius:var(--radius-sm);border:1px solid var(--border-strong);
  background:var(--surface-card);font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-body);cursor:pointer;display:flex;align-items:center;justify-content:center;}
.pv-size.active{border-color:var(--color-primary);background:var(--color-primary-soft);color:var(--color-primary);}
.pv-swatches{display:flex;gap:9px;}
.pv-sw{width:30px;height:30px;border-radius:50%;cursor:pointer;border:2px solid var(--surface-card);box-shadow:0 0 0 1px var(--border-strong);}
.pv-sw.active{box-shadow:0 0 0 2px var(--color-primary);}
.pv-buy{display:flex;gap:10px;margin-top:4px;}
.pv-perks{display:flex;gap:18px;margin-top:6px;padding-top:16px;border-top:1px solid var(--border-default);}
.pv-perk{display:flex;align-items:center;gap:8px;font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);}
.pv-perk .mt-icon{color:var(--color-success);}
`;
function injectPV(){if(document.getElementById('mt-pv-css'))return;const e=document.createElement('style');e.id='mt-pv-css';e.textContent=PV_CSS;document.head.appendChild(e);}

const PIMG = "../../assets/products/sneaker.png";

function ProductView({ product, onAdd, onBack }){
  React.useEffect(()=>{injectPV();},[]);
  const { Button, Badge, Icon } = PV;
  const p = product || { name:"Triumph ISO Koşu", cat:"Koşu", price:2890, pts:2890, rating:5, hue:0 };
  const hue = p.hue||0;
  const [size,setSize]=React.useState("42");
  const [sw,setSw]=React.useState(0);
  const swatches=["hue-rotate(0deg)","hue-rotate(130deg)","hue-rotate(-45deg)","hue-rotate(200deg)"];
  const filt = `${sw?swatches[sw]:`hue-rotate(${hue}deg)`}`;
  return (
    <React.Fragment>
      <div className="pv-back"><Button variant="ghost" size="sm" iconStart="chevron-left" onClick={onBack}>Mağazaya dön</Button></div>
      <div className="pv-wrap">
        <div className="pv-gallery">
          <div className="pv-stage"><img src={PIMG} alt={p.name} style={{filter:`${filt} drop-shadow(0 26px 30px rgba(0,0,0,.2))`}}/></div>
          <div className="pv-thumbs">
            {[0,1,2,3].map(i=>(
              <div key={i} className={"pv-thumb"+(sw===i?" active":"")} onClick={()=>setSw(i)}>
                <img src={PIMG} alt="" style={{filter:swatches[i]}}/>
              </div>
            ))}
          </div>
        </div>
        <div className="pv-info">
          <span className="pv-cat">{p.cat} · Uyanık Sport</span>
          <h1>{p.name}</h1>
          <div className="pv-rate"><div className="stars">{Array.from({length:5}).map((_,i)=><Icon key={i} name="star" size={15} color={i<p.rating?'var(--color-warning)':'var(--border-strong)'}/>)}</div><small>4.8 · 312 değerlendirme</small><Badge color="success" variant="light" size="sm">Stokta</Badge></div>
          <div className="pv-price"><b>{p.price.toLocaleString('tr-TR')} ₺</b><s>{Math.round(p.price*1.25).toLocaleString('tr-TR')} ₺</s><Badge color="accent" variant="light">+{(p.pts||0).toLocaleString('tr-TR')} puan</Badge></div>
          <p className="pv-desc">EVERUN taban teknolojisi ile gün boyu konfor. Nefes alabilen ISOFIT örgü üst, hafif ve dengeli destek. Günlük koşular ve antrenmanlar için ideal.</p>
          <div>
            <div className="pv-opt__lbl">Renk</div>
            <div className="pv-swatches">
              {["#1f3864","#0bc33f","#e08a2b","#4921ea"].map((c,i)=>(<div key={i} className={"pv-sw"+(sw===i?" active":"")} style={{background:c}} onClick={()=>setSw(i)}/>))}
            </div>
          </div>
          <div>
            <div className="pv-opt__lbl">Beden</div>
            <div className="pv-sizes">{["39","40","41","42","43","44","45"].map(s=>(<div key={s} className={"pv-size"+(size===s?" active":"")} onClick={()=>setSize(s)}>{s}</div>))}</div>
          </div>
          <div className="pv-buy">
            <Button color="accent" size="lg" iconStart="handcart" onClick={()=>onAdd(p)} style={{flex:1}}>Sepete ekle</Button>
            <Button variant="outline" color="dark" size="lg" iconStart="heart" aria-label="Favori">Favori</Button>
          </div>
          <div className="pv-perks">
            <div className="pv-perk"><Icon name="check-circle" size={16}/>Ücretsiz kargo</div>
            <div className="pv-perk"><Icon name="check-circle" size={16}/>30 gün iade</div>
            <div className="pv-perk"><Icon name="check-circle" size={16}/>2 yıl garanti</div>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
}

window.ProductView = ProductView;
