using System;
using System.Collections;
using System.Collections.Generic;

public class NeuronMapping
{
    public static void Main()
    {
        Queue<uint> numbers = new Queue<uint>();
        long inputNumber = -1;
        bool flagForBorder = false;

        do
        {
            inputNumber = long.Parse(Console.ReadLine());
            if (inputNumber == -1)
            {
                break;
            }

            string inputNumberAsString = Convert.ToString(inputNumber, 2).PadLeft(32, '0');
            BitArray numberBits = new BitArray(inputNumberAsString.Length);
            for (int count = 0; count < numberBits.Length; count++)
            {
                numberBits[count] = inputNumberAsString[count] == '1';
            }

            // Finding borders of neurons and fill them in
            for (int bit = 0; bit < 32; bit++)
            {
                if (flagForBorder)
                {
                    if (numberBits[bit] == true)
                    {
                        flagForBorder = false;
                        numberBits[bit] = false;
                    }
                    else
                    {
                        numberBits[bit] = true;
                    }
                }
                else if (numberBits[bit] == true && bit < 30)
                {
                    if (numberBits[bit + 1] == false)
                    {
                        for (int i = bit + 2; i < 32; i++)
                        {
                            if (numberBits[i] == true)
                            {
                                flagForBorder = true;
                                break;
                            }
                        }

                        numberBits[bit] = false;
                    }
                    else
                    {
                        numberBits[bit] = false;
                    }
                }
                else
                {
                    numberBits[bit] = false;
                }
            }

            uint finalValue = 0;
            for (int i = numberBits.Count - 1; i >= 0; i--)
            {
                if (numberBits[i])
                {
                    finalValue += Convert.ToUInt32(Math.Pow(2, 31 - i));
                }
            }

            numbers.Enqueue(finalValue);
        }
        while (true);

        // Prints result to console
        while (numbers.Count != 0)
        {
            Console.WriteLine(numbers.Dequeue());
        }
    }
}