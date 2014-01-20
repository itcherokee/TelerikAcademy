// Task description is in the solution folder
namespace NineGagNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class NineGagNumbersExec
    {
        public static void Main()
        {
            string number = Console.ReadLine();
            int[] splitedByDigitsNumber = Split(number);
            BigInteger decimalNumber = Convert(splitedByDigitsNumber);
            Console.WriteLine(decimalNumber);
        }

        // Split number by separating digits by positions
        private static int[] Split(string number)
        {
            List<int> result = new List<int>();
            int index = 0;
            char letter;
            while (index < number.Length)
            {
                letter = number[index];
                switch (letter)
                {
                    case '-':
                        result.Add(0);
                        index += 2;
                        break;
                    case '*':
                        if (number[index + 1].Equals('*'))
                        {
                            result.Add(1);
                        }
                        else
                        {
                            result.Add(6);
                            index += 2;
                        }

                        index += 2;
                        break;
                    case '!':
                        if (number[index + 1].Equals('!'))
                        {
                            if (number[index + 2].Equals('!'))
                            {
                                result.Add(2);
                            }
                            else if (number[index + 2].Equals('*'))
                            {
                                result.Add(8);
                                index += 3;
                            }

                            index += 3;
                        }
                        else
                        {
                            result.Add(5);
                            index += 2;
                        }

                        break;
                    case '&':
                        if (number[index + 1].Equals('*'))
                        {
                            result.Add(7);
                            index += 3;
                            continue;
                        }

                        if (number[index + 1].Equals('&'))
                        {
                            result.Add(3);
                        }
                        else if (number[index + 1].Equals('-'))
                        {
                            result.Add(4);
                        }

                        index += 2;
                        break;
                }
            }

            return result.ToArray();
        }

        private static BigInteger Convert(int[] splittedByDigitsNumber)
        {
            BigInteger number = splittedByDigitsNumber[splittedByDigitsNumber.Length - 1];
            BigInteger multiplyer = 9;
            for (int index = splittedByDigitsNumber.Length - 2; index >= 0; index--)
            {
                number += splittedByDigitsNumber[index] * multiplyer;
                multiplyer *= 9;
            }

            return number;
        }
    }
}