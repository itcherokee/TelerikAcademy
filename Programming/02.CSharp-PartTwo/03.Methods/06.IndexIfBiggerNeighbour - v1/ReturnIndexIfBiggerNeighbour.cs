using System;
using System.Linq;

/// <summary>
/// Task: "6. Write a method that returns the index of the first element in array that is bigger 
/// than its neighbors, or -1, if there’s no such element.
/// - Use the method from the previous exercise."
/// 
/// Note: First and last elements of the array are also included in search. The reason is that they have 
///       only one neighbour (the other could be considered as nothing) and if they are bigger than that 
///       neighbour (they are also bigger than nothing), so they are winners.
/// </summary>
public class ReturnIndexIfBiggerNeighbour
{
    public static void Main()
    {
        Console.Title = "Find first bigger element than it's neighbours.";
        int[] numbers = EnterElements();

        int elementIndex = FirstBigger(numbers);
        if (elementIndex != -1)
        {
            Console.WriteLine("First element bigger between neighbours is at the index position {0} (number {1}).", elementIndex, numbers[elementIndex]);
        }
        else
        {
            Console.WriteLine("There is no element that is bigger than it's neighbours!");
        }

        Console.ReadKey();
    }

    // Finds first bigger element in between it's neighbours
    public static int FirstBigger(int[] array)
    {
        int numberIndex = -1;
        if (array.Length != 1)
        {
            for (int index = 0; index < array.Length; index++)
            {
                bool result = IsBigger(array, index) ?? false;
                if (result)
                {
                    numberIndex = index;
                    break;
                }
            }
        }

        return numberIndex;
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