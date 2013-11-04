using System;
using System.Text;

/// <summary>
/// Task; "12. Find online more information about ASCII (American Standard Code for Information Interchange)
/// and write a program that prints the entire ASCII table of characters on the console."
/// </summary>
public class PrintASCII
{
    public static void Main()
    {
        Console.Title = "Print ASCII table";
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Chars from 0 to 32 from ASCII table usually are non-printable on screen.");
        Console.WriteLine("  Dec     Hex     Char");
        Console.WriteLine(" ======================");
        for (int index = 33; index < 256; index++)
        {
            Console.WriteLine("{0,4}{1,8:X}{2,8}", index, index, (char)index);
            if (index % 22 == 0)
            {
                Console.WriteLine("<Press key to continue...>");
                Console.ReadKey();
            }
        }

        Console.ReadKey();
    }
}