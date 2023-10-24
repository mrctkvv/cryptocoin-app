using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCoin.Services
{
    internal class CryptoCoinApiService
    {
        private readonly HttpClient _http;

        public CryptoCoinApiService()
        {
            _http = new HttpClient();
        }

        public Task<HttpResponseMessage> GetRequest(string? url)
        {
            if (string.IsNullOrEmpty(url?.Trim()))
            {
                throw new ArgumentNullException(nameof(url));
            }

            return GetRequestAsync(url);
            async Task<HttpResponseMessage> GetRequestAsync(string addressUrl)
            {
                var res = await _http.GetAsync(addressUrl);
                return res == null ? throw new ArgumentException("Bad request:{urlAddress}") : res;
            }
        }
    }
}
