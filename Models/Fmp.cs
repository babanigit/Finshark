using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Finshark.Models
{
    public class BalanceSheetStatement
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ReportedCurrency { get; set; } = string.Empty;
        public string Cik { get; set; } = string.Empty;
        public string FilingDate { get; set; } = string.Empty;
        public string AcceptedDate { get; set; } = string.Empty;
        public string FiscalYear { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;

        // Current Assets
        public long CashAndCashEquivalents { get; set; }
        public long ShortTermInvestments { get; set; }
        public long CashAndShortTermInvestments { get; set; }
        public long NetReceivables { get; set; }
        public long AccountsReceivables { get; set; }
        public long OtherReceivables { get; set; }
        public long Inventory { get; set; }
        public long Prepaids { get; set; }
        public long OtherCurrentAssets { get; set; }
        public long TotalCurrentAssets { get; set; }

        // Non-Current Assets
        public long PropertyPlantEquipmentNet { get; set; }
        public long Goodwill { get; set; }
        public long IntangibleAssets { get; set; }
        public long GoodwillAndIntangibleAssets { get; set; }
        public long LongTermInvestments { get; set; }
        public long TaxAssets { get; set; }
        public long OtherNonCurrentAssets { get; set; }
        public long TotalNonCurrentAssets { get; set; }
        public long OtherAssets { get; set; }
        public long TotalAssets { get; set; }

        // Current Liabilities
        public long TotalPayables { get; set; }
        public long AccountPayables { get; set; }
        public long OtherPayables { get; set; }
        public long AccruedExpenses { get; set; }
        public long ShortTermDebt { get; set; }
        public long CapitalLeaseObligationsCurrent { get; set; }
        public long TaxPayables { get; set; }
        public long DeferredRevenue { get; set; }
        public long OtherCurrentLiabilities { get; set; }
        public long TotalCurrentLiabilities { get; set; }

        // Non-Current Liabilities
        public long LongTermDebt { get; set; }
        public long CapitalLeaseObligationsNonCurrent { get; set; }
        public long DeferredRevenueNonCurrent { get; set; }
        public long DeferredTaxLiabilitiesNonCurrent { get; set; }
        public long OtherNonCurrentLiabilities { get; set; }
        public long TotalNonCurrentLiabilities { get; set; }
        public long OtherLiabilities { get; set; }
        public long CapitalLeaseObligations { get; set; }
        public long TotalLiabilities { get; set; }

        // Stockholders' Equity
        public long TreasuryStock { get; set; }
        public long PreferredStock { get; set; }
        public long CommonStock { get; set; }
        public long RetainedEarnings { get; set; }
        public long AdditionalPaidInCapital { get; set; }
        public long AccumulatedOtherComprehensiveIncomeLoss { get; set; }
        public long OtherTotalStockholdersEquity { get; set; }
        public long TotalStockholdersEquity { get; set; }
        public long TotalEquity { get; set; }
        public long MinorityInterest { get; set; }
        public long TotalLiabilitiesAndTotalEquity { get; set; }

        // Summary Metrics
        public long TotalInvestments { get; set; }
        public long TotalDebt { get; set; }
        public long NetDebt { get; set; }
    }


    public class CashFlowStatement
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ReportedCurrency { get; set; } = string.Empty;
        public string Cik { get; set; } = string.Empty;
        public string FilingDate { get; set; } = string.Empty;
        public string AcceptedDate { get; set; } = string.Empty;
        public string FiscalYear { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;

        // Operating Activities
        public long NetIncome { get; set; }
        public long DepreciationAndAmortization { get; set; }
        public long DeferredIncomeTax { get; set; }
        public long StockBasedCompensation { get; set; }
        public long ChangeInWorkingCapital { get; set; }
        public long AccountsReceivables { get; set; }
        public long Inventory { get; set; }
        public long AccountsPayables { get; set; }
        public long OtherWorkingCapital { get; set; }
        public long OtherNonCashItems { get; set; }
        public long NetCashProvidedByOperatingActivities { get; set; }

        // Investing Activities
        public long InvestmentsInPropertyPlantAndEquipment { get; set; }
        public long AcquisitionsNet { get; set; }
        public long PurchasesOfInvestments { get; set; }
        public long SalesMaturitiesOfInvestments { get; set; }
        public long OtherInvestingActivities { get; set; }
        public long NetCashProvidedByInvestingActivities { get; set; }

        // Financing Activities
        public long NetDebtIssuance { get; set; }
        public long LongTermNetDebtIssuance { get; set; }
        public long ShortTermNetDebtIssuance { get; set; }
        public long NetStockIssuance { get; set; }
        public long NetCommonStockIssuance { get; set; }
        public long CommonStockIssuance { get; set; }
        public long CommonStockRepurchased { get; set; }
        public long NetPreferredStockIssuance { get; set; }
        public long NetDividendsPaid { get; set; }
        public long CommonDividendsPaid { get; set; }
        public long PreferredDividendsPaid { get; set; }
        public long OtherFinancingActivities { get; set; }
        public long NetCashProvidedByFinancingActivities { get; set; }

        // Summary
        public long EffectOfForexChangesOnCash { get; set; }
        public long NetChangeInCash { get; set; }
        public long CashAtEndOfPeriod { get; set; }
        public long CashAtBeginningOfPeriod { get; set; }
        public long OperatingCashFlow { get; set; }
        public long CapitalExpenditure { get; set; }
        public long FreeCashFlow { get; set; }
        public long IncomeTaxesPaid { get; set; }
        public long InterestPaid { get; set; }
    }

    public class HistoricalPriceFullResponse
    {
        [JsonProperty("data")]
        public HistoricalPriceFull[] Data { get; set; } = Array.Empty<HistoricalPriceFull>();
    }

    public class HistoricalPriceFull
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal Vwap { get; set; }
    }


    public class IncomeStatement
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ReportedCurrency { get; set; } = string.Empty;
        public string Cik { get; set; } = string.Empty;
        public string FilingDate { get; set; } = string.Empty;
        public string AcceptedDate { get; set; } = string.Empty;
        public string FiscalYear { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;

        // Revenue & Gross Profit
        public long Revenue { get; set; }
        public long CostOfRevenue { get; set; }
        public long GrossProfit { get; set; }

        // Operating Expenses
        public long ResearchAndDevelopmentExpenses { get; set; }
        public long GeneralAndAdministrativeExpenses { get; set; }
        public long SellingAndMarketingExpenses { get; set; }
        public long SellingGeneralAndAdministrativeExpenses { get; set; }
        public long OtherExpenses { get; set; }
        public long OperatingExpenses { get; set; }
        public long CostAndExpenses { get; set; }

        // Interest & EBITDA
        public long NetInterestIncome { get; set; }
        public long InterestIncome { get; set; }
        public long InterestExpense { get; set; }
        public long DepreciationAndAmortization { get; set; }
        public long Ebitda { get; set; }
        public long Ebit { get; set; }

        // Operating Income
        public long NonOperatingIncomeExcludingInterest { get; set; }
        public long OperatingIncome { get; set; }
        public long TotalOtherIncomeExpensesNet { get; set; }

        // Net Income
        public long IncomeBeforeTax { get; set; }
        public long IncomeTaxExpense { get; set; }
        public long NetIncomeFromContinuingOperations { get; set; }
        public long NetIncomeFromDiscontinuedOperations { get; set; }
        public long OtherAdjustmentsToNetIncome { get; set; }
        public long NetIncome { get; set; }
        public long NetIncomeDeductions { get; set; }
        public long BottomLineNetIncome { get; set; }

        // Per Share Data
        public decimal Eps { get; set; }
        public decimal EpsDiluted { get; set; }
        public long WeightedAverageShsOut { get; set; }
        public long WeightedAverageShsOutDil { get; set; }
    }



    public class KeyMetrics
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string FiscalYear { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public string ReportedCurrency { get; set; } = string.Empty;

        // Valuation
        public long MarketCap { get; set; }
        public long EnterpriseValue { get; set; }
        public decimal EvToSales { get; set; }
        public decimal EvToOperatingCashFlow { get; set; }
        public decimal EvToFreeCashFlow { get; set; }
        public decimal EvToEBITDA { get; set; }
        public decimal NetDebtToEBITDA { get; set; }

        // Liquidity & Quality
        public decimal CurrentRatio { get; set; }
        public decimal IncomeQuality { get; set; }
        public decimal GrahamNumber { get; set; }
        public decimal GrahamNetNet { get; set; }

        // Burden Ratios
        public decimal TaxBurden { get; set; }
        public decimal InterestBurden { get; set; }

        // Capital
        public long WorkingCapital { get; set; }
        public long InvestedCapital { get; set; }

        // Return Metrics
        public decimal ReturnOnAssets { get; set; }
        public decimal OperatingReturnOnAssets { get; set; }
        public decimal ReturnOnTangibleAssets { get; set; }
        public decimal ReturnOnEquity { get; set; }
        public decimal ReturnOnInvestedCapital { get; set; }
        public decimal ReturnOnCapitalEmployed { get; set; }

        // Yield Metrics
        public decimal EarningsYield { get; set; }
        public decimal FreeCashFlowYield { get; set; }

        // Capex Ratios
        public decimal CapexToOperatingCashFlow { get; set; }
        public decimal CapexToDepreciation { get; set; }
        public decimal CapexToRevenue { get; set; }

        // Expense Ratios
        public decimal SalesGeneralAndAdministrativeToRevenue { get; set; }
        public decimal ResearchAndDevelopementToRevenue { get; set; }
        public decimal StockBasedCompensationToRevenue { get; set; }
        public decimal IntangiblesToTotalAssets { get; set; }

        // Averages
        public long AverageReceivables { get; set; }
        public long AveragePayables { get; set; }
        public long AverageInventory { get; set; }

        // Days Metrics
        public decimal DaysOfSalesOutstanding { get; set; }
        public decimal DaysOfPayablesOutstanding { get; set; }
        public decimal DaysOfInventoryOutstanding { get; set; }
        public decimal OperatingCycle { get; set; }
        public decimal CashConversionCycle { get; set; }

        // Cash Flow
        public long FreeCashFlowToEquity { get; set; }
        public long FreeCashFlowToFirm { get; set; }
        public long TangibleAssetValue { get; set; }
        public long NetCurrentAssetValue { get; set; }
    }


    public class CompanyProfile
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;

        // Price & Market Data
        public decimal Price { get; set; }
        public long MarketCap { get; set; }
        public decimal Beta { get; set; }
        public decimal LastDividend { get; set; }
        public string Range { get; set; } = string.Empty;
        public decimal Change { get; set; }
        public decimal ChangePercentage { get; set; }
        public long Volume { get; set; }
        public long AverageVolume { get; set; }

        // Company Info
        public string CompanyName { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Cik { get; set; } = string.Empty;
        public string Isin { get; set; } = string.Empty;
        public string Cusip { get; set; } = string.Empty;
        public string ExchangeFullName { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ceo { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FullTimeEmployees { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Address
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;

        // Media & Flags
        public string Image { get; set; } = string.Empty;
        public string IpoDate { get; set; } = string.Empty;
        public bool DefaultImage { get; set; }
        public bool IsEtf { get; set; }
        public bool IsActivelyTrading { get; set; }
        public bool IsAdr { get; set; }
        public bool IsFund { get; set; }
    }


    public class StockSearch
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string ExchangeFullName { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
    }

    public class CompanyInfo
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Cik { get; set; } = string.Empty;
        public string SicCode { get; set; } = string.Empty;
        public string IndustryTitle { get; set; } = string.Empty;
        public string BusinessAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class CompanyOverview
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public long MktCap { get; set; }
    }


    public class SecFiling
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Cik { get; set; } = string.Empty;
        public string SicCode { get; set; } = string.Empty;
        public string IndustryTitle { get; set; } = string.Empty;
        public string BusinessAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }


    public class StockPeer
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public long MktCap { get; set; }
    }

    //     public class CompanyInfo
    // {
    //     public int Id { get; set; }
    //     public string Symbol { get; set; } = string.Empty;
    //     public string Name { get; set; } = string.Empty;
    //     public string Cik { get; set; } = string.Empty;
    //     public string SicCode { get; set; } = string.Empty;
    //     public string IndustryTitle { get; set; } = string.Empty;
    //     public string BusinessAddress { get; set; } = string.Empty;
    //     public string PhoneNumber { get; set; } = string.Empty;
    // }

}