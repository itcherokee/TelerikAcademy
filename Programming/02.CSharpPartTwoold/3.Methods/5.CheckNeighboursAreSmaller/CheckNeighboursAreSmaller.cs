using System;

public class CheckNeighboursAreSmaller
{
    // Write a method that checks if the element at given position in
    // given array of integers is bigger than its two neighbors (when such exist).

    public static void Main()
    {
        Console.Title = "Check element at position in array is bigger than direct neighbours.";
        Console.WriteLine("Enter sequence of numbers on one row separated by one space.");
        string[] tempArray = Console.ReadLine().Trim().Split();
        int[] enteredNumbers = new int[tempArray.Length];
        for (int i = 0; i < tempArray.Length; i++)
        {
            enteredNumbers[i] = int.Parse(tempArray[i]);
        }

        Console.Write("Enter the element's index to check it's value: ");
        int numberToCompare = int.Parse(Console.ReadLine());
        bool? evaluationResult = IsBigger(numberToCompare, enteredNumbers);
        if (evaluationResult.HasValue)
        {
            switch (evaluationResult.Value)
            {
                case true:
                    Console.WriteLine("Yes, the element at position {0} is bigger than it's neighbour(s).", numberToCompare);
                    break;
                case false:
                    Console.WriteLine("No, the element at position {0} is smaller than it's neighbour(s) or one of them.", numberToCompare);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Your sequence contains only one element or you have requested non existing index!");
        }
    }

    public static bool? IsBigger(int index, int[] array)
    {
        if ((array.Length != 1) && (index >= 0) && (index <= array.Length - 1))
        {
            if (index == 0)
            {
                // first element in array
                return array[index] > array[index + 1] ? true : false;
            }
            else if (index == array.Length - 1)
            {
                // last element in array
                return array[index] > array[index - 1] ? true : false;
            }
            else
            {
                // internal element in array
                return ((array[index] > array[index + 1]) && (array[index] > array[index - 1])) ? true : false;
            }
        }
        else
        {
            return null;
        }
    }
}
