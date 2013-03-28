using System;
using System.Numerics;

class CalculateSum
{
    // Write a program that, for a given two integer numbers N and X,
    // calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N

    static void Main()
    {
        decimal numberN = 1;
        decimal numberX = 1;
        decimal resultSum = 1m;
        decimal power = 1;
        Console.Title = "Calculate the sum of expression S = 1 + 1!/X + 2!/X" + '\u00B2' + "+ … + N!/X" + '\x1DB0';
        numberN = ConsoleInput(numberN, 'N');
        numberX = ConsoleInput(numberX, 'X');
        for (int i = 1; i <= numberN; i++)
        {
            power *= numberX;
            resultSum += (Factorial(i) / power);
        }
        Console.WriteLine("Sum of expresion is: {0:F}", resultSum);
        Console.ReadKey();
    }

    static decimal Factorial(int upperNumber)
    {
        decimal factorialResult = 1;
        for (int i = 1; i <= upperNumber; i++)
        {
            factorialResult *= i;
        }
        return factorialResult;
    }

    static decimal ConsoleInput(decimal numberToEnter, char numberName)
    {
        bool noError = false;
        do
        {
            Console.Write("Enter value for \"{0}\" [1..] = ", numberName);
            noError = decimal.TryParse(Console.ReadLine(), out numberToEnter);
            if ((!noError) || (numberToEnter <= 0))
            {
                Console.WriteLine("You have entered symbol(s) or number {0} less than 1. Try again.", numberName);
                Console.ReadKey();
                Console.Clear();
                noError = false;
            }
        } while (!noError);
        return numberToEnter;
    }
}