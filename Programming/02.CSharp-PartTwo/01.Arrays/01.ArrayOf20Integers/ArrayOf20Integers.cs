using System;

/// <summary>
/// Task: "Write a program that allocates array of 20 integers and initializes each element 
/// by its index multiplied by 5. Print the obtained array on the console."
/// </summary>
public class ArrayOf20Integers
{
    public static void Main()
    {
        Console.Title = "Array of 20 integers with value = index * 5";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Initial value of array elements:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        int[] numbers = new int[20];
        Console.WriteLine(string.Join(", ", numbers));
        for (int index = 0; index < numbers.Length; index++)
        {
            numbers[index] = index * 5;
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nArray elements' index multiplied by 5 and assigned to each:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(string.Join(", ", numbers));
        Console.ReadKey();
    }
}