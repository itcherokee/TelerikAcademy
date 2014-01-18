// Task description is in the solution folder
namespace DurankulakNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class DurankulakExec
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            int[] splitedByDigitsNumber = Split(number);
            BigInteger decimalNumber = Convert(splitedByDigitsNumber);
            Console.WriteLine(decimalNumber);
        }

        // Split/Parse Durankulak number by separate Durankulaks' digits
        private static int[] Split(string number)
        {
            List<int> result = new List<int>();
            int index = 0;
            char letter;
            while (index < number.Length)
            {
                letter = number[index];
                if (char.IsLower(letter))
                {
                    // Current letter is lower, so we need the next one (Capital) as well
                    result.Add(((letter - 96) * 26) + (number[index + 1] - 65));
                    index += 2;
                }
                else
                {
                    // Current letter is Capital
                    result.Add(letter - 65);
                    index++;
                }
            }

            return result.ToArray();
        }

        private static BigInteger Convert(int[] splittedByDigitsNumber)
        {
            BigInteger number = splittedByDigitsNumber[splittedByDigitsNumber.Length - 1];
            BigInteger multiplyer = 168;
            for (int index = splittedByDigitsNumber.Length - 2; index >= 0; index--)
            {
                number += splittedByDigitsNumber[index] * multiplyer;
                multiplyer *= 168;
            }

            return number;
        }
    }
}