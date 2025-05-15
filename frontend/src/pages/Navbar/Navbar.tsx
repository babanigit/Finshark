import { Link } from "react-router-dom";
import logo from "./logo2.png";
import "./Navbar.css";
import { useAuth } from "../../Context/useAuth";

import { CiLight } from "react-icons/ci";
import { MdDarkMode } from "react-icons/md";
import { ThemeDataType } from "../../assets/theme";
import { useContext, useState } from "react";
import { SetThemeContext } from "../../App";

interface INavBarProps {
  theme: ThemeDataType;
}

const Navbar = ({ theme }: INavBarProps) => {
  const { isLoggedIn, user, logout } = useAuth();

  const setT = useContext(SetThemeContext);
  const [currTheme, setCurrTheme] = useState(theme.name);

  function changeTheme() {
    if (currTheme === "light") {
      setT("dark");
      setCurrTheme("dark");
    } else {
      setT("light");
      setCurrTheme("light");
    }
  }

  return (
    <nav className="  rounded-lg relative container mx-auto p-6">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          <Link to="/">
            <img className=" w-16 rounded-lg " src={logo} alt="" />
          </Link>
          <div className="hidden font-bold lg:flex">
            <Link
              to="/search"
              className=" hover:text-darkBlue hover:bg-opacity-50"
            >
              Search
            </Link>
          </div>
        </div>

        <div className=" flex gap-8">
          {isLoggedIn() ? (
            <div className="hidden lg:flex items-center space-x-6 text-back">
              <div className="hover:text-darkBlue hover:bg-opacity-50 ">
                Welcome,
                {user?.userName}
              </div>
              <a
                onClick={logout}
                style={{ cursor: "pointer" }}
                className="px-8 py-3 font-bold rounded bg-blue-400 bg-opacity-50 hover:bg-blue-400 "
              >
                Logout
              </a>
            </div>
          ) : (
            <div className="hidden lg:flex items-center space-x-6 text-back">
              <Link to="/login" className="hover:text-darkBlue">
                Login
              </Link>
              <Link
                to="/register"
                className="px-8 py-3 font-bold rounded bg-blue-400 bg-opacity-50 hover:bg-blue-400"
              >
                Signup
              </Link>
            </div>
          )}

          <div className=" grid text-right">
            <button style={{ color: theme.text }} onClick={changeTheme}>
              {theme.name === "light" ? (
                <MdDarkMode size={23} />
              ) : (
                <CiLight size={23} />
              )}
            </button>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
