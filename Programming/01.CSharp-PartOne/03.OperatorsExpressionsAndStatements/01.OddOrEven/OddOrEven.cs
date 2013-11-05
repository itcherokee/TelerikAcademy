using System;

/// <summary>
/// Task: "1. Write an expression that checks if given integer is odd or even."
/// </summary>
public class OddOrEven
{
    public static void Main()
    {
        Console.Title = "Number is Odd or Even?";
        int checkedNumber = 0;
        bool isValidInput = false;
        do
        {
            Console.Write("Enter an integer number to check is it odd or even: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out checkedNumber);
            if (isValidInput)
            {
                Console.WriteLine("The number you entered is {0}.", ((checkedNumber % 2) == 0) ? "EVEN" : "ODD");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number or not a number at all! <Press a key...>");
                Console.ReadKey();
                Console.Clear();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
        while (!isValidInput);

        Console.ReadKey();
    }
}
