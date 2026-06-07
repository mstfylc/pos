# MODULE INVENTORY

Tarih: 2026-06-07

Kapsam: Kod yazmadan denetim. Kaynaklar: Domain entity dosyalari, Application DTO/use-case dosyalari, Infrastructure EF repositoryleri, `contracts/openapi.yaml`.

## Ozet: DTO eksigi riski

| Modul | DTO durumu | Form yapilirsa backend kaydedemez riski |
| --- | --- | --- |
| Order | Create/cancel var, list cok dar | Orta: order create `Description`, `AddressId`, `OrderNumber`, `IsClosed`, `OfflineOrder`, `OrderDiscount`, `OrderSubProduct` almaz. |
| Customer | CRUD var, cok dar | Yuksek: `Photo`, `Registered`, `MustChangePassword`, adresler, wallet/loyalty/tier yazma DTO'su yok. |
| Loyalty | Sadece read account + redeem reward var | Yuksek: EarnRule/Tier/Reward/Campaign admin CRUD DTO'su yok. |
| Stock | Sadece movement list var | Yuksek: StoreProduct stok giris/sayim/imha/transfer create-update DTO'su yok. |
| Discount/Campaign | Discount CRUD var, Campaign CRUD yok | Orta/Yuksek: Discount scope join DTO'lari yok; Campaign priority/rule/max_total_discount formu kaydedemez. |
| Purchase | DTO/endpoint yok | Yuksek: Purchase ve PurchaseProduct formu kaydedemez. |
| User/Role | Auth login/refresh/otp var, user/role CRUD yok | Yuksek: User/Role/Permission/assignment formu kaydedemez. |

## Order

### Entity alanlari

| Entity | Alanlar |
| --- | --- |
| Order | `Id` sistem; `SubTotal decimal` zorunlu; `TaxTotal decimal` zorunlu; `TotalDiscount decimal?`; `Total decimal`; `PaymentSummary enum`; `ShippingType enum`; `OrderState enum`; `OrderTime DateTimeOffset`; `OrderNumber int`; `IsClosed bool`; `OfflineOrder bool`; `IdempotencyKey string`; `UpdateReason string?`; `Description string?`; `AddressId Guid?`; `CustomerId Guid?`; `PosId Guid`; `UserId Guid`; `CompanyId Guid`; audit alanlari. |
| OrderPayment | `Id`; `OrderId Guid`; `CompanyId Guid`; `PaymentType enum`; `Amount decimal`; `Currency string`; `State enum`; `ExternalReference string?`; `ReversalOfId Guid?`; `Reason string?`; `PaidAt DateTimeOffset`. Append-only. |
| OrderProduct | `Id`; `Quantity int`; `Total decimal?`; `ProductId Guid`; `OrderId Guid`. |
| OrderSubProduct | `Id`; `Name string?`; `ProductId Guid`; `OrderProductId Guid`; `OrderId Guid`. |
| OrderDiscount | `Id`; `Amount decimal?`; `UserId Guid`; `DiscountId Guid`; `OrderId Guid`. |

### Enum'lar

| Enum | Degerler |
| --- | --- |
| OrderState | `Received`, `Preparing`, `Completed`, `Cancelled`, `Deleted`, `Transferring` |
| ShippingType | `Self`, `ComeTake`, `Order`, `Customer` |
| PaymentType | `Cash`, `CreditCard`, `Ticket`, `Sodexo`, `Multinet` |
| PaymentSummary | `Cash`, `CreditCard`, `Ticket`, `Sodexo`, `Multinet`, `Mixed` |
| OrderPaymentState | `Pending`, `Captured`, `Cancelled`, `Refunded` |

### DTO eksikleri

| DTO | Modelde var, DTO'da yok |
| --- | --- |
| CreateOrderRequest | `Description`, `AddressId`, `OrderNumber`, `IsClosed`, `OfflineOrder`, `UpdateReason`, manuel `OrderState`, explicit `SubTotal/TaxTotal/TotalDiscount/Total`, `OrderDiscounts`, `OrderSubProducts`. |
| OrderListDto | `SubTotal`, `TaxTotal`, `TotalDiscount`, `ShippingType`, `OrderNumber`, `IsClosed`, `OfflineOrder`, `IdempotencyKey`, `UpdateReason`, `Description`, `AddressId`, satirlar, odemeler, indirimler. |
| CancelOrderRequest | Sadece `Reason` alir; partial refund/line-based refund DTO'su yok. |

### Kritik is kurallari

| Kural | Not |
| --- | --- |
| Idempotency | `IdempotencyKey` zorunlu, tekrar gelirse mevcut sonuc doner. |
| Odeme toplami | `Payments.Amount` toplami siparis toplamina esit olmali. |
| Stok | `Product.Stocktaking=true` ise yetersiz stokta hata; stok hareketi ve StoreProduct azaltilir. |
| Wallet | Customer varsa wallet bakiyesi siparis toplamindan dusulur; yetersizse hata. |
| Loyalty | Puan kazanma ve kampanya puani transaction ile yazilir. |
| Cancel/refund | Silme yok; payment/stock/wallet/loyalty/reward reversal satirlari eklenir. `Reason` zorunlu. |

### Frontend notu

| Not |
| --- |
| POS siparis formu mevcut DTO ile satis akisini destekler; adresli teslimat, aciklama, manuel indirim ve combo/alt urun UI'i icin backend DTO eksik. |

## Customer

### Entity alanlari

| Entity | Alanlar |
| --- | --- |
| Customer | `Id`; `Name string`; `Surname string`; `Username string`; `Phone string?`; `Mail string?`; `PasswordHash byte[]`; `PasswordSalt byte[]`; `MustChangePassword bool`; `Balance decimal`; `Photo string?`; `Registered bool`; `CompanyId Guid`; `RoleId Guid`; audit alanlari. |
| Address | `Id`; `AddressType enum`; `AddressHeader string?`; `CityId Guid`; `TownId Guid`; `District string?`; `MobilePhone string?`; `BusinessPhone string?`; `Description string?`; `CompanyId Guid`; audit alanlari. |
| CustomerAddress | `Id`; `CustomerId Guid`; `AddressId Guid`. |
| WalletAccount | `Id`; `CompanyId Guid`; `CustomerId Guid`; `Currency string`; `Balance decimal`. |
| WalletTransaction | `Id`; `CompanyId Guid`; `WalletAccountId Guid`; `OrderId Guid?`; `Direction enum`; `Amount decimal`; `State enum`; `ReversalOfId Guid?`; `Description string?`; `OccurredAt DateTimeOffset`. Append-only. |
| LoyaltyAccount | `Id`; `CompanyId Guid`; `CustomerId Guid`; `LoyaltyTierId Guid?`; `PointBalance int`; `LifetimePoints int`. |

### Enum'lar

| Enum | Degerler |
| --- | --- |
| AddressType | `Home`, `Office`, `Dorm` |
| LedgerDirection | `Debit`, `Credit` |
| LedgerEntryState | `Posted`, `Reversed` |
| BalanceMovementType | `Order`, `BalanceLoading`, `CanceledOrder` |

### DTO eksikleri

| DTO | Modelde var, DTO'da yok |
| --- | --- |
| CustomerWriteDto | `Password/MustChangePassword`, `Balance`, `Photo`, `Registered`, adres listesi, wallet currency/balance, loyalty tier/puan alanlari. |
| CustomerDto | `RoleId`, `Photo`, `Registered`, `MustChangePassword`, adresler, wallet id/currency, loyalty `PointBalance/LifetimePoints/Tier`. |
| Wallet/Loyalty endpoints | Wallet read ve loyalty read var; customer formundan bakiye yukleme/puan/tier guncelleme DTO'su yok. |

### Kritik is kurallari

| Kural | Not |
| --- | --- |
| Auth | Canli auth Argon2id; customer OTP iskeleti var. |
| Wallet | Sipariste wallet bakiyesi dusulur; iptalde reversal ile geri alinir. |
| Loyalty | Iptalde point ve lifetime_points azalir ama tier downgrade yok. |
| Tenant | Customer list/create/update `CompanyId` ile scope'lu. |

### Frontend notu

| Not |
| --- |
| Musteri profil formu temel kimlik alanlarini kaydedebilir; adres, fotograf, kayit durumu, bakiye yukleme ve sadakat tier/puan yonetimi icin ayrica backend DTO gerekir. |

## Loyalty

### Entity alanlari

| Entity | Alanlar |
| --- | --- |
| LoyaltyTier | `Id`; `CompanyId Guid`; `Name string`; `MinimumPoints int`; `EarnMultiplier decimal`; `Active bool`. |
| EarnRule | `Id`; `CompanyId Guid`; `Name string`; `AmountPerPoint decimal`; `MinimumOrderTotal decimal`; `Scope enum`; `BranchId Guid?`; `CategoryId Guid?`; `ExpiryDays int?`; `StartsAt DateTimeOffset?`; `EndsAt DateTimeOffset?`; `Active bool`. |
| Reward | `Id`; `CompanyId Guid`; `Name string`; `RequiredPoints int`; `RewardType enum`; `DiscountAmount decimal?`; `ProductId Guid?`; `Active bool`. |
| RewardRedemption | `Id`; `CompanyId Guid`; `CustomerId Guid`; `RewardId Guid`; `Points int`; `State enum`; `RedemptionCode string`; `OrderId Guid?`; `ReversalOfId Guid?`; `RequestedAt DateTimeOffset`. Append-only. |
| Campaign | `Id`; `CompanyId Guid`; `Name string`; `Description string?`; `CampaignType enum`; `RuleJson string`; `Priority int`; `MaxTotalDiscount decimal?`; `TargetTierId Guid?`; `StartsAt DateTimeOffset?`; `EndsAt DateTimeOffset?`; `Active bool`. |
| LoyaltyPointTransaction | `Id`; `CompanyId Guid`; `LoyaltyAccountId Guid`; `OrderId Guid?`; `TransactionType enum`; `Points int`; `State enum`; `ReversalOfId Guid?`; `Description string?`; `ExpiresAt DateTimeOffset?`; `OccurredAt DateTimeOffset`. Append-only. |

### Enum'lar

| Enum | Degerler |
| --- | --- |
| EarnRuleScope | `All`, `Branch`, `Category` |
| RewardType | `DiscountAmount`, `FreeProduct`, `Custom` |
| RewardRedemptionState | `Requested`, `Approved`, `Cancelled`, `Completed` |
| CampaignType | `ExtraPoints`, `DiscountAmount`, `Stamp` |
| LoyaltyPointTransactionType | `Earn`, `Redeem`, `Expire`, `Adjust`, `Reverse` |

### DTO eksikleri

| DTO | Modelde var, DTO'da yok |
| --- | --- |
| LoyaltyAccount read | Sadece account read; tier detay formu/listesi yok. |
| EarnRule | Create/update/list DTO ve endpoint yok. |
| LoyaltyTier | Create/update/list DTO ve endpoint yok. |
| Reward | Redeem DTO var; reward create/update/list DTO yok. |
| Campaign | Create/update/list DTO yok; `RuleJson`, `Priority`, `MaxTotalDiscount`, `TargetTierId`, tarihler kaydedilemez. |
| LoyaltyPointTransaction | Manuel adjust/expire formu DTO'su yok. |

### Kritik is kurallari

| Kural | Not |
| --- | --- |
| Earn rule secimi | Eligible kurallar icinden `MinimumOrderTotal` en yuksek olan secilir. |
| Tier | Kazanimda lifetime points ile en yuksek uygun active tier atanir; iptalde downgrade yok. |
| Campaign conflict | Ayni `CampaignType` icinde priority en yuksek tek kampanya; farkli tipler birlikte uygulanir. |
| Discount cap | Campaign discount toplami `MaxTotalDiscount` ve order total ile sinirlanir. |
| Reward redeem | Aktif reward ve yeterli puan zorunlu; puan dusumu transaction ile yapilir. |

### Frontend notu

| Not |
| --- |
| Sadakat admin ekranlari icin backend yazma yuzeyi henuz yok; UI sadece read/redeem ile sinirlanmali veya backend DTO istenmeli. |

## Stock

### Entity alanlari

| Entity | Alanlar |
| --- | --- |
| StoreProduct | `Id`; `Quantity int`; `QuantityAfterStockCount int?`; `StockDiff int?`; `Threshold int`; `StoreId Guid`; `ProductId Guid`. |
| StoreProductMovement | `Id`; `MovementType enum`; `Quantity int`; `OperationId Guid`; `OperationTime DateTimeOffset`; `Description string?`; `StoreId Guid`; `ProductId Guid`. |
| StockMovement | `Id`; `CompanyId Guid`; `StoreId Guid`; `ProductId Guid`; `OperationId Guid?`; `MovementType enum`; `Direction enum`; `Quantity int`; `State enum`; `ReversalOfId Guid?`; `Description string?`; `OccurredAt DateTimeOffset`. Append-only. |
| StoreProductTransfer | `Id`; `TransferState enum`; `SourceStoreId Guid`; `TargetStoreId Guid`; `RequestedById Guid`; `RequestedTime DateTimeOffset`; `ConfirmedById Guid?`; `ConfirmedTime DateTimeOffset?`; `ReceivedById Guid?`; `ReceivedTime DateTimeOffset?`; `TransferDone bool?`; `CompanyId Guid`; `Details list`. |
| StoreProductTransferDetail | `Id`; `StoreProductTransferId Guid`; `Quantity int`; `ReceivedQuantity int?`; `Unit enum?`; `UnitPrice decimal?`; `ProductId Guid`. |

### Enum'lar

| Enum | Degerler |
| --- | --- |
| StoreProductMovementType | `StockIn`, `StockOut`, `Destroy`, `Order`, `Purchase`, `TransferIn`, `TransferOut` |
| ProductTransferState | `Requested`, `Confirmed`, `Received` |
| ProductUnitType | `Adet`, `MiliLitre`, `Gram` |
| LedgerDirection | `Debit`, `Credit` |
| LedgerEntryState | `Posted`, `Reversed` |

### DTO eksikleri

| DTO | Modelde var, DTO'da yok |
| --- | --- |
| StockMovement | Sadece list schema/endpoint var; stock-in/out/destroy/count/transfer create DTO yok. |
| StoreProduct | Quantity/Threshold/StockDiff/QuantityAfterStockCount yazma DTO'su yok. |
| Transfer | Transfer header/detail create/confirm/receive DTO yok. |
| Sayim/imha | `QuantityAfterStockCount`, `StockDiff`, reason/description ile sayim/imha DTO'su yok. |

### Kritik is kurallari

| Kural | Not |
| --- | --- |
| Order stock | `Stocktaking=true` urunlerde StoreProduct quantity dusulur; yetersiz stok hata. |
| Reversal | Iptalde StockMovement ters kayit eklenir ve StoreProduct geri artar. |
| Append-only | Yeni `StockMovement` append-only; hard delete yok. |
| Transfer/sayim | Entity var, application use-case/DTO bu denetimde gorulmedi. |

### Frontend notu

| Not |
| --- |
| Stok listesi okunabilir; stok giris, cikis, imha, sayim ve transfer ekranlari icin backend yazma endpointleri eklenmeden form kaydedemez. |

## Discount / Campaign

### Entity alanlari

| Entity | Alanlar |
| --- | --- |
| Discount | `Id`; `Description string?`; `Amount decimal`; `MaxDiscountAmount decimal`; `ExpireDate DateTimeOffset?`; `DiscountType enum`; `DiscountCategory enum`; `SortOrder int`; `CompanyId Guid`; audit alanlari. |
| DiscountBranch | `Id`; `DiscountId Guid`; `BranchId Guid`. |
| DiscountPos | `Id`; `DiscountId Guid`; `PosId Guid`. |
| DiscountUser | `Id`; `DiscountId Guid`; `UserId Guid`. |
| DiscountUsageLog | `Id`; `Amount decimal`; `OrderTime DateTimeOffset`; `CompanyId Guid`; `OrderId Guid`; `DiscountId Guid`; `UserId Guid`. |
| Campaign | `Id`; `CompanyId Guid`; `Name string`; `Description string?`; `CampaignType enum`; `RuleJson string`; `Priority int`; `MaxTotalDiscount decimal?`; `TargetTierId Guid?`; `StartsAt DateTimeOffset?`; `EndsAt DateTimeOffset?`; `Active bool`. |

### Enum'lar

| Enum | Degerler |
| --- | --- |
| DiscountType | `Percentage`, `Amount` |
| DiscountCategory | `All`, `Branch`, `Personnel`, `Pos` |
| CampaignType | `ExtraPoints`, `DiscountAmount`, `Stamp` |

### DTO eksikleri

| DTO | Modelde var, DTO'da yok |
| --- | --- |
| DiscountWriteDto | Scope join listeleri yok: `DiscountBranch`, `DiscountPos`, `DiscountUser`; usage log manuel yazma yok. |
| DiscountDto | `SortOrder` read DTO'da yok. |
| Campaign | Tum campaign CRUD DTO/endpoint yok: `Name`, `RuleJson`, `Priority`, `MaxTotalDiscount`, tier/tarih/active kaydedilemez. |

### Kritik is kurallari

| Kural | Not |
| --- | --- |
| Discount legacy limit | Order discount kullanimi `MaxDiscountAmount` ile sinirlanmali; mevcut generic Discount CRUD sadece tanim yazar. |
| Campaign priority | Ayni tip kampanyalarda priority en yuksek tek kampanya uygulanir. |
| Campaign type combine | Farkli campaign type'lari birlikte uygulanir. |
| Campaign cap | Toplam kampanya indirimi `MaxTotalDiscount` ve order total uzerinden cap'lenir. |

### Frontend notu

| Not |
| --- |
| Discount temel formu kaydedebilir; scope secimleri ve campaign yonetimi icin backend eksik. Campaign formu su an kaydedemez. |

## Purchase

### Entity alanlari

| Entity | Alanlar |
| --- | --- |
| Supplier | `Id`; `Name string`; `AuthorizedPerson string?`; `Address string?`; `Phone string?`; `Mail string?`; `TaxOffice string?`; `TaxNo string?`; `TaxFree bool?`; `MoneyUnitType enum?`; `Maturity int?`; `OpeningBalance decimal?`; `CompanyId Guid`; audit alanlari. |
| Purchase | `Id`; `PurchaseTime DateTimeOffset?`; `Invoice string?`; `Total decimal`; `PaymentCompleted bool`; `Received bool`; `PayerId Guid?`; `ReceiverId Guid?`; `SupplierId Guid`; `StoreId Guid`; `CompanyId Guid`; `PurchaseProducts list`. |
| PurchaseProduct | `Id`; `Quantity int`; `ProductId Guid`; `Price decimal`; `Total decimal`; `Discount int?`; `Tax int?`; `PurchaseId Guid`. |

### Enum'lar

| Enum | Degerler |
| --- | --- |
| MoneyUnitType | `TL`, `USD`, `EUR` |
| StoreProductMovementType | Purchase entegrasyonu icin `Purchase` degeri var. |

### DTO eksikleri

| DTO | Modelde var, DTO'da yok |
| --- | --- |
| Supplier | Create/update/list DTO ve endpoint yok. |
| Purchase | Header create/update/list DTO yok. |
| PurchaseProduct | Satir kalemi DTO yok. |
| Stock integration | Purchase received oldugunda stok hareketi/StoreProduct update use-case'i bu denetimde gorulmedi. |

### Kritik is kurallari

| Kural | Not |
| --- | --- |
| Alim/stok | Entity `Received`, `StoreId`, satir product/quantity ile stok giris mantigina hazir; use-case/DTO eksik. |
| Odeme | `PaymentCompleted`, `PayerId` var; ledger/payment transaction use-case gorulmedi. |

### Frontend notu

| Not |
| --- |
| Satin alma ve tedarikci formlari backend yazma yuzeyi olmadan kaydedemez; stok giris etkisi de ayrica tasarlanmali. |

## User / Role

### Entity alanlari

| Entity | Alanlar |
| --- | --- |
| User | `Id`; `FirstName string`; `LastName string`; `Username string`; `Phone string?`; `Mail string?`; `PasswordHash byte[]`; `PasswordSalt byte[]`; `MustChangePassword bool`; `Pin string?`; `CompanyId Guid`; `RoleId Guid`; `CardId Guid?`; audit alanlari. |
| Role | `Id`; `Name string`; `CompanyId Guid`; audit alanlari. |
| Permission | `Id`; `Name string`; `DisplayName string?`; `PermissionType enum`. |
| RolePermission | `Id`; `RoleId Guid`; `PermissionId Guid`; `Active bool`. |
| Card | `Id`; `Name string`; `Number string`; `CompanyId Guid`; audit alanlari. |
| CompanyOwner | `Id`; `CompanyId Guid`; `OwnerId Guid`. |
| BranchManager | `Id`; `BranchId Guid`; `ManagerId Guid`. |
| BranchUser | `Id`; `BranchId Guid`; `UserId Guid`. |
| PosUser | `Id`; `PosId Guid`; `UserId Guid`. |
| Assignment | `Id`; `UserId Guid`; `AssignmentTableType enum`; `AssignmentRecords list`. |
| AssignmentRecord | `Id`; `RecordId Guid`; `RecordName string`; `AssignmentId Guid`. |

### Enum'lar

| Enum | Degerler |
| --- | --- |
| PermissionType | `Undefined = 0` |
| AssignmentTableType | `Pos`, `Branch`, `Store` |

### DTO eksikleri

| DTO | Modelde var, DTO'da yok |
| --- | --- |
| User | User create/update/list DTO yok; auth sadece login/refresh/otp. |
| Role | Role create/update/list DTO yok. |
| Permission | Permission list/assign DTO yok. |
| RolePermission | Role-permission mapping DTO yok. |
| Assignment | Branch/POS/store user assignment DTO yok. |
| Card/PIN | Card ve PIN alanlari icin DTO yok. |

### Kritik is kurallari

| Kural | Not |
| --- | --- |
| Auth | Superadmin/personel Argon2id hash ile baslar; `MustChangePassword` destekli. |
| AllowAnonymous | Login/refresh/OTP disinda anonymous olmamali. |
| Yetki | Permission entity ve RolePermission var; aktif policy/permission katalogu henuz cok sinirli gorunuyor. |
| Tenant | User/Role company scoped. |

### Frontend notu

| Not |
| --- |
| Personel, rol ve yetki ekranlari icin backend CRUD/assignment DTO'su yok; sadece auth akisi kullanilabilir. |
