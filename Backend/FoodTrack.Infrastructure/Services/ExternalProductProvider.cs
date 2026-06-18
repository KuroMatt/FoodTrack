using FoodTrack.Application.DTOs;
using FoodTrack.Application.Interfaces;
using FoodTrack.Infrastructure.HttpClients;
using FoodTrack.Infrastructure.Mappers;


namespace FoodTrack.Infrastructure.Services
{
    // Classe de service permettant d'intéragie avec des API externes pour la récupération de données de produits
    public class ExternalProductProvider: IExternalProductProvider
    {
        private readonly OpenFoodFactClient _openFoodFactClient;

        public ExternalProductProvider(OpenFoodFactClient openFoodFactClient)
        {
            _openFoodFactClient = openFoodFactClient;
        }

        public async Task<ProductDto> GetProductByBarCodeAsync(string barCode)
        {
            var reponse = await _openFoodFactClient.GetByBarCodeAsync(barCode);

            return OpenFoodFactMapper.ToProductDto(reponse);
        }
    }
}
