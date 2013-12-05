using System;
using System.Collections.Generic;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        SortedSet<BigInteger> numbers = new SortedSet<BigInteger>();
        int count = int.Parse(Console.ReadLine());
        BigInteger current = 0;
        for (int index = 0; index < count; index++)
        {
            current = BigInteger.Parse(Console.ReadLine());
            if (!numbers.Add(current))
            {
                numbers.Remove(current);
            }
        }

        foreach (var number in numbers)
        {
            Console.WriteLine(number.ToString());
        }
    }
}