using System;
using System.Collections.Generic;
using System.Text;

public class BullsAndCows
{
    public static void Main()
    {
        // User input
        int secretNumber = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());

        // Calculations
        int n1 = secretNumber / 1000; // thousands
        int n2 = secretNumber / 100 % 10; // hundreads
        int n3 = secretNumber / 10 % 10; // tens
        int n4 = secretNumber % 10; // ones
        int[,] number = new int[1, 1];
        List<int> bullList = new List<int>();
        List<int> cowList = new List<int>();

        if ((bulls == 3 & cows > 0) || (bulls + cows > 4))
        {
            Console.WriteLine("No");
            return;
        }

        for (int currentNumber = 1111; currentNumber <= 9999; currentNumber++)
        {
            // decomposite currentNumber
            int t1 = currentNumber / 1000; // thousands
            int t2 = currentNumber / 100 % 10; // hundreads
            int t3 = currentNumber / 10 % 10; // tens
            int t4 = currentNumber % 10; // ones

            // exclude (skip) numbers with zero in any position
            if (t1 == 0 || t2 == 0 || t3 == 0 || t4 == 0)
            {
                continue;
            }

            int countdownBulls = bulls;
            int bullPositions = 0;
            BitPositions currentBitPositions;
            // Check is there are bulls in requirements
            if (bulls != 0)
            {
                // check for 4 bulls
                if (n1 == t1 && n2 == t2 && n3 == t3 && n4 == t4 && bulls == 4)
                {
                    bullList.Add(currentNumber);

                    break;
                }
                else if (n1 == t1 && n2 == t2 && n3 == t3 && n4 == t4 && bulls != 4)
                {
                    continue;
                }

                // search for all combinations of bulls
                if (n1 == t1)
                {
                    countdownBulls--;
                    bullPositions += 1000;
                    if (countdownBulls == 0)
                    {

                        if (cows == 0)
                        {
                            bullList.Add(currentNumber);
                        }
                        else
                        {
                            string tempNumber = secretNumber.ToString();
                            tempNumber = "0" + tempNumber.Remove(0, 1); // zeros the thousand where is the bull
                            bullList.Add(CheckForCows(bullList, currentNumber, tempNumber, cows));
                        }
                        continue;
                    }
                }

                if (n2 == t2)
                {
                    countdownBulls--;
                    bullPositions += 100;

                    if (countdownBulls == 0)
                    {
                        bullList.Add(currentNumber);

                        continue;
                    }
                }

                if (n3 == t3)
                {
                    countdownBulls--;
                    bullPositions += 10;

                    if (countdownBulls == 0)
                    {
                        bullList.Add(currentNumber);
                        continue;
                    }
                }

                if (n4 == t4)
                {
                    countdownBulls--;
                    bullPositions += 1;

                    if (countdownBulls == 0)
                    {
                        bullList.Add(currentNumber);
                        continue;
                    }
                }
            }
        }


        if (cows != 0)
        {
           // CheckForCows(bullList, 0, cows, n1, n2, n3, n4);
        }

        bullList.Sort();

        foreach (var item in bullList)
        {
            Console.Write("{0} ", item);
        }

        //Console.ReadLine();
    }

    private static void SaveNumber(int[,] number, List<int[,]> bullList, int currentNumber, BitPositions bits)
    {
        number[0, 0] = currentNumber;
        number[0, 1] = (int)(bits);
        bullList.Add(number);
    }

    [Flags]
    private enum BitPositions
    {
        Thousands = 0x8,
        Hundreds = 0x4,
        Tens = 0x2,
        Ones = 0x1,
    }

    static private int CheckForCows(List<int> list, int number, string numberWithZeroedBulls, int numberOfCows, params int[] ns)
    {
        int t1, t2, t3, t4;

        StringBuilder onlyPossibleCowsNumberString = new StringBuilder();
        onlyPossibleCowsNumberString.Append(numberWithZeroedBulls);
        onlyPossibleCowsNumberString.Replace("0", string.Empty);
        int[] tempForSorting = new int[onlyPossibleCowsNumberString.Length];
        for (int i = 0; i < onlyPossibleCowsNumberString.Length; i++)
        {
            tempForSorting[i] = int.Parse(onlyPossibleCowsNumberString[i].ToString());
        }

        Array.Sort(tempForSorting);
        onlyPossibleCowsNumberString.Clear();
        onlyPossibleCowsNumberString.Append(string.Join("",tempForSorting));

        //int bulPos1 = number / 1000; // thousands
        //int bulPos2 = number / 100 % 10; // hundreads
        //int bulPos3 = number / 10 % 10; // tens
        //int bulPos4 = number % 10; // ones

        string finalResultOnlyCows = string.Empty;

        //string test = "1234";

        for (int i = 0; i < numberOfCows; i++)
        {
            if (numberOfCows == 1)
            {
                finalResultOnlyCows = string.Format("{0}", onlyPossibleCowsNumberString[i]);
                continue;
            }

            for (int j = 0; j < numberOfCows; j++)
            {
                if (i == j)
                {
                    continue;
                }

                if (numberOfCows == 2)
                {
                    finalResultOnlyCows = string.Format("{0}{1}", onlyPossibleCowsNumberString[i], onlyPossibleCowsNumberString[j]);
                    continue;
                }

                for (int k = 0; k < numberOfCows; k++)
                {
                    if (i == k || j == k)
                    {
                        continue;
                    }

                    if (numberOfCows == 3)
                    {
                        finalResultOnlyCows = string.Format("{0}{1}{2}", onlyPossibleCowsNumberString[i], onlyPossibleCowsNumberString[j], onlyPossibleCowsNumberString[k]);
                        break;
                    }


                    for (int l = 0; l < numberOfCows; l++)
                    {
                        if (i == l || j == l || k == l)
                        {
                            continue;
                        }

                        finalResultOnlyCows = string.Format("{0}{1}{2}{3}", onlyPossibleCowsNumberString[i], onlyPossibleCowsNumberString[j], onlyPossibleCowsNumberString[k], onlyPossibleCowsNumberString[l]);
                    }
                }
            }
        }

        StringBuilder inputNumber = new StringBuilder(number.ToString());
        StringBuilder outputNumber = new StringBuilder(4);
        int cowsCounter = numberOfCows;
        for (int i = 0; i < numberWithZeroedBulls.Length; i++)
        {
            if (numberWithZeroedBulls[i] == '0')
            {
                outputNumber.Append(inputNumber[i]);
            }
            else
            {
                outputNumber.Append(finalResultOnlyCows[0]);
                cowsCounter--;
                if (cowsCounter == 0)
                {
                    // TODO: additional numbers to fill in the number
                }
            }
        }

        return int.Parse(outputNumber.ToString());




        //if (numberOfCows == 4)
        //{
        //    for (int i = 1111; i <= 9999; i++)
        //    {            // decomposite currentNumber
        //        int posibleCombination = 4;



        //        t1 = i / 1000; // thousands
        //        t2 = i / 100 % 10; // hundreads
        //        t3 = i / 10 % 10; // tens
        //        t4 = i % 10; // ones

        //        if (t1 == 0 || t2 == 0 || t3 == 0 || t4 == 0)
        //        {
        //            continue;
        //        }

        //        if (ns[0] != t1)
        //        {
        //            posibleCombination--;
        //        }

        //        if (ns[1] != t2)
        //        {
        //            posibleCombination--;
        //        }

        //        if (ns[2] != t3)
        //        {
        //            posibleCombination--;
        //        }

        //        if (ns[3] != t1)
        //        {
        //            posibleCombination--;
        //        }

        //        if (posibleCombination == 0)
        //        {
        //            list.Add(i);
        //        }
        //    }
        //}

    }
}