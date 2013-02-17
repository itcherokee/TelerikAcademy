using System;

public class ReturnIndexIfBiggerNeighbour
{
    // Write a method that returns the index of the first element in array that 
    // is bigger than its neighbors, or -1, if there’s no such element.
    // Use the method from the previous exercise.

    public static void Main()
    {
        Console.Title = "Find first bigger element than it's neighbours.";
        Console.WriteLine("Enter sequence of numbers on one row separated by one space.");
        string[] tempArray = Console.ReadLine().Trim().Split();
        int[] enteredNumbers = new int[tempArray.Length];
        for (int i = 0; i < tempArray.Length; i++)
        {
            enteredNumbers[i] = int.Parse(tempArray[i]);
        }

        int elementIndex = FirstBigger(enteredNumbers);
        if (elementIndex != -1)
        {
            Console.WriteLine("The first bigger element than it's neighbours is at the index position {0} (number {1}).", elementIndex, enteredNumbers[elementIndex]);
        }
        else
        {
            Console.WriteLine("There is no element that is bigger than it's neighbours!");
        }
    }

    public static int FirstBigger(int[] array)
    {
        if (array.Length != 1)
        {
            for (int index = 0; index < array.Length; index++)
            {
                if ((index != 0 && index != array.Length - 1) && (array[index] > array[index - 1] && array[index] > array[index + 1]))
                {
                    return index;
                }

                if ((index == 0 && array[index] > array[index + 1]) || (index == array.Length - 1 && array[index] > array[index - 1]))
                {
                    return index;
                }
            }
        }

        return -1;
    }
}
