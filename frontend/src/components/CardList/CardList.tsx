import React, { FormEvent } from "react";
import { CompanySearch } from "../../company";
import { v4 as uuidv4 } from "uuid";
import Card from "../Card/Card";

interface Props {
  searchResults: CompanySearch[];
  search: string | undefined;
  onPortfolioCreate: (e: FormEvent<HTMLFormElement>) => void;
}

const CardList: React.FC<Props> = ({
  searchResults = [],
  onPortfolioCreate,
  search,
}: Props): JSX.Element => {
  return (
    <div>
      {searchResults.length > 0 && search!.length !== 0 ? (
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
        <p className="mb-3 text-gray-400 mt-3 text-xl font-semibold text-center md:text-xl">
          Search the Company to add to your Portfolio
        </p>
      )}
    </div>
  );
};

export default CardList;
