import { useEffect, useState } from "react";
import { useOutletContext } from "react-router-dom";
import { CompanyKeyMetrics } from "../../company";
import { getKeyMetrics } from "../../api";
import RatioList from "../RatioList/RatioList";
import Spinner from "../Spinners/Spinner";
import {
  formatLargeNonMonetaryNumber,
  formatRatio,
} from "../../Helpers/NumberFormatting";
import StockComment from "../StockComment/StockComment";
// import StockComment from "../StockComment/StockComment";

const tableConfig = [
  {
    label: "Market Cap",
    render: (company: CompanyKeyMetrics) =>
      formatLargeNonMonetaryNumber(company.marketCap),
    subTitle: "Total value of all a company's shares of stock",
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) => formatRatio(company.currentRatio),
    subTitle:
      "Measures the companies ability to pay short term debt obligations",
  },
  {
    label: "Return On Equity",
    render: (company: CompanyKeyMetrics) => formatRatio(company.returnOnEquity),
    subTitle:
      "Return on equity is the measure of a company's net income divided by its shareholder's equity",
  },
  {
    label: "Return On Assets",
    render: (company: CompanyKeyMetrics) => formatRatio(company.returnOnAssets),
    subTitle:
      "Return on assets is the measure of how effective a company is using its assets",
  },
  {
    label: "Free Cashflow Per Share",
    render: (company: CompanyKeyMetrics) =>
      formatRatio(company.freeCashFlowToEquity),
    subTitle:
      "Return on assets is the measure of how effective a company is using its assets (free cash flow to equaity) ",
  },
  {
    label: "Book Value Per Share TTM",
    render: (company: CompanyKeyMetrics) =>
      formatRatio(company.tangibleAssetValue),
    subTitle:
      "Book value per share indicates a firm's net asset value (total assets - total liabilities) on per share basis (tangibleAssetValue) ",
  },
  {
    label: "Divdend Yield TTM",
    render: (company: CompanyKeyMetrics) => formatRatio(company.earningsYield),
    subTitle:
      "Shows how much a company pays each year relative to stock price (earningsYield) ",
  },
  {
    label: "Capex Per Share TTM",
    render: (company: CompanyKeyMetrics) =>
      formatRatio(company.capexToOperatingCashFlow),
    subTitle:
      "Capex is used by a company to aquire, upgrade, and maintain physical assets (capexToOperatingCashFlow) ",
  },
  {
    label: "Graham Number",
    render: (company: CompanyKeyMetrics) => formatRatio(company.grahamNumber),
    subTitle:
      "This is the upperbouind of the price range that a defensive investor should pay for a stock",
  },
  {
    label: "PE Ratio",
    render: (company: CompanyKeyMetrics) => formatRatio(company.currentRatio),
    subTitle:
      "This is the upperbouind of the price range that a defensive investor should pay for a stock (currentRatio) ",
  },
];

const CompanyProfile = () => {
  const ticker = useOutletContext<string>();
  const [companyData, setCompanyData] = useState<
    CompanyKeyMetrics | undefined
  >();
  useEffect(() => {
    const getCompanyKeyRatios = async () => {
      const value = await getKeyMetrics(ticker);

      setCompanyData(value);

      console.log("companyData", companyData);
    };
    getCompanyKeyRatios();
  }, []);
  return (
    <>
      {companyData ? (
        <>
          <RatioList config={tableConfig} data={companyData} />
          {/* <StockComment stockSymbol={ticker} /> */}
        </>
      ) : (
        <>
          <Spinner /> hello 3
        </>
      )}

      {/* <div> hello getKeyMetrics</div> */}
    </>
  );
};

export default CompanyProfile;
