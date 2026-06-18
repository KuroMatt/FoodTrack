using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Domain.Entities
{
    public  class User
    {
        public Guid UserId { get; set; }
        public string Pseudo { get; set; } = string.Empty;
    }
}
