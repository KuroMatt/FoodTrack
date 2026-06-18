
namespace FoodTrack.Application.DTOs
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int TotalStockQuantity { get; set; }
        public int CurrentStockQuantity { get; set; }
    }
}
