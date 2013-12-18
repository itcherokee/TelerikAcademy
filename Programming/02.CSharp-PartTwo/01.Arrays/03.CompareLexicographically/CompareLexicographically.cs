using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Task: "3. Write a program that compares two char arrays lexicographically (letter by letter)."
/// 
/// Rules:
/// - empty arrays -> no match possible 
/// - one array is empty -> winner (nothing is before anything)
/// - one array is shorter, but identical with first part of the other -> shorter wins
/// - one array is shorter, but identical with middle or end part of the longer, if longer first char is smaller -> longer wins; else shorter wins
/// - arrays are identical -> total equality, both wins
/// - arrays are different in one or more elements (could be equal or not in length) -> the one with first smaller element wins
/// 
/// Constraints:
/// - arrays should not be sorted within algorythm
/// - space is not considered as a char (at least in provided code) and will be removed from input
/// </summary>
public class CompareLexicographically
{
    public static void Main()
    {
        Console.Title = "Compare lexicographically two char arrays";
        char[] arrayOne = EnterElements("First");
        char[] arrayTwo = EnterElements("Second");
        bool isEqualLength = true;
        if (arrayOne.Length != arrayTwo.Length)
        {
            isEqualLength = false;
        }

        char[] shorterArray = arrayOne.Length < arrayTwo.Length ? arrayOne : arrayTwo;
        Console.ForegroundColor = ConsoleColor.Yellow;

        if (arrayOne.Length != 0 && arrayTwo.Length != 0)
        {
            // Compare elements of char array by using ASCII code of each one; if difference, select winner and exit the program
            for (int index = 0; index < shorterArray.Length; index++)
            {
                if ((int)arrayOne[index] < (int)arrayTwo[index])
                {
                    PrintWinner("First array wins!", arrayOne);
                    return;
                }
                else if ((int)arrayOne[index] > (int)arrayTwo[index])
                {
                    PrintWinner("Second array wins!", arrayTwo);
                    return;
                }
            }

            // both arrays are identical - check their length for selecting the winner
            if (isEqualLength)
            {
                PrintWinner("Both char arrays are winners!", arrayOne);
            }
            else if (arrayOne.Length < arrayTwo.Length)
            {
                PrintWinner("First char array wins!", arrayOne);
            }
            else
            {
                PrintWinner("Second char array wins!", arrayTwo);
            }
        }
        else
        {
            // both or one of the arrays are empty 
            if (isEqualLength)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Both arrays are empty, so there is no match possible!");
            }
            else if (arrayOne.Length == 0)
            {
                Console.WriteLine("First array is empty, so it is the winner!");
            }
            else
            {
                Console.WriteLine("Second array is empty, so it is the winner!");
            }
        }

        Console.ReadKey();
    }

    // Prints on the Console the winning array(s) message + array elements 
    private static void PrintWinner(string message, char[] winner)
    {
        Console.WriteLine("\n" + message);
        Console.Write("\nArray element(s): ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(string.Join(", ", winner));
    }

    // Manage the input of all char array elements in one line of Console
    private static char[] EnterElements(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the array elements on one line separated by space (space is ommited).\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("{0} char array element(s): ", message);
        Console.ForegroundColor = ConsoleColor.Yellow;

        // Next line read input from Console and removes any spaces inside the string
        string input = Console.ReadLine().Replace(" ", string.Empty);

        // Next line converts string array to char array by using lambda expression - select each char "x" 
        // in string which goes to new char array, which is then assigned to declared char array
        // It is like a short representation of "for" loop that enumerate each char in the string 
        // by index and assign it to char array element
        char[] array = input.Select(x => x).ToArray();
        Console.ForegroundColor = ConsoleColor.White;
        return array;
    }
}