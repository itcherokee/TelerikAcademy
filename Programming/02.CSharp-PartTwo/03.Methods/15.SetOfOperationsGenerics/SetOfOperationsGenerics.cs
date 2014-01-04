using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Task: "15. * Modify your last program and try to make it work for any number type, not just integer 
/// (e.g. decimal, float, byte, etc.). Use generic method (read in Internet about generic methods in C#)."
/// </summary>
public class SetOfOperationsGenerics
{
    public static void Main()
    {
        Console.WriteLine("Minimal number: " + Min(11, 2, 3, 4.98, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Maximal number: " + Max(11, 2, 3, 4.98, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Average number: " + Average(11, 2, 3, 4.98, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Sum of numbers: " + Sum(11, 2, 3, 4.98, 5, 10, 6, 7, 8, 9));
        Console.WriteLine("Product of numbers: " + Product(11, 2, 3, 4.98, 5, 10, 6, 7, 8, 9));
    }

    // Minimal number in sequence
    private static T Min<T>(params T[] numbers) where T : struct
    {
        dynamic result = 0;
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
    private static T Max<T>(params T[] numbers) where T : struct
    {
        dynamic result = 0;
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
    private static T Average<T>(params T[] numbers) where T : struct
    {
        dynamic result = 0;
        if (numbers.Length > 0)
        {
            foreach (var number in numbers)
            {
                result += number;
            }

            return result / numbers.Length;
        }

        return result;
    }

    // Sum of a sequence of integers
    private static T Sum<T>(params T[] numbers) where T : struct
    {
        dynamic result = 0;
        if (numbers.Length > 0)
        {
            result = numbers.Aggregate<T, dynamic>(0, (current, number) => current + number);
        }

        return result;
    }

    // Product of a sequence of integers
    private static T Product<T>(params T[] numbers) where T : struct
    {
        dynamic result = 0;
        if (numbers.Length > 0)
        {
            result = numbers.Aggregate<T, dynamic>(1, (current, number) => current * number);
        }

        return result;
    }
}
