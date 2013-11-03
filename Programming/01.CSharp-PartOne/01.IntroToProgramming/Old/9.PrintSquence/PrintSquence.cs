using System;

/// <summary>
/// Task: "9. Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ..."
/// </summary>
public class PrintSquence
{
    public static void Main()
    {
        Console.Title = "Print a sequence of 2, -3, 4, -5, 6, -7, ...";
        Console.Write("First 10 members of sequence are: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int sequenceNumber = 2; sequenceNumber <= 11; sequenceNumber++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if ((sequenceNumber % 2) == 0)
            {
                Console.Write(sequenceNumber.ToString());
            }
            else
            {
                Console.Write((sequenceNumber * -1).ToString());
            }

            Console.ForegroundColor = ConsoleColor.White;

            // separate secuence members by comma
            if (sequenceNumber < 11)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
        Console.ReadKey();
    }
}