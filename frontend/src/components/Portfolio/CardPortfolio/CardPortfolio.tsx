import  { FormEvent } from "react";
import { Link } from "react-router-dom";
import { PortfolioGet } from "../../../Models/Portfolio";
import DeletePortfolio from "../DeletePortfolio/DeletePortfolio";

interface Props {
  portfolioValue: PortfolioGet;
  onPortfolioDelete: (e: FormEvent<HTMLFormElement>) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
  return (
    <div className="border-4 border-gray-400 flex flex-col p-6 space-y-4 text-center rounded-lg w-full max-w-sm shadow-lg bg-white">
    {/* Company Name & Symbol */}
    <Link
      to={`/company/${portfolioValue.symbol}/company-profile`}
      className="pt-4 text-xl font-bold text-blue-600 hover:underline"
    >
      {portfolioValue.companyName} ({portfolioValue.symbol})
    </Link>

    {/* Industry */}
    <p className="text-gray-600 text-sm">{portfolioValue.industry}</p>

    {/* Market Cap & Purchase Price */}
    <div className="flex flex-col text-sm space-y-2">
      <p>
        <span className="font-semibold">Market Cap:</span> $
        {portfolioValue.marketCap.toLocaleString()}
      </p>
      <p>
        <span className="font-semibold">Purchase Price:</span> $
        {portfolioValue.purchase.toFixed(2)}
      </p>
    </div>

    {/* Delete Portfolio Button */}
    <DeletePortfolio
      portfolioValue={portfolioValue.symbol}
      onPortfolioDelete={onPortfolioDelete}
    />
  </div>
  );
};

export default CardPortfolio;
