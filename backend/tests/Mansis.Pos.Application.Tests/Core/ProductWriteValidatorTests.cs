using Mansis.Pos.Application.Core;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Core;

public sealed class ProductWriteValidatorTests
{
    private readonly ProductWriteValidator validator = new();

    [Fact]
    public void Validate_accepts_full_product_model_with_zero_tax()
    {
        var request = ValidRequest() with
        {
            TaxType = TaxType.Sifir,
            PurchasePrice = 10.5m,
            SalePrice = 15m,
            Image = "products/book.png",
            StoreProduct = true,
            PosProduct = true,
            EntryProduct = false,
            FavoriteProduct = true,
            SortOrder = 7,
            Description = "Book",
            Main = true,
            ParentId = Guid.NewGuid()
        };

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_rejects_missing_required_product_fields()
    {
        var request = ValidRequest() with
        {
            Name = string.Empty,
            CategoryId = Guid.Empty
        };

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(ProductWriteDto.Name));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(ProductWriteDto.CategoryId));
    }

    private static ProductWriteDto ValidRequest() => new(
        CompanyId: Guid.NewGuid(),
        UserId: Guid.NewGuid(),
        Name: "Product",
        CategoryId: Guid.NewGuid(),
        PurchasePrice: null,
        SalePrice: null,
        Barcode: null,
        StockCode: null,
        ProductUnitType: ProductUnitType.Adet,
        TaxType: TaxType.Bir,
        Stocktaking: false,
        Image: null,
        StoreProduct: false,
        PosProduct: true,
        EntryProduct: false,
        FavoriteProduct: false,
        SortOrder: 0,
        Description: null,
        Main: true,
        ParentId: null);
}
