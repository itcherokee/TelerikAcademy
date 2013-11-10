using System;

/// <summary>
/// Task: "4. Sort 3 real values in descending order using nested if statements."
/// </summary>
public class SortRealNumbers
{
    public static void Main()
    {
        Console.Title = "Sorting in descendant order three real numbers";

        decimal numberOne = default(decimal);
        decimal numberTwo = default(decimal);
        decimal numberThree = default(decimal);
        bool noError = true;
        bool areEqualNumbers = false;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter three different real numbers to sort them in descending order.");
            numberOne = EnterData("Number 1: ");
            numberTwo = EnterData("Number 2: ");
            numberThree = EnterData("Number 3: ");
            if ((numberOne == numberTwo) || (numberOne == numberThree) || (numberTwo == numberThree))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered 2 or 3 numbers with equal values. Please reenter all.");
                areEqualNumbers = true;
            }
            else
            {
                areEqualNumbers = false;
            }
        }
        while (areEqualNumbers);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Entered numbers ordered in descending order:");
        if (decimal.Compare(numberOne, numberTwo) > 0)
        {
            if (decimal.Compare(numberOne, numberThree) > 0)
            {
                Console.WriteLine("{0:F1}", numberOne);
                if (decimal.Compare(numberTwo, numberThree) > 0)
                {
                    Console.WriteLine("{0:F1}", numberTwo);
                    Console.WriteLine("{0:F1}", numberThree);
                }
                else
                {
                    Console.WriteLine("{0:F1}", numberThree);
                    Console.WriteLine("{0:F1}", numberTwo);
                }
            }
            else
            {
                Console.WriteLine("{0:F1}", numberThree);
                Console.WriteLine("{0:F1}", numberOne);
                Console.WriteLine("{0:F1}", numberTwo);
            }
        }
        else if (decimal.Compare(numberTwo, numberThree) > 0)
        {
            Console.WriteLine("{0:F1}", numberTwo);
            if (decimal.Compare(numberOne, numberThree) > 0)
            {
                Console.WriteLine("{0:F1}", numberOne);
                Console.WriteLine("{0:F1}", numberThree);
            }
            else
            {
                Console.WriteLine("{0:F1}", numberThree);
                Console.WriteLine("{0:F1}", numberOne);
            }
        }
        else
        {
            Console.WriteLine("{0:F1}", numberThree);
            Console.WriteLine("{0:F1}", numberTwo);
            Console.WriteLine("{0:F1}", numberOne);
        }

        Console.ReadKey();
    }

    private static decimal EnterData(string message)
    {
        bool isValidInput = default(bool);
        decimal enteredValue = default(decimal);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = decimal.TryParse(Console.ReadLine(), out enteredValue);
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