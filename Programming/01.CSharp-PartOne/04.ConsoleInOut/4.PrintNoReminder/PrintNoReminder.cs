using System;

class PrintNoReminder
{
    static void Main()
    {
        //Write a program that reads two positive integer numbers and 
        //prints how many numbers p exist between them such that the 
        //reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

        Console.Title = "Print all numbers devided by 5 in a range without reminder";
        Console.Write("Enter first digit (left border): ");
        int numberOne = int.Parse(Console.ReadLine());
        Console.Write("Enter second digit (right border): ");
        int numberTwo = int.Parse(Console.ReadLine());
        int totalNumbers = 0;
        for (int i = Math.Min(numberOne, numberTwo); i < (Math.Max(numberOne, numberTwo) + 1); i++)
        {
            totalNumbers = totalNumbers + (((i % 5) == 0) ? 1 : 0);
        }
        Console.WriteLine("The total number of numbers, which devide by 5 in selected range is: {0}", totalNumbers);
        Console.ReadKey();
    }
}