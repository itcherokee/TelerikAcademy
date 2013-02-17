using System;

public class ReturnDigitAsWord
{
    // Write a method that returns the last digit of given integer 
    // as an English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

    public static void Main()
    {
        Console.Title = "Return last digit as a word.";
        Console.Write("Enter an integer number: ");
        int inputNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Last digit in that number is \"{0}\"", LastDigit(inputNumber));
    }

    private static string LastDigit(int number)
    {
        string[] digitWords = new string[10] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digitWords[number % 10];
    }
}