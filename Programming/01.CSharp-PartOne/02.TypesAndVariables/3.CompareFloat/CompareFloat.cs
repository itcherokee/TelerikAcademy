using System;

class CompareFloat
{
    static void Main()
    {
        //Write a program that safely compares floating-point numbers with precision of 0.000001. 
        //Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003) -> true


        decimal numberOne;
        decimal numberTwo;
        decimal result;
        Console.Title = "Check two numbers for parity";
        Console.WriteLine("Parity check of 2 numbers (precision up to 6th digit after deciaml point)");
        Console.Write("Enter first number: ");
        numberOne = decimal.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        numberTwo = decimal.Parse(Console.ReadLine());
        result = Math.Abs(numberOne - numberTwo);
        if (result < 0.000001m)
        {
            Console.WriteLine("Numbers are equal!");
        }
        else
        {
            Console.WriteLine("Numbers are NOT equal!.");
        }
        Console.ReadKey();
    }
}
