using System;
using System.Text;

/// <summary>
/// Task: "7. Write a program that encodes and decodes a string using given encryption key (cipher). 
/// The key consists of a sequence of characters. The encoding/decoding is done by performing 
/// XOR (exclusive or) operation over the first letter of the string with the first of the key, 
/// the second – with the second, etc. When the last key character is reached, the next is the first."
/// </summary>
public class EncodeString
{
    public static void Main()
    {
        Console.Title = "Encode/Decode a string with cypher key";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter the text to be encoded: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string userInput = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter the encryption key: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string encryptionKey = Console.ReadLine();

        // Encodes/Decodes the message + Output to Console
        var encodedInput = Encode(userInput, encryptionKey);
        Console.WriteLine("Encrypted text: {0}", encodedInput);
        var decodedInput = Decode(encodedInput, encryptionKey);
        Console.WriteLine("Decrypted text: {0}", decodedInput);
    }

    // Encodes a text with cypher 
    private static string Encode(string text, string encryptionKey)
    {
        StringBuilder result = new StringBuilder(text.Length);
        int cypherIndex = 0;
        for (int index = 0; index < text.Length; index++)
        {
            result.Append((char)(text[index] ^ encryptionKey[cypherIndex]));
            if (index == encryptionKey.Length - 1)
            {
                cypherIndex = 0;
            }
        }

        return result.ToString();
    }

    // Decode encrypted text with same cypher
    private static string Decode(string text, string encryptionKey)
    {
        return Encode(text, encryptionKey);
    }
}