using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Task: "Write a program that sorts an array of strings using the quick sort algorithm."
/// 
/// Note:   There is an fixed values usorted array hard-coded - to include values(numbers) like "02" and strings
///         Additionally after that is used random generator to add more strings (numbers).
/// </summary>
public class QuickSort
{
    public static void Main()
    {
        Console.Title = "QuickSort algorythm";
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Note that the task requirement is to sort STRINGS, not numbers.");
        Console.Write("That means that in sorted array  for example \"2\" will be after \"11\",");
        Console.WriteLine("but \"02\" in sorted array will be before \"11\".\n");
        List<string> arrayOfStrings = new List<string>();

        // Hard-coded values - initial part of the string array
        arrayOfStrings.Add("1");
        arrayOfStrings.Add("11111");
        arrayOfStrings.Add("abc");
        arrayOfStrings.Add("a11");
        arrayOfStrings.Add("abcd");
        arrayOfStrings.Add("02");
        arrayOfStrings.Add("2");
        arrayOfStrings.Add("0");
        arrayOfStrings.Add("77");
        arrayOfStrings.Add("8");
        arrayOfStrings.Add("zyw");
        arrayOfStrings.Add("99");

        // Generate additional random strings(numbers) 
        GenerateNumbers(arrayOfStrings);

        // Output unsorted array 
        Print(arrayOfStrings, false);

        // Sort & Output to Console the sorted array
        Print(Sort(arrayOfStrings), true);
        Console.ReadKey();
    }

    // Output result to Console
    private static void Print(IEnumerable<string> arrayOfStrings, bool isSorted)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n{0} array: ", isSorted ? "Sorted" : "Unsorted");
        Console.ForegroundColor = isSorted ? ConsoleColor.Green : ConsoleColor.Yellow;
        Console.Write(string.Join(",", arrayOfStrings));
        Console.WriteLine();
    }

    // Generator of 20 random numbers for the array converted to strings
    private static void GenerateNumbers(List<string> arrayOfNumbers)
    {
        // Generated numbers are in range [1..100]
        Random generator = new Random();
        for (int count = 0; count < 20; count++)
        {
            arrayOfNumbers.Add(generator.Next(1, 101).ToString(CultureInfo.InvariantCulture));
        }
    }

    // QuickSort algorythm implementation
    private static List<string> Sort(List<string> elements)
    {
        // only one element in the array - nothing to sort
        if (elements.Count < 2)
        {
            return elements;
        }
      
        if (elements.Count == 2)
        {
            // Only 2 elements in the array - no need to create separate left/right arrays, just compare them
            //
            // In the IF we use Compare with StringComaprison.Ordinal argument in order to exclude linguistic conventions
            // see: http://msdn.microsoft.com/en-us/library/cc165449.aspx
            if (string.Compare(elements[0], elements[1], StringComparison.Ordinal) > 0)
            {
                string holder = elements[0];
                elements[0] = elements[1];
                elements[1] = holder;
            }

            return elements;
        }

        // Below code finds pivot element and start the real quick sort algorythm - left & right sub-arrays
        int pivotIndex = elements.Count / 2;
        string pivotValue = elements[pivotIndex];
        List<string> leftArray = new List<string>();
        List<string> rightArray = new List<string>();
        for (int index = 0; index < elements.Count; index++)
        {
            if (index == pivotIndex)
            {
                // this is the pivot and we skip it
                continue;
            }

            if (string.Compare(elements[index], pivotValue, StringComparison.Ordinal) <= 0)
            {
                // "smaller" string value than value in the pivot
                leftArray.Add(elements[index]);
            }
            else
            {
                // "bigger" string value than value in the pivot
                rightArray.Add(elements[index]);
            }
        }

        List<string> returnArray = new List<string>();

        // Itterate over left array - recursivly call Sort method
        returnArray.AddRange(Sort(leftArray));

        // add current pivot element to current final array
        returnArray.Add(pivotValue);

        // Itterate over right array - recursivly call Sort method
        returnArray.AddRange(Sort(rightArray));
        return returnArray;
    }
}