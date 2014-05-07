// Refactor the following code to apply variable usage and naming best practices

namespace Statistics
{
    using System;

    /// <summary>
    /// Code that establish a statistical object, load data and accomplish some statistical routines over data.
    /// </summary>
    public class StatisticsCalculation
    {
        /// <summary>
        /// Main executable routine of the code.
        /// </summary>
        public static void Main()
        {
            StatisticsUtils statisticsData = new StatisticsUtils();
            double[] statistics = { 1.4, -3.4, 0, 2, 3, 4.7, -0.5, 6, 17.7 };
            int statisticsDataCount = statistics.Length;
            statisticsData.MaximalValue(statistics, statisticsDataCount);
            statisticsData.MinimalValue(statistics, statisticsDataCount);
            statisticsData.CalculateAverageValue(statistics, statisticsDataCount);
        }
    }
}
