using System;
using System.Numerics;

/// <summary>
/// Task "9-10. Write a program to calculate the N-th Catalan number by given N."
/// </summary>
public class CalculateCatalanNumber
{
    public static void Main()
    {
        Console.Title = "Calculate N-th Catalan number";
        int numberN = EnterData("Enter the N-th member from Catalan numbers to calculate it. N=");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The N-th Catalan number is: {0}", Factorial(2 * numberN) / (Factorial(numberN + 1) * Factorial(numberN)));
        Console.ReadKey();
    }

    // Calculating Factorial using recursion
    private static BigInteger Factorial(BigInteger upperNumber)
    {
        BigInteger factorialResult = 1;
        for (int count = 1; count <= upperNumber; count++)
        {
            factorialResult *= count;
        }

        return factorialResult;
    }

    // User data input
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