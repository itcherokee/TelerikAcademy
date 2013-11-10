using System;
using System.Numerics;

/// <summary>
/// Task: "9. Write a program to print the first 100 members of the sequence of 
/// Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …"
/// </summary>
public class Fibonacci
{
    public static void Main()
    {
        Console.Title = "First 100 Fibonacci numbers";
        BigInteger numberOne = 0;
        BigInteger numberTwo = 1;
        BigInteger currentNumber = numberOne;
        PrintHeader();
        for (int i = 0; i <= 100; i++)
        {
            Console.WriteLine("|{0,3}| {1,22}|", i, currentNumber);
            numberOne = numberTwo;
            numberTwo = currentNumber;
            currentNumber = numberOne + numberTwo;
            if (i == 100)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any key to Exit.");
                Console.ReadKey();
                break;
            }
            else
            {
                // implementing sort of paging on the screen
                if (i % 20 == 0 && i != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    PrintHeader();
                }
            }
        }
    }

    /// <summary>
    /// Prints table header.
    /// </summary>
    private static void PrintHeader()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-----------------------------");
        Console.Write("|");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("{0,2}", "N");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("{0,2}", "|");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("{0,15}", "Number");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("{0,9}", "|");
        Console.WriteLine("-----------------------------");
        Console.ForegroundColor = ConsoleColor.White;
    }
}