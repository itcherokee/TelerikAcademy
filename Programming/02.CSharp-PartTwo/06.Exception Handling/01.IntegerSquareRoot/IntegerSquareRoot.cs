using System;

/// <summary>
/// Task: "1. Write a program that reads an integer number and calculates and prints its square root.
/// If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". 
/// Use try-catch-finally."
/// </summary>
public class IntegerSquareRoot
{
    public static void Main()
    {
        Console.Title = "Calculate square root of an integer.";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter an integer number to calculate the square root: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        try
        {
            int enteredNumber = int.Parse(Console.ReadLine());
            if (enteredNumber < 0)
            {
                string message = "You have entered a negative number!\nSquare root is not defined for negative numbers.";
                throw new ArgumentOutOfRangeException(message);
            }

            Console.WriteLine(Math.Sqrt(enteredNumber));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (OverflowException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Good bye!");
            Console.Read();
        }
    }
}