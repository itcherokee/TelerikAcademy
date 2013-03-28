using System;

class ExchangeInt
{
    static void Main()
    {
        // Declare  two integer variables and assign them with 5 and 10 
        // and after that exchange their values.

        Console.Title = "Exchange values of two integers";
        int numberOne = 5;
        int numberTwo = 10;
        Console.WriteLine("Number A={0}, number B={1}", numberOne, numberTwo);
        numberOne += numberTwo;
        numberTwo = numberOne - numberTwo;
        numberOne -= numberTwo;
        Console.WriteLine("After swap:");
        Console.WriteLine("Number A={0}, Number B={1}", numberOne, numberTwo);
        Console.ReadKey();
    }
}
