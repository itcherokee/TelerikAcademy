using System;

class CheckThirdBit
{
    static void Main()
    {
        // Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

        int checkedNumber = 0;
        int checkedNumberMasked = 0;
        int mask = 8; // 3rd bit set
        int bitResult = 0;
        bool wrongNumber = false;
        Console.Title = "Check value of 3rd bit of an integer";
        do
        {
            Console.Write("Please enter a integer number: ");
            wrongNumber = int.TryParse(Console.ReadLine(), out checkedNumber);
            if (!wrongNumber)
            {
                Console.WriteLine("You have entered wrong number or symbols. Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!wrongNumber);
        // Logic of the program
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
        Console.ReadKey();
    }
}
