/* Screen 5 — Ürün Ekle/Düzenle: sekmeli geniş form (Drawer içinde). window.ProductForm */
const PFMDS = window.MetronicDesignSystem_a73f8f;

const PF_CSS = `
.pf2{display:flex;flex-direction:column;min-height:0;}
.pf2__tabs{position:sticky;top:0;background:var(--surface-card);z-index:5;padding-bottom:2px;margin:-2px 0 20px;border-bottom:1px solid var(--border-default);}
.pf2__taberr{display:inline-flex;align-items:center;justify-content:center;width:16px;height:16px;border-radius:50%;background:var(--color-danger);color:#fff;font:var(--fw-bold) 9px/1 var(--font-sans);margin-left:6px;}
.pf2__panel{display:flex;flex-direction:column;gap:20px;}
.pf2__sec{font:var(--fw-semibold) 11px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.06em;color:var(--text-muted);padding-bottom:11px;border-bottom:1px solid var(--border-default);margin-bottom:2px;}
.pf2__grid{display:grid;grid-template-columns:1fr 1fr;gap:16px;}
.pf2__full{grid-column:1 / -1;}
@media(max-width:560px){.pf2__grid{grid-template-columns:1fr;}}

.pf2__field{display:flex;flex-direction:column;gap:7px;}
.pf2__label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);display:flex;align-items:center;gap:4px;}
.pf2__label i{color:var(--color-danger);font-style:normal;}
.pf2__hint{font:var(--fw-regular) 11.5px/1.4 var(--font-sans);color:var(--text-muted);}
.pf2__err{display:flex;align-items:center;gap:5px;font:var(--fw-medium) 11.5px/1.3 var(--font-sans);color:var(--color-danger);}

/* category select with swatch preview */
.pf2__catprev{display:flex;align-items:center;gap:10px;margin-top:9px;padding:9px 12px;border:1px solid var(--border-default);border-radius:var(--radius-md);background:var(--color-grey-50);}
.pf2__catdot{width:26px;height:26px;flex:none;display:flex;align-items:center;justify-content:center;color:#fff;}
.pf2__catprev b{font:var(--fw-semibold) 12.5px/1.2 var(--font-sans);color:var(--text-heading);}
.pf2__catprev span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);display:block;margin-top:2px;}

/* image upload */
.pf2__upload{display:flex;align-items:center;gap:16px;}
.pf2__thumb{width:80px;height:106px;border-radius:var(--radius-md);border:1.5px dashed var(--border-strong);background:var(--color-grey-50);display:flex;flex-direction:column;align-items:center;justify-content:center;gap:6px;color:var(--text-placeholder);flex:none;cursor:pointer;transition:all .12s;overflow:hidden;position:relative;}
.pf2__thumb:hover{border-color:var(--color-primary);color:var(--color-primary);background:var(--color-primary-soft);}
.pf2__thumb img{width:100%;height:100%;object-fit:cover;}
.pf2__thumb-x{position:absolute;top:4px;right:4px;width:22px;height:22px;border-radius:6px;background:rgba(0,0,0,.55);border:0;cursor:pointer;display:flex;align-items:center;justify-content:center;}

/* switch rows */
.pf2__switch{display:flex;align-items:center;justify-content:space-between;gap:12px;padding:13px 15px;border:1px solid var(--border-default);border-radius:var(--radius-md);transition:border-color .12s,background .12s;}
.pf2__switch.on{border-color:var(--color-primary);background:var(--color-primary-soft);}
.pf2__switch-tx b{font:var(--fw-semibold) 13px/1.3 var(--font-sans);color:var(--text-heading);display:flex;align-items:center;gap:8px;}
.pf2__switch-tx span{font:var(--fw-regular) 11.5px/1.4 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;}
.pf2__flaggrid{display:grid;grid-template-columns:1fr 1fr;gap:12px;}
@media(max-width:560px){.pf2__flaggrid{grid-template-columns:1fr;}}

/* POS price table */
.pf2__pos{border:1px solid var(--border-default);border-radius:var(--radius-md);overflow:hidden;}
.pf2__pos table{width:100%;border-collapse:collapse;}
.pf2__pos th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;color:var(--text-muted);padding:11px 12px;background:var(--color-grey-50);border-bottom:1px solid var(--border-default);}
.pf2__pos td{padding:9px 12px;border-bottom:1px solid var(--border-default);vertical-align:middle;}
.pf2__pos tr:last-child td{border-bottom:0;}
.pf2__posempty{display:flex;flex-direction:column;align-items:center;gap:6px;padding:28px 20px;text-align:center;}
.pf2__posempty b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);}
.pf2__posempty span{font:var(--fw-regular) 12px/1.5 var(--font-sans);color:var(--text-muted);max-width:300px;}
.pf2__addrow{appearance:none;border:0;background:none;cursor:pointer;display:flex;align-items:center;gap:6px;padding:11px 12px;width:100%;font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--color-primary);border-top:1px solid var(--border-default);}
.pf2__addrow:hover{background:var(--color-primary-soft);}
.pf2__poshint{display:flex;align-items:center;gap:7px;font:var(--fw-medium) 11.5px/1.4 var(--font-sans);color:var(--text-muted);background:var(--color-grey-50);border:1px solid var(--border-default);border-radius:var(--radius-md);padding:10px 12px;}
.pf2__mini{width:100%;height:36px;border:1px solid var(--border-default);border-radius:var(--radius-sm,6px);padding:0 10px;font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-heading);background:var(--surface-card);outline:none;}
.pf2__mini:focus{border-color:var(--color-primary);}
`;
function injectPF(){ if(document.getElementById('pf2-css'))return; const e=document.createElement('style');e.id='pf2-css';e.textContent=PF_CSS;document.head.appendChild(e); }

/* Category metadata: color + shape (per CLAUDE rules categories have color/shape) */
const PF_CATEGORIES = [
  { name:"Roman", color:"#1f3864", shape:"8px" },
  { name:"Tarih", color:"#7a1f3d", shape:"8px" },
  { name:"Kişisel Gelişim", color:"#0f5c2e", shape:"8px" },
  { name:"Çocuk", color:"#e08a2b", shape:"50%" },
  { name:"Bilim", color:"#3b2f7a", shape:"8px" },
  { name:"Şiir", color:"#1f5e7a", shape:"8px" },
  { name:"Kırtasiye", color:"#5a4a1f", shape:"4px" },
  { name:"Sıcak İçecek", color:"#9a4a1f", shape:"50%" },
  { name:"Soğuk İçecek", color:"#1f6e8a", shape:"50%" },
  { name:"Atıştırmalık", color:"#7a5a1f", shape:"50%" },
];
const PF_KDV = ["%0","%1","%8","%18"];
const PF_UNITS = ["Adet","ml","gram"];
const PF_BRANCHES = ["Çayyolu Şubesi","Bağdat Caddesi","Alsancak Şubesi"];

function ProductForm({ initial, onCancel, onSave }){
  React.useEffect(()=>{injectPF();},[]);
  const { Tabs, Input, Select, Textarea, Switch, Button } = PFMDS;
  const isEdit = !!initial;
  const [tab,setTab]=React.useState("genel");
  const [v,setV]=React.useState(()=>({
    name:initial?.name||"", category:initial?.category||"", desc:initial?.desc||"",
    unit:initial?.unit||"Adet", kdv:initial?.kdv||"%8", image:initial?.image||null,
    buy:initial?.buy!=null?String(initial.buy):"", sell:initial?.sell!=null?String(initial.sell):"",
    barcode:initial?.barcode||"", sku:initial?.sku||"", track:initial?.track!==false,
    fDepot:initial?.fDepot!==false, fPos:initial?.fPos!==false, fFav:!!initial?.fFav, fMain:initial?.fMain!==false,
    posPrices:initial?.posPrices||[],
  }));
  const [err,setErr]=React.useState({});
  const [tried,setTried]=React.useState(false);

  function validate(s){
    const e={};
    if(!s.name.trim()) e.name="Ürün adı zorunludur.";
    if(!s.category) e.category="Kategori seçin.";
    if(!s.unit) e.unit="Birim seçin.";
    if(!s.kdv) e.kdv="KDV oranı seçin.";
    if(s.buy && (isNaN(Number(s.buy))||Number(s.buy)<0)) e.buy="Geçerli bir fiyat girin.";
    if(s.sell && (isNaN(Number(s.sell))||Number(s.sell)<0)) e.sell="Geçerli bir fiyat girin.";
    s.posPrices.forEach((p,i)=>{ if(p.pos && p.sell && (isNaN(Number(p.sell))||Number(p.sell)<0)) e["pos"+i]="Geçersiz fiyat"; });
    return e;
  }
  // which tab does each error belong to
  const TAB_OF = { name:"genel", category:"genel", unit:"genel", kdv:"genel", buy:"fiyat", sell:"fiyat" };
  function tabErrCount(tabId){
    return Object.keys(err).filter(k=>{
      if(k.startsWith("pos")) return tabId==="pos";
      return TAB_OF[k]===tabId;
    }).length;
  }

  function set(k,val){ const ns={...v,[k]:val}; setV(ns); if(tried) setErr(validate(ns)); }
  function setPos(i,k,val){ const arr=v.posPrices.map((p,j)=>j===i?{...p,[k]:val}:p); set("posPrices",arr); }

  function submit(){
    setTried(true);
    const e=validate(v); setErr(e);
    if(Object.keys(e).length>0){
      // jump to first tab containing an error
      const order=["genel","fiyat","pos"];
      const firstBad=order.find(t=>Object.keys(e).some(k=>k.startsWith("pos")?t==="pos":TAB_OF[k]===t));
      if(firstBad) setTab(firstBad);
      return;
    }
    onSave({...v, buy:v.buy?Number(v.buy):0, sell:v.sell?Number(v.sell):0});
  }

  const cat = PF_CATEGORIES.find(c=>c.name===v.category);
  const tabs=[
    { id:"genel", label:<span>Genel{tabErrCount("genel")>0 && tried && <span className="pf2__taberr">{tabErrCount("genel")}</span>}</span> },
    { id:"fiyat", label:<span>Fiyat & Stok{tabErrCount("fiyat")>0 && tried && <span className="pf2__taberr">{tabErrCount("fiyat")}</span>}</span> },
    { id:"pos", label:<span>Şube Özel Fiyatlar</span> },
  ];

  return (
    <div className="pf2">
      <div className="pf2__tabs"><Tabs tabs={tabs} value={tab} onChange={setTab}/></div>

      {/* ---------- TAB 1: Genel ---------- */}
      {tab==="genel" && (
        <div className="pf2__panel">
          <div className="pf2__grid">
            <div className="pf2__full">
              <Input label="Ürün Adı" required error={err.name} placeholder="Örn. Caffè Latte" value={v.name} onChange={e=>set("name",e.target.value)}/>
            </div>
            <div>
              <Select label="Kategori" required error={err.category} value={v.category} onChange={e=>set("category",e.target.value)}>
                <option value="">Kategori seçin…</option>
                {PF_CATEGORIES.map(c=><option key={c.name} value={c.name}>{c.name}</option>)}
              </Select>
              {cat && (
                <div className="pf2__catprev">
                  <span className="pf2__catdot" style={{background:cat.color,borderRadius:cat.shape}}><PFMDS.Icon name="category" size={14} color="#fff"/></span>
                  <div><b>{cat.name}</b><span>Kategori rengi & şekli ürün kartlarında kullanılır</span></div>
                </div>
              )}
            </div>
            <Select label="Birim" required error={err.unit} value={v.unit} onChange={e=>set("unit",e.target.value)}>
              {PF_UNITS.map(u=><option key={u} value={u}>{u}</option>)}
            </Select>
            <div className="pf2__full">
              <Textarea label="Açıklama" hint="Opsiyonel — ürün kartında ve POS'ta görünür" rows={3} placeholder="Ürün açıklaması…" value={v.desc} onChange={e=>set("desc",e.target.value)}/>
            </div>
            <Select label="KDV Oranı" required error={err.kdv} value={v.kdv} onChange={e=>set("kdv",e.target.value)}>
              {PF_KDV.map(k=><option key={k} value={k}>{"KDV "+k}</option>)}
            </Select>
            <div/>
          </div>
          <div>
            <div className="pf2__sec">Ürün Görseli</div>
            <div className="pf2__upload">
              <label className="pf2__thumb">
                {v.image ? <React.Fragment>
                  <img src={v.image} alt=""/>
                  <button type="button" className="pf2__thumb-x" onClick={e=>{e.preventDefault();set("image",null);}}><PFMDS.Icon name="cross-circle" size={14} color="#fff"/></button>
                </React.Fragment> : <React.Fragment>
                  <PFMDS.Icon name="picture" size={22}/>
                  <span style={{font:"var(--fw-semibold) 10px/1 var(--font-sans)"}}>Yükle</span>
                </React.Fragment>}
                <input type="file" accept="image/*" style={{display:"none"}} onChange={e=>{ const f=e.target.files&&e.target.files[0]; if(f){ const r=new FileReader(); r.onload=()=>set("image",r.result); r.readAsDataURL(f);} }}/>
              </label>
              <div style={{font:"var(--fw-regular) 12px/1.6 var(--font-sans)",color:"var(--text-muted)"}}>
                PNG/JPG, en az 400×600px önerilir.<br/>Kapak görseli ürün kartlarında ve POS'ta gösterilir.
              </div>
            </div>
          </div>
        </div>
      )}

      {/* ---------- TAB 2: Fiyat & Stok ---------- */}
      {tab==="fiyat" && (
        <div className="pf2__panel">
          <div>
            <div className="pf2__sec">Fiyatlandırma</div>
            <div className="pf2__grid">
              <Input label="Alış Fiyatı" hint={err.buy?undefined:"₺ — opsiyonel"} error={err.buy} placeholder="0,00" value={v.buy} onChange={e=>set("buy",e.target.value)}/>
              <Input label="Satış Fiyatı" hint={err.sell?undefined:"₺ — KDV dahil"} error={err.sell} placeholder="0,00" value={v.sell} onChange={e=>set("sell",e.target.value)}/>
            </div>
          </div>
          <div>
            <div className="pf2__sec">Kodlama & Stok</div>
            <div className="pf2__grid">
              <Input label="Barkod" hint="Opsiyonel" placeholder="869•••••••••" value={v.barcode} onChange={e=>set("barcode",e.target.value)} iconLead="dots-square"/>
              <Input label="Stok Kodu (SKU)" hint="Opsiyonel" placeholder="UYK-0000" value={v.sku} onChange={e=>set("sku",e.target.value)}/>
            </div>
            <div className={"pf2__switch"+(v.track?" on":"")} style={{marginTop:14}}>
              <div className="pf2__switch-tx">
                <b><PFMDS.Icon name="folder" size={15} color={v.track?"var(--color-primary)":"var(--text-muted)"}/>Stok Takibi</b>
                <span>{v.track?"Stok kontrolü yapılır — eşik altına düşünce uyarı verilir.":"Sınırsız satılır (örn. hizmet, açık ürün). Stok düşülmez."}</span>
              </div>
              <Switch checked={v.track} onChange={e=>set("track",e.target.checked)}/>
            </div>
          </div>
          <div>
            <div className="pf2__sec">Bayraklar</div>
            <div className="pf2__flaggrid">
              {[
                {k:"fDepot",ic:"folder",t:"Depo Ürünü",d:"Depo stoğunda tutulur"},
                {k:"fPos",ic:"handcart",t:"POS'ta Satılır",d:"Kasada listelenir"},
                {k:"fFav",ic:"heart",t:"Favori Ürün",d:"POS'ta hızlı erişim"},
                {k:"fMain",ic:"verify",t:"Ana Ürün",d:"Alt ürün / reçete değil"},
              ].map(f=>(
                <div className={"pf2__switch"+(v[f.k]?" on":"")} key={f.k}>
                  <div className="pf2__switch-tx">
                    <b><PFMDS.Icon name={f.ic} size={15} color={v[f.k]?"var(--color-primary)":"var(--text-muted)"}/>{f.t}</b>
                    <span>{f.d}</span>
                  </div>
                  <Switch checked={v[f.k]} onChange={e=>set(f.k,e.target.checked)}/>
                </div>
              ))}
            </div>
          </div>
        </div>
      )}

      {/* ---------- TAB 3: Şube Özel Fiyatlar ---------- */}
      {tab==="pos" && (
        <div className="pf2__panel">
          <div className="pf2__poshint"><PFMDS.Icon name="information-2" size={14} color="var(--text-muted)"/>Belirli şubelerde farklı fiyat tanımlayın. Boş bırakılırsa <b style={{margin:"0 3px"}}>ana fiyat</b> ({v.sell?v.sell+" ₺":"—"}) tüm şubelerde geçerli olur.</div>
          <div className="pf2__pos">
            {v.posPrices.length===0 ? (
              <div className="pf2__posempty">
                <PFMDS.Icon name="dots-square" size={26} color="var(--border-strong)"/>
                <b>Şubeye özel fiyat yok</b>
                <span>Tüm şubelerde ana satış fiyatı geçerli. Bir şubeye farklı fiyat tanımlamak için aşağıdan ekleyin.</span>
              </div>
            ) : (
              <table>
                <thead><tr><th>Şube</th><th style={{width:120}}>Alış ₺</th><th style={{width:120}}>Satış ₺</th><th style={{width:44}}></th></tr></thead>
                <tbody>
                  {v.posPrices.map((p,i)=>(
                    <tr key={i}>
                      <td>
                        <select className="pf2__mini" value={p.pos} onChange={e=>setPos(i,"pos",e.target.value)}>
                          <option value="">Şube seçin…</option>
                          {PF_BRANCHES.map(x=><option key={x} value={x}>{x}</option>)}
                        </select>
                      </td>
                      <td><input className="pf2__mini" style={{textAlign:"right"}} placeholder={v.buy||"0"} value={p.buy} onChange={e=>setPos(i,"buy",e.target.value)}/></td>
                      <td><input className="pf2__mini" style={{textAlign:"right",borderColor:err["pos"+i]?"var(--color-danger)":undefined}} placeholder={v.sell||"0"} value={p.sell} onChange={e=>setPos(i,"sell",e.target.value)}/></td>
                      <td><PFMDS.IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="Sil" onClick={()=>set("posPrices",v.posPrices.filter((_,j)=>j!==i))}/></td>
                    </tr>
                  ))}
                </tbody>
              </table>
            )}
            <button className="pf2__addrow" onClick={()=>set("posPrices",[...v.posPrices,{pos:"",buy:"",sell:""}])}><PFMDS.Icon name="plus-squared" size={15}/>Şube fiyatı ekle</button>
          </div>
        </div>
      )}

      {/* footer */}
      <div style={{display:"flex",justifyContent:"flex-end",gap:10,paddingTop:22,marginTop:20,borderTop:"1px solid var(--border-default)"}}>
        <Button variant="ghost" color="dark" onClick={onCancel}>İptal</Button>
        <Button color="accent" iconStart="check-circle" onClick={submit}>{isEdit?"Değişiklikleri kaydet":"Ürünü kaydet"}</Button>
      </div>
    </div>
  );
}

window.ProductForm = ProductForm;
window.PF_CATEGORIES = PF_CATEGORIES;
