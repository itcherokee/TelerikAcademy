namespace BooleanConverter
{
    using System;

    internal class BooleanUtils
    {
        /// <summary>
        /// Prints input data to the Console
        /// </summary>
        /// <param name="inputData">Boolean value</param>
        internal void Print(bool inputData)
        {
            Console.WriteLine(this.ConvertBoolToString(inputData));
        }

        /// <summary>
        /// Converts boolean input data to string
        /// </summary>
        /// <param name="inputData">boolean value</param>
        /// <returns>String representation of boolean value</returns>
        private string ConvertBoolToString(bool inputData)
        {
            string convertedInputData = inputData.ToString();
            return convertedInputData;
        }
    }
}
