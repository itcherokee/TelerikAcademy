using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperLibrary;

class Program
{
    static void Main()
    {
        byte position = 10;
        int number = 8;

        Console.WriteLine("Number: " + Binary.BinaryPreview(number));
        Console.WriteLine("Bit at position {0} is 1: {1}", position, Binary.IsBitSetToOne(number, position));
        Console.WriteLine("Bit at position {0} is 0: {1}", position, Binary.IsBitSetToZero(number, position));
        number = Binary.SetBitToOne(number, position);
        Console.WriteLine("Set to 1 the bit at position {0}: {1}", position, Binary.BinaryPreview(number));
        Console.WriteLine("Bit at position {0} is: {1}", position, Binary.GetBitAsDigit(number, position));
        Console.WriteLine("Number of bits set to one are: {0}", Binary.SumOfBits(number));
        number = Binary.SetBitToZero(number, position);
        Console.WriteLine("Set to 0 the bit at position {0}: {1}", position, Binary.BinaryPreview(number));
        Console.WriteLine("Bit at position {0} is: {1}", position, Binary.GetBitAsDigit(number, position));
        Console.WriteLine("Number of bits set to one are: {0}", Binary.SumOfBits(number));
        number = Binary.SwapBits(number, 3, 30);
        Console.WriteLine("Number: " + Binary.BinaryPreview(number));
        number = 55;
        Console.WriteLine("Number    = " + Binary.BinaryPreview(number));
        int subNumber = Binary.GetRangeOfBitsAsDigit(number, 2, 3);
        Console.WriteLine("Sub range = " + Binary.BinaryPreview(subNumber));
        number = 255;
        Console.WriteLine("Number    = " + Binary.BinaryPreview(number));
        Console.WriteLine("Sub range = " + Binary.BinaryPreview(Binary.SetBitsRangeToZero(number, 0, 4)));

        number = 255;
        Console.WriteLine("Number     = " + Binary.BinaryPreview(number));
        Console.WriteLine("Swap range = " + Binary.BinaryPreview(Binary.SwapBits(number, 0, 20, 4)));


        uint n = 4290772963;

        //Print the number before it has been changed for comparison
        Console.WriteLine(Convert.ToString(n, 2));

        byte p = 3;
        byte q = 2;
        byte k = 21;
        uint mask = 1;//when shifting right you need yout right side to be int

        //set the mask E.g (2^3) - 1
        for (int i = 0; i < p; i++)
        {
            mask *= 2;
        }

        //get the first bits
        uint getFirstBits = (((mask - 1) << q) & n) >> q;
        //get the second bits
        uint getSecondBits = (((mask - 1) << k) & n) >> k;

        //null the first bits
        n = n & (~((mask - 1) << q));
        //null the second bits
        n = n & (~((mask - 1) << k));

        //we concatnate the first bits and the nulled number(we exchange them)
        n = n | (getFirstBits << k);

        //we concatnate the second bits and the nulled number(we exchange them)
        n = n | (getSecondBits << q);

        //Print changed
        Console.WriteLine(Convert.ToString(n, 2));
    }
}