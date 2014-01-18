// Task description is in the solution folder
namespace KaspichanNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    public class KaspichanExec
    {
        public static void Main()
        {
            BigInteger numberToConvert = BigInteger.Parse(Console.ReadLine());
            string convertedToKapichan = ConvertFromTen(numberToConvert, 256);
            Console.WriteLine(convertedToKapichan);
        }

        // Converts the number from Decimal to requested numeral system
        private static string ConvertFromTen(BigInteger numberToConvert, int toBase)
        {
            StringBuilder convertedNumber = new StringBuilder();
            List<int> result = new List<int>();
            if (numberToConvert > 0)
            {
                while (numberToConvert > 0)
                {
                    result.Add((int)(numberToConvert % toBase));
                    numberToConvert /= toBase;
                }
            }
            else
            {
                result.Add(0);
            }

            for (int count = result.Count - 1; count >= 0; count--)
            {
                convertedNumber.Append(result[count] > 25 ? ((char)(96 + (result[count] / 26))).ToString() : string.Empty);
                convertedNumber.Append((char)(65 + (result[count] % 26)));
            }

            return convertedNumber.ToString();
        }
    }
}