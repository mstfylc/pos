/* Screen 6 — Kategoriler. window.CategoriesView */
const KVMDS = window.MetronicDesignSystem_a73f8f;

const KV_CSS = `
.kv-grid{display:grid;grid-template-columns:repeat(auto-fill,minmax(248px,1fr));gap:16px;}
.kv-card{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);padding:16px 17px;display:flex;flex-direction:column;gap:14px;position:relative;transition:all .14s;}
.kv-card:hover{box-shadow:var(--shadow-md);border-color:var(--border-strong);}
.kv-card.off{opacity:.62;}
.kv-card__top{display:flex;align-items:flex-start;gap:13px;}
.kv-card__ic{width:48px;height:48px;border-radius:13px;display:flex;align-items:center;justify-content:center;flex:none;}
.kv-card__t{flex:1;min-width:0;}
.kv-card__t b{font:var(--fw-bold) 15px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);display:block;}
.kv-card__t span{font:var(--fw-regular) 12px/1.3 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;}
.kv-card__drag{position:absolute;top:14px;right:13px;color:var(--border-strong);cursor:grab;display:flex;}
.kv-card__foot{display:flex;align-items:center;justify-content:space-between;border-top:1px solid var(--border-default);padding-top:13px;}
.kv-card__count{display:flex;align-items:center;gap:7px;font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-body);}
.kv-card__acts{display:flex;gap:2px;}
.kv-pill{display:inline-flex;align-items:center;gap:5px;font:var(--fw-semibold) 11px/1 var(--font-sans);padding:4px 9px;border-radius:999px;}
.kv-form{display:flex;flex-direction:column;gap:18px;}
.kv-field{display:flex;flex-direction:column;gap:8px;}
.kv-label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);}
.kv-label i{color:var(--color-danger);font-style:normal;}
.kv-swatch{display:flex;flex-wrap:wrap;gap:9px;}
.kv-sw{width:34px;height:34px;border-radius:9px;cursor:pointer;border:2px solid transparent;display:flex;align-items:center;justify-content:center;transition:transform .1s;}
.kv-sw:hover{transform:scale(1.08);}
.kv-sw.on{border-color:var(--text-heading);}
.kv-icons{display:flex;flex-wrap:wrap;gap:8px;}
.kv-ic{width:42px;height:42px;border-radius:10px;cursor:pointer;border:1.5px solid var(--border-default);background:var(--surface-card);display:flex;align-items:center;justify-content:center;transition:all .12s;}
.kv-ic:hover{border-color:var(--color-primary);}
.kv-ic.on{border-color:var(--color-primary);background:var(--color-primary-soft);}
.kv-preview{display:flex;align-items:center;gap:13px;background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:14px 16px;}
.kv-preview__ic{width:46px;height:46px;border-radius:12px;display:flex;align-items:center;justify-content:center;flex:none;}
.kv-preview__t b{font:var(--fw-semibold) 14px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.kv-preview__t span{font:var(--fw-regular) 11.5px/1 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;}
.kv-switch{display:flex;align-items:center;justify-content:space-between;gap:12px;padding:13px 15px;border:1px solid var(--border-default);border-radius:var(--radius-md);background:var(--color-grey-50);}
.kv-switch__tx b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.kv-switch__tx span{font:var(--fw-regular) 11.5px/1.4 var(--font-sans);color:var(--text-muted);display:block;margin-top:2px;}
`;
function injectKV(){ if(document.getElementById('kv-css'))return; const e=document.createElement('style');e.id='kv-css';e.textContent=KV_CSS;document.head.appendChild(e); }

const KV_COLORS=["#3a2417","#6f4a2f","#9a4a1f","#1f5e7a","#1f6e8a","#7a1f3d","#2f6e3a","#5a4a1f","#4921ea","#1f3864"];
const KV_ICONS=["element-11","category","abstract","dots-square","heart","star","price-tag","handcart","folder","home","chart-pie-simple","verify"];

const KV_DATA=[
  {id:1,name:"Espresso Bazlı",desc:"Espresso, latte, cappuccino",color:"#3a2417",icon:"element-11",count:8,active:true},
  {id:2,name:"Filtre Kahve",desc:"V60, Chemex, batch brew",color:"#6f4a2f",icon:"abstract",count:3,active:true},
  {id:3,name:"Soğuk Kahve",desc:"Cold brew, iced latte, frappe",color:"#1f6e8a",icon:"category",count:4,active:true},
  {id:4,name:"Sıcak İçecek",desc:"Çay, sıcak çikolata, sahlep",color:"#9a4a1f",icon:"heart",count:4,active:true},
  {id:5,name:"Soğuk İçecek",desc:"Limonata, soda, meyve suyu",color:"#1f5e7a",icon:"dots-square",count:3,active:true},
  {id:6,name:"Tatlı",desc:"Cheesecake, brownie, cookie",color:"#7a1f3d",icon:"star",count:4,active:true},
  {id:7,name:"Atıştırmalık",desc:"Kruvasan, tost, sandviç",color:"#2f6e3a",icon:"price-tag",count:2,active:true},
  {id:8,name:"Paket Kahve",desc:"Çekirdek & öğütülmüş kahve",color:"#5a4a1f",icon:"folder",count:2,active:true},
  {id:9,name:"Mevsimsel",desc:"Sınırlı süreli özel menü",color:"#4921ea",icon:"verify",count:0,active:false},
];

function CategoryForm({ initial, onCancel, onSave }){
  const { Input, Textarea, Switch, Button } = KVMDS;
  const isEdit=!!initial;
  const [v,setV]=React.useState(()=>({name:initial?.name||"",desc:initial?.desc||"",color:initial?.color||KV_COLORS[0],icon:initial?.icon||KV_ICONS[0],active:initial?.active!==false}));
  const [err,setErr]=React.useState({});
  const [tried,setTried]=React.useState(false);
  function set(k,val){ setV(s=>({...s,[k]:val})); if(tried) validate({...v,[k]:val}); }
  function validate(s){ const e={}; if(!s.name.trim())e.name="Kategori adı zorunludur."; setErr(e); return !Object.keys(e).length; }
  function submit(){ setTried(true); if(validate(v)) onSave(v); }
  return (
    <div className="kv-form">
      <div className="kv-preview">
        <div className="kv-preview__ic" style={{background:v.color}}><KVMDS.Icon name={v.icon} size={24} color="#fff"/></div>
        <div className="kv-preview__t"><b>{v.name||"Kategori adı"}</b><span>{v.desc||"Açıklama (opsiyonel)"}</span></div>
      </div>
      <div className="kv-field">
        <label className="kv-label">Kategori Adı <i>*</i></label>
        <Input placeholder="Örn. Espresso Bazlı" value={v.name} onChange={e=>set("name",e.target.value)} error={err.name}/>
      </div>
      <div className="kv-field">
        <label className="kv-label">Açıklama</label>
        <Textarea rows={2} placeholder="Kısa açıklama (opsiyonel)" value={v.desc} onChange={e=>set("desc",e.target.value)}/>
      </div>
      <div className="kv-field">
        <label className="kv-label">Renk</label>
        <div className="kv-swatch">
          {KV_COLORS.map(c=>(
            <div key={c} className={"kv-sw"+(v.color===c?" on":"")} style={{background:c}} onClick={()=>set("color",c)}>
              {v.color===c && <KVMDS.Icon name="verify" size={15} color="#fff"/>}
            </div>
          ))}
        </div>
      </div>
      <div className="kv-field">
        <label className="kv-label">İkon</label>
        <div className="kv-icons">
          {KV_ICONS.map(ic=>(
            <div key={ic} className={"kv-ic"+(v.icon===ic?" on":"")} onClick={()=>set("icon",ic)}>
              <KVMDS.Icon name={ic} size={19} color={v.icon===ic?"var(--color-primary)":"var(--text-muted)"}/>
            </div>
          ))}
        </div>
      </div>
      <div className="kv-switch">
        <div className="kv-switch__tx"><b>Aktif</b><span>Pasif kategoriler menüde ve POS'ta görünmez.</span></div>
        <Switch checked={v.active} onChange={e=>set("active",e.target.checked)}/>
      </div>
      <div style={{display:"flex",justifyContent:"flex-end",gap:10,paddingTop:4}}>
        <Button variant="ghost" color="dark" onClick={onCancel}>İptal</Button>
        <Button color="accent" iconStart="verify" onClick={submit}>{isEdit?"Değişiklikleri kaydet":"Kategori ekle"}</Button>
      </div>
    </div>
  );
}

function CategoriesView(){
  React.useEffect(()=>{injectKV();},[]);
  const { Button, Drawer, Modal, Input } = KVMDS;
  const toast = KVMDS.ToastProvider.useToast();
  const [data,setData]=React.useState(KV_DATA);
  const [q,setQ]=React.useState("");
  const [drawer,setDrawer]=React.useState(null);
  const [del,setDel]=React.useState(null);

  const filtered=data.filter(c=>!q||c.name.toLowerCase().includes(q.toLowerCase()));
  const totalProducts=data.reduce((s,c)=>s+c.count,0);

  function onSave(v){
    if(drawer.mode==="add"){
      const id=Math.max(...data.map(d=>d.id))+1;
      setData([...data,{...v,id,count:0}]);
      toast({type:"success",title:"Kategori eklendi",description:`“${v.name}” oluşturuldu.`});
    } else {
      setData(data.map(d=>d.id===drawer.cat.id?{...d,...v}:d));
      toast({type:"success",title:"Kategori güncellendi",description:`“${v.name}” kaydedildi.`});
    }
    setDrawer(null);
  }
  function confirmDelete(){
    setData(data.filter(d=>d.id!==del.id));
    toast({type:"error",title:"Kategori silindi",description:`“${del.name}” kaldırıldı.`});
    setDel(null);
  }

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Genel","Kategoriler"]} title="Kategoriler"
        desc={`${data.length} kategori · ${totalProducts} ürün`}
        actions={<Button color="accent" iconStart="plus-squared" onClick={()=>setDrawer({mode:"add"})}>Kategori Ekle</Button>}/>

      <div className="as-filter">
        <div style={{width:280}}><Input iconLead="magnifier" placeholder="Kategori ara…" value={q} onChange={e=>setQ(e.target.value)}/></div>
        <div className="as-filter__sp"/>
        <span style={{font:"var(--fw-medium) 12px/1.4 var(--font-sans)",color:"var(--text-muted)",display:"flex",alignItems:"center",gap:6}}>
          <KVMDS.Icon name="abstract" size={14} color="var(--text-placeholder)"/>Kartları sürükleyerek menü sırasını değiştirin
        </span>
      </div>

      {filtered.length===0 ? (
        <div style={{background:"var(--surface-card)",border:"1px solid var(--border-default)",borderRadius:"var(--radius-lg)",padding:"60px 20px",textAlign:"center"}}>
          <KVMDS.Icon name="category" size={30} color="var(--text-placeholder)"/>
          <div style={{font:"var(--fw-semibold) 15px/1.3 var(--font-sans)",color:"var(--text-heading)",marginTop:12}}>Kategori bulunamadı</div>
          <div style={{font:"var(--fw-regular) 13px/1.5 var(--font-sans)",color:"var(--text-muted)",marginTop:4}}>“{q}” için sonuç yok.</div>
        </div>
      ) : (
        <div className="kv-grid">
          {filtered.map(c=>(
            <div className={"kv-card"+(c.active?"":" off")} key={c.id}>
              <span className="kv-card__drag"><KVMDS.Icon name="dots-square" size={15}/></span>
              <div className="kv-card__top">
                <div className="kv-card__ic" style={{background:c.color}}><KVMDS.Icon name={c.icon} size={23} color="#fff"/></div>
                <div className="kv-card__t"><b>{c.name}</b><span>{c.desc||"—"}</span></div>
              </div>
              <div className="kv-card__foot">
                <span className="kv-card__count">
                  <span className="kv-pill" style={{background:c.active?"var(--color-primary-soft)":"var(--color-grey-100)",color:c.active?"var(--color-primary)":"var(--text-muted)"}}>{c.count} ürün</span>
                  {!c.active && <span style={{font:"var(--fw-medium) 11px/1 var(--font-sans)",color:"var(--text-placeholder)"}}>Pasif</span>}
                </span>
                <div className="kv-card__acts">
                  <KVMDS.IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={()=>setDrawer({mode:"edit",cat:c})}/>
                  <KVMDS.IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="Sil" onClick={()=>setDel(c)}/>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      <Drawer open={!!drawer} onClose={()=>setDrawer(null)} size="md"
        title={drawer?.mode==="add"?"Yeni Kategori":"Kategoriyi Düzenle"}
        subtitle={drawer?.mode==="add"?"Menü için yeni kategori oluşturun":drawer?.cat?.name}>
        {drawer && <CategoryForm initial={drawer.mode==="edit"?drawer.cat:null} onCancel={()=>setDrawer(null)} onSave={onSave}/>}
      </Drawer>

      <Modal open={!!del} onClose={()=>setDel(null)} icon="trash" tone="danger"
        title="Kategoriyi sil?"
        subtitle={del?(del.count>0?`“${del.name}” içinde ${del.count} ürün var. Silmeden önce ürünleri başka kategoriye taşıyın.`:`“${del.name}” kalıcı olarak silinecek.`):""}
        footer={<>
          <Button variant="ghost" color="dark" onClick={()=>setDel(null)}>İptal</Button>
          <Button color="danger" iconStart="trash" disabled={del&&del.count>0} onClick={confirmDelete}>Evet, sil</Button>
        </>}/>
    </React.Fragment>
  );
}
window.CategoriesView = CategoriesView;
