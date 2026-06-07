namespace Mansis.Pos.Application.Auth;

public interface IAuthStore
{
    Task<AuthUserSnapshot?> FindUserAsync(Guid companyId, string username, CancellationToken cancellationToken);
    Task<AuthUserSnapshot?> FindUserByRefreshTokenAsync(Guid companyId, string refreshTokenHash, CancellationToken cancellationToken);
    Task SaveRefreshRotationAsync(Guid companyId, Guid userId, string oldRefreshTokenHash, string newRefreshTokenHash, DateTimeOffset expiresAt, CancellationToken cancellationToken);
}

public interface IAuthTokenIssuer
{
    AuthTokenPair Issue(Guid companyId, Guid userId, string username);
}

public interface IPasswordVerifier
{
    bool Verify(string password, byte[] passwordHash, byte[] passwordSalt);
}

public sealed record AuthTokenPair(string AccessToken, string RefreshToken, string RefreshTokenHash, DateTimeOffset ExpiresAt);
