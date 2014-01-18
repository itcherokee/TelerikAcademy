// Task description is in the solution folder

namespace Zerg
{
    using System;

    public class ZergExec
    {
        private static string[] sounds = { "Rawr", "Rrrr", "Hsst", "Ssst", "Grrr", "Rarr", "Mrrr", "Psst", "Uaah", "Uaha", "Zzzz", "Bauu", "Djav", "Myau", "Gruh" };

        public static void Main()
        {
            // Data input
            string input = Console.ReadLine();
            int[] zergNumber = new int[input.Length / 4];
            for (int index = 0, k = 0; index < input.Length; index += 4, k++)
            {
                string zergSound = input.Substring(index, 4);
                zergNumber[k] = Array.IndexOf(sounds, zergSound);
            }

            Console.WriteLine(ConvertToTen(zergNumber, 15));
        }

        /// <summary>
        /// Convert the number to Decimal numeral system.
        /// </summary>
        /// <param name="numberToConvert">Number to be converted.</param>
        /// <param name="fromBase">Whatis the base system of the number to be converted.</param>
        /// <returns>Converted number into decimal base.</returns>
        private static long ConvertToTen(int[] numberToConvert, int fromBase)
        {
            int position = numberToConvert.Length - 1;
            long convertedNumber = 0;
            for (int index = 0; index <= position; index++)
            {
                int decNumber = numberToConvert[position - index];
                convertedNumber += decNumber * (long)Math.Pow(fromBase, index);
            }

            return convertedNumber;
        }
    }
}