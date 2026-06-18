using FoodTrack.Domain.Entities;


namespace FoodTrack.Application.DTOs
{
    public class StockProductDto
    {
        public Guid ProductId { get; set; }
        public Guid StockProductId { get; set; }
        public string BarCode { get; set; } = string.Empty;
        public string stockProductName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public DateOnly PurchaseDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public Guid? stockProductLocationId { get; set; }
        public string stockProductLocationName { get; set; } = string.Empty;
    }
}
