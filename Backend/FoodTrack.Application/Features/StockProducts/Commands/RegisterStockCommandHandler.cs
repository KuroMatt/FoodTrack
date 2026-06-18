using FoodTrack.Application.Interfaces;
using FoodTrack.Domain.Entities;
using MediatR;


namespace FoodTrack.Application.Features.StockProducts.Commands
{
    public record RegisterStockCommand(Guid productId, DateOnly purchaseDate, DateOnly expirationDate, Guid? locationId, int quantity) : IRequest<Guid>;
    public class RegisterStockCommandHandler : IRequestHandler<RegisterStockCommand, Guid>
    {
        private readonly IStockRepository _stockRepository;

        public RegisterStockCommandHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<Guid> Handle(RegisterStockCommand request, CancellationToken cancellationToken)
        {
            // Stock existant avec même produit et même DLC
            var existing = await _stockRepository.GetByKeyAsync(
                request.productId,
                request.expirationDate,
                cancellationToken);

            if (existing is not null)
            {
                existing.IncrementQuantity();
                await _stockRepository.UpdateAsync(existing, cancellationToken);
                return existing.StockProductId;
            }

            // Nouveau stock
            var stockProduct = StockProduct.Create(
                request.productId,
                request.purchaseDate,
                request.expirationDate,
                request.locationId,
                request.quantity);

            await _stockRepository.AddAsync(stockProduct, cancellationToken);
            return stockProduct.StockProductId;
        }
    }
}
 