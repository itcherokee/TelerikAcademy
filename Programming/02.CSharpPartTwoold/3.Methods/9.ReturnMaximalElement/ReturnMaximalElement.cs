using System;

public class ReturnMaximalElement
{
    // Write a method that return the maximal element in a portion of array 
    // of integers starting at given index. Using it write another method 
    // that sorts an array in ascending / descending order.

    public static void Main()
    {
        //int[] arrayOfNumbers = { 8, 9, 4, 5, 77, 32, 687, 2, 56, 8, 9, 12, 56, 3, 0, 23 };
        int[] arrayOfNumbers = { 0, 0, 0, 3, 3, 3, 3, 2, 2, 2, 2, 6, 6, 6, 7, 9, 900, 0, 0 };
        bool noError = false;
        int userInput = 0;

        // find maximal element
        do
        {
            Console.Write("Select starting index to search for Max element in array: ");
            noError = int.TryParse(Console.ReadLine(), out userInput);
            if ((!noError) || (userInput < 0) || (userInput > arrayOfNumbers.Length - 1))
            {
                noError = ReportError(noError);
            }
        } 
        while (!noError);
        Console.WriteLine("In selected range the maximal number is {0}.", FindMaximal(arrayOfNumbers, userInput));

        // sorting the array
        do
        {
            Console.Write("Choose how to sort the array (1 - ascending; 2 - descending): ");
            noError = int.TryParse(Console.ReadLine(), out userInput);
            if ((!noError) || (userInput < 1) || (userInput > 2))
            {
                noError = ReportError(noError);
            }
        } 
        while (!noError);
        bool selectedOrder = userInput == 1 ? true : false;
        SortArray(ref arrayOfNumbers, selectedOrder);
        Console.WriteLine("Sorted array in {0} order:", selectedOrder ? "ascending" : "descending");
        foreach (var element in arrayOfNumbers)
        {
            Console.Write(element + " ");
        }

        Console.WriteLine();
    }

    public static int FindMaximal(int[] numbers, int startIndex)
    {
        int biggestNumber = numbers[startIndex];
        int biggestNumberIndex = startIndex;
        for (int index = startIndex; index < numbers.Length; index++)
        {
            if (numbers[index] >= biggestNumber)
            {
                biggestNumber = numbers[index];
                biggestNumberIndex = index;
            }
        }

        return biggestNumber;
    }

    public static void SortArray(ref int[] numbers, bool sortDirection)
    {
        int count = 0;
        int[] tempArray = new int[numbers.Length];
        int biggestIndex = 0;
        while (count < numbers.Length)
        {
            biggestIndex = Array.IndexOf(numbers, FindMaximal(numbers, 0));
            switch (sortDirection)
            {
                // ascending 
                case true:
                    tempArray[numbers.Length - 1 - count] = numbers[biggestIndex];
                    numbers[biggestIndex] = int.MinValue;
                    break;
                // descending
                case false:
                    tempArray[count] = numbers[biggestIndex];
                    numbers[biggestIndex] = int.MinValue;
                    break;
            }

            count++;
        }

        numbers = tempArray;
    }

    // method used to report user input error
    private static bool ReportError(bool noError)
    {
        Console.WriteLine("Wrong selection detected!");
        Console.WriteLine("Try again <press Enter>...");
        Console.ReadLine();
        Console.Clear();
        return false;
    }
}