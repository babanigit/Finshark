import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";

const api = import.meta.env.VITE_BACKEND_API_URL ;

console.log(" the api link is :- ", api);

// Create a default Axios instance with credentials enabled
const axiosInstance = axios.create({
  baseURL: api,
  withCredentials: true, // ✅ Allows sending cookies and headers
  headers: {
    "Content-Type": "application/json",
  },
});

export const loginAPI = async (username: string, password: string) => {
  try {
    const data = await axiosInstance.post<UserProfileToken>(api + "account/login", {
      username: username,
      password: password,
    });
    return data;
  } catch (error) {
    console.log("[bab] --- error from  loginAPI");
    handleError(error);
  }
};

export const registerAPI = async (
  email: string,
  username: string,
  password: string
) => {
  try {
    const data = await axiosInstance.post<UserProfileToken>(
      api + "account/register",
      {
        email: email,
        username: username,
        password: password,
      }
    );
    return data;
  } catch (error) {
    console.log("[bab] --- error from  registerAPI");
    handleError(error);
  }
};
