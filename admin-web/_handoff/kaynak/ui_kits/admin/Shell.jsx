/* Metronic admin shell — Sidebar + Topbar + AppShell. Exposes to window. */
const MTDS = window.MetronicDesignSystem_a73f8f;

const SHELL_CSS = `
.mt-app{display:flex;min-height:100%;background:var(--surface-page);}
.mt-side{width:248px;flex:none;background:var(--surface-card);border-right:1px solid var(--border-default);
  display:flex;flex-direction:column;position:sticky;top:0;height:100vh;}
.mt-side__brand{display:flex;align-items:center;gap:10px;height:64px;padding:0 22px;flex:none;}
.mt-side__brand img{height:32px;}
.mt-side__brand .logo-dark{display:none;}
[data-theme="dark"] .mt-side__brand .logo-light{display:none;}
[data-theme="dark"] .mt-side__brand .logo-dark{display:block;}
[data-theme="dark"] .mt-side__brand .wm{color:#f5f5f5;}
.mt-side__brand .wm{font-family:var(--font-wordmark);font-weight:800;font-size:18px;letter-spacing:-0.01em;color:#1f3864;}
.mt-side__scroll{flex:1;overflow-y:auto;padding:8px 16px 20px;}
.mt-side__sec{margin-top:18px;padding:0 10px 6px;font:var(--fw-semibold) 11px/1 var(--font-sans);
  letter-spacing:.06em;text-transform:uppercase;color:var(--text-placeholder);}
.mt-nav{appearance:none;width:100%;border:0;background:none;cursor:pointer;text-align:left;
  display:flex;align-items:center;gap:11px;padding:8px 10px;border-radius:var(--radius-md);
  font:var(--fw-medium) 13.5px/1 var(--font-sans);color:var(--text-body);transition:all .12s;margin-top:2px;}
.mt-nav:hover{background:var(--color-grey-100);color:var(--text-heading);}
.mt-nav--active{background:var(--color-primary-soft);color:var(--color-primary);font-weight:var(--fw-semibold);}
.mt-nav__ic{flex:none;color:inherit;opacity:.9;}
.mt-nav__chev{margin-left:auto;color:var(--text-placeholder);}
.mt-top{height:64px;flex:none;background:var(--surface-card);border-bottom:1px solid var(--border-default);
  display:flex;align-items:center;justify-content:space-between;padding:0 28px;position:sticky;top:0;z-index:20;}
.mt-top__crumb{display:flex;align-items:center;gap:8px;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-muted);}
.mt-top__crumb b{color:var(--text-heading);font-weight:var(--fw-semibold);}
.mt-top__crumb .sep{color:var(--border-strong);}
.mt-top__right{display:flex;align-items:center;gap:6px;}
.mt-search{display:flex;align-items:center;gap:8px;height:38px;width:200px;padding:0 12px;border-radius:var(--radius-md);
  background:var(--color-grey-50);border:1px solid var(--border-default);color:var(--text-placeholder);font-size:13px;}
.mt-search input{border:0;background:none;outline:none;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-heading);width:100%;}
.mt-main{flex:1;display:flex;flex-direction:column;min-width:0;}
.mt-content{flex:1;padding:28px;}
.mt-pagehd{margin-bottom:22px;}
.mt-pagehd h1{font:var(--fw-semibold) 20px/1.2 var(--font-sans);letter-spacing:var(--ls-tight);color:var(--text-heading);}
.mt-pagehd p{font:var(--fw-regular) 13px/1.4 var(--font-sans);color:var(--text-muted);margin-top:3px;}
`;

function injectShell(){
  if(document.getElementById('mt-shell-css')) return;
  const el=document.createElement('style');el.id='mt-shell-css';el.textContent=SHELL_CSS;document.head.appendChild(el);
}

const NAV = [
  { sec: "Kullanıcı", items: [
    { id:"dashboard", label:"Panolar", icon:"element-11" },
    { id:"onboarding", label:"Başlangıç", icon:"rocket" },
    { id:"profile", label:"Herkese Açık Profil", icon:"profile-circle", chev:true },
    { id:"account", label:"Hesabım", icon:"setting-2", chev:true },
    { id:"auth", label:"Kimlik Doğrulama", icon:"key", chev:true },
  ]},
  { sec: "Sayfalar", items: [
    { id:"marketplace", label:"Pazaryeri", icon:"handcart" },
    { id:"social", label:"Sosyal", icon:"messages" },
    { id:"company", label:"Şirket", icon:"category" },
    { id:"blog", label:"Blog", icon:"notepad" },
  ]},
  { sec: "Uygulamalar", items: [
    { id:"projects", label:"Projeler", icon:"folder" },
    { id:"ecommerce", label:"E-Ticaret", icon:"price-tag" },
  ]},
];

function Sidebar({ active, onNavigate }){
  return (
    <aside className="mt-side">
      <div className="mt-side__brand">
        <img className="logo-light" src="../../assets/logo-mark.svg" alt="Uyanık" />
        <img className="logo-dark" src="../../assets/logo-owl-dark.svg" alt="Uyanık" />
        <span className="wm">Uyanık</span>
      </div>
      <nav className="mt-side__scroll">
        {NAV.map(group => (
          <div key={group.sec}>
            <div className="mt-side__sec">{group.sec}</div>
            {group.items.map(it => (
              <button key={it.id} className={"mt-nav" + (active===it.id ? " mt-nav--active":"")} onClick={()=>onNavigate(it.id)}>
                <MTDS.Icon className="mt-nav__ic" name={it.icon} size={18} />
                <span>{it.label}</span>
                {it.chev && <MTDS.Icon className="mt-nav__chev" name="chevron-down" size={14} />}
              </button>
            ))}
          </div>
        ))}
      </nav>
    </aside>
  );
}

function ThemeToggle(){
  const [dark, setDark] = React.useState(false);
  React.useEffect(()=>{
    const root = document.documentElement;
    if(dark) root.setAttribute('data-theme','dark'); else root.removeAttribute('data-theme');
  },[dark]);
  const sun = '<svg viewBox="0 0 24 24" fill="none" style="width:100%;height:100%"><circle cx="12" cy="12" r="4.5" fill="currentColor"/><g stroke="currentColor" stroke-width="1.8" stroke-linecap="round"><path d="M12 2.5v2.5M12 19v2.5M2.5 12H5M19 12h2.5M5 5l1.8 1.8M17.2 17.2 19 19M19 5l-1.8 1.8M6.8 17.2 5 19"/></g></svg>';
  const moon = '<svg viewBox="0 0 24 24" fill="none" style="width:100%;height:100%"><path d="M20 14.5A8 8 0 1 1 9.5 4a6.5 6.5 0 0 0 10.5 10.5Z" fill="currentColor"/></svg>';
  return (
    <button className="mtbtn mtbtn--ghost mtbtn--md mtbtn--icon c-secondary" aria-label="Temayı değiştir" onClick={()=>setDark(d=>!d)}>
      <span className="mt-icon" style={{width:18,height:18}} dangerouslySetInnerHTML={{__html: dark ? sun : moon}} />
    </button>
  );
}

function Topbar({ crumb }){
  return (
    <header className="mt-top">
      <div className="mt-top__crumb">{crumb.map((c,i)=>(
        <React.Fragment key={i}>{i>0 && <span className="sep">/</span>}{i===crumb.length-1 ? <b>{c}</b> : <span>{c}</span>}</React.Fragment>
      ))}</div>
      <div className="mt-top__right">
        <div className="mt-search"><MTDS.Icon name="magnifier" size={16} /><input placeholder="Ara…" /></div>
        <ThemeToggle />
        <MTDS.IconButton icon="message-notif" aria-label="Bildirimler" />
        <MTDS.IconButton icon="messages" aria-label="Mesajlar" />
        <MTDS.IconButton icon="element-11" aria-label="Uygulamalar" />
        <div style={{marginLeft:6}}><MTDS.Avatar name="Jenny Klabber" size={36} status="online" /></div>
      </div>
    </header>
  );
}

function AppShell({ active, onNavigate, crumb, children }){
  React.useEffect(()=>{ injectShell(); },[]);
  return (
    <div className="mt-app">
      <Sidebar active={active} onNavigate={onNavigate} />
      <div className="mt-main">
        <Topbar crumb={crumb} />
        <div className="mt-content">{children}</div>
      </div>
    </div>
  );
}

window.MTShell = { AppShell, Sidebar, Topbar };
