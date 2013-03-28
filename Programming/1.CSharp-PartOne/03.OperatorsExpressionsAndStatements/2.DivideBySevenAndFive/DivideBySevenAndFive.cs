using System;

class DivideBySevenAndFive
{
    static void Main()
    {
        //Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
        int checkedNumber = 0;
        bool problemInput = false;
        Console.Title = "Can number be devided by 7 and 5 at the same time?";
        Console.Write("Enter an integer to check for division by 5 & 7 at the same time: ");
        problemInput = int.TryParse(Console.ReadLine(), out checkedNumber);
        if (problemInput)
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
            Console.WriteLine("You have entered invalid number or not a number at all!");
        }
    }
}

