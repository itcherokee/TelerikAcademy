using System;
using System.Collections.Generic;
using System.Numerics;

public class LeastMajorityMultiple
{
    public static void Main()
    {
        uint[] numbers = new uint[5];
        for (int index = 0; index < 5; index++)
        {
            numbers[index] = byte.Parse(Console.ReadLine());
        }

        BigInteger currentGCD;
        List<BigInteger> result = new List<BigInteger>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = i + 1; j < 4; j++)
            {
                for (int k = j + 1; k < 5; k++)
                {
                    currentGCD = LCD(numbers[i], LCD(numbers[j], numbers[k]));
                    result.Add(currentGCD);
                }
            }
        }

        result.Sort();
        Console.WriteLine(result[0]);
    }

    public static uint LCD(uint numberOne, uint numberTwo)
    {
        uint result = 0;
        uint chislitel = (uint)numberOne * numberTwo;
        result = chislitel / (uint)BigInteger.GreatestCommonDivisor(numberOne, numberTwo);
        return result;
    }
}