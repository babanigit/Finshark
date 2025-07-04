import { useEffect, useState } from "react";
import { CompanyProfile } from "../../company";
import { useParams } from "react-router-dom";
import { getCompanyProfile } from "../../api";
import Sidebar from "../../components/Sidebar/Sidebar";
import CompanyDashboard from "../../components/CompanyDashboard/CompanyDashboard";
import Tile from "../../components/Tile/Tile";
import Spinner from "../../components/Spinners/Spinner";
import CompFinder from "../../components/CompFinder/CompFinder";
import TenKFinder from "../../components/TenKFinder/TenKFinder";

const CompanyPage = () => {
  const { ticker } = useParams();

  const [company, setCompany] = useState<CompanyProfile>();

  useEffect(() => {
    const getProfileInit = async () => {
      const result = await getCompanyProfile(ticker!);
      setCompany(result?.data[0]);
    };
    getProfileInit();
  }, []);

  return (
    <>
      {company ? (
        <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
          <Sidebar />
          <CompanyDashboard ticker={ticker!}>
            <Tile title="Company Name" subTitle={company.companyName} />
            <Tile title="Price" subTitle={"$" + company.price.toString()} />
            <Tile title="DCF" subTitle={"$" + company.dcf.toString()} />
            <Tile title="Sector" subTitle={company.sector} />
            <CompFinder ticker={company.symbol} />
            <TenKFinder ticker={company.symbol} />
            <p className=" shadow rounded text-medium font-medium border border-gray-500 p-3 mt-1 m-4">
              {company.description}
            </p>
          </CompanyDashboard>
        </div>
      ) : (
        <>
          <Spinner />
        </>
      )}
    </>
  );
};

export default CompanyPage;
