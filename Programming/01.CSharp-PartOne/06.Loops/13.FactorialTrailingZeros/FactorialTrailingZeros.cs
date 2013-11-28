using System;
using System.Numerics;

/// <summary>
/// Task "13. * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. 
/// Examples:
/// N = 10 -> N! = 3628800 -> 2
/// N = 20 -> N! = 2432902008176640000 -> 4
/// Does your program work for N = 50 000? -> YES
/// </summary>
public class TrailingZeros
{
    public static void Main()
    {
        Console.Title = "Calculate trailing zeros in N!";
        uint numberInput = EnterData("Please enter a number: ");

        // Calculate factorial for output
        BigInteger factorialResult = 1;
        if (numberInput == 0)
        {
            factorialResult = 1;
        }
        else
        {
            for (int count = 1; count <= numberInput; count++)
            {
                factorialResult *= count;
            }
        }

        // Calculate trailing zeros
        long operationalResult = 0;
        int divisor = 5;
        long zerosCount = 0;
        do
        {
            operationalResult = numberInput / divisor;
            if (operationalResult == 0) 
            {
                break;
            }

            zerosCount += operationalResult;
            divisor *= 5;
        }
        while (true);

        // Output to Console
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("In {0}!={1} there {2} {3} trailing zero(s).", numberInput, factorialResult, zerosCount > 1 ? "are" : "is", zerosCount);
        Console.ReadKey();
    }

    private static uint EnterData(string message)
    {
        bool isValidInput = default(bool);
        uint enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
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