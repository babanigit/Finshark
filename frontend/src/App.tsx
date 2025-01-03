import { Outlet } from "react-router-dom";

const App = () => {
  return (
    <>
      <div> navbar </div>
      <Outlet />
      <div> footer </div>
    </>
  );
};

export default App;
