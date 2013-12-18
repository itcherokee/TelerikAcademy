using System;

public class MaximalIncreasingSequence
{
    // Write a program that finds the maximal increasing sequence in an array. 
    // Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

    public static void Main()
    {
        Console.Title = "Maximal increasing sequence";
        int[] numbers = { 3, 2, 3, 4, 2, 2, 4, 2, 4, 5, 6, 7 };
        int finalIndex = 0;
        int finalCounter = 0;
        int currentCounter = 1;
        int currentNumber = numbers[0];
        for (int index = 1; index < numbers.Length; index++)
        {
            if (currentNumber + 1 == numbers[index])
            {
                currentCounter++;
                currentNumber = numbers[index];
                if (currentCounter == 2)
                {
                    finalIndex = index - 1;
                }

                if ((index == numbers.Length - 1) && (finalCounter < currentCounter))
                {
                    finalCounter = currentCounter;
                }
            }
            else
            {
                if (finalCounter < currentCounter)
                {
                    finalCounter = currentCounter;
                }

                currentNumber = numbers[index];
                currentCounter = 1;
            }
        }

        Console.Write("Maximal increasing sequence is: ");
        for (int i = finalIndex; i < finalIndex + finalCounter; i++)
        {
            Console.Write("{0}", numbers[i]);
            if (i < finalIndex + finalCounter - 1)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }
}
