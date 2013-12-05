using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FallDown
{
    public static void Main()
    {
        byte[,] bits = new byte[8, 8];
        byte number = 0;
        for (int index = 0; index < 8; index++)
        {
            number = byte.Parse(Console.ReadLine());
            byte[] currentRow = DistributeBits(number);
            for (int column = 0; column < 8; column++)
            {
                bits[index, column] = currentRow[column];
            }
        }

        for (byte column = 0; column < 8; column++)
        {
            if (CalcColumn(bits, column) == 0)
            {
                continue;
            }

            FallDawnBitsInAColumn(bits, column);
        }

        for (byte row = 0; row < 8; row++)
        {
            Console.WriteLine(CalcRow(bits, row));
        }
    }
    
    public static byte CalcColumn(byte[,] bits, byte column)
    {
        int result = 0;
        for (int row = 0; row < 8; row++)
        {
            result += bits[row, column] * (int)Math.Pow(2, row);
        }

        return (byte)result;
    }

    public static byte CalcRow(byte[,] bits, byte row)
    {
        int result = 0;
        for (int column = 7; column >= 0; column--)
        {
            result += bits[row, column] * (int)Math.Pow(2, 7 - column);
        }

        return (byte)result;
    }

    public static byte[] DistributeBits(byte number)
    {
        byte[] bitsOfNumber = new byte[8];
        int reminder = 0;
        for (int column = 7; column >= 0; column--)
        {
            reminder = number % 2;
            number /= 2;
            if (reminder == 1)
            {
                bitsOfNumber[column] = 1;
            }
            else
            {
                bitsOfNumber[column] = 0;
            }
        }

        return bitsOfNumber;
    }

    public static void FallDawnBitsInAColumn(byte[,] bits, byte column)
    {
        for (int row = 6; row >= 0; row--)
        {
            for (int repeat = row; repeat < 7; repeat++)
            {
                if (bits[repeat, column] == 1 && bits[repeat + 1, column] == 0)
                {
                    bits[repeat + 1, column] = 1;
                    bits[repeat, column] = 0;
                }
            }
        }
    }
}