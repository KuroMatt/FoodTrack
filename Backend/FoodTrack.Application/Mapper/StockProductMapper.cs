using FoodTrack.Application.DTOs;
using FoodTrack.Domain.Entities;

namespace FoodTrack.Application.Mapper
{
    public class StockProductMapper
    {
        public static StockProductDto ToDto(StockProduct stockProduct, Product product) => new StockProductDto()
        {
            StockProductId = stockProduct.StockProductId,
            Quantity = stockProduct.Quantity,
            stockProductLocationId = stockProduct.StockProductLocationId,
            ExpirationDate = stockProduct.ExpirationDate,
            PurchaseDate = stockProduct.PurchaseDate,
            stockProductName = product.ProductName,
            BarCode = product.BarCode,
            Brand = product.Brand,
            Category = product.Category,
            Weight = product.Weight,
            ProductId = product.ProductId
        };

    }
}
