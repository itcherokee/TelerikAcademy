using System;
using System.Text;

class Triangle
{
    static void Main()
    {
        // Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
        // Use Windows Character Map to find the Unicode code of the © symbol. 
        // Note: the © symbol may be displayed incorrectly.

        Console.Title = "Print isosceles triangle";
        char copyRight = '\u00a9';
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("{0,3}", copyRight);
        Console.WriteLine("{0,2}{0}{0}", copyRight);
        Console.WriteLine("{0}{0}{0}{0}{0}", copyRight);
        Console.ReadKey();
    }
}


