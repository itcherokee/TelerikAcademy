using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Task: "Write a program that finds the sequence of maximal sum in given array. 
/// Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
/// Can you do it with only one loop (with single scan through the elements of the array)?"
/// 
/// Note: There are a couple of hard-coded arrays. You can comment/uncomment or add your own for tests 
/// </summary>
public class SequenceOfMaxSum
{
    public static void Main()
    {
        Console.Title = "Find sequence of maximal sum in array";

        // int[] numbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        // int[] numbers = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        // int[] numbers = { 23, 4, -4, -65, 3 };
        int[] numbers = { -2, -3, -3, -9, -7, -12, -1, -5, -4, -1 };
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array: ");
        Console.ForegroundColor = ConsoleColor.Yellow;

        // Output of entered array to console - converting each number to string by lambda expression
        Console.WriteLine(string.Join(",", numbers.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray()));

        int finalSum = numbers[0];
        int currentStartIndex = 0;
        int currentElementsCount = 1;
        int currentSum = numbers[0];
        for (int index = 1; index < numbers.Length; index++)
        {
            if (currentSum + numbers[index] < numbers[index])
            {
                currentSum = numbers[index];
                currentStartIndex = index;
                currentElementsCount = 1;
            }
            else
            {
                currentSum = currentSum + numbers[index];
                currentElementsCount++;
            }

            if (finalSum < currentSum)
            {
                finalSum = currentSum;
            }
        }

        // Output result to the Console
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nThe maximal sum in given array is: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(finalSum);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Sequence is: ");
        Console.ForegroundColor = ConsoleColor.Yellow;

        // printing just fom index = currentStartIndex, only currentElementsCount which are forming discovered max sum
        Console.WriteLine(string.Join(",", numbers.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray(), currentStartIndex, currentElementsCount));
        Console.ReadKey();
    }
}