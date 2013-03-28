using System;
using System.Numerics;

class TrailingZeros
{
    static void Main()
    {
        //* Write a program that calculates for given N how many trailing zeros present at the end of the number N!. 
        // Examples:
        // N = 10 -> N! = 3628800 -> 2
        // N = 20 -> N! = 2432902008176640000 -> 4
        // Does your program work for N = 50 000? -> YES

        Console.Title = "Calculate trailing zeros in N!";
        BigInteger factorialResult = 1;
        int numberInput = 0;
        bool noError = false;
        do
        {
            Console.Write("Please enter a number: ");
            noError = int.TryParse(Console.ReadLine(), out numberInput);
            if ((!noError) || (numberInput < 0))
            {
                Console.WriteLine("You have entered a symbol(s) or wrong number. Try again <press a key>.");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!noError);
        // calculate factorial for output
        if (numberInput == 0)
        {
            factorialResult = 1;
        }
        else
        {
            for (int i = 1; i <= numberInput; i++)
            {

                factorialResult *= i;
            }
        }
        //calculate trailing zeros
        int operationalResult = 0;
        int divisor = 5;
        int zerosCount = 0;
        do
        {
            operationalResult = (numberInput / divisor);
            if (operationalResult == 0) { break; }
            zerosCount += operationalResult;
            divisor *= 5;
        } while (true);
        Console.WriteLine("In {0}!={1} there {2} {3} trailing zero(s).", numberInput, factorialResult, zerosCount > 1 ? "are" : "is", zerosCount);
        Console.ReadKey();
    }
}

