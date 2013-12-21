using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Task: "10. Write a program that finds in given array of integers a sequence of given sum S (if present). 
/// Example: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}"
/// 
/// Constraints:
/// - first (left-to-right) sequence is outputed as discovery (could be longer than later one).
/// - zero as element in the array -> is considered part of the sequence if it is in the middle of sequence
/// - zero as element in the array -> is considered out of the sequence if it is at the begining or end of the sequence
/// 
/// Border cases:
/// - empty array
/// - only one element in the array
/// - one item of many in array that is equal to Sum
/// - sum of all elements of the array is Sum
/// - no elements sequence is equal to Sum
/// </summary>
public class SequenceOfSum
{
    public static void Main()
    {
        Console.Title = "A sequence of integers in array equal to given Sum";
        int sum = EnterData("What is the value of the Sum to be searched: ");

        // User input is converted to int array by using lambda expression - simplify by skipping FOR loops
        // The expression: "x => int.Parse(x)", could be also replaced by just "int.Parse", but current one
        // is more readable; This is not the best solution as we do not do checks for wrong data input, 
        // but I thought that might be interested.
        int[] numbers = EnterElements().Select(x => int.Parse(x)).ToArray();
        int currentSum = 0;
        int start = 0;
        int end = 0;
        for (int outer = 0; outer < numbers.Length; outer++)
        {
            // skip loop iteration if starting elelemnt is 0
            if (numbers[outer] == 0)
            {
                continue;
            }

            currentSum = numbers[outer];

            // handles if only a single element is equal to Sum
            if (currentSum == sum)
            {
                start = outer;
                end = outer;
                string subRange = string.Join(",", numbers.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray(), start, end - start + 1);
                PrintFinalResult(string.Format("The sequence of elements equal to Sum ({0}) is {1}", sum, subRange));
            }

            for (int inner = outer + 1; inner < numbers.Length; inner++)
            {
                currentSum += numbers[inner];

                // checks unnecessary elements that summed are equal to 0 - search for shorter sequence
                if (currentSum == 0)
                {
                    currentSum -= numbers[inner];
                    break;
                }

                if (currentSum == sum)
                {
                    start = outer;
                    end = inner;
                    string subRange = string.Join(",", numbers.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray(), start, end - start + 1);
                    PrintFinalResult(string.Format("The sequence of elements equal to Sum ({0}) is {1}", sum, subRange));
                }
            }
        }

        // Handles no available sequence of elements in array forming the Sum
        PrintFinalResult(string.Format("There is no sequence of elements forming the Sum ({0})!", sum));
    }

    // Prints result to the console
    private static void PrintFinalResult(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ReadKey();
        Environment.Exit(0);
    }

    // Manage the input of all array elements in one line on Console
    private static string[] EnterElements()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the array elements on one line separated by space (space is ommited).\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array elements: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.ForegroundColor = ConsoleColor.White;
        return array;
    }

    // Manage the input of single value from Console (in that case the SUM)
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