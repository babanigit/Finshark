import { Outlet } from "react-router-dom";
import Navbar from "./pages/Navbar/Navbar";
import { UserProvider } from "./Context/useAuth";
import { ToastContainer } from "react-toastify";

import { ThemeProvider } from "styled-components";
import { themes } from "./assets/theme";
import { createContext, useState } from "react";

interface SetThemeContextType {
  (value: string): void;
}

export const SetThemeContext = createContext<SetThemeContextType>(() => {});

const App = () => {
  const [themeState, setThemeState] = useState<string>("dark");

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
