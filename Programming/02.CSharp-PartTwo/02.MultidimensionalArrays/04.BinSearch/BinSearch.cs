using System;
using System.Linq;

/// <summary>
/// Task: "Write a program, that reads from the console an array of N integers and an integer K, 
/// sorts the array and using the method Array.BinSearch() finds the largest number in the array 
/// which is ≤ K."
/// </summary>
public class BinSearch
{
    public static void Main()
    {
        Console.Title = "By using BinSearch, find the largest number in array.";
        int[] numbers = EnterElements();
        int numberToSearch = EnterData("\nEnter a number to find [K]: ");

        // Sorts the array - You can uncomment the below code to use BubbleSort or leave it using the Array.Sort()
        Array.Sort(numbers);

        // for (int i = 0; i < numbers.Length - 1; i++)
        // {
        //    for (int j = 0; j < numbers.Length - 1; j++)
        //    {
        //        if (numbers[j] > numbers[j + 1])
        //        {
        //            // switch two elements by using XOR - no need of temp variable
        //            numbers[j] ^= numbers[j + 1];
        //            numbers[j + 1] = numbers[j] ^ numbers[j + 1];
        //            numbers[j] ^= numbers[j + 1];
        //        }
        //    }
        // }

        // Binsearch the array
        int returnValueBinSearch = Array.BinarySearch(numbers, numberToSearch);
        if (returnValueBinSearch < 0)
        {
            returnValueBinSearch = ~returnValueBinSearch;
            if (returnValueBinSearch >= numbers.Length)
            {
                Console.WriteLine("The biggest number that is less than K is: {0}", numbers[numbers.Length - 1]);
            }
            else if (returnValueBinSearch > 0)
            {
                Console.WriteLine("The biggest number that is less than K is: {0}", numbers[returnValueBinSearch - 1]);
            }
            else
            {
                Console.WriteLine("There is no number in the array that is smaller than K={0}", numberToSearch);
            }
        }
        else
        {
            Console.WriteLine("The number K={2} is equal with element at index {0} in the array, which is: {1}", returnValueBinSearch, numbers[returnValueBinSearch], numberToSearch);
        }

        Console.Write("\nSorted array: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(string.Join(",", numbers));
        Console.ReadKey();
    }

    // Handles user input of all array elements in one line 
    private static int[] EnterElements()
    {
        bool isValidInput = true;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the array elements on one line separated by space (space is ommited).\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Array elements: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                if (input.Length == 0)
                {
                    throw new FormatException();
                }

                int[] numbers = new int[input.Length];
                numbers = input.Select(int.Parse).ToArray();
                Console.ForegroundColor = ConsoleColor.White;
                return numbers;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                isValidInput = false;
            }
        }
        while (!isValidInput);

        return new int[0];
    }

    // Handles user input of single integer
    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}