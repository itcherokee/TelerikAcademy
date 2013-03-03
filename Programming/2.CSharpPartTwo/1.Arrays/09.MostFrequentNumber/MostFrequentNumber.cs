using System;

public class MostFrequentNumber
{
    // Write a program that finds the most frequent number in an array. 
    // Example: {4,1,1,4,2,3,4,4,1,2,4,9,3} -> 4 (5 times)

    public static void Main()
    {
        Console.Title = "Find most frequent number in an array";
        int[] arrayOfNumbers = { 3, 4, 1, 3, 4, 3, 3, 4, 3, 1, 2, 3, 3, 3, 3, 6, 3, 2, 3 };
        Console.Write("Array: ");
        for (int index = 0; index < arrayOfNumbers.Length; index++)
        {
            Console.Write(arrayOfNumbers[index] + " ");
        }

        int?[] workingArray = new int?[arrayOfNumbers.Length];
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            workingArray[i] = arrayOfNumbers[i];
        }

        int finalNumber = int.MinValue;
        int finalCount = 0;
        int currentNumber = int.MinValue;
        int currentCount = 1;
        for (int i = 0; i < workingArray.Length; i++)
        {
            if (workingArray[i].HasValue)
            {
                currentNumber = workingArray[i].Value;
                workingArray[i] = null;
                for (int j = i + 1; j < workingArray.Length; j++)
                {
                    if (currentNumber == workingArray[j])
                    {
                        currentCount++;
                        workingArray[j] = null;
                    }
                }

                if (finalCount < currentCount)
                {
                    finalCount = currentCount;
                    finalNumber = currentNumber;
                }

                currentCount = 1;
            }
        }

        Console.WriteLine("\nMost frequent number in the array is {0}, appeared {1} times.", finalNumber, finalCount);
    }
}
