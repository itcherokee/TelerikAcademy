using System;

public class ReadNumberMethod
{
    // Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
    // If an invalid number or non-number text is entered, the method should throw an exception. 
    // Using this method write a program that enters 10 numbers:
    // a1, a2, … a10, such that 1 < a1 < … < a10 < 100

    private static string[] ends = { "st", "nd", "rd", "th" };

    public static void Main()
    {
        Console.Title = "Implement ReadNumber to enter numbers in range [2..99]";
        Console.WriteLine("Condition for number (a) input is (1 < a1 < … < a10 < 100).");
        int start = 1;
        int end = 99;
        try
        {
            for (int index = 1; index < 11; index++)
            {
                start = ReadNumber(start, end, index);
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }

    private static int ReadNumber(int start, int end, int currentElement)
    {
        Console.Write("Please enter {0}{1} number: ", currentElement, currentElement < 4 ? ends[currentElement - 1] : ends[3]);
        int enteredNumber = int.Parse(Console.ReadLine());
        if (enteredNumber <= start || enteredNumber >= end)
        {
            string msg = string.Format("Number entered was smaller than {0} or bigger than {1}!", start + 1, end);
            throw new ArgumentOutOfRangeException(msg);
        }

        if (enteredNumber > (89 + currentElement))
        {
            string msg = string.Format("Current number should be in the range {0}..{1}!", start + 1, 89 + currentElement);
            throw new ArgumentOutOfRangeException(msg);
        }

        return enteredNumber;
    }
}