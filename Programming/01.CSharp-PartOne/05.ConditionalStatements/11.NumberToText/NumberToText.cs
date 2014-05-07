using System;
using System.Text;

/// <summary>
/// Task: "11. *Write a program that converts a number in the range [0...999] 
/// to a text corresponding to its English pronunciation. 
/// Examples:
/// 0 -> "Zero"
/// 273 -> "Two hundred seventy three"
/// 400 -> "Four hundred"
/// 501 -> "Five hundred and one"
/// 711 -> "Seven hundred and eleven"
/// </summary>
public class NumberToText
{
    public static void Main()
    {
        Console.Title = "Convert Number to Text";
        string[] numberNames = 
        {
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
            "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
            "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "thirty",
            "forty", "fifty", "eighty", "hundred", "ty"
        };
        int inputValueInt = 0;
        string initialNumber = default(string);
        int hundreds = 0;
        int tens = 0;
        int units = 0;
        StringBuilder inputValueStr = new StringBuilder();
        StringBuilder finalTranslation = new StringBuilder();
        bool isValidInput = false;
        do
        {
            Console.Write("Enter a number [0..999] to translate it to English:");
            inputValueStr.Append(Console.ReadLine());
            isValidInput = int.TryParse(inputValueStr.ToString(), out inputValueInt);
            if (isValidInput)
            {
                isValidInput = false;
                initialNumber = inputValueStr.ToString();

                // Separate hundreds/tens/units
                hundreds = inputValueInt / 100;
                tens = (inputValueInt / 10) % 10;
                units = inputValueInt % 10;

                // Checks for zero
                if (inputValueInt == 0)
                {
                    finalTranslation.Append(numberNames[units]);
                    inputValueStr.Length = 0;
                }

                // Assigns hundreds
                if (inputValueStr.Length == 3)
                {
                    finalTranslation.Append(numberNames[hundreds] + " ");
                    finalTranslation.Append(numberNames[25]);
                    if ((hundreds != 0) && ((tens != 0) || (units != 0)))
                    {
                        finalTranslation.Append(" and ");
                    }

                    // Removes the hundreds
                    inputValueStr.Remove(0, 1);
                }

                // Assigns tens
                if ((inputValueStr.Length == 2) && (tens != 0))
                {
                    switch (tens)
                    {
                        case 1:
                            finalTranslation.Append(numberNames[tens + 9 + units]);
                            inputValueStr.Length = 1;
                            break;
                        case 2:
                            finalTranslation.Append(numberNames[20]);
                            break;
                        case 3:
                            finalTranslation.Append(numberNames[21]);
                            break;
                        case 4:
                            finalTranslation.Append(numberNames[22]);
                            break;
                        case 5:
                            finalTranslation.Append(numberNames[23]);
                            break;
                        case 6:
                            finalTranslation.Append(numberNames[tens] + numberNames[26]);
                            break;
                        case 7:
                            finalTranslation.Append(numberNames[tens] + numberNames[26]);
                            break;
                        case 8:
                            finalTranslation.Append(numberNames[24]);
                            break;
                        case 9:
                            finalTranslation.Append(numberNames[tens] + numberNames[26]);
                            break;
                    }

                    // Removes the tens
                    inputValueStr.Remove(0, 1);
                }
                else if (tens == 0)
                {
                    // Removes the tens
                    inputValueStr.Remove(0, 1);
                }

                // Assigns units
                if (inputValueStr.Length == 1)
                {
                    if ((tens != 0) && (units != 0))
                    {
                        finalTranslation.Append(" ");
                    }

                    if (units != 0 && tens != 1)
                    {
                        finalTranslation.Append(numberNames[units]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Input was not a number or out of scope, please try again.");
                Console.ReadKey();
                Console.Clear();
                isValidInput = true;
            }
        }
        while (isValidInput);

        Console.WriteLine("Translation of {0} is: \"{1}\"", initialNumber, finalTranslation.ToString());
    }
}