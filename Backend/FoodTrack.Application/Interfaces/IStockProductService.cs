using FoodTrack.Application.DTOs;
using FoodTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTrack.Application.Interfaces
{
    public interface IstockProductService
    {
        public Task<StockProductDto> CreatestockProductAsync(StockProductDto stockProductDto);
    }
}
