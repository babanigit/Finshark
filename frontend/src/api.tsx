import axios from "axios";
import {
  CompanyBalanceSheet,
  CompanyCashFlow,
  CompanyCompData,
  CompanyIncomeStatement,
  CompanyKeyMetrics,
  CompanyProfile,
  CompanySearch,
  CompanyTenK,
  CompanyHistoricalDividend,
  CompanyProfile2,
  // Dividend,
} from "./company";

import search_data from "../src/jsons/search_data.json";
import balance_sheet_statement from "../src/jsons/balance_sheet_statement.json";
import cash_flow_statement from "../src/jsons/cash_flow_statement.json";
import historicalDivident from "../src/jsons/historicalDivident.json";
import income_statement from "../src/jsons/income_statement.json";
import key_metrics from "../src/jsons/key_metrics.json";
import profile from "../src/jsons/profile.json";
import stock_peer from "../src/jsons/stock_peer.json";
import sec_filings from "../src/jsons/sec_filings.json";
import { HistoricalPriceResponse } from "./Models/Historic_Divident";

export interface SearchResponse {
  data: CompanySearch[];
}
const apiKey: string = import.meta.env.VITE_FMI_API_KEY;
if (!apiKey) {
  console.error("API key is missing!");
}



export interface Iapistatus{
  message:string;
}


export const apistatus = async (query: string) => {
  try {
    const data = await axios.get<Iapistatus>(
      `http://localhost:5222/api/status`,
    );
    return data;
    // return { data: search_data };
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("error message: ", error.message);
      return error.message;
    } else {
      console.error("unexpected error: ", error);
      return "An expected error has occured.";
    }
  }
};


//https://financialmodelingprep.com/stable/search-symbol?query=tata&limit=10&exchange=NASDAQ&apikey=vxeZ0Lbxl3xfWEU4ftBvenLHBmrWcXmj
export const searchCompanies = async (query: string) => {
  try {
    // const data = await axios.get<SearchResponse>(
    //   `https://financialmodelingprep.com/stable/search-symbol?query=${query}&limit=10&exchange=NASDAQ&apikey=${apiKey}`,
    // );
    return { data: search_data };
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("error message: ", error.message);
      return error.message;
    } else {
      console.error("unexpected error: ", error);
      return "An expected error has occured.";
    }
  }
};

export const getCompanyProfile = async (query: string) => {
  try {
    // const data = await axios.get<CompanyProfile2[]>(
    //   // `https://financialmodelingprep.com/stable/profile/${query}?apikey=${apiKey}`
    //   `https://financialmodelingprep.com/stable/profile?symbol=${query}&apikey=${apiKey}`,
    // );
    return { data: profile };
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getKeyMetrics = async (query: string) => {
  try {
    // const data = await axios.get<CompanyKeyMetrics[]>(
    //   // `https://financialmodelingprep.com/stable/key-metrics-ttm/${query}?limit=40&apikey=${apiKey}`
    //   `https://financialmodelingprep.com/stable/key-metrics?symbol=${query}&apikey=${apiKey}`,
    // );
    return { data: key_metrics };
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};
export const getIncomeStatement = async (query: string) => {
  try {
    // const data = await axios.get<CompanyIncomeStatement[]>(
    //   // `https://financialmodelingprep.com/stable/income-statement/${query}?limit=50&apikey=${apiKey}`
    //   `https://financialmodelingprep.com/stable/income-statement?symbol=${query}&apikey=${apiKey}`,
    // );
    return { data: income_statement };
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getBalanceSheet = async (query: string) => {
  try {
    // const data = await axios.get<CompanyBalanceSheet[]>(
    //   // `https://financialmodelingprep.com/stable/balance-sheet-statement/${query}?limit=20&apikey=${apiKey}`
    //   `https://financialmodelingprep.com/stable/balance-sheet-statement?symbol=${query}&apikey=${apiKey}`,
    // );
    return { data: balance_sheet_statement };
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getCashFlow = async (query: string) => {
  try {
    // const data = await axios.get<CompanyCashFlow[]>(
    //   // `https://financialmodelingprep.com/stable/cash-flow-statement/${query}?limit=100&apikey=${apiKey}`
    //   `https://financialmodelingprep.com/stable/cash-flow-statement?symbol=${query}&apikey=${apiKey}`,
    // );
    return { data: cash_flow_statement };
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getCompData = async (query: string) : Promise<any> => {
  try {
    // const data = await axios.get<CompanyCompData[]>(
    //   //`https://financialmodelingprep.com/api/v4/stock_peers?symbol=${query}&apikey=${apiKey}`
    //   `https://financialmodelingprep.com/stable/stock-peers?symbol=${query}&apikey=${apiKey}`,
    // );
    return { data: stock_peer };
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getTenK = async (query: string) => {
  try {
    // const data = await axios.get<CompanyTenK[]>(
    //   // `https://financialmodelingprep.com/stable/sec_filings/${query}?type=10-K&page=0&apikey=${apiKey}`,
    //   `https://financialmodelingprep.com/stable/sec-filings-company-search/symbol?symbol=${query}&apikey=${apiKey}`,
    // );
    return { data: sec_filings };
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};
// import historicalDividendData from "./jsons/historicalDivident.json";

export const getHistoricalDividend = async (
  query: string,
): Promise<HistoricalPriceResponse | undefined> => {
  try {
    // const data = await axios.get<CompanyHistoricalDividend>(
    //   // `https://financialmodelingprep.com/stable/historical-price-full/stock_dividend/${query}?apikey=${apiKey}`,
    //   `https://financialmodelingprep.com/stable/historical-price-eod/full?symbol=${query}&apikey=${apiKey}`
    // );

    // Filter by symbol if your JSON contains multiple symbols

    return historicalDivident;

    // return { data: historicalDivident };

    //  const result = historicalDivident.data.filter(
    //   (item) => item.symbol.toLowerCase() === query.toLowerCase()
    // );
    // return { data: result }; // now value.data is an array ✅
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};
