using System;

public class BInSearch
{
    // Write a program, that reads from the console an array of N integers and an integer K, 
    // sorts the array and using the method Array.BinSearch() finds the largest number in 
    // the array which is ≤ K. 
    public static void Main()
    {
        Console.Title = "By using BinSearch, find the largest number in array.";
        string[] arrayString;
        int[] arrayToSearch;
        bool error = false;

        // read from console the array and load it        
        do
        {
            Console.WriteLine("Enter array elements (positive) on one row separated by one space: ");
            arrayString = Console.ReadLine().Trim().Split();
            arrayToSearch = new int[arrayString.Length];
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                error = int.TryParse(arrayString[i], out arrayToSearch[i]);
                if ((!error) || (arrayToSearch[i] < 0))
                {
                    PrintError();
                    error = false;
                    break;
                }
            }
        }
        while (!error);

        // sort the array ascending 
        for (int i = 0; i < arrayToSearch.Length - 1; i++)
        {
            for (int j = 0; j < arrayToSearch.Length - 1; j++)
            {
                if (arrayToSearch[j] > arrayToSearch[j + 1])
                {
                    // switch two elements by using XOR - no need of temp variable
                    arrayToSearch[j] ^= arrayToSearch[j + 1];
                    arrayToSearch[j + 1] = arrayToSearch[j] ^ arrayToSearch[j + 1];
                    arrayToSearch[j] ^= arrayToSearch[j + 1];
                }
            }
        }

        // read from console the K number to search for
        int numberToSearch = 0;
        error = false;
        do
        {
            Console.Write("\nEnter a number to find [K>=0]: ");
            error = int.TryParse(Console.ReadLine(), out numberToSearch);
            if ((!error) || (numberToSearch < 0))
            {
                PrintError();
                error = false;
            }
        }
        while (!error);

        // binsearch the array
        int returnValueBinSearch = Array.BinarySearch<int>(arrayToSearch, numberToSearch);
        if (returnValueBinSearch < 0)
        {
            returnValueBinSearch = ~returnValueBinSearch;
            if (returnValueBinSearch >= arrayToSearch.Length)
            {
                Console.WriteLine("The biggest number that is less than K is: {0}", arrayToSearch[arrayToSearch.Length - 1]);
            }
            else if (returnValueBinSearch > 0)
            {
                Console.WriteLine("The biggest number that is less than K is: {0}", arrayToSearch[returnValueBinSearch - 1]);
            }
            else
            {
                Console.WriteLine("There is no number in the array that is smaller than K={0}", numberToSearch);
            }
        }
        else
        {
            Console.WriteLine("The number K={2} is equal with element at index {0} in the array, which is: {1}", returnValueBinSearch, arrayToSearch[returnValueBinSearch], numberToSearch);
            Console.Write("Sorted array: ");
            for (int index = 0; index < arrayToSearch.Length; index++)
            {
                Console.Write(arrayToSearch[index] + " ");
            }
        }
    }

    private static void PrintError()
    {
        Console.WriteLine("Wrong input detected!");
        Console.WriteLine("Try again <press Enter>...");
        Console.ReadLine();
        Console.Clear();
    }
}
