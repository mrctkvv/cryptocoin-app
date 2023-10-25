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

        //public async Task<List<HistoricalDataPoint>> GetHistoricalDataById(string? id, string interval)
        //{
        //    if (string.IsNullOrEmpty(id?.Trim()))
        //        throw new ArgumentNullException(nameof(id));

        //    if (string.IsNullOrEmpty(interval?.Trim()))
        //        throw new ArgumentNullException(nameof(interval));

        //    var response = await _apiService.GetRequest(_baseAddress + $"assets/{id}/history?interval={interval}");
        //    var apiHistoricalData = await GetApiData<List<HistoricalDataPoint>>(response);

        //    return apiHistoricalData ?? new List<HistoricalDataPoint>();
        //}

        public async Task<List<HistoricalDataPoint>> GetHistoricalDataById(string currencyId)
        {

            try
            {
                HttpResponseMessage response = await _apiService.GetRequest(_baseAddress + $"assets/{currencyId}/history?interval=d1");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var rootNode = JsonNode.Parse(responseContent);
                    var dataNode = rootNode?["data"];

                    if (dataNode != null)
                    {
                        // Deserialize the dataNode into a list of HistoricalDataPoint.
                        var model = dataNode.Deserialize<List<HistoricalDataPoint>>(new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (model != null)
                        {
                            if (model.Any())
                            {
                                return model;
                            }
                            else
                            {
                                Console.WriteLine($"No historical data available for currency: {currencyId}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid JSON response received for currency: {currencyId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No 'data' property found in the JSON response for currency: {currencyId}");
                    }
                }
                else
                {
                    Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
            }

            // Return an empty list if the historical data could not be retrieved.
            return new List<HistoricalDataPoint>();
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
