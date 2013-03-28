using System;
using System.Numerics;

class FactorialDivision
{
    static void Main()
    {
        //Write a program that calculates N!/K! for given N and K (1<K<N).

        Console.Title = "Calculate N!/K!";
        int numberN = 0;
        int numberK = 0;
        BigInteger result = 0;
        bool noError = false;
        Console.WriteLine("Enter value for N and K considering following restriction (1<K<N)");
        do
        {
            Console.Write("N = ");
            noError = int.TryParse(Console.ReadLine(), out numberN);
            if ((!noError) || (numberN <= 2))
            {
                Console.WriteLine("You have entered symbol(s) or number N <= 2. Try again.");
                Console.ReadKey();
                Console.Clear();
                noError = false;
            }
        } while (!noError);
        do
        {
            Console.Write("K = ");
            noError = int.TryParse(Console.ReadLine(), out numberK);
            if (!noError)
            {
                Console.WriteLine("You have entered symbol(s) or wrong number. Try again.");
                Console.ReadKey();
                noError = false;
            }
            else if ((numberK <= 1) || (numberK >= numberN))
            {
                Console.WriteLine("You have entered number K to be <= 1 or >= to N. Try again.");
                Console.ReadKey();
                noError = false;
            }
        } while (!noError);
        BigInteger a = Factorial(numberN);
        BigInteger b = Factorial(numberK);
        result = Factorial(numberN) / Factorial(numberK);
        Console.WriteLine("Result is: {0}", result);
        Console.ReadKey();
    }

    static BigInteger Factorial(int upperNumber)
    {
        BigInteger factorialResult = 1;
        for (int i = 1; i <= upperNumber; i++)
        {
            factorialResult *= i;
        }
        return factorialResult;
    }

}
