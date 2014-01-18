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
            // Input 
            string cypherText = Console.ReadLine();

            // Get cypher's length as a string
            var cypherLengthAsString = ExtractNumber(cypherText, Direction.FromEnd);

            // Get cypher's length as a value (number)
            int cypherLength = int.Parse(cypherLengthAsString);

            // Decode cypher text - without the cypher length value at the end
            string decodedText = Decode(cypherText.Substring(0, cypherText.Length - cypherLength.ToString(CultureInfo.InvariantCulture).Length));
            if (decodedText.Length != cypherLength)
            {
                // Extract the cypher from decoded text using the cypher length
                string cypher = decodedText.Substring(decodedText.Length - cypherLength, cypherLength);

                // Decrypt the message using extracted cypher on encrypted message
                string decryptedText = Decrypt(decodedText.Substring(0, decodedText.Length - cypher.Length), cypher);

                // Output message
                Console.WriteLine(decryptedText);
            }
        }

        private static string Decrypt(string encryptedText, string cypher)
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~', '⌂' };
            int[] codes = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62 };
            if (!string.IsNullOrEmpty(cypher))
            {
                StringBuilder decryptedText = new StringBuilder(encryptedText);
                int endOfLoop;
                bool cypherShorter = false;
                bool encryptedTextShorter = false;
                if (encryptedText.Length > cypher.Length)
                {
                    endOfLoop = encryptedText.Length;
                    cypherShorter = true;
                }
                else if (encryptedText.Length < cypher.Length)
                {
                    endOfLoop = cypher.Length;
                    encryptedTextShorter = true;
                }
                else
                {
                    endOfLoop = encryptedText.Length;
                }

                int indexCypher = 0;
                int indexText = 0;
                int commonCounter = 0;
                while (commonCounter < endOfLoop)
                {
                    int halfDecryptedChar = decryptedText[indexText] - 65;
                    int cypherLetterCode = Array.IndexOf(codes, Array.IndexOf(letters, cypher[indexCypher]));
                    int decryptedChar = halfDecryptedChar ^ cypherLetterCode;
                    decryptedText.Replace(decryptedText[indexText], letters[decryptedChar], indexText, 1);
                    if (indexCypher + 1 >= cypher.Length && cypherShorter)
                    {
                        indexCypher = 0;
                    }
                    else
                    {
                        indexCypher++;
                    }

                    if (indexText + 1 >= encryptedText.Length && encryptedTextShorter)
                    {
                        indexText = 0;
                    }
                    else
                    {
                        indexText++;
                    }

                    commonCounter++;
                }

                return decryptedText.ToString();
            }

            return encryptedText;
        }

        // Extracts first appearance of number starting from begining or end of a text
        private static string ExtractNumber(string text, Direction direction)
        {
            string number = string.Empty;
            int length;
            int index = 0;
            bool isValid;
            do
            {
                if (direction == Direction.FromEnd)
                {
                    isValid = int.TryParse(text[(text.Length - 1) - index++].ToString(CultureInfo.InvariantCulture), out length);
                    if (isValid)
                    {
                        number = length + number;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    isValid = int.TryParse(text[index++].ToString(CultureInfo.InvariantCulture), out length);
                    if (isValid)
                    {
                        number = number + length;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            while (isValid);

            return number;
        }

        // Decodes text, based on run-length encoding
        private static string Decode(string text)
        {
            StringBuilder result = new StringBuilder();
            int index = 0;
            while (index < text.Length)
            {
                if (char.IsDigit(text[index]))
                {
                    string number = ExtractNumber(text.Substring(index), Direction.FromStart);
                    int multiplier = int.Parse(number);
                    index += number.Length + 1;
                    result.Append(new string(text[index - 1], multiplier));
                }
                else
                {
                    result.Append(text[index]);
                    index++;
                }
            }

            return result.ToString();
        }
    }
}