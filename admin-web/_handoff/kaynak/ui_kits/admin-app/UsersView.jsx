/* Screen 12 — Kullanıcılar (personel). window.UsersView */
const UVMDS = window.MetronicDesignSystem_a73f8f;

const UV_CSS = `
.uv-user{display:flex;align-items:center;gap:11px;}
.uv-user__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.uv-user__t span{font:var(--fw-regular) 11.5px/1 var(--font-sans);color:var(--text-muted);}
.uv-role{display:inline-flex;align-items:center;gap:6px;font:var(--fw-semibold) 11.5px/1 var(--font-sans);padding:5px 10px;border-radius:999px;}
.uv-form{display:flex;flex-direction:column;gap:16px;}
.uv-grid{display:grid;grid-template-columns:1fr 1fr;gap:14px;}
.uv-full{grid-column:1/-1;}
.uv-field{display:flex;flex-direction:column;gap:7px;}
.uv-label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);}
.uv-label i{color:var(--color-danger);font-style:normal;}
.uv-switch{display:flex;align-items:center;justify-content:space-between;gap:12px;padding:13px 15px;border:1px solid var(--border-default);border-radius:var(--radius-md);background:var(--color-grey-50);}
.uv-switch__tx b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.uv-switch__tx span{font:var(--fw-regular) 11.5px/1.4 var(--font-sans);color:var(--text-muted);display:block;margin-top:2px;}
`;
function injectUV(){ if(document.getElementById('uv-css'))return; const e=document.createElement('style');e.id='uv-css';e.textContent=UV_CSS;document.head.appendChild(e); }

const UV_ROLES={
  admin:{label:"Yönetici",bg:"var(--color-primary-soft)",fg:"var(--color-primary)",icon:"key"},
  mudur:{label:"Şube Müdürü",bg:"var(--color-accent-soft)",fg:"var(--color-accent-accent,#b5701b)",icon:"verify"},
  barista:{label:"Barista",bg:"var(--color-success-soft)",fg:"var(--color-success)",icon:"heart"},
  kasiyer:{label:"Kasiyer",bg:"var(--color-grey-100)",fg:"var(--text-body)",icon:"handcart"},
};
const UV_BRANCHES=["Çayyolu Şubesi","Bağdat Caddesi","Alsancak Şubesi","Tüm Şubeler"];
const UV_NAMES=["Selin Aydın","Mert Demir","Ece Kaya","Burak Şahin","Deniz Arslan","Can Öztürk","Zeynep Korkmaz","Murat Çelik","Aslı Yıldız","Onur Taş","Gizem Acar","Kaan Er","Pınar Su","Tolga Bay","Nazlı Tan"];
function uvBuild(){
  const roles=["mudur","barista","kasiyer","barista","admin","kasiyer","barista"];
  return UV_NAMES.map((name,i)=>{
    const role=roles[i%roles.length];
    const slug=name.toLowerCase().replace(/ /g,".").replace(/ç/g,"c").replace(/ş/g,"s").replace(/ı/g,"i").replace(/ğ/g,"g").replace(/ü/g,"u").replace(/ö/g,"o");
    return {id:i,name,role,email:slug+"@uyanik.co",phone:"0532 "+(100+i)+" 45 "+String(10+i).slice(-2),branch:role==="admin"?"Tüm Şubeler":UV_BRANCHES[i%3],active:i%7!==5,last:`0${1+(i%6)}.06.2026`};
  });
}
const UV_DATA=uvBuild();
const UV_PAGE=8;

function UserForm({ initial, onCancel, onSave }){
  const { Input, Select, Switch, Button } = UVMDS;
  const isEdit=!!initial;
  const [v,setV]=React.useState(()=>({name:initial?.name||"",email:initial?.email||"",phone:initial?.phone||"",role:initial?.role||"barista",branch:initial?.branch||UV_BRANCHES[0],active:initial?.active!==false}));
  const [err,setErr]=React.useState({});
  const [tried,setTried]=React.useState(false);
  function set(k,val){ setV(s=>({...s,[k]:val})); if(tried) validate({...v,[k]:val}); }
  function validate(s){ const e={}; if(!s.name.trim())e.name="Ad soyad zorunludur."; if(!s.email.trim())e.email="E-posta zorunludur."; else if(!/^[^@]+@[^@]+\.[^@]+$/.test(s.email))e.email="Geçerli e-posta girin."; setErr(e); return !Object.keys(e).length; }
  function submit(){ setTried(true); if(validate(v)) onSave(v); }
  return (
    <div className="uv-form">
      <div className="uv-grid">
        <div className="uv-field uv-full"><label className="uv-label">Ad Soyad <i>*</i></label><Input placeholder="Örn. Selin Aydın" value={v.name} onChange={e=>set("name",e.target.value)} error={err.name}/></div>
        <div className="uv-field"><label className="uv-label">E-posta <i>*</i></label><Input type="email" placeholder="ad@uyanik.co" value={v.email} onChange={e=>set("email",e.target.value)} error={err.email}/></div>
        <div className="uv-field"><label className="uv-label">Telefon</label><Input placeholder="05XX XXX XX XX" value={v.phone} onChange={e=>set("phone",e.target.value)}/></div>
        <div className="uv-field"><label className="uv-label">Rol <i>*</i></label><Select value={v.role} onChange={e=>set("role",e.target.value)}>{Object.entries(UV_ROLES).map(([k,r])=><option key={k} value={k}>{r.label}</option>)}</Select></div>
        <div className="uv-field"><label className="uv-label">Şube <i>*</i></label><Select value={v.branch} onChange={e=>set("branch",e.target.value)}>{UV_BRANCHES.map(b=><option key={b} value={b}>{b}</option>)}</Select></div>
      </div>
      <div className="uv-switch">
        <div className="uv-switch__tx"><b>Aktif hesap</b><span>Pasif kullanıcılar giriş yapamaz ve POS'ta görünmez.</span></div>
        <Switch checked={v.active} onChange={e=>set("active",e.target.checked)}/>
      </div>
      {!isEdit && <div style={{display:"flex",alignItems:"center",gap:8,font:"var(--fw-medium) 11.5px/1.4 var(--font-sans)",color:"var(--text-muted)",background:"var(--color-primary-soft)",borderRadius:"var(--radius-md)",padding:"11px 13px"}}><UVMDS.Icon name="message-notif" size={14} color="var(--color-primary)"/>Hesap oluşturulunca kullanıcıya e-posta ile parola belirleme bağlantısı gönderilir.</div>}
      <div style={{display:"flex",justifyContent:"flex-end",gap:10,paddingTop:4}}>
        <Button variant="ghost" color="dark" onClick={onCancel}>İptal</Button>
        <Button color="accent" iconStart="check-circle" onClick={submit}>{isEdit?"Değişiklikleri kaydet":"Kullanıcı ekle"}</Button>
      </div>
    </div>
  );
}

function UsersView(){
  React.useEffect(()=>{injectUV();},[]);
  const { DataGrid, StatusBadge, Button, Input, Select, Drawer, Modal } = UVMDS;
  const toast = UVMDS.ToastProvider.useToast();
  const [loading,setLoading]=React.useState(true);
  const [demo,setDemo]=React.useState("full");
  const [q,setQ]=React.useState("");
  const [role,setRole]=React.useState("");
  const [branch,setBranch]=React.useState("");
  const [sort,setSort]=React.useState({key:"name",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [data,setData]=React.useState(UV_DATA);
  const [drawer,setDrawer]=React.useState(null);
  const [del,setDel]=React.useState(null);

  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),550); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,role,branch]);

  const filtered=React.useMemo(()=>{
    let r=data.filter(u=>(!q||u.name.toLowerCase().includes(q.toLowerCase())||u.email.toLowerCase().includes(q.toLowerCase()))&&(!role||u.role===role)&&(!branch||u.branch===branch));
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{let x=a[sort.key],y=b[sort.key];if(typeof x==="string")return x.localeCompare(y,"tr")*dir;return (x-y)*dir;});
    return r;
  },[data,q,role,branch,sort]);
  const total=filtered.length, rows=filtered.slice((page-1)*UV_PAGE,page*UV_PAGE);
  const es=window.effState(demo,{loading,rows,total});

  function onSave(v){
    if(drawer.mode==="add"){ const id=Math.max(...data.map(d=>d.id))+1; setData([{...v,id,last:"—"},...data]); toast({type:"success",title:"Kullanıcı eklendi",description:`${v.name} · ${UV_ROLES[v.role].label}`}); }
    else { setData(data.map(d=>d.id===drawer.user.id?{...d,...v}:d)); toast({type:"success",title:"Kullanıcı güncellendi",description:v.name}); }
    setDrawer(null);
  }
  function confirmDelete(){ setData(data.filter(d=>d.id!==del.id)); toast({type:"error",title:"Kullanıcı silindi",description:del.name}); setDel(null); }

  const columns=[
    { key:"name", header:"Kullanıcı", sortable:true, render:u=><div className="uv-user"><UVMDS.Avatar name={u.name} size={34} status={u.active?"online":undefined}/><div className="uv-user__t"><b>{u.name}</b><span>{u.email}</span></div></div> },
    { key:"role", header:"Rol", render:u=>{ const r=UV_ROLES[u.role]; return <span className="uv-role" style={{background:r.bg,color:r.fg}}><UVMDS.Icon name={r.icon} size={13} color={r.fg}/>{r.label}</span>; } },
    { key:"branch", header:"Şube", render:u=><span style={{fontSize:12.5}}>{u.branch}</span> },
    { key:"phone", header:"Telefon", render:u=><span style={{fontSize:12.5,color:"var(--text-muted)"}}>{u.phone}</span> },
    { key:"last", header:"Son Giriş", align:"right", render:u=><span style={{fontSize:12.5,color:"var(--text-muted)"}}>{u.last}</span> },
    { key:"active", header:"Durum", render:u=><StatusBadge status={u.active?"aktif":"pasif"}/> },
    { key:"_act", header:"", align:"right", width:96, render:u=>(
      <div style={{display:"flex",gap:2,justifyContent:"flex-end"}}>
        <UVMDS.IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={e=>{e.stopPropagation();setDrawer({mode:"edit",user:u});}}/>
        <UVMDS.IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="Sil" onClick={e=>{e.stopPropagation();setDel(u);}}/>
      </div>) },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Yönetim","Kullanıcılar"]} title="Kullanıcılar"
        desc={`${data.length} personel · ${data.filter(u=>u.active).length} aktif`}
        actions={<><window.StatePreviewSeg demo={demo} setDemo={setDemo}/><Button color="accent" iconStart="plus-squared" onClick={()=>setDrawer({mode:"add"})}>Kullanıcı Ekle</Button></>}/>
      <div className="as-filter">
        <div style={{width:260}}><Input iconLead="magnifier" placeholder="Ad soyad veya e-posta…" value={q} onChange={e=>setQ(e.target.value)}/></div>
        <div style={{width:160}}><Select value={role} onChange={e=>setRole(e.target.value)}><option value="">Tüm roller</option>{Object.entries(UV_ROLES).map(([k,r])=><option key={k} value={k}>{r.label}</option>)}</Select></div>
        <div style={{width:170}}><Select value={branch} onChange={e=>setBranch(e.target.value)}><option value="">Tüm şubeler</option>{UV_BRANCHES.map(b=><option key={b} value={b}>{b}</option>)}</Select></div>
        <div className="as-filter__sp"/>
        {(q||role||branch)&&<Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setRole("");setBranch("");}}>Temizle</Button>}
      </div>
      <DataGrid columns={columns} rows={es.rows} loading={es.loading} error={es.error} onRetry={()=>setDemo("full")}
        empty={{icon:"profile-circle",title:(q||role||branch)?"Kullanıcı bulunamadı":"Henüz kullanıcı yok",subtitle:(q||role||branch)?"Filtreleri değiştirin.":"İlk personeli ekleyin.",action:(q||role||branch)?<Button variant="light" size="sm" onClick={()=>{setQ("");setRole("");setBranch("");}}>Filtreleri temizle</Button>:<Button color="accent" size="sm" iconStart="plus-squared" onClick={()=>setDrawer({mode:"add"})}>Kullanıcı Ekle</Button>}}
        sort={sort} onSortChange={setSort} page={page} pageSize={UV_PAGE} total={es.total} onPageChange={setPage} rowKey={u=>u.id} onRowClick={u=>setDrawer({mode:"edit",user:u})}/>

      <Drawer open={!!drawer} onClose={()=>setDrawer(null)} size="md" title={drawer?.mode==="add"?"Yeni Kullanıcı":"Kullanıcıyı Düzenle"} subtitle={drawer?.mode==="add"?"Personel hesabı oluştur":drawer?.user?.email}>
        {drawer && <UserForm initial={drawer.mode==="edit"?drawer.user:null} onCancel={()=>setDrawer(null)} onSave={onSave}/>}
      </Drawer>
      <Modal open={!!del} onClose={()=>setDel(null)} icon="trash" tone="danger" title="Kullanıcıyı sil?" subtitle={del?`“${del.name}” hesabı kalıcı olarak silinecek.`:""}
        footer={<><Button variant="ghost" color="dark" onClick={()=>setDel(null)}>İptal</Button><Button color="danger" iconStart="trash" onClick={confirmDelete}>Evet, sil</Button></>}/>
    </React.Fragment>
  );
}
window.UsersView = UsersView;
