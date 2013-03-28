using System;
using System.Numerics;

class CalculateCatalanNumber
{
    // Write a program to calculate the N-th Catalan number by given N.

    static void Main()
    {
        Console.Title = "Calculate N-th Catalan number";
        int numberN = 0;
        bool noError = false;
        Console.WriteLine("Enter the N-th member from Catalan numbers to calculate it.");
        do
        {
            Console.Write("N = ");
            noError = int.TryParse(Console.ReadLine(), out numberN);
            if (!noError)
            {
                Console.WriteLine("You have entered symbol(s) or wrong number. Try again.");
                Console.ReadKey();
                Console.Clear();
                noError = false;
            }
        } while (!noError);
        Console.WriteLine("The N-th Catalan number is: {0}", ( Factorial(2 * numberN) / (Factorial(numberN + 1) * Factorial(numberN))));
        Console.ReadKey();
    }

    static BigInteger Factorial(BigInteger upperNumber)
    {
        BigInteger factorialResult = 1;
        for (int i = 1; i <= upperNumber; i++)
        {
            factorialResult *= i;
        }
        return factorialResult;
    }
}
