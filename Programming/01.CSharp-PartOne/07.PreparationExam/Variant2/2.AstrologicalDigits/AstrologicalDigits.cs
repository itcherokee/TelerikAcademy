using System;
using System.Numerics;

class AstrologicalDigits
{
    static void Main()
    {

        string numberEnteredStr = Console.ReadLine();
        if (numberEnteredStr.Contains("."))
        {
            numberEnteredStr = numberEnteredStr.Remove(numberEnteredStr.IndexOf('.'), 1);
        }
        if (numberEnteredStr.Contains("-"))
        {
            numberEnteredStr = numberEnteredStr.Remove(numberEnteredStr.IndexOf('-'), 1);
        }
        BigInteger numberEntered = BigInteger.Parse(numberEnteredStr);
        int size = numberEnteredStr.Length;
        BigInteger sum = 0;
        while (size > 1)
        {
            sum = 0;
            for (int i = 0; i <= size - 1; i++)
            {
                sum += numberEntered % 10;
                numberEntered /= 10;
            }
            numberEntered = sum;
            numberEnteredStr = numberEntered.ToString();
            size = numberEnteredStr.Length;

        }
        Console.WriteLine(numberEnteredStr);
    }
}
