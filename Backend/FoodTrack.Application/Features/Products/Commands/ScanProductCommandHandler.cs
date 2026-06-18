using FoodTrack.Application.DTOs;
using FoodTrack.Application.Interfaces;
using FoodTrack.Application.Mapper;
using FoodTrack.Domain.Entities;
using MediatR;

namespace FoodTrack.Application.Features.Products.Commands
{
    public record ScanProductCommand(string Barcode) : IRequest<ProductDto>;

    public class ScanProductCommandHandler : IRequestHandler<ScanProductCommand, ProductDto>
    {
        private readonly IExternalProductProvider _externalProductProvider;
        private readonly IProductRepository _productRepository;

        public ScanProductCommandHandler(IExternalProductProvider externalProductProvider,
            IStockRepository stockProductRepository,
            IProductRepository productRepository)
        {
            _externalProductProvider = externalProductProvider;
            _productRepository = productRepository;

        }
        public async Task<ProductDto> Handle(ScanProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _productRepository.GetByBarCodeAsync(request.Barcode);
            if (productEntity is not null)
            {
                return ProductMapper.ToDto(productEntity);
            }

            var externalProduct = await _externalProductProvider.GetProductByBarCodeAsync(request.Barcode);
            if (externalProduct is null)
            {
                if (externalProduct is null) throw new Exception("Produit introuvable via le code-barres.");
            }
            var product = Product.Create(externalProduct.Name, externalProduct.Brand, externalProduct.BarCode, externalProduct.Category, externalProduct.Weight, externalProduct.ImageUrl);

            await _productRepository.AddAsync(product);
            return ProductMapper.ToDto(product);

        }
    }
}
