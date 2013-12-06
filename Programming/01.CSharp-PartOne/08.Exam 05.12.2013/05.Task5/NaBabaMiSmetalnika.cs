using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NaBabaMiSmetalnika
{
    public static int leftBorder = 32;
    public static void Main()
    {

        byte width = byte.Parse(Console.ReadLine()); // [5..32]
        leftBorder = width - 1;

        int[] numbers = new int[8];
        for (int index = 0; index < 8; index++)
        {
            numbers[index] = int.Parse(Console.ReadLine());
        }

        int line = 0;
        int position = 0;
        while (true)
        {
            string command = Console.ReadLine();
            switch (command)
            {
                case "right":
                    line = int.Parse(Console.ReadLine());
                    position = int.Parse(Console.ReadLine());
                    if (position < 0)
                    {
                        position = 0;
                    }
                    else if (position > leftBorder)
                    {
                        position = leftBorder - 1;
                    }
                    else
                    {
                        position = leftBorder - position;
                    }
                    numbers[line] = ShiftRight(numbers[line], position);
                    break;
                case "left":
                    line = int.Parse(Console.ReadLine());
                    position = int.Parse(Console.ReadLine());
                    if (position < 0)
                    {
                        position = 0;
                    }
                    else if (position > leftBorder)
                    {
                        position = leftBorder - 1;
                    }
                    else
                    {
                        position = leftBorder - position;
                    }
                    numbers[line] = ShiftLeft(numbers[line], position);
                    break;
                case "reset":
                    Reset(numbers);
                    break;
                case "stop":
                    Console.WriteLine(CalcResult(numbers));
                    return;
            }

        }
    }

    private static int ShiftLeft(int number, int position)
    {
        int bitSum = SumOfBitsToLeft(number, position);
        number = SetBitsRangeToZero(number, position, leftBorder - position);
        number = SetBitsRangeToOne(number, leftBorder - bitSum + 1, bitSum);
        return number;
    }

    private static int ShiftRight(int number, int position)
    {
        int bitSum = SumOfBitsToRight(number, position);
        number = SetBitsRangeToZero(number, 0, position);
        number = SetBitsRangeToOne(number, 0, bitSum);
        return number;
    }




    public static bool IsBitSetToOne(int inputNumber, int position)
    {
        int mask = 1 << position;
        int result = inputNumber & mask;
        result >>= position;
        return result == 1 ? true : false;
    }

    public static int GetBitAsDigit(int inputNumber, int position)
    {
        int mask = 1 << position;
        int result = inputNumber & mask;
        result >>= position;
        return result;
    }

    public static int SumOfBits(int inputNumber)
    {
        int result = default(int);
        for (int index = 0; index < 32; index++)
        {
            result += GetBitAsDigit(inputNumber, index);
        }

        return result;
    }

    public static int SumOfBitsToRight(int inputNumber, int position)
    {
        int result = default(int);
        for (int index = position; index >= 0; index--)
        {
            result += GetBitAsDigit(inputNumber, index);
        }

        return result;
    }

    public static int SumOfBitsToLeft(int inputNumber, int position)
    {
        int result = default(int);
        for (int index = position; index < leftBorder; index++)
        {
            result += GetBitAsDigit(inputNumber, index);
        }

        return result;
    }

    public static int SetBitsRangeToZero(int inputNumber, int position, int countOfBits)
    {
        if (position + countOfBits > 31)
        {
            throw new ArgumentOutOfRangeException("Invalid values for countOfBits or position.");
        }

        int mask = 1;
        for (int index = 0; index < countOfBits; index++)
        {
            mask *= 2;
        }

        mask = (mask - 1) << position;
        int result = inputNumber & ~mask;
        return result;
    }

    public static int SetBitsRangeToOne(int inputNumber, int position, int countOfBits)
    {
        if (position + countOfBits > 31)
        {
            throw new ArgumentOutOfRangeException("Invalid values for countOfBits or position.");
        }

        int mask = 1;
        for (int index = 0; index < countOfBits; index++)
        {
            mask *= 2;
        }

        mask = (mask - 1) << position;
        int result = inputNumber | mask;
        return result;
    }

    public static void Reset(int[] numbers)
    {
        for (int row = 0; row < 8; row++)
        {
            int bitSum = SumOfBits(numbers[row]);
            numbers[row] = SetBitsRangeToZero(numbers[row], 0, leftBorder - 1);
            numbers[row] = SetBitsRangeToOne(numbers[row], leftBorder, bitSum);
        }
    }

    private static int CalcResult(int[] numbers)
    {
        int result = 0;
        for (int index = 0; index < 8; index++)
        {
            result += numbers[index];
        }

        int emptyColumns = 0;

        for (int column = 0; column < leftBorder; column++)
        {
            if (IsColumnEmpty(numbers, column))
            {
                emptyColumns++;
            }
        }

        if (emptyColumns != 0)
        {
            result *= emptyColumns;
        }

        return result;
    }

    public static bool IsColumnEmpty(int[] number, int column)
    {
        bool result = true;
        int col = column;
        int mask = 1 << col;
        for (int index = 0; index < 8; index++)
        {
            if ((number[index] & mask) >> col == 1)
            {
                result = false;
                break;
            }
        }
        return result;

    }
}