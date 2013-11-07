using System;

/// <summary>
/// Task: "11. Write an expression that extracts from a given integer i the value of a given bit number b. 
/// Example: i=5; b=2  value=1."
/// </summary>
public class ExtractBitFromInteger
{
    public static void Main()
    {
        Console.Title = "Extract value of a given bit in a given integer";

        int numberChecked = 0;
        int countedBit = 0;
        int mask = 0;
        int result = 0;
        numberChecked = EnterData("Please enter an integer number: ");
        countedBit = EnterData("Which bit of that number to be extracted (counts from 0): ");
        if (countedBit > (sizeof(int) * 8))
        {
            Console.WriteLine("You have entered incorect bit position and program will exit. Start over.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        mask = 1 << countedBit;
        result = numberChecked & mask;
        byte bitValue = 0;
        if ((result >> countedBit) == 1)
        {
            bitValue = 1;
        }
        else
        {
            bitValue = 0;
        }

        Console.WriteLine("Bit number \"{0}\" in integer \"{1}\" has a value = {2}.", countedBit, numberChecked, bitValue);
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
