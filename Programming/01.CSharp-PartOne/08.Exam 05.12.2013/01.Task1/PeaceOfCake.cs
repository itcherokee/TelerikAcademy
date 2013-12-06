using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PeaceOfCake
{
    public static void Main()
    {
        // Console.WriteLine(ushort.MaxValue);
        uint numberA = uint.Parse(Console.ReadLine());
        uint numberB = uint.Parse(Console.ReadLine());
        uint numberC = uint.Parse(Console.ReadLine());
        uint numberD = uint.Parse(Console.ReadLine());

        decimal nom = Nominator(numberA, numberB, numberC, numberD);
        decimal den = Denominator(numberA, numberB, numberC, numberD);
        decimal result = Calc(nom, den);

        if (result >= 1)
        {
            Console.WriteLine((long)result);
            Console.WriteLine("{0}/{1}", nom, den);
        }
        else
        {
            Console.WriteLine("{0:F22}", result);
            Console.WriteLine("{0}/{1}", nom, den);
        }

    }

    public static decimal Calc(decimal nominator, decimal denominator)
    {
        decimal result = default(decimal);
        result = nominator / denominator;
        return result;
    }

    public static long Nominator(long a, long b, long c, long d)
    {
        long result = default(long);
        long first = a * d;
        long second = c * b;
        result = first + second;
        return result;
    }

    public static long Denominator(long a, long b, long c, long d)
    {
        long result = default(long);
        result = b * d;
        return result;
    }


}