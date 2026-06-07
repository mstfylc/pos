namespace Mansis.Pos.Application.Core;

public sealed class CoreCrudService(ICoreCrudStore store)
{
    public Task<IReadOnlyList<ProductDto>> ListProductsAsync(Guid companyId, CancellationToken cancellationToken) => store.ListProductsAsync(companyId, cancellationToken);
    public Task<ProductDto?> CreateProductAsync(ProductWriteDto request, CancellationToken cancellationToken) => store.CreateProductAsync(request, cancellationToken);
    public Task<ProductDto?> UpdateProductAsync(Guid id, ProductWriteDto request, CancellationToken cancellationToken) => store.UpdateProductAsync(id, request, cancellationToken);
    public Task<bool> DeactivateProductAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateProductAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync(Guid companyId, CancellationToken cancellationToken) => store.ListCategoriesAsync(companyId, cancellationToken);
    public Task<CategoryDto?> CreateCategoryAsync(CategoryWriteDto request, CancellationToken cancellationToken) => store.CreateCategoryAsync(request, cancellationToken);
    public Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryWriteDto request, CancellationToken cancellationToken) => store.UpdateCategoryAsync(id, request, cancellationToken);
    public Task<bool> DeactivateCategoryAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateCategoryAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<CustomerDto>> ListCustomersAsync(Guid companyId, CancellationToken cancellationToken) => store.ListCustomersAsync(companyId, cancellationToken);
    public Task<CustomerDto?> CreateCustomerAsync(CustomerWriteDto request, CancellationToken cancellationToken) => store.CreateCustomerAsync(request, cancellationToken);
    public Task<CustomerDto?> UpdateCustomerAsync(Guid id, CustomerWriteDto request, CancellationToken cancellationToken) => store.UpdateCustomerAsync(id, request, cancellationToken);
    public Task<bool> DeactivateCustomerAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateCustomerAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<OrderListDto>> ListOrdersAsync(Guid companyId, CancellationToken cancellationToken) => store.ListOrdersAsync(companyId, cancellationToken);

    public Task<IReadOnlyList<StoreDto>> ListStoresAsync(Guid companyId, CancellationToken cancellationToken) => store.ListStoresAsync(companyId, cancellationToken);
    public Task<StoreDto?> CreateStoreAsync(StoreWriteDto request, CancellationToken cancellationToken) => store.CreateStoreAsync(request, cancellationToken);
    public Task<StoreDto?> UpdateStoreAsync(Guid id, StoreWriteDto request, CancellationToken cancellationToken) => store.UpdateStoreAsync(id, request, cancellationToken);
    public Task<bool> DeactivateStoreAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateStoreAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<PosDto>> ListPosAsync(Guid companyId, CancellationToken cancellationToken) => store.ListPosAsync(companyId, cancellationToken);
    public Task<PosDto?> CreatePosAsync(PosWriteDto request, CancellationToken cancellationToken) => store.CreatePosAsync(request, cancellationToken);
    public Task<PosDto?> UpdatePosAsync(Guid id, PosWriteDto request, CancellationToken cancellationToken) => store.UpdatePosAsync(id, request, cancellationToken);
    public Task<bool> DeactivatePosAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivatePosAsync(companyId, id, userId, cancellationToken);

    public Task<IReadOnlyList<DiscountDto>> ListDiscountsAsync(Guid companyId, CancellationToken cancellationToken) => store.ListDiscountsAsync(companyId, cancellationToken);
    public Task<DiscountDto?> CreateDiscountAsync(DiscountWriteDto request, CancellationToken cancellationToken) => store.CreateDiscountAsync(request, cancellationToken);
    public Task<DiscountDto?> UpdateDiscountAsync(Guid id, DiscountWriteDto request, CancellationToken cancellationToken) => store.UpdateDiscountAsync(id, request, cancellationToken);
    public Task<bool> DeactivateDiscountAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken) => store.DeactivateDiscountAsync(companyId, id, userId, cancellationToken);
}
