using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

public class AngryemaleGPS
{
    public static void Main()
    {

        long input = long.Parse(Console.ReadLine());
        BigInteger number = input < 0 ? (BigInteger)input * -1 : (BigInteger)input;

        BigInteger odd = CalcOdd(number);
        BigInteger even = CalcEven(number);
        if (even > odd)
        {
            Console.WriteLine("right {0}", even);
        }
        else if (odd > even)
        {
            Console.WriteLine("left {0}", odd);
        }
        else
        {
            Console.WriteLine("straight {0}", odd);
        }

    }

    public static BigInteger CalcOdd(BigInteger n)
    {
        BigInteger result = default(BigInteger);
        long step = 10;
        BigInteger temp = default(BigInteger);
        int length = n.ToString().Length;
        if (n < 0)
        {
            length--;
        }
        for (int index = 0; index < length; index++)
        {
            temp = n % step;
            if (temp % 2 != 0)
            {
                result += temp;
            }

            n /= 10;
        }

        return result;
    }

    public static BigInteger CalcEven(BigInteger n)
    {
        BigInteger result = default(BigInteger);
        long step = 10;
        BigInteger temp = default(BigInteger);
        int length = n.ToString().Length;
        if (n < 0)
        {
            length--;
        }
        for (int index = 0; index < length; index++)
        {
            temp = n % step;
            if (temp % 2 == 0)
            {
                result += temp;
            }

            n /= 10;
        }

        return result;
    }
}