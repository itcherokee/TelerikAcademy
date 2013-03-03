using System;

public class SelectionSort
{
    // Sorting an array means to arrange its elements in increasing order. 
    // Write a program to sort an array. Use the "selection sort" algorithm: 
    // Find the smallest element, move it at the first position, find 
    // the smallest from the rest, move it at the second position, etc.

    public static void Main()
    {
        Console.Title = "Selection Sort algorythm";
        int?[] unsortedArray = { 3, 6, 343, 88, 44, 677, 432, 2, 5, 8, 0, 44, 5, 2, 9 };
        //int?[] unsortedArray = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        Console.Write("Unsorted array: ");
        for (int index = 0; index < unsortedArray.Length; index++)
        {
            Console.Write(unsortedArray[index] + " ");
        }

        int[] sortedArray = new int[unsortedArray.Length];
        int? minElementIndex = null;
        for (int index = 0; index < unsortedArray.Length; index++)
        {
            minElementIndex = MinIndex(unsortedArray);
            if (minElementIndex != null)
            {
                sortedArray[index] = (int)unsortedArray[minElementIndex.Value];
                unsortedArray[minElementIndex.Value] = null;
            }
        }

        Console.Write("\nSorted array  : ");
        for (int index = 0; index < sortedArray.Length; index++)
        {
            Console.Write(sortedArray[index] + " ");
        }

        Console.WriteLine();
    }

    private static int? MinIndex(int?[] array)
    {
        int currentIndex = -1;
        int? currentElement = null;
        for (int index = 0; index < array.Length; index++)
        {
            if (array[index].HasValue)
            {
                currentElement = array[index].Value;
                currentIndex = index;
                break;
            }
        }

        for (int index = 0; index < array.Length; index++)
        {
            if (array[index].HasValue)
            {
                if (array[index].Value < currentElement)
                {
                    currentElement = array[index];
                    currentIndex = index;
                }
            }
        }

        return currentIndex;
    }
}