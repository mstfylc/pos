using Mansis.Pos.Application.Loyalty.RedeemReward;
using Mansis.Pos.Domain.Enumerations;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[Route("api/v1/app/loyalty")]
[Tags("App")]
public sealed class AppLoyaltyController(RedeemRewardService redeemRewardService) : ControllerBase
{
    [HttpPost("rewards/{rewardId:guid}/redeem")]
    [ProducesResponseType(typeof(RedeemRewardResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RedeemRewardResponse>> RedeemRewardAsync(
        Guid rewardId,
        [FromBody] RedeemRewardApiRequest request,
        CancellationToken cancellationToken)
    {
        var result = await redeemRewardService.RedeemAsync(
            new RedeemRewardRequest(request.CompanyId, request.CustomerId, rewardId, request.OrderId),
            cancellationToken);

        if (!result.IsSuccess || result.Value is null)
        {
            return BadRequest(new ProblemDetails { Status = StatusCodes.Status400BadRequest, Detail = result.Error });
        }

        return Ok(RedeemRewardResponse.From(result.Value));
    }
}

public sealed record RedeemRewardApiRequest(Guid CompanyId, Guid CustomerId, Guid? OrderId);

public sealed record RedeemRewardResponse(
    Guid RedemptionId,
    string RedemptionCode,
    Guid LoyaltyTransactionId,
    int Points,
    int PointBalance,
    RewardRedemptionState State)
{
    public static RedeemRewardResponse From(RedeemRewardResult result)
    {
        return new RedeemRewardResponse(
            result.RedemptionId,
            result.RedemptionCode,
            result.LoyaltyTransactionId,
            result.Points,
            result.PointBalance,
            result.State);
    }
}
