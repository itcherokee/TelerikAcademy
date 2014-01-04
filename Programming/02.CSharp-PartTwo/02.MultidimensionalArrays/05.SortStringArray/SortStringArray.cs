using System;
using System.Security.Cryptography;

/// <summary>
/// Task: "You are given an array of strings. Write a method that sorts the array 
/// by the length of its elements (the number of characters composing them)."
/// </summary>
public class SortStringArray
{
    private enum Direction
    {
        Ascending,
        Descending,
        None,
    }

    public static void Main()
    {
        Console.Title = "Sort array based on elements (string) length.";
        string[] arrayToSort = { "a", "bc", "dfdfdf", "23", "werwrwrwrewer", string.Empty };
        Print(arrayToSort, Direction.None);

        // Sorts array in ascending elements & output to Console
        Sort(arrayToSort, Direction.Ascending);
        Print(arrayToSort, Direction.Ascending);

        // Sorts array in descending elements & output to Console
        Sort(arrayToSort, Direction.Descending);
        Print(arrayToSort, Direction.Descending);
        Console.WriteLine();
        Console.ReadKey();
    }

    // Sorts the array by length of the elements and in selected direction
    private static void Sort(string[] array, Direction direction)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                switch (direction)
                {
                    case Direction.Descending:
                        if (array[j].Length < array[j + 1].Length)
                        {
                            Swap(array, j);
                        }

                        break;
                    case Direction.Ascending:
                        if (array[j].Length > array[j + 1].Length)
                        {
                            Swap(array, j);
                        }

                        break;
                    case Direction.None:
                        // do nothing as it has no sence in that scenario
                        break;
                }
            }
        }
    }

    // Swaps to elements of the array
    private static void Swap(string[] array, int j)
    {
        string element = array[j];
        array[j] = array[j + 1];
        array[j + 1] = element;
    }

    // Output to Console
    private static void Print(string[] array, Direction direction)
    {
        Console.ForegroundColor = ConsoleColor.White;
        switch (direction)
        {
            case Direction.None:
                Console.Write("\nInitial array (non sorted): ");
                break;
            case Direction.Ascending:
                Console.Write("\nSorted array (ascending): ");
                break;
            case Direction.Descending:
                Console.Write("\nSorted array (descending): ");
                break;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        for (int index = 0; index < array.Length; index++)
        {
            if (string.IsNullOrEmpty(array[index]) || string.IsNullOrWhiteSpace(array[index]))
            {
                Console.Write("<empty>");
            }
            else
            {
                Console.Write(array[index]);
            }

            if (index < array.Length - 1)
            {
                Console.Write(", ");
            }
        }
    }
}