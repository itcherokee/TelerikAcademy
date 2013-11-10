using System;
using System.Collections.Generic;

/// <summary>
/// Task: "4. Write a program that reads two positive integer numbers and prints how many 
/// numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). 
/// Example: p(17,25) = 2."
/// </summary>
public class PrintNoReminder
{
    public static void Main()
    {
        Console.Title = "Print all numbers devided by 5 in a range without reminder";
        Console.ForegroundColor = ConsoleColor.White;
        int numberOne = EnterData("Enter first digit (left border): ");
        int numberTwo = EnterData("Enter second digit (right border): ");

        // if left border value is bigger than right one -> swap them
        if (numberTwo - numberOne < 0)
        {
            numberOne = numberOne ^ numberTwo;
            numberTwo = numberOne ^ numberTwo;
            numberOne = numberOne ^ numberTwo;
        }

        int totalNumbers = default(int);
        List<int> numbers = new List<int>();
        for (int i = numberOne; i < numberTwo + 1; i++)
        {
            int divisableNumber = i % 5;
            if (divisableNumber == 0)
            {
                totalNumbers++;

                // Adds divisable by 5 number into a list for later print on Console
                numbers.Add(i);
            }
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The total number of numbers, which devide by 5 in range [{0}..{1}] is: {2}", numberOne, numberTwo, totalNumbers);
        Console.WriteLine("These numbers are: {0}", string.Join(", ", numbers));
        Console.ReadKey();
    }

    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
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