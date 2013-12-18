using System;

public class CalculateSumFromSequence
{
    // You are given a sequence of positive integer values written into a string, 
    // separated by spaces. Write a function that reads these values from given 
    // string and calculates their sum. 
    // Example: string = "43 68 9 23 318" -> result = 461

    public static void Main()
    {
        string incommingNumbers = "43 68 9 23 318";
        Console.WriteLine("Sum = {0}", SumSequence(incommingNumbers));
    }

    private static int SumSequence(string inputNumbers)
    {
        string[] inputArray = inputNumbers.Split();
        int result = 0;
        for (int count = 0; count < inputArray.Length; count++)
        {
            result += int.Parse(inputArray[count]);
        }

        return result;
    }
}