using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Task: "8. Write a program that extracts from a given text all sentences containing given word."
/// </summary>
public class ExtractSentence
{
    public static void Main()
    {
        // Source data - you can change them in order to test the routine
        // string input = "We are living in a yellow submarine.";
        string input = "In Alabala is Hoho. He is so deep under water, so he is in... . We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Source text :");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nWord to search :");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(word);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nSentences where the word is met:");
        Console.ForegroundColor = ConsoleColor.Green;

        // Extract all sentences which containing given word
        Console.WriteLine(string.Join("\n", ExtractSentencesByWord(input, word)));
    }

    /// <summary>
    /// Extract all sentences where is met searched word (<paramref name="word"/>).
    /// </summary>
    /// <param name="text">Text where we are going to search.</param>
    /// <param name="word">Word to search in text.</param>
    /// <returns>A List with only the sentences from text where is met the searched word.</returns>
    private static List<string> ExtractSentencesByWord(string text, string word)
    {
        List<string> senteces = new List<string>();
        int sentenceStart = 0;
        int sentenceEnd = 0;
        while (sentenceEnd != -1)
        {
            // Find end of first sentence
            sentenceEnd = text.IndexOf('.', sentenceStart);

            // Bypass iteration if only dots are visible -  could happen when some sentences finish with "..."
            // or sentence is less the length of searched word.
            if (sentenceStart == sentenceEnd || sentenceEnd - sentenceStart < word.Length)
            {
                sentenceStart++;
                continue;
            }

            string currentSentence = text.Substring(sentenceStart, sentenceEnd - sentenceStart + 1);
            int wordIndex = 0;
            int offset = 0;
            do
            {
                wordIndex = currentSentence.IndexOf(word, wordIndex + offset, StringComparison.OrdinalIgnoreCase);

                // Checks does word is a separate one or just substring from another word
                if (!char.IsLetter(currentSentence[wordIndex + word.Length]))
                {
                    if (wordIndex == 0 || !char.IsLetter(currentSentence[wordIndex - 1]))
                    {
                        // It is a separate word so we select the sentence and quit the loop.
                        // There is no need to continue enumerate that sentence anymore as we have 
                        // discovered the first single word, so we fulfill the requirement of task
                        senteces.Add(currentSentence.Trim());
                        break;
                    }
                }

                offset++;
            }
            while (wordIndex != -1);

            if (sentenceEnd == text.Length - 1)
            {
                // Exit loop if we reached the end of the text.
                break;
            }

            // Move to next sentence
            sentenceStart = sentenceEnd + 1;
        }

        return senteces;
    }
}