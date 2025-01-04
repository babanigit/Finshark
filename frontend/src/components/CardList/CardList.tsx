import React, { FormEvent } from "react";
import { CompanySearch } from "../../company";
import { v4 as uuidv4 } from "uuid";
import Card from "../Card/Card";

interface Props {
  searchResults: CompanySearch[];
  onPortfolioCreate: (e: FormEvent<HTMLFormElement>) => void;
}

const CardList: React.FC<Props> = ({
  searchResults,
  onPortfolioCreate,
}: Props): JSX.Element => {
  return (
    <div>
      {searchResults.length > 0 ? (
        searchResults.map((result) => {
          return (
                <Card
                  id={result.symbol}
                  key={uuidv4()}
                  searchResult={result}
                  onPortfolioCreate={onPortfolioCreate}
                />
          );
        })
      ) : (
        <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
          No results!
        </p>
      )}
    </div>
  );
};

export default CardList;
