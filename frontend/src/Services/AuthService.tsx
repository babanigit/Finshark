// import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { UserProfileToken } from "../Models/User";

const api = import.meta.env.VITE_BACKEND_API_URL || "";

console.log(" the api link is :- ", api);

export const loginAPI = async (username: string, password: string) => {
  try {
    const res = await fetch(`${api}account/login`, {
      method: "POST",
      credentials: "include", // ✅ same as withCredentials
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        username,
        password,
      }),
    });

    if (!res.ok) {
      throw new Error("Login failed");
    }

    const data: UserProfileToken = await res.json();
    return { data }; // mimic axios response shape
  } catch (error) {
    console.log("[bab] --- error from loginAPI");
    handleError(error);
  }
};



export const registerAPI = async (
  email: string,
  username: string,
  password: string
) => {
  try {
    const res = await fetch(`${api}account/register`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        email,
        username,
        password,
      }),
    });

    if (!res.ok) {
      throw new Error("Registration failed");
    }

    const data: UserProfileToken = await res.json();
    return { data };
  } catch (error) {
    console.log("[bab] --- error from registerAPI");
    handleError(error);
  }
};

