/* Screen 4 — Ürün Listesi. window.ProductsView */
const PVMDS = window.MetronicDesignSystem_a73f8f;

const PV_CSS = `
.pv-cover{width:36px;height:36px;border-radius:9px;display:flex;align-items:center;justify-content:center;
  box-shadow:0 1px 4px rgba(0,0,0,.16);overflow:hidden;flex:none;}
.pv-cover span{font:var(--fw-bold) 11px/1 var(--font-sans);color:rgba(255,255,255,.95);}
.pv-name{display:flex;align-items:center;gap:11px;}
.pv-name__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.pv-name__t span{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);font-variant-numeric:tabular-nums;}
.pv-price{font:var(--fw-semibold) 13px/1 var(--font-sans);color:var(--text-heading);font-variant-numeric:tabular-nums;}
.pv-buy{font:var(--fw-medium) 12.5px/1 var(--font-sans);color:var(--text-muted);font-variant-numeric:tabular-nums;}
.pv-state-seg{display:inline-flex;background:var(--color-grey-100);border-radius:9px;padding:3px;gap:2px;}
.pv-state-seg button{appearance:none;border:0;cursor:pointer;background:none;font:var(--fw-semibold) 11.5px/1 var(--font-sans);color:var(--text-muted);padding:6px 11px;border-radius:6px;transition:all .12s;}
.pv-state-seg button.on{background:var(--surface-card);color:var(--text-heading);box-shadow:var(--shadow-sm);}
`;
function injectPV(){ if(document.getElementById('pv-css'))return; const e=document.createElement('style');e.id='pv-css';e.textContent=PV_CSS;document.head.appendChild(e);}

const PV_COVERS=["#3a2417","#6f4a2f","#1f5e7a","#9a4a1f","#1f6e8a","#7a1f3d","#5a4a1f","#2f3a1f"];
function coverFor(name,i){ const init=name.split(" ").slice(0,2).map(w=>w[0]).join("").toUpperCase(); return {bg:PV_COVERS[i%PV_COVERS.length],init}; }

const PV_CATS=["Espresso Bazlı","Filtre Kahve","Soğuk Kahve","Sıcak İçecek","Soğuk İçecek","Tatlı","Atıştırmalık","Paket Kahve"];
const PV_DATA=[
  {name:"Espresso",cat:"Espresso Bazlı",sku:"UYK-1001",barcode:"8690001001",buy:8,sell:45,kdv:"%8",track:true,active:true},
  {name:"Double Espresso",cat:"Espresso Bazlı",sku:"UYK-1002",barcode:"8690001002",buy:11,sell:60,kdv:"%8",track:true,active:true},
  {name:"Americano",cat:"Espresso Bazlı",sku:"UYK-1003",barcode:"8690001003",buy:10,sell:60,kdv:"%8",track:true,active:true},
  {name:"Cappuccino",cat:"Espresso Bazlı",sku:"UYK-1004",barcode:"8690001004",buy:14,sell:75,kdv:"%8",track:true,active:true},
  {name:"Caffè Latte",cat:"Espresso Bazlı",sku:"UYK-1005",barcode:"8690001005",buy:15,sell:80,kdv:"%8",track:true,active:true},
  {name:"Flat White",cat:"Espresso Bazlı",sku:"UYK-1006",barcode:"8690001006",buy:15,sell:80,kdv:"%8",track:true,active:true},
  {name:"Caramel Macchiato",cat:"Espresso Bazlı",sku:"UYK-1007",barcode:"8690001007",buy:18,sell:95,kdv:"%8",track:true,active:true},
  {name:"Mocha",cat:"Espresso Bazlı",sku:"UYK-1008",barcode:"8690001008",buy:18,sell:90,kdv:"%8",track:true,active:true},
  {name:"Filtre Kahve",cat:"Filtre Kahve",sku:"UYK-1009",barcode:"8690001009",buy:12,sell:65,kdv:"%8",track:true,active:true},
  {name:"V60 Demleme",cat:"Filtre Kahve",sku:"UYK-1010",barcode:"8690001010",buy:16,sell:85,kdv:"%8",track:true,active:true},
  {name:"Chemex (2 kişilik)",cat:"Filtre Kahve",sku:"UYK-1011",barcode:"8690001011",buy:24,sell:120,kdv:"%8",track:true,active:true},
  {name:"Cold Brew",cat:"Soğuk Kahve",sku:"UYK-1012",barcode:"8690001012",buy:18,sell:90,kdv:"%8",track:true,active:true},
  {name:"Iced Latte",cat:"Soğuk Kahve",sku:"UYK-1013",barcode:"8690001013",buy:16,sell:85,kdv:"%8",track:true,active:true},
  {name:"Frappe",cat:"Soğuk Kahve",sku:"UYK-1014",barcode:"8690001014",buy:18,sell:95,kdv:"%8",track:true,active:true},
  {name:"Iced Americano",cat:"Soğuk Kahve",sku:"UYK-1015",barcode:"8690001015",buy:12,sell:70,kdv:"%8",track:true,active:true},
  {name:"Çay",cat:"Sıcak İçecek",sku:"UYK-2001",barcode:"8690002001",buy:4,sell:20,kdv:"%8",track:false,active:true},
  {name:"Sıcak Çikolata",cat:"Sıcak İçecek",sku:"UYK-2002",barcode:"8690002002",buy:14,sell:70,kdv:"%8",track:true,active:true},
  {name:"Sahlep",cat:"Sıcak İçecek",sku:"UYK-2003",barcode:"8690002003",buy:15,sell:75,kdv:"%8",track:true,active:false},
  {name:"Bitki Çayı",cat:"Sıcak İçecek",sku:"UYK-2004",barcode:"8690002004",buy:8,sell:45,kdv:"%8",track:true,active:true},
  {name:"Limonata",cat:"Soğuk İçecek",sku:"UYK-2005",barcode:"8690002005",buy:12,sell:55,kdv:"%8",track:true,active:true},
  {name:"Taze Portakal Suyu",cat:"Soğuk İçecek",sku:"UYK-2006",barcode:"8690002006",buy:18,sell:70,kdv:"%8",track:true,active:true},
  {name:"Soda",cat:"Soğuk İçecek",sku:"UYK-2007",barcode:"8690002007",buy:8,sell:30,kdv:"%8",track:true,active:true},
  {name:"Cheesecake",cat:"Tatlı",sku:"UYK-3001",barcode:"8690003001",buy:35,sell:110,kdv:"%8",track:true,active:true},
  {name:"Brownie",cat:"Tatlı",sku:"UYK-3002",barcode:"8690003002",buy:28,sell:95,kdv:"%8",track:true,active:true},
  {name:"San Sebastian",cat:"Tatlı",sku:"UYK-3003",barcode:"8690003003",buy:40,sell:120,kdv:"%8",track:true,active:true},
  {name:"Cookie",cat:"Tatlı",sku:"UYK-3004",barcode:"8690003004",buy:14,sell:55,kdv:"%8",track:true,active:true},
  {name:"Kruvasan",cat:"Atıştırmalık",sku:"UYK-3005",barcode:"8690003005",buy:20,sell:70,kdv:"%8",track:true,active:true},
  {name:"Avokado Tost",cat:"Atıştırmalık",sku:"UYK-3006",barcode:"8690003006",buy:45,sell:145,kdv:"%8",track:true,active:true},
  {name:"Çekirdek Kahve 250g",cat:"Paket Kahve",sku:"UYK-4001",barcode:"8690004001",buy:110,sell:220,kdv:"%18",track:true,active:true},
  {name:"Filtre Kahve 250g (paket)",cat:"Paket Kahve",sku:"UYK-4002",barcode:"8690004002",buy:90,sell:180,kdv:"%18",track:true,active:true},
].map((p,i)=>({...p,id:i+1,_cover:coverFor(p.name,i)}));

const PAGE_SIZE=8;

function ProductsView(){
  React.useEffect(()=>{injectPV();},[]);
  const { DataGrid, StatusBadge, Button, IconButton, Input, Select, Modal, Drawer } = PVMDS;
  const toast = PVMDS.ToastProvider.useToast();

  const [demo,setDemo]=React.useState("full"); // full | loading | empty | error
  const [loading,setLoading]=React.useState(true);
  const [q,setQ]=React.useState("");
  const [cat,setCat]=React.useState("");
  const [status,setStatus]=React.useState("");
  const [sort,setSort]=React.useState({key:"name",dir:"asc"});
  const [page,setPage]=React.useState(1);
  const [data,setData]=React.useState(PV_DATA);
  const [drawer,setDrawer]=React.useState(null); // {mode:'add'|'edit', row}
  const [del,setDel]=React.useState(null);

  // simulate initial load
  React.useEffect(()=>{ setLoading(true); const t=setTimeout(()=>setLoading(false),650); return ()=>clearTimeout(t); },[]);
  React.useEffect(()=>{ setPage(1); },[q,cat,status]);

  const filtered=React.useMemo(()=>{
    let r=data.filter(p=>
      (!q || p.name.toLowerCase().includes(q.toLowerCase()) || p.sku.toLowerCase().includes(q.toLowerCase()) || p.barcode.includes(q)) &&
      (!cat || p.cat===cat) &&
      (!status || (status==="active"?p.active:!p.active))
    );
    const dir=sort.dir==="asc"?1:-1;
    r=[...r].sort((a,b)=>{ let x=a[sort.key],y=b[sort.key]; if(typeof x==="string"){return x.localeCompare(y,"tr")*dir;} return (x-y)*dir; });
    return r;
  },[data,q,cat,status,sort]);

  const total=filtered.length;
  const rows=filtered.slice((page-1)*PAGE_SIZE,page*PAGE_SIZE);

  const effLoading = demo==="loading" || loading;
  const effError = demo==="error" ? "Sunucuya bağlanılamadı (503). Lütfen tekrar deneyin." : null;
  const effRows = demo==="empty" ? [] : rows;
  const effTotal = demo==="empty" ? 0 : total;

  function onSave(v){
    const mapped={...v, cat:v.category||v.cat};
    if(drawer.mode==="add"){
      const id=Math.max(...data.map(d=>d.id))+1;
      setData([{...mapped,id,active:true,_cover:coverFor(mapped.name,id),buy:Number(mapped.buy)||0,sell:Number(mapped.sell)||0},...data]);
      toast({type:"success",title:"Ürün eklendi",description:`“${mapped.name}” kataloğa eklendi.`});
    } else {
      setData(data.map(d=>d.id===drawer.row.id?{...d,...mapped,buy:Number(mapped.buy)||0,sell:Number(mapped.sell)||0,_cover:coverFor(mapped.name,d.id)}:d));
      toast({type:"success",title:"Ürün güncellendi",description:`“${mapped.name}” kaydedildi.`});
    }
    setDrawer(null);
  }
  function confirmDelete(){ setData(data.filter(d=>d.id!==del.id)); toast({type:"error",title:"Ürün silindi",description:`“${del.name}” kaldırıldı.`}); setDel(null); }

  const columns=[
    { key:"name", header:"Ürün", sortable:true, render:r=>(
      <div className="pv-name">
        <div className="pv-cover" style={{background:r._cover.bg}}><span>{r._cover.init}</span></div>
        <div className="pv-name__t"><b>{r.name}</b><span>{r.barcode}</span></div>
      </div>) },
    { key:"cat", header:"Kategori", sortable:true, render:r=><PVMDS.Badge color="secondary" variant="light" size="sm">{r.cat}</PVMDS.Badge> },
    { key:"sku", header:"Stok Kodu", render:r=><span style={{font:"var(--fw-medium) 12px/1 var(--font-mono)",color:"var(--text-muted)"}}>{r.sku}</span> },
    { key:"buy", header:"Alış", align:"right", sortable:true, render:r=><span className="pv-buy">{r.buy.toLocaleString("tr-TR")} ₺</span> },
    { key:"sell", header:"Satış", align:"right", sortable:true, render:r=>(
      <div style={{display:"flex",flexDirection:"column",alignItems:"flex-end",gap:2}}>
        <span className="pv-price">{r.sell.toLocaleString("tr-TR")} ₺</span>
        <span style={{font:"var(--fw-medium) 10px/1 var(--font-sans)",color:"var(--text-placeholder)"}}>KDV {r.kdv}</span>
      </div>) },
    { key:"active", header:"Durum", render:r=>(
      <div style={{display:"flex",alignItems:"center",gap:6}}>
        <StatusBadge status={r.active?"aktif":"pasif"}/>
        {!r.track && <span style={{font:"var(--fw-medium) 10px/1 var(--font-sans)",color:"var(--text-placeholder)",border:"1px solid var(--border-default)",borderRadius:"5px",padding:"3px 6px"}}>Takipsiz</span>}
      </div>) },
    { key:"_act", header:"", align:"right", width:96, render:r=>(
      <div style={{display:"flex",gap:2,justifyContent:"flex-end"}}>
        <IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={e=>{e.stopPropagation();setDrawer({mode:"edit",row:r});}}/>
        <IconButton size="sm" variant="ghost" color="danger" icon="trash" aria-label="Sil" onClick={e=>{e.stopPropagation();setDel(r);}}/>
      </div>) },
  ];

  return (
    <React.Fragment>
      <window.AdminShellHeader
        crumb={["Genel","Ürünler"]} title="Ürünler"
        desc={`Katalogda ${data.length} ürün · ${data.filter(d=>d.active).length} aktif`}
        actions={<Button color="accent" iconStart="plus-squared" onClick={()=>setDrawer({mode:"add"})}>Ürün Ekle</Button>}
      />

      <div className="as-filter">
        <div style={{width:280}}>
          <Input size="md" iconLead="magnifier" placeholder="Ürün adı, stok kodu veya barkod…" value={q} onChange={e=>setQ(e.target.value)}/>
        </div>
        <div style={{width:180}}>
          <Select size="md" value={cat} onChange={e=>setCat(e.target.value)}>
            <option value="">Tüm kategoriler</option>
            {PV_CATS.map(c=><option key={c} value={c}>{c}</option>)}
          </Select>
        </div>
        <div style={{width:150}}>
          <Select size="md" value={status} onChange={e=>setStatus(e.target.value)}>
            <option value="">Tüm durumlar</option>
            <option value="active">Aktif</option>
            <option value="passive">Pasif</option>
          </Select>
        </div>
        <div className="as-filter__sp"/>
        {(q||cat||status) && <Button variant="ghost" color="dark" size="sm" iconStart="cross-circle" onClick={()=>{setQ("");setCat("");setStatus("");}}>Temizle</Button>}
        <span style={{display:"flex",alignItems:"center",gap:8,paddingLeft:10,marginLeft:2,borderLeft:"1px solid var(--border-default)"}}>
          <span style={{font:"var(--fw-medium) 10.5px/1 var(--font-sans)",textTransform:"uppercase",letterSpacing:".04em",color:"var(--text-placeholder)"}}>Önizleme</span>
          <div className="pv-state-seg" title="DataGrid durum önizlemesi">
            {[["full","Dolu"],["loading","Yükleniyor"],["empty","Boş"],["error","Hata"]].map(([k,l])=>(
              <button key={k} className={demo===k?"on":""} onClick={()=>setDemo(k)}>{l}</button>
            ))}
          </div>
        </span>
      </div>

      <DataGrid
        columns={columns} rows={effRows} loading={effLoading} error={effError}
        onRetry={()=>setDemo("full")}
        empty={{ icon:"files", title:(q||cat||status)?"Sonuç bulunamadı":"Henüz ürün yok",
          subtitle:(q||cat||status)?"Filtreleri değiştirip tekrar deneyin.":"İlk ürününüzü ekleyerek kataloğu oluşturun.",
          action:(q||cat||status)
            ? <Button variant="light" size="sm" onClick={()=>{setQ("");setCat("");setStatus("");}}>Filtreleri temizle</Button>
            : <Button color="accent" size="sm" iconStart="plus-squared" onClick={()=>setDrawer({mode:"add"})}>Ürün Ekle</Button> }}
        sort={sort} onSortChange={setSort}
        page={page} pageSize={PAGE_SIZE} total={effTotal} onPageChange={setPage}
        rowKey={r=>r.id} onRowClick={r=>setDrawer({mode:"edit",row:r})}
      />

      <Drawer open={!!drawer} onClose={()=>setDrawer(null)} size="lg"
        title={drawer?.mode==="add"?"Yeni Ürün":"Ürünü Düzenle"}
        subtitle={drawer?.mode==="add"?"Kataloğa yeni bir ürün ekleyin":drawer?.row?.sku}>
        {drawer && <window.ProductForm initial={drawer.mode==="edit"?{
          ...drawer.row, category:drawer.row.category||drawer.row.cat, desc:drawer.row.desc||""
        }:null} onCancel={()=>setDrawer(null)} onSave={onSave}/>}
      </Drawer>

      <Modal open={!!del} onClose={()=>setDel(null)} icon="trash" tone="danger"
        title="Ürünü sil?" subtitle={del?`“${del.name}” kalıcı olarak silinecek. Bu işlem geri alınamaz.`:""}
        footer={<>
          <Button variant="ghost" color="dark" onClick={()=>setDel(null)}>İptal</Button>
          <Button color="danger" iconStart="trash" onClick={confirmDelete}>Evet, sil</Button>
        </>}/>
    </React.Fragment>
  );
}

window.ProductsView = ProductsView;
