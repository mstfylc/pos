# POS_FLOW

## Kaynaklar

| Katman | Incelenen kaynak |
|---|---|
| Yeni backend | `AppOrdersController`, `AppCatalogController`, `CreateOrderService`, `EfOrderCreationStore`, domain order/catalog/discount/ledger/loyalty entity'leri, `contracts/openapi.yaml` |
| Legacy referans | `AppOrderController`, `AppPosProductController`, `AppProductController`, `AppUserController`, `OrderRepository`, `OrderProductRepository`, `OrderSubProductRepository`, `DiscountUsageLogRepository`, `CustomerController`, `CardController` |

## 1. Siparis olusturma akisi

| Parca | Mevcut backend | Legacy POS davranisi | Frontend notu |
|---|---|---|---|
| Endpoint | `POST /api/v1/app/orders`; idempotency header `Idempotency-Key` veya body `idempotencyKey`. | `POST app/order/create`; tek payload `OrderExtendedDto`. | Yeni POS bunu kullanabilir ama alan seti legacy kadar genis degil. |
| Zorunlu order alanlari | `companyId`, `posId`, `userId`, `shippingType`, `orderTime`, `idempotencyKey`, `lines`, `payments`. | `SubTotal`, `TaxTotal`, `Total`, `PaymentType`, `ShippingType`, `OrderState`, `OrderTime`, `OrderNumber`, `PosID`, `UserID`, `CompanyID`, `OrderProducts`. | Yeni backend toplam/tax'i satirlardan hesapliyor; legacy toplamlar client'tan geliyordu. |
| Opsiyonel order alanlari | `customerId`; body `idempotencyKey` header yoksa kullanilir. | `TotalDiscount`, `OfflineOrder`, `IsClosed`, `UpdateReason`, `Description`, `AddressID`, `CustomerID`, `OrderDiscounts`, `TagList`. | Yeni DTO'da `offlineOrder`, `description`, `addressId`, `orderNumber`, `isClosed`, tag ve manuel indirim yok. |
| Satirlar | `lines[]`: `productId`, `quantity`, `unitPrice`, `taxAmount=0`. | `OrderProducts[]`: `ProductID`, `Quantity`, `Total`, `SubProducts[]`. | Yeni DTO alt urun/recete satiri almiyor; POS combo/secenek UI'i backend'e kaydedemez. |
| Odemeler | `payments[]`: `paymentType`, `amount`, `currency=TRY`, `externalReference`. | Order'da tek `PaymentType` alani vardi; coklu odeme yoktu. | Yeni backend coklu odeme icin dogru yonde; UI toplam odeme = siparis toplam kontrolu yapmali. |
| Kayit etkisi | Tek transaction: order + order_products + order_payments + stock_movements + wallet_transactions + loyalty_point_transactions + store_product update. | Parcalar ard arda repo call ile yaziliyor; stok ve bakiye hareketleri ayrica isleniyor. | Yeni davranis daha guvenli; ama eksik DTO alanlari tasarimda saklanmali veya backend istenmeli. |

## 2. Odeme tipleri

| Baslik | Durum |
|---|---|
| `PaymentType` tam liste | `Cash`, `CreditCard`, `Ticket`, `Sodexo`, `Multinet`. Legacy enum da ayni. |
| `PaymentSummary` | `Cash`, `CreditCard`, `Ticket`, `Sodexo`, `Multinet`, `Mixed`. Tek tip odemede o tip, farkli tipler varsa `Mixed`. |
| Coklu / bolunmus odeme | Yeni backend `order_payments` satirlariyla calisir; her satir append-only `Captured` olur. `payments.Sum(amount)` siparis toplamiyla esit degilse 400. |
| Cuzdan / puan odemesi | `PaymentType` enum'da `Wallet` veya `LoyaltyPoints` yok. Mevcut backend customer varsa wallet bakiyesini siparis toplamindan otomatik duser; bu odeme satiri tipi degil. Puan kullanim ayri `POST /api/v1/app/loyalty/rewards/{rewardId}/redeem`. |

## 3. Offline siparis

| Baslik | Mevcut backend | Legacy davranisi | Eksik / risk |
|---|---|---|---|
| Bayrak | Domain `Order.OfflineOrder` var ama `CreateOrderRequest` almaz; create her zaman default `false`. | Payload `OfflineOrder` alir. `false` ise stok ve indirim limit kontrolu yapar; `true` ise stok yeterlilik ve indirim limit kontrolunu atlar, sadece urun/indirim var mi bakar. | POS offline outbox tasarimi icin DTO'da `offlineOrder` yok. |
| Idempotency | Zorunlu; ayni `companyId + idempotencyKey` tekrar gelirse mevcut order sonucu doner, duplicate yok. | Legacy'de idempotency key gorulmedi. | Offline senkron icin yeni backend dogru temel sunuyor. |
| Stok kontrolu | Mevcut create online/offline ayrimi yapmadan `Stocktaking=true` urunde yeterli stok ister. | Offline sipariste stok miktar kontrolu yok. | Offline satislar sunucuya geldiginde stok yetersizse bugun 400 alabilir. |

## 4. Musteri tanima

| Baslik | Durum |
|---|---|
| Legacy | Order sadece `CustomerID` alir; `ShippingType=Customer` ise musteri zorunlu, musteri varsa shipping type `Customer` olmak zorunda. Musteri listesi telefon/mail/username aramaya uygundur. Kart modeli (`Card`) ve user-card baglantisi var; musteri QR/token akisi gorulmedi. |
| Yeni backend | `customerId` verilirse wallet ve loyalty snapshot yuklenir. `CustomerCardToken` domain modeli var: `tokenHash`, `expiresAt`, `state`; fakat POS tarafinda token ureten/dogrulayan endpoint gorulmedi. |
| Tanininca gosterilecekler | `GET /api/v1/app/customers` temel musteri listesi; `GET /api/v1/app/customers/{customerId}/wallet` OpenAPI'de var; `GET /api/v1/loyalty/accounts/{customerId}` puan/tier ozeti verir. Mevcut controller tarafinda wallet/loyalty read route uyumu ayrica dogrulanmali. |
| Form/UI notu | POS icin telefon/isim arama ile musteri secimi yapilabilir; QR/kart okutma tasarlanacaksa backend endpoint eksik. |

## 5. Indirim

| Baslik | Durum |
|---|---|
| Legacy manuel indirim | `OrderDiscounts[]`: `DiscountID`, `UserID`, `Amount`. Create'te her indirim icin `DiscountUsageLog` yazilir. |
| Limit hesabi | Legacy `GetTotalUsedDiscount(discountId)` ayin ilk gununden bugune kadar kullanim toplamini alir; `orderDiscount.Amount + totalUsed > discount.MaxDiscountAmount` ise kategoriye gore hata. |
| Kapsam | `DiscountCategory`: `All`, `Branch`, `Personnel`, `Pos`; yeni backend `DiscountBranch`, `DiscountPos`, `DiscountUser` scope listelerini tanim CRUD'unda destekliyor. |
| Mevcut order create | `OrderDiscount` ve `DiscountUsageLog` yazmaz; sadece campaign evaluator kaynakli `TotalDiscount` hesaplar. Manuel indirim/kupon girisi DTO'da yok. |
| Kupon | Legacy ve mevcut backend'de POS order create'e bagli kupon kodu alanı gorulmedi. |

## 6. Sadakat anlik etki

| Baslik | Durum |
|---|---|
| Puan kazanimi | Customer varsa aktif earn rule'lar yuklenir; uygun rule'lar icinden `MinimumOrderTotal` en yuksek olan secilir. Puan = `floor(orderTotal / amountPerPoint) * tierMultiplier`; `expiryDays` varsa son kullanim tarihi yazilir. |
| Tier | Kazanim sonrasi lifetime points ile uygun en yuksek aktif tier'a upgrade olur; downgrade yok. |
| Kampanya | Aktif kampanyalar tarih, target tier ve min order ile filtrelenir. Ayni `CampaignType` icinde priority en yuksek tek kampanya uygulanir; farkli tipler birlikte uygulanir. Discount campaign toplam indirimi `maxTotalDiscount` ve order total ile cap'lenir. |
| Odul kullanimi | `RedeemReward` puani hemen dusup redemption code uretir; orderId opsiyoneldir. |
| POS onizleme eksigi | Order create response sadece `orderId`, `total`, `paymentSummary`, `existing` doner. "Bu sepette kazanilacak puan", "uygulanacak kampanya", "kullanilabilir oduller" icin preview endpoint/DTO yok. |

## 7. Vardiya / gun sonu

| Baslik | Sonuc |
|---|---|
| Legacy arama | `Shift`, `Vardiya`, `ZReport`, `EndOfDay`, `CashRegister`, `Kasa`, `OpenCash`, `CloseCash` icin controller/entity/repository izi bulunmadi. |
| Mevcut backend | Vardiya, kasa acma-kapama, X/Z raporu domain modeli veya endpoint'i yok. |
| Mevcut rapor alternatifi | Legacy `OrderRepository.GetAllSales`, `GetSalesByUser`, order list filtreleriyle satis ozeti uretiyor; bu Z raporu degil, raporlama sorgusu. |
| Frontend notu | POS tasariminda vardiya/gun sonu ekranlari isteniyorsa backend modulu yeni gereksinimdir. |

## 8. Kategori / urun gosterimi

| Baslik | Durum |
|---|---|
| Legacy POS urun listesi | `app/posProduct/list` `companyId`, `posId`, `productId`, `searchString` ile `PosProduct` listeler; her urune `Visible=true` ProductSubProduct listesi ekler. |
| Legacy genel urun listesi | `app/product/list` `companyId`, `categoryId`, `storeId`, `stroreProduct`, `posProduct`, `stocktaking`, `favoriteProduct`, `active`, `productUnitType`, `taxType`, `barcode`, `main`, `description`, `searchString` filtrelerini destekler; store stock ekler. |
| Yeni backend app listesi | `GET /api/v1/app/products?companyId=` sadece generic product list doner; POS'a gore `PosProduct` override fiyat/availability ve stok bilgisi donmez. |
| Kategori gorseli | Category `CategoryColorId`, `CategoryShapeId`, `BePrinted`, `SortOrder` modelde var; mevcut `CategoryDto` sadece `id`, `companyId`, `name`, `sortOrder`, `active` doner. |
| Alt urun | Domain `ProductSubProduct` var; create order DTO alt urun almaz, app product DTO alt urun listesi donmez. |

## 9. POS create DTO / endpoint yeterlilik

| Alan / davranis | Mevcut durum | POS tasarim riski |
|---|---|---|
| Coklu odeme | Yeterli: `payments[]` var, summary turetiliyor. | Wallet/puan odemesi payment type degil; UI bunu ayri davranis olarak ele almali. |
| Idempotency | Yeterli: header/body destekli, zorunlu validation. | Offline outbox icin her lokal satis kalici key uretmeli. |
| Offline order | Eksik: `offlineOrder` DTO'da yok. | Offline satis senkronunda stok yetersizse create reddedilebilir. |
| Manuel indirim | Eksik: `orderDiscounts`, `discountUsageLog`, kupon kodu yok. | POS indirim butonu tasarlanirsa backend kaydedemez/limit dusmez. |
| Alt urun / combo | Eksik: `OrderSubProduct` DTO'da yok. | Visible alt urun secimi tasarlanirsa order'a yazilamaz. |
| POS fiyat/stok listesi | Eksik: POS'a ozel product endpoint yok; `PosProduct` fiyat override ve stock donmez. | Satis ekrani fiyati/stogu dogru gostermeyebilir. |
| Musteri QR/kart | Eksik: `CustomerCardToken` endpoint yok. | QR okutma/kartla tanima UI'i backend'e baglanamaz. |
| Loyalty preview | Eksik: kazanilacak puan/kampanya/odul preview endpoint yok. | POS sepetinde anlik sadakat etkisi hesaplatilamaz. |
| Vardiya/Z raporu | Yok. | Kasa ac/kapat ve gun sonu ekranlari backend destegi bekler. |

## Kisa karar notu

| Konu | Sonuc |
|---|---|
| POS satis cekirdegi | Basit online satis + coklu odeme + idempotency + stok/wallet/loyalty ledger calisir. |
| Tasarim icin kritik eksikler | Offline bayragi, manuel indirim/kupon, alt urun, POS fiyat/stok listesi, musteri QR/kart endpointleri, loyalty preview, vardiya/Z raporu. |
| Vardiya/gun sonu | Backend ve legacy referansta gercek vardiya/Z raporu modulu bulunmadi. |
