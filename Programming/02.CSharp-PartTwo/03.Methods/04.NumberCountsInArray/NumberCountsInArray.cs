using System;
using System.Linq;

/// <summary>
/// Task: "4. Write a method that counts how many times given number appears in given array. 
/// Write a test program to check if the method is working correctly."
/// </summary>
public class NumberCountsInArray
{
    public static void Main()
    {
        Console.Title = "Counts times that one number appears in sequence of numbers.";
        int[] numbers = EnterElements();
        int numberToCount = EnterData("Enter the number to be searched & counted in the sequence: ");
        Print(CountOcurances(numbers, numberToCount));
        Console.WriteLine();
        Console.ReadKey();
    }

    // Counts how many times given number appears in given array
    private static int CountOcurances(int[] numbers, int digit)
    {
        // Using LINQ extension method (with lambda expresion ) to count the occurances of number
        // It iterate through array and counts where element (x) is equal to digit we count
        return numbers.Count(x => x == digit);
    }

    // Output to Console of the result
    private static void Print(int result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nYour number appears ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(result);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" times in the sequence.");
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Handles user input of single integer value
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