using System;

public class SubsetsSum
{
    // * We are given an array of integers and a number S. Write a program to find 
    // if there exists a subset of the elements of the array that has a sum S. 
    // Example:	arr={2 1 2 4 3 5 2 6}, S=14 -> yes (1+2+5+6)

    public static void Main()
    {
        Console.Title = "Look for subset Sum";
        //int[] arrayOfNumbers = { 2, 1, 2, 4, 3, 5, 2, 6 };
        int[] arrayOfNumbers = { 2, 88, 2, 4, 3, 5, 111, 6, 10, 10 };
        Console.Write("Enter Sum to search: ");
        int sumToSearch = int.Parse(Console.ReadLine());
        string pattern = string.Empty;
        int currentSum = 0;
        bool found = false;
        for (int bits = BinToDec(arrayOfNumbers.Length); bits >= 0; bits--)
        {
            pattern = Convert.ToString(bits, 2).PadLeft(arrayOfNumbers.Length, '0');
            for (int index = 0; index < arrayOfNumbers.Length; index++)
            {
                if (pattern[index] == '1')
                {
                    currentSum += arrayOfNumbers[index];
                }
            }

            if (currentSum == sumToSearch)
            {
                Console.Write("BINGO! Subset: ");
                for (int index = 0; index < arrayOfNumbers.Length; index++)
                {
                    if (pattern[index] == '1')
                    {
                        Console.Write(arrayOfNumbers[index] + " ");
                    }
                }

                found = true;
                Console.WriteLine();
                break;
            }

            currentSum = 0;
        }

        if (!found)
        {
            Console.WriteLine("Unfortunately there is no such Sum in the sequence.");
        }
    }

    private static int BinToDec(int bitSize)
    {
        int result = 0;
        for (int i = 0; i < bitSize; i++)
        {
            result += (int)Math.Pow(2, i);
        }

        return result;
    }
}