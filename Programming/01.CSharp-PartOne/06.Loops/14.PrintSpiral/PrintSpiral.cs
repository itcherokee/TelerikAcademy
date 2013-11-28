using System;

/// <summary>
/// Task "14. * Write a program that reads a positive integer number N (N < 20) from console
/// and outputs in the console the numbers 1 ... N numbers arranged as a spiral."
/// </summary>
public class Spiral
{
    public static void Main()
    {
        Console.Title = "Print numbers in Spiral";
        int numberInput = EnterData("Please enter a number [1..20]: ");
        int[,] spiralnumbers = new int[numberInput, numberInput];
        int col = -1, row = 0;
        int borderYLeft = 0, borderYRight = numberInput;
        int borderXUp = 0, borderXDown = numberInput;
        int totalNumbers = 1;
        while (totalNumbers <= (numberInput * numberInput))
        {
            col++;
            while (col < borderYRight)
            {
                spiralnumbers[row, col] = totalNumbers;
                col++;
                totalNumbers++;
            }

            col--;
            borderYRight--;
            row++;
            while (row < borderXDown)
            {
                spiralnumbers[row, col] = totalNumbers;
                row++;
                totalNumbers++;
            }

            row--;
            borderXDown--;
            col--;
            while (col >= borderYLeft)
            {
                spiralnumbers[row, col] = totalNumbers;
                col--;
                totalNumbers++;
            }

            col++;
            borderYLeft++;
            row--;
            while (row > borderXUp)
            {
                spiralnumbers[row, col] = totalNumbers;
                row--;
                totalNumbers++;
            }

            row++;
            borderXUp++;
        }

        // Ouput to Console
        Console.Clear();
        for (int i = 0; i <= numberInput - 1; i++)
        {
            for (int k = 0; k <= numberInput - 1; k++)
            {
                Console.Write("{0,4}", spiralnumbers[i, k]);
            }

            Console.WriteLine();
        }

        Console.ReadKey();
    }

    // User data input
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
            if (!isValidInput || (enteredValue < 0) || (enteredValue > 20))
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