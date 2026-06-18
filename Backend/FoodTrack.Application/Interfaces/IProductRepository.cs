

using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product?> GetByBarCodeAsync(string barCode);
        public Task AddAsync(Product product);

        public Task<IReadOnlyList<Product>> GetByIdsAsync(List<Guid> productIds, CancellationToken cancellationToken);
        public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken);

    }
}
