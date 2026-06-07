using Mansis.Pos.Application.Common;
using System.Security.Cryptography;
using System.Text;

namespace Mansis.Pos.Application.Auth;

public sealed class AuthService(
    IAuthStore store,
    IAuthTokenIssuer tokenIssuer,
    IPasswordVerifier passwordVerifier)
{
    public async Task<Result<AuthTokenResult>> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await store.FindUserAsync(request.CompanyId, request.Username, cancellationToken);
        if (user is null || !user.Active || !passwordVerifier.Verify(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return Result<AuthTokenResult>.Failure("Invalid credentials.");
        }

        var tokenPair = tokenIssuer.Issue(user.CompanyId, user.Id, user.Username);
        await store.SaveRefreshRotationAsync(user.CompanyId, user.Id, string.Empty, tokenPair.RefreshTokenHash, tokenPair.ExpiresAt, cancellationToken);
        return Result<AuthTokenResult>.Success(new AuthTokenResult(user.Id, user.CompanyId, tokenPair.AccessToken, tokenPair.RefreshToken, tokenPair.ExpiresAt));
    }

    public async Task<Result<AuthTokenResult>> RefreshAsync(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var oldHash = HashRefreshToken(request.RefreshToken);
        var user = await store.FindUserByRefreshTokenAsync(request.CompanyId, oldHash, cancellationToken);
        if (user is null || !user.Active)
        {
            return Result<AuthTokenResult>.Failure("Invalid refresh token.");
        }

        var tokenPair = tokenIssuer.Issue(user.CompanyId, user.Id, user.Username);
        await store.SaveRefreshRotationAsync(user.CompanyId, user.Id, oldHash, tokenPair.RefreshTokenHash, tokenPair.ExpiresAt, cancellationToken);
        return Result<AuthTokenResult>.Success(new AuthTokenResult(user.Id, user.CompanyId, tokenPair.AccessToken, tokenPair.RefreshToken, tokenPair.ExpiresAt));
    }

    public Task<Result<OtpResult>> RequestOtpAsync(OtpRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<OtpResult>.Success(new OtpResult("OtpRequested")));
    }

    public Task<Result<OtpResult>> VerifyOtpAsync(OtpVerifyRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result<OtpResult>.Success(new OtpResult("OtpVerificationPending")));
    }

    public static string HashRefreshToken(string refreshToken)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken));
        return Convert.ToHexString(bytes);
    }
}
