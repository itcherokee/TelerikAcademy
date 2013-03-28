using System;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        /*Write a program to print the first 100 members of the sequence
         * of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …*/

        BigInteger numberOne = 0;
        BigInteger numberTwo = 1;
        BigInteger currentNumber = numberOne;
        Console.WriteLine("First 100 Fibonacci numbers");
        Console.WriteLine("-----------------------------");
        Console.WriteLine("{0}{1,2}{0,2}{2,15}{0,9}","|","N","Number");
        Console.WriteLine("-----------------------------");
        for (int i = 0; i <= 100; i++)
        {      
            Console.WriteLine("|{0,3}| {1,22}|",i,currentNumber);
            numberOne = numberTwo;
            numberTwo = currentNumber; 
            currentNumber = numberOne + numberTwo;
        }
    }
}