using FluentValidation;

namespace Mansis.Pos.Application.Orders.CancelOrder;

public sealed class CancelOrderValidator : AbstractValidator<CancelOrderRequest>
{
    public CancelOrderValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.OrderId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Reason)
            .NotEmpty()
            .WithMessage("Reason is required.")
            .MaximumLength(512);
    }
}
