using System;

public class BinarySearch
{
    // Write a program that finds the index of given element in a sorted array 
    // of integers by using the binary search algorithm (find it in Wikipedia).

    public static void Main()
    {
        int[] arrayOfNumbers = { 10, 22, 34, 47, 58, 60, 71, 87, 93, 100 };
        Console.Write("Initial Array: ");
        for (int index = 0; index < arrayOfNumbers.Length; index++)
        {
            Console.Write(arrayOfNumbers[index] + " ");
        }

        Console.Write("\nWhich number to search for: ");
        int numberToSearch = int.Parse(Console.ReadLine());
        int min = 0;
        int max = arrayOfNumbers.Length - 1;
        int middle = 0;
        if (numberToSearch >= arrayOfNumbers[min] && numberToSearch <= arrayOfNumbers[max])
        {
            while (max >= min)
            {
                middle = min + ((max - min) / 2);
                if (numberToSearch == arrayOfNumbers[middle])
                {
                    break;
                }

                if (numberToSearch < arrayOfNumbers[middle])
                {
                    max = middle - 1;
                }
                else
                {
                    min = middle + 1;
                }
            }

            Console.WriteLine("The elelement is at the index {0}", middle);
        }
        else
        {
            Console.WriteLine("You have entered a number out of the array elements scope!");
        }
    }
}