// Task definition is in the solution folder
namespace DecodeAndDecrypt
{
    using System;
    using System.Globalization;
    using System.Text;

    // Enumeration used in Extract method for pointing directions of procesing the text
    internal enum Direction
    {
        FromStart,
        FromEnd,
    }

    public class DecodeDecryptExec
    {
        public static void Main()
        {
            // Get message 
            string cypherText = Console.ReadLine();

            // Get cypher
            string cypher = Console.ReadLine();
            int cypherLength = cypher.Length;

            // Encrypt text
            string encryptedText = Encrypt(cypherText, cypher);

            // Attach cypher to message
            encryptedText += cypher;

            // Encode message and cypher + add size of cypher
            encryptedText = Encode(encryptedText) + cypherLength;

            // Output result
            Console.WriteLine(encryptedText);
        }

        // Encrypt text
        private static string Encrypt(string text, string cypher)
        {
            char[] letters =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
                'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|',
                '}', '~', '⌂'
            };
            int[] codes =
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
                26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51,
                52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62
            };
            if (!string.IsNullOrEmpty(cypher))
            {
                StringBuilder encryptedText = new StringBuilder(text);
                int endOfLoop;
                bool cypherShorter = false;
                bool encryptedTextShorter = false;
                if (text.Length > cypher.Length)
                {
                    endOfLoop = text.Length;
                    cypherShorter = true;
                }
                else if (text.Length < cypher.Length)
                {
                    endOfLoop = cypher.Length;
                    encryptedTextShorter = true;
                }
                else
                {
                    endOfLoop = text.Length;
                }

                int indexCypher = 0;
                int indexText = 0;
                int commonCounter = 0;
                while (commonCounter < endOfLoop)
                {
                    int halfDecryptedChar = encryptedText[indexText] - 65;
                    int cypherLetterCode = Array.IndexOf(codes, Array.IndexOf(letters, cypher[indexCypher]));
                    int decryptedChar = halfDecryptedChar ^ cypherLetterCode;
                    encryptedText.Replace(encryptedText[indexText], letters[decryptedChar], indexText, 1);
                    if (indexCypher + 1 >= cypher.Length && cypherShorter)
                    {
                        indexCypher = 0;
                    }
                    else
                    {
                        indexCypher++;
                    }

                    if (indexText + 1 >= text.Length && encryptedTextShorter)
                    {
                        indexText = 0;
                    }
                    else
                    {
                        indexText++;
                    }

                    commonCounter++;
                }

                return encryptedText.ToString();
            }

            return text;
        }

        // Decodes text, based on run-length encoding
        private static string Encode(string text)
        {
            StringBuilder result = new StringBuilder();
            char letter = text[0];
            int letterCounter = 1;
            for (int index = 1; index <= text.Length; index++)
            {
                if (index == text.Length || !text[index].Equals(letter))
                {
                    if (letterCounter > 2)
                    {
                        result.Append(letterCounter);
                        result.Append(letter);
                    }
                    else if (letterCounter == 2)
                    {
                        result.Append(letter);
                        result.Append(letter);
                    }
                    else
                    {
                        result.Append(letter);
                    }

                    if (index == text.Length)
                    {
                        break;
                    }

                    letter = text[index];
                    letterCounter = 1;
                }
                else
                {
                    letterCounter++;
                }
            }

            return result.ToString();
        }
    }
}