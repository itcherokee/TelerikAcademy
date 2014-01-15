// Task definition is in the solution folder
namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MagicWordsExec
    {
        public static void Main()
        {
            int wordsNumber = int.Parse(Console.ReadLine());
            int longestWord = 0;
            int totallength = 0;
            List<string> words = new List<string>(wordsNumber + 1);
            for (int i = 0; i < wordsNumber; i++)
            {
                string wordEntered = Console.ReadLine();
                words.Add(wordEntered);
                totallength += wordEntered.Length;
                if (longestWord < wordEntered.Length)
                {
                    longestWord = wordEntered.Length;
                }
            }

            Reorder(words);
            Print(words, totallength, longestWord);
        }

        private static void Reorder(IList<string> words)
        {
            for (int i = 0; i < words.Count; i++)
            {
                int position = words[i].Length % (words.Count + 1);
                string word = words[i];
                if (position > i)
                {
                    words.Insert(position, word);
                    words.RemoveAt(i);
                }
                else if (position < i)
                {
                    words.RemoveAt(i);
                    words.Insert(position, word);
                }
            }
        }

        private static void Print(IList<string> words, int totallength, int longestWord)
        {
            var output = new StringBuilder(totallength);
            for (int letter = 0; letter < longestWord; letter++)
            {
                foreach (string t in words)
                {
                    if (t.Length <= letter)
                    {
                        continue;
                    }

                    output.Append(t[letter]);
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}