using System;
using System.Linq;

/// <summary>
/// Task: "Write a program that finds the maximal increasing sequence in an array. 
/// Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}."
/// 
/// Rules:
/// - Only integers are accepted as input
/// - If there are no increasing sequence -> no winner
/// - If there are more than one sequence with the same length -> first one is considered (second/third/... is(are) ignored)
/// - The increasing step is 1
/// 
/// Boundary cases:
/// - Checks for empty array (empty input)
/// - If only one element is entered
/// - If two/three/four/... different elements are entered
/// 
/// </summary>
public class MaximalIncreasingSequence
{
    public static void Main()
    {
        Console.Title = "Maximal increasing sequence of numbers.";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter the array elements (integers) on one line separated by space.\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Array elements: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (input.Length != 0)
        {
            // convert to integer array the input
            int[] elements = new int[input.Length];
            bool isValidInput = true;
            for (int index = 0; index < input.Length; index++)
            {
                isValidInput = int.TryParse(input[index], out elements[index]);
                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input detected! Program will exit...");
                    return;
                }
            }

            int highSequenceLength = default(int);
            int highSequenceStartIndex = default(int);
            int currentElement = elements[0];
            bool isThereSequence = false;
            int currentSequenceSartIndex = 0;
            int currentSequenceLength = 1;
            for (int index = 1; index < elements.Length; index++)
            {
                if (currentElement + 1 == elements[index])
                {
                    // increasing sequence discovered
                    currentSequenceLength++;
                    isThereSequence = true;
                    currentElement = elements[index];
                }
                else
                {
                    if (highSequenceLength < currentSequenceLength)
                    {
                        highSequenceLength = currentSequenceLength;
                        highSequenceStartIndex = currentSequenceSartIndex;
                    }

                    currentElement = elements[index];
                    currentSequenceLength = 1;
                    currentSequenceSartIndex = index;
                }

                // handles if index is last one and we are still within increasing sequence
                if (index == elements.Length - 1 && highSequenceLength < currentSequenceLength)
                {
                    highSequenceLength = currentSequenceLength;
                    highSequenceStartIndex = currentSequenceSartIndex;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("There is {0}increasing sequence detected!", isThereSequence ? string.Empty : "NO ");
            if (isThereSequence)
            {
                Console.Write("Sequence: ");
                Console.ForegroundColor = ConsoleColor.Green;

                // On next line the extension method "Select" is acting like "for" loop over array's elements and converting 
                // each int element to String, than ToArray() produce a temp array of strings (comming from "Select") which is passed
                // to string.Join and after that we print (join) only elements which are part of increasing sequence.
                Console.WriteLine(string.Join(",", elements.Select(x => x.ToString()).ToArray(), highSequenceStartIndex, highSequenceLength));
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