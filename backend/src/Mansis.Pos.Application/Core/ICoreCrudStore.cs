namespace Mansis.Pos.Application.Core;

public interface ICoreCrudStore
{
    Task<IReadOnlyList<ProductDto>> ListProductsAsync(Guid companyId, CancellationToken cancellationToken);
    Task<ProductDto?> CreateProductAsync(ProductWriteDto request, CancellationToken cancellationToken);
    Task<ProductDto?> UpdateProductAsync(Guid id, ProductWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateProductAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<CategoryDto>> ListCategoriesAsync(Guid companyId, CancellationToken cancellationToken);
    Task<CategoryDto?> CreateCategoryAsync(CategoryWriteDto request, CancellationToken cancellationToken);
    Task<CategoryDto?> UpdateCategoryAsync(Guid id, CategoryWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateCategoryAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<CustomerDto>> ListCustomersAsync(Guid companyId, CancellationToken cancellationToken);
    Task<CustomerDto?> CreateCustomerAsync(CustomerWriteDto request, CancellationToken cancellationToken);
    Task<CustomerDto?> UpdateCustomerAsync(Guid id, CustomerWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateCustomerAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<OrderListDto>> ListOrdersAsync(Guid companyId, CancellationToken cancellationToken);

    Task<IReadOnlyList<StoreDto>> ListStoresAsync(Guid companyId, CancellationToken cancellationToken);
    Task<StoreDto?> CreateStoreAsync(StoreWriteDto request, CancellationToken cancellationToken);
    Task<StoreDto?> UpdateStoreAsync(Guid id, StoreWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateStoreAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<PosDto>> ListPosAsync(Guid companyId, CancellationToken cancellationToken);
    Task<PosDto?> CreatePosAsync(PosWriteDto request, CancellationToken cancellationToken);
    Task<PosDto?> UpdatePosAsync(Guid id, PosWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivatePosAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);

    Task<IReadOnlyList<DiscountDto>> ListDiscountsAsync(Guid companyId, CancellationToken cancellationToken);
    Task<DiscountDto?> CreateDiscountAsync(DiscountWriteDto request, CancellationToken cancellationToken);
    Task<DiscountDto?> UpdateDiscountAsync(Guid id, DiscountWriteDto request, CancellationToken cancellationToken);
    Task<bool> DeactivateDiscountAsync(Guid companyId, Guid id, Guid userId, CancellationToken cancellationToken);
}
