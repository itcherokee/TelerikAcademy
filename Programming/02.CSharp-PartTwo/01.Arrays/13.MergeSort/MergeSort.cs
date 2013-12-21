using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Task: "13. * Write a program that sorts an array of integers using the merge sort algorithm."
/// </summary>
public class MergeSort
{
    private enum Sorted
    {
        Yes,
        No,
    }

    public static void Main()
    {
        Console.Title = "MergeSort algorythm";
        List<int> numbers = new List<int>();

        // Generate additional random strings(numbers) 
        GenerateNumbers(numbers, 30);

        // Output unsorted array 
        Print(numbers, Sorted.No);

        // Sort & Output to Console the sorted array
        Print(Sort(numbers), Sorted.Yes);
        Console.ReadKey();
    }

    // Sort algorythm - dividing the initial array to smaller ones
    private static List<int> Sort(List<int> numbers)
    {
        // Bottom of recursion - list has only one or zero elements
        if (numbers.Count <= 1)
        {
            return numbers;
        }

        // Will hold smaller numbers than number under "middle" index
        List<int> leftList = new List<int>();

        // Will hold bigger numbers than number under "middle" index + number under "middle" index
        List<int> rightList = new List<int>();

        int middle = numbers.Count / 2;
        for (int index = 0; index < numbers.Count; index++)
        {
            if (numbers[index] < numbers[middle])
            {
                leftList.Add(numbers[index]);
            }
            else
            {
                rightList.Add(numbers[index]);
            }
        }

        // Move first element from one sub-list to another, in order to prevent endless 
        // recursion if one of the sub-list contains only equal elements
        if (leftList.Count < rightList.Count)
        {
            leftList.Add(rightList[0]);
            rightList.RemoveAt(0);
        }
        else
        {
            rightList.Add(leftList[0]);
            leftList.RemoveAt(0);
        }

        leftList = Sort(leftList);
        rightList = Sort(rightList);
        return Merge(leftList, rightList);
    }

    // Sort algorythm - combining divided parts by comparing them and glue them
    private static List<int> Merge(List<int> leftList, List<int> rightList)
    {
        List<int> result = new List<int>();
        while (leftList.Count > 0 || rightList.Count() > 0)
        {
            if (leftList.Count > 0 && rightList.Count > 0)
            {
                // Start comparing elements from both sub-list and add to currently 
                // final result list by sorting them
                if (leftList[0] <= rightList[0])
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }
            else if (leftList.Count > 0)
            {
                result.Add(leftList[0]);
                leftList.RemoveAt(0);
            }
            else if (rightList.Count > 0)
            {
                result.Add(rightList[0]);
                rightList.RemoveAt(0);
            }
        }

        return result;
    }

    // Output result to Console
    private static void Print(IEnumerable<int> numbers, Sorted isSorted)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n{0} array: ", isSorted == Sorted.Yes ? "Sorted" : "Unsorted");
        Console.ForegroundColor = isSorted == Sorted.Yes ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.Write(string.Join(",", numbers));
        Console.WriteLine();
    }

    // Generator of 20 random numbers for the array converted to strings
    private static void GenerateNumbers(List<int> arrayOfNumbers, int count)
    {
        // Generated numbers are in range [1..30]
        Random generator = new Random();
        for (int i = 0; i < count; i++)
        {
            arrayOfNumbers.Add(generator.Next(1, 100));
        }
    }
}