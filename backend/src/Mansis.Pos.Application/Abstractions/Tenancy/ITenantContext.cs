namespace Mansis.Pos.Application.Abstractions.Tenancy;

public interface ITenantContext
{
    Guid? CompanyId { get; }
}
