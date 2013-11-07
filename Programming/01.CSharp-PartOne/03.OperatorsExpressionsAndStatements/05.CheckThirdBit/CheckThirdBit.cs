using System;

/// <summary>
/// Task: "5. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0."
/// </summary>
public class CheckThirdBit
{
    public static void Main()
    {
        Console.Title = "Check value of 3rd bit of an integer";

        int checkedNumber = 0;
        int checkedNumberMasked = 0;
        int mask = 0x08; // 3rd bit set
        int bitResult = 0;
        bool isValidInput = false;
        do
        {
            Console.Write("Please enter an integer number: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out checkedNumber);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered wrong number or symbols. Try again (press key).");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        checkedNumberMasked = checkedNumber & mask;
        bitResult = checkedNumberMasked >> 3;
        if (bitResult == 0)
        {
            Console.WriteLine("The bit at the 3rd position (counting from 0) is 0");
        }
        else
        {
            Console.WriteLine("The bit at the 3rd position (counting from 0) is 1");
        }

        Console.WriteLine(Convert.ToString(checkedNumber, 2).PadLeft(32, '0'));
        Console.ReadKey();
    }
}
