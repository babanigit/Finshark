import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../pages/HomePage/HomePage";
import LoginPage from "../pages/LoginPage/LoginPage";
import RegisterPage from "../pages/RegisterPage/RegisterPage";
import ProtectedRoute from "./ProtectedRoute";
import SearchPage from "../pages/SearchPage/SearchPage";
import DesignGuide from "../pages/DesignGuide/DesignGuide";
import CompanyPage from "../pages/CompanyPage/CompanyPage";
import CompanyProfile from "../components/CompanyProfile/CompanyProfile";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "login", element: <LoginPage /> },
      { path: "register", element: <RegisterPage /> },
      {
        path: "search",
        element: (
          <ProtectedRoute>
            <SearchPage />
          </ProtectedRoute>
        ),
      },
      { path: "design-guide", element: <DesignGuide /> },

      {
        path: "company/:ticker",
        element: (
          <ProtectedRoute>
            <CompanyPage />
          </ProtectedRoute>
        ),
        children: [
          { path: "company-profile", element: <CompanyProfile /> },
          // { path: "income-statement", element: <IncomeStatement /> },
          // { path: "balance-sheet", element: <BalanceSheet /> },
          // { path: "cashflow-statement", element: <CashflowStatement /> },
          // { path: "historical-dividend", element: <HistoricalDividend /> },
        ],
      },
    ],
  },
]);
