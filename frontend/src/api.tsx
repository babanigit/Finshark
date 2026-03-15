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
  // Dividend,
} from "./company";

export interface SearchResponse {
  data: CompanySearch[];
}
const apiKey: string = import.meta.env.VITE_FMI_API_KEY;
if (!apiKey) {
  console.error("API key is missing!");
}
//https://financialmodelingprep.com/stable/search-symbol?query=tata&limit=10&exchange=NASDAQ&apikey=vxeZ0Lbxl3xfWEU4ftBvenLHBmrWcXmj
export const searchCompanies = async (query: string) => {
  try {
    const data = await axios.get<SearchResponse>(
      `https://financialmodelingprep.com/stable/search-symbol?query=${query}&limit=10&exchange=NASDAQ&apikey=${apiKey}`
    );
    return data;
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
    const data = await axios.get<CompanyProfile[]>(
      `https://financialmodelingprep.com/stable/profile/${query}?apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getKeyMetrics = async (query: string) => {
  try {
    const data = await axios.get<CompanyKeyMetrics[]>(
      `https://financialmodelingprep.com/stable/key-metrics-ttm/${query}?limit=40&apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getIncomeStatement = async (query: string) => {
  try {
    const data = await axios.get<CompanyIncomeStatement[]>(
      `https://financialmodelingprep.com/stable/income-statement/${query}?limit=50&apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getBalanceSheet = async (query: string) => {
  try {
    const data = await axios.get<CompanyBalanceSheet[]>(
      `https://financialmodelingprep.com/stable/balance-sheet-statement/${query}?limit=20&apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getCashFlow = async (query: string) => {
  try {
    const data = await axios.get<CompanyCashFlow[]>(
      `https://financialmodelingprep.com/stable/cash-flow-statement/${query}?limit=100&apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getCompData = async (query: string) => {
  try {
    const data = await axios.get<CompanyCompData[]>(
      `https://financialmodelingprep.com/api/v4/stock_peers?symbol=${query}&apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getTenK = async (query: string) => {
  try {
    const data = await axios.get<CompanyTenK[]>(
      `https://financialmodelingprep.com/stable/sec_filings/${query}?type=10-K&page=0&apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};

export const getHistoricalDividend = async (query: string) => {
  try {
    const data = await axios.get<CompanyHistoricalDividend>(
      `https://financialmodelingprep.com/stable/historical-price-full/stock_dividend/${query}?apikey=${apiKey}`
    );
    return data;
  } catch (error: any) {
    console.error("error message: ", error.message);
  }
};
