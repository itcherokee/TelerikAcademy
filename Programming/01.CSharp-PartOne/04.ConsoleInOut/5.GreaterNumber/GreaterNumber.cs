using System;

class GreaterNumber
{
    static void Main()
    {
        //Write a program that gets two numbers from the console 
        //and prints the greater of them. Don’t use if statements.

        double numberOne, numberTwo;
        Console.Title = "Find greater number v.1";
        Console.Write("Enter first number: ");
        numberOne = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        numberTwo = double.Parse(Console.ReadLine());
        Console.WriteLine("Bigger number is: {0}", Math.Max(numberOne, numberTwo));
        Console.ReadKey();
    }
}

