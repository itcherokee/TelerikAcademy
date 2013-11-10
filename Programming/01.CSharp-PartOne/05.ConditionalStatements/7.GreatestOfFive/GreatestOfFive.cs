using System;

/// <summary>
/// Task: "7. Write a program that finds the greatest of given 5 variables."
/// </summary>
public class GreatestOfFive
{
    public static void Main()
    {
        Console.Title = "Find the biggest of 5 numbers";
        Console.WriteLine("Enter five integers in one line separated by space.");
        Console.Write("Numbers: ");
        string[] numbersInput = Console.ReadLine().Split(' ');
        int[] numbers = new int[5];
        bool isValidInput = false;
        for (int i = 0; i <= numbers.Length - 1; i++)
        {
            isValidInput = int.TryParse(numbersInput[i], out numbers[i]);
            if (!isValidInput)
            {
                Console.WriteLine("You have entered invalid number or symbol. Press key to exit!");
                Console.ReadKey();
                return;
            }
        }

        // Using method of comparing element by element
        int flag = numbers[0];
        for (int i = 1; i <= numbers.Length - 1; i++)
        {
            if (flag < numbers[i])
            {
                flag = numbers[i];
            }
        }

        Console.WriteLine("By using comapare element-by-element, the greatest number is {0}", flag);

        // Using Array.Sort to find greatest number
        Array.Sort(numbers);
        Console.WriteLine("By using Array.Sort, the greatest number is {0}", numbers[numbers.Length - 1]);
        Console.ReadKey();
    }
}