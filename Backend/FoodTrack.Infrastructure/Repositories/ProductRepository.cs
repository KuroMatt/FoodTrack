using FoodTrack.Application.Interfaces;
using FoodTrack.Domain.Entities;
using FoodTrack.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;


namespace FoodTrack.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductTrackDbContext _productTrackDbContext;
        public ProductRepository(ProductTrackDbContext productTrackDbContext) 
        { 
            _productTrackDbContext = productTrackDbContext;
        }

        public async Task AddAsync(Product product,CancellationToken cancellationToken)
        {
           await _productTrackDbContext.AddAsync(product, cancellationToken);
           await _productTrackDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByBarCodeAsync(string barCode, CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.Products.FirstOrDefaultAsync(product => product.BarCode == barCode, cancellationToken);
        }

        public async Task<Product?> GetByProductIdAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.Products.FirstOrDefaultAsync(product => product.ProductId == productId, cancellationToken);
        }

        public async Task<IReadOnlyList<Product>> GetByIdsAsync(List<Guid> productIds, CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync(cancellationToken);
        }
    }
}
