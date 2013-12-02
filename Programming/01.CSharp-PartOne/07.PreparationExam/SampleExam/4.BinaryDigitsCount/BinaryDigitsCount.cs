using System;
using System.Collections;

public class BinaryDigitsCount
{
    public static void Main()
    {
        byte binary = byte.Parse(Console.ReadLine());
        ushort numberOfDigits = ushort.Parse(Console.ReadLine());
        uint resultMask = 0;
        int resultBinaries = 0;
        ArrayList numbers = new ArrayList(numberOfDigits);
        for (int i = 1; i <= numberOfDigits; i++)
        {
            numbers.Add(uint.Parse(Console.ReadLine()));
        }

        foreach (uint number in numbers)
        {
            uint mask = 1;
            uint modifiedMask = 0;
            int msb = 0;
            for (int i = 31; i >= 0; i--)
            {
                modifiedMask = mask << i;
                resultMask = modifiedMask & number;
                resultMask = resultMask >> i;
                if (resultMask == 1)
                {
                    msb = i;
                    break;
                }
            }

            for (int i = 0; i <= msb; i++)
            {
                modifiedMask = mask << i;
                resultMask = modifiedMask & number;
                resultMask = resultMask >> i;
                if (((binary == 0) && (resultMask == 0)) || ((binary == 1) && (resultMask == 1)))
                {
                    resultBinaries++;
                }
            }

            mask = 0;
            Console.WriteLine(resultBinaries);
            resultBinaries = 0;
        }
    }
}