using System;
using System.Collections;

public class MaximalSum
{
    // Write a program that reads two integer numbers N and K 
    // and an array of N elements from the console. 
    // Find in the array those K elements that have maximal sum.

    public static void Main()
    {
        Console.Title = "Find K elelements that have maximal sum";
        Console.Write("Enter size of the array N=");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayOfNumbers = new int[arraySize];
        Console.Write("Enter number of elements to calculate for maximal sum K=");
        int numberOfElements = int.Parse(Console.ReadLine());
        Console.Write("Enter array elements on one row separated by space: ");
        string[] tempArray = Console.ReadLine().Trim().Split();
        SortedList sumElements = new SortedList();
        if (arraySize >= numberOfElements)
        {
            arrayOfNumbers[0] = int.Parse(tempArray[0]);
            for (int index = 1; index < arraySize; index++)
            {
                arrayOfNumbers[index] = int.Parse(tempArray[index]);
                if (index <= numberOfElements)
                {
                    sumElements.Add(arrayOfNumbers[index], index);
                }
                else
                {
                    if (arrayOfNumbers[index] > (int)sumElements.GetKey(0))
                    {
                        sumElements.Add(arrayOfNumbers[index], index);
                        sumElements.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine("The elements that calculate maximal sum are:");
            int totalSum = 0;
            for (int count = 0; count < sumElements.Count; count++)
            {
                Console.Write("{0} (at index {1})", sumElements.GetKey(count), sumElements.GetByIndex(count));
                if (count < sumElements.Count - 1)
                {
                    Console.Write(", ");
                }

                totalSum += (int)sumElements.GetKey(count);
            }

            Console.WriteLine("\nTotal SUM is: {0}", totalSum);
        }
        else
        {
            Console.WriteLine("You have entered wrong initial data.");
        }
    }
}