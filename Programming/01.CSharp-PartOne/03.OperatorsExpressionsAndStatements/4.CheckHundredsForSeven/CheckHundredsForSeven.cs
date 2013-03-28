using System;

class CheckHundredsForSeven
{
    static void Main()
    {
        //Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true.

        int numberChecked = 0;
        bool wrongNumber = false;
        Console.Title = "Check hundreds are 7";
        // Handling the input of data
        do
        {
            Console.Write("Please enter a three, four or more digit (integer) number: ");
            wrongNumber = int.TryParse(Console.ReadLine(), out numberChecked);
            if (!wrongNumber)
            {
                Console.WriteLine("You have entered wrong number or symbols. Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!wrongNumber);
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
