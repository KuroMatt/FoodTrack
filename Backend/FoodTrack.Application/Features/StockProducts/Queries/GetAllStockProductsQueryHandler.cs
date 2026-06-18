using FoodTrack.Application.DTOs;
using FoodTrack.Application.Interfaces;
using FoodTrack.Application.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Application.Features.StockProducts.Queries
{
    public record GetAllStockProductsQuery : IRequest<IReadOnlyList<StockProductDto>>;
    public class GetAllStockProductsQueryHandler : IRequestHandler<GetAllStockProductsQuery, IReadOnlyList<StockProductDto>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IProductRepository _productRepository;


        public GetAllStockProductsQueryHandler(IStockRepository stockRepository, IProductRepository productRepository)
        {
            _stockRepository = stockRepository;
            _productRepository = productRepository;
        }
        public async Task<IReadOnlyList<StockProductDto>> Handle(GetAllStockProductsQuery request, CancellationToken cancellationToken)
        {
            var stockList = await _stockRepository.GetAllAsync(cancellationToken);
            if (!stockList.Any()) return new List<StockProductDto>();

            var productIds = stockList
                .Select(s => s.ProductId)
                .Distinct()
                .ToList();

            var products = await _productRepository.GetByIdsAsync(productIds, cancellationToken);
            var productDict = products.ToDictionary(p => p.ProductId);

            return stockList
                .Select(stock => StockProductMapper.ToDto(stock, productDict[stock.ProductId]))
                .ToList();
        }

    }
}
