/* Screen 17 — Ayarlar (sekmeli). window.SettingsView */
const STMDS = window.MetronicDesignSystem_a73f8f;

const ST_CSS = `
.st-wrap{max-width:760px;}
.st-card{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.st-card__hd{padding:16px 20px;border-bottom:1px solid var(--border-default);}
.st-card__hd b{font:var(--fw-semibold) 14px/1.2 var(--font-sans);color:var(--text-heading);}
.st-card__hd span{font:var(--fw-regular) 12px/1.4 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;}
.st-card__bd{padding:20px;}
.st-grid{display:grid;grid-template-columns:1fr 1fr;gap:16px;}
.st-full{grid-column:1/-1;}
.st-field{display:flex;flex-direction:column;gap:7px;}
.st-label{font:var(--fw-semibold) 12.5px/1 var(--font-sans);color:var(--text-heading);}
.st-row{display:flex;align-items:center;justify-content:space-between;gap:14px;padding:15px 0;border-bottom:1px solid var(--border-default);}
.st-row:last-child{border-bottom:0;}
.st-row__t b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);display:block;}
.st-row__t span{font:var(--fw-regular) 11.5px/1.4 var(--font-sans);color:var(--text-muted);display:block;margin-top:3px;max-width:420px;}
.st-logo{display:flex;align-items:center;gap:16px;}
.st-logo__box{width:72px;height:72px;border-radius:16px;background:#14233f;display:flex;align-items:center;justify-content:center;flex:none;}
.st-logo__box img{width:42px;}
.st-receipt{background:#fff;border:1px solid var(--border-default);border-radius:var(--radius-md);padding:18px;max-width:280px;margin:0 auto;font-family:var(--font-mono);}
.st-receipt__c{text-align:center;}
.st-receipt__logo{font-family:var(--font-wordmark);font-weight:800;font-size:18px;color:#14233f;}
.st-receipt__line{border-top:1px dashed #cbd2dd;margin:11px 0;}
.st-receipt__r{display:flex;justify-content:space-between;font-size:11px;color:#3f4a5c;padding:2px 0;}
.st-receipt__tot{display:flex;justify-content:space-between;font-size:13px;font-weight:700;color:#14233f;padding:3px 0;}
.st-receipt__ft{text-align:center;font-size:10px;color:#78829d;margin-top:8px;}
`;
function injectST(){ if(document.getElementById('st-css'))return; const e=document.createElement('style');e.id='st-css';e.textContent=ST_CSS;document.head.appendChild(e); }

function SettingsView(){
  React.useEffect(()=>{injectST();},[]);
  const { Tabs, Input, Select, Switch, Button, Textarea } = STMDS;
  const toast = STMDS.ToastProvider.useToast();
  const [tab,setTab]=React.useState("company");
  const [dirty,setDirty]=React.useState(false);
  const [s,setS]=React.useState({
    company:"Uyanık Kahve A.Ş.", taxNo:"1234567890", taxOffice:"Çankaya VD", email:"info@uyanik.co", phone:"0312 555 12 34",
    currency:"₺ (TRY)", kdv:"%8", priceIncl:true, roundCents:true,
    receiptHeader:"Uyanık Kahve · Çayyolu", receiptFooter:"Bizi tercih ettiğiniz için teşekkürler ☕", showLogo:true, showPoints:true,
    lang:"Türkçe", dateFmt:"GG.AA.YYYY", lowStockAlert:true, autoPrint:true,
  });
  function set(k,v){ setS(p=>({...p,[k]:v})); setDirty(true); }
  function save(){ setDirty(false); toast({type:"success",title:"Ayarlar kaydedildi",description:"Değişiklikler tüm şubelere uygulandı."}); }

  return (
    <React.Fragment>
      <window.AdminShellHeader crumb={["Yönetim","Ayarlar"]} title="Ayarlar"
        desc="Şirket, vergi, fiş ve genel sistem ayarları"
        actions={<>
          {dirty && <Button variant="ghost" color="dark" onClick={()=>setDirty(false)}>Geri al</Button>}
          <Button color="accent" iconStart="check-circle" disabled={!dirty} onClick={save}>Değişiklikleri kaydet</Button>
        </>}/>

      <div style={{marginBottom:18}}>
        <Tabs tabs={[{id:"company",label:"Şirket"},{id:"tax",label:"Vergi & Para"},{id:"receipt",label:"Fiş Şablonu"},{id:"general",label:"Genel"}]} value={tab} onChange={setTab}/>
      </div>

      <div className="st-wrap">
        {tab==="company" && (
          <div className="st-card">
            <div className="st-card__hd"><b>Şirket Bilgileri</b><span>Faturalarda ve resmi belgelerde görünür.</span></div>
            <div className="st-card__bd">
              <div className="st-logo" style={{marginBottom:20}}>
                <div className="st-logo__box"><img src={window.UYANIK_LOGO} alt="logo"/></div>
                <div><Button variant="outline" color="dark" iconStart="files">Logo değiştir</Button><div style={{font:"var(--fw-regular) 11px/1.4 var(--font-sans)",color:"var(--text-muted)",marginTop:7}}>PNG/SVG · en az 200×200px</div></div>
              </div>
              <div className="st-grid">
                <div className="st-field st-full"><label className="st-label">Şirket Ünvanı</label><Input value={s.company} onChange={e=>set("company",e.target.value)}/></div>
                <div className="st-field"><label className="st-label">Vergi No</label><Input value={s.taxNo} onChange={e=>set("taxNo",e.target.value)}/></div>
                <div className="st-field"><label className="st-label">Vergi Dairesi</label><Input value={s.taxOffice} onChange={e=>set("taxOffice",e.target.value)}/></div>
                <div className="st-field"><label className="st-label">E-posta</label><Input value={s.email} onChange={e=>set("email",e.target.value)}/></div>
                <div className="st-field"><label className="st-label">Telefon</label><Input value={s.phone} onChange={e=>set("phone",e.target.value)}/></div>
              </div>
            </div>
          </div>
        )}

        {tab==="tax" && (
          <div className="st-card">
            <div className="st-card__hd"><b>Vergi & Para Birimi</b><span>Fiyatlandırma ve fiş hesaplamalarını etkiler.</span></div>
            <div className="st-card__bd">
              <div className="st-grid" style={{marginBottom:8}}>
                <div className="st-field"><label className="st-label">Para Birimi</label><Select value={s.currency} onChange={e=>set("currency",e.target.value)}><option>₺ (TRY)</option><option>$ (USD)</option><option>€ (EUR)</option></Select></div>
                <div className="st-field"><label className="st-label">Varsayılan KDV</label><Select value={s.kdv} onChange={e=>set("kdv",e.target.value)}><option>%0</option><option>%1</option><option>%8</option><option>%18</option></Select></div>
              </div>
              <div className="st-row"><div className="st-row__t"><b>Fiyatlara KDV dahil</b><span>Menü fiyatları KDV dahil gösterilir ve hesaplanır.</span></div><Switch checked={s.priceIncl} onChange={e=>set("priceIncl",e.target.checked)}/></div>
              <div className="st-row"><div className="st-row__t"><b>Kuruş yuvarlama</b><span>Nakit ödemelerde toplam en yakın 0,10 ₺'ye yuvarlanır.</span></div><Switch checked={s.roundCents} onChange={e=>set("roundCents",e.target.checked)}/></div>
            </div>
          </div>
        )}

        {tab==="receipt" && (
          <div className="st-card">
            <div className="st-card__hd"><b>Fiş Şablonu</b><span>POS'tan basılan fişin görünümü.</span></div>
            <div className="st-card__bd">
              <div className="st-grid">
                <div style={{display:"flex",flexDirection:"column",gap:16}}>
                  <div className="st-field"><label className="st-label">Fiş Başlığı</label><Input value={s.receiptHeader} onChange={e=>set("receiptHeader",e.target.value)}/></div>
                  <div className="st-field"><label className="st-label">Fiş Alt Notu</label><Textarea rows={2} value={s.receiptFooter} onChange={e=>set("receiptFooter",e.target.value)}/></div>
                  <div className="st-row" style={{paddingTop:4}}><div className="st-row__t"><b>Logo göster</b></div><Switch checked={s.showLogo} onChange={e=>set("showLogo",e.target.checked)}/></div>
                  <div className="st-row"><div className="st-row__t"><b>Sadakat puanı göster</b></div><Switch checked={s.showPoints} onChange={e=>set("showPoints",e.target.checked)}/></div>
                </div>
                <div>
                  <div style={{font:"var(--fw-medium) 10.5px/1 var(--font-sans)",textTransform:"uppercase",letterSpacing:".05em",color:"var(--text-placeholder)",marginBottom:10,textAlign:"center"}}>Önizleme</div>
                  <div className="st-receipt">
                    <div className="st-receipt__c">{s.showLogo && <div className="st-receipt__logo">Uyanık</div>}<div style={{fontSize:10,color:"#78829d",marginTop:3}}>{s.receiptHeader}</div></div>
                    <div className="st-receipt__line"/>
                    <div className="st-receipt__r"><span>Caffè Latte</span><span>80,00</span></div>
                    <div className="st-receipt__r"><span>Cheesecake</span><span>110,00</span></div>
                    <div className="st-receipt__line"/>
                    <div className="st-receipt__r"><span>KDV %8</span><span>14,07</span></div>
                    <div className="st-receipt__tot"><span>TOPLAM</span><span>190,00 ₺</span></div>
                    {s.showPoints && <><div className="st-receipt__line"/><div className="st-receipt__r"><span>Kazanılan puan</span><span>+19</span></div></>}
                    <div className="st-receipt__ft">{s.receiptFooter}</div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        )}

        {tab==="general" && (
          <div className="st-card">
            <div className="st-card__hd"><b>Genel</b><span>Dil, tarih biçimi ve sistem davranışları.</span></div>
            <div className="st-card__bd">
              <div className="st-grid" style={{marginBottom:8}}>
                <div className="st-field"><label className="st-label">Dil</label><Select value={s.lang} onChange={e=>set("lang",e.target.value)}><option>Türkçe</option><option>English</option></Select></div>
                <div className="st-field"><label className="st-label">Tarih Biçimi</label><Select value={s.dateFmt} onChange={e=>set("dateFmt",e.target.value)}><option>GG.AA.YYYY</option><option>YYYY-AA-GG</option></Select></div>
              </div>
              <div className="st-row"><div className="st-row__t"><b>Eşik-altı stok uyarısı</b><span>Stok eşiğin altına düşünce bildirim gönderilir.</span></div><Switch checked={s.lowStockAlert} onChange={e=>set("lowStockAlert",e.target.checked)}/></div>
              <div className="st-row"><div className="st-row__t"><b>Otomatik fiş yazdırma</b><span>Sipariş tamamlanınca fiş otomatik basılır.</span></div><Switch checked={s.autoPrint} onChange={e=>set("autoPrint",e.target.checked)}/></div>
            </div>
          </div>
        )}
      </div>
    </React.Fragment>
  );
}
window.SettingsView = SettingsView;
