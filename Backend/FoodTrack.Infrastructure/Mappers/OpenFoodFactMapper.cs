using FoodTrack.Application.DTOs;
using FoodTrack.Infrastructure.HttpClients.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Infrastructure.Mappers
{
    public static class OpenFoodFactMapper
    {
        public static ProductDto? ToProductDto(OpenFoodFactResponse response)
        {
            if (response == null || response.Product == null)
                return null;

            var product = response.Product;
            return new ProductDto
            {
                BarCode = response.BarCode,
                Name = product.ProductName,
                Brand = product.Brand,
                Category = product.Category,
                Weight = product.Weight,
                ImageUrl = product.ImageUrl,
                
            };
        }
    }
}
