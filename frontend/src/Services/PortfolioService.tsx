import axios from "axios";
import { PortfolioGet, PortfolioPost } from "../Models/Portfolio";
import { handleError } from "../Helpers/ErrorHandler";

// const api = "http://13.201.166.186:5222/api/portfolio/";
// const api = "http://localhost:5222/api/portfolio/";

// if (import.meta.env.ENV_DOTNET === "dev") {
// }

const api = import.meta.env.VITE_DOTNET_API_URL + "portfolio/" || "http://13.201.166.186:5222/api/portfolio/";


export const portfolioAddAPI = async (symbol: string) => {
  try {
    const data = await axios.post<PortfolioPost>(api + `?symbol=${symbol}`);
    return data;
  } catch (error) {
    handleError(error + "LOL portfolioAddAPI");
  }
};

export const portfolioDeleteAPI = async (symbol: string) => {
  try {
    const data = await axios.delete<PortfolioPost>(api + `?symbol=${symbol}`);
    return data;
  } catch (error) {
    handleError(error + "LOL portfolioDeleteAPI");
  }
};

export const portfolioGetAPI = async () => {
  try {
    const data = await axios.get<PortfolioGet[]>(api);
    return data;
  } catch (error) {
    handleError(error + "LOL portfolioGetAPI");
  }
};
