// Task definitiation is in the solution folder
namespace MovingLetters
{
    using System;
    using System.Linq;
    using System.Text;

    public class MovingLettersExec
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split().Select(x => new string(x.ToCharArray().Reverse().ToArray())).ToArray();
            int wordWithMaxLength = words.Max(x => x.Length);
            StringBuilder textToEncrypt = new StringBuilder();
            textToEncrypt = ExtractLetters(words, wordWithMaxLength);
            Console.WriteLine(RotateLetters(textToEncrypt));
        }

        private static StringBuilder ExtractLetters(string[] words, int wordWithMaxLength)
        {
            StringBuilder result = new StringBuilder();

            // Enumerate all columns one by one by length of the word with max length
            for (int column = 0; column < wordWithMaxLength; column++)
            {
                // Enumerate all words in array one by one
                for (int row = 0; row < words.Length; row++)
                {
                    // If in the current word the column exist (word.length is bigger) => add char to result
                    if (words[row].Length > column)
                    {
                        result.Append(words[row][column]);
                    }
                }
            }

            return result;
        }

        private static string RotateLetters(StringBuilder encryptedText)
        {
            string letter;
            int letterIndex = 0;
            int alphabetposition = 0;
            for (int index = 0; index < encryptedText.Length; index++)
            {
                // take current letter
                letter = encryptedText[letterIndex].ToString();

                // Calculate number of letter
                alphabetposition = letter.ToUpper()[0] - 64;

                // Delete the letter from encrypted text
                encryptedText.Remove(letterIndex, 1);

                // Calculate new index
                int newIndex = (letterIndex + alphabetposition) % (encryptedText.Length + 1);

                // Insert the letter in encrypted text at the new index
                encryptedText.Insert(newIndex, letter);
                letterIndex++;
            }

            return encryptedText.ToString();
        }
    }
}