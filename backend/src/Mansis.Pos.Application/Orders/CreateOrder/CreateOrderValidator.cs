using FluentValidation;

namespace Mansis.Pos.Application.Orders.CreateOrder;

public sealed class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.PosId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.OrderTime).NotEmpty();
        RuleFor(request => request.IdempotencyKey).NotEmpty().MinimumLength(8);
        RuleFor(request => request.Lines).NotEmpty();
        RuleForEach(request => request.Lines).ChildRules(line =>
        {
            line.RuleFor(x => x.ProductId).NotEmpty();
            line.RuleFor(x => x.Quantity).GreaterThan(0);
            line.RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
        });
        RuleFor(request => request.Payments).NotEmpty();
        RuleForEach(request => request.Payments).ChildRules(payment =>
        {
            payment.RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            payment.RuleFor(x => x.Currency).NotEmpty();
        });
        RuleFor(request => request.Discounts).NotNull();
        RuleForEach(request => request.Discounts).ChildRules(discount =>
        {
            discount.RuleFor(x => x.DiscountId).NotEmpty();
            discount.RuleFor(x => x.UserId).NotEmpty();
            discount.RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        });
    }
}
