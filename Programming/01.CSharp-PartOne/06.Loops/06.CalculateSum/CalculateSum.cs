﻿using System;

/// <summary>
/// Task: "6. Write a program that, for a given two integer numbers N and X, 
/// calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N"
/// </summary>
public class CalculateSum
{
    public static void Main()
    {
        Console.Title = "Calculate the sum of expression S = 1 + 1!/X + 2!/X" + '\u00B2' + "+ … + N!/X" + '\x1DB0';
        int numberN = EnterData('N');
        int numberX = EnterData('X');
        decimal resultSum = 1m;
        decimal power = 1;
        for (int count = 1; count <= numberN; count++)
        {
            power *= numberX;
            resultSum += Factorial(count) / power;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sum of expresion is: {0:F}", resultSum);
        Console.ReadKey();
    }

    private static int Factorial(int upperNumber)
    {
        int factorialResult = 1;
        for (int count = 1; count <= upperNumber; count++)
        {
            factorialResult *= count;
        }

        return factorialResult;
    }

    private static int EnterData(char numberName)
    {
        bool isValidInput = false;
        int inputNumber = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter value for \"{0}\" [1..] = ", numberName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out inputNumber);
            if ((!isValidInput) || (inputNumber <= 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered symbol(s) or number {0} less than 1. Try again.", numberName);
                Console.ReadKey();
                Console.Clear();
                isValidInput = false;
            }
        }
        while (!isValidInput);

        return inputNumber;
    }
}