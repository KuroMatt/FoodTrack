using FoodTrack.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Application.Features.StockProducts.Query
{
    public record GetTotalStockByProductQuery(Guid ProductId) : IRequest<int>;
    public class GetTotalStockByProductQueryHandler : IRequestHandler<GetTotalStockByProductQuery, int>
    {
        private readonly IStockRepository _stockRepository;

        public GetTotalStockByProductQueryHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<int> Handle(GetTotalStockByProductQuery request, CancellationToken cancellationToken)
        {
            var stockList = await _stockRepository.GetByProductIdAsync(request.ProductId, cancellationToken);
            return stockList.Sum(s => s.Quantity);
        }
    }
}
    