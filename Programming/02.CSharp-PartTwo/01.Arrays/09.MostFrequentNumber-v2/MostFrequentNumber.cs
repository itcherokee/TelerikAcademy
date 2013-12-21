using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Task: "Write a program that finds the most frequent number in an array.
/// Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)."
/// 
/// Border cases:
/// - empty array
/// - only one element in array
/// - last element in array is most frequent number
/// </summary>
public class MostFrequentNumber
{
    public static void Main(string[] args)
    {
        Console.Title = "Most frequent number";
        string[] input = EnterElements();

        // Below line use lambda expression in order to convert string[] to int[] - it is like calling "for" loop
        int[] numbers = input.Select(x => int.Parse(x)).ToArray();
        if (numbers.Length > 0)
        {
            // SortedDictionary is a List of KeyValuePairs, where the Key is unique, array elements in out case,
            // and Value is the times a Key is met in input array.
            SortedDictionary<int, int> result = new SortedDictionary<int, int>();
            int currentKey = default(int);
            foreach (int number in numbers)
            {
                currentKey = number;
                if (result.ContainsKey(number))
                {
                    // increment the Value of the Key
                    result[currentKey]++;
                }
                else
                {
                    // add new Key and set its value to one
                    result[currentKey] = 1;
                }
            }

            int finalNumber = int.MinValue;
            int finalCount = 0;

            // Find the Key/Value with most highest number of Values - this is our searched number: Key=number, Value=frequency 
            foreach (var item in result)
            {
                if (item.Value > finalCount)
                {
                    finalNumber = item.Key;
                    finalCount = item.Value;
                }
            }

            Console.WriteLine("Most frequent number is {0} ({1} times)", finalNumber, finalCount);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Empty array provided!");
            Console.WriteLine("Program will exit...");
        }

        Console.ReadKey();
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