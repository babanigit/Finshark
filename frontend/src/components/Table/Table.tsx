type Props = {
  config: any;
  data: any;
};

const Table = ({ config = [], data = [] }: Props) => {
  const renderedRows = data.map((company: any) => {
    return (
      <tr key={company.cik}>
        {config.map((val: any) => {
          return <td className="p-3">{val.render(company)}</td>;
        })}
      </tr>
    );
  });
  const renderedHeaders = config.map((config: any) => {
    return (
      <th
        className=" border p-4 text-left text-xs font-medium uppercase tracking-wider"
        key={config.label}
      >
        {config.label}
      </th>
    );
  });
  return (
    <div className=" border border-gray-500 shadow rounded-lg p-4 sm:p-6 xl:p-8 ">
      <table className="min-w-full divide-y divide-gray-500 border border-gray-500 m-5">
        <thead className="bg-gray-400 bg-opacity-50 ">{renderedHeaders}</thead>
        <tbody className="   "  >{renderedRows}</tbody>
      </table>
    </div>
  );
};

export default Table;
