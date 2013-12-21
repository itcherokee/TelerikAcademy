using System;
using System.Collections.Generic;

/// <summary>
/// Task: "15. Write a program that finds all prime numbers in the range [1...10 000 000]. 
/// Use the sieve of Eratosthenes algorithm."
/// </summary>
public class FindAllPrimeNumbers
{
    public static void Main()
    {
        Console.Title = "Find all Prime numbers in [1..10 000 000] range";
        int?[] numberArray = new int?[10000000];

        // load array with numbers from loop index
        for (int i = 0; i < numberArray.Length; i++)
        {
            numberArray[i] = i;
        }

        numberArray[0] = null;
        numberArray[1] = null;

        // List will hold all primes that we discover
        List<int> primeNumbers = new List<int>();

        // Eratosthenes algorythm
        Console.Write("Calculating...");
        for (int counter = 2; counter < numberArray.Length; counter++)
        {
            if (numberArray[counter].HasValue)
            {
                primeNumbers.Add(numberArray[counter].Value);

                // loops and "nulls" all next numbers in the array that are double of counter index
                for (int i = counter; i < numberArray.Length; i += counter)
                {
                    if (numberArray[i].HasValue)
                    {
                        numberArray[i] = null;
                    }
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nDo you want preview of all numbers (Y/N): ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string answer = Console.ReadLine();
        if (answer == "Y" || answer == "y")
        {
            Console.WriteLine("Primes: {0}", string.Join(", ", primeNumbers));
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Total prime numbers in the range are: {0}", primeNumbers.Count);
        Console.ReadKey();
    }
}