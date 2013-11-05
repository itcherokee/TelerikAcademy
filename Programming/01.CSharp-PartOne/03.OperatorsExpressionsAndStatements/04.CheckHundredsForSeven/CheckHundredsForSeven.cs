using System;

/// <summary>
/// Task: "4. Write an expression that checks for given integer
/// if its third digit (right-to-left) is 7. E. g. 1732 -> true."
/// </summary>
public class CheckHundredsForSeven
{
    public static void Main()
    {
        Console.Title = "Check hundreds are 7";
        int numberChecked = 0;
        bool isValidInput = false;
        do
        {
            Console.Write("Please enter a three, four or more digit (integer) number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out numberChecked);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered wrong number or symbols. Try again (press key).");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        if (((numberChecked / 100) % 10) == 7)
        {
            Console.WriteLine("Third digit (right-to-left or hundreds) is 7!");
        }
        else
        {
            Console.WriteLine("Third digit (right-to-left or hundreds) is definately NOT 7");
        }

        Console.ReadKey();
    }
}
