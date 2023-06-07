namespace BrickSchema.Net.Shapes
{
    public class Aggregation : BrickShape
    {

        public enum AggregationMode
        {
            Min,
            Count,
            Mean,
            Sum,
            Median,
            Mode
        }

        public static List<double> AggregateByInterval(List<(DateTime Timestamp, double Value)> timeSeriesData, int intervalInMinutes, AggregationMode mode)
        {
            var resampledData = ResampleData(timeSeriesData, intervalInMinutes);
            var aggregatedData = new List<double>();
            DateTime startTime = resampledData.First().Timestamp;
            DateTime endTime = resampledData.Last().Timestamp;

            for (DateTime current = startTime; current < endTime; current = current.AddMinutes(intervalInMinutes))
            {
                DateTime next = current.AddMinutes(intervalInMinutes);
                var dataSubset = resampledData.Where(x => x.Timestamp >= current && x.Timestamp < next)
                                               .Select(x => x.Value);

                if (!dataSubset.Any())
                {
                    continue;
                }

                switch (mode)
                {
                    case AggregationMode.Min:
                        aggregatedData.Add(Min(dataSubset));
                        break;
                    case AggregationMode.Count:
                        aggregatedData.Add(Count(dataSubset));
                        break;
                    case AggregationMode.Mean:
                        aggregatedData.Add(Mean(dataSubset));
                        break;
                    case AggregationMode.Sum:
                        aggregatedData.Add(Sum(dataSubset));
                        break;
                    case AggregationMode.Median:
                        aggregatedData.Add(Median(dataSubset));
                        break;
                    case AggregationMode.Mode:
                        aggregatedData.Add(Mode(dataSubset));
                        break;
                }
            }

            return aggregatedData;
        }

        private static List<(DateTime Timestamp, double Value)> ResampleData(List<(DateTime Timestamp, double Value)> timeSeriesData, int intervalInMinutes)
        {
            var resampledData = new List<(DateTime Timestamp, double Value)>();

            DateTime startTime = timeSeriesData.First().Timestamp;
            DateTime endTime = timeSeriesData.Last().Timestamp;

            for (DateTime current = startTime; current <= endTime; current = current.AddMinutes(intervalInMinutes))
            {
                double interpolatedValue = Interpolate(timeSeriesData, current);
                resampledData.Add((current, interpolatedValue));
            }

            return resampledData;
        }

        private static double Interpolate(List<(DateTime Timestamp, double Value)> timeSeriesData, DateTime targetTime)
        {
            if (timeSeriesData.Count == 1 || targetTime <= timeSeriesData.First().Timestamp)
            {
                return timeSeriesData.First().Value;
            }

            if (targetTime >= timeSeriesData.Last().Timestamp)
            {
                return timeSeriesData.Last().Value;
            }

            for (int i = 0; i < timeSeriesData.Count - 1; i++)
            {
                var currentDataPoint = timeSeriesData[i];
                var nextDataPoint = timeSeriesData[i + 1];

                if (targetTime >= currentDataPoint.Timestamp && targetTime <= nextDataPoint.Timestamp)
                {
                    double proportion = (targetTime - currentDataPoint.Timestamp).TotalMinutes / (nextDataPoint.Timestamp - currentDataPoint.Timestamp).TotalMinutes;
                    double interpolatedValue = currentDataPoint.Value + (nextDataPoint.Value - currentDataPoint.Value) * proportion;
                    return interpolatedValue;
                }
            }

            return 0;
        }

        public static double Max(IEnumerable<double> data)
        {
            return data.Max();
        }

        public static double Min(IEnumerable<double> data)
        {
            return data.Min();
        }

        public static int Count(IEnumerable<double> data)
        {
            return data.Count();
        }

        public static double Mean(IEnumerable<double> data)
        {
            return data.Average();
        }

        public static double Sum(IEnumerable<double> data)
        {
            return data.Sum();
        }

        public static double Median(IEnumerable<double> data)
        {
            var orderedData = data.OrderBy(x => x).ToList();
            int count = orderedData.Count;

            if (count % 2 == 0)
            {
                return (orderedData[count / 2 - 1] + orderedData[count / 2]) / 2;
            }
            else
            {
                return orderedData[count / 2];
            }
        }

        public static double Mode(IEnumerable<double> data)
        {
            var groupedData = data.GroupBy(x => x)
                                  .Select(x => new { Value = x.Key, Count = x.Count() })
                                  .OrderByDescending(x => x.Count)
                                  .ToList();

            if (groupedData.Count > 0)
            {
                return groupedData[0].Value;
            }
            else
            {
                throw new InvalidOperationException("The input data is empty.");
            }
        }
    }


}