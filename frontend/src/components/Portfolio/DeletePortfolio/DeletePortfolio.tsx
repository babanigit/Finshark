import { FormEvent } from "react";

interface Props {
  onPortfolioDelete: (e: FormEvent<HTMLFormElement>) => void;
  portfolioValue: string;
}

const DeletePortfolio = ({ onPortfolioDelete, portfolioValue }: Props) => {
  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    const confirmDelete = window.confirm(
      `Are you sure you want to delete portfolio: ${portfolioValue}?`
    );

    if (!confirmDelete) {
      e.preventDefault(); // Stop the form from submitting
      return;
    }

    onPortfolioDelete(e); // Proceed if confirmed
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input type="hidden" value={portfolioValue} name="portfolioValue" />
        <button
          type="submit"
          className="block w-16 py-3 duration-200 border-2 rounded-lg bg-red-400 bg-opacity-50 hover:bg-red-400"
        >
          X
        </button>
      </form>
    </div>
  );
};

export default DeletePortfolio;
