/* Company — Şirket / Şube / POS yönetimi. window.CompanyView */
const COMDS = window.MetronicDesignSystem_a73f8f;

const CO_CSS = `
.co-branches{display:grid;grid-template-columns:repeat(auto-fill,minmax(280px,1fr));gap:16px;}
.co-branch{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.co-branch__hd{display:flex;align-items:center;gap:13px;padding:16px 18px;border-bottom:1px solid var(--border-default);}
.co-branch__ic{width:44px;height:44px;border-radius:12px;display:flex;align-items:center;justify-content:center;flex:none;}
.co-branch__t{flex:1;min-width:0;}
.co-branch__t b{font:var(--fw-bold) 14.5px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);display:block;}
.co-branch__t span{font:var(--fw-regular) 11.5px/1.3 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;}
.co-branch__bd{padding:14px 18px;}
.co-meta{display:flex;align-items:center;gap:8px;font:var(--fw-medium) 12px/1.4 var(--font-sans);color:var(--text-body);padding:5px 0;}
.co-meta svg{flex:none;}
.co-pos-list{margin-top:12px;border-top:1px solid var(--border-default);padding-top:12px;}
.co-pos{display:flex;align-items:center;gap:10px;padding:7px 0;}
.co-pos__d{width:8px;height:8px;border-radius:50%;flex:none;}
.co-pos__n{font:var(--fw-semibold) 12px/1 var(--font-mono);color:var(--text-heading);}
.co-pos__s{font:var(--fw-regular) 11px/1 var(--font-sans);color:var(--text-muted);margin-left:auto;}
`;
function injectCO(){ if(document.getElementById('co-css'))return; const e=document.createElement('style');e.id='co-css';e.textContent=CO_CSS;document.head.appendChild(e); }

const CO_BRANCHES=[
  {id:1,name:"Çayyolu Şubesi",city:"Ankara",addr:"Çayyolu Mah. 2851. Cad. No:12",phone:"0312 555 12 34",depot:false,pos:[{n:"POS-1",on:true},{n:"POS-2",on:true}]},
  {id:2,name:"Bağdat Caddesi",city:"İstanbul",addr:"Bağdat Cad. No:240, Kadıköy",phone:"0216 555 45 67",depot:false,pos:[{n:"POS-1",on:true},{n:"POS-2",on:false}]},
  {id:3,name:"Alsancak Şubesi",city:"İzmir",addr:"Kıbrıs Şehitleri Cad. No:18",phone:"0232 555 78 90",depot:false,pos:[{n:"POS-1",on:true}]},
  {id:4,name:"Merkez Depo",city:"Ankara",addr:"Ostim OSB 100. Yıl Blv. No:55",phone:"0312 555 99 00",depot:true,pos:[]},
];

function CompanyView(){
  React.useEffect(()=>{injectCO();},[]);
  const { Button, StatusBadge } = COMDS;
  const toast = COMDS.ToastProvider.useToast();
  const totalPos=CO_BRANCHES.reduce((s,b)=>s+b.pos.length,0);
  const activePos=CO_BRANCHES.reduce((s,b)=>s+b.pos.filter(p=>p.on).length,0);

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Yönetim","Şirket / Şube / POS"]} title="Şube & POS Yönetimi"
        desc={`${CO_BRANCHES.filter(b=>!b.depot).length} şube · 1 depo · ${activePos}/${totalPos} POS aktif`}
        actions={<Button color="accent" iconStart="plus-squared" onClick={()=>toast({type:"info",title:"Yeni şube",description:"Şube ekleme formu açılır."})}>Şube Ekle</Button>}/>

      <div className="co-branches">
        {CO_BRANCHES.map(b=>(
          <div className="co-branch" key={b.id}>
            <div className="co-branch__hd">
              <div className="co-branch__ic" style={{background:b.depot?"var(--color-grey-100)":"var(--color-primary-soft)"}}><COMDS.Icon name={b.depot?"folder":"home"} size={21} color={b.depot?"var(--text-muted)":"var(--color-primary)"}/></div>
              <div className="co-branch__t"><b>{b.name}</b><span>{b.city}</span></div>
              <COMDS.IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={()=>toast({type:"info",title:b.name,description:"Şube düzenleme formu açılır."})}/>
            </div>
            <div className="co-branch__bd">
              <div className="co-meta"><COMDS.Icon name="home" size={13} color="var(--text-placeholder)"/>{b.addr}</div>
              <div className="co-meta"><COMDS.Icon name="message-notif" size={13} color="var(--text-placeholder)"/>{b.phone}</div>
              {b.depot ? (
                <div className="co-pos-list" style={{font:"var(--fw-medium) 12px/1.4 var(--font-sans)",color:"var(--text-muted)",display:"flex",alignItems:"center",gap:7}}><COMDS.Icon name="folder" size={13} color="var(--text-placeholder)"/>Depo lokasyonu · POS yok</div>
              ) : (
                <div className="co-pos-list">
                  <div style={{font:"var(--fw-semibold) 10px/1 var(--font-sans)",textTransform:"uppercase",letterSpacing:".05em",color:"var(--text-placeholder)",marginBottom:6}}>POS Cihazları</div>
                  {b.pos.map((p,i)=>(
                    <div className="co-pos" key={i}>
                      <span className="co-pos__d" style={{background:p.on?"var(--color-success)":"var(--text-placeholder)"}}/>
                      <span className="co-pos__n">{p.n}</span>
                      <span className="co-pos__s">{p.on?"Çevrimiçi":"Çevrimdışı"}</span>
                    </div>
                  ))}
                </div>
              )}
            </div>
          </div>
        ))}
      </div>
    </React.Fragment>
  );
}
window.CompanyView = CompanyView;
