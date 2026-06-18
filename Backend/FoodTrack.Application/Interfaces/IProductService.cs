using FoodTrack.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByBarCode(string barCode);
    }
}
