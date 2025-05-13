using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finshark.DTOs.stocks;
using Finshark.Interfaces;
using Finshark.Mappers;
using Finshark.Models;
using Newtonsoft.Json;

namespace Finshark.Services
{
    public class FMPService : IFMPService
    {
        private HttpClient _httpClient;
        private IConfiguration _config;

        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // var apiKey = _config["FMPKey"];

                // Console.WriteLine($"🔐 API Key: {apiKey}");
                if (string.IsNullOrEmpty(apiKey))
                {
                    Console.WriteLine("❌ FMPKey is missing!");
                    return null;
                }

                var url = $"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={apiKey}";
                // Console.WriteLine($"🌐 Fetching: {url}");

                var result = await _httpClient.GetAsync(url);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    // Console.WriteLine($"📄 Response: {content}");

                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks.FirstOrDefault();

                    return stock?.ToStockFromFMP();
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"🔥 Exception: {e.Message}");
                return null;
            }
        }
    }
}