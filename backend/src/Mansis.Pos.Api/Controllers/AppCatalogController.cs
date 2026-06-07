using Mansis.Pos.Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace Mansis.Pos.Api.Controllers;

[ApiController]
[Route("api/v1/app")]
[Tags("App")]
public sealed class AppCatalogController(CoreCrudService coreCrudService) : ControllerBase
{
    [HttpGet("products")]
    public Task<IReadOnlyList<ProductDto>> ListProductsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListProductsAsync(companyId, cancellationToken);

    [HttpGet("categories")]
    public Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListCategoriesAsync(companyId, cancellationToken);

    [HttpGet("customers")]
    public Task<IReadOnlyList<CustomerDto>> ListCustomersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListCustomersAsync(companyId, cancellationToken);

    [HttpGet("orders")]
    public Task<IReadOnlyList<OrderListDto>> ListOrdersAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListOrdersAsync(companyId, cancellationToken);

    [HttpGet("stores")]
    public Task<IReadOnlyList<StoreDto>> ListStoresAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListStoresAsync(companyId, cancellationToken);

    [HttpGet("pos")]
    public Task<IReadOnlyList<PosDto>> ListPosAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListPosAsync(companyId, cancellationToken);

    [HttpGet("discounts")]
    public Task<IReadOnlyList<DiscountDto>> ListDiscountsAsync([FromQuery] Guid companyId, CancellationToken cancellationToken) =>
        coreCrudService.ListDiscountsAsync(companyId, cancellationToken);
}
