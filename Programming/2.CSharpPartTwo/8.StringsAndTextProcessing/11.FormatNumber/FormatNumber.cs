using System;

public class FormatNumber
{
    // Write a program that reads a number and prints it as a decimal number, 
    // hexadecimal number, percentage and in scientific notation. 
    // Format the output aligned right in 15 symbols.

    public static void Main()
    {
        Console.Title = "Formating a number in different ways";
        Console.Write("Enter a number: ");
        double userInput = double.Parse(Console.ReadLine());
        Console.WriteLine("Result:");
        Console.WriteLine("Decimal    :   {0,15:N0}", (int)userInput);
        Console.WriteLine("Hexadecimal: 0x{0:x15}", (int)userInput);
        Console.WriteLine("Percentage :   {0,15:P}", userInput / 100);
        Console.WriteLine("Scientific :   {0,15:E}", userInput);
    }
}