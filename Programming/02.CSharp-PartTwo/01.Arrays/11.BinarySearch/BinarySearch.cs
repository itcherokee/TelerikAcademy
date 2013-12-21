using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Task: "11. Write a program that finds the index of given element in 
/// a sorted array of integers by using the binary search algorithm."
/// 
/// Drawbacks of binary search algorythm:
/// - if array contains one and the same number more than ones (Ex.: 1,1,1,1,2) -> the discovered index 
///   of that element is the first one discovered by the algorythm (index=2 in the example), not the 
///   first element in the sorted array (index=0 in the example). 
/// </summary>
public class BinarySearch
{
    internal enum Sorted
    {
        Yes,
        No,
    }

    public static void Main()
    {
        Console.Title = "Find index of element of array with Binary Search";

        // User input is converted to int array by using lambda expression - simplify by skipping FOR loops
        // The expression: "x => int.Parse(x)", could be also replaced by just "int.Parse", but current one
        // is more readable
        int[] numbers = EnterElements().Select(x => int.Parse(x)).ToArray();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n*** Solution ***\n");

        // Outputs current unsorted array
        PrintArray(numbers, Sorted.No);

        // In order to use binary search, it is required the array to be sorted
        Array.Sort(numbers);

        // Output current sorted array
        PrintArray(numbers, Sorted.Yes);
        int numberToSearch = EnterData("Index of which number do you want to find in the sorted array: ");
        int lowBorder = 0;
        int highBorder = numbers.Length - 1;
        int middle = 0;
        bool found = false;
        while (lowBorder <= highBorder)
        {
            if (highBorder > middle)
            {
                // set middle into upper sub-array - 
                // we need to add current lower border of upper sub-array for valid indexes in array of numbers
                middle = lowBorder + ((highBorder - lowBorder) / 2);
            }
            else
            {
                // set middle into lower sub-array
                middle = (highBorder - lowBorder) / 2;
            }

            if (numbers[middle] == numberToSearch)
            {
                // number found
                found = true;
                break;
            }

            if (numbers[middle] < numberToSearch)
            {
                // search in upper sub-array
                lowBorder = middle + 1;
            }
            else
            {
                // search in lower sub-array
                highBorder = middle - 1;
            }
        }

        if (found)
        {
            Console.Write("The array index (starting count from 0) of requested number is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(middle);
        }
        else
        {
            Console.WriteLine("There is no such number in the array!");
        }

        Console.ReadKey();
    }

    private static void PrintArray(int[] numbers, Sorted sorted)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array {0}: ", sorted == Sorted.Yes ? "(sorted)" : "elements");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(string.Join(",", numbers));
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
    }

    // Manage the input of all array elements in one line on Console
    private static IEnumerable<string> EnterElements()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the array elements on one line separated by space (space is ommited).\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array elements: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.ForegroundColor = ConsoleColor.White;
        return array;
    }

    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
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
}