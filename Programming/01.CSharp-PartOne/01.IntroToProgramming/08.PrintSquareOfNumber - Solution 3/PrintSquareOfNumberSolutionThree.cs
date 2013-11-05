using System;

/// <summary>
/// Task: "8. Create a console application that calculates and prints the square of the number 12345."
/// </summary>
public class PrintSquareOfNumberSolutionThree
{
    public static void Main()
    {
        Console.Title = "Print square of a number - ver.3";
        int number = 12345;
        Console.Write("The square of number {0} is (algorythm using only addition): ", number);
        Console.ForegroundColor = ConsoleColor.Yellow;
        int oddNumber = 1;
        int result = 0;
        for (int countNumber = 0; countNumber < number; countNumber++)
        {
            result += oddNumber;
            oddNumber += 2;
        }

        Console.WriteLine("{0}", result.ToString());
        Console.ReadKey();
    }
}