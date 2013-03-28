using System;

public class TwentyIntegers
{
    public static void Main()
    {
        // Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
        // Print the obtained array on the console.

        Console.Title = "Initialize and print an array of 20 integers";
        int[] arrayNumbers = new int[20];
        for (int i = 0; i < arrayNumbers.Length; i++)
        {
            arrayNumbers[i] = i * 5;
            Console.Write("{0} ", arrayNumbers[i]);
        }

        Console.WriteLine();
    }
}