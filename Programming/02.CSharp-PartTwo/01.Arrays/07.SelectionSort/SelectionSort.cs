using System;
using System.Linq;

/// <summary>
/// Task: "7. Sorting an array means to arrange its elements in increasing order. 
/// Write a program to sort an array. Use the "selection sort" algorithm: Find the 
/// smallest element, move it at the first position, find the smallest from the rest, 
/// move it at the second position, etc."
/// </summary>
public class SelectionSort
{
    public static void Main()
    {
        string[] array = EnterElements();
        int[] numbers = array.Select(x => int.Parse(x)).ToArray();

        // Eventually provides preview on each step is user request it
        Console.Write("\nDo you want preview of each sort step (Y/N): ");
        bool withPreview = Console.ReadLine().ToUpper() == "Y" ? true : false;
        Sort(numbers, withPreview);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n\nSorted array: ");
        Print(numbers);
        Console.WriteLine();
        Console.ReadKey();
    }

    // Sorting algorythm implementation
    private static void Sort(int[] numbers, bool withPreview = false)
    {
        bool smallerExist = false;
        int stepCounter = 1;
        int currentSmallestNumberIndex = default(int);
        for (int outerIndex = 0; outerIndex < numbers.Length; outerIndex++)
        {
            currentSmallestNumberIndex = outerIndex;
            smallerExist = false;
            for (int innerIndex = outerIndex + 1; innerIndex < numbers.Length; innerIndex++)
            {
                // Find smaller number than current selected
                if (numbers[innerIndex] < numbers[currentSmallestNumberIndex])
                {
                    currentSmallestNumberIndex = innerIndex;
                    smallerExist = true;
                }

                // Handles preview
                if (withPreview)
                {
                    Console.Write("\nStep{0,3}: ", stepCounter++);
                    Print(numbers);
                }
            }

            if (smallerExist)
            {
                // Smaller number has been found, so positions of numbers are swaped
                numbers[outerIndex] ^= numbers[currentSmallestNumberIndex];
                numbers[currentSmallestNumberIndex] ^= numbers[outerIndex];
                numbers[outerIndex] ^= numbers[currentSmallestNumberIndex];
            }
        }
    }

    // Output to Console
    private static void Print(int[] numbers)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(string.Join(",", numbers));
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Manage the input of all array elements in one line of Console
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
}