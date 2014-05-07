namespace Statistics
{
    using System;

    /// <summary>
    /// A class posses some routines to operate over statistics data.
    /// </summary>
    public class StatisticsUtils
    {
        /// <summary>
        /// Finds the maximal value within the statistical data. 
        /// </summary>
        /// <param name="statisticFigures">Statistical data.</param>
        /// <param name="figuresCount">Number of values within the statistical data.</param>
        public void MaximalValue(double[] statisticFigures, int figuresCount)
        {
            double maximalValue = double.MinValue;

            for (int i = 0; i < figuresCount; i++)
            {
                if (statisticFigures[i] > maximalValue)
                {
                    maximalValue = statisticFigures[i];
                }
            }

            this.PrintResult("Maximal", maximalValue);
        }

        /// <summary>
        /// Finds the minimal value within the statistical data. 
        /// </summary>
        /// <param name="statisticFigures">Statistical data.</param>
        /// <param name="figuresCount">Number of values within the statistical data.</param>
        public void MinimalValue(double[] statisticFigures, int figuresCount)
        {
            double minimalValue = double.MinValue;
            for (int i = 0; i < figuresCount; i++)
            {
                if (statisticFigures[i] < minimalValue)
                {
                    minimalValue = statisticFigures[i];
                }
            }

            this.PrintResult("Minimal", minimalValue);
        }

        /// <summary>
        /// Calculate the average value from the statistical data values provided. 
        /// </summary>
        /// <param name="statisticFigures">Statistical data.</param>
        /// <param name="figuresCount">Number of values within the statistical data.</param>
        public void CalculateAverageValue(double[] statisticFigures, int figuresCount)
        {
            double sum = 0;
            for (int i = 0; i < figuresCount; i++)
            {
                sum += statisticFigures[i];
            }

            double averageResult = sum / figuresCount;
            this.PrintResult("Average", averageResult);
        }

        /// <summary>
        /// Prints on the console the value by prefix it with the corresponding operation header.
        /// </summary>
        /// <param name="operation">Operation header accomplished over data representing in System.String.</param>
        /// <param name="value">System.Double value to be printed</param>
        private void PrintResult(string operation, double value)
        {
            Console.WriteLine("{0} value = {1}", operation, value);
        }
    }
}
