using System;

class GreaterNumber
{
    static void Main()
    {
        //Write a program that gets two numbers from the console 
        //and prints the greater of them. Don’t use if statements.

        int numberOne, numberTwo;
        int maxNumber, difference, checkSign;
        //input
        Console.Title = "Find greater number v.2";
        Console.Write("Enter first number: ");
        numberOne = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        numberTwo = int.Parse(Console.ReadLine());
        //logic
        difference = numberOne - numberTwo;
        checkSign = (difference >> 31) & 0x1;
        maxNumber = numberOne - checkSign * difference;
        Console.WriteLine("Bigger number is: {0}", maxNumber);
        Console.ReadKey();
    }
}