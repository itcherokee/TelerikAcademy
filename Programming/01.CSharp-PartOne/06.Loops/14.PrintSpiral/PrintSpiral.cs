using System;

class Spiral
{
    //* Write a program that reads a positive integer number N (N < 20) from console 
    // and outputs in the console the numbers 1 ... N numbers arranged as a spiral.

    static void Main()
    {
        Console.Title = "Print numbers in Spiral";
        int numberInput = 0;
        bool noError = false;
        do
        {
            Console.Write("Please enter a number [1..20]: ");
            noError = int.TryParse(Console.ReadLine(), out numberInput);
            if ((!noError) || (numberInput < 0) || (numberInput > 20))
            {
                Console.WriteLine("You have entered a symbol(s) or wrong number. Try again <press a key>.");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!noError);
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
}
