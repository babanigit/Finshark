import { FormEvent } from "react";
import CardPortfolio from "../CardPortfolio/CardPortfolio";
import { PortfolioGet } from "../../../Models/Portfolio";

interface Props {
  portfolioValues: PortfolioGet[];
  onPortfolioDelete: (e: FormEvent<HTMLFormElement>) => void;
}

const ListPortfolio = ({ portfolioValues, onPortfolioDelete }: Props) => {
  return (
    <section id="portfolio">
      <h2 className="mb-3 mt-3 text-3xl font-semibold text-center md:text-4xl">
        My Portfolio
      </h2>
      <div className="container mx-auto px-4">
        <div className="flex flex-wrap justify-center gap-4">
          {portfolioValues.length > 0 ? (
            portfolioValues.map((portfolioValue) => (
              <CardPortfolio
                key={portfolioValue.id} // Make sure to add a key prop
                portfolioValue={portfolioValue}
                onPortfolioDelete={onPortfolioDelete}
              />
            ))
          ) : (
            <h3 className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
              Your portfolio is empty.
            </h3>
          )}
        </div>
      </div>
    </section>
  );
};

export default ListPortfolio;