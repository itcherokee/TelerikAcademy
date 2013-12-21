using System;
using System.Collections.Generic;

/// <summary>
/// Task: "19. * Write a program that reads a number N and generates and prints 
/// all the permutations of the numbers [1 … N]. 
/// 
/// Example: n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}"
/// </summary>
public class Permutations
{
    public static void Main()
    {
        Console.Title = "Print all combinations of K elements from set [1..N].";
        int upperBound = EnterData("Enter upper bound of set [1..(N)]: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nAll possible permutations follow...");
        Console.ForegroundColor = ConsoleColor.Green;

        // Start constructing one by one of all possible permutations.
        for (int index = 1; index <= upperBound; index++)
        {
            var permutation = new List<int>();
            permutation.Add(index);
            Permutate(permutation, upperBound);
        }

        Console.WriteLine();
        Console.ReadKey();
    }

    /// <summary>
    /// Calculating permutation by permutation.
    /// </summary>
    /// <param name="permutation">An array holding current permutation under construction.</param>
    /// <param name="size">The upper bound of range with numbers for permutations.</param>
    private static void Permutate(List<int> permutation, int size)
    {
        // When size of current array holding permutation under construction reach the upped bound of number's range we set,
        // we are ready with current permutaion and output it to Console without keeping it in another array.
        // After that we return from current recursion level one step back and start the construction of next permutation.
        if (permutation.Count == size)
        {
            Print(permutation);
            return;
        }

        for (int number = 1; number <= size; number++)
        {
            // Check does current number has been used already in the current constructing permutation record
            bool sameNumberFound = false;
            for (int index = 0; index < permutation.Count; index++)
            {
                if (number == permutation[index])
                {
                    // already used number in single permutation found, so we skip it
                    sameNumberFound = true;
                    break;
                }
            }

            // If current number is not found to be used up to now, we add it the to current permutation
            // and continue digging by calling the same method (recursivly)
            if (!sameNumberFound)
            {
                var onePermutation = new List<int>(permutation);
                onePermutation.Add(number);
                Permutate(onePermutation, size);
            }
        }
    }

    /// <summary>
    /// Output to Console single ready permutation.
    /// </summary>
    /// <param name="singleReadyPermutation">An array containg ordered finalized permutation to be printed.</param>
    private static void Print(IEnumerable<int> singleReadyPermutation)
    {
        Console.Write("{" + string.Join(",", singleReadyPermutation) + "} ");
    }

    // Handles user input
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
