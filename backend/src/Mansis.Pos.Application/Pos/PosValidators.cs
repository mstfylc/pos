using FluentValidation;

namespace Mansis.Pos.Application.Pos;

public sealed class IssueCustomerCardTokenValidator : AbstractValidator<IssueCustomerCardTokenRequest>
{
    public IssueCustomerCardTokenValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.CustomerId).NotEmpty();
        RuleFor(request => request.ExpiresInSeconds).InclusiveBetween(30, 3600);
    }
}

public sealed class IdentifyCustomerValidator : AbstractValidator<IdentifyCustomerRequest>
{
    public IdentifyCustomerValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request)
            .Must(request => !string.IsNullOrWhiteSpace(request.Token) || !string.IsNullOrWhiteSpace(request.CardNumber))
            .WithMessage("Token or card number is required.");
    }
}

public sealed class LoyaltyPreviewValidator : AbstractValidator<LoyaltyPreviewRequest>
{
    public LoyaltyPreviewValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.PosId).NotEmpty();
        RuleFor(request => request.CustomerId).NotEmpty();
        RuleFor(request => request.Lines).NotEmpty();
        RuleForEach(request => request.Lines).ChildRules(line =>
        {
            line.RuleFor(item => item.ProductId).NotEmpty();
            line.RuleFor(item => item.Quantity).GreaterThan(0);
            line.RuleFor(item => item.UnitPrice).GreaterThanOrEqualTo(0);
            line.RuleFor(item => item.TaxAmount).GreaterThanOrEqualTo(0);
        });
    }
}
