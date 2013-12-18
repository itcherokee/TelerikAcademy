using System;
using System.Collections.Generic;

/// <summary>
/// Task: "18. * Write a program that reads an array of integers and removes from it a minimal number 
/// of elements in such way that the remaining array is sorted in increasing order. Print the 
/// remaining sorted array. 
/// 
/// Example:{6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}"
/// 
/// ! Please use maximum of three digit numbers for each element of array and array length no more than 12 numbers 
/// for best visualization of the results. Algorythm is working for bigger input data, but formated output
/// is adjusted for above restrictions.
/// </summary>
public class RemoveToSort
{
    public static void Main()
    {
        Console.Title = "Remove elements in array in order to become sorted";

        // int[] arrayOfNumbers = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        // int[] arrayOfNumbers = { 6, 1, 4, 2, 6, 3, 18, 4, 0, 3, 6, 4, 5, 7, 111, 112 };
        int[] arrayOfNumbers = EnterElements();

        // Using List of KeyValuePairs which will stored to number of sorted elements as Key 
        // and the patern to extract them from input array as Value
        List<KeyValuePair<int, string>> winningSequences = new List<KeyValuePair<int, string>>();
        int biggest = 0;
        string pattern = string.Empty;
        for (int bits = BinToDec(arrayOfNumbers.Length); bits > 0; bits--)
        {
            // Convert the binarry pattern in string format
            pattern = Convert.ToString(bits, 2).PadLeft(arrayOfNumbers.Length, '0');
            List<int> numberIndexes = new List<int>();

            // Discovering all numbers that match the pattern and adding 
            // them to candidates list which forms the candidate sorted array
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                if (pattern[index] == '1')
                {
                    numberIndexes.Add(index);
                }
            }

            // Check does the current pattern includes highest number of array numbers (as we are looking for that by task condition)
            // if current pattern is with more numbers than previous one we proceed futher else skip to next pattern
            // Goal is to reduce the number of iterations and unnecesary save of small patterns when bigger/biggest exists
            if (biggest < numberIndexes.Count)
            {
                // Analyzing does the candidate list elements are sorted
                // if yes -> add them to winners list
                bool isSorted = true;
                int previousElement = arrayOfNumbers[numberIndexes[0]];
                for (int index = 1; index < numberIndexes.Count; index++)
                {
                    if (previousElement >= arrayOfNumbers[numberIndexes[index]])
                    {
                        isSorted = false;
                        break;
                    }

                    previousElement = arrayOfNumbers[numberIndexes[index]];
                }

                if (isSorted)
                {
                    // Sorted array is found and is saved
                    winningSequences.Add(new KeyValuePair<int, string>(numberIndexes.Count, pattern));
                    biggest = numberIndexes.Count;
                }
            }
        }

        // Sort the list with discovered sorted arrays by the Key of KeyValuPair type using lambda Comparer
        winningSequences.Sort((x, y) => x.Key.CompareTo(y.Key));

        // Output to Console
        foreach (var item in winningSequences)
        {
            if (item.Key == biggest)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Sorted array(s) found!\n");
                Console.Write("Input  ");
                for (int i = 0; i < arrayOfNumbers.Length; i++)
                {
                    Console.Write("|{0,3}", arrayOfNumbers[i]);
                    if (i == arrayOfNumbers.Length - 1)
                    {
                        Console.WriteLine("|");
                    }
                }

                Console.WriteLine(new string('-', 79));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Sorted ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int index = 0; index < arrayOfNumbers.Length; index++)
                {
                    if (item.Value[index] == '1')
                    {
                        Console.Write("|{0,3}", arrayOfNumbers[index]);
                    }
                    else
                    {
                        Console.Write("|   ");
                    }

                    if (index == arrayOfNumbers.Length - 1)
                    {
                        Console.WriteLine("|\n");
                    }
                }
            }
        }

        Console.WriteLine();
        Console.ReadKey();
    }

    // Manage the input of all array elements in one line of Console
    private static int[] EnterElements()
    {
        bool isValidInput = false;
        int[] result;
        string[] input;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the array elements on one line separated by space (space is ommited).\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Array elements: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            result = new int[input.Length];
            for (int index = 0; index < input.Length; index++)
            {
                isValidInput = int.TryParse(input[index], out result[index]);
                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        while (!isValidInput);

        return result;
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