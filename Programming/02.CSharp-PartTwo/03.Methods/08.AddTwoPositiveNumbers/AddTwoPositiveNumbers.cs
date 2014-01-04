using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

/// <summary>
/// Таск: "8. Write a method that adds two positive integer numbers represented as arrays of digits
/// (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the numbers 
/// that will be added could have up to 10 000 digits."
/// </summary>
public class AddTwoPositiveNumbers
{
    public static void Main()
    {
        Console.Title = "Calculate sum of two numbers (up to 10 0000 numbers).";
        byte[] firstNumber = ToByteArray(EnterData("Enter number 1: "));
        byte[] secondNumber = ToByteArray(EnterData("Enter number 2: "));
        Console.Write("Sum of numbers = ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(Sum(firstNumber, secondNumber));
        Console.WriteLine();
        Console.ReadKey();
    }

    private static int Sum(byte[] arrayOne, byte[] arrayTwo)
    {
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
            var currentProduct = biggerArray[index] + (index < smallerArray.Length ? smallerArray[index] : 0) + carryOver;
            carryOver = (currentProduct / 10) % 10;
            tempArray.Add((byte)(currentProduct % 10));
        }

        if (carryOver > 0)
        {
            tempArray.Add((byte)carryOver);
        }

        byte[] result = tempArray.ToArray();
        Array.Reverse(result);
        return int.Parse(string.Join(string.Empty, result.Select(x => x.ToString(CultureInfo.InvariantCulture))));
    }

    // Converts (split) string number to byte[] of digits
    private static byte[] ToByteArray(string number)
    {
        byte[] returnArray = new byte[number.Length];
        for (var index = 0; index < number.Length; index++)
        {
            returnArray[index] = Convert.ToByte(number.Substring(index, 1));
        }

        return returnArray;
    }

    // Handles user input of single integer value by checking for correct input
    private static string EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue.ToString(CultureInfo.InvariantCulture);
    }
}