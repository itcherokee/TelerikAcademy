using System;

public class GeneratePrintRandomNumbers
{
    // Write a program that generates and prints to the console 10 random values in the range [100, 200].

    public static void Main()
    {
        Console.Title = "Generate and Print 10 random numbers within scope 100-200";
        Random numberGenerator = new Random();
        int numberInScope = 0;
        Console.Write("Random numbers: ");
        for (int itteration = 0; itteration < 10; itteration++)
        {
            numberInScope = numberGenerator.Next(100, 201);
            Console.Write("{0,-4}", numberInScope);
        }

        Console.WriteLine();
    }
}