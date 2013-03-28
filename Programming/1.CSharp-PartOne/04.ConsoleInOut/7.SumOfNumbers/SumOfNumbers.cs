using System;

class SumOfNNumbers
{
    static void Main()
    {
        //Write a program that gets a number n and after that gets 
        //more n numbers and calculates and prints their sum. 

        Console.Title = "Sum of all entered numbers";
        Console.Write("Enter the number of digits to be entered (sum): ");
        long totalNumbers = 0;
        long sumOfAllNumbers = 0;
        totalNumbers = long.Parse(Console.ReadLine());
        for (int i = 0; i < totalNumbers; i++)
        {
            Console.Write("Enter digit number {0}: ", i + 1);
            sumOfAllNumbers += long.Parse(Console.ReadLine());
        }
        Console.WriteLine("Sum of all entered numbers is {0}: ", sumOfAllNumbers);
        Console.ReadKey();
    }
}

