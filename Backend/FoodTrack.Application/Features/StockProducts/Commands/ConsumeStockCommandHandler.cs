using FoodTrack.Application.DTOs;
using FoodTrack.Application.Interfaces;
using FoodTrack.Application.Mapper;
using MediatR;

namespace FoodTrack.Application.Features.StockProducts.Commands
{
    public record ConsumeStockCommand() : IRequest
    {
        public Guid StockProductId { get; init; }
        public DateOnly ExpirationDate { get; init; }
        public int Quantity { get; init; } = 1;
    }

    public class ConsumeStockCommandHandler : IRequestHandler<ConsumeStockCommand>
    {
        private readonly IStockRepository _stockRepository;

        public ConsumeStockCommandHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task Handle(ConsumeStockCommand request, CancellationToken cancellationToken)
        {
            var existing = await _stockRepository.GetByStockProductIdAsync(
            request.StockProductId,
            cancellationToken)
            ?? throw new Exception(
                $"Le produit {request.StockProductId} est introuvable dans le stock.");

            int newQuantity = existing.Quantity - request.Quantity;

            // Stock épuisé → supprime l'entrée
            if (newQuantity <= 0)
            {
                await _stockRepository.DeleteAsync(existing, cancellationToken);
                existing.Quantity = 0; 
            }

            // Décrémente la quantité
            existing.Quantity = newQuantity;
            await _stockRepository.UpdateAsync(existing, cancellationToken);
        }
    }
}
