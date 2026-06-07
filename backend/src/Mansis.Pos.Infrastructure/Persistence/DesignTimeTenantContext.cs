using Mansis.Pos.Application.Abstractions.Tenancy;

namespace Mansis.Pos.Infrastructure.Persistence;

internal sealed class DesignTimeTenantContext : ITenantContext
{
    public Guid? CompanyId => Guid.Empty;
}
