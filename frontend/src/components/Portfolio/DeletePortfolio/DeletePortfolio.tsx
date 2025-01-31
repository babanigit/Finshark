import  { FormEvent } from "react";

interface Props {
  onPortfolioDelete: (e: FormEvent<HTMLFormElement>) => void;
  portfolioValue: string;
}

const DeletePortfolio = ({ onPortfolioDelete, portfolioValue }: Props) => {
  return (
    <div>
      <form onSubmit={onPortfolioDelete}>
        <input hidden={true} value={portfolioValue} />
        <button className="block w-full py-3 text-black duration-200 border-2 rounded-lg bg-red-100 hover:text-red-500 hover:bg-white border-red-500">
          X
        </button>
      </form>
    </div>
  );
};

export default DeletePortfolio;
