using System;
using System.Linq;
using System.Text;

/// <summary>
/// Task: "5. Write a method that checks if the element at given position in given array of integers
/// is bigger than its two neighbors (when such exist)."
/// 
/// Note: First and last elements of the array are also included in search. The reason is that they have 
///       only one neighbour (the other could be considered as nothing) and if they are bigger than that 
///       neighbour (they are also bigger than nothing), so they are winners.
/// </summary>
public class CheckNeighboursAreSmaller
{
    public static void Main()
    {
        Console.Title = "Check element at position in array is bigger than direct neighbours.";
        int[] numbers = EnterElements();
        int numberToCompare = EnterData("Enter the element's index to check it's value (starting from 0 index): ");
        bool? evaluationResult = IsBigger(numbers, numberToCompare);
        PrintResult(numberToCompare, evaluationResult);
        Console.WriteLine();
        Console.ReadKey();
    }

    // Checks does number at index ara bigger than it's neighbours
    public static bool? IsBigger(int[] array, int index)
    {
        bool? result = null;
        if ((array.Length != 1) && (index >= 0) && (index <= array.Length - 1))
        {
            if (index == 0)
            {
                // first element in array
                result = array[index] > array[index + 1];
            }
            else if (index == array.Length - 1)
            {
                // last element in array
                result = array[index] > array[index - 1];
            }
            else
            {
                // internal element in array
                result = array[index] > array[index + 1] && array[index] > array[index - 1];
            }
        }

        // if result equal to null => only one element entered in the array or non-existing index requested
        return result;
    }

    // Output to Console the result
    private static void PrintResult(int index, bool? isBigger = null)
    {
        if (isBigger.HasValue)
        {
            switch (isBigger.Value)
            {
                case true:
                    Console.WriteLine("Yes, the element at position {0} is bigger than it's neighbour(s).", index);

                    break;
                case false:
                    Console.WriteLine("No, the element at position {0} is smaller than it's neighbour(s) or one of them.", index);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Your sequence contains only one element or you have requested non existing index!");
        }
    }

    // Handles the user input of single integer value
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
}
