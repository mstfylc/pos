/* Screen 15 — Sadakat Yönetimi. window.LoyaltyView */
const LYMDS = window.MetronicDesignSystem_a73f8f;

const LY_CSS = `
.ly-tiers{display:grid;grid-template-columns:repeat(3,1fr);gap:16px;}
@media(max-width:900px){.ly-tiers{grid-template-columns:1fr;}}
.ly-tier{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.ly-tier__top{padding:18px 20px;color:#fff;position:relative;}
.ly-tier__top.bronz{background:linear-gradient(135deg,#b07a44,#8a5e30);}
.ly-tier__top.gumus{background:linear-gradient(135deg,#9aa0ad,#6f7686);}
.ly-tier__top.altin{background:linear-gradient(135deg,#e3a23e,#c6751c);}
.ly-tier__name{font:var(--fw-bold) 17px/1 var(--font-sans);display:flex;align-items:center;gap:8px;}
.ly-tier__mult{font:var(--fw-bold) 30px/1 var(--font-sans);margin-top:14px;}
.ly-tier__mult span{font:var(--fw-medium) 13px/1 var(--font-sans);opacity:.85;}
.ly-tier__min{font:var(--fw-medium) 12px/1 var(--font-sans);opacity:.9;margin-top:6px;}
.ly-tier__edit{position:absolute;top:16px;right:16px;}
.ly-tier__body{padding:16px 20px;}
.ly-tier__adv{display:flex;align-items:flex-start;gap:9px;font:var(--fw-medium) 12.5px/1.4 var(--font-sans);color:var(--text-body);padding:7px 0;}
.ly-tier__cnt{display:flex;align-items:center;justify-content:space-between;border-top:1px solid var(--border-default);margin-top:8px;padding-top:13px;font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-muted);}
.ly-tier__cnt b{font:var(--fw-bold) 15px/1 var(--font-sans);color:var(--text-heading);}

.ly-tbl{width:100%;border-collapse:collapse;}
.ly-tbl th{text-align:left;font:var(--fw-semibold) 10px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.04em;color:var(--text-placeholder);padding:0 16px 12px;border-bottom:1px solid var(--border-default);}
.ly-tbl td{padding:13px 16px;border-bottom:1px solid var(--border-default);font:var(--fw-medium) 12.5px/1.3 var(--font-sans);color:var(--text-body);vertical-align:middle;}
.ly-tbl tr:last-child td{border-bottom:0;}
.ly-tbl .num{text-align:right;font-variant-numeric:tabular-nums;}
.ly-panel{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}

.ly-rewards{display:grid;grid-template-columns:repeat(3,1fr);gap:16px;}
@media(max-width:900px){.ly-rewards{grid-template-columns:1fr 1fr;}}
@media(max-width:620px){.ly-rewards{grid-template-columns:1fr;}}
.ly-reward{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;display:flex;flex-direction:column;}
.ly-reward__img{height:96px;display:flex;align-items:center;justify-content:center;}
.ly-reward__b{padding:14px 16px;flex:1;display:flex;flex-direction:column;gap:10px;}
.ly-reward__t b{font:var(--fw-semibold) 13.5px/1.3 var(--font-sans);color:var(--text-heading);display:block;}
.ly-reward__cost{display:inline-flex;align-items:center;gap:6px;font:var(--fw-bold) 15px/1 var(--font-sans);color:var(--color-accent);font-variant-numeric:tabular-nums;}
.ly-reward__foot{display:flex;align-items:center;justify-content:space-between;margin-top:auto;}

.ly-stamps{display:grid;grid-template-columns:1fr 1fr;gap:16px;}
@media(max-width:760px){.ly-stamps{grid-template-columns:1fr;}}
.ly-stamp{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);padding:18px 20px;}
.ly-stamp__hd{display:flex;align-items:center;justify-content:space-between;margin-bottom:14px;}
.ly-stamp__hd b{font:var(--fw-semibold) 14px/1.2 var(--font-sans);color:var(--text-heading);}
.ly-stamp__dots{display:flex;flex-wrap:wrap;gap:8px;margin-bottom:12px;}
.ly-stamp__dot{width:30px;height:30px;border-radius:50%;display:flex;align-items:center;justify-content:center;border:2px dashed var(--border-strong);color:var(--text-placeholder);}
.ly-stamp__dot.on{background:var(--color-primary);border-color:var(--color-primary);color:#fff;}
.ly-stamp__dot.reward{background:var(--color-accent);border-color:var(--color-accent);color:#fff;border-style:solid;}
.ly-stamp__r{font:var(--fw-medium) 12.5px/1.4 var(--font-sans);color:var(--text-muted);}
.ly-stamp__r b{color:var(--text-heading);font-weight:var(--fw-semibold);}
`;
function injectLY(){ if(document.getElementById('ly-css'))return; const e=document.createElement('style');e.id='ly-css';e.textContent=LY_CSS;document.head.appendChild(e); }

const LY_TIERS=[
  {id:"bronz",name:"Bronz",cls:"bronz",min:0,mult:1,members:680,adv:["Her 10 ₺ = 1 puan","Doğum günü sürprizi"]},
  {id:"gumus",name:"Gümüş",cls:"gumus",min:1000,mult:1.25,members:420,adv:["Her 10 ₺ = 1,25 puan","Ücretsiz filtre kahve / ay","Özel kampanyalar"]},
  {id:"altin",name:"Altın",cls:"altin",min:3000,mult:1.5,members:140,adv:["Her 10 ₺ = 1,5 puan","Haftalık ikram","Öncelikli hazırlık","Özel etkinlik davetleri"]},
];
const LY_EARN=[
  {name:"Standart kazanım",rate:"1 puan / 10 ₺",minOrder:"50 ₺",valid:"365 gün",scope:"Tüm şubeler",active:true},
  {name:"Kitap kategorisi bonusu",rate:"2 puan / 10 ₺",minOrder:"100 ₺",valid:"180 gün",scope:"Tüm şubeler",active:true},
  {name:"Hafta içi kahve",rate:"1,5 puan / 10 ₺",minOrder:"—",valid:"90 gün",scope:"Çayyolu, Alsancak",active:false},
];
const LY_REWARDS=[
  {name:"Filtre Kahve",cost:150,type:"urun",color:"#7a5a1f",init:"FK"},
  {name:"50 ₺ İndirim",cost:500,type:"indirim",color:"#1f3864",init:"₺"},
  {name:"Cheesecake Dilim",cost:220,type:"urun",color:"#b5651d",init:"CD"},
  {name:"Seçili Kitap %20",cost:300,type:"indirim",color:"#0f5c2e",init:"%"},
  {name:"İkram Limonata",cost:120,type:"urun",color:"#1f5e7a",init:"L"},
  {name:"100 ₺ İndirim",cost:900,type:"indirim",color:"#7a1f3d",init:"₺"},
];
const LY_STAMPS=[
  {name:"Kahve Kartı",need:8,have:5,reward:"1 Ücretsiz Kahve"},
  {name:"Kitap Kulübü",need:6,have:2,reward:"%25 Kitap İndirimi"},
];

function LoyaltyView(){
  React.useEffect(()=>{injectLY();},[]);
  const { Tabs, Button, Badge, Switch, StatusBadge, Modal, Input } = LYMDS;
  const toast = LYMDS.ToastProvider.useToast();
  const [tab,setTab]=React.useState("tiers");
  const [modal,setModal]=React.useState(null);

  const addLabel={tiers:"Tier Ekle",earn:"Kural Ekle",rewards:"Ödül Ekle",stamps:"Damga Kartı Ekle"}[tab];

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Müşteri & Sadakat","Sadakat"]} title="Sadakat Yönetimi"
        desc="Seviyeler, kazanım kuralları, ödüller ve damga kartları"
        actions={<Button color="accent" iconStart="plus-squared" onClick={()=>setModal(addLabel)}>{addLabel}</Button>}/>

      <div style={{marginBottom:18}}>
        <Tabs tabs={[{id:"tiers",label:"Seviyeler",count:LY_TIERS.length},{id:"earn",label:"Kazanım Kuralları",count:LY_EARN.length},{id:"rewards",label:"Ödüller",count:LY_REWARDS.length},{id:"stamps",label:"Damga Kartları",count:LY_STAMPS.length}]} value={tab} onChange={setTab}/>
      </div>

      {tab==="tiers" && (
        <div className="ly-tiers">
          {LY_TIERS.map(t=>(
            <div className="ly-tier" key={t.id}>
              <div className={"ly-tier__top "+t.cls}>
                <div className="ly-tier__edit"><LYMDS.IconButton size="sm" variant="ghost" icon="notepad-edit" aria-label="Düzenle" style={{color:"#fff"}} onClick={()=>setModal("Seviye: "+t.name)}/></div>
                <div className="ly-tier__name"><LYMDS.Icon name="star" size={17} color="#fff"/>{t.name}</div>
                <div className="ly-tier__mult">{t.mult}× <span>puan çarpanı</span></div>
                <div className="ly-tier__min">Min. {t.min.toLocaleString("tr-TR")} puan</div>
              </div>
              <div className="ly-tier__body">
                {t.adv.map((a,i)=><div className="ly-tier__adv" key={i}><LYMDS.Icon name="check-circle" size={15} color="var(--color-success)" style={{flexShrink:0,marginTop:1}}/>{a}</div>)}
                <div className="ly-tier__cnt"><span>Üye sayısı</span><b>{t.members.toLocaleString("tr-TR")}</b></div>
              </div>
            </div>
          ))}
        </div>
      )}

      {tab==="earn" && (
        <div className="ly-panel">
          <table className="ly-tbl"><thead><tr><th>Kural</th><th>Kazanım</th><th>Min. Sipariş</th><th>Geçerlilik</th><th>Kapsam</th><th>Durum</th><th></th></tr></thead><tbody>
            {LY_EARN.map((r,i)=>(
              <tr key={i}>
                <td style={{fontWeight:"var(--fw-semibold)",color:"var(--text-heading)"}}>{r.name}</td>
                <td><Badge color="accent" variant="light" size="sm">{r.rate}</Badge></td>
                <td>{r.minOrder}</td><td>{r.valid}</td><td style={{color:"var(--text-muted)"}}>{r.scope}</td>
                <td><StatusBadge status={r.active?"aktif":"pasif"}/></td>
                <td style={{textAlign:"right"}}><LYMDS.IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={()=>setModal("Kural: "+r.name)}/></td>
              </tr>
            ))}
          </tbody></table>
        </div>
      )}

      {tab==="rewards" && (
        <div className="ly-rewards">
          {LY_REWARDS.map((r,i)=>(
            <div className="ly-reward" key={i}>
              <div className="ly-reward__img" style={{background:r.color}}><span style={{font:"var(--fw-bold) 26px/1 var(--font-sans)",color:"rgba(255,255,255,.95)"}}>{r.init}</span></div>
              <div className="ly-reward__b">
                <div className="ly-reward__t"><b>{r.name}</b></div>
                <Badge color={r.type==="indirim"?"primary":"secondary"} variant="light" size="sm">{r.type==="indirim"?"İndirim":"Ürün"}</Badge>
                <div className="ly-reward__foot">
                  <span className="ly-reward__cost"><LYMDS.Icon name="star" size={15} color="var(--color-accent)"/>{r.cost}</span>
                  <LYMDS.IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={()=>setModal("Ödül: "+r.name)}/>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      {tab==="stamps" && (
        <div className="ly-stamps">
          {LY_STAMPS.map((s,i)=>(
            <div className="ly-stamp" key={i}>
              <div className="ly-stamp__hd"><b>{s.name}</b><LYMDS.IconButton size="sm" variant="ghost" color="secondary" icon="notepad-edit" aria-label="Düzenle" onClick={()=>setModal("Damga: "+s.name)}/></div>
              <div className="ly-stamp__dots">
                {Array.from({length:s.need}).map((_,j)=>{ const last=j===s.need-1;
                  return <span key={j} className={"ly-stamp__dot"+(last?" reward":(j<s.have?" on":""))}><LYMDS.Icon name={last?"star":"check-circle"} size={14} color={last||j<s.have?"#fff":"var(--text-placeholder)"}/></span>;
                })}
              </div>
              <div className="ly-stamp__r"><b>{s.need} damga</b> topla → <b>{s.reward}</b> kazan · {s.have}/{s.need} dolu</div>
            </div>
          ))}
        </div>
      )}

      <Modal open={!!modal} onClose={()=>setModal(null)} icon="star" tone="accent" title={modal||""}
        subtitle="Bu örnek formda alanlar gösterim amaçlıdır."
        footer={<><Button variant="ghost" color="dark" onClick={()=>setModal(null)}>İptal</Button>
        <Button color="accent" iconStart="check-circle" onClick={()=>{toast({type:"success",title:"Kaydedildi",description:modal});setModal(null);}}>Kaydet</Button></>}>
        <div style={{display:"flex",flexDirection:"column",gap:14}}>
          <Input label="Ad" required defaultValue={modal?modal.split(": ")[1]||"":""} placeholder="Ad girin"/>
          <Input label="Puan / değer" placeholder="0" hint="Seviye min. puanı, ödül maliyeti veya kazanım oranı"/>
        </div>
      </Modal>
    </React.Fragment>
  );
}
window.LoyaltyView = LoyaltyView;
