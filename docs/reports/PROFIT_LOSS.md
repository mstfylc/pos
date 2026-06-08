# Profit / Loss ve Gelir Merkezi Envanteri

## Kisa sonuc

| Baslik | Sonuc | Not |
| --- | --- | --- |
| Legacy gelir merkezi / cost center | YOK | Isimlendirilmis `gelir merkezi`, `cost center`, `profit center` entity/controller mantigi bulunmadi. |
| Legacy kar/zarar benzeri rapor | KISMEN VAR | `sale/*` controller'i satis ozeti, urun satislari ve kullanici satislarini donuyor; brans/POS/kullanici/tag/tarih filtreleri var. |
| Mevcut backend P&L endpoint | YOK | `/api/v1/reports/*` altinda sadece giris urunu teslim raporu var. |
| P&L icin en kritik eksik | Maliyet snapshot'i | `order_products` satis anindaki birim maliyeti saklamiyor; `Product.PurchasePrice` degisirse gecmis kar raporu kayar. |

## 1. Legacy proje bulgulari

| Alan | Bulgu | Kaynak / isleyis |
| --- | --- | --- |
| Gelir merkezi kavrami | Bulunmadi | Kod aramasinda `gelir merkezi`, `cost center`, `profit center` veya benzeri ayrik kavram yok. |
| Satis ozeti endpoint'i | `GET sale/summary` | `SalesController.Summary`; policy: `SaleSummary`. |
| Urun satis listesi | `GET sale/list` | `ProductSaleDto` doner; LightQuery ile paged/sorted. |
| Kullanici satis raporu | `GET sale/salesByUser` | `SaleByUserDto` doner; kullanici bazli adet/toplam/indirim. |
| Excel satis listesi | `GET sale/listExcel` | Urun satis aggregate'ini Excel amacli doner. |
| Filtreler | company, branch, POS, user, payment, shipping, order state, customer order, tarih, tag | `OrderRepository.GetAllSales(...)` filtreleri bu alanlar uzerinden kuruyor. |
| Giris urunu adedi | Var | `Util.GetEntryProductCategoryId(companyId)` ile giris kategori urunleri bulunup `OrderDetailByProduct(...).Sum(Quantity)` ile sayiliyor. |
| Brut kar hesabi | Var ama sinirli | `GrossProfit = orders.Sum(Total) - orderProductList.Sum(Product.PurchasePrice)` olarak hesaplanmis. Gozlenen kod miktarla carpmiyor; iade/iptal etkisi sadece `orderState` filtresine bagli. |
| Kategori bazli P&L | Yok | Urun aggregate'i var; kategori bazli gelir/gider/kar raporu olarak ayrismamis. |
| Gider / satin alma raporu | Kismen var | Purchase CRUD/list ve `purchasesByProduct` var; stok hareketinde `Purchase` tipi yaziliyor. Ancak satis kar raporu ile entegre P&L yok. |

Legacy'de en yakin davranis `sale` rapor seti: gelir tarafini siparis toplamlarindan, kaba brut kari da urunlerin `PurchasePrice` alanindan hesapliyor. Bu bir "gelir merkezi" modeli degil; filtrelenebilir satis raporu.

## 2. Mevcut backend'de P&L icin mevcut veri

| P&L kalemi | Mevcut veri | Konum | Yeterlilik / risk |
| --- | --- | --- | --- |
| Satis geliri | `Order.SubTotal`, `TaxTotal`, `TotalDiscount`, `Total`, `OrderState`, `OrderTime`, `PosId`, `UserId`, `CompanyId` | `Order` | Gelir icin ana kaynak var; brans bilgisi POS uzerinden gelir. |
| Odeme tahsilati | `OrderPayment.Amount`, `PaymentType`, `State`, `ReversalOfId`, `Reason`, `PaidAt` | `OrderPayment` | Nakit bazli rapor icin uygun; iade/iptal ters satirlari var. |
| Satis satirlari | `OrderProduct.ProductId`, `Quantity`, `Total`, `IsEntry` | `OrderProduct` | Urun ve adet var; satis anindaki birim fiyat/maliyet snapshot'i yok. |
| Urun maliyeti | `Product.PurchasePrice`, POS override icin `PosProduct.PurchasePrice` | `Product`, `PosProduct` | Guncel maliyet var; gecmis rapor icin tek basina guvenilir degil. |
| Indirim gideri | `Order.TotalDiscount`, `OrderDiscount.Amount`, `DiscountUsageLog.Amount` | `Order`, `OrderDiscount`, `DiscountUsageLog` | Manuel indirim loglanir; kampanya indirimi toplam indirime dahil olabilir, ayrik P&L kalemi olarak netlesmeli. |
| Iptal / iade | `OrderState`, `OrderPayment` reversal, append-only stock/wallet/loyalty reversal | Order ve ledger tablolar | Ters kayit yaklasimi var; P&L raporu hangi state/reversal'i dahil edecegini tanimlamali. |
| Giris urunu maliyeti | `OrderProduct.IsEntry = true`, satir tutari 0, stok normal duser | `OrderProduct`, `StockMovement` | Gelir 0; COGS icin maliyet gerekir. Snapshot olmadigi icin bugunku `PurchasePrice` ile hesaplamak tarihsel sapma yaratir. |
| Satin alma gideri | `Purchase.Total`, `PurchaseProduct.Price/Total/Discount/Tax`, `StoreProductMovementType.Purchase` | `Purchase`, `PurchaseProduct`, stok hareketleri | Alim kaydi var; P&L'de dogrudan gider mi, stok maliyeti mi sayilacak muhasebe kurali eksik. |
| Stok kayip/duzeltme | `StockMovement.Direction`, `MovementType`, `Quantity`, `Description`, `OccurredAt` | `StockMovement` | Imha/sayim farki gibi envanter zarari raporlanabilir; parasal deger icin maliyet snapshot'i gerekir. |

## 3. Mevcut `/api/v1/reports/*` uclari

| Endpoint | Donen veri | P&L durumu |
| --- | --- | --- |
| `GET /api/v1/reports/entry-products` | Tarih, sube, POS, urun, adet bazli giris urunu teslim satirlari | Kar/zarar degil; sadece `is_entry` satirlarini adet olarak raporlar. |

Mevcut backend'de kar/zarar, gelir-gider ozeti, brut kar veya gelir merkezi endpoint'i bulunmuyor. Rapor katmani su an ham satis ozeti de donmuyor; sadece giris urunu teslimi var.

## 4. P&L raporu kurmak icin eklenmesi gerekenler

| Eksik | Oneri | Neden |
| --- | --- | --- |
| Satis anindaki maliyet | `order_products` uzerine `unit_cost` ve `cost_total` ekle veya append-only COGS ledger kur | Gecmis P&L, urun alis fiyati degisince bozulmamali. |
| P&L endpoint'i | `GET /api/v1/reports/profit-loss` | `companyId`, `from`, `to`, `branchId`, `posId`, `categoryId`, `productId`, `groupBy=day/branch/pos/category/product` filtreleriyle rapor donmeli. |
| Gelir hesabi kurali | Satis bazli ve tahsilat bazli ayrimi netlestir | `Order.Total` satis geliridir; `OrderPayment` nakit/tahsilat akisidir. Ikisi ayni raporda karistirilmamali. |
| Iptal/iade muhasebesi | Completed/captured satislar pozitif; refund/cancel reversal satirlari negatif yazilmali | Silme yok, ters kayit var. Rapor da append-only mantigina uymali. |
| Indirim ayrimi | Manual discount, coupon, campaign discount kalemleri ayrik raporlanmali | Toplam indirim var; P&L icin hangi indirimin kampanya/kupon/personel kaynakli oldugu gerekir. |
| Giris urunu maliyeti | `is_entry=true` satirlar gelir 0, COGS pozitif olarak raporlanmali | Giris paketi teslimi kari azaltir; stok duser ama satis geliri yoktur. |
| Satin alma raporu ayrimi | Purchase gideri ile satilan malin maliyeti ayrilmali | Alim stok varligi yaratir; P&L'de COGS satis aninda, nakit akista purchase odemesi olarak gorulmeli. |
| Stok kayip gideri | Destroy / count diff hareketleri maliyetle carpilip envanter zarari olarak eklenmeli | Imha ve sayim farki operasyonel zarar kalemidir. |
| Indeksler | `orders(company_id, order_time, pos_id, order_state)`, `order_products(order_id, product_id, is_entry)`, `order_payments(company_id, paid_at, state)`, `products(category_id)`, `stock_movements(company_id, occurred_at, store_id, product_id, movement_type)` | Tarih ve grup bazli rapor sorgulari icin gerekli. |
| Testler | Satis, indirimli satis, giris urunu, iptal/iade, maliyet degisimi, kategori/POS/sube gruplama | P&L hatalari finansal etki yarattigi icin kritik test gerekir. |

## Frontend / urunlesme notu

| Ihtiyac | Not |
| --- | --- |
| Gelir merkezi UI | Legacy'deki gibi sube/POS/kullanici/tag filtreleriyle baslanabilir; ayrik "gelir merkezi" entity'si yoksa ilk seviye POS/sube/kategori gruplama yeterli. |
| P&L kartlari | Net satis, indirim, COGS, brut kar, giris urunu maliyeti, iade/iptal, stok kaybi kalemleri ayrik gosterilmeli. |
| Guvenilirlik uyarisi | Maliyet snapshot'i eklenmeden bugunku `PurchasePrice` ile gecmis kar raporu uretmek dogru degil; rapora "tahmini" etiketi gerekir. |
