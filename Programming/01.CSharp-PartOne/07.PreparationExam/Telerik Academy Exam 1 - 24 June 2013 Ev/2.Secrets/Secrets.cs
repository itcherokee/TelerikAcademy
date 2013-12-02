using System;
using System.Text;

public class Secrets
{
    public static void Main()
    {
        // User input
        StringBuilder input = new StringBuilder();
        input.Append(Console.ReadLine());

        // Remove '-', if negative number entered
        input.Replace("-", string.Empty);
        string inputNumber = input.ToString();
        int specialSum = 0;
        int numberLength = inputNumber.Length;
        bool isEvenLength = numberLength % 2 == 0;

        // Calculate the Special Sum
        int currentDigit = 0;
        for (int index = numberLength - 1; index >= 0; index--)
        {
            currentDigit = int.Parse(inputNumber[index].ToString());
            if (isEvenLength)
            {
                if (index % 2 == 0)
                {
                    specialSum += CalcEven(currentDigit, numberLength - index);
                }
                else
                {
                    specialSum += CalcOdd(currentDigit, numberLength - index);
                }
            }
            else
            {
                if (index % 2 == 0)
                {
                    specialSum += CalcOdd(currentDigit, numberLength - index);
                }
                else
                {
                    specialSum += CalcEven(currentDigit, numberLength - index);
                }
            }
        }

        // Print to console the Special Sum
        Console.WriteLine(specialSum);

        // Calculate Secret Alpha-sequence
        int alphaSequenceLength = specialSum % 10;
        int alphaSequenceReminder = specialSum % 26;

        // Print special case when there is no alph-sequence and exit program
        if (alphaSequenceLength == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", inputNumber);
            return;
        }

        // Create alpha-sequence & Prints result
        int letterIndex = alphaSequenceReminder + 65;
        do
        {
            if (letterIndex == 91)
            {
                letterIndex = 65;
            }

            Console.Write((char)letterIndex);
            alphaSequenceLength--;
            letterIndex++;
        }
        while (alphaSequenceLength != 0);
    }

    public static int CalcOdd(int number, int position)
    {
        return number * (position * position);
    }

    public static int CalcEven(int number, int position)
    {
        return (number * number) * position;
    }
}