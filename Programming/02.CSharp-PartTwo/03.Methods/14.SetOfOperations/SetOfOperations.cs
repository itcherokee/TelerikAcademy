using System;
using System.Linq;

/// <summary>
/// Task: "14. Write methods to calculate minimum, maximum, average, sum and product 
/// of given set of integer numbers. Use variable number of arguments."
/// </summary>
public class SetOfOperations
{
    public static void Main()
    {
        Console.WriteLine("Minimal number: " + Min(11, 2, 3, 4, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Maximal number: " + Max(11, 2, 3, 4, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Average number: " + Average(11, 2, 3, 4, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Sum of numbers: " + Sum(11, 2, 3, 4, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Product of numbers: " + Product(11, 2, 3, 4, 5, 10, 6, 7, 8, 9));
    }

    // Minimal number in sequence
    private static int Min(params int[] numbers)
    {
        int result = 0;
        if (numbers.Length > 0)
        {
            result = numbers[0];
            if (numbers.Length > 1)
            {
                for (int index = 1; index < numbers.Length; index++)
                {
                    result = numbers[index] < result ? numbers[index] : result;
                }
            }
        }

        return result;
    }

    // Maximal number in sequence
    private static int Max(params int[] numbers)
    {
        int result = 0;
        if (numbers.Length > 0)
        {
            result = numbers[0];
            if (numbers.Length > 1)
            {
                for (int index = 1; index < numbers.Length; index++)
                {
                    result = numbers[index] > result ? numbers[index] : result;
                }
            }
        }

        return result;
    }

    // Average of a sequence of integers
    private static decimal Average(params int[] numbers)
    {
        int result = 0;
        if (numbers.Length > 0)
        {
            // LINQ operator that fullfil the same task as below commented lines
            result += numbers.Sum();

            // foreach (var number in numbers)
            // {
            //    result += number;
            // }
            return (decimal)result / numbers.Length;
        }

        return result;
    }

    // Sum of a sequence of integers
    private static int Sum(params int[] numbers)
    {
        int result = 0;
        if (numbers.Length > 0)
        {
            // LINQ operator that fullfil the same task as below commented lines
            result = numbers.Sum();

            // result = 0;
            // foreach (var number in numbers)
            // {
            //    result += number;
            // }
        }

        return result;
    }

    // Product of a sequence of integers
    private static int Product(params int[] numbers)
    {
        int result = 0;
        if (numbers.Length > 0)
        {
            // LINQ with lambda expression that fullfil the same as below commented lines
            result = numbers.Aggregate(1, (current, number) => current * number);

            // result = 1;
            // foreach (var number in numbers)
            // {
            //    result *= number;
            // }
        }

        return result;
    }
}
