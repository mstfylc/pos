/* Rapor Oluşturucu — kullanıcı kendi raporunu seçer, önizler, formatında indirir. window.ReportBuilder */
const RBMDS = window.MetronicDesignSystem_a73f8f;

const RB_CSS = `
.rb{display:grid;grid-template-columns:308px 1fr;gap:18px;align-items:start;}
@media(max-width:1080px){.rb{grid-template-columns:1fr;}}
.rb-saved{display:flex;flex-wrap:wrap;gap:8px;margin-bottom:16px;align-items:center;}
.rb-saved__lbl{font:var(--fw-semibold) 11px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;color:var(--text-placeholder);margin-right:2px;}
.rb-saved__c{display:inline-flex;align-items:center;gap:7px;padding:8px 13px;border:1px solid var(--border-default);border-radius:999px;background:var(--surface-card);cursor:pointer;font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-body);transition:all .12s;}
.rb-saved__c:hover{border-color:var(--color-primary);box-shadow:var(--shadow-sm);color:var(--color-primary);}
.rb-cfg{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);position:sticky;top:16px;overflow:hidden;}
.rb-cfg__sec{padding:15px 16px;border-bottom:1px solid var(--border-default);}
.rb-cfg__foot{padding:14px 16px;display:flex;flex-direction:column;gap:9px;background:var(--color-grey-50,var(--surface-card));}
.rb-lbl{font:var(--fw-semibold) 11px/1 var(--font-sans);text-transform:uppercase;letter-spacing:.05em;color:var(--text-placeholder);margin-bottom:10px;display:flex;align-items:center;gap:6px;}
.rb-types{display:flex;flex-direction:column;gap:6px;}
.rb-type{display:flex;align-items:center;gap:10px;padding:9px 11px;border-radius:var(--radius-md);border:1px solid var(--border-default);background:var(--surface-card);cursor:pointer;text-align:left;appearance:none;transition:all .12s;width:100%;}
.rb-type:hover{border-color:var(--color-primary);}
.rb-type.on{border-color:var(--color-primary);background:var(--color-primary-soft);}
.rb-type__ic{width:30px;height:30px;border-radius:8px;background:var(--color-grey-100);display:flex;align-items:center;justify-content:center;flex:none;}
.rb-type.on .rb-type__ic{background:var(--surface-card);}
.rb-type__t b{font:var(--fw-semibold) 12.5px/1.15 var(--font-sans);color:var(--text-heading);display:block;}
.rb-type__t span{font:var(--fw-regular) 10.5px/1.25 var(--font-sans);color:var(--text-muted);display:block;margin-top:1px;}
.rb-chips{display:flex;flex-wrap:wrap;gap:6px;}
.rb-chip{appearance:none;border:1px solid var(--border-default);background:var(--surface-card);border-radius:999px;padding:6px 12px;font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-body);cursor:pointer;transition:all .12s;}
.rb-chip:hover{border-color:var(--color-primary);}
.rb-chip.on{background:var(--color-primary);border-color:var(--color-primary);color:#fff;}
.rb-dates{display:grid;grid-template-columns:1fr 1fr;gap:8px;margin-top:9px;}
.rb-field{margin-bottom:11px;}
.rb-field:last-child{margin-bottom:0;}
.rb-cols{display:flex;flex-direction:column;gap:10px;}
.rb-prev{background:var(--surface-card);border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-sm);overflow:hidden;}
.rb-prev__hd{display:flex;align-items:center;gap:12px;padding:14px 18px;border-bottom:1px solid var(--border-default);flex-wrap:wrap;}
.rb-prev__hd b{font:var(--fw-semibold) 14px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.rb-prev__meta{font:var(--fw-regular) 11.5px/1.3 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.rb-prev__bd{padding:18px;}
.rb-state-seg{display:inline-flex;background:var(--color-grey-100);border-radius:8px;padding:3px;gap:2px;}
.rb-state-seg button{appearance:none;border:0;background:none;cursor:pointer;font:var(--fw-semibold) 11px/1 var(--font-sans);color:var(--text-muted);padding:6px 10px;border-radius:6px;transition:all .12s;}
.rb-state-seg button.on{background:var(--surface-card);color:var(--text-heading);box-shadow:var(--shadow-sm);}
.rb-kpis{display:grid;grid-template-columns:repeat(4,1fr);gap:12px;margin-bottom:16px;}
@media(max-width:680px){.rb-kpis{grid-template-columns:1fr 1fr;}}
.rb-kpi{border:1px solid var(--border-default);border-radius:var(--radius-md);padding:12px 14px;}
.rb-kpi span{font:var(--fw-medium) 11px/1.2 var(--font-sans);color:var(--text-muted);}
.rb-kpi b{font:var(--fw-bold) 21px/1 var(--font-sans);color:var(--text-heading);display:block;margin-top:8px;font-variant-numeric:tabular-nums;letter-spacing:var(--ls-tight);}
.rb-kpi-sk{height:14px;border-radius:5px;background:var(--color-grey-100);}
.rb-idle{display:flex;flex-direction:column;align-items:center;justify-content:center;text-align:center;gap:9px;padding:64px 28px;}
.rb-idle__ic{width:64px;height:64px;border-radius:16px;background:var(--color-primary-soft);display:flex;align-items:center;justify-content:center;margin-bottom:4px;}
.rb-idle__t{font:var(--fw-bold) 17px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.rb-idle__s{font:var(--fw-regular) 13px/1.5 var(--font-sans);color:var(--text-muted);max-width:380px;}
.rb-stale{display:flex;align-items:center;gap:8px;font:var(--fw-medium) 12px/1.3 var(--font-sans);color:#9a5b12;background:var(--color-accent-soft);padding:9px 13px;border-radius:var(--radius-md);margin-bottom:14px;}
.rb-dot{width:9px;height:9px;border-radius:50%;flex:none;display:inline-block;}
`;
function injectRB(){ if(document.getElementById('rb-css'))return; const e=document.createElement('style');e.id='rb-css';e.textContent=RB_CSS;document.head.appendChild(e); }

const RB_FMT = n => Math.round(n).toLocaleString('tr-TR');
const RB_BRANCHES = ["Çayyolu","Bağdat Cad.","Alsancak"];
const RB_PAYS = ["Kredi/Banka Kartı","Nakit","Yemek Kartı","Sadakat Puanı"];
const RB_CATS = ["Espresso Bazlı","Soğuk Kahve","Filtre Kahve","Tatlı","Atıştırmalık"];
const RB_PRODUCTS = [["Caffè Latte","Espresso Bazlı"],["Cappuccino","Espresso Bazlı"],["Americano","Espresso Bazlı"],["Türk Kahvesi","Espresso Bazlı"],["Filtre Kahve","Filtre Kahve"],["Cold Brew","Soğuk Kahve"],["Ice Latte","Soğuk Kahve"],["Cheesecake","Tatlı"],["Brownie","Tatlı"],["San Sebastian","Tatlı"],["Kruvasan","Atıştırmalık"],["Su 0.5L","Atıştırmalık"]];
const RB_STAFF = [["Selin Aydın","Çayyolu"],["Mert Kaya","Çayyolu"],["Ece Demir","Bağdat Cad."],["Burak Şahin","Alsancak"],["Zeynep Ak","Çayyolu"],["Can Yıldız","Bağdat Cad."]];
const RB_TIERS = ["Bronz","Gümüş","Altın","Platin"];

const RB_RANGES = [
  { id:"today", label:"Bugün", days:1 },
  { id:"yesterday", label:"Dün", days:1 },
  { id:"7d", label:"Son 7 gün", days:7 },
  { id:"30d", label:"Son 30 gün", days:30 },
  { id:"month", label:"Bu ay", days:30 },
  { id:"custom", label:"Özel…", days:14 },
];
function rbRangeLabel(id, c1, c2){ if(id==="custom") return (c1||"GG.AA.YYYY")+" – "+(c2||"GG.AA.YYYY"); return RB_RANGES.find(r=>r.id===id).label; }

function rnd(s){ const x=Math.sin(s*12.9898)*43758.5453; return x-Math.floor(x); }
function dateList(n){ const base=new Date(2026,5,7); const out=[]; for(let i=n-1;i>=0;i--){ const d=new Date(base); d.setDate(base.getDate()-i); out.push(String(d.getDate()).padStart(2,'0')+'.'+String(d.getMonth()+1).padStart(2,'0')+'.'+d.getFullYear()); } return out; }

/* Report-type registry. Each build(cfg) -> {cols, rows, kpis} */
const RB_TYPES = [
  { id:"sales", label:"Satış Özeti", icon:"chart-line-up", desc:"Ciro, sipariş, sepet",
    groups:[["gun","Gün"],["hafta","Hafta"],["ay","Ay"],["sube","Şube"],["odeme","Ödeme tipi"]], defGroup:"gun" },
  { id:"products", label:"Ürün Satışları", icon:"notepad-bookmark", desc:"Ürün / kategori bazında",
    groups:[["urun","Ürün"],["kategori","Kategori"]], defGroup:"urun" },
  { id:"stock", label:"Stok Durumu", icon:"folder", desc:"Mevcut, eşik, değer", groups:[], defGroup:"" },
  { id:"payments", label:"Ödeme Kırılımı", icon:"price-tag", desc:"Yöntem bazında tahsilat", groups:[], defGroup:"" },
  { id:"loyalty", label:"Müşteri & Sadakat", icon:"heart", desc:"Seviye, puan, ciro",
    groups:[["seviye","Seviye"],["musteri","Müşteri"]], defGroup:"seviye" },
  { id:"staff", label:"Personel Performansı", icon:"people", desc:"Sipariş ve ciro", groups:[], defGroup:"" },
  { id:"returns", label:"İade & İptal", icon:"cross-circle", desc:"İptal edilen siparişler", groups:[], defGroup:"" },
];

function buildReport(cfg){
  const { type, group, range, customA, customB } = cfg;
  const days = (range==="custom") ? 14 : RB_RANGES.find(r=>r.id===range).days;
  const factor = Math.max(days, 1);

  if(type==="sales"){
    let labels, head;
    if(group==="gun"){ labels=dateList(Math.min(days,30)); head="Tarih"; }
    else if(group==="hafta"){ const w=Math.max(1,Math.round(days/7)); labels=Array.from({length:w},(_,i)=>(i+1)+". Hafta"); head="Hafta"; }
    else if(group==="ay"){ labels=["Mart 2026","Nisan 2026","Mayıs 2026","Haziran 2026"].slice(-Math.max(1,Math.min(4,Math.round(days/30)+1))); head="Ay"; }
    else if(group==="sube"){ labels=RB_BRANCHES; head="Şube"; }
    else { labels=RB_PAYS; head="Ödeme Yöntemi"; }
    const per = factor/labels.length;
    const rows = labels.map((l,i)=>{
      const orders=Math.round(150*per*(0.65+rnd(i+1)*0.7));
      const ciro=Math.round(orders*(56+rnd(i+9)*22));
      const indirim=Math.round(ciro*(0.03+rnd(i+3)*0.06));
      const net=ciro-indirim;
      return { grup:l, siparis:orders, ciro, indirim, net, sepet:Math.round(ciro/Math.max(orders,1)) };
    });
    return { cols:[
      {key:"grup",header:head,lock:true},
      {key:"siparis",header:"Sipariş",num:true},
      {key:"ciro",header:"Ciro",num:true,money:true},
      {key:"indirim",header:"İndirim",num:true,money:true},
      {key:"net",header:"Net Ciro",num:true,money:true,lock:true},
      {key:"sepet",header:"Ort. Sepet",num:true,money:true},
    ], rows };
  }

  if(type==="products"){
    const byCat = group==="kategori";
    const src = byCat ? RB_CATS.map(c=>[c,c]) : RB_PRODUCTS;
    const rows = src.map((p,i)=>{
      const adet=Math.round((byCat?60:18)*factor*(0.4+rnd(i+2)*0.9));
      const ciro=Math.round(adet*(48+rnd(i+5)*42));
      const iade=Math.round(adet*(0.01+rnd(i+7)*0.03));
      return { urun:p[0], kategori:p[1], adet, ciro, iade, net:Math.round(ciro*(1-(0.01+rnd(i+7)*0.03))) };
    }).sort((a,b)=>b.ciro-a.ciro);
    return { cols:[
      {key:"urun",header:byCat?"Kategori":"Ürün",lock:true},
      ...(byCat?[]:[{key:"kategori",header:"Kategori"}]),
      {key:"adet",header:"Adet",num:true,lock:true},
      {key:"ciro",header:"Ciro",num:true,money:true,lock:true},
      {key:"iade",header:"İade",num:true},
      {key:"net",header:"Net Ciro",num:true,money:true},
    ], rows };
  }

  if(type==="stock"){
    const rows = RB_PRODUCTS.map((p,i)=>{
      const esik=[15,20,10,25,12][i%5];
      const mevcut=Math.round(rnd(i+1)*40);
      const durum = mevcut===0?"out":(mevcut<esik?"low":"ok");
      return { urun:p[0], kategori:p[1], mevcut, esik, durum, deger:Math.round(mevcut*(28+rnd(i+4)*40)) };
    });
    return { cols:[
      {key:"urun",header:"Ürün",lock:true},
      {key:"kategori",header:"Kategori"},
      {key:"mevcut",header:"Mevcut",num:true,lock:true},
      {key:"esik",header:"Eşik",num:true},
      {key:"durum",header:"Durum",stock:true,lock:true},
      {key:"deger",header:"Stok Değeri",num:true,money:true},
    ], rows };
  }

  if(type==="payments"){
    const base=[0.55,0.27,0.11,0.07];
    const totalCiro=Math.round(10500*factor);
    const rows = RB_PAYS.map((p,i)=>{
      const tutar=Math.round(totalCiro*base[i]*(0.9+rnd(i+1)*0.2));
      const islem=Math.round(tutar/(55+rnd(i+3)*30));
      return { yontem:p, islem, tutar, pay:Math.round(base[i]*100), ort:Math.round(tutar/Math.max(islem,1)) };
    });
    return { cols:[
      {key:"yontem",header:"Yöntem",lock:true},
      {key:"islem",header:"İşlem",num:true},
      {key:"tutar",header:"Tutar",num:true,money:true,lock:true},
      {key:"pay",header:"Pay %",num:true,pct:true},
      {key:"ort",header:"Ort. İşlem",num:true,money:true},
    ], rows };
  }

  if(type==="loyalty"){
    const byTier = group!=="musteri";
    if(byTier){
      const counts=[640,380,180,40];
      const rows=RB_TIERS.map((t,i)=>{
        const uye=Math.round(counts[i]*(0.9+rnd(i+1)*0.2));
        const kaz=Math.round(uye*(30+i*22)*factor/7);
        return { ad:t, uye, kazanilan:kaz, harcanan:Math.round(kaz*(0.3+rnd(i+2)*0.3)), ciro:Math.round(uye*(40+i*55)*factor/7) };
      });
      return { cols:[
        {key:"ad",header:"Seviye",lock:true},
        {key:"uye",header:"Üye",num:true,lock:true},
        {key:"kazanilan",header:"Kazanılan Puan",num:true},
        {key:"harcanan",header:"Harcanan Puan",num:true},
        {key:"ciro",header:"Ciro",num:true,money:true,lock:true},
      ], rows };
    }
    const names=["Ayşe Yılmaz","Mehmet Demir","Elif Kaya","Ahmet Çelik","Zeynep Arslan","Hakan Öz","Deniz Acar","Selin Tan"];
    const rows=names.map((n,i)=>{
      const ciro=Math.round((2200-i*180)*factor/30+rnd(i+1)*400);
      return { ad:n, uye:RB_TIERS[Math.min(3,3-(i%4))], kazanilan:Math.round(ciro*0.1), harcanan:Math.round(ciro*0.04), ciro };
    });
    return { cols:[
      {key:"ad",header:"Müşteri",lock:true},
      {key:"uye",header:"Seviye"},
      {key:"kazanilan",header:"Kazanılan Puan",num:true},
      {key:"harcanan",header:"Harcanan Puan",num:true},
      {key:"ciro",header:"Ciro",num:true,money:true,lock:true},
    ], rows };
  }

  if(type==="staff"){
    const rows=RB_STAFF.map((s,i)=>{
      const orders=Math.round((180-i*15)*factor/7*(0.8+rnd(i+1)*0.4));
      const ciro=Math.round(orders*(58+rnd(i+2)*16));
      return { ad:s[0], sube:s[1], siparis:orders, ciro, sepet:Math.round(ciro/Math.max(orders,1)) };
    }).sort((a,b)=>b.ciro-a.ciro);
    return { cols:[
      {key:"ad",header:"Personel",lock:true},
      {key:"sube",header:"Şube"},
      {key:"siparis",header:"Sipariş",num:true,lock:true},
      {key:"ciro",header:"Ciro",num:true,money:true,lock:true},
      {key:"sepet",header:"Ort. Sepet",num:true,money:true},
    ], rows };
  }

  /* returns */
  const reasons=["Yanlış ürün","Müşteri vazgeçti","Stok yok","Geç hazırlandı","Kalite şikayeti"];
  const dl=dateList(Math.min(days,30));
  const rows=Array.from({length:Math.min(14,Math.max(4,Math.round(factor/2)))}).map((_,i)=>{
    const p=RB_PRODUCTS[i%RB_PRODUCTS.length];
    return { tarih:dl[(i*3)%dl.length], no:"#UYK-"+(2048-i), urun:p[0], tutar:Math.round(48+rnd(i+1)*180), sebep:reasons[i%reasons.length] };
  });
  return { cols:[
    {key:"tarih",header:"Tarih",lock:true},
    {key:"no",header:"Sipariş No",lock:true},
    {key:"urun",header:"Ürün"},
    {key:"tutar",header:"Tutar",num:true,money:true,lock:true},
    {key:"sebep",header:"Sebep"},
  ], rows };
}

function reportKpis(type, cols, rows){
  const sum=k=>rows.reduce((s,r)=>s+(typeof r[k]==="number"?r[k]:0),0);
  if(type==="sales") return [["Toplam Ciro",RB_FMT(sum("ciro"))+" ₺"],["Sipariş",RB_FMT(sum("siparis"))],["İndirim",RB_FMT(sum("indirim"))+" ₺"],["Net Ciro",RB_FMT(sum("net"))+" ₺"]];
  if(type==="products") return [["Toplam Adet",RB_FMT(sum("adet"))],["Ciro",RB_FMT(sum("ciro"))+" ₺"],["İade",RB_FMT(sum("iade"))],["Satır",String(rows.length)]];
  if(type==="stock") return [["Ürün",String(rows.length)],["Eşik-altı",String(rows.filter(r=>r.durum==="low").length)],["Tükenen",String(rows.filter(r=>r.durum==="out").length)],["Stok Değeri",RB_FMT(sum("deger"))+" ₺"]];
  if(type==="payments") return [["Tahsilat",RB_FMT(sum("tutar"))+" ₺"],["İşlem",RB_FMT(sum("islem"))],["Yöntem",String(rows.length)],["Ort. İşlem",RB_FMT(sum("tutar")/Math.max(sum("islem"),1))+" ₺"]];
  if(type==="loyalty") return [["Üye",RB_FMT(sum("uye"))],["Kazanılan",RB_FMT(sum("kazanilan"))],["Harcanan",RB_FMT(sum("harcanan"))],["Ciro",RB_FMT(sum("ciro"))+" ₺"]];
  if(type==="staff") return [["Personel",String(rows.length)],["Sipariş",RB_FMT(sum("siparis"))],["Ciro",RB_FMT(sum("ciro"))+" ₺"],["Ort. Sepet",RB_FMT(sum("ciro")/Math.max(sum("siparis"),1))+" ₺"]];
  return [["İade Kaydı",String(rows.length)],["Tutar",RB_FMT(sum("tutar"))+" ₺"],["Ort. Tutar",RB_FMT(sum("tutar")/Math.max(rows.length,1))+" ₺"],["",""]];
}

const RB_STOCK_DOT={ok:["#22c55e","Normal"],low:["#e08a2b","Eşik-altı"],out:["#ef4444","Tükendi"]};

const RB_SAVED=[
  { name:"Günlük Satış Özeti", type:"sales", group:"gun", range:"7d" },
  { name:"En Çok Satan Ürünler", type:"products", group:"urun", range:"30d" },
  { name:"Ödeme Kırılımı", type:"payments", group:"", range:"30d" },
  { name:"Düşük Stok Listesi", type:"stock", group:"", range:"today" },
];

function downloadFile(name, mime, content){
  try{
    const blob=new Blob([content],{type:mime});
    const url=URL.createObjectURL(blob);
    const a=document.createElement('a'); a.href=url; a.download=name;
    document.body.appendChild(a); a.click(); a.remove();
    setTimeout(()=>URL.revokeObjectURL(url),1500);
    return true;
  }catch(e){ return false; }
}
function cellText(c,r){ const v=r[c.key]; if(c.stock) return RB_STOCK_DOT[v][1]; if(c.num) return RB_FMT(v)+(c.money?" ₺":c.pct?" %":""); return String(v); }
function exportCSV(meta, cols, rows){
  const esc=s=>{ s=String(s); return /[";\n]/.test(s)?'"'+s.replace(/"/g,'""')+'"':s; };
  const head=cols.map(c=>esc(c.header)).join(";");
  const body=rows.map(r=>cols.map(c=>esc(cellText(c,r))).join(";")).join("\n");
  return downloadFile(meta+".csv","text/csv;charset=utf-8","\uFEFF"+head+"\n"+body);
}
function exportXLS(meta, cols, rows){
  const th=cols.map(c=>`<th style="background:#1F3864;color:#fff;text-align:left;padding:6px 10px;">${c.header}</th>`).join("");
  const trs=rows.map(r=>"<tr>"+cols.map(c=>`<td style="padding:5px 10px;border:1px solid #ddd;${c.num?'mso-number-format:0;text-align:right;':''}">${cellText(c,r)}</td>`).join("")+"</tr>").join("");
  const html=`<html xmlns:x="urn:schemas-microsoft-com:office:excel"><head><meta charset="utf-8"></head><body><table border="0"><thead><tr>${th}</tr></thead><tbody>${trs}</tbody></table></body></html>`;
  return downloadFile(meta+".xls","application/vnd.ms-excel",html);
}
function exportPDF(meta, cols, rows){
  const th=cols.map(c=>`<th>${c.header}</th>`).join("");
  const trs=rows.map(r=>"<tr>"+cols.map(c=>`<td class="${c.num?'n':''}">${cellText(c,r)}</td>`).join("")+"</tr>").join("");
  const doc=`<!doctype html><html><head><meta charset="utf-8"><title>${meta}</title><style>
    *{font-family:-apple-system,BlinkMacSystemFont,'Segoe UI',sans-serif;}
    body{margin:34px;color:#1a1a1a;}
    h1{font-size:18px;margin:0 0 2px;color:#1F3864;} .sub{font-size:11px;color:#777;margin-bottom:18px;}
    table{width:100%;border-collapse:collapse;font-size:11px;}
    th{background:#1F3864;color:#fff;text-align:left;padding:7px 10px;}
    td{padding:6px 10px;border-bottom:1px solid #e5e5e5;} td.n,th.n{text-align:right;}
    @media print{@page{margin:14mm;}}
  </style></head><body><h1>Uyanık — ${meta}</h1><div class="sub">Çayyolu Şubesi · Oluşturulma: 07.06.2026</div>
  <table><thead><tr>${th}</tr></thead><tbody>${trs}</tbody></table>
  <script>window.onload=function(){setTimeout(function(){window.print();},250);}<\/script></body></html>`;
  let w=null;
  try{ w=window.open("","_blank","width=900,height=700"); }catch(e){ w=null; }
  if(w){ w.document.write(doc); w.document.close(); return true; }
  return downloadFile(meta+".html","text/html",doc); /* popup engellendiyse yazdırılabilir HTML indir */
}

function ColToggle({ col, on, onToggle }){
  const { Checkbox } = RBMDS;
  if(col.lock) return (
    <label style={{display:"inline-flex",alignItems:"center",gap:9,opacity:.55,cursor:"not-allowed",font:"var(--fw-medium) 13px/1.3 var(--font-sans)",color:"var(--text-body)"}}>
      <span style={{width:18,height:18,borderRadius:5,background:"var(--color-primary)",display:"flex",alignItems:"center",justifyContent:"center"}}>
        <RBMDS.Icon name="check-circle" size={12} color="#fff"/>
      </span>{col.header}
    </label>
  );
  return <Checkbox label={col.header} checked={on} onChange={onToggle}/>;
}

function ReportBuilder(){
  React.useEffect(()=>{injectRB();},[]);
  const { Button, Select, Input, Switch } = RBMDS;
  const toast = RBMDS.ToastProvider.useToast();

  const [type,setType]=React.useState("sales");
  const [group,setGroup]=React.useState("gun");
  const [range,setRange]=React.useState("7d");
  const [cA,setCA]=React.useState(""); const [cB,setCB]=React.useState("");
  const [branch,setBranch]=React.useState("");
  const [cat,setCat]=React.useState("");
  const [hidden,setHidden]=React.useState({});     // {colKey:true} = gizli
  const [format,setFormat]=React.useState("table");
  const [schedule,setSchedule]=React.useState(false);

  const [ran,setRan]=React.useState(false);
  const [stale,setStale]=React.useState(false);
  const [state,setState]=React.useState("idle");   // idle|loading|full|empty|error
  const [page,setPage]=React.useState(1);
  const [sort,setSort]=React.useState(null);
  const PAGE=8;

  const typeDef=RB_TYPES.find(t=>t.id===type);
  const built=React.useMemo(()=>buildReport({type,group,range,customA:cA,customB:cB}),[type,group,range,cA,cB]);
  const visCols=built.cols.filter(c=>!hidden[c.key]);
  const kpis=reportKpis(type,built.cols,built.rows);
  const metaTitle=typeDef.label;
  const metaLine=`${rbRangeLabel(range,cA,cB)}${typeDef.groups.length?` · ${typeDef.groups.find(g=>g[0]===group)?.[1]||""} kırılımı`:""}${branch?` · ${branch}`:" · Tüm şubeler"}`;

  function markStale(){ if(ran) setStale(true); }
  function changeType(id){ const d=RB_TYPES.find(t=>t.id===id); setType(id); setGroup(d.defGroup); setHidden({}); setSort(null); setPage(1); markStale(); }
  function run(){ setRan(true); setStale(false); setState("loading"); setPage(1);
    setTimeout(()=>setState(built.rows.length?"full":"empty"),650); }

  function quick(s){ setType(s.type); const d=RB_TYPES.find(t=>t.id===s.type); setGroup(s.group||d.defGroup); setRange(s.range); setHidden({}); setBranch(""); setCat(""); setSort(null); setPage(1);
    setRan(true); setStale(false); setState("loading"); setTimeout(()=>setState("full"),650); }

  function doExport(){
    const fname=`Uyanik_${metaTitle.replace(/[^\wğüşıöçĞÜŞİÖÇ]+/g,"_")}_${range}`;
    if(format==="csv"){ exportCSV(fname,visCols,built.rows) ? toast({type:"success",title:"CSV indirildi",description:fname+".csv"}) : toast({type:"error",title:"İndirilemedi"}); }
    else if(format==="excel"){ exportXLS(fname,visCols,built.rows) ? toast({type:"success",title:"Excel indirildi",description:fname+".xls"}) : toast({type:"error",title:"İndirilemedi"}); }
    else if(format==="pdf"){ exportPDF(metaTitle,visCols,built.rows); toast({type:"info",title:"PDF yazdırma",description:"Yazdır penceresinden 'PDF olarak kaydet' seçin."}); }
    else { toast({type:"info",title:"Tablo görünümü",description:"Rapor zaten ekranda. İndirmek için PDF / Excel / CSV seçin."}); }
  }

  // DataGrid columns
  const dgCols=visCols.map(c=>({
    key:c.key, header:c.header, align:c.num?"right":"left", sortable:true,
    render:r=>{
      if(c.stock){ const s=RB_STOCK_DOT[r[c.key]]; return <span style={{display:"inline-flex",alignItems:"center",gap:7,font:"var(--fw-semibold) 12px/1 var(--font-sans)",color:s[0]}}><span className="rb-dot" style={{background:s[0]}}/>{s[1]}</span>; }
      if(c.num) return <span style={{fontVariantNumeric:"tabular-nums",font:`${c.money||c.lock?"var(--fw-semibold)":"var(--fw-medium)"} 12.5px/1.3 var(--font-sans)`,color:c.money?"var(--text-heading)":"var(--text-body)"}}>{RB_FMT(r[c.key])}{c.money?" ₺":c.pct?" %":""}</span>;
      return <span style={{font:`${c.lock?"var(--fw-semibold)":"var(--fw-medium)"} 12.5px/1.3 var(--font-sans)`,color:c.lock?"var(--text-heading)":"var(--text-body)"}}>{r[c.key]}</span>;
    }
  }));
  let pageRows=built.rows;
  if(sort){ const dir=sort.dir==="asc"?1:-1; pageRows=[...built.rows].sort((a,b)=>{ const x=a[sort.key],y=b[sort.key]; return (typeof x==="number"?x-y:String(x).localeCompare(String(y),"tr"))*dir; }); }
  pageRows=pageRows.slice((page-1)*PAGE,page*PAGE);

  return (
    <div className="rb">
      {/* ---------------- CONFIG ---------------- */}
      <div className="rb-cfg">
        <div className="rb-cfg__sec">
          <span className="rb-lbl"><RBMDS.Icon name="files" size={13} color="var(--text-placeholder)"/>Rapor türü</span>
          <div className="rb-types">
            {RB_TYPES.map(t=>(
              <button key={t.id} className={"rb-type"+(type===t.id?" on":"")} onClick={()=>changeType(t.id)}>
                <span className="rb-type__ic"><RBMDS.Icon name={t.icon} size={16} color={type===t.id?"var(--color-primary)":"var(--text-muted)"}/></span>
                <span className="rb-type__t"><b>{t.label}</b><span>{t.desc}</span></span>
              </button>
            ))}
          </div>
        </div>

        <div className="rb-cfg__sec">
          <span className="rb-lbl"><RBMDS.Icon name="calendar" size={13} color="var(--text-placeholder)"/>Tarih aralığı</span>
          <div className="rb-chips">
            {RB_RANGES.map(r=>(
              <button key={r.id} className={"rb-chip"+(range===r.id?" on":"")} onClick={()=>{setRange(r.id);markStale();}}>{r.label}</button>
            ))}
          </div>
          {range==="custom" && (
            <div className="rb-dates">
              <Input size="sm" placeholder="GG.AA.YYYY" value={cA} onChange={e=>{setCA(e.target.value);markStale();}}/>
              <Input size="sm" placeholder="GG.AA.YYYY" value={cB} onChange={e=>{setCB(e.target.value);markStale();}}/>
            </div>
          )}
        </div>

        {typeDef.groups.length>0 && (
          <div className="rb-cfg__sec">
            <span className="rb-lbl"><RBMDS.Icon name="chart-pie-simple" size={13} color="var(--text-placeholder)"/>Kırılım</span>
            <Select size="sm" value={group} onChange={e=>{setGroup(e.target.value);markStale();}}>
              {typeDef.groups.map(g=><option key={g[0]} value={g[0]}>{g[1]}</option>)}
            </Select>
          </div>
        )}

        <div className="rb-cfg__sec">
          <span className="rb-lbl"><RBMDS.Icon name="filter" size={13} color="var(--text-placeholder)"/>Filtreler</span>
          <div className="rb-field">
            <Select size="sm" value={branch} onChange={e=>{setBranch(e.target.value);markStale();}}>
              <option value="">Tüm şubeler</option>{RB_BRANCHES.map(b=><option key={b} value={b}>{b}</option>)}
            </Select>
          </div>
          <div className="rb-field">
            <Select size="sm" value={cat} onChange={e=>{setCat(e.target.value);markStale();}}>
              <option value="">Tüm kategoriler</option>{RB_CATS.map(c=><option key={c} value={c}>{c}</option>)}
            </Select>
          </div>
        </div>

        <div className="rb-cfg__sec">
          <span className="rb-lbl"><RBMDS.Icon name="notepad-edit" size={13} color="var(--text-placeholder)"/>Sütunlar</span>
          <div className="rb-cols">
            {built.cols.map(c=>(
              <ColToggle key={c.key} col={c} on={!hidden[c.key]} onToggle={e=>{ setHidden(h=>({...h,[c.key]:!e.target.checked})); markStale(); }}/>
            ))}
          </div>
        </div>

        <div className="rb-cfg__foot">
          <label style={{display:"flex",alignItems:"center",justifyContent:"space-between",gap:10,font:"var(--fw-medium) 12px/1.3 var(--font-sans)",color:"var(--text-body)",cursor:"pointer"}}>
            <span>Her sabah e-posta gönder</span>
            <Switch checked={schedule} onChange={e=>setSchedule(e.target.checked)}/>
          </label>
          <Button color="accent" iconStart="chart-line-up" onClick={run} style={{width:"100%"}}>Raporu Hazırla</Button>
        </div>
      </div>

      {/* ---------------- PREVIEW ---------------- */}
      <div>
        <div className="rb-saved">
          <span className="rb-saved__lbl">Hazır şablonlar</span>
          {RB_SAVED.map(s=>(
            <button key={s.name} className="rb-saved__c" onClick={()=>quick(s)}>
              <RBMDS.Icon name="rocket" size={13} color="var(--color-primary)"/>{s.name}
            </button>
          ))}
        </div>

        <div className="rb-prev">
          <div className="rb-prev__hd">
            <div style={{minWidth:0}}>
              <b>{metaTitle}</b>
              <div className="rb-prev__meta">{metaLine}</div>
            </div>
            <div style={{marginLeft:"auto",display:"flex",alignItems:"center",gap:10,flexWrap:"wrap"}}>
              {ran && (
                <div className="rb-state-seg" title="Durum önizleme">
                  {[["full","Dolu"],["loading","Yükleniyor"],["empty","Boş"],["error","Hata"]].map(([k,l])=>(
                    <button key={k} className={state===k?"on":""} onClick={()=>setState(k)}>{l}</button>
                  ))}
                </div>
              )}
            </div>
          </div>

          <div className="rb-prev__bd">
            {!ran ? (
              <div className="rb-idle">
                <span className="rb-idle__ic"><RBMDS.Icon name="chart-line-up" size={28} color="var(--color-primary)"/></span>
                <div className="rb-idle__t">Raporunu oluştur</div>
                <div className="rb-idle__s">Soldan rapor türü, tarih aralığı, kırılım ve sütunları seç; <b>Raporu Hazırla</b>'ya bas. Önizlemeyi PDF, Excel veya CSV olarak indirebilirsin.</div>
                <div style={{marginTop:6}}><Button color="accent" iconStart="chart-line-up" onClick={run}>Raporu Hazırla</Button></div>
              </div>
            ) : (
              <React.Fragment>
                {stale && (
                  <div className="rb-stale">
                    <RBMDS.Icon name="notepad-edit" size={15} color="#9a5b12"/>
                    Ayarları değiştirdin — güncel sonuç için yeniden hazırla.
                    <Button size="sm" variant="light" color="dark" onClick={run} style={{marginLeft:"auto"}}>Yenile</Button>
                  </div>
                )}

                {/* KPI strip */}
                <div className="rb-kpis">
                  {kpis.map((k,i)=>(
                    <div className="rb-kpi" key={i}>
                      {state==="loading"
                        ? <><div className="rb-kpi-sk" style={{width:"55%"}}/><div className="rb-kpi-sk" style={{width:"75%",height:18,marginTop:10}}/></>
                        : <><span>{k[0]||"\u00A0"}</span><b>{k[1]||"\u00A0"}</b></>}
                    </div>
                  ))}
                </div>

                <RBMDS.DataGrid
                  columns={dgCols}
                  rows={state==="full"?pageRows:[]}
                  loading={state==="loading"} error={state==="error"?"Rapor verileri alınamadı.":null}
                  onRetry={run}
                  empty={{ icon:"files", title:"Sonuç yok", subtitle:"Bu filtrelerle kayıt bulunamadı. Tarih aralığını genişletin." }}
                  sort={sort} onSortChange={s=>{setSort(s);setPage(1);}}
                  page={page} pageSize={PAGE} total={built.rows.length} onPageChange={setPage}
                  rowKey={(r,i)=>r.no||r.urun||r.ad||r.grup||r.yontem||i}
                  footerNote={state==="full"?`${built.rows.length} satır · ${visCols.length} sütun`:undefined}
                />

                {/* Export bar */}
                <div style={{display:"flex",alignItems:"center",gap:12,marginTop:16,flexWrap:"wrap",paddingTop:16,borderTop:"1px solid var(--border-default)"}}>
                  <span style={{font:"var(--fw-semibold) 11px/1 var(--font-sans)",textTransform:"uppercase",letterSpacing:".05em",color:"var(--text-placeholder)"}}>Format</span>
                  <div className="rb-state-seg">
                    {[["table","Tablo"],["pdf","PDF"],["excel","Excel"],["csv","CSV"]].map(([k,l])=>(
                      <button key={k} className={format===k?"on":""} onClick={()=>setFormat(k)}>{l}</button>
                    ))}
                  </div>
                  <div style={{marginLeft:"auto",display:"flex",gap:9,flexWrap:"wrap"}}>
                    <Button variant="outline" color="dark" iconStart="files" onClick={()=>exportPDF(metaTitle,visCols,built.rows)}>Yazdır</Button>
                    <Button color="accent" iconStart="share" onClick={doExport} disabled={state!=="full"}>
                      {format==="csv"?"CSV indir":format==="excel"?"Excel indir":format==="pdf"?"PDF indir":"İndir"}
                    </Button>
                  </div>
                </div>
              </React.Fragment>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
window.ReportBuilder = ReportBuilder;
