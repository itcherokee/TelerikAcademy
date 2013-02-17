using System;
using System.Collections.Generic;

public class LexicographicalArrayCompare
{
    // Write a program that compares two char arrays lexicographically (letter by letter).

    public static void Main()
    {
        Console.Title = "Compare two char arrays lexicographycaly";
        char[] arrayOne = new char[GetArraySize("first")];
        char[] arrayTwo = new char[GetArraySize("second")];
        int? shorterArray = null;
        shorterArray = arrayOne.Length < arrayTwo.Length ? arrayOne.Length : arrayTwo.Length;
        arrayOne = GetArrayContent("first", arrayOne.Length);
        arrayTwo = GetArrayContent("second", arrayTwo.Length);
        for (int index = 0; index < (shorterArray ?? arrayOne.Length); index++)
        {
            // compare letter by letter - if difference -> array with smaller letter wins
            if (arrayOne[index] < arrayTwo[index])
            {
                Console.WriteLine("First Array is lexicographicaly first.");
                Console.ReadLine();
                return;
            }
            else if (arrayOne[index] > arrayTwo[index])
            {
                Console.WriteLine("Second Array is lexicographicaly first.");
                Console.ReadLine();
                return;
            }
        }

        // if we are at last index and no diferences, we check length of arrays:
        //  - if equal -> both wins - else the smaller wins
        if (arrayOne.Length == arrayTwo.Length)
        {
            Console.WriteLine("Both arrays are lexicographically equal.");
        }
        else if (arrayOne.Length < arrayTwo.Length)
        {
            Console.WriteLine("First array is lexicographically the winner.");
        }
        else
        {
            Console.WriteLine("Second array is lexicographically the winner.");
        }
    }

    // Method for managing input of arrays sizes
    private static int GetArraySize(string arrayNum)
    {
        bool noError = false;
        byte arraySize = 0;
        do
        {
            Console.Write("Enter size of the {0} array: ", arrayNum);
            noError = byte.TryParse(Console.ReadLine(), out arraySize);
            if (!noError || arraySize == 0)
            {
                Console.WriteLine("incorrect size (probably symbol or 0 entered)!");
                Console.WriteLine("Try again <press Enter>...");
                Console.ReadLine();
                Console.Clear();
                noError = false;
            }
        } 
        while (!noError);
        return arraySize;
    }

    // Method for managing input of arrays elements (letters)
    private static char[] GetArrayContent(string arrayNum, int size)
    {
        char[] arrayOutput = new char[size];
        string lettersInput = string.Empty;
        bool noError = false;
        int counter = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Enter {0} array elements (letters) on one line without spaces: ", arrayNum);
            lettersInput = Console.ReadLine().ToUpper();

            for (int i = 0; i < lettersInput.Length; i++)
            {
                // check for reached length of array -> quit loop (the rest of the letters are ignored)
                if (counter == size)
                {
                    noError = true;
                    break;
                }

                if (lettersInput[i] < 'A' || lettersInput[i] > 'Z' || lettersInput[i] == ' ')
                {
                    Console.WriteLine("There was wrong input!");
                    Console.WriteLine("Try again <press Enter>...");
                    Console.ReadLine();
                    Console.Clear();
                    noError = false;
                    break;
                }
                else
                {
                    arrayOutput[counter] = Convert.ToChar(lettersInput[i]);
                    noError = true;
                    counter++;
                }
            }
        } 
        while (!noError);
        return arrayOutput;
    }
}