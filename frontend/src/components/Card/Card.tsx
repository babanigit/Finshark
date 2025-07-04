import React, { FormEvent } from "react";
import { Link } from "react-router-dom";
import "./Card.css";
import { CompanySearch } from "../../company";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";

interface Props {
  id: string;
  searchResult: CompanySearch;
  onPortfolioCreate: (e: FormEvent<HTMLFormElement>) => void;
}

const Card: React.FC<Props> = ({
  id,
  searchResult,
  onPortfolioCreate,
}: Props): JSX.Element => {
  return (
    <div
    className="flex flex-col items-center justify-between p-6 m-2 rounded-lg md:flex-row border border-gray-500 box-border"
    key={id}
    id={id}
  >
      <Link
        to={`/company/${searchResult.symbol}/company-profile`}
        className="font-bold text-center text-veryDarkViolet md:text-left"
      >
        {searchResult.name} ({searchResult.symbol})
      </Link>
      <p className="text-veryDarkBlue">{searchResult.currency}</p>
      <p className="font-bold text-veryDarkBlue">
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </p>
      <AddPortfolio
        onPortfolioCreate={onPortfolioCreate}
        symbol={searchResult.symbol}
      />
    </div>
  );
};

export default Card;
