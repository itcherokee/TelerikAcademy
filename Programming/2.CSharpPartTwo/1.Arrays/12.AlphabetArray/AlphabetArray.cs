using System;

public class AlphabetArray
{
    // Write a program that creates an array containing all letters from the alphabet (A-Z). 
    // Read a word from the console and print the index of each of its letters in the array.

    public static void Main()
    {
        char[] alphabet = new char[26];
        for (int count = 0; count < 26; count++)
        {
            alphabet[count] = (char)(65 + count);
        }

        Console.Write("Enter a word: ");
        string enteredWord = Console.ReadLine().ToUpper();
        Console.WriteLine("Letter Index");
        for (int count = 0; count < enteredWord.Length; count++)
        {
            Console.WriteLine("{0,3}{1,8}", enteredWord[count], Array.BinarySearch(alphabet, enteredWord[count]));
        }
    }
}
