using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Task: "21. Write a program that reads two numbers N and K and generates all the combinations 
/// of K distinct elements from the set [1..N]. 
/// Example: N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}"
/// 
///      1 = N-1 kombinations (N-4, N-3..N)
///      2 = N-2 kombinations (N-3, N-2..N)
///      3 = N-3 kombinations (N-2, N-1..N)
///      4 = N-4 kombinations (N-1, N)
/// </summary>
public class CombinationsDistinct
{
    private static int[] numbers;
    private static int shift = 0;

    public static void Main()
    {
        Console.Title = "Print all combinations of K distinct elements from set [1..N].";
        int upperBound = EnterData("Enter upper bound of set [1..(N)]: ");
        numbers = new int[upperBound];
        int combinationSize = EnterData("Enter number of elements to combine (K): ");
        Console.WriteLine("\nAll possible distinct combinations follow...");
        Console.ForegroundColor = ConsoleColor.Green;
        Combinate(0, combinationSize, upperBound);
        Console.WriteLine();
        Console.ReadKey();
    }

    // Combination calculations
    private static void Combinate(int currentBound, int combinationSize, int upperBound)
    {
        // If we have constructed the required combination, output to the Console
        // and take one step back from recursion (starting calculation of the new combination).
        if (combinationSize == currentBound)
        {
            Print(combinationSize);
            return;
        }

        for (int i = 1 + currentBound + shift; i <= upperBound; i++)
        {
            numbers[currentBound] = i;
            Combinate(currentBound + 1, combinationSize, upperBound);
        }

        shift++;
    }

    // Prints single combination to the Console
    private static void Print(int combinationSize)
    {
        Console.Write("{");
        Console.Write(string.Join(",", numbers.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray(), 0, combinationSize));
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