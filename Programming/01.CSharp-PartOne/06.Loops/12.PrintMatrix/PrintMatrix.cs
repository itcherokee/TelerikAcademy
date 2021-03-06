﻿using System;

/// <summary>
/// Task "12. Write a program that reads from the console 
/// a positive integer number N (N < 20) and outputs a matrix"
/// </summary>
public class PrintMatrix
{
    public static void Main()
    {
        Console.Title = "Print a matrix";
        byte numberN = EnterData("Enter upper border of sequence [2..20] = ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int count = 1; count <= numberN; count++)
        {
            for (int k = count; k <= (count + numberN - 1); k++)
            {
                Console.Write("{0,3}", k);
            }

            Console.WriteLine();
        }
    }

    private static byte EnterData(string message)
    {
        bool isValidInput = default(bool);
        byte enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = byte.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput || (enteredValue <= 1) || (enteredValue > 20))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}
