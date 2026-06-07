# PRODUCT MODEL ENVANTERI

Tarih: 2026-06-07

## Kaynaklar

| Kaynak | Dosya / Not |
| --- | --- |
| Mevcut backend | `backend/src/Mansis.Pos.Domain/Entities/CatalogEntities.cs`, `StockEntities.cs`, `LegacyEnums.cs` |
| Mevcut CRUD | `backend/src/Mansis.Pos.Application/Core/CoreCrudModels.cs`, `EfCoreCrudStore.cs` |
| Legacy referans | `Mansis.Pos.WS.Entities/Models/Product*.cs`, `StoreProduct.cs`, `PosProduct.cs`, `Category*.cs` |
| Legacy is kurali | `ProductRepository.cs`, `ProductSubProductRepository.cs`, `PosProductRepository.cs`, `StoreProductRepository.cs`, `OrderProductRepository.cs`, app controller listeleri |

## Product alanlari

| Alan | Mevcut tip | Legacy tip | Zorunlu | Aciklama / frontend notu |
| --- | --- | --- | --- | --- |
| Id | Guid | int | sistem | Primary key. |
| Name | string | string | evet | Legacy `[Required]`; company icinde isim tekil kontrolu vardi. |
| PurchasePrice | decimal? | double? | hayir | Alis fiyati; mevcut CRUD DTO'da henuz yok. |
| SalePrice | decimal? | double? | hayir | Satis fiyati; mevcut CRUD DTO'da var. |
| StockCode | string? | string | hayir | Stok kodu; mevcut index `(CompanyId, StockCode)`, unique degil. |
| Barcode | string? | string | hayir | Barkod; mevcut index `(CompanyId, Barcode)`, unique degil. |
| StoreProduct / StroreProduct | bool | bool | evet | Legacy yazim hatasi `StroreProduct`; stok/depo urunu filtresi ve app stok kontrolunde kullaniliyor. |
| PosProduct | bool | bool | evet | POS'ta satilabilir/filtrelenebilir urun bayragi. |
| Stocktaking | bool | bool | evet | Stok takibi acik mi; sipariste stok kontrolu ve stok hareketi bununla calisir. |
| EntryProduct | bool | bool | evet | Legacy `GetEntryProduct(companyId)` ile tek giris/ozel urun gibi kullaniliyor. |
| FavoriteProduct | bool | bool | evet | Legacy filtre ve app listesinde favori urun bayragi. |
| SortOrder | int | int | evet | Liste sirasi; mevcut liste `SortOrder`, sonra `Name`. |
| Description | string? | string | hayir | Legacy filtrelenebilir aciklama. |
| ProductUnitType | enum | enum | evet | Legacy `[Required]`; adet/ml/gram. |
| Image | string? | string | hayir | Gorsel yolu/icerigi; mevcut CRUD DTO'da henuz yok. |
| TaxType | enum | enum | evet | Legacy `[Required]`; yeni enum legacy ile birebir ayni degil, asagida not var. |
| Main | bool | bool | evet | Ana/top-level urun filtresi; `ParentId` ile varyant/agac baglantisi. |
| CategoryId / CategoryID | Guid | int | evet | Legacy `[Required]` ve sifirdan farkli; kategori gorsel rengi/sekli buradan gelir. |
| CompanyId / CompanyID | Guid | int | evet | Tenant scope; her urun sirket kapsaminda. |
| ParentId / ParentID | Guid? | int? | hayir | Ust/ana urune bagli varyant veya alt kayit iliskisi. |
| Parent | Product? | Product | hayir | Navigation. |
| Category | Category? | Category | hayir | Navigation. |
| Company | Company? | Company | hayir | Navigation. |
| CreatedAt | DateTimeOffset | DateTime | sistem | Audit. |
| UpdatedAt | DateTimeOffset | DateTime | sistem | Audit. |
| DeletedAt | DateTimeOffset? | DateTime? | sistem | Soft delete. |
| Active | bool | bool | sistem/form | Aktiflik; delete/deactivate false + DeletedAt. |
| CreatedById / CreatedByID | Guid | int | sistem | Audit user. |
| UpdatedById / UpdatedByID | Guid | int | sistem | Audit user. |

## ProductSubProduct iliskisi

| Alan | Mevcut tip | Legacy tip | Zorunlu | Aciklama |
| --- | --- | --- | --- | --- |
| Id | Guid | int | sistem | Primary key. |
| Name | string? | string? | hayir | Recete/opsiyon satiri gorunen adi. |
| Quantity | int | int | evet | Legacy `[Required]` ve sifirdan farkli; alt urun miktari. |
| Price | decimal? | double? | hayir | Alt urun fiyat farki/override. |
| Default | bool | bool | evet | Varsayilan secili/dahil satir. Legacy duplicate kontrolu sadece `Default=true` iken Product+SubProduct icin yapilmis. |
| Visible | bool | bool | evet | POS/app tarafinda gosterilecek satir. App POS listesi `Visible=true` olanlari ekliyor. |
| ProductId / ProductID | Guid | int | evet | Ana/ust urun. Mevcut index `(ProductId, SubProductId)` unique. |
| SubProductId / SubProductID | Guid | int | evet | Bilesen/alt urun; kendisi de Product. |
| Product / SubProduct | Product? | Product | hayir | Navigation. |

| Kural | Not |
| --- | --- |
| Ne zaman kullanilir | Recete, combo, secenek/ek urun veya urunun alt bilesenleri icin kullanilir. |
| POS gorunumu | Legacy `AppPosProductController`, POS urun listesine `Visible=true` ProductSubProduct satirlarini ekliyor. |
| Stok etkisi | Mevcut ve legacy siparis stok akisi siparis satirindaki `ProductId` uzerinden calisiyor; ProductSubProduct bilesen stok dusumu ayrica gorulmedi. |

## Iliskili tablolar

| Tablo | Alanlar | Kullanim |
| --- | --- | --- |
| PosProduct | Id, PurchasePrice?, SalePrice?, ProductId, PosId | POS bazli urun/fiyat override. Legacy ayni POS+Product tekrarini reddediyor; mevcut index `(PosId, ProductId)` unique. |
| StoreProduct | Id, Quantity, QuantityAfterStockCount?, StockDiff?, Threshold, StoreId, ProductId | Depo bazli stok. Mevcut index `(StoreId, ProductId)` unique. |
| StoreProductMovement | MovementType, Quantity, OperationId, OperationTime/OccurredAt, Description, StoreId, ProductId | Siparis/stok sayim/transfer gibi stok hareket logu. Yeni sistem append-only ledger mantiginda. |
| Category | Name, BePrinted, SortOrder, CompanyId, CategoryColorId, CategoryShapeId | Product.CategoryId zorunlu. POS gorsel grup ve yazdirma davranisi icin kategori bilgisi. |
| CategoryColor | Name, Content, CompanyId | Kategori renk sozlugu; `Content` UI renk degeri/icerigi. |
| CategoryShape | Name, Content, CompanyId | Kategori sekil/ikon sozlugu; `Content` UI sekil degeri/icerigi. |
| ProductType | Store, Pos | Product alanindan ziyade stok/transfer tipi enum'u; Product uzerinde ayri `StoreProduct` ve `PosProduct` bool'lari var. |

## Enum'lar

| Enum | Mevcut backend | Legacy |
| --- | --- | --- |
| ProductUnitType | `Adet`, `MiliLitre`, `Gram` | `Adet=0`, `MiliLitre=1`, `Gram=2` |
| TaxType | `Bir`, `Sekiz`, `OnSekiz` | `Sifir=0`, `Bir=1`, `Sekisz=2`, `OnSekiz=3` |
| ProductType | `Store`, `Pos` | `Store=0`, `Pos=1` |

## Urun olusturma / form kurallari

| Kural | Durum / Not |
| --- | --- |
| Minimum zorunlu alanlar | Legacy: `Name`, `ProductUnitType`, `TaxType`, `CategoryID`, `CompanyID`. Mevcut ProductWriteDto: `CompanyId`, `UserId`, `Name`, `CategoryId`, `ProductUnitType`, `TaxType`, `Stocktaking`; opsiyonel `SalePrice`, `Barcode`, `StockCode`. |
| Formda eksik ama modelde var | `PurchasePrice`, `StoreProduct`, `PosProduct`, `EntryProduct`, `FavoriteProduct`, `SortOrder`, `Description`, `Image`, `Main`, `ParentId`, ProductSubProduct listesi mevcut CRUD DTO'da henuz yok. |
| Stok takibi | `Stocktaking=true` ise siparis oncesi StoreProduct miktari kontrol edilir; yeterli degilse hata. Siparis olusunca stok hareketi yazilir ve StoreProduct.Quantity azalir. |
| Legacy ek stok kontrolu | Legacy app order create, `product.StroreProduct || product.Stocktaking` icin stok var/yeterli kontrolu yapiyor; legacy `OrderProductRepository` dusumu `Stocktaking` ile yapiyor. |
| StoreProduct kaydi | Stok takipli urunlerde ilgili store icin StoreProduct kaydi ve Quantity gerekir. Yoksa legacy dusum yapmiyor; yeni backend stok snapshot'ta miktar yoksa yetersiz stok gibi ele alinir. |
| POS fiyat farki | PosProduct satiri varsa POS bazli PurchasePrice/SalePrice override/availability olarak kullanilmali; base Product fiyatlari ana degerdir. |
| Ana urun / varyant | `Main=true` ana/top-level urun filtresi; `ParentId` alt/varyant baglantisi. Legacy filtre ve update destekliyor, ayrintili hesap kuralina rastlanmadi. |
| Recete / alt urun | ProductSubProduct ile ust urune bilesen/secenek eklenir. `Default` varsayilan, `Visible` app/POS'ta gosterim, `Price` fiyat farki/override, `Quantity` bilesen miktari. |
| Vergi uyumsuzlugu | Legacy `TaxType` icinde `Sifir` ve yazim hatali `Sekisz` var; mevcut backend sadece `Bir/Sekiz/OnSekiz`. Frontend enum kaynagi yeni OpenAPI olursa sifir KDV secenegi gorunmez. |
| Benzersizlik | Legacy Product name company icinde tekil kontrol ediyordu. Mevcut Product barcode/stockCode indexleri unique degil; Product name unique indexi gorulmedi. |
