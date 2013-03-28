using System;

class PrintScope
{
    static void Main()
    {
        //Write a program that reads an integer number n from the console 
        //and prints all the numbers in the interval [1..n], each on a single line.

        Console.Title = "Print all numbers in range [1..n]";
        Console.Write("Enter number (n): ");
        int numberOne = int.Parse(Console.ReadLine());
        for (int i = 1; i < (numberOne+1); i++)
        {
            Console.WriteLine(i);
        }
        Console.ReadKey();
    }
}