namespace Mansis.Pos.Application.Auth;

public sealed record LoginRequest(Guid CompanyId, string Username, string Password);
public sealed record RefreshTokenRequest(Guid CompanyId, string RefreshToken);
public sealed record AuthTokenResult(Guid UserId, Guid CompanyId, string AccessToken, string RefreshToken, DateTimeOffset ExpiresAt);
public sealed record OtpRequest(Guid CompanyId, string Phone);
public sealed record OtpVerifyRequest(Guid CompanyId, string Phone, string Code);
public sealed record OtpResult(string State);

public sealed record AuthUserSnapshot(Guid Id, Guid CompanyId, string Username, byte[] PasswordHash, byte[] PasswordSalt, bool Active);
