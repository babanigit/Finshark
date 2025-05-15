import { Link } from "react-router-dom";
import hero from "./hero2.png";
import "./Hero.css";

const Hero = () => {
  return (
    <section id="hero">
      <div className="container flex flex-col-reverse mx-auto p-8 lg:flex-row">
        <div className="flex flex-col space-y-10 mb-44 m-10 lg:m-10 xl:m-20 lg:mt:16 lg:w-1/2 xl:mb-52">
          <h1 className="text-5xl font-bold text-center lg:text-6xl lg:max-w-md lg:text-left">
            Objective financial insights without the noise.
          </h1>
          <p className="text-2xl text-center  lg:max-w-md lg:text-left">
            Discover trustworthy financial documents—no hype, no fear, just
            facts.
          </p>
          <div className="mx-auto lg:mx-0">
            <Link
              to="/search"
              className="py-5 px-10 text-2xl font-bold bg-blue-400 bg-opacity-50 rounded lg:py-4 hover:opacity-70"
            >
              Get Started
            </Link>
          </div>
        </div>
        <div className="mb-24 mx-auto md:w-180 md:px-10 lg:mb-0 lg:w-1/2">
          <img src={hero} alt="" className=" rounded-3xl" />
        </div>
      </div>
    </section>
  );
};

export default Hero;
