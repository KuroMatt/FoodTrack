 using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } =string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        private Product() { }

        public static Product Create(string productName, string brand, string barCode, string category, string weight, string imageUrl)
        {
            return new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = productName,
                Brand = brand,
                BarCode = barCode,
                Category = category,
                Weight = weight,
                ImageUrl = imageUrl
            };
        }
    }
}
