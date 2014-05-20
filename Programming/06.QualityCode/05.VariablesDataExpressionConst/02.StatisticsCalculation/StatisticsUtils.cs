namespace Statistics
{
    using System;

    /// <summary>
    /// A class with routines to operate over statistics data.
    /// </summary>
    public class StatisticsUtils
    {
        /// <summary>
        /// Finds the maximal value within the statistical data. 
        /// </summary>
        /// <param name="statisticFigures">Statistical data.</param>
        /// <param name="figuresCount">Number of values within the statistical data.</param>
        /// <returns>Maximal value in provided statistics data.</returns>
        public double MaximalValue(double[] statisticFigures, int figuresCount)
        {
            double maximalValue = double.MinValue;

            for (int i = 0; i < figuresCount; i++)
            {
                if (statisticFigures[i] > maximalValue)
                {
                    maximalValue = statisticFigures[i];
                }
            }

            return maximalValue;
        }

        /// <summary>
        /// Finds the minimal value within the statistical data. 
        /// </summary>
        /// <param name="statisticFigures">Statistical data.</param>
        /// <param name="figuresCount">Number of values within the statistical data.</param>
        /// <returns>Minimal value in provided statistics data.</returns>
        public double MinimalValue(double[] statisticFigures, int figuresCount)
        {
            double minimalValue = double.MinValue;
            for (int i = 0; i < figuresCount; i++)
            {
                if (statisticFigures[i] < minimalValue)
                {
                    minimalValue = statisticFigures[i];
                }
            }

            return minimalValue;
        }

        /// <summary>
        /// Calculate the average value from the statistical data values provided. 
        /// </summary>
        /// <param name="statisticFigures">Statistical data.</param>
        /// <param name="figuresCount">Number of values within the statistical data.</param>
        /// <returns>Average value of provided statistics data.</returns>
        public double CalculateAverageValue(double[] statisticFigures, int figuresCount)
        {
            double sumOfElements = 0;
            for (int i = 0; i < figuresCount; i++)
            {
                sumOfElements += statisticFigures[i];
            }

            return sumOfElements / figuresCount;
        }
    }
}
