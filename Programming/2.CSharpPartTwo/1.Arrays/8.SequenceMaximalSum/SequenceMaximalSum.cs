using System;

public class SequenceMaximalSum
{
    // Write a program that finds the sequence of maximal sum in given array. 
    // Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
    // Can you do it with only one loop (with single scan through the elements of the array)?

    public static void Main()
    {
        Console.Title = "Find sequence of maximal sum in array";
        // int[] arrayOfNumbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int[] arrayOfNumbers = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        //int[] arrayOfNumbers = { 23, 4, -4, -65, 3 };
        Console.Write("Array: ");
        for (int index = 0; index < arrayOfNumbers.Length; index++)
        {
            Console.Write(arrayOfNumbers[index] + " ");
        }

        int finalSum = int.MinValue;
        int finalStartIndex = 0;
        int finalElelementCount = 0;
        int currentStartIndex = 0;
        int currentCountElelemnts = 0;
        int currentSum = 0;
        for (int index = 0; index < arrayOfNumbers.Length; index++)
        {
            if (currentSum + arrayOfNumbers[index] > 0)
            {
                if (currentSum == 0)
                {
                    currentStartIndex = index;
                }

                currentSum = currentSum + arrayOfNumbers[index];
                currentCountElelemnts++;
            }
            else
            {
                currentSum = 0;
                currentCountElelemnts = 0;
            }

            if (currentSum > finalSum)
            {
                finalSum = currentSum;
                finalStartIndex = currentStartIndex;
                finalElelementCount = currentCountElelemnts;
            }
        }

        Console.WriteLine("\nThe sequence of maximal sum ({0}) in given array is: ", finalSum);
        for (int i = finalStartIndex; i < finalStartIndex + finalElelementCount; i++)
        {
            Console.Write(arrayOfNumbers[i]);
            if (i < finalStartIndex + finalElelementCount - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }
}