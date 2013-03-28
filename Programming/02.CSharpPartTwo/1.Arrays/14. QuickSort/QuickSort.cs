using System;
using System.Collections.Generic;

public class QuickSort
{
    // Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

    public static void Main()
    {
        Console.Title = "QuickSort algorythm";
        List<int> arrayOfNumbers = new List<int>();
        Random generator = new Random();
        for (int count = 0; count < 20; count++)
        {
            arrayOfNumbers.Add(generator.Next(1, 101));
        }

        Console.Write("Unsorted array: " + string.Join(",", arrayOfNumbers));
        List<int> arrayOfNumbersSorted = new List<int>();
        arrayOfNumbersSorted = QSort(arrayOfNumbers);
        Console.WriteLine("\nSorted array  : " + string.Join(",", arrayOfNumbersSorted));
    }

    // QuickSort algorythm implementation
    private static List<int> QSort(List<int> array)
    {
        if (array.Count < 2)
        {
            return array;
        }
        else if (array.Count == 2)
        {
            if (array[0] > array[1])
            {
                array[0] ^= array[1];
                array[1] = array[0] ^ array[1];
                array[0] ^= array[1];
            }

            return array;
        }

        int pivotIndex = array.Count / 2;
        int pivotValue = array[pivotIndex];
        List<int> leftArray = new List<int>();
        List<int> rightArray = new List<int>();
        for (int index = 0; index < array.Count; index++)
        {
            if (index == pivotIndex)
            {
                continue;
            }

            if (array[index] <= pivotValue)
            {
                leftArray.Add(array[index]);
            }
            else
            {
                rightArray.Add(array[index]);
            }
        }

        List<int> returnArray = new List<int>();
        returnArray.AddRange(QSort(leftArray));
        returnArray.Add(pivotValue);
        returnArray.AddRange(QSort(rightArray));
        return returnArray;
    }
}
