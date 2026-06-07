using Mansis.Pos.Application.Abstractions.Tenancy;

namespace Mansis.Pos.Api.Tenancy;

internal sealed class HttpTenantContext(IHttpContextAccessor httpContextAccessor) : ITenantContext
{
    public Guid? CompanyId
    {
        get
        {
            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext is not null)
            {
                if (TryReadGuid(httpContext.Request.Headers["X-Company-Id"].FirstOrDefault(), out var headerCompanyId))
                {
                    return headerCompanyId;
                }

                if (TryReadGuid(httpContext.Request.Query["companyId"].FirstOrDefault(), out var queryCompanyId))
                {
                    return queryCompanyId;
                }
            }

            var value = Environment.GetEnvironmentVariable("COMPANY_ID");
            return TryReadGuid(value, out var envCompanyId) ? envCompanyId : null;
        }
    }

    private static bool TryReadGuid(string? value, out Guid companyId)
    {
        return Guid.TryParse(value, out companyId) && companyId != Guid.Empty;
    }
}
