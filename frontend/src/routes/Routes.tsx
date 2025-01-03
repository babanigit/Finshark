import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../pages/HomePage/HomePage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "login", element: <> login_page </> },
      { path: "register", element: <> register_page </> },
      { path: "search", element: <> protected search </> },
      { path: "design-guide", element: <> design_guide </> },
    ],
  },
]);
