using Mansis.Pos.Application.Core;

namespace Mansis.Pos.Application.Tests.Core;

public sealed class PosProductWriteValidatorTests
{
    private readonly PosProductWriteValidator validator = new();

    [Fact]
    public void Validate_accepts_required_pos_product_fields()
    {
        var request = new PosProductWriteDto(
            CompanyId: Guid.NewGuid(),
            UserId: Guid.NewGuid(),
            PosId: Guid.NewGuid(),
            ProductId: Guid.NewGuid(),
            PurchasePrice: 8m,
            SalePrice: 12m);

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_rejects_empty_scope_fields()
    {
        var request = new PosProductWriteDto(
            CompanyId: Guid.Empty,
            UserId: Guid.Empty,
            PosId: Guid.Empty,
            ProductId: Guid.Empty,
            PurchasePrice: null,
            SalePrice: null);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(PosProductWriteDto.CompanyId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(PosProductWriteDto.UserId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(PosProductWriteDto.PosId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(PosProductWriteDto.ProductId));
    }
}
