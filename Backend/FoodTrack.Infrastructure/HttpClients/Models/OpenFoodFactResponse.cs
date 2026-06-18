using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FoodTrack.Infrastructure.HttpClients.Models
{
    public class OpenFoodFactResponse
    {
        [JsonPropertyName("code")]
        public string BarCode { get; set; } = string.Empty;

        [JsonPropertyName("product")]
        public OpenFoodFactProduct? Product { get; set; }

        public class OpenFoodFactProduct
        {
            [JsonPropertyName("product_name")]
            public string ProductName { get; set; } = string.Empty;

            [JsonPropertyName("categories")]
            public string Category { get; set; } = string.Empty;

            [JsonPropertyName("brands")]
            public string Brand { get; set; } = string.Empty;

            [JsonPropertyName("quantity")]
            public string Weight { get; set; } = string.Empty;

            [JsonPropertyName("image_front_thumb_url")]
            public string ImageUrl { get; set; } = string.Empty;
        }
    }



}
