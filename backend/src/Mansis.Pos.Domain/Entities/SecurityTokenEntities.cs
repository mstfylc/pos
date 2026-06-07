using Mansis.Pos.Domain.Common;
using Mansis.Pos.Domain.Enumerations;

namespace Mansis.Pos.Domain.Entities;

public sealed class RefreshToken : Entity, ICompanyScoped, IAppendOnly
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public string TokenHash { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public TokenState State { get; set; }
    public DateTimeOffset? RevokedAt { get; set; }
    public User? User { get; set; }
}

public sealed class PasswordResetToken : Entity, ICompanyScoped, IAppendOnly
{
    public Guid CompanyId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CustomerId { get; set; }
    public string TokenHash { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public TokenState State { get; set; }
    public User? User { get; set; }
    public Customer? Customer { get; set; }
}
