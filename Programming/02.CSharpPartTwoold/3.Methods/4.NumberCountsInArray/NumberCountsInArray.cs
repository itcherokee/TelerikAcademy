using System;
using System.Collections.Generic;

public class NumberCountsInArray
{
    // Write a method that counts how many times given number appears in given array. 
    // Write a test program to check if the method is working correctly.

    public static void Main()
    {
        Console.Title = "Counts times that one number appears in sequence of numbers.";
        Console.WriteLine("Enter sequence of numbers on one row separated by one space.");
        string[] tempArray = Console.ReadLine().Trim().Split();
        int[] enteredNumbers = new int[tempArray.Length];
        for (int i = 0; i < tempArray.Length; i++)
        {
            enteredNumbers[i] = int.Parse(tempArray[i]);
        }

        Console.Write("Enter the number to be searched & counted in the sequence: ");
        int numberToCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Your number appears {0} times in the sequence.", Count(numberToCount, enteredNumbers));
    }

    private static int Count(int digit, int[] numbers)
    {
        int result = 0;
        foreach (var item in numbers)
        {
            if (item == digit)
            {
                result++;
            }
        }

        return result;
    }
}
