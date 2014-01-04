using System;

/// <summary>
/// Task: "2. Write a method GetMax() with two parameters that returns the bigger of two integers. 
/// Write a program that reads 3 integers from the console and prints the biggest of them using 
/// the method GetMax()."
/// </summary>
public class GetMaxProgram
{
    public static void Main()
    {
        Console.Title = "GetMax() routine test";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter three integers to find the bigest.");
        int firstNumber = EnterData("Number 1:");
        int secondNumber = EnterData("Number 2:");
        int thirdNumber = EnterData("Number 3:");
        Console.ForegroundColor = ConsoleColor.Green;
        Print(GetMax(GetMax(firstNumber, secondNumber), thirdNumber));
        Console.ReadKey();
    }

    // Calculates bigger of two numbers
    private static int GetMax(int numberOne, int numberTwo)
    {
        return numberOne > numberTwo ? numberOne : numberTwo;
    }

    // Output to Console of the result
    private static void Print(int result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nBigest number is ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("{0}", result);
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Hadles user input
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