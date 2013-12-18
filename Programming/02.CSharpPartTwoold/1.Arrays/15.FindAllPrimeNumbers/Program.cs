using System;
using System.Collections.Generic;

public class Program
{
    // Write a program that finds all prime numbers in the range [1...10 000 000]. 
    // Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

    public static void Main()
    {
        Console.Title = "Find all Prime numbers in [1..10 000 000] range";
        int?[] numberArray = new int?[10000000];
        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i] = i;
        }

        numberArray[0] = null;
        numberArray[1] = null;
        List<int> primeNumbers = new List<int>();
        for (int counter = 2; counter < numberArray.Length; counter++)
        {
            if (numberArray[counter].HasValue)
            {
                primeNumbers.Add(numberArray[counter].Value);
                for (int i = counter; i < numberArray.Length; i += counter)
                {
                    if (numberArray[i].HasValue)
                    {
                        numberArray[i] = null;
                    }
                }
            }
        }

        Console.WriteLine("Primes: {0}", string.Join(", ", primeNumbers));
    }
}