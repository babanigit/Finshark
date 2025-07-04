import { FormEvent } from "react";

interface Props {
  onPortfolioCreate: (e: FormEvent<HTMLFormElement>) => void;
  symbol: string;
}

const AddPortfolio = ({ onPortfolioCreate, symbol }: Props) => {
  return (
    <div className="flex flex-col items-center justify-end flex-1 space-x-4 space-y-2 md:flex-row md:space-y-0">
      <form onSubmit={onPortfolioCreate}>
        <input readOnly={true} hidden={true} value={symbol} />
        <button
          type="submit"
          className="p-2 px-8 rounded bg-blue-400 bg-opacity-50 hover:bg-blue-400  focus:outline-none"
        >
          Add
        </button>
      </form>
    </div>
  );
};

export default AddPortfolio;
