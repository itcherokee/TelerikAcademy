using System;

class CheckForPrimeNumber
{
    static void Main()
    {
        //Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

        byte numberEntered = 0;
        bool correctInput = false;
        Console.Title = "Check a number is it prime";
        // Console input management
        do
        {
            Console.Write("Please enter a positive number (n<=100) to check is it a prime :");
            correctInput = byte.TryParse(Console.ReadLine(), out numberEntered);
            if ((numberEntered > 100) || (!correctInput))
            {
                Console.WriteLine("Your input was not correct. Please try again (press key).");
                Console.ReadKey();
                Console.Clear();
                correctInput = false;
            }
        } while (!correctInput);
        // Calculations
        byte upperBorder = (byte)Math.Sqrt(numberEntered);
        switch (numberEntered)
        {
            case 0:
            case 1: PrintMessage(1); break;
            case 2:
            case 3:
            case 5:
            case 7: PrintMessage(2); break;
            default:
                if ((numberEntered % 2) != 0) //skip divisors which are even
                {
                    for (int i = 3; i <= upperBorder; i++)
                    {
                        if ((numberEntered % i) == 0)
                        {
                            PrintMessage(3); break;
                        }
                        else
                        {
                            PrintMessage(2); break;
                        }
                    }
                }
                else
                {
                    PrintMessage(3);
                }
                break;
        }
        Console.ReadKey();
    }

    //Prints messages for different results
    static void PrintMessage(byte message)
    {
        switch (message)
        {
            case 1: Console.WriteLine("Number 0 and 1 are neighter primes nor complex."); break;
            case 2: Console.WriteLine("The number you have entered is prime a number!"); break;
            case 3: Console.WriteLine("This is not a prime number!"); break;
        }
    }
}
