using System;

public class IntegerSquareRoot
{
    // Write a program that reads an integer number and calculates and prints its square root. 
    // If the number is invalid or negative, print "Invalid number". In all cases finally 
    // print "Good bye". Use try-catch-finally.

    public static void Main()
    {
        Console.Title = "Calculate square root of an integer.";
        Console.Write("Enter an integer number to calculate the square root: ");
        try
        {
            int enteredNumber = int.Parse(Console.ReadLine());
            if (enteredNumber < 0)
            {
                throw new ArgumentOutOfRangeException("You have entered a negative number!\nSquare root is not defined for negative numbers.");
            }

            Console.WriteLine(Math.Sqrt((double)enteredNumber));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);

        }
        catch (OverflowException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.Error.WriteLine("Good bye!");
        }
    }
}