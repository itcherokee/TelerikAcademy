using System;

class CharVariable
{
    static void Main()
    {
        //Declare a character variable and assign it with the symbol that has Unicode code 72.
 
        char symbol = '\u0048';
        Console.WriteLine("Символа с код {0} (Hex:{0:X}) e {1}.", (int)symbol,symbol);
        Console.ReadKey();
    }
}

