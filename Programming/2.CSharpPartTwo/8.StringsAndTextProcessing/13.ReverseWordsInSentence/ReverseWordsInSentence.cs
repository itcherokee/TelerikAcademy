using System;
using System.Text;

public class ReverseWordsInSentence
{
    // Write a program that reverses the words in given sentence.

    public static void Main()
    {
        Console.Title = "Reverse words in a sentence";
        string userInput = "C# is not C++, not PHP and not Delphi!";
        //string userInput = "Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.";
        string[] wordsArray = userInput.Split(new char[] { ' ', '.', ',', '!', '?', ':', '"', '(', ')', '[', ']', '{', '}', '/', '\\', '-' }, StringSplitOptions.RemoveEmptyEntries);
        int startIndex = 0;
        int endIndex = userInput.Length - 1;
        int endIndexCount = userInput.Length - 1;
        StringBuilder result = new StringBuilder(userInput);
        for (int index = 0; index < wordsArray.Length; index++)
        {
            startIndex = result.ToString().IndexOf(wordsArray[index], startIndex);
            endIndex = result.ToString().LastIndexOf(wordsArray[wordsArray.Length - 1 - index], endIndex);
            if (startIndex == endIndex)
            {
                break;
            }

            result.Replace(wordsArray[wordsArray.Length - 1 - index], wordsArray[index], endIndex, wordsArray[wordsArray.Length - 1 - index].Length);
            result.Replace(wordsArray[index], wordsArray[wordsArray.Length - 1 - index], startIndex, wordsArray[index].Length);

            startIndex += wordsArray[wordsArray.Length - 1 - index].Length;
            endIndex += wordsArray[wordsArray.Length - 1 - index].Length - wordsArray[index].Length - 1;
        }

        Console.WriteLine(result.ToString());
    }
}