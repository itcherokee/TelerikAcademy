using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Task: "4. Write a program that finds the maximal sequence of equal elements in an array.
/// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}."
/// 
/// Boundary cases:
/// - Checks for empty array (empty input)
/// - If only one element is entered
/// - If two/three/four/... different elements are entered
/// - Handles any kind of elements, not only integers as well as different length of elements - via string array
/// 
/// </summary>
public class MaximalSequence
{
    public static void Main()
    {
        Console.Title = "Maximal sequence of equal elements.";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the array elements on one line separated by space (space is ommited).\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array elements: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] elementArray = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (elementArray.Length != 0)
        {
            bool isThereEqualElements = false;
            int highCount = 1;
            int currentCount = 1;
            string highElement = elementArray[0];
            string currentElement = elementArray[0];
            for (int i = 1; i < elementArray.Length; i++)
            {
                if (elementArray[i].Equals(currentElement))
                {
                    currentCount++;
                    isThereEqualElements = true;
                }
                else
                {
                    if (currentCount > highCount)
                    {
                        highCount = currentCount;
                        highElement = currentElement;
                    }

                    currentCount = 1;
                    currentElement = elementArray[i];
                }
            }

            if (isThereEqualElements)
            {
                // There are at least two equal elements
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("The maximal sequence is: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int index = 0; index < highCount; index++)
                {
                    Console.Write("{0}{1} ", highElement, index != highCount - 1 ? "," : "\n");
                }
            }
            else
            {
                // Array is not empty, but there is no any sequence of equal elements
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("There is no sequence of equal elements at all in that array!");
            }
        }
        else
        {
            // Empty array detected
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No elements in the array! Program will exit now...");
        }
    }
}