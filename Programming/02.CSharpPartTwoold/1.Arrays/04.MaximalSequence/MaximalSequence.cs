using System;

public class MaximalSequence
{
    // Write a program that finds the maximal sequence of equal elements in an array.
    // Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

    public static void Main()
    {
        Console.Title = "Maximal sequence of equal elements";
        int[] numbers = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 2 };
        int finalNumber;
        int finalCounter;
        int currentNumber = finalNumber = numbers[0];
        int currentCounter = finalCounter = 1;
        for (int index = 1; index < numbers.Length; index++)
        {
            if (currentNumber == numbers[index])
            {
                currentCounter++;
                if ((index == numbers.Length - 1) && (finalCounter < currentCounter))
                {
                    finalCounter = currentCounter;
                    finalNumber = currentNumber;
                }
            }
            else
            {
                if (currentCounter > finalCounter)
                {
                    finalCounter = currentCounter;
                    finalNumber = currentNumber;
                }

                currentNumber = numbers[index];
                currentCounter = 1;
            }
        }

        Console.WriteLine("Maximal sequence of equal numbers ({0}) appeared {1} times consecutive.", finalNumber, finalCounter);
    }
}
