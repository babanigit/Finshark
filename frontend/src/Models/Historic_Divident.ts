// types/historicalPrice.ts

// Core data entry
export interface HistoricalPriceEntry {
  symbol: string;
  date: string;
  open: number;
  high: number;
  low: number;
  close: number;
  volume: number;
  change: number;
  changePercent: number;
  vwap: number;
}

// Axios config headers
export interface AxiosConfigHeaders {
  Accept: string;
  Authorization: string;
}

// Axios transitional config
export interface AxiosTransitional {
  silentJSONParsing: boolean;
  forcedJSONParsing: boolean;
  clarifyTimeoutError: boolean;
}

// Axios request config
export interface AxiosRequestConfig {
  transitional: AxiosTransitional;
  adapter: string[];
  // eslint-disable-next-line @typescript-eslint/no-unsafe-function-type
  transformRequest: (null | Function)[];
  // eslint-disable-next-line @typescript-eslint/no-unsafe-function-type
  transformResponse: (null | Function)[];
  timeout: number;
  xsrfCookieName: string;
  xsrfHeaderName: string;
  maxContentLength: number;
  maxBodyLength: number;
  env: Record<string, unknown>;
  headers: AxiosConfigHeaders;
  method: string;
  url: string;
}

// Response headers
export interface ResponseHeaders {
  "content-type": string;
}

// Full axios response wrapper
export interface HistoricalPriceResponse {
  data: HistoricalPriceEntry[];
  status: number;
  statusText: string;
  headers: ResponseHeaders;
  config: AxiosRequestConfig;
  request: Record<string, unknown>;
}