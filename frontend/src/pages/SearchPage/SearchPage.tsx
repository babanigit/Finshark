import {
  useState,
  ChangeEvent,
  SyntheticEvent,
  useEffect,
  FormEvent,
} from "react";
import { CompanySearch } from "../../company";
import { searchCompanies } from "../../api";
import Search from "../../components/Search/Search";
import ListPortfolio from "../../components/Portfolio/ListPortfolio/ListPortfolio";
import CardList from "../../components/CardList/CardList";
import { PortfolioGet } from "../../Models/Portfolio";
import {
  portfolioAddAPI,
  portfolioDeleteAPI,
  portfolioGetAPI,
} from "../../Services/PortfolioService";
import { toast } from "react-toastify";

const SearchPage = () => {
  const [search, setSearch] = useState<string>("");
  const [portfolioValues, setPortfolioValues] = useState<PortfolioGet[] | null>(
    []
  );
  const [searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

  useEffect(() => {
    getPortfolio();
  }, []);

  const handleSearchChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
  };

  const getPortfolio = () => {
    portfolioGetAPI()
      .then((res) => {
        if (res?.data) {
          setPortfolioValues(res?.data);
        }
      })
      .catch((e) => {
        console.error("error in getPortfolio ,: ", e);
        setPortfolioValues(null);
      });
  };

  const onPortfolioCreate = (e: FormEvent<HTMLFormElement>) => {
    console.log("onPortfolioCreate clicked")
    e.preventDefault();
    const form = e.currentTarget;
    const stockValue = form.elements[0] as HTMLInputElement; // Access the first input element
    portfolioAddAPI(stockValue.value)
      .then((res) => {
        if (res?.status === 204) {
          toast.success("Stock added to portfolio!");
          getPortfolio();
        }
      })
      .catch((e) => {
        console.error("error in onPortfolioCreate ,: ", e);
        toast.warning("Could not add stock to portfolio :- ", e);
      });
  };

  const onPortfolioDelete = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const form = e.currentTarget;
    const stockValue = form.elements[0] as HTMLInputElement; // Access the first input element

    portfolioDeleteAPI(stockValue.value).then((res) => {
      if (res?.status == 200) {
        toast.success("Stock deleted from portfolio!");
        getPortfolio();
      }
    });
  };

  const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompanies(search);
    //setServerError(result.data);
    if (typeof result === "string") {
      setServerError(result);
    } else if (Array.isArray(result.data)) {
      setSearchResult(result.data);
    }
  };
  return (
    <>
      <Search
        onSearchSubmit={onSearchSubmit}
        search={search}
        handleSearchChange={handleSearchChange}
      />
      <ListPortfolio
        portfolioValues={portfolioValues!}
        onPortfolioDelete={onPortfolioDelete}
      />
      <CardList
        searchResults={searchResult}
        onPortfolioCreate={onPortfolioCreate}
      />
      {serverError && <div>Unable to connect to API</div>}
    </>
  );
};

export default SearchPage;
