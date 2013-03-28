using System;

class OddOrEven
{
    static void Main()
    {
        // Write an expression that checks if given integer is odd or even.
        int checkedNumber =0;
        bool problemInput = false;
        Console.Title = "Number is Odd or Even?";
        Console.Write("Enter an integer number to check is it odd or even: ");
        problemInput = int.TryParse(Console.ReadLine(), out checkedNumber);
        if (problemInput)
        {
            Console.WriteLine("The number you entered is {0}.", ((checkedNumber%2)==0)?"even":"odd");
        }
        else
        {
            Console.WriteLine("You have entered invalid number or not a number at all!");
        }
        Console.ReadKey();
    }
}
