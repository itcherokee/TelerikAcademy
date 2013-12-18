using System;
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
    public static void Main()
    {
        Console.Title = "Find index of element of array with Binary Search";
        int[] numbers = EnterElements().Select(x => int.Parse(x)).ToArray();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n*** Solution ***\n");
        PrintArray(numbers, false);

        // In order to use binary search, it is required the array to be sorted
        Array.Sort(numbers);
        PrintArray(numbers, true);
        int numberToSearch = EnterData("Index of which number do you want to find in the sorted array: ");
        int minBorder = 0;
        int maxBorder = numbers.Length - 1;
        int middle = 0;
        bool found = false;
        while (minBorder <= maxBorder)
        {
            if (maxBorder > middle)
            {
                // set middle into upper sub-array - 
                // we need to add current lower border of upper sub-array for valid indexes in array of numbers
                middle = minBorder + ((maxBorder - minBorder) / 2);
            }
            else
            {
                // set middle into lower sub-array
                middle = (maxBorder - minBorder) / 2;
            }

            if (numbers[middle] == numberToSearch)
            {
                // number found
                found = true;
                break;
            }
            else if (numbers[middle] < numberToSearch)
            {
                // search in upper sub-array
                minBorder = middle + 1;
            }
            else
            {
                // search in lower sub-array
                maxBorder = middle - 1;
            }
        }

        if (found)
        {
            Console.WriteLine("The array index (starting count from 0) of requested number is {0}", middle);
        }
        else
        {
            Console.WriteLine("There is no such number in the array!");
        }
    }

    private static void PrintArray(int[] numbers, bool sorted)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array {0}: ", sorted ? "(sorted)" : "elements");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(string.Join(",", numbers.Select(x => x.ToString()).ToArray()));
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Manage the input of all array elements in one line on Console
    private static string[] EnterElements()
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