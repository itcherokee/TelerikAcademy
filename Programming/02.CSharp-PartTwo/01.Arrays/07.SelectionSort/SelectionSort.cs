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
        Console.Write("Run algorythm with Insert in front the smallest number or not (Y/N): ");
        bool withInsert = Console.ReadLine().ToUpper() == "Y" ? true : false;
        Console.Write("Do you want view of each sort step (Y/N): ");
        bool withPreview = Console.ReadLine().ToUpper() == "Y" ? true : false;
        Sort(numbers, withInsert, withPreview);
        Console.Write("Sorted array: ");
        StepsPreview(numbers);
        Console.ReadKey();
    }

    // Print on Console each step of sorting algorythm
    private static void StepsPreview(int[] numbers)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(string.Join(",", numbers));
    }

    // Sorting algorythm implementation
    private static void Sort(int[] numbers, bool withInsert, bool withPreview = false)
    {
        bool smallerExist = false;
        int currentSmallestNumberIndex = default(int);
        for (int outer = 0; outer < numbers.Length; outer++)
        {
            if (withInsert)
            {
                currentSmallestNumberIndex = outer;
                for (int inner = outer + 1; inner < numbers.Length; inner++)
                {
                    if (numbers[inner] < numbers[currentSmallestNumberIndex])
                    {
                        currentSmallestNumberIndex = inner;
                        numbers[outer] ^= numbers[currentSmallestNumberIndex];
                        numbers[currentSmallestNumberIndex] ^= numbers[outer];
                        numbers[outer] ^= numbers[currentSmallestNumberIndex];
                    }

                    if (withPreview)
                    {
                        StepsPreview(numbers);
                    }
                }
            }
            else
            {
                currentSmallestNumberIndex = outer;
                smallerExist = false;
                for (int inner = outer + 1; inner < numbers.Length; inner++)
                {
                    if (numbers[inner] < numbers[currentSmallestNumberIndex])
                    {
                        currentSmallestNumberIndex = inner;
                        smallerExist = true;
                    }

                    if (withPreview)
                    {
                        StepsPreview(numbers);
                    }
                }

                if (smallerExist)
                {
                    numbers[outer] ^= numbers[currentSmallestNumberIndex];
                    numbers[currentSmallestNumberIndex] ^= numbers[outer];
                    numbers[outer] ^= numbers[currentSmallestNumberIndex];
                }
            }
        }
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