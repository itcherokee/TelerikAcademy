using System;
using System.Numerics;

/// <summary>
///  Task: "7. Write a program that reads a number N and calculates the sum of the first N members of 
/// the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
/// Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.
/// </summary>
public class SumOfFibonacciNumbers
{
    public static void Main()
    {
        Console.Title = "Calculate sum of Fibonacci numbers up to member N";

        uint numberN = EnterData();

        BigInteger resultSum = 1;
        BigInteger prePreviousFibonacci = 0;
        BigInteger previousFibonacci = 1;
        BigInteger exchangeFibonacci = 0;
        Console.Write("Fibonacci: 0 1 ");
        for (int i = 3; i <= numberN; i++)
        {
            exchangeFibonacci = prePreviousFibonacci + previousFibonacci;
            resultSum += exchangeFibonacci;
            Console.Write(exchangeFibonacci + " ");
            prePreviousFibonacci = previousFibonacci;
            previousFibonacci = exchangeFibonacci;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nSum of all Fibinacci up to member {0} is: {1}", numberN, resultSum);
    }

    private static uint EnterData()
    {
        bool isValidInput = default(bool);
        uint enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("PLease enter the member number to calculate the Sum.");
            Console.Write("N [2..] = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
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