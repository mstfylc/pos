using Mansis.Pos.Application.Abstractions.Tenancy;

namespace Mansis.Pos.Infrastructure.Tenancy;

internal sealed class EnvironmentTenantContext : ITenantContext
{
    public Guid? CompanyId
    {
        get
        {
            var value = Environment.GetEnvironmentVariable("COMPANY_ID");
            return Guid.TryParse(value, out var companyId) ? companyId : null;
        }
    }
}
