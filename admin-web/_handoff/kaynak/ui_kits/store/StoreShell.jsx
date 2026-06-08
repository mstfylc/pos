/* Uyanık Store — header, category nav, footer. Exposes window.StoreShell */
const SDS = window.MetronicDesignSystem_a73f8f;

const STORE_CSS = `
.st-app{min-height:100vh;display:flex;flex-direction:column;background:var(--surface-page);}
.st-head{position:sticky;top:0;z-index:30;background:var(--surface-card);border-bottom:1px solid var(--border-default);}
.st-head__row{display:flex;align-items:center;gap:22px;padding:0 32px;height:68px;max-width:1240px;margin:0 auto;}
.st-brand{display:flex;align-items:center;gap:10px;cursor:pointer;flex:none;}
.st-brand img{height:34px;}
.st-brand .wm{font-family:var(--font-wordmark);font-weight:800;font-size:19px;letter-spacing:-0.01em;color:var(--color-primary);}
.st-search{flex:1;max-width:420px;display:flex;align-items:center;gap:9px;height:42px;padding:0 14px;border-radius:var(--radius-md);
  background:var(--color-grey-50);border:1px solid var(--border-default);color:var(--text-placeholder);}
.st-search input{border:0;background:none;outline:none;width:100%;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-heading);}
.st-head__actions{display:flex;align-items:center;gap:6px;margin-left:auto;}
.st-points{display:flex;align-items:center;gap:7px;height:38px;padding:0 13px;border-radius:var(--radius-full);
  background:var(--color-accent-soft);color:var(--color-accent-accent);font:var(--fw-semibold) 13px/1 var(--font-sans);cursor:pointer;}
.st-cart{position:relative;}
.st-cart__badge{position:absolute;top:-3px;right:-3px;min-width:17px;height:17px;border-radius:999px;background:var(--color-accent);
  color:#fff;font:var(--fw-bold) 10px/17px var(--font-sans);text-align:center;padding:0 4px;box-sizing:border-box;border:2px solid var(--surface-card);}
.st-nav{border-top:1px solid var(--border-default);}
.st-nav__row{display:flex;align-items:center;gap:4px;padding:0 32px;height:48px;max-width:1240px;margin:0 auto;}
.st-nav a{font:var(--fw-medium) 13.5px/1 var(--font-sans);color:var(--text-body);padding:8px 12px;border-radius:var(--radius-sm);cursor:pointer;}
.st-nav a:hover{background:var(--color-grey-100);color:var(--text-heading);}
.st-nav a.active{color:var(--color-primary);font-weight:var(--fw-semibold);}
.st-main{flex:1;max-width:1240px;width:100%;margin:0 auto;padding:28px 32px 48px;box-sizing:border-box;}
.st-foot{background:var(--color-primary);color:#fff;margin-top:auto;}
.st-foot__row{max-width:1240px;margin:0 auto;padding:30px 32px;display:flex;align-items:center;justify-content:space-between;gap:20px;}
.st-foot .wm{font-family:var(--font-wordmark);font-weight:800;font-size:18px;color:#fff;letter-spacing:-0.01em;}
.st-foot__brand{display:flex;align-items:center;gap:10px;margin-bottom:7px;}
.st-foot__brand img{height:30px;}
.st-foot small{color:rgba(255,255,255,.6);font:var(--fw-regular) 12px/1.5 var(--font-sans);}
.st-foot__links{display:flex;gap:22px;}
.st-foot__links span{color:rgba(255,255,255,.85);font:var(--fw-medium) 13px/1 var(--font-sans);cursor:pointer;}
`;
function injectStore(){if(document.getElementById('mt-store-css'))return;const e=document.createElement('style');e.id='mt-store-css';e.textContent=STORE_CSS;document.head.appendChild(e);}

const CATS = ["Tümü","Koşu","Antrenman","Patika","Yaşam","Çocuk","İndirim"];

function StoreShell({ active, onNav, cartCount, points, children }){
  React.useEffect(()=>{injectStore();},[]);
  return (
    <div className="st-app">
      <header className="st-head">
        <div className="st-head__row">
          <div className="st-brand" onClick={()=>onNav('store')}>
            <img src="../../assets/logo-mark.svg" alt="Uyanık"/><span className="wm">Uyanık</span>
          </div>
          <div className="st-search"><SDS.Icon name="magnifier" size={17}/><input placeholder="Ürün, marka veya kategori ara…"/></div>
          <div className="st-head__actions">
            <div className="st-points" onClick={()=>onNav('account')}><SDS.Icon name="star" size={15}/>{points.toLocaleString('tr-TR')} puan</div>
            <SDS.IconButton icon="heart" aria-label="Favoriler"/>
            <SDS.IconButton icon="profile-circle" aria-label="Hesabım" onClick={()=>onNav('account')}/>
            <div className="st-cart">
              <SDS.IconButton icon="handcart" aria-label="Sepet" onClick={()=>onNav('checkout')}/>
              {cartCount>0 && <span className="st-cart__badge">{cartCount}</span>}
            </div>
          </div>
        </div>
        <div className="st-nav">
          <div className="st-nav__row">
            {CATS.map((c,i)=>(<a key={c} className={i===0&&active==='store'?'active':''} onClick={()=>onNav('store')}>{c}</a>))}
          </div>
        </div>
      </header>
      <main className="st-main">{children}</main>
      <footer className="st-foot">
        <div className="st-foot__row">
          <div>
            <div className="st-foot__brand"><img src="../../assets/logo-owl-dark.svg" alt=""/><div className="wm">Uyanık</div></div>
            <small>Sadakat puanlarınızla daha fazlası. © 2026 Uyanık.</small>
          </div>
          <div className="st-foot__links"><span>Yardım</span><span>İade & Değişim</span><span>Sadakat Programı</span><span>İletişim</span></div>
        </div>
      </footer>
    </div>
  );
}

window.StoreShell = StoreShell;
