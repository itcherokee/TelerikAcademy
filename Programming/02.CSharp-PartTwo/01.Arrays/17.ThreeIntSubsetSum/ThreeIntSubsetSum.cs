using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Task: "17. * Write a program that reads three integer numbers N, K and S 
/// and an array of N elements from the console. Find in the array a subset of K 
/// elements that have sum S or indicate about its absence."
/// 
/// Test example:
/// N=10
/// K=2
/// S=199
/// array = 2 88 2 4 88 5 111 6 10 10 
/// Result = "88" "111" and again "88" "111" - two sub-sets are found
/// 
/// I'm using patterns (representing indexes in array - 1s & 0s) to form all possible combinations of sub-sets - 
/// restricted by condition about number of elements used for the sum, after that are matched to the searched sum.
/// 
/// ! Please use maximum of three digit numbers for each element of array and array length no more than 9 numbers 
/// for best visualization of the results. Algorythm is working for bigger input data, but formated output
/// is adjusted for above restrictions.
/// </summary>
public class ThreeIntSubsetSum
{
    public static void Main()
    {
        Console.Title = "Look for subset Sum formed by K elements";

        // User input management
        int arrayElementsNum = EnterData("Enter number of array elements");
        int sumElementsNum = EnterData("Enter number of elements that form Sum");
        int sumToSearch = EnterData("Enter the Sum to search for");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter array elements on one row splited by space: ");
        Console.ForegroundColor = ConsoleColor.Yellow;

        // Below line receives the input in one line, split it by numbers, converts it to int 
        // and if the number of elements is bigger than assigned in arrayElementsNum, takes only the 
        // first arrayElementNum elements - this is a lamba expression that simplifies all this operations
        // in one line instead of couple of loops.
        int[] arrayOfNumbers = Console.ReadLine().Trim()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => int.Parse(x)).Take(arrayElementsNum).ToArray();
        int currentSum = 0;
        bool isSumFound = false;

        // Will hold all patterns that leads to the Sum we search
        List<string> winningPatterns = new List<string>();

        // Generate all possible patterns fullfilling the requirements of sumElementsNum (K) - number of elements to sum
        List<string> patternCombinations = new List<string>();
        patternCombinations = BinToDec(arrayOfNumbers.Length, sumElementsNum);

        // Search for sum based on generated patterns - main algorythm
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
                winningPatterns.Add(patternCombinations[patterns]);
                isSumFound = true;
            }

            currentSum = 0;
        }

        // Output to Console - same code for output is reused as in the previous task
        if (isSumFound)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("BINGO! Subset(s) forming the required SUM found!\n");
            Console.Write("Input     ");
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
                Console.Write("Subset {0,2} ", element);
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int index = 0; index < arrayOfNumbers.Length; index++)
                {
                    if (winningPatterns[element][index] == '1')
                    {
                        Console.Write("| {0,3} ", arrayOfNumbers[index]);
                    }
                    else
                    {
                        Console.Write("|     ");
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

    // User input management
    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message + ": ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }

    // Generate List with patterns based on restriction by sumElementsNum (K)
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