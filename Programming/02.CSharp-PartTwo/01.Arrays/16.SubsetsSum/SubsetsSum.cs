using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Task: "16. * We are given an array of integers and a number S. Write a program 
/// to find if there exists a subset of the elements of the array that has a sum S. 
/// Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)"
/// 
/// Tests: there is hard-coded values, but you can enter your own. User input is not 
/// coded as it was not requested by task condition - in next task (17), there is as well user input
/// 
/// I'm using patterns (representing indexes in array - 1s & 0s) to form all possible combinations of sub-sets,
/// which after that are matched to the searched sum.
/// 
/// ! Please use maximum of three digit numbers for each element of array and array length no more than 9 numbers 
/// for best visualization of the results. Algorythm is working for bigger input data, but formated output
/// is adjusted for above restrictions.
/// </summary>
public class SubsetsSum
{
    public static void Main()
    {
        Console.Title = "Look for subset Sum in array";

        // Input arrays - examples, you can create your own following the above constraints for visualization of results
        // int[] arrayOfNumbers = { 2, 1, 2, 4, 3, 5, 2, 6 };
        // int[] arrayOfNumbers = { 2, 88, 2, 4, 3, 5, 111, 6, 10, 10 };
        int[] arrayOfNumbers = { -2, 4, 6, -8, -10, -99, 76 };
        Console.WriteLine("Given array: " + string.Join(", ", arrayOfNumbers));
        Console.Write("Enter Sum to search: ");
        int sumToSearch = int.Parse(Console.ReadLine());
        string pattern = string.Empty;
        int currentSum = 0;
        bool isSumFound = false;

        // Will hold all patterns that leads to searched Sum
        List<string> winningPatterns = new List<string>();

        // Task algorythm
        for (int bits = BinToDec(arrayOfNumbers.Length); bits >= 0; bits--)
        {
            // convert the binarry pattern in string format
            pattern = Convert.ToString(bits, 2).PadLeft(arrayOfNumbers.Length, '0');

            // Calculation of the pattern sum
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                if (pattern[index] == '1')
                {
                    currentSum += arrayOfNumbers[index];
                }
            }

            // Pattern sum matching with searched sum
            if (currentSum == sumToSearch)
            {
                // sub-set forming the Sum found
                winningPatterns.Add(pattern);
                isSumFound = true;
            }

            currentSum = 0;
        } 

        // Output to Console
        if (isSumFound)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("BINGO! Subset(s) forming the required SUM found!\n");
            Console.Write("Input    : ");
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                Console.Write("| {0,3} ", arrayOfNumbers[i]);
                if (i == arrayOfNumbers.Length - 1)
                {
                    Console.WriteLine("|");
                }
            }

            Console.WriteLine(new string('-', 79));
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int element = 0; element < winningPatterns.Count; element++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Subset {0,2}: ", element);
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int index = 0; index < arrayOfNumbers.Length; index++)
                {
                    if (winningPatterns[element][index] == '1')
                    {
                        Console.Write("| {0,3} ", arrayOfNumbers[index]);
                    }
                    else
                    {
                        Console.Write("|     ", arrayOfNumbers[index]);
                    }

                    if (index == arrayOfNumbers.Length - 1)
                    {
                        Console.WriteLine("| = {0}\n", sumToSearch);
                    }
                }
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unfortunately there is no such Sum in the sequence.");
        }
    }

    // Generating the patern to be used against array elements
    private static int BinToDec(int bitSize)
    {
        int result = 0;
        for (int i = 0; i < bitSize; i++)
        {
            result += (int)Math.Pow(2, i);
        }

        return result;
    }
}