using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Mansis.Pos.Application.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Mansis.Pos.Api.Auth;

internal sealed class JwtAuthTokenIssuer(IConfiguration configuration) : IAuthTokenIssuer
{
    public AuthTokenPair Issue(Guid companyId, Guid userId, string username)
    {
        var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET")
            ?? throw new InvalidOperationException("JWT_SECRET environment variable is required.");
        var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        var expiresAt = DateTimeOffset.UtcNow.AddDays(30);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim("company_id", companyId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, username)
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
            SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials);

        return new AuthTokenPair(
            new JwtSecurityTokenHandler().WriteToken(token),
            refreshToken,
            AuthService.HashRefreshToken(refreshToken),
            expiresAt);
    }
}
