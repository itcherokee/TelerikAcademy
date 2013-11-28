using System;
using System.Numerics;

/// <summary>
/// Task: "5. Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K)."
/// </summary>
public class FactorialDivision
{
    public static void Main()
    {
        Console.Title = "Calculate N!*K! / (K-N)!";
        Console.WriteLine("Enter value for N and K considering following restriction (1<N<K)");
        int numberK = EnterData("K = ", Number.NumberK);
        int numberN = EnterData("N = ", Number.NumberN);
        if (numberK <= numberN)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have violated the restriction (1<N<K) - N can't be equal or bigger than K.\nProgram will exit now!");
            return;
        }

        BigInteger result = (Factorial(numberN) * Factorial(numberK)) / Factorial(numberK - numberN);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Result is: {0}", result);
        Console.ReadKey();
    }

    // Calculates Factorial using recursion
    private static BigInteger Factorial(int upperNumber)
    {
        BigInteger factorialResult = 1;
        for (int count = 1; count <= upperNumber; count++)
        {
            factorialResult *= count;
        }

        return factorialResult;
    }

    // Input of user data
    private static int EnterData(string message, Number number)
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
            else
            {
                switch (number)
                {
                    case Number.NumberK:
                        if (enteredValue <= 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have entered number K <= 2. Try again.");
                            Console.ReadKey();
                            Console.Clear();
                            isValidInput = false;
                        }

                        break;
                    case Number.NumberN:
                        if (enteredValue <= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have entered number N to be <= 1. Try again.");
                            Console.ReadKey();
                            Console.Clear();
                            isValidInput = false;
                        }

                        break;
                    default:
                        break;
                }
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}