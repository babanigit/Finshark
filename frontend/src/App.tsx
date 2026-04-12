import { Outlet } from "react-router-dom";
import Navbar from "./pages/Navbar/Navbar";
import { UserProvider } from "./Context/useAuth";
import { ToastContainer } from "react-toastify";

import { ThemeProvider } from "styled-components";
import { themes } from "./assets/theme";
import { createContext, useEffect, useState } from "react";

interface SetThemeContextType {
  (value: string): void;
}

export const SetThemeContext = createContext<SetThemeContextType>(() => {});

const api = import.meta.env.VITE_BACKEND_API_URL || "" ;

console.log(" the api link is :- ", api);


const App = () => {
  const [themeState, setThemeState] = useState<string>("dark");

  useEffect(() => {
    
    // hit the server to check if it's up
    fetch(`${api}api/status`)
      .then((response) => response.json())
      .then((data) => console.log(data))
      .catch((error) => console.error("Error fetching status:", error));

  }, []);

  return (
  
      <div
      className="h-100"
      style={{
        minHeight: "100vh", // or height: "100vh"
          backgroundColor: themes[themeState].body,
          color: themes[themeState].text,
          borderColor: themes[themeState].text,
        }}
      >
        <ThemeProvider theme={themes[themeState]}>
          <SetThemeContext.Provider value={setThemeState}>
            <UserProvider>
              <Navbar theme={themes[themeState]} />
              <Outlet />
              <ToastContainer />
            </UserProvider>
          </SetThemeContext.Provider>
        </ThemeProvider>
      </div>
  
  );
};

export default App;
