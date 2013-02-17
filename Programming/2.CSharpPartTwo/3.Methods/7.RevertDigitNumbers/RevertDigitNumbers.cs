using System;

public class RevertDigitNumbers
{
    // Write a method that reverses the digits of given decimal number. Example: 256 -> 652

    public static void Main()
    {
        Console.Title = "Reverse the digits in a number";
        Console.Write("Enter a number:");
        string numberEntered = Console.ReadLine();
        Console.WriteLine("Entered number reversed looks like that: {0}", Reverse(numberEntered));
    }

    private static string Reverse(string number)
    {
        int[] arrayOfNumbers = new int[number.Length];
        int wholeNumber = int.Parse(number);
        int multiplyer = 10;
        for (int index = 0; index < number.Length; index++)
        {
            arrayOfNumbers[index] = wholeNumber % multiplyer;
            wholeNumber /= multiplyer;            
        }

        string result = string.Empty;
        foreach (var digit in arrayOfNumbers)
        {
            result += digit;
        }

        return result.TrimStart('0');
    }
}