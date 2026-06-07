namespace Mansis.Pos.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; set; }
}

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public bool Active { get; set; } = true;
    public Guid CreatedById { get; set; }
    public Guid UpdatedById { get; set; }
}

public interface ICompanyScoped
{
    Guid CompanyId { get; set; }
}

public interface IAppendOnly
{
}
