using System;

/// <summary>
/// Task "8. Write a program that calculates the greatest common divisor (GCD)
/// of given two numbers.Use the Euclidean algorithm (find it in Internet)."
/// </summary>
public class GreatestCommonDivisor
{
    public static void Main()
    {
        Console.Title = "Find the greatest common divisor";
        int numberN = EnterData("Enter first integer value: ");
        int numberM = EnterData("Enter second integer value: ");

        // select higher number as divinend & smaller as divider 
        numberN = numberN ^ numberM;
        numberM = numberN ^ numberM;
        numberN = numberN ^ numberM;

        // calculate GCD
        Console.ForegroundColor = ConsoleColor.Green;
        int result = 0;
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
        } 
        while (result != 0);
        
        Console.ReadKey();
    }

    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}