using Mansis.Pos.Application.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/v1/auth")]
[Tags("Auth")]
public sealed class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthTokenResult>> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.LoginAsync(request, cancellationToken);
        return result.IsSuccess && result.Value is not null
            ? Ok(result.Value)
            : Unauthorized(new ProblemDetails { Status = StatusCodes.Status401Unauthorized, Detail = result.Error });
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<AuthTokenResult>> RefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.RefreshAsync(request, cancellationToken);
        return result.IsSuccess && result.Value is not null
            ? Ok(result.Value)
            : Unauthorized(new ProblemDetails { Status = StatusCodes.Status401Unauthorized, Detail = result.Error });
    }

    [HttpPost("otp/request")]
    public async Task<ActionResult<OtpResult>> RequestOtpAsync([FromBody] OtpRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.RequestOtpAsync(request, cancellationToken);
        return Ok(result.Value);
    }

    [HttpPost("otp/verify")]
    public async Task<ActionResult<OtpResult>> VerifyOtpAsync([FromBody] OtpVerifyRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.VerifyOtpAsync(request, cancellationToken);
        return Ok(result.Value);
    }
}
