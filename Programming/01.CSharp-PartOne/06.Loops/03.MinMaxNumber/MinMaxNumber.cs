using System;

/// <summary>
/// Task: "3. Write a program that reads from the console a sequence 
/// of N integer numbers and returns the minimal and maximal of them."
/// </summary>
public class MinMaxNumber
{
    public static void Main()
    {
        Console.Title = "Find Minimal & Maximal number in sequence";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter sequence of numbers (integer) separated by space.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Numbers: ");
        string[] enteredNumbers = Console.ReadLine().Split();
        int[] convertedNumbers = new int[enteredNumbers.Length];
        bool isValidInput = true;
        for (int i = 0; i <= enteredNumbers.Length - 1; i++)
        {
            isValidInput = int.TryParse(enteredNumbers[i], out convertedNumbers[i]);
            if (!isValidInput)
            {
                Console.WriteLine("You've entered incorect values. Press <Enter> to exit.");
                Console.ReadLine();
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nWhich method do you wanna use to find min/max number:\n1.Array sorting\n2.Compare number-by-number\nSelect one: ");
        Console.ForegroundColor = ConsoleColor.Green;
        switch (Console.ReadLine())
        {
            case "1":
                Array.Sort(convertedNumbers);
                Console.WriteLine("Minimal number is: {0}\nMaximal number is: {1}", convertedNumbers[0], convertedNumbers[convertedNumbers.Length - 1]);
                break;
            case "2":

                int min = convertedNumbers[0];
                int max = min;
                for (int i = 1; i <= convertedNumbers.Length - 1; i++)
                {
                    if (min > convertedNumbers[i])
                    {
                        min = convertedNumbers[i];
                    }

                    if (max < convertedNumbers[i])
                    {
                        max = convertedNumbers[i];
                    }
                }

                Console.WriteLine("biggest: {0}\nsmallest: {1}", max, min);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You made invalid selection. Press <Enter> to exit.");
                return;
        }

        Console.ReadKey();
    }
}