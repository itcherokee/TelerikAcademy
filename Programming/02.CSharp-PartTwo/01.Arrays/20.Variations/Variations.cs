using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Task: "20. Write a program that reads two numbers N and K and generates all the variations 
/// of K elements from the set [1..N]. 
/// 
/// Example: N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}"
/// </summary>
public class Variations
{
    private static int[] numbers;

    public static void Main()
    {
        Console.Title = "Print all combinations of K elements from set [1..N].";
        int upperBound = EnterData("Enter upper bound of set [1..(N)]: ");
        numbers = new int[upperBound];
        int variationSize = EnterData("Enter number of elements to combine (K): ");
        Console.WriteLine("\nAll possible variations follow...");
        Console.ForegroundColor = ConsoleColor.Green;
        Variate(0, variationSize, upperBound);
        Console.WriteLine();
        Console.ReadKey();
    }

    /// <summary>
    /// Calculates the possible variations
    /// </summary>
    /// <param name="cuurentBound">Current bound of the variation (up to now).</param>
    /// <param name="variationSize">The total size of the variation to be constructed.</param>
    /// <param name="upperBound">The size of the numbers range that is initialy provided.</param>
    private static void Variate(int cuurentBound, int variationSize, int upperBound)
    {
        if (variationSize == cuurentBound)
        {
            Print(variationSize);
            return;
        }

        for (int i = 1; i <= upperBound; i++)
        {
            numbers[cuurentBound] = i;
            Variate(cuurentBound + 1, variationSize, upperBound);
        }
    }

    // Prints single variation to the Console
    private static void Print(int variationSize)
    {
        Console.Write("{");
        Console.Write(string.Join(",", numbers.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray(), 0, variationSize));
        Console.Write("} ");
    }

    // Handles user input
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