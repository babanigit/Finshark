using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finshark.Models;

namespace Finshark.Interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
        Task<KeyMetrics[]> GetFmpBySymbolAsync(string symbol, string url);
        Task<StockSearch[]> GetSearchDataBySymbolAsync(string symbol, string url);
        Task<CompanyProfile[]> GetProfileBySymbolAsync(string symbol, string url);
        Task<KeyMetrics[]> GetKeyMetricsBySymbolAsync(string symbol, string url);
        Task<IncomeStatement[]> GetIncomeStatementBySymbolAsync(string symbol, string url);
        Task<BalanceSheetStatement[]> GetBalanceSheetStatementBySymbolAsync(string symbol, string url);
        Task<CashFlowStatement[]> GetCashFlowStatementBySymbolAsync(string symbol, string url);
        Task<StockPeer[]> GetStockPeersBySymbolAsync(string symbol, string url);
        Task<SecFiling[]> GetSecFilingsBySymbolAsync(string symbol, string url);
        Task<HistoricalDividend[]> GetHistoricalPriceFullBySymbolAsync(string symbol, string url);

    }
}