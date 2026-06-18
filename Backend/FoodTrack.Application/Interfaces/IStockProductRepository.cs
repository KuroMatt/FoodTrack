using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.Interfaces
{
    public interface IStockRepository
    {
        Task<StockProduct?> GetByKeyAsync(Guid productID, DateOnly expirationDate, CancellationToken cancellationToken);
        Task<StockProduct?> GetByStockProductIdAsync(Guid stockProductId, CancellationToken cancellationToken);
        Task<IReadOnlyList<StockProduct>> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken);
        Task<IReadOnlyList<StockProduct>> GetAllAsync(CancellationToken cancellationToken);
        Task UpdateAsync(StockProduct storeProduct, CancellationToken cancellationToken);
        Task AddAsync(StockProduct stockProduct, CancellationToken cancellationToken);
        Task DeleteAsync(StockProduct stockProduct, CancellationToken cancellationToken);
    }
}
