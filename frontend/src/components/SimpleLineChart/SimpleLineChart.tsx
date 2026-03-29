import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  Legend,
  ResponsiveContainer,
} from "recharts";
import { HistoricalPriceEntry } from "../../Models/Historic_Divident";

type Props = {
  data: HistoricalPriceEntry[];
};

const SimpleLineChart = ({ data }: Props) => {
  // Sort by date ascending
  const sortedData = [...data].sort(
    (a, b) => new Date(a.date).getTime() - new Date(b.date).getTime(),
  );

  // Format date for X axis label
  const formatDate = (dateStr: string) => {
    const d = new Date(dateStr);
    return `${d.getMonth() + 1}/${d.getDate()}`;
  };

  return (
    <ResponsiveContainer width="99%" height={500}>
      <LineChart
        data={sortedData}
        margin={{ top: 20, right: 40, left: 10, bottom: 10 }}
      >
        <CartesianGrid strokeDasharray="3 3" stroke="#e0e0e0" />
        <XAxis
          dataKey="date"
          tickFormatter={formatDate}
          tick={{ fontSize: 12 }}
          label={{ value: "Date", position: "insideBottom", offset: -5 }}
        />
        <YAxis
          domain={["auto", "auto"]}
          tick={{ fontSize: 12 }}
          label={{ value: "Price (USD)", angle: -90, position: "insideLeft" }}
        />
        <Tooltip
          formatter={(value: number) => [`$${value.toFixed(2)}`]}
          labelFormatter={(label) => `Date: ${label}`}
        />
        <Legend verticalAlign="top" />
        <Line
          type="monotone"
          dataKey="close"
          name="Close"
          stroke="#8884d8"
          dot={false}
          activeDot={{ r: 6 }}
        />
        <Line
          type="monotone"
          dataKey="open"
          name="Open"
          stroke="#82ca9d"
          dot={false}
          activeDot={{ r: 6 }}
        />
        <Line
          type="monotone"
          dataKey="high"
          name="High"
          stroke="#ff7300"
          dot={false}
          activeDot={{ r: 6 }}
        />
        <Line
          type="monotone"
          dataKey="low"
          name="Low"
          stroke="#ff0000"
          dot={false}
          activeDot={{ r: 6 }}
        />
      </LineChart>
    </ResponsiveContainer>
  );
};

export default SimpleLineChart;
