using System;
using System.Text;

class NumberToText
{
    static void Main()
    {
        // *Write a program that converts a number in the range [0...999] 
        // to a text corresponding to its English pronunciation. 
        // Examples:
        //	0 -> "Zero"
        // 273 -> "Two hundred seventy three"
        // 400 -> "Four hundred"
        // 501 -> "Five hundred and one"
        // 711 -> "Seven hundred and eleven"

        string[] numberNames = new string[27] 
        { "zero","one", "two","three","four","five","six","seven","eight","nine","ten","eleven",
        "twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen","twenty","thirty","forty","fifty","eighty","hundred","ty"};
        int inputValueInt = 0;
        StringBuilder inputValueStr = new StringBuilder();
        string initialNumber = "";
        int hundreds = 0;
        int tens = 0;
        int units = 0;
        StringBuilder finalTranslation = new StringBuilder();
        bool wrongInput = false;
        Console.Title = "Convert Number to Text";
        do
        {
            Console.Write("Enter a number [0..999] to translate it to English:");
            inputValueStr.Append(Console.ReadLine());
            wrongInput = int.TryParse(inputValueStr.ToString(), out inputValueInt);
            if (wrongInput)
            {
                wrongInput = false;
                initialNumber = inputValueStr.ToString();
                //separate hundreds/tens/units
                hundreds = inputValueInt / 100;
                tens = (inputValueInt / 10) % 10;
                units = inputValueInt % 10;
                //checks for zero
                if (inputValueInt == 0)
                { 
                    finalTranslation.Append(numberNames[units]);
                    inputValueStr.Length = 0;
                }
                //Assigns hundreds
                if (inputValueStr.Length == 3)
                {
                    finalTranslation.Append(numberNames[hundreds] + " ");
                    finalTranslation.Append(numberNames[25]);
                    if ((hundreds != 0) && ((tens != 0) || (units != 0))) { finalTranslation.Append(" and "); }
                    inputValueStr.Remove(0, 1); //removes the hundreds
                }
                //Assigns tens
                if ((inputValueStr.Length == 2) && (tens != 0))
                {
                    switch (tens)
                    {
                        case 1: finalTranslation.Append(numberNames[tens + 9 + units]); inputValueStr.Length = 1; break;
                        case 2: finalTranslation.Append(numberNames[20]); break;
                        case 3: finalTranslation.Append(numberNames[21]); break;
                        case 4: finalTranslation.Append(numberNames[22]); break;
                        case 5: finalTranslation.Append(numberNames[23]); break;
                        case 6:
                        case 7:
                        case 8: finalTranslation.Append(numberNames[24]); break;
                        case 9: finalTranslation.Append(numberNames[tens] + numberNames[26]); break;
                    }
                    inputValueStr.Remove(0, 1); //removes the tens
                }
                else if (tens == 0)
                {
                    inputValueStr.Remove(0, 1); //removes the tens
                }
                // Assigns units
                if (inputValueStr.Length == 1)
                {
                    if ((tens != 0) && (units != 0))
                    {
                        finalTranslation.Append(" ");
                    }
                    if (units != 0) { finalTranslation.Append(numberNames[units]); }

                }
            }
            else
            {
                Console.WriteLine("Input was not a number or out of scope, please try again.");
                Console.ReadKey();
                Console.Clear();
                wrongInput = true;
            }
        } while (wrongInput);
        Console.WriteLine("Translation of {0} is: \"{1}\"", initialNumber, finalTranslation.ToString());
    }
}
