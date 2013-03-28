using System;

class ExtractBitFromInteger
{
    // Write an expression that extracts from a given integer i the value 
    // of a given bit number b. Example: i=5; b=2 -> value=1.

    // Console input management
    static int EnterData(string message)
    {
        bool correctPointValue = false;
        int enteredValue = 0;
        do
        {
            Console.Write(message);
            correctPointValue = int.TryParse(Console.ReadLine(), out enteredValue);
            if (correctPointValue)
            { correctPointValue = true; }
            else
            {
                Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!correctPointValue);
        Console.Clear();
        return enteredValue;
    }

    static void Main()
    {
        int numberChecked = 0;
        int countedBit = 0;
        int mask = 0;
        int result = 0;
        Console.Title = "Extract value of a given bit in a given integer";
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
        if ((result >> countedBit) == 1)
        {
            Console.WriteLine("Bit number \"{0}\" in integer \"{1}\" has a value = 1.", countedBit, numberChecked);
        }
        else
        {
            Console.WriteLine("Bit number \"{0}\" in integer \"{1}\" has a value = 0.", countedBit, numberChecked);
        }
        Console.ReadKey();
    }
}
