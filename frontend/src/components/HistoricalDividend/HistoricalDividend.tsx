import { useEffect, useState } from "react";
import { useOutletContext } from "react-router-dom";
import { getHistoricalDividend } from "../../api";
// import Spinner from "../Spinners/Spinner";
import SimpleLineChart from "../SimpleLineChart/SimpleLineChart";
import {
  HistoricalPriceEntry,
  HistoricalPriceResponse,
} from "../../Models/Historic_Divident";
// import { Dividend } from "../../company";

const HistoricalDividend = () => {
  const ticker = useOutletContext<string>();
  const [dividend, setDividend] = useState<HistoricalPriceEntry[]>();
  useState<boolean>(false);
  useEffect(() => {
    const fetchHistoricalDividend = async () => {
      const value = await getHistoricalDividend(ticker);


      setDividend(
        value?.data.slice(0, 300).sort(function (a, b) {
          const c = new Date(a.date);
          const d = new Date(b.date);
          return c.getTime() - d.getTime();
        }),

        //  value?.data
      );
    };
    fetchHistoricalDividend();

  }, []);
  return (
    <>
      {dividend && dividend.length > 0 ? (
        <SimpleLineChart data={dividend} />
      ) : (
        <h1 className="ml-3">Company does not have a historical dividend!</h1>
      )}
    </>
  );
};

export default HistoricalDividend;
