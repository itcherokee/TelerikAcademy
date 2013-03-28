using System;

class ThreeIntegers
{
    static void Main()
    {
        //Write a program that reads 3 integer numbers from the console and prints their sum.

        int a, b, c;
        Console.Title = "Sum of 3 numbers";
        Console.WriteLine("Calculating sum of three numbers.");
        Console.Write("Enter first number:");
        a = int.Parse(Console.ReadLine());
        Console.Write("Enter second number:");
        b = int.Parse(Console.ReadLine());
        Console.Write("Enter third number:");
        c = int.Parse(Console.ReadLine());
        Console.WriteLine("The Sum of numbers {0}, {1} and {2} is {3}", a, b, c, a + b + c);
        Console.ReadKey();
    }
}
