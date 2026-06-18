using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodTrack.Domain.Entities
{
    public class StockProductLocation
    {
        [Key]
        public Guid stockProductLocationId { get; set; }

        [Required]
        public string LocationName { get; set; } = string.Empty;
    }
}
