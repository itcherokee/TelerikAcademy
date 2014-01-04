using System;
using System.Collections.Generic;

/// <summary>
/// Task: "10. Write a program to calculate n! for each n in the range [1..100]. 
/// Hint: Implement first a method that multiplies a number represented as array 
/// of digits by given integer number. "
/// </summary>
public class CalculateFactorial
{
    public static void Main()
    {
        Console.Title = "Calculate & print all n! in range [1..100]";
        byte[] factorial = new byte[1] { 1 };
        Console.WriteLine("{0,3}. {1}", 1, 1);
        for (int count = 2; count <= 100; count++)
        {
            Console.Write("{0,3}. ", count);
            factorial = Multiply(factorial, count);
            for (int i = 0; i < factorial.Length; i++)
            {
                Console.Write(factorial[i]);
            }

            Console.WriteLine();
        }
    }

    // Multiply by using addition n-times 
    private static byte[] Multiply(byte[] numbers, int index)
    {
        byte[] returnArray = numbers;
        for (int multiplyer = 1; multiplyer < index; multiplyer++)
        {
            returnArray = Addition(returnArray, numbers);
        }

        return returnArray;
    }

    // Sum two numbers represented as arrays of digits
    private static byte[] Addition(byte[] arrayOne, byte[] arrayTwo)
    {
        var carryOver = 0;
        byte[] biggerArray;
        byte[] smallerArray;
        if (arrayOne.Length < arrayTwo.Length)
        {
            biggerArray = new byte[arrayTwo.Length];
            arrayTwo.CopyTo(biggerArray, 0);
            smallerArray = new byte[arrayOne.Length];
            arrayOne.CopyTo(smallerArray, 0);
        }
        else
        {
            biggerArray = new byte[arrayOne.Length];
            arrayOne.CopyTo(biggerArray, 0);
            smallerArray = new byte[arrayTwo.Length];
            arrayTwo.CopyTo(smallerArray, 0);
        }

        Array.Reverse(biggerArray);
        Array.Reverse(smallerArray);
        List<byte> tempArray = new List<byte>();
        for (int index = 0; index < biggerArray.Length; index++)
        {
            var currentProduct = biggerArray[index] + (index < smallerArray.Length ? smallerArray[index] : 0) + carryOver;
            carryOver = (currentProduct / 10) % 10;
            tempArray.Add((byte)(currentProduct % 10));
        }

        if (carryOver > 0)
        {
            tempArray.Add((byte)carryOver);
        }

        byte[] returnArray = new byte[tempArray.Count];
        returnArray = tempArray.ToArray();
        Array.Reverse(returnArray);
        return returnArray;
    }
}