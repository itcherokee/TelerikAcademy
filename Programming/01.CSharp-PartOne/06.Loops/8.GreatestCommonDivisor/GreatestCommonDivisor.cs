using System;

class GreatestCommonDivisor
{
    // Write a program that calculates the greatest common divisor (GCD) of given two numbers.
    // Use the Euclidean algorithm (find it in Internet).

    static void Main()
    {
        Console.Title = "Find the greatest common divisor";
        int numberN = 0;
        int numberM = 0;
        int result = 0;
        //console input management
        numberN = ConsoleInput("first");
        numberM = ConsoleInput("second");
        // select higher number as divinend & smaller as divider
        numberN = numberN ^ numberM;
        numberM = numberN ^ numberM;
        numberN = numberN ^ numberM;
        // calculate GCD
        do
        {
            result = numberN % numberM;
            if (result == 0)
            {
                Console.WriteLine("Greatest common divisor is {0}", numberM);
            }
            else
            {
                numberN = numberM;
                numberM = result;
            }
        } while (result != 0);
        Console.ReadKey();
    }

    static int ConsoleInput(string numberName)
    {
        bool noError = false;
        int numberToEnter = 0;
        do
        {
            Console.Write("Enter {0} integer value: ", numberName);
            noError = int.TryParse(Console.ReadLine(), out numberToEnter);
            if (!noError)
            {
                Console.WriteLine("You have entered symbol(s) or wrong number. Try again.");
                Console.ReadKey();
                Console.Clear();
                noError = false;
            }
        } while (!noError);
        return numberToEnter;
    }
}