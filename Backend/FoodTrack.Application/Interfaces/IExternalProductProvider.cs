using FoodTrack.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Application.Interfaces
{
    public  interface IExternalProductProvider
    {
        public Task<ProductDto> GetProductByBarCodeAsync(string barCode);
    }
}
