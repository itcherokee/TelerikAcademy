using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.TRES4_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            BigInteger numberToConvert = BigInteger.Parse(Console.ReadLine());
            string convertedToTres4 = ConvertFromTen(numberToConvert, 9);
            Console.WriteLine(convertedToTres4);
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

            string[] tres4Numbers = new[] { "LON+", "VK-", "*ACAD", "^MIM", "ERIK|", "SEY&", "EMY>>", "/TEL", "<<DON" };
            for (int count = result.Count - 1; count >= 0; count--)
            {
                //convertedNumber.Append(tres4Numbers[result[count]]);
                convertedNumber.Append(result[count] > 9 ? tres4Numbers[result[count]] : string.Empty);
                convertedNumber.Append(tres4Numbers[result[count]]);
            }

            return convertedNumber.ToString();
        }
    }
}
