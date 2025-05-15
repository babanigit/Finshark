import { useEffect, useState } from "react";
import { useOutletContext } from "react-router-dom";
import { getHistoricalDividend } from "../../api";
// import Spinner from "../Spinners/Spinner";
import SimpleLineChart from "../SimpleLineChart/SimpleLineChart";
import { Dividend } from "../../company";

const HistoricalDividend = () => {
  const ticker = useOutletContext<string>();
  const [dividend, setDividend] = useState<Dividend[]>();
  useState<boolean>(false);
  useEffect(() => {
    const fetchHistoricalDividend = async () => {
      const value = await getHistoricalDividend(ticker);
      setDividend(
        value?.data.historical.slice(0, 18).sort(function (a, b) {
          const c = new Date(a.date);
          const d = new Date(b.date);
          return c.getTime() - d.getTime();
        })
      );
      console.log("✅ the dividend is:-0 ", dividend)
    };
    fetchHistoricalDividend();
  }, []);
  return (
    <>
      {dividend && dividend.length > 0 && dividend !== undefined ? (
        <SimpleLineChart data={dividend} xAxis="label" dataKey="dividend" />
      ) : (
        <h1 className="ml-3">Company does not have a dividend!</h1>
      )}
    </>
  );
};

export default HistoricalDividend;
