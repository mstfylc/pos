using Mansis.Pos.Application.Core;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Application.Tests.Core;

public sealed class GroupThreeCrudValidatorTests
{
    [Fact]
    public void Wallet_adjustment_requires_reason_and_positive_amount()
    {
        var validator = new CustomerWalletAdjustmentValidator();
        var request = new CustomerWalletAdjustmentRequest(
            CompanyId: Guid.NewGuid(),
            UserId: Guid.NewGuid(),
            Amount: 0m,
            Direction: LedgerDirection.Credit,
            Reason: string.Empty);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CustomerWalletAdjustmentRequest.Amount));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CustomerWalletAdjustmentRequest.Reason));
    }

    [Fact]
    public void Loyalty_adjustment_requires_reason_and_positive_points()
    {
        var validator = new CustomerLoyaltyAdjustmentValidator();
        var request = new CustomerLoyaltyAdjustmentRequest(
            CompanyId: Guid.NewGuid(),
            UserId: Guid.NewGuid(),
            Points: 0,
            Direction: LedgerDirection.Credit,
            Reason: string.Empty);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CustomerLoyaltyAdjustmentRequest.Points));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(CustomerLoyaltyAdjustmentRequest.Reason));
    }

    [Fact]
    public void Purchase_requires_supplier_store_and_lines()
    {
        var validator = new PurchaseWriteValidator();
        var request = new PurchaseWriteDto(
            CompanyId: Guid.NewGuid(),
            UserId: Guid.NewGuid(),
            PurchaseTime: DateTimeOffset.UtcNow,
            Invoice: "INV-1",
            PaymentCompleted: false,
            Received: false,
            PayerId: null,
            ReceiverId: null,
            SupplierId: Guid.Empty,
            StoreId: Guid.Empty,
            Lines: []);

        var result = validator.Validate(request);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(PurchaseWriteDto.SupplierId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(PurchaseWriteDto.StoreId));
        Assert.Contains(result.Errors, error => error.PropertyName == nameof(PurchaseWriteDto.Lines));
    }

    [Fact]
    public void Supplier_accepts_required_name()
    {
        var validator = new SupplierWriteValidator();
        var request = new SupplierWriteDto(
            CompanyId: Guid.NewGuid(),
            UserId: Guid.NewGuid(),
            Name: "Supplier",
            AuthorizedPerson: null,
            Address: null,
            Phone: null,
            Mail: null,
            TaxOffice: null,
            TaxNo: null,
            TaxFree: false,
            MoneyUnitType: MoneyUnitType.TL,
            Maturity: 0,
            OpeningBalance: 0m);

        var result = validator.Validate(request);

        Assert.True(result.IsValid);
    }
}
