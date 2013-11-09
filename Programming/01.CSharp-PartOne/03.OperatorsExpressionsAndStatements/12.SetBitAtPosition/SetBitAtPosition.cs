using System;

/// <summary>
/// Task: "12.We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of 
/// operators that modifies n to hold the value v at the position p from the binary representation of n.
/// Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101)
/// n = 5 (00000101), p=2, v=0 -> 1 (00000001)
/// </summary>
public class SetBitAtPosition
{
    public static void Main()
    {
        Console.Title = "Modify given bit with a given value in an integer";
        int numberToModify = EnterData("Please enter an integer number to be modified (n): ");
        int bitValue = EnterData("What will be the value (v) of the bit [0..1]: ");
        if ((bitValue < 0) || (bitValue > 1))
        {
            ShowErrorMessage();
        }

        int bitPosition = EnterData("At what position (p) to place the value [0..31]: ");
        if (bitPosition > (sizeof(int) * 8) || bitPosition < 0)
        {
            ShowErrorMessage();
        }

        int mask = 1 << bitPosition;
        int result = 0;
        switch (bitValue)
        {
            case 0: 
                result = numberToModify & (~mask); 
                break;
            case 1: 
                result = numberToModify | mask; 
                break;
        }

        Console.WriteLine("Number (n)    | {0,-11} ({1})", numberToModify, Convert.ToString(numberToModify, 2).PadLeft(32, '0'));
        Console.WriteLine("Position (p)  | {0,-11}  {1}", bitPosition, "*".PadLeft(32 - bitPosition, ' ').PadRight(32 - bitPosition, ' '));
        Console.WriteLine("Value (v)     | {0,-11}", bitValue);
        Console.WriteLine("Resultant int | {0,-11} ({1})", result, Convert.ToString(result, 2).PadLeft(32, '0'));
        Console.ReadKey();
    }

    private static void ShowErrorMessage()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Your input was out of range and program will exit. Start over.");
        Console.ReadKey();
        Environment.Exit(0);
    }

    private static int EnterData(string message)
    {
        bool isValidInput = false;
        int enteredValue = 0;
        do
        {
            Console.Write(message);
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (isValidInput)
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.Clear();
        return enteredValue;
    }
}