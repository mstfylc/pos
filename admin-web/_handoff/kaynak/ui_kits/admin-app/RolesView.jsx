/* Screen 13 — Roller & Yetkiler. window.RolesView */
const RVMDS = window.MetronicDesignSystem_a73f8f;

const RV_CSS = `
.rv-wrap{display:grid;grid-template-columns:240px 1fr;gap:18px;align-items:start;}
@media(max-width:820px){.rv-wrap{grid-template-columns:1fr;}}
.rv-roles{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);padding:8px;}
.rv-role{appearance:none;width:100%;border:0;background:none;cursor:pointer;text-align:left;display:flex;align-items:center;gap:11px;padding:11px 12px;border-radius:var(--radius-md);transition:background .12s;margin-bottom:2px;}
.rv-role:hover{background:var(--color-grey-50);}
.rv-role.on{background:var(--color-primary-soft);}
.rv-role__ic{width:34px;height:34px;border-radius:9px;display:flex;align-items:center;justify-content:center;flex:none;}
.rv-role__t{flex:1;min-width:0;}
.rv-role__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.rv-role__t span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);}
.rv-role.on .rv-role__t b{color:var(--color-primary);}
.rv-panel{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.rv-phd{display:flex;align-items:center;gap:13px;padding:18px 20px;border-bottom:1px solid var(--border-default);}
.rv-phd__ic{width:44px;height:44px;border-radius:12px;display:flex;align-items:center;justify-content:center;flex:none;}
.rv-phd__t b{font:var(--fw-bold) 16px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);display:block;}
.rv-phd__t span{font:var(--fw-regular) 12px/1.3 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;}
.rv-matrix{padding:6px 20px 14px;}
.rv-mrow{display:grid;grid-template-columns:1fr auto;align-items:center;gap:16px;padding:13px 0;border-bottom:1px solid var(--border-default);}
.rv-mrow:last-child{border-bottom:0;}
.rv-mrow__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.rv-mrow__t span{font:var(--fw-regular) 11.5px/1.3 var(--font-sans);color:var(--text-muted);display:block;margin-top:2px;}
.rv-perms{display:flex;gap:7px;}
.rv-perm{appearance:none;cursor:pointer;border:1px solid var(--border-default);background:var(--surface-card);border-radius:8px;padding:6px 11px;font:var(--fw-semibold) 11.5px/1 var(--font-sans);color:var(--text-muted);transition:all .12s;display:flex;align-items:center;gap:5px;}
.rv-perm:hover{border-color:var(--border-strong);}
.rv-perm.on{background:var(--color-primary);border-color:var(--color-primary);color:#fff;}
.rv-perm.on.view{background:var(--color-success);border-color:var(--color-success);}
`;
function injectRV(){ if(document.getElementById('rv-css'))return; const e=document.createElement('style');e.id='rv-css';e.textContent=RV_CSS;document.head.appendChild(e); }

const RV_ROLES=[
  {id:"admin",label:"Yönetici",desc:"Tam yetki",bg:"var(--color-primary)",icon:"key",users:1},
  {id:"mudur",label:"Şube Müdürü",desc:"Şube yönetimi",bg:"var(--color-accent)",icon:"verify",users:3},
  {id:"barista",label:"Barista",desc:"Üretim & sipariş",bg:"var(--color-success)",icon:"heart",users:7},
  {id:"kasiyer",label:"Kasiyer",desc:"Yalnızca POS",bg:"#78829d",icon:"handcart",users:4},
];
const RV_MODULES=[
  {id:"orders",label:"Siparişler",desc:"Sipariş görüntüleme ve yönetimi"},
  {id:"products",label:"Ürünler & Kategoriler",desc:"Menü ve katalog"},
  {id:"stock",label:"Stok & Depo",desc:"Stok, transfer, satın alma"},
  {id:"customers",label:"Müşteriler & Sadakat",desc:"Müşteri ve puan yönetimi"},
  {id:"reports",label:"Raporlar",desc:"Satış ve performans raporları"},
  {id:"users",label:"Kullanıcılar & Roller",desc:"Personel ve yetki yönetimi"},
  {id:"settings",label:"Ayarlar",desc:"Şirket ve sistem ayarları"},
];
// permission level per role per module: 0=none,1=view,2=full
const RV_DEFAULTS={
  admin:   {orders:2,products:2,stock:2,customers:2,reports:2,users:2,settings:2},
  mudur:   {orders:2,products:2,stock:2,customers:2,reports:2,users:1,settings:1},
  barista: {orders:2,products:1,stock:1,customers:1,reports:0,users:0,settings:0},
  kasiyer: {orders:2,products:1,stock:0,customers:1,reports:0,users:0,settings:0},
};

function RolesView(){
  React.useEffect(()=>{injectRV();},[]);
  const { Button } = RVMDS;
  const toast = RVMDS.ToastProvider.useToast();
  const [sel,setSel]=React.useState("mudur");
  const [perms,setPerms]=React.useState(RV_DEFAULTS);
  const [dirty,setDirty]=React.useState(false);

  const role=RV_ROLES.find(r=>r.id===sel);
  const isAdmin=sel==="admin";
  function setPerm(mod,level){ if(isAdmin)return; setPerms(p=>({...p,[sel]:{...p[sel],[mod]:level}})); setDirty(true); }
  function save(){ setDirty(false); toast({type:"success",title:"Yetkiler kaydedildi",description:`${role.label} rolü güncellendi.`}); }

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Yönetim","Roller & Yetkiler"]} title="Roller & Yetkiler"
        desc="Rol bazlı ekran erişim yetkilerini yönetin"
        actions={<>
          {dirty && <Button variant="ghost" color="dark" onClick={()=>{setPerms(RV_DEFAULTS);setDirty(false);}}>Sıfırla</Button>}
          <Button color="accent" iconStart="check-circle" disabled={!dirty} onClick={save}>Değişiklikleri kaydet</Button>
        </>}/>
      <div className="rv-wrap">
        <div className="rv-roles">
          {RV_ROLES.map(r=>(
            <button key={r.id} className={"rv-role"+(sel===r.id?" on":"")} onClick={()=>setSel(r.id)}>
              <span className="rv-role__ic" style={{background:r.bg}}><RVMDS.Icon name={r.icon} size={17} color="#fff"/></span>
              <span className="rv-role__t"><b>{r.label}</b><span>{r.users} kullanıcı</span></span>
            </button>
          ))}
        </div>
        <div className="rv-panel">
          <div className="rv-phd">
            <div className="rv-phd__ic" style={{background:role.bg}}><RVMDS.Icon name={role.icon} size={22} color="#fff"/></div>
            <div className="rv-phd__t"><b>{role.label}</b><span>{isAdmin?"Yönetici tüm modüllere tam erişime sahiptir ve değiştirilemez.":"Her modül için erişim seviyesini seçin: Yok · Görüntüle · Tam yetki."}</span></div>
          </div>
          <div className="rv-matrix">
            {RV_MODULES.map(m=>{
              const lvl=perms[sel][m.id];
              return (
                <div className="rv-mrow" key={m.id}>
                  <div className="rv-mrow__t"><b>{m.label}</b><span>{m.desc}</span></div>
                  <div className="rv-perms">
                    <button className={"rv-perm"+(lvl===0?" on":"")} style={lvl===0?{background:"var(--text-muted)",borderColor:"var(--text-muted)",color:"#fff"}:{}} onClick={()=>setPerm(m.id,0)} disabled={isAdmin}>Yok</button>
                    <button className={"rv-perm view"+(lvl===1?" on":"")} onClick={()=>setPerm(m.id,1)} disabled={isAdmin}>{lvl===1&&<RVMDS.Icon name="check-circle" size={12} color="#fff"/>}Görüntüle</button>
                    <button className={"rv-perm"+(lvl===2?" on":"")} onClick={()=>setPerm(m.id,2)} disabled={isAdmin}>{lvl===2&&<RVMDS.Icon name="check-circle" size={12} color="#fff"/>}Tam yetki</button>
                  </div>
                </div>
              );
            })}
          </div>
        </div>
      </div>
    </React.Fragment>
  );
}
window.RolesView = RolesView;
