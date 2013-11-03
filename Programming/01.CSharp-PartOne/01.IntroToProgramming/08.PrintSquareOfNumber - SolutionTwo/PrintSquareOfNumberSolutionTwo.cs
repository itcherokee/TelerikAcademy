using System;

/// <summary>
/// Task: "8. Create a console application that calculates and prints the square of the number 12345."
/// </summary>
public class PrintSquareOfNumberSolutionTwo
{
    public static void Main()
    {
        Console.Title = "Print square of a number - ver.2";
        int number = 12345;
        Console.Write("The square of number {0} is: ", number);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("{0}", Math.Pow(number, 2).ToString());
        Console.ReadKey();
    }
}