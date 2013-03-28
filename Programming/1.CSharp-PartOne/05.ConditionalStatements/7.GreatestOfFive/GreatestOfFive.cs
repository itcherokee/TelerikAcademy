using System;

class GreatestOfFive
{
    static void Main()
    {
        //Write a program that finds the greatest of given 5 variables.

        int[] numbers = new int[5];
        int[] numbersArraySort = new int[5];
        //int[] numbersSortedForCycle = new int[5];
        Console.Title = "Find the biggest of 5 numbers";
        Console.WriteLine("Enter five integers in one line splited by space.");
        Console.Write("Numbers: ");

        string[] numbersInput = Console.ReadLine().Split(' ');
        bool noError = false;
        for (int i = 0; i <= numbers.Length - 1; i++)
        {
            noError = int.TryParse(numbersInput[i], out numbers[i]);
            if (!noError)
            {
                Console.WriteLine("You have entered invalid number or symbol. Press key to exit!");
                Console.ReadKey();
                return;
            }
        }
        for (int i = 0; i <= numbers.Length - 1; i++)
        {
            numbersArraySort[i] = numbers[i];
        }
        Array.Sort(numbersArraySort);
        Console.WriteLine("By using Array.Sort, the greatest number is {0}", numbersArraySort[numbersArraySort.Length - 1]);
        int flag = numbers[0];
        for (int i = 1; i <= numbers.Length - 1; i++)
        {
            if (flag < numbers[i])
            {
                flag = numbers[i];
            }
        }
        Console.WriteLine("By using comapare element-by-element, the greatest number is {0}", flag);
        Console.ReadKey();
    }
}