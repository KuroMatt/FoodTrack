using FoodTrack.Application.DTOs;
using FoodTrack.Application.Interfaces;
using FoodTrack.Application.Mapper;
using MediatR;
using System;

namespace FoodTrack.Application.Features.Products.Queries
{
    public record GetByProductByIdQuery(Guid productID) : IRequest<ProductDto>;
    public class GetByProductByIdQueryHandler : IRequestHandler<GetByProductByIdQuery, ProductDto>
    {
        
        private readonly IProductRepository _productRepository;

        public GetByProductByIdQueryHandler(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetByProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByProductIdAsync(request.productID, cancellationToken);
            if (product == null)
            {
                throw new Exception($"Product with ID {request.productID} not found.");
            }
            return ProductMapper.ToDto(product);
        }
    }
}
