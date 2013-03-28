using System;

class PrintsOneToN
{
    static void Main()
    {
        //Write a program that prints all the numbers from 1 to N

        Console.Title = "Prints all numbers from 1 to N";
        Console.WriteLine("Please enter the upper boundary N of the range to print.");
        bool noError = true;
        uint upperBoundary = 0;
        do
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("N = ");
            noError = uint.TryParse(Console.ReadLine(), out upperBoundary);
            if ((!noError) || (upperBoundary <= 1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered nothing, symbol(s), 0 or 1! Try again, press <Enter>.");
                Console.ReadLine();
                Console.Clear();
                noError = false;
            }
        } while (!noError);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Result = ");
        for (int i = 1; i <= upperBoundary; i++)
        {
            Console.Write(i);
            if (i < upperBoundary)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}
