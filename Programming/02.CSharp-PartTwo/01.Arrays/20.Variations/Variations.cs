using System;

/// <summary>
/// Task: "20. Write a program that reads two numbers N and K and generates all the variations 
/// of K elements from the set [1..N]. 
/// 
/// Example: N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}"
/// </summary>
public class Variations
{
    private static int combinationSize = 0;
    private static int upperBound = 0;
    private static int[] arrayOfNumbers;

    public static void Main()
    {
        Console.Title = "Print all combinations of K elements from set [1..N].";
        Console.Write("Enter upper bound of set [1..(N)]: ");
        upperBound = int.Parse(Console.ReadLine());
        //arrayOfNumbers = new int[upperBound];
        Console.Write("Enter number of elements to combine (K): ");
        combinationSize = int.Parse(Console.ReadLine());
        Console.WriteLine("All possible variations follow...");
        Console.Write("{");
        for (int firstIndex = 1; firstIndex <= upperBound; firstIndex++)
        {
            for (int secondIndex = 1; secondIndex <= upperBound; secondIndex++)
            {
                Console.Write("{");
                for (int size = 0; size < combinationSize; size++)
                {
                    Console.Write("{0}{1}", arrayOfNumbers[size]);
                    if (size < combinationSize - 1)
                    {
                        Console.Write(",");
                    }
                }

                Console.Write("}");

               // Console.Write("({0},{1})", firstIndex,secondIndex);
            }
        }
    }

    //private static void Combinate(int cuurentBound)
    //{
    //    if (combinationSize == cuurentBound)
    //    {
    //        Console.Write("{");
    //        for (int i = 0; i < combinationSize; i++)
    //        {
    //            Console.Write("{0}", arrayOfNumbers[i]);
    //            if (i < combinationSize - 1)
    //            {
    //                Console.Write(",");
    //            }
    //        }

    //        Console.Write("} ");
    //        return;
    //    }

    //    for (int i = 1; i <= upperBound; i++)
    //    {
    //        arrayOfNumbers[cuurentBound] = i;
    //        Combinate(cuurentBound + 1);
    //    }
    //}
}