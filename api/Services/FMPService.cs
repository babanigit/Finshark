using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.stocks;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Newtonsoft.Json;

namespace api.Services
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

                var apiKey = _config["FMPKey"]; // Get the API Key

                if (string.IsNullOrEmpty(apiKey))
                {
                    Console.WriteLine("FMPKey is missing or empty!");
                    return null;
                }

                Console.WriteLine($"Using API Key: {apiKey}"); // Debugging Log

                var staticKey = $"https://financialmodelingprep.com/api/v3/profile/query=AA&apikey=XBxgWb82iv6gwQGqFAkvs81uehEqswlT" ;

                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey=XBxgWb82iv6gwQGqFAkvs81uehEqswlT");

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