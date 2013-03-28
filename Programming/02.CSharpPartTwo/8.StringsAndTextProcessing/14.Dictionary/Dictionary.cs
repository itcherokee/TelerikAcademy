using System;

public class Dictionary
{
    // A dictionary is stored as a sequence of text lines containing words and their explanations. 
    // Write a program that enters a word and translates it by using the dictionary. 

    public static void Main()
    {
        Console.Title = "Dictionary";
        string vocabulary = ".NET – platform for applications from Microsoft \n" +
                            "CLR – managed execution environment for .NET \n" +
                            "namespace – hierarchical organization of classes \n";
        string[] words = vocabulary.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        Console.Write("These are the words that I know: ");
        for (int index = 0; index < words.Length; index++)
        {
            Console.Write(words[index].Substring(0, words[index].IndexOf(" – ")));
            if (index < words.Length - 1)
            {
                Console.Write(", ");
            }
        }

        Console.Write("\nChoose a word: ");
        string selectedWord = Console.ReadLine();
        int answer = -1;
        int length = 0;
        for (int index = 0; index < words.Length; index++)
        {
            if (words[index].Substring(0,  words[index].IndexOf(" – ")).ToLower().CompareTo(selectedWord.ToLower()) == 0)
            {
                answer = index;
                length = words[index].Length;
                break;
            }
        }

        Console.WriteLine(new string('=', length));
        Console.WriteLine(answer != -1 ? words[answer] : "The word is unknown to me!");
        Console.WriteLine(new string('=', length));
    }
}