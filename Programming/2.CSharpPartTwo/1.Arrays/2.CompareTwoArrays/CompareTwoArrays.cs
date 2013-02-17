using System;

public class CompareTwoArrays
{
    public static void Main()
    {
        // Write a program that reads two arrays from the console and compares them element by element.

        Console.Title = "Compare two arrays for equality";
        Console.WriteLine("Array 1 - Enter values on one line separated by space: ");
        string[] arrayOne = Console.ReadLine().Trim().Split();
        Console.WriteLine("Array 2 - Enter values on one line separated by space: ");
        string[] arrayTwo = Console.ReadLine().Trim().Split();

        // check length of both arrays for equality
        if (arrayOne.Length != arrayTwo.Length)
        {
            Console.WriteLine("Your arrays are with different sizes, so they can not be equal!");
        }
        else
        {
            bool[] equalArrays = new bool[arrayOne.Length];

            // prepare graphical output
            Console.WriteLine("{0,10}{1,10}{2,10}", "Array 1", "Array 2", "Equal?");
            Console.WriteLine(new string('-', 30));

            // check element by element and print on screen the result
            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    equalArrays[i] = true;
                }

                Console.WriteLine("{0,8}{1,10}{2,11}", arrayOne[i], arrayTwo[i], equalArrays[i] ? "Yes" : "No");
            }
        }
    }
}
