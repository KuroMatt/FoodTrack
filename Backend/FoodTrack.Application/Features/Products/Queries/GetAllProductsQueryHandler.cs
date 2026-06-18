using FoodTrack.Application.DTOs;
using FoodTrack.Application.Interfaces;
using FoodTrack.Application.Mapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Application.Features.Products.Queries
{
    public record GetAllProductsQuery : IRequest<IReadOnlyList<ProductDto>>;
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IReadOnlyList<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync(cancellationToken);
            return products.Select(ProductMapper.ToDto).ToList();
        }
    }
}
