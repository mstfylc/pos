using Mansis.Pos.Application.Orders.CreateOrder;
using Mansis.Pos.Domain.Entities;

namespace Mansis.Pos.Application.Pos;

public interface IPosStore
{
    Task<PosProductCatalogResponse?> GetCatalogAsync(Guid companyId, Guid posId, CancellationToken cancellationToken);
    Task<Customer?> GetCustomerAsync(Guid companyId, Guid customerId, CancellationToken cancellationToken);
    Task AddCustomerCardTokenAsync(CustomerCardToken token, CancellationToken cancellationToken);
    Task<IdentifiedCustomerDto?> IdentifyCustomerByTokenAsync(Guid companyId, string token, bool consume, CancellationToken cancellationToken);
    Task<OrderCreationSnapshot?> LoadLoyaltyPreviewSnapshotAsync(Guid companyId, Guid posId, Guid customerId, IReadOnlyCollection<Guid> productIds, CancellationToken cancellationToken);
    Task<IReadOnlyList<Reward>> ListAvailableRewardsAsync(Guid companyId, int pointBalance, CancellationToken cancellationToken);
}
