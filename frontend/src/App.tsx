import { Outlet } from "react-router-dom";
import Navbar from "./pages/Navbar/Navbar";

const App = () => {
  return (
    <>
      <Navbar />
      <Outlet />
      <div> footer </div>
    </>
  );
};

export default App;
