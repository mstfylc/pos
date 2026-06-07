using Mansis.Pos.Application.Auth;
using Mansis.Pos.Domain.Entities;
using Mansis.Pos.Domain.Enumerations;
using Mansis.Pos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mansis.Pos.Infrastructure.Auth;

internal sealed class EfAuthStore(PosDbContext dbContext) : IAuthStore
{
    public async Task<AuthUserSnapshot?> FindUserAsync(Guid companyId, string username, CancellationToken cancellationToken)
    {
        return await dbContext.Users
            .AsNoTracking()
            .Where(user => user.CompanyId == companyId && user.Username == username)
            .Select(user => new AuthUserSnapshot(user.Id, user.CompanyId, user.Username, user.PasswordHash, user.PasswordSalt, user.Active))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<AuthUserSnapshot?> FindUserByRefreshTokenAsync(Guid companyId, string refreshTokenHash, CancellationToken cancellationToken)
    {
        var now = DateTimeOffset.UtcNow;
        return await dbContext.RefreshTokens
            .AsNoTracking()
            .Where(token =>
                token.CompanyId == companyId
                && token.TokenHash == refreshTokenHash
                && token.State == TokenState.Active
                && token.ExpiresAt > now)
            .Join(
                dbContext.Users.AsNoTracking(),
                token => token.UserId,
                user => user.Id,
                (token, user) => new AuthUserSnapshot(user.Id, user.CompanyId, user.Username, user.PasswordHash, user.PasswordSalt, user.Active))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task SaveRefreshRotationAsync(
        Guid companyId,
        Guid userId,
        string oldRefreshTokenHash,
        string newRefreshTokenHash,
        DateTimeOffset expiresAt,
        CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var now = DateTimeOffset.UtcNow;

        if (!string.IsNullOrWhiteSpace(oldRefreshTokenHash))
        {
            var oldToken = await dbContext.RefreshTokens.FirstOrDefaultAsync(
                token =>
                    token.CompanyId == companyId
                    && token.UserId == userId
                    && token.TokenHash == oldRefreshTokenHash
                    && token.State == TokenState.Active,
                cancellationToken);

            if (oldToken is not null)
            {
                oldToken.State = TokenState.Used;
                oldToken.RevokedAt = now;
            }
        }

        dbContext.RefreshTokens.Add(new RefreshToken
        {
            Id = Guid.NewGuid(),
            CompanyId = companyId,
            UserId = userId,
            TokenHash = newRefreshTokenHash,
            CreatedAt = now,
            ExpiresAt = expiresAt,
            State = TokenState.Active
        });

        await dbContext.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }
}
