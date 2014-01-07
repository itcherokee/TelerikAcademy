using System;

/// <summary>
/// Task: "11. Write a program that reads a number and prints it as a decimal number, hexadecimal number,
/// percentage and in scientific notation. Format the output aligned right in 15 symbols."
/// </summary>
public class FormatNumber
{
    public static void Main()
    {
        Console.Title = "Formating a number in different ways";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter a number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        double userInput = double.Parse(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nNumber {0} in different formats:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nDecimal    :   {0,15:N0}", (int)userInput);
        Console.WriteLine("Hexadecimal: 0x{0:X15}", (int)userInput);
        Console.WriteLine("Percentage :   {0,15:P}", userInput / 100);
        Console.WriteLine("Scientific :   {0,15:E}\n", userInput);
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}