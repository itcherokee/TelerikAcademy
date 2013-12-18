using System;

/// <summary>
/// Task: "2. Write a program that reads two arrays from the console 
/// and compares them element by element."
/// </summary>
public class CompareTwoArrays
{
    public static void Main()
    {
        Console.Title = "Compare two arrays";
        Console.ForegroundColor = ConsoleColor.White;
        int arrayLength = EnterData("Enter the size of the arrays: ");
        string[] arrayOne = EnterElements("First");
        string[] arrayTwo = EnterElements("Second");

        // Check does length of the both arrays differ each other
        if (arrayOne.Length != arrayTwo.Length)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Number of elements in one of the arrays is less than elements in other one!");
            Console.WriteLine("Program will exit...");
            Console.ReadKey();
            return;
        }

        bool isIdentical = true;
        int indexPosition = 0;
        for (int index = 0; index < arrayOne.Length; index++)
        {
            if (arrayOne[index] != arrayTwo[index])
            {
                isIdentical = false;
                indexPosition = index;
                break;
            }
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nArrays are {0}identical!", isIdentical ? string.Empty : "NOT ");
        Console.WriteLine("Position of first elements that are not identical is {0}", indexPosition);
    }

    // Manage the input of all array elements in one line of Console
    private static string[] EnterElements(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the array elements on one line separated by space (space is ommited).\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("{0} array elements: ", message);
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] elementArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.ForegroundColor = ConsoleColor.White;
        return elementArray;
    }

    // Manage the input of single value from Console
    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}