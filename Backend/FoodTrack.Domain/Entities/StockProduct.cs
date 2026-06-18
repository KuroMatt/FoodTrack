using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FoodTrack.Domain.Entities
{
    public class StockProduct
    {
        public Guid StockProductId { get; set; }
        public Guid ProductId { get; set; }

        public DateOnly PurchaseDate { get; set; }
        public DateOnly ExpirationDate { get; set; }

        public Guid? StockProductLocationId { get; set; }

        public int Quantity { get; set; }

        private StockProduct() { }

        public static StockProduct Create(Guid productId, DateOnly purchaseDate, DateOnly expirationDate, Guid? stockProductLocationId, int quantity)
        {
            return new StockProduct
            {
                StockProductId = Guid.NewGuid(),
                ProductId = productId,
                PurchaseDate = purchaseDate,
                ExpirationDate = expirationDate,
                StockProductLocationId = stockProductLocationId,
                Quantity = quantity
            };
        }

        public void IncrementQuantity()
        {
            Quantity++;
        }

        public void DecrementQuantity()
        {
            if (Quantity <= 0) throw new Exception("Le stock ne peut pas être négatif.");
            Quantity--;
        }

        public void Update(DateOnly purchaseDate, DateOnly expirationDate, Guid locationId)
        {
            if (expirationDate <= purchaseDate)
                throw new Exception("La date d'expiration doit être postérieure à la date d'achat.");

            PurchaseDate = purchaseDate;
            ExpirationDate = expirationDate;
            StockProductLocationId = locationId;
        }

    }
}
