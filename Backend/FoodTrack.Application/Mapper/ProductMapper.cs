using FoodTrack.Application.DTOs;
using FoodTrack.Domain.Entities;


namespace FoodTrack.Application.Mapper
{
    public class ProductMapper
    {
        public static ProductDto ToDto(Product product) => new()
        {
            ProductId = product.ProductId,
            Name = product.ProductName,
            BarCode = product.BarCode,
            Brand = product.Brand,
            Weight = product.Weight,
            Category = product.Category,
            ImageUrl = product.ImageUrl,
        };

    }
}
