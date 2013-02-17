using System;

public class CombinationsDistinct
{
    // Write a program that reads two numbers N and K and generates all the 
    // combinations of K distinct elements from the set [1..N]. 
    // Example:	N=5, K=2 -> {1,2},{1,3},{1,4},{1,5},{2,3},{2,4},{2,5},{3,4},{3,5},{4,5}

    // 1 = N-1 kombinations (N-4, N-3..N)
    // 2 = N-2 kombinations (N-3, N-2..N)
    // 3 = N-3 kombinations (N-2, N-1..N)
    // 4 = N-4 kombinations (N-1, N)

    public static int combinationSize = 0;
    public static int upperBound = 0;
    public static int[] arrayOfNumbers;
    public static int shift = 0;

    public static void Main()
    {
        Console.Title = "Print all combinations of K distinct elements from set [1..N].";
        Console.Write("Enter upper bound of set [1..(N)]: ");
        upperBound = int.Parse(Console.ReadLine());
        Console.Write("Enter number of elements to combine (K): ");
        combinationSize = int.Parse(Console.ReadLine());
        arrayOfNumbers = new int[upperBound];
        Console.WriteLine("All possible distinct combinations follow...");
        Combinate(0);
        Console.WriteLine();
    }

    private static void Combinate(int currentBound)
    {
        if (combinationSize == currentBound)
        {
            Console.Write("{");
            for (int i = 0; i < combinationSize; i++)
            {
                Console.Write("{0}", arrayOfNumbers[i]);
                if (i < combinationSize - 1)
                {
                    Console.Write(",");
                }
            }

            Console.Write("} ");
            return;
        }

        for (int i = 1 + currentBound + shift; i <= upperBound; i++)
        {
            arrayOfNumbers[currentBound] = i;
            Combinate(currentBound + 1);
        }

        shift++;
    }
}