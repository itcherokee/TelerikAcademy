using System;

/// <summary>
/// Task: "7. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime."
/// </summary>
public class CheckForPrimeNumber
{
    public static void Main()
    {
        Console.Title = "Check a number is it prime";
        byte numberEntered = 0;
        bool isValidInput = false;
        do
        {
            Console.Write("Please enter a positive number (n<=100) to check is it a prime :");
            isValidInput = byte.TryParse(Console.ReadLine(), out numberEntered);
            if ((numberEntered > 100) || (!isValidInput))
            {
                Console.WriteLine("Your input was not correct. Please try again (press key).");
                Console.ReadKey();
                Console.Clear();
                isValidInput = false;
            }
        }
        while (!isValidInput);

        byte upperBorder = (byte)Math.Sqrt(numberEntered);
        if (numberEntered == 0 || numberEntered == 1)
        {
            Console.WriteLine("Number 0 and 1 are neighter primes nor complex.");
        }
        else if (numberEntered >= 2 && numberEntered <= 7)
        {
            Console.WriteLine("The number you have entered is a prime number!");
        }
        else
        {
            // skip divisors which are even
            if ((numberEntered % 2) != 0) 
            {
                for (int i = 3; i <= upperBorder; i++)
                {
                    if ((numberEntered % i) == 0)
                    {
                        Console.WriteLine("This is not a prime number!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The number you have entered is a prime number!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("This is not a prime number!");
            }
        }

        Console.ReadKey();
    }
}
