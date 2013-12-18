using System;
using System.Collections.Generic;

/// <summary>
/// Task: "Write a program that reads two integer numbers N and K and an array of N elements 
/// from the console. Find in the array those K elements that have maximal sum."
/// 
/// Boarder cases:
/// - number of K elements is bigger than size of array.
/// - number of K elements is equal to array size -> sum includes all elements.
/// - K is equal to 0 -> no calculation possible;
/// - more elements are entered than array size -> only first "N" elements are taken, the rest are are ommited
/// </summary>
public class MaximalSum
{
    public static void Main()
    {
        Console.Title = "Find out maximal sum of K elements";
        int size = EnterData("Please, enter the count of array elements (N): ");
        int numberOfSumElements = EnterData("Please, enter the count of elements to look for maximal sum (K): ");
        int[] elements = new int[size];
        if (numberOfSumElements > size || numberOfSumElements == 0)
        {
            if (numberOfSumElements != 0)
            {
                Terminate("Count of elements to look for maximal sum is bigger than array's size!");
            }
            else
            {
                Terminate("Count of elements to look for maximal sum is 0! No calulation possible.");
            }
        }
        else
        {
            string[] tempArray = EnterElements();
            if (tempArray.Length >= size)
            {
                // Next line is List, but with a structure known as key/value pair elements 
                // (here is used as: array_element_value/position_in_array) - Dictionary<int,int> could be used as well.
                List<KeyValuePair<int, int>> sumElements = new List<KeyValuePair<int, int>>();
                for (int index = 0; index < size; index++)
                {
                    // Next line sort the List by specifying (using lambda expression) to do the sort by Key
                    // SortedDictionary<int,int> will do the job automatically as well
                    sumElements.Sort((elementA, elementB) => elementA.Key.CompareTo(elementB.Key));
                    if (int.TryParse(tempArray[index], out elements[index]))
                    {
                        if (index <= numberOfSumElements - 1)
                        {
                            sumElements.Add(new KeyValuePair<int, int>(elements[index], index));
                        }
                        else
                        {
                            if (elements[index] > sumElements[0].Key)
                            {
                                sumElements.Add(new KeyValuePair<int, int>(elements[index], index));
                                sumElements.RemoveAt(0);
                            }
                        }
                    }
                    else
                    {
                        Terminate("Invalid array elements detected!");
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The elements that calculate maximal sum ({0} out of {1}) are:", numberOfSumElements, size);
                int totalSum = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                for (int index = 0; index < sumElements.Count; index++)
                {
                    Console.Write("{0} (at index {1})", sumElements[index].Key, sumElements[index].Value);
                    if (index < sumElements.Count - 1)
                    {
                        Console.Write(", ");
                    }

                    totalSum += (int)sumElements[index].Key;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nTotal SUM is: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(totalSum);
            }
            else
            {
                Terminate(string.Format("Empty or not full array (N={0}) of elements detected!", size));
            }
        }
    }

    private static void Terminate(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.WriteLine("Program will exit...");
        Console.ReadKey();
        Environment.Exit(0);
    }

    // Manage the input of single value with validation for integer (common routine used in many projects)
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

    // Manage the input of all array elements in one line on Console (common routine used in many projects)
    private static string[] EnterElements()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the array elements on one line separated by space .\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array elements: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.ForegroundColor = ConsoleColor.White;
        return array;
    }
}