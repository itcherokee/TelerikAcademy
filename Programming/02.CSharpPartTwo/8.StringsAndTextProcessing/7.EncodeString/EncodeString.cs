using System;
using System.Text;

public class EncodeString
{
    // Write a program that encodes and decodes a string using given encryption key (cipher). 
    // The key consists of a sequence of characters. The encoding/decoding is done by 
    // performing XOR (exclusive or) operation over the first letter of the string with 
    // the first of the key, the second – with the second, etc. When the last key character 
    // is reached, the next is the first.

    public static void Main()
    {
        Console.Title = "Encode/Decode a string with cypher key";
        Console.Write("Enter the text to be encoded: ");
        string userInput = Console.ReadLine();
        Console.Write("Enter the encryption key: ");
        string encryptKey = Console.ReadLine();
        userInput = Crypt(userInput, encryptKey);
        Console.WriteLine("Encrypted text: {0}", userInput);
        userInput = Crypt(userInput, encryptKey);
        Console.WriteLine("Decrypted text: {0}", userInput);
    }

    private static string Crypt(string text, string encryptKey)
    {
        StringBuilder result = new StringBuilder(text.Length);
        int cypherIndex = 0;
        for (int index = 0; index < text.Length; index++)
        {
            result.Append((char)(text[index] ^ encryptKey[cypherIndex]));
            if (index == encryptKey.Length - 1)
            {
                cypherIndex = 0;
            }
        }

        return result.ToString();
    }
}