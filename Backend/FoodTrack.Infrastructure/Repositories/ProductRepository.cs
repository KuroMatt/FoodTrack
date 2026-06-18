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

        public async Task AddAsync(Product product)
        {
           await _productTrackDbContext.AddAsync(product);
           await _productTrackDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByBarCodeAsync(string barCode)
        {
            return await _productTrackDbContext.Products.FirstOrDefaultAsync(product => product.BarCode == barCode);
        }


        public async Task<IReadOnlyList<Product>> GetByIdsAsync(List<Guid> productIds, CancellationToken cancellationToken)
        {
            return await _productTrackDbContext.Products
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync(cancellationToken);
        }
    }
}
