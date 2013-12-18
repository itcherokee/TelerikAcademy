using System;
using System.Collections.Generic;

public class ThreeIntSubsetSum
{
    // * Write a program that reads three integer numbers N, K and S and 
    // an array of N elements from the console. Find in the array a subset 
    // of K elements that have sum S or indicate about its absence.
    //  Test example:
    //  N=10
    //  K=2
    //  S=199
    //  array = 2 88 2 4 3 5 111 6 10 10 
    //  Result = 88 111

    public static void Main()
    {
        Console.Title = "Look for subset Sum formed by K elements";
        Console.Write("Enter number of array elements: ");
        int arrayElementsNum = int.Parse(Console.ReadLine());
        Console.Write("Enter number of elements that form Sum: ");
        int sumElementsNum = int.Parse(Console.ReadLine());
        Console.Write("Enter the Sum to search for: ");
        int sumToSearch = int.Parse(Console.ReadLine());
        Console.Write("Enter array elelements on one row splited by space: ");
        string[] arrayOfNumsStr = Console.ReadLine().Trim().Split();
        int[] arrayOfNumbers = new int[arrayElementsNum];
        for (int index = 0; index < arrayElementsNum; index++)
        {
            arrayOfNumbers[index] = int.Parse(arrayOfNumsStr[index]);
        }

        string pattern = string.Empty;
        int currentSum = 0;

        // generate patterns equal to sumElementsNum (K)
        List<string> patternCombinations = new List<string>();
        patternCombinations = BinToDec(arrayOfNumbers.Length, sumElementsNum);

        // search for sum based on patterns & if found -> print
        for (int patterns = 0; patterns < patternCombinations.Count; patterns++)
        {
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                if (patternCombinations[patterns][index] == '1')
                {
                    currentSum += arrayOfNumbers[index];
                }
            }

            if (currentSum == sumToSearch)
            {
                Console.WriteLine("BINGO!!!");
                for (int index = 0; index < arrayOfNumbers.Length; index++)
                {
                    if (patternCombinations[patterns][index] == '1')
                    {
                        Console.Write(arrayOfNumbers[index] + " ");
                    }
                }

                Console.WriteLine();
                return;
            }

            currentSum = 0;
        }
    }

    // generate List with patterns based on restriction by sumElementsNum (K)
    private static List<string> BinToDec(int bitSize, int elementsNumber)
    {
        List<string> combinations = new List<string>();
        int result = 0;
        for (int i = 0; i < bitSize; i++)
        {
            result += (int)Math.Pow(2, i);
        }

        string pattern = string.Empty;
        for (int bits = result; bits >= 0; bits--)
        {
            pattern = Convert.ToString(bits, 2).PadLeft(bitSize, '0');
            int sumBits = 0;
            for (int index = 0; index < pattern.Length; index++)
            {
                sumBits += int.Parse(pattern[index].ToString());
            }

            if (sumBits == elementsNumber)
            {
                combinations.Add(pattern);
            }
        }

        return combinations;
    }
}