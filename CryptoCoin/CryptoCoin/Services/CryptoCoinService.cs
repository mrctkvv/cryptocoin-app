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
        private readonly HttpClient _http;
        private const string _baseAddress = "https://api.coincap.io/v2/";
        private const string _apiKey = "05e4b35a-ddcb-4a3e-9e65-684892de3e87";

        public CryptoCoinService()
        {
            _http = new HttpClient();
            _http.DefaultRequestHeaders.Add("Authorization", "Bearer " + _apiKey);
        }

        public async Task<List<CryptoCoinModel>> GetCryptoCoins()
        {
            var response = await GetRequest(_baseAddress + "assets");
            var apiAssets = await GetApiData<List<CryptoCoinModel>>(response);

            return apiAssets is null ? new List<CryptoCoinModel>() : apiAssets;
        }

        public async Task<CryptoCoinModel> GetAssetById(string? id)
        {
            if (string.IsNullOrEmpty(id?.Trim()))
                throw new ArgumentNullException(nameof(id));

            var response = await GetRequest(_baseAddress + $"assets/{id}");
            var apiAsset = await GetApiData<CryptoCoinModel>(response);

            return apiAsset is null ? new CryptoCoinModel() : apiAsset;
        }

        private async Task<HttpResponseMessage> GetRequest(string? url)
        {
            if (string.IsNullOrEmpty(url?.Trim()))
                throw new ArgumentNullException(nameof(url));

            var response = await _http.GetAsync(url);
            if (response is null)
                throw new ArgumentException($"Bad request to url:{url}");

            return response;
        }

        private async Task<M?> GetApiData<M>(HttpResponseMessage responseMessage) where M : class
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
