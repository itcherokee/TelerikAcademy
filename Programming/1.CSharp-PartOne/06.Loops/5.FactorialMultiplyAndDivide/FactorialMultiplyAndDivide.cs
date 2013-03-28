using System;
using System.Numerics;

class FactorialDivision
{
    static void Main()
    {
        //Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

        Console.Title = "Calculate N!*K! / (K-N)!";
        int numberN = 0;
        int numberK = 0;
        BigInteger result = 0;
        bool noError = false;
        Console.WriteLine("Enter value for N and K considering following restriction (1<N<K)");
        do
        {
            Console.Write("K = ");
            noError = int.TryParse(Console.ReadLine(), out numberK);
            if ((!noError) || (numberK <= 2))
            {
                Console.WriteLine("You have entered symbol(s) or or number K <= 2. Try again.");
                Console.ReadKey();
                noError = false;
            }
        } while (!noError);
        do
        {
            Console.Write("N = ");
            noError = int.TryParse(Console.ReadLine(), out numberN);
            if (!noError)
            {
                Console.WriteLine("You have entered symbol(s) or wrong number. Try again.");
                Console.ReadKey();
                noError = false;
            }
            else if ((numberN <= 1) || (numberN >= numberK))
            {
                Console.WriteLine("You have entered number N to be <= 1 or >= to K. Try again.");
                Console.ReadKey();
                noError = false;
            }
        } while (!noError);

        result = (Factorial(numberN) * Factorial(numberK)) / Factorial(numberK - numberN);
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
