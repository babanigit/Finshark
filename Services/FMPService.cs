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

                if (string.IsNullOrEmpty(apiKey))
                {
                    Console.WriteLine("FMPKey is missing or empty!");
                    return null;
                }

                var staticKey = $"https://financialmodelingprep.com/Finshark/v3/profile/query=AA&apikey={apiKey}";

                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/Finshark/v3/profile/{symbol}?apikey={apiKey}");
                var result2 = await _httpClient.GetAsync($"https://financialmodelingprep.com/Finshark/v3/profile/{symbol}?apikey={_config["FMPKey"]}");


                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks[0];
                    if (stock != null)
                    {
                        return stock.ToStockFromFMP();
                    }
                    return null;
                }
                return null;

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return null;
            }
        }
    }
}