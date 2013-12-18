using System;

public class FindSum
{
    // Write a program that finds in given array of integers a sequence of given sum S (if present). 
    // Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

    public static void Main()
    {
        int[] arrayOfNumbers = { 1, 4, 2, 5, 8 };
        Console.Write("Please enter to Sum to search: ");
        int sumToSearch = int.Parse(Console.ReadLine());
        int currentSum = 0;
        for (int index = 0; index < arrayOfNumbers.Length; index++)
        {
            for (int currentIndex = index; currentIndex < arrayOfNumbers.Length; currentIndex++)
            {
                currentSum += arrayOfNumbers[currentIndex];
                if (currentSum > sumToSearch)
                {
                    currentSum = 0;
                    break;
                }

                if (currentSum == sumToSearch)
                {
                    Console.Write("The sequence that summed makes {0} is ", sumToSearch);
                    for (int i = index; i <= currentIndex; i++)
                    {
                        Console.Write(arrayOfNumbers[i]);
                        if (i < currentIndex)
                        {
                            Console.Write(", ");
                        }
                    }

                    Console.WriteLine();
                    return;
                }
            }
        }

        Console.WriteLine("There is no sequence of elements that summed make Sum of {0}", sumToSearch);
    }
}
