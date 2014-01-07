using System;

/// <summary>
/// Task: "14. A dictionary is stored as a sequence of text lines containing words and their explanations. 
/// Write a program that enters a word and translates it by using the dictionary."
/// </summary>
public class Dictionary
{
    public static void Main()
    {
        Console.Title = "Dictionary";
        const string Vocabulary = ".NET – platform for applications from Microsoft \n" +
                                  "CLR – managed execution environment for .NET \n" +
                                  "namespace – hierarchical organization of classes \n";
        string[] words = Vocabulary.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Output to Console all words in vocabulary
        ShowWordsInVocabulary(words);

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nChoose a word: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string selectedWord = Console.ReadLine();

        // Search in Dictionary for the word
        var answer = SearchDictionary(words, selectedWord);

        // Output to Console
        if (answer > -1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', words[answer].Length + 1));
            Console.WriteLine(" " + words[answer]);
            Console.WriteLine(new string('=', words[answer].Length + 1));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The word is unknown to me!");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    /// <summary>
    /// Search dictionary for word.
    /// </summary>
    /// <param name="vocabulary">Dictionary where to search for word (<paramref name="word"/>).</param>
    /// <param name="word">The word to be searched in the vocabulary.</param>
    /// <returns>Index in the vocabulary, where is located the word or returns -1 if word is not found.</returns>
    private static int SearchDictionary(string[] vocabulary, string word)
    {
        int answer = -1;
        for (int index = 0; index < vocabulary.Length; index++)
        {
            if (word != null)
            {
                var vocabularyWord = vocabulary[index].Substring(0, vocabulary[index].IndexOf(" – ", StringComparison.OrdinalIgnoreCase));
                if (string.Compare(vocabularyWord, word, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    answer = index;
                    break;
                }
            }
        }

        return answer;
    }

    /// <summary>
    /// Output to Console all words that are in vocabulary as reference (index).
    /// </summary>
    /// <param name="vocabulary">Dictionary to use.</param>
    private static void ShowWordsInVocabulary(string[] vocabulary)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("These are the words that I know: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int index = 0; index < vocabulary.Length; index++)
        {
            Console.Write(vocabulary[index].Substring(0, vocabulary[index].IndexOf(" – ", StringComparison.OrdinalIgnoreCase)));
            if (index < vocabulary.Length - 1)
            {
                Console.Write(", ");
            }
        }
    }
}