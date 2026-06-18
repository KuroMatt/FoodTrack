using FoodTrack.Infrastructure.HttpClients.Models;
using System.Net.Http.Json;

namespace FoodTrack.Infrastructure.HttpClients
{
    public class OpenFoodFactClient : HttpClient
    {
        private readonly HttpClient _httpClient;

        public const string ProductionUrl = "https://world.openfoodfacts.org";
        public const string StagingUrl = "https://world.openfoodfacts.net";
        public const string ApiUrl = "api/v2/product";

        public OpenFoodFactClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OpenFoodFactResponse> GetByBarCodeAsync(string barCode)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}/{barCode}");

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    throw new Exception(
                        $"Le produit avec le code barre {barCode} est introuvabl sur OpenFoodFacts.");
            }


            response.EnsureSuccessStatusCode();

            return await response.Content
                .ReadFromJsonAsync<OpenFoodFactResponse>()
                ?? throw new Exception($"Le produit avec le code barre {barCode} est introuvable");
        }


    }
}
