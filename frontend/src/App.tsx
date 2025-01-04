import { Outlet } from "react-router-dom";
import Navbar from "./pages/Navbar/Navbar";
import { UserProvider } from "./Context/useAuth";
import { ToastContainer } from "react-toastify";

const App = () => {
  return (
    <>
      <UserProvider>
        <Navbar />
        <Outlet />
        <ToastContainer />
      </UserProvider>
    </>
  );
};

export default App;
