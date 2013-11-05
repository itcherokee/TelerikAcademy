using System;

/// <summary>
/// Task: "2. Write a boolean expression that checks for given integer 
/// if it can be divided (without remainder) by 7 and 5 in the same time."
/// </summary>
public class DivideBySevenAndFive
{
    public static void Main()
    {
        Console.Title = "Can number be devided by 7 and 5 at the same time without remainder?";
        int checkedNumber = 0;
        bool isValidInput = false;
        do
        {
            Console.Write("Enter an integer to check for division by 5 & 7 at the same time: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out checkedNumber);
            if (isValidInput)
            {
                if (((checkedNumber % 7) == 0) && ((checkedNumber % 5) == 0))
                {
                    Console.WriteLine("The number can be divided by 5 and 7 at the same time!");
                }
                else
                {
                    Console.WriteLine("Unfortunately the number can NOT be divided by 5 and 7 at the same time!");
                }
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