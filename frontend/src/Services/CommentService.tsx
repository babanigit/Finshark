import axios from "axios";
import { CommentGet, CommentPost } from "../Models/Comment";
import { handleError } from "../Helpers/ErrorHandler";

// const api = "http://13.201.166.186:5222/api/comment/";
// const api = "http://localhost:5222/api/comment/";

// if (import.meta.env.ENV_DOTNET === "dev") {
// }

const api = import.meta.env.VITE_DOTNET_API_URL + "comments/" || "http://localhost:5222/api/comments/";


export const commentPostAPI = async (
  title: string,
  content: string,
  symbol: string
) => {
  try {
    const data = await axios.post<CommentPost>(api + `${symbol}`, {
      title: title,
      content: content,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const commentGetAPI = async (symbol: string) => {
  try {
    const data = await axios.get<CommentGet[]>(api + `?Symbol=${symbol}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};
