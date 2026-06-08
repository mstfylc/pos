/* Uyanık Admin — shared shell: 15-item sidebar + topbar. window.AdminShell.* */
const ASMDS = window.MetronicDesignSystem_a73f8f;

const ADMIN_SHELL_CSS = `
.as-app{display:flex;min-height:100vh;background:var(--surface-page);}
.as-side{width:248px;flex:none;background:#14233f;display:flex;flex-direction:column;position:sticky;top:0;height:100vh;z-index:20;}
.as-side__brand{display:flex;align-items:center;gap:11px;height:62px;padding:0 20px;flex:none;border-bottom:1px solid rgba(255,255,255,.08);}
.as-side__brand img{height:28px;}
.as-side__brand .wm{font-family:var(--font-wordmark);font-weight:800;font-size:17px;letter-spacing:-0.01em;color:#fff;}
.as-side__scroll{flex:1;overflow-y:auto;padding:12px 12px 22px;}
.as-side__scroll::-webkit-scrollbar{width:6px;}
.as-side__scroll::-webkit-scrollbar-thumb{background:rgba(255,255,255,.14);border-radius:3px;}
.as-sec{margin-top:16px;padding:0 10px 7px;font:var(--fw-semibold) 10px/1 var(--font-sans);letter-spacing:.09em;text-transform:uppercase;color:rgba(255,255,255,.36);}
.as-sec:first-child{margin-top:2px;}
.as-nav{appearance:none;width:100%;border:0;background:none;cursor:pointer;text-align:left;display:flex;align-items:center;gap:11px;
  padding:8px 11px;border-radius:var(--radius-md);font:var(--fw-medium) 13px/1 var(--font-sans);color:rgba(255,255,255,.7);transition:all .12s;margin-top:2px;}
.as-nav:hover{background:rgba(255,255,255,.07);color:#fff;}
.as-nav--active{background:var(--color-primary);color:#fff;font-weight:var(--fw-semibold);box-shadow:0 2px 8px rgba(0,0,0,.18);}
.as-nav__ic{flex:none;opacity:.92;}
.as-nav__count{margin-left:auto;font:var(--fw-semibold) 10px/1 var(--font-sans);background:var(--color-accent);color:#fff;padding:3px 7px;border-radius:999px;}
.as-nav--active .as-nav__count{background:rgba(255,255,255,.22);}

.as-main{flex:1;display:flex;flex-direction:column;min-width:0;}
.as-top{height:62px;flex:none;background:var(--surface-card);border-bottom:1px solid var(--border-default);
  display:flex;align-items:center;justify-content:space-between;padding:0 24px;position:sticky;top:0;z-index:30;}
.as-top__left{display:flex;align-items:center;gap:16px;}
.as-branch{position:relative;}
.as-branch__btn{appearance:none;cursor:pointer;display:flex;align-items:center;gap:9px;height:40px;padding:0 11px;border:1px solid var(--border-default);border-radius:var(--radius-md);background:var(--color-grey-50);transition:all .12s;}
.as-branch__btn:hover{border-color:var(--border-strong);background:#fff;}
.as-branch__pin{width:28px;height:28px;border-radius:7px;background:var(--color-primary-soft);display:flex;align-items:center;justify-content:center;flex:none;}
.as-branch__txt{display:flex;flex-direction:column;line-height:1.2;text-align:left;}
.as-branch__txt b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.as-branch__txt span{font:var(--fw-medium) 10.5px/1 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.as-menu{position:absolute;top:calc(100% + 8px);min-width:236px;background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-lg);padding:7px;z-index:50;}
.as-menu--left{left:0;} .as-menu--right{right:0;}
.as-menu__item{appearance:none;width:100%;border:0;background:none;cursor:pointer;text-align:left;display:flex;align-items:center;gap:11px;padding:9px 11px;border-radius:var(--radius-md);font:var(--fw-medium) 13px/1.2 var(--font-sans);color:var(--text-body);transition:background .12s;}
.as-menu__item:hover{background:var(--color-grey-100);}
.as-menu__item--active{background:var(--color-primary-soft);color:var(--color-primary);font-weight:var(--fw-semibold);}
.as-menu__item small{display:block;font:var(--fw-regular) 11px/1.3 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.as-menu__item--active small{color:var(--color-primary);opacity:.75;}
.as-menu__sep{height:1px;background:var(--border-default);margin:6px 4px;}
.as-search{display:flex;align-items:center;gap:9px;height:40px;width:264px;padding:0 12px;border-radius:var(--radius-md);background:var(--color-grey-50);border:1px solid var(--border-default);color:var(--text-placeholder);}
.as-search:focus-within{border-color:var(--color-primary);background:#fff;}
.as-search input{border:0;background:none;outline:none;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-heading);width:100%;}
.as-search kbd{font:var(--fw-semibold) 10px/1 var(--font-sans);color:var(--text-placeholder);border:1px solid var(--border-default);border-radius:5px;padding:3px 6px;background:#fff;}
.as-top__right{display:flex;align-items:center;gap:6px;}
.as-bell{position:relative;}
.as-bell__dot{position:absolute;top:7px;right:7px;width:8px;height:8px;border-radius:999px;background:var(--color-accent);border:2px solid var(--surface-card);}
.as-noti{position:absolute;top:calc(100% + 8px);right:0;width:340px;background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-lg);z-index:50;overflow:hidden;}
.as-noti__hd{display:flex;align-items:center;justify-content:space-between;padding:13px 16px;border-bottom:1px solid var(--border-default);}
.as-noti__hd b{font:var(--fw-semibold) 13.5px/1 var(--font-sans);color:var(--text-heading);}
.as-noti__hd button{appearance:none;border:0;background:none;cursor:pointer;font:var(--fw-semibold) 11.5px/1 var(--font-sans);color:var(--color-primary);}
.as-noti__list{max-height:340px;overflow-y:auto;}
.as-noti__i{display:flex;gap:11px;padding:12px 16px;border-bottom:1px solid var(--border-default);cursor:pointer;transition:background .12s;}
.as-noti__i:hover{background:var(--color-grey-50);}
.as-noti__i:last-child{border-bottom:0;}
.as-noti__ic{width:34px;height:34px;border-radius:9px;flex:none;display:flex;align-items:center;justify-content:center;}
.as-noti__tx b{font:var(--fw-semibold) 12.5px/1.3 var(--font-sans);color:var(--text-heading);display:block;}
.as-noti__tx span{font:var(--fw-regular) 11.5px/1.4 var(--font-sans);color:var(--text-muted);display:block;margin-top:2px;}
.as-noti__tx time{font:var(--fw-medium) 10.5px/1 var(--font-sans);color:var(--text-placeholder);display:block;margin-top:5px;}
.as-noti__unread{width:7px;height:7px;border-radius:50%;background:var(--color-accent);flex:none;margin-top:6px;}
.as-noti__ft{padding:11px 16px;text-align:center;border-top:1px solid var(--border-default);}
.as-noti__ft button{appearance:none;border:0;background:none;cursor:pointer;font:var(--fw-semibold) 12px/1 var(--font-sans);color:var(--text-body);}
.as-noti__empty{padding:40px 20px;text-align:center;font:var(--fw-regular) 12.5px/1.5 var(--font-sans);color:var(--text-muted);}
.as-user{position:relative;}
.as-user__btn{appearance:none;cursor:pointer;display:flex;align-items:center;gap:9px;height:44px;padding:0 8px 0 6px;border:0;border-radius:var(--radius-md);background:none;transition:background .12s;margin-left:4px;}
.as-user__btn:hover{background:var(--color-grey-100);}
.as-user__txt{display:flex;flex-direction:column;line-height:1.2;text-align:left;}
.as-user__txt b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);}
.as-user__txt span{font:var(--fw-medium) 10.5px/1 var(--font-sans);color:var(--text-muted);margin-top:2px;}

.as-content{flex:1;padding:24px 26px 40px;min-width:0;}
.as-pagehd{display:flex;align-items:flex-end;justify-content:space-between;gap:20px;margin-bottom:20px;flex-wrap:wrap;}
.as-pagehd h1{font:var(--fw-bold) 21px/1.2 var(--font-sans);letter-spacing:var(--ls-tight);color:var(--text-heading);}
.as-pagehd p{font:var(--fw-regular) 13px/1.4 var(--font-sans);color:var(--text-muted);margin-top:4px;}
.as-crumb{display:flex;align-items:center;gap:7px;font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-muted);margin-bottom:7px;}
.as-crumb .sep{color:var(--border-strong);}
.as-crumb b{color:var(--text-body);font-weight:var(--fw-semibold);}
.as-pagehd__act{display:flex;gap:10px;align-items:center;}

.as-filter{display:flex;align-items:center;gap:10px;flex-wrap:wrap;margin-bottom:16px;}
.as-filter__sp{flex:1;}
.as-burger{display:none;align-items:center;justify-content:center;width:40px;height:40px;border-radius:var(--radius-md);border:1px solid var(--border-default);background:var(--surface-card);cursor:pointer;flex:none;color:var(--text-body);}
.as-burger:hover{background:var(--color-grey-100);}
.as-scrim{display:none;}
@media (max-width:900px){
  .as-side{position:fixed;left:-260px;transition:left .22s cubic-bezier(.2,.8,.3,1);z-index:60;box-shadow:0 0 40px rgba(0,0,0,.3);}
  .as-side--open{left:0;}
  .as-scrim{display:block;position:fixed;inset:0;background:rgba(15,28,51,.5);z-index:55;animation:asfade .2s;}
  @keyframes asfade{from{opacity:0;}to{opacity:1;}}
  .as-burger{display:flex;}
  .as-search{display:none;}
  .as-top{padding:0 16px;}
  .as-content{padding:18px 16px 36px;}
  .as-branch__txt span{display:none;}
  .as-pagehd{flex-direction:column;align-items:stretch;gap:14px;}
  .as-pagehd__act{flex-wrap:wrap;}
}
@media (max-width:560px){
  .as-branch__txt{display:none;}
  .as-top__right .mticon-btn{display:none;}
  .as-pagehd h1{font-size:19px;}
  .as-filter > div[style]{width:100%!important;}
}
`;

function injectAdminShell(){ if(document.getElementById('as-shell-css'))return; const e=document.createElement('style');e.id='as-shell-css';e.textContent=ADMIN_SHELL_CSS;document.head.appendChild(e);}

const ADMIN_NAV = [
  { sec:"Genel", items:[
    { id:"home", label:"Ana Sayfa", icon:"home" },
    { id:"orders", label:"Siparişler", icon:"handcart", count:"12" },
    { id:"products", label:"Ürünler", icon:"notepad-bookmark" },
    { id:"categories", label:"Kategoriler", icon:"category" },
    { id:"stock", label:"Stok / Depo", icon:"folder" },
    { id:"transfer", label:"Stok Transferi", icon:"share" },
    { id:"purchase", label:"Satın Alma", icon:"files" },
  ]},
  { sec:"Müşteri & Sadakat", items:[
    { id:"customers", label:"Müşteriler", icon:"people" },
    { id:"campaigns", label:"İndirim & Kampanya", icon:"price-tag" },
    { id:"loyalty", label:"Sadakat", icon:"heart" },
  ]},
  { sec:"Yönetim", items:[
    { id:"users", label:"Kullanıcılar", icon:"profile-circle" },
    { id:"roles", label:"Roller & Yetkiler", icon:"key" },
    { id:"company", label:"Şirket / Şube / POS", icon:"dots-square" },
    { id:"reports", label:"Raporlar", icon:"chart-line-up" },
    { id:"settings", label:"Ayarlar", icon:"setting-2" },
  ]},
];

const ADMIN_BRANCHES = [
  { id:"cayyolu", name:"Çayyolu Şubesi", sub:"Ankara · Açık", depot:false },
  { id:"bagdat", name:"Bağdat Caddesi", sub:"İstanbul · Açık", depot:false },
  { id:"alsancak", name:"Alsancak Şubesi", sub:"İzmir · Açık", depot:false },
  { id:"merkez", name:"Merkez Depo", sub:"Ankara · 7/24", depot:true },
];

function useOutside(ref, cb){
  React.useEffect(()=>{ function h(e){ if(ref.current && !ref.current.contains(e.target)) cb(); }
    document.addEventListener('mousedown',h); return ()=>document.removeEventListener('mousedown',h); },[cb]);
}

function Sidebar({ active, onNavigate, open }){
  return (
    <aside className={"as-side"+(open?" as-side--open":"")}>
      <div className="as-side__brand"><img src={window.UYANIK_LOGO} alt="Uyanık"/><span className="wm">Uyanık</span></div>
      <nav className="as-side__scroll">
        {ADMIN_NAV.map(g=>(
          <div key={g.sec}>
            <div className="as-sec">{g.sec}</div>
            {g.items.map(it=>(
              <button key={it.id} className={"as-nav"+(active===it.id?" as-nav--active":"")} onClick={()=>onNavigate(it.id)}>
                <ASMDS.Icon className="as-nav__ic" name={it.icon} size={17}/>
                <span>{it.label}</span>
                {it.count && <span className="as-nav__count">{it.count}</span>}
              </button>
            ))}
          </div>
        ))}
      </nav>
    </aside>
  );
}

function Branch(){
  const [open,setOpen]=React.useState(false), [sel,setSel]=React.useState(0), ref=React.useRef(null);
  useOutside(ref,()=>setOpen(false));
  const b=ADMIN_BRANCHES[sel];
  return (
    <div className="as-branch" ref={ref}>
      <button className="as-branch__btn" onClick={()=>setOpen(o=>!o)}>
        <span className="as-branch__pin"><ASMDS.Icon name={b.depot?"folder":"home"} size={15} color="var(--color-primary)"/></span>
        <span className="as-branch__txt"><b>{b.name}</b><span>{b.depot?"Depo":"Şube · POS aktif"}</span></span>
        <ASMDS.Icon name="chevron-down" size={13} color="var(--text-placeholder)" style={{transform:open?'rotate(180deg)':'none',transition:'transform .15s'}}/>
      </button>
      {open && (
        <div className="as-menu as-menu--left">
          {ADMIN_BRANCHES.map((br,i)=>(
            <button key={br.id} className={"as-menu__item"+(i===sel?" as-menu__item--active":"")} onClick={()=>{setSel(i);setOpen(false);}}>
              <ASMDS.Icon name={br.depot?"folder":"home"} size={16} color={i===sel?"var(--color-primary)":"var(--text-muted)"}/>
              <span>{br.name}<small>{br.sub}</small></span>
              {i===sel && <ASMDS.Icon name="check-circle" size={15} color="var(--color-primary)" style={{marginLeft:'auto'}}/>}
            </button>
          ))}
          <div className="as-menu__sep"></div>
          <button className="as-menu__item" onClick={()=>{setOpen(false);window.__adminNav&&window.__adminNav("company");}}><ASMDS.Icon name="setting-2" size={16} color="var(--text-muted)"/><span>Tüm şubeleri yönet</span></button>
        </div>
      )}
    </div>
  );
}

function UserMenu(){
  const [open,setOpen]=React.useState(false), ref=React.useRef(null);
  useOutside(ref,()=>setOpen(false));
  return (
    <div className="as-user" ref={ref}>
      <button className="as-user__btn" onClick={()=>setOpen(o=>!o)}>
        <ASMDS.Avatar name="Selin Aydın" size={34} status="online"/>
        <span className="as-user__txt"><b>Selin Aydın</b><span>Şube Müdürü</span></span>
        <ASMDS.Icon name="chevron-down" size={13} color="var(--text-placeholder)"/>
      </button>
      {open && (
        <div className="as-menu as-menu--right">
          <button className="as-menu__item" onClick={()=>{setOpen(false);window.__adminNav&&window.__adminNav("users");}}><ASMDS.Icon name="profile-circle" size={16} color="var(--text-muted)"/><span>Profilim</span></button>
          <button className="as-menu__item" onClick={()=>{setOpen(false);window.__adminNav&&window.__adminNav("settings");}}><ASMDS.Icon name="setting-2" size={16} color="var(--text-muted)"/><span>Hesap ayarları</span></button>
          <div className="as-menu__sep"></div>
          <button className="as-menu__item" style={{color:'var(--color-danger)'}} onClick={()=>{setOpen(false);window.__adminLogout&&window.__adminLogout();}}><ASMDS.Icon name="exit-right" size={16} color="var(--color-danger)"/><span>Çıkış yap</span></button>
        </div>
      )}
    </div>
  );
}

const NOTIFICATIONS = [
  { id:1, icon:"dots-square", bg:"var(--color-accent-soft)", fg:"var(--color-accent)", title:"Esik-alti stok uyarısı", desc:"7 ürün eşik değerinin altında", time:"5 dk önce", unread:true, nav:"stock" },
  { id:2, icon:"handcart", bg:"var(--color-primary-soft)", fg:"var(--color-primary)", title:"Yeni sipariş · UYK-2048", desc:"Çayyolu şubesi · 248 ₺", time:"8 dk önce", unread:true, nav:"orders" },
  { id:3, icon:"heart", bg:"var(--color-success-soft)", fg:"var(--color-success)", title:"32 yeni sadakat üyesi", desc:"Bugün kaydolan müşteriler", time:"1 saat önce", unread:false, nav:"customers" },
  { id:4, icon:"price-tag", bg:"var(--color-primary-soft)", fg:"var(--color-primary)", title:"Kampanya sona eriyor", desc:"“Hafta sonu kahve” 2 gün kaldı", time:"3 saat önce", unread:false, nav:"campaigns" },
];

function NotificationBell({ onNavigate }){
  const [open,setOpen]=React.useState(false);
  const [items,setItems]=React.useState(NOTIFICATIONS);
  const ref=React.useRef(null);
  useOutside(ref,()=>setOpen(false));
  const unread=items.filter(i=>i.unread).length;
  return (
    <span className="as-bell" ref={ref}>
      <ASMDS.IconButton icon="message-notif" aria-label="Bildirimler" onClick={()=>setOpen(o=>!o)}/>
      {unread>0 && <span className="as-bell__dot"></span>}
      {open && (
        <div className="as-noti">
          <div className="as-noti__hd"><b>Bildirimler {unread>0?`(${unread})`:""}</b>{unread>0 && <button onClick={()=>setItems(items.map(i=>({...i,unread:false})))}>Tümünü okundu işaretle</button>}</div>
          <div className="as-noti__list">
            {items.length===0 ? <div className="as-noti__empty">Yeni bildirim yok.</div> :
              items.map(n=>(
                <div className="as-noti__i" key={n.id} onClick={()=>{ setItems(items.map(i=>i.id===n.id?{...i,unread:false}:i)); setOpen(false); onNavigate&&onNavigate(n.nav); }}>
                  <span className="as-noti__ic" style={{background:n.bg}}><ASMDS.Icon name={n.icon} size={16} color={n.fg}/></span>
                  <div className="as-noti__tx" style={{flex:1}}><b>{n.title}</b><span>{n.desc}</span><time>{n.time}</time></div>
                  {n.unread && <span className="as-noti__unread"></span>}
                </div>
              ))}
          </div>
          <div className="as-noti__ft"><button onClick={()=>setOpen(false)}>Kapat</button></div>
        </div>
      )}
    </span>
  );
}

function Topbar({ onBurger }){
  const nav=(id)=>window.__adminNav&&window.__adminNav(id);
  return (
    <header className="as-top">
      <div className="as-top__left">
        <button className="as-burger" onClick={onBurger} aria-label="Menü"><ASMDS.Icon name="dots-square" size={19}/></button>
        <Branch/>
        <div className="as-search"><ASMDS.Icon name="magnifier" size={15}/><input placeholder="Ürün, sipariş, müşteri ara…" onKeyDown={e=>{ if(e.key==="Enter" && e.target.value.trim()) nav("products"); }}/><kbd>⌘K</kbd></div>
      </div>
      <div className="as-top__right">
        <ASMDS.IconButton icon="calendar" aria-label="Takvim" onClick={()=>nav("reports")}/>
        <NotificationBell onNavigate={nav}/>
        <UserMenu/>
      </div>
    </header>
  );
}

function PageHeader({ crumb, title, desc, actions }){
  return (
    <div className="as-pagehd">
      <div>
        {crumb && <div className="as-crumb">{crumb.map((c,i)=>(<React.Fragment key={i}>{i>0 && <span className="sep">/</span>}{i===crumb.length-1?<b>{c}</b>:<span>{c}</span>}</React.Fragment>))}</div>}
        <h1>{title}</h1>
        {desc && <p>{desc}</p>}
      </div>
      {actions && <div className="as-pagehd__act">{actions}</div>}
    </div>
  );
}

function AdminShell({ active, onNavigate, children }){
  React.useEffect(()=>{ injectAdminShell(); },[]);
  const [menuOpen,setMenuOpen]=React.useState(false);
  React.useEffect(()=>{ setMenuOpen(false); },[active]);
  function nav(id){ onNavigate(id); setMenuOpen(false); }
  return (
    <div className="as-app">
      {menuOpen && <div className="as-scrim" onClick={()=>setMenuOpen(false)}/>}
      <Sidebar active={active} onNavigate={nav} open={menuOpen}/>
      <div className="as-main">
        <Topbar onBurger={()=>setMenuOpen(o=>!o)}/>
        <div className="as-content">{children}</div>
      </div>
    </div>
  );
}

window.AdminKit = { AdminShell, PageHeader, ADMIN_NAV };
window.AdminShellHeader = PageHeader;
