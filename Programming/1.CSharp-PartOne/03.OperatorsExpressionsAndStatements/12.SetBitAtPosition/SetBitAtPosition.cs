using System;

class SetBitAtPosition
{
    // We are given integer number n, value v (v=0 or 1) and a position p. 
    // Write a sequence of operators that modifies n to hold the value v at 
    // the position p from the binary representation of n.
    // Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101) n = 5 (00000101), p=2, v=0 -> 1 (00000001)

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

    static void MessageAndExit(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
        Environment.Exit(0);
    }

    static void Main()
    {
        int numberToModify = 0;
        int bitValue = 0;
        int bitPosition = 0;
        int mask = 0;
        int result = 0;
        Console.Title = "Modify given bit with a given value in integer";
        numberToModify = EnterData("Please enter an integer number to be modified (n): ");
        bitValue = EnterData("What will be the value (v) of the bit [0..1]: ");
        if ((bitValue < 0) || (bitValue > 1))
        {
            MessageAndExit("Your input was out of range and program will exit. Start over.");
        }
        bitPosition = EnterData("At what position (p) to place the value [0..31]: ");
        if (bitPosition > (sizeof(int) * 8))
        {
            MessageAndExit("You have entered incorect bit position and program will exit. Start over.");
        }
        mask = 1 << bitPosition;
        switch (bitValue)
        {
            case 0: result = numberToModify & (~mask); break;
            case 1: result = numberToModify | mask; break;
        }
        Console.WriteLine("{0,8}{1,-11} ({2})", "Number (n)    | ", numberToModify, Convert.ToString(numberToModify, 2).PadLeft(32, '0'));
        Console.WriteLine("{0,8}{1,-11}", "Position (p)  | ", bitPosition);
        Console.WriteLine("{0,8}{1,-11}", "Value (v)     | ", bitValue);
        Console.WriteLine("{0,8}{1,-11} ({2})", "Resultant int | ", result, Convert.ToString(result, 2).PadLeft(32, '0'));
        Console.ReadKey();
    }
}
