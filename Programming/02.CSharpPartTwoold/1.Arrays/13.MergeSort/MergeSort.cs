using System;
using System.Collections.Generic;

public class MergeSort
{
    // * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

    public static void Main()
    {
        Console.Title = "Merge Sort algorythm";
        List<int> randomNumbers = new List<int>();
        Random generator = new Random();
        int random = 0;
        for (int count = 0; count < 14; count++)
        {
            random = generator.Next(0, 101);
            randomNumbers.Add(random);
        }

        Console.WriteLine("Unsorted array: " + string.Join(" ", randomNumbers));
        Console.WriteLine("Sorted array  : " + string.Join(" ", SplitArray(randomNumbers)));
    }

    private static List<int> SplitArray(List<int> array)
    {
        if (array.Count <= 1)
        {
            return array;
        }

        int center = array.Count / 2;
        List<int> partOne = new List<int>();
        List<int> partTwo = new List<int>();
        for (int index = 0; index < center; index++)
        {
            partOne.Add(array[index]);
        }

        for (int index = center; index < array.Count; index++)
        {
            partTwo.Add(array[index]);
        }

        partOne = SplitArray(partOne);
        partTwo = SplitArray(partTwo);
        return MergeArrays(partOne, partTwo);
    }

    private static List<int> MergeArrays(List<int> arrayOne, List<int> arrayTwo)
    {
        List<int> arrayResult = new List<int>();
        while (arrayOne.Count > 0 || arrayTwo.Count > 0)
        {
            if (arrayOne.Count > 0 && arrayTwo.Count > 0)
            {
                if (arrayOne[0] <= arrayTwo[0])
                {
                    arrayResult.Add(arrayOne[0]);
                    arrayOne.RemoveAt(0);
                }
                else
                {
                    arrayResult.Add(arrayTwo[0]);
                    arrayTwo.RemoveAt(0);
                }
            }
            else if (arrayOne.Count > 0)
            {
                arrayResult.Add(arrayOne[0]);
                arrayOne.RemoveAt(0);
            }
            else if (arrayTwo.Count > 0)
            {
                arrayResult.Add(arrayTwo[0]);
                arrayTwo.RemoveAt(0);
            }
        }

        return arrayResult;
    }
}
