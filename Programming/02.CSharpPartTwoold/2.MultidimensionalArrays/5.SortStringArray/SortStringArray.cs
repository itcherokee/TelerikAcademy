using System;

public class SortStringArray
{
    // You are given an array of strings. Write a method that sorts the array 
    // by the length of its elements (the number of characters composing them).

    public static void Main()
    {
        Console.Title = "Sort array based on elements (string) length.";
        int arrayLength = 6;
        string[] arrayToSort = { "a", "bc", "dfdfdf", "23", "werwrwrwrewer", string.Empty };
        string[] initialArray = new string[arrayLength];
        arrayToSort.CopyTo(initialArray, 0);
        string elementValue = null;
        Console.Write("Initial Array: ");
        for (int i = 0; i < arrayToSort.Length; i++)
        {
            if (initialArray[i] == string.Empty)
            {
                Console.Write("<empty> ");
            }
            else
            {
                Console.Write("{0} ", initialArray[i]);
            }

            for (int j = 0; j < arrayToSort.Length - 1; j++)
            {
                if (arrayToSort[j].Length < arrayToSort[j + 1].Length)
                {
                    elementValue = arrayToSort[j];
                    arrayToSort[j] = arrayToSort[j + 1];
                    arrayToSort[j + 1] = elementValue;
                }
            }
        }

        Console.Write("\nSorted array (descending): ");
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("{0} ", arrayToSort[i]);
        }

        Console.WriteLine();
        Console.ReadKey();
    }
}
