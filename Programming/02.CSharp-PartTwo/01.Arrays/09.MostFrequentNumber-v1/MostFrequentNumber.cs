using System;
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
            Array.Sort(numbers);
            int currentNumber = numbers[0];
            int currentCount = 1;
            int finalNumber = currentNumber;
            int finalCount = currentCount;
            for (int index = 1; index < numbers.Length; index++)
            {
                if (currentNumber == numbers[index])
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > finalCount)
                    {
                        finalCount = currentCount;
                        finalNumber = currentNumber;
                    }

                    currentNumber = numbers[index];
                    currentCount = 1;
                }
            }

            if (currentCount > finalCount)
            {
                finalCount = currentCount;
                finalNumber = currentNumber;
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