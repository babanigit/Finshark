import { useEffect, useState } from "react";
import CompFinderItem from "./CompFinderItem/CompFinderItem";
import { CompanyCompData } from "../../company";
import { getCompData } from "../../api";

type Props = {
  ticker: string;
};

const CompFinder = ({ ticker }: Props) => {
  const [companyData, setCompanyData] = useState<CompanyCompData>();
  const [error, setError] = useState<string>("");

  useEffect(() => {
    const getComps = async () => {
      try {
        const value = await getCompData(ticker);
        console.log(" the compFinder1 error is:- ", value);

        if (value?.data[0]) {
          setCompanyData(value.data[0]);
          setError(""); // Clear any previous errors
        } else {
          setError("Company data not Available ");
        }
      } catch (err) {
        console.error(err);
      }
    };
    getComps();
  }, [ticker]);

  if (error) {
    return <div className="m-4 p-4  rounded-md">{error}</div>;
  }

  return (
    <div className="inline-flex rounded-md shadow-sm m-4" role="group">
      {Array.isArray(companyData?.peersList) && companyData ? (
        companyData?.peersList.map((ticker) => {
          return <CompFinderItem key={ticker} ticker={ticker} />;
        })
      ) : (
        <div className="text-black">Loading...</div>
      )}
    </div>
  );
};

export default CompFinder;
