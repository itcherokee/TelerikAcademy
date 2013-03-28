using System;
using System.Text;

class PrintASCII
{
    static void Main()
    {
        Console.Title = "Print ASCII table";
        //Write a program that prints the entire ASCII table of characters on the console.
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Chars from 0 to 32 from ASCII table usually are non-printable on screen.");
        Console.WriteLine("  Dec     Hex     Char");
        Console.WriteLine(" ======================");
        for (int index = 33; index < 256; index++)
        {
            Console.WriteLine("{0,4}{1,8:X}{2,8}", index, index, (char)index);
        }
        Console.ReadKey();
    }
}