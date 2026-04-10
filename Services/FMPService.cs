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

                Console.WriteLine($"🔐 API Key: {apiKey}");
                if (string.IsNullOrEmpty(apiKey))
                {
                    Console.WriteLine("❌ FMPKey is missing!");
                    return null;
                }

                // var url = $"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={apiKey}";
                var url = $"https://financialmodelingprep.com/stable/profile?symbol={symbol}&apikey={apiKey}";
                Console.WriteLine($"🌐 Fetching: {url}");

                var result = await _httpClient.GetAsync(url);
                Console.WriteLine($"📥 Status: {result.StatusCode}");

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    Console.WriteLine($"📄 Response: {content}");

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

        public async Task<BalanceSheetStatement[]> GetBalanceSheetStatementBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<BalanceSheetStatement[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<CashFlowStatement[]> GetCashFlowStatementBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<CashFlowStatement[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<KeyMetrics[]> GetFmpBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        // public async Task<HistoricalPriceFull[]> GetHistoricalPriceFullBySymbolAsync(string symbol, string url)
        // {
        //     try
        //     {
        //         var jsonFilePath = url;
        //         Console.WriteLine($"Reading from file: {jsonFilePath}");
        //         var content = await File.ReadAllTextAsync(jsonFilePath);
        //         var metrics = JsonConvert.DeserializeObject<HistoricalPriceFullResponse[]>(content);
        //         return metrics?.data ?? Array.Empty<HistoricalPriceFull>();

        //         // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
        //         // if (string.IsNullOrEmpty(apiKey))
        //         // {
        //         //     Console.WriteLine("❌ FMPKey is missing!");
        //         //     return null;
        //         // }
        //         // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
        //         // var result = await _httpClient.GetAsync(full_url_link);
        //         // Console.WriteLine($"📥 Status: {result.StatusCode}");
        //         // if (result.IsSuccessStatusCode)
        //         // {
        //         //     var content = await result.Content.ReadAsStringAsync();
        //         //     Console.WriteLine($"📄 Response: {content}");
        //         //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
        //         //     return metrics!;
        //         // }
        //         // return null!;
        //     }
        //     catch (System.Exception ex)
        //     {
        //         Console.WriteLine($"🔥 Exception: {ex.Message}");
        //         return null!;
        //     }
        // }

        public async Task<HistoricalPriceFull[]> GetHistoricalPriceFullBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);

                var response = JsonConvert.DeserializeObject<HistoricalPriceFullResponse>(content);

                return response?.Data ?? Array.Empty<HistoricalPriceFull>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return Array.Empty<HistoricalPriceFull>();
            }
        }

        public async Task<IncomeStatement[]> GetIncomeStatementBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<IncomeStatement[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<KeyMetrics[]> GetKeyMetricsBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<CompanyProfile[]> GetProfileBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<CompanyProfile[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<StockSearch[]> GetSearchDataBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<StockSearch[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<SecFiling[]> GetSecFilingsBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<SecFiling[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }

        public async Task<StockPeer[]> GetStockPeersBySymbolAsync(string symbol, string url)
        {
            try
            {
                var jsonFilePath = url;
                Console.WriteLine($"Reading from file: {jsonFilePath}");
                var content = await File.ReadAllTextAsync(jsonFilePath);
                var metrics = JsonConvert.DeserializeObject<StockPeer[]>(content);
                return metrics!;

                // var apiKey = Environment.GetEnvironmentVariable("FMPKey");
                // if (string.IsNullOrEmpty(apiKey))
                // {
                //     Console.WriteLine("❌ FMPKey is missing!");
                //     return null;
                // }
                // var full_url_link = $"{url}?symbol={symbol}&apikey={apiKey}";
                // var result = await _httpClient.GetAsync(full_url_link);
                // Console.WriteLine($"📥 Status: {result.StatusCode}");
                // if (result.IsSuccessStatusCode)
                // {
                //     var content = await result.Content.ReadAsStringAsync();
                //     Console.WriteLine($"📄 Response: {content}");
                //     var metrics = JsonConvert.DeserializeObject<KeyMetrics[]>(content);
                //     return metrics!;
                // }
                // return null!;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"🔥 Exception: {ex.Message}");
                return null!;
            }
        }
    }
}