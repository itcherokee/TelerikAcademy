using System;
using System.Collections.Generic;

public class AddTwoPositiveNumbers
{
    // Write a method that adds two positive integer numbers represented 
    // as arrays of digits (each array element arr[i] contains a digit; 
    // the last digit is kept in arr[0]). Each of the numbers that will 
    // be added could have up to 10 000 digits.

    public static void Main()
    {
        Console.Title = "Calculate sum of two numbers (up to 10 0000 numbers).";
        string number = string.Empty;
        Console.Write("Enter number 1: ");
        number = Console.ReadLine().Trim();
        byte[] firstNumber = ToByteArray(number);
        Console.Write("Enter number 2: ");
        number = Console.ReadLine().Trim();
        byte[] secondNumber = ToByteArray(number);
        byte[] result = Sum(firstNumber, secondNumber);
        Console.Write("Sum of both numbers = ");
        for (int index = result.Length - 1; index >= 0; index--)
        {
            Console.Write(result[index]);
        }

        Console.WriteLine();
    }

    private static byte[] Sum(byte[] arrayOne, byte[] arrayTwo)
    {
        var currentProduct = 0;
        var carryOver = 0;
        byte[] biggerArray;
        byte[] smallerArray;
        if (arrayOne.Length < arrayTwo.Length)
        {
            biggerArray = arrayTwo;
            smallerArray = arrayOne;
        }
        else
        {
            biggerArray = arrayOne;
            smallerArray = arrayTwo;
        }

        Array.Reverse(biggerArray);
        Array.Reverse(smallerArray);
        List<byte> tempArray = new List<byte>();
        for (int index = 0; index < biggerArray.Length; index++)
        {
            currentProduct = biggerArray[index] + (index < smallerArray.Length ? smallerArray[index] : 0) + carryOver;
            carryOver = (currentProduct / 10) % 10;
            tempArray.Add((byte)(currentProduct % 10));
        }

        if (carryOver > 0)
        {
            tempArray.Add((byte)carryOver);
        }

        byte[] returnArray = new byte[tempArray.Count];
        returnArray = tempArray.ToArray();
        return returnArray;
    }

    // convert/split string number to byte[] of digits
    private static byte[] ToByteArray(string number)
    {
        byte[] returnArray = new byte[number.Length];
        for (var index = 0; index < number.Length; index++)
        {
            returnArray[index] = Convert.ToByte(number.Substring(index, 1));
        }

        return returnArray;
    }
}