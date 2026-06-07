using FluentValidation;

namespace Mansis.Pos.Application.Stock;

public sealed class StockAdjustmentValidator : AbstractValidator<StockAdjustmentRequest>
{
    public StockAdjustmentValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.StoreId).NotEmpty();
        RuleFor(request => request.ProductId).NotEmpty();
        RuleFor(request => request.Quantity).GreaterThan(0);
    }
}

public sealed class DestroyStockValidator : AbstractValidator<DestroyStockRequest>
{
    public DestroyStockValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.StoreId).NotEmpty();
        RuleFor(request => request.ProductId).NotEmpty();
        RuleFor(request => request.Quantity).GreaterThan(0);
        RuleFor(request => request.Reason).NotEmpty().MaximumLength(512);
    }
}

public sealed class StockCountValidator : AbstractValidator<StockCountRequest>
{
    public StockCountValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.StoreId).NotEmpty();
        RuleFor(request => request.ProductId).NotEmpty();
        RuleFor(request => request.CountedQuantity).GreaterThanOrEqualTo(0);
    }
}

public sealed class CreateTransferValidator : AbstractValidator<CreateTransferRequest>
{
    public CreateTransferValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.SourceStoreId).NotEmpty();
        RuleFor(request => request.TargetStoreId).NotEmpty().NotEqual(request => request.SourceStoreId);
        RuleFor(request => request.Lines).NotEmpty();
        RuleForEach(request => request.Lines).ChildRules(line =>
        {
            line.RuleFor(item => item.ProductId).NotEmpty();
            line.RuleFor(item => item.Quantity).GreaterThan(0);
            line.RuleFor(item => item.Unit).IsInEnum().When(item => item.Unit.HasValue);
            line.RuleFor(item => item.UnitPrice).GreaterThanOrEqualTo(0).When(item => item.UnitPrice.HasValue);
        });
    }
}

public sealed class ConfirmTransferValidator : AbstractValidator<ConfirmTransferRequest>
{
    public ConfirmTransferValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
    }
}

public sealed class ReceiveTransferValidator : AbstractValidator<ReceiveTransferRequest>
{
    public ReceiveTransferValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Lines).NotEmpty();
        RuleForEach(request => request.Lines).ChildRules(line =>
        {
            line.RuleFor(item => item.ProductId).NotEmpty();
            line.RuleFor(item => item.ReceivedQuantity).GreaterThanOrEqualTo(0);
        });
    }
}

public sealed class CancelTransferValidator : AbstractValidator<CancelTransferRequest>
{
    public CancelTransferValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Reason).NotEmpty().MaximumLength(512);
    }
}
