using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OnesAndZeros
{
    public static void Main()
    {
        string pattern1 = ".#.";
        string pattern2 = "##.";
        string pattern3 = "###";
        string pattern4 = "#.#";


        // input
        int number = int.Parse(Console.ReadLine());
        //if (number < 0)
        //{
        //    number *= -1;
        //}
        char[] temp = new char[32];
        temp = BinaryPreview(number).ToCharArray();
        char[] digits = new char[16];

        for (int i = 0; i < 16; i++)
        {
            digits[i] = temp[i+16];
        }

        //  char[] digits = new char[16];
        //  digits = BinaryPreview(number).ToCharArray();
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 16; k++)
            {
                if (digits[k] == '0')
                {
                    switch (i)
                    {
                        case 0:
                            result.Append(pattern3);
                            break;
                        case 1:
                        case 2:
                        case 3:
                            result.Append(pattern4);
                            break;
                        case 4:
                            result.Append(pattern3);
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 0:
                            result.Append(pattern1);
                            break;
                        case 1:
                            result.Append(pattern2);
                            break;
                        case 2:
                        case 3:
                            result.Append(pattern1);
                            break;
                        case 4:
                            result.Append(pattern3);
                            break;
                    }
                }

                if (k != 15)
                {
                    result.Append(".");
                }
            }
            if (i != 4)
            {
                result.Append("\n");
            }
        }

        Console.WriteLine(result.ToString());
    }

    public static string BinaryPreview(int inputNumber)
    {
        return Convert.ToString(inputNumber, 2).PadLeft(32, '0');
    }
}