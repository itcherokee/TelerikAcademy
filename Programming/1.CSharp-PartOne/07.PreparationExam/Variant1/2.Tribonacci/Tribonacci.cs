using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        BigInteger nElement = BigInteger.Parse(Console.ReadLine());
        if (nElement == 1)
        {
            Console.WriteLine(t1);
        }
        else if (nElement == 2)
        {
            Console.WriteLine(t2);
        }
        else if (nElement == 3)
        {
            Console.WriteLine(t3);
        }
        else
        {
            BigInteger sumTribonacci = 0;
            for (short i = 4; i <= nElement; i++)
            {
                sumTribonacci = t1 + t2 + t3;
                t1 = t2;
                t2 = t3;
                t3 = sumTribonacci;
            }
            Console.WriteLine(sumTribonacci);
        }
    }
}
