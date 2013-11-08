using System;

/// <summary>
/// Task: "11. Write an expression that extracts from a given integer i the value of a given bit number b. 
/// Example: i=5; b=2 -> value=1."
/// </summary>
public class ExtractBitFromInteger
{
    public static void Main()
    {
        Console.Title = "Extract value of a given bit in a given integer";
        int numberToCheck = EnterData("Please enter an integer number: ");
        int bitToCheck = EnterData("Which bit of that number to be extracted (counts from 0): ");
        if (bitToCheck > (sizeof(int) * 8))
        {
            Console.WriteLine("You have entered incorect bit position and program will exit. Start over.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        int mask = 1 << bitToCheck;
        int result = numberToCheck & mask;
        byte searchedBitValue = 0;
        if ((result >> bitToCheck) == 1)
        {
            searchedBitValue = 1;
        }
        else
        {
            searchedBitValue = 0;
        }

        Console.WriteLine("Bit number \"{0}\" in integer \"{1}\" has a value = {2}", bitToCheck, numberToCheck, searchedBitValue);
        Console.Write("Here is number {0} in binary format: ", numberToCheck);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(Convert.ToString(numberToCheck, 2).PadLeft(32, '0'));
        Console.ReadKey();
    }

    private static int EnterData(string message)
    {
        bool isValidInput = false;
        int enteredValue = 0;
        do
        {
            Console.Write(message);
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (isValidInput != true)
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
