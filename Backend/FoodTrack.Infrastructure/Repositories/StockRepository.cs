using FoodTrack.Application.Interfaces;
using FoodTrack.Domain.Entities;
using FoodTrack.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;


namespace FoodTrack.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ProductTrackDbContext _productTrackDbContext;

        public StockRepository(ProductTrackDbContext productTrackDbContext)
        {
            _productTrackDbContext = productTrackDbContext;
        }

        public async Task<StockProduct?> GetByKeyAsync(Guid productId, DateOnly expirationDate, CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.StockProducts
                .FirstOrDefaultAsync(hp =>
                    hp.ProductId == productId && hp.ExpirationDate == expirationDate);
        }

        public async Task UpdateAsync(StockProduct stockProduct, CancellationToken cancellationToken)
        {
            _productTrackDbContext.StockProducts.Update(stockProduct);
            await _productTrackDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<StockProduct>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.StockProducts
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(StockProduct stockProduct, CancellationToken cancellationToken)
        {
            await _productTrackDbContext.StockProducts.AddAsync(stockProduct, cancellationToken);
            await _productTrackDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(StockProduct stockProduct, CancellationToken cancellationToken)
        {
            _productTrackDbContext.StockProducts.Remove(stockProduct);
            await _productTrackDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<StockProduct?> GetByStockProductIdAsync(Guid stockProductId, CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.StockProducts.AsNoTracking().FirstOrDefaultAsync(hp => hp.StockProductId == stockProductId, cancellationToken);
        }

        public async Task<IReadOnlyList<StockProduct>> GetByProductIdAsync(Guid stockProductId, CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.StockProducts
                .AsNoTracking()
                .Where(hp => hp.ProductId == stockProductId)
                .ToListAsync(cancellationToken);
        }
    }
}
