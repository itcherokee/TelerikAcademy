using System;
using System.Linq;

/// <summary>
/// Таск: "6. You are given a sequence of positive integer values written into a string, separated by spaces. 
/// Write a function that reads these values from given string and calculates their sum. 
/// Example: string = "43 68 9 23 318" -> result = 461"
/// </summary>
public class CalculateSumFromSequence
{
    public static void Main()
    {
        Console.Title = "Calculate sum from given sequence of numbers in a string";
        int[] input = EnterNumbers();
        Console.WriteLine("\nSum = {0}", SumSequence(input));
    }

    // Sum sequence of numbers
    private static int SumSequence(int[] sequence)
    {
        return sequence.Sum();
    }

    // Handles user input of all array elements in one line 
    private static int[] EnterNumbers()
    {
        bool isValidInput = true;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the numbers on one line separated by space.\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Numbers: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
                Console.WriteLine("You have entered invalid number(s)! Try again <press any key...>");
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