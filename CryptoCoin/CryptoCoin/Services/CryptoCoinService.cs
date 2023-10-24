using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoCoin.Models;

namespace CryptoCoin.Services
{
    public class CryptoCoinService
    {
        private readonly CryptoCoinApiService _apiService;
        private const string _baseAddress = "https://api.coincap.io/v2/";

        public CryptoCoinService()
        {
            _apiService = new CryptoCoinApiService();
        }

        public async Task<List<CryptoCoinModel>> GetCryptoCoins()
        {
            var response = await _apiService.GetRequest(_baseAddress + "assets");
            var apiAssets = await GetApiData<List<CryptoCoinModel>>(response);

            return apiAssets is null ? new List<CryptoCoinModel>() : apiAssets;
        }

        public async Task<CryptoCoinModel> GetModelById(string? id)
        {
            if (string.IsNullOrEmpty(id?.Trim()))
                throw new ArgumentNullException(nameof(id));

            var response = await _apiService.GetRequest(_baseAddress + $"assets/{id}");
            var apiAsset = await GetApiData<CryptoCoinModel>(response);

            return apiAsset is null ? new CryptoCoinModel() : apiAsset;
        }

        private static async Task<M?> GetApiData<M>(HttpResponseMessage responseMessage) where M : class
        {
            string stringResponse = await responseMessage.Content.ReadAsStringAsync();
            try
            {
                var jsonArray = JsonNode.Parse(stringResponse)?["data"];
                var model = jsonArray.Deserialize<M>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return model;
            }
            catch
            {
                return null;
            }
        }
    }
}
