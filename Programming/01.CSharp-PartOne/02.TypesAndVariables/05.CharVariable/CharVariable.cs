using System;

/// <summary>
/// Task: "5. Declare a character variable and assign it with the symbol that has Unicode code 72."
/// </summary>
public class CharVariable
{
    public static void Main()
    {
        char symbol = '\u0048';
        Console.Write("Symbol with Unicode code {0} (Hex:{0:X}) is ", (int)symbol);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(symbol);
        Console.ReadKey();
    }
}