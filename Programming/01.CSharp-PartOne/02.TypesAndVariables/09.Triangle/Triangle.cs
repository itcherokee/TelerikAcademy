using System;
using System.Text;

/// <summary>
/// Task: '9. Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
/// Use Windows Character Map to find the Unicode code of the © symbol. 
/// Note: the © symbol may be displayed incorrectly."
/// </summary>
public class Triangle
{
    public static void Main()
    {
        Console.Title = "Print isosceles triangle with 9 copyright symbols";
        char copyRight = '\u00a9';
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("{0,3}", copyRight);
        Console.WriteLine("{0,2}{0}{0}", copyRight);
        Console.WriteLine("{0}{0}{0}{0}{0}", copyRight);
        Console.ReadKey();
    }
}