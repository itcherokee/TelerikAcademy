using System;

public class ExtractSentence
{
    // Write a program that extracts from a given text all sentences containing given word.

    public static void Main()
    {
        string userInput = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string givenWord = "in";
        int startOfSentence = 0;
        int endOfSentence = 0;
        int indexOfWord = -1;
        while (endOfSentence != -1)
        {
            endOfSentence = userInput.IndexOf('.', startOfSentence);
            indexOfWord = userInput.IndexOf(string.Concat(' ', givenWord, ' '), startOfSentence);
            if (indexOfWord < endOfSentence && indexOfWord > startOfSentence)
            {
                Console.WriteLine(userInput.Substring(startOfSentence, endOfSentence - startOfSentence).Trim());
            }

            startOfSentence = endOfSentence + 1;
        }
    }
}