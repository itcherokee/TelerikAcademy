﻿using System;
using System.Collections.Generic;

/// <summary>
/// Task: "2. Write a program that prints all the numbers from 1 to N, 
/// that are not divisible by 3 and 7 at the same time."
/// </summary>
public class PrintAllNotDivByThreeAndSeven
{
    public static void Main()
    {
        Console.Title = "Prints all numbers from 1 to N not divisible by 3 and 7 at the same time";
        uint upperBoundary = EnterData("Please enter the upper boundary of the range. N=");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Result = ");
        List<int> divisableNumbers = new List<int>();
        for (int count = 1; count <= upperBoundary; count++)
        {
            if ((count % 3 != 0) || (count % 7 != 0))
            {
                Console.Write(count);
                if (count < upperBoundary)
                {
                    Console.Write(", ");
                }
            }
            else
            {
                divisableNumbers.Add(count);
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        if (divisableNumbers.Count > 0)
        {
            Console.Write("Numbers that are divisable by 3 & 7 at the same time are: ");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in divisableNumbers)
            {
                Console.Write(item + " ");
            }
        }
        else
        {
            Console.WriteLine("There were no numbers divisable by 3  & 7 at the same time.");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.ReadKey();
    }

    private static uint EnterData(string message)
    {
        bool isValidInput = default(bool);
        uint enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
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