using System;
using System.Collections.Generic;

class PrintAllNotDivByThreeAndSeven
{
    static void Main()
    {
        // Write a program that prints all the numbers from 1 to N, 
        // that are not divisible by 3 and 7 at the same time.

        Console.Title = "Prints all numbers from 1 to N not divisible by 3 and 7 at the same time";
        Console.WriteLine("Please enter the upper boundary N of the range to print.");
        bool noError = true;
        uint upperBoundary = 0;
        do
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("N = ");
            noError = uint.TryParse(Console.ReadLine(), out upperBoundary);
            if ((!noError) || (upperBoundary <= 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered nothing, symbol(s), 0 or 1! Try again, press <Enter>.");
                Console.ReadLine();
                Console.Clear();
                noError = false;
            }
        } while (!noError);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Result = ");
        List<int> divisableNumbers = new List<int>();
        for (int i = 1; i <= upperBoundary; i++)
        {
            if (((i % 3 != 0) || (i % 7 != 0)))
            {
                Console.Write(i);
                if (i < upperBoundary)
                {
                    Console.Write(", ");
                }
            }
            else
            {
                divisableNumbers.Add(i);
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

        Console.WriteLine();
        Console.ReadKey();
    }
}
