using System;

class PrintMatrix
{
    // Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix 

    static void Main()
    {
        Console.Title = "Print a matrix";
        byte numberN = 1;
        bool noError = false;
        do
        {
            Console.Write("Enter upper border of sequence [2..20] = ");
            noError = byte.TryParse(Console.ReadLine(), out numberN);
            if ((!noError) || (numberN <= 1) || (numberN > 20))
            {
                Console.WriteLine("You have entered symbol(s) or number out of range. Try again.");
                Console.ReadKey();
                Console.Clear();
                noError = false;
            }
        } while (!noError);
        for (int i = 1; i <= numberN; i++)
        {
            for (int k = i; k <= (i + numberN - 1); k++)
            {
                Console.Write("{0,3}", k);
            }
            Console.WriteLine();
        }
    }
}
