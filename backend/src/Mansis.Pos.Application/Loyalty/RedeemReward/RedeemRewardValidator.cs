using FluentValidation;

namespace Mansis.Pos.Application.Loyalty.RedeemReward;

public sealed class RedeemRewardValidator : AbstractValidator<RedeemRewardRequest>
{
    public RedeemRewardValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.CustomerId).NotEmpty();
        RuleFor(request => request.RewardId).NotEmpty();
    }
}
