using System;
using System.Collections.Generic;

public class RemoveToSort
{
    // *Write a program that reads an array of integers and removes from it 
    // a minimal number of elements in such way that the remaining array is 
    // sorted in increasing order. Print the remaining sorted array. 
    // Example:{6,1,4,3,0,3,6,4,5}->{1,3,3,4,5}

    public static void Main()
    {
        Console.Title = "Remove entries in order to sort an array";
        //int[] arrayOfNumbers = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        int[] arrayOfNumbers = { 6, 1, 4, 2, 6, 3, 18, 4, 0, 3, 6, 4, 5 };
        Console.Write("Original array: ");
        for (int index = 0; index < arrayOfNumbers.Length; index++)
        {
            Console.Write(arrayOfNumbers[index]);
            if (index < arrayOfNumbers.Length - 2)
            {
                Console.Write(", ");
            }
        }

        List<int> finalSortedList = new List<int>();
        List<int> operationalSortedList = new List<int>();
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            operationalSortedList.Add(arrayOfNumbers[i]);
            for (int j = i + 1; j < arrayOfNumbers.Length; j++)
            {
                if (arrayOfNumbers[i] < arrayOfNumbers[j])
                {
                    operationalSortedList.Add(arrayOfNumbers[j]);
                    if (operationalSortedList[operationalSortedList.Count - 2] > operationalSortedList[operationalSortedList.Count - 1])
                    {
                        operationalSortedList.RemoveAt(operationalSortedList.Count - 2);
                    }
                }
                else
                {
                    continue;
                }
            }

            if (finalSortedList.Count < operationalSortedList.Count)
            {
                finalSortedList.Clear();
                finalSortedList.AddRange(operationalSortedList);
            }

            if (arrayOfNumbers.Length - finalSortedList.Count < i)
            {
                break;
            }

            operationalSortedList.Clear();
        }

        Console.WriteLine("\nSorted array  : {0}", string.Join(", ", finalSortedList));
    }
}