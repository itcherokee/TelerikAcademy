// Task definition is in the solution folder
namespace MultiverseCommunication
{
    using System;

    public class MultiverseComExec
    {
        private static int[] decNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private static string[] spaceNumbers = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };

        public static void Main()
        {
            string input = Console.ReadLine();
            string[] message = new string[input.Length / 3];
            for (int i = 0, k = 0; k < message.Length; k++, i += 3)
            {
                message[k] = input.Substring(i, 3);
            }

            Console.WriteLine(ConvertToTen(message, 13));
        }

        private static long ConvertToTen(string[] numberToConvert, int fromBase)
        {
            int position = numberToConvert.Length - 1;
            long convertedNumber = 0;
            for (int index = 0; index <= position; index++)
            {
                // Tooks the decimal representation of digit in certain position (if it is from base bigger then 10th: A,B,C...)
                int decNumber = int.Parse(decNumbers[Array.IndexOf(spaceNumbers, numberToConvert[position - index])].ToString());
                convertedNumber += decNumber * (long)Math.Pow(fromBase, index);
            }

            return convertedNumber;
        }
    }
}