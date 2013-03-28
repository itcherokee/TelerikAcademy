using System;

class CheckBitAtPosition
{
    // Write a boolean expression that returns if the bit at position p (counting from 0) 
    // in a given integer number v has value of 1. Example: v=5; p=1 -> false.

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
        Console.Title = "Check if selected bit at position is set to 1.";
        numberChecked = EnterData("Please enter an integer number: ");
        countedBit = EnterData("Which bit of that number to be checked for 1 (counts from 0): ");
        if (countedBit > (sizeof(int) * 8))
        {
            Console.WriteLine("You have entered incorect position for bit and program will exit. Start over.");
            Console.ReadKey();
            Environment.Exit(0);
        }
        mask = 1 << countedBit;
        result = numberChecked & mask;
        Console.WriteLine("Does bit number \"{0}\" in number \"{1}\" is set to 1: {2}", countedBit, numberChecked, ((result >> countedBit) == 1));
        Console.ReadKey();
    }
}
