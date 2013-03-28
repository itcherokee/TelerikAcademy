using System;
using System.Numerics;

class SumOfFibonacciNumbers
{
    // Write a program that reads a number N and calculates the sum of the first N members of 
    // the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
    // Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.

    static void Main()
    {
        BigInteger resultSum = 1;
        uint numberN = 2;
        BigInteger prePreviousFibonacci = 0;
        BigInteger previousFibonacci = 1;
        BigInteger exchangeFibonacci = 0;
        bool noError = false;
        Console.Title = "Calculate sum of Fibonacci numbers up to member N";
        Console.WriteLine("PLease enter the member number to calculate the Sum.");
        do
        {
            Console.Write("N [2..] = ");
            noError = uint.TryParse(Console.ReadLine(), out numberN);
            if ((!noError) || (numberN <= 1))
            {
                Console.WriteLine("You have entered symbol(s) or number smaller than 2. Try again.");
                Console.ReadKey();
                noError = false;
            }
        } while (!noError);
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
}