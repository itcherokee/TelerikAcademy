using System;

/// <summary>
/// Task: "3. Write a program that finds the biggest of three integers using nested if statements."
/// </summary>
public class BiggestOfThree
{
    public static void Main()
    {
        Console.Title = "Find the biggest number out of three";

        int numberOne = default(int);
        int numberTwo = default(int);
        int numberThree = default(int);
        bool areEqualNumbers = false;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter three different integers and program will find the biggest one.");
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
        if (numberOne > numberTwo)
        {
            if (numberOne > numberThree)
            {
                Console.WriteLine("First number is the biggest: {0}", numberOne);
            }
            else
            {
                Console.WriteLine("Third number is the biggest: {0}", numberThree);
            }
        }
        else if (numberTwo > numberThree)
        {
            Console.WriteLine("Second number is the biggest: {0}", numberTwo);
        }
        else
        {
            Console.WriteLine("Third number is the biggest: {0}", numberThree);
        }

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