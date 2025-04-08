import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";

const api = "http://13.201.166.186:5222/api/";

// Create a default Axios instance with credentials enabled
const axiosInstance = axios.create({
  baseURL: api,
  withCredentials: true,  // ✅ Allows sending cookies and headers
  headers: {
    "Content-Type": "application/json",
  },
});

export const loginAPI = async (username: string, password: string) => {
  try {
    const data = await axiosInstance.post<UserProfileToken>("account/login", {
      username: username,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const registerAPI = async (
  email: string,
  username: string,
  password: string
) => {
  try {
    const data = await axiosInstance.post<UserProfileToken>("account/register", {
      email: email,
      username: username,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};
