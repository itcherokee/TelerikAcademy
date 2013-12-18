//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

///// <summary>
///// Task: "Write a program that finds the sequence of maximal sum in given array. 
///// Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
///// Can you do it with only one loop (with single scan through the elements of the array)?"
///// </summary>
//public class SequenceOfMaxSum
//{
//    public static void Main()
//    {
//        Console.Title = "Find sequence of maximal sum in array";
//        int[] arrayOfNumbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
//        //  int[] arrayOfNumbers = { -2, -3, -3, -9, -7, -12, -1, -5, -4, 1 };
//        // int[] arrayOfNumbers = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
//        //int[] arrayOfNumbers = { 23, 4, -4, -65, 3 };


//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.Write("Array: ");
//        Console.ForegroundColor = ConsoleColor.Yellow;

//        // Console print of entered array on console
//        Console.WriteLine(string.Join(",", arrayOfNumbers.Select(x => x.ToString()).ToArray()));

//        bool isAllNegative = true;
//        int finalSum = arrayOfNumbers[0];
//        int finalStartIndex = 0;
//        int finalElelementCount = 0;
//        int currentStartIndex = 0;
//        int currentCountElelemnts = 1;
//        int smallest = int.MinValue;
//        int currentSum = arrayOfNumbers[0];
//        for (int index = 1; index < arrayOfNumbers.Length; index++)
//        {
//            // check does all numbers are negative
//            //if (arrayOfNumbers[index] > 0)
//            //{
//            //    isAllNegative = false;
//            //}
//            //else if (isAllNegative && smallest < arrayOfNumbers[index])
//            //{
//            //    smallest = arrayOfNumbers[index];
//            //}

//            if (currentSum + arrayOfNumbers[index] < arrayOfNumbers[index])
//            {
//                currentSum = arrayOfNumbers[index];
//                currentStartIndex = index;
//                currentCountElelemnts = 1;
//            }
//            else
//            {
//                currentSum = currentSum + arrayOfNumbers[index];
//                currentCountElelemnts++;
//            }

//            if (finalSum < currentSum)
//            {
//                finalSum = currentSum;
//            }
//            //    if (currentSum == 0)
//            //    {
//            //        currentStartIndex = index;
//            //    }

//            //    currentSum = currentSum + arrayOfNumbers[index];
//            //    currentCountElelemnts++;
//            //}
//            //else
//            //{
//            //    currentSum = 0;
//            //    currentCountElelemnts = 0;
//            //}

//            //if (currentSum > finalSum)
//            //{
//            //    finalSum = currentSum;
//            //    finalStartIndex = currentStartIndex;
//            //    finalElelementCount = currentCountElelemnts;
//            //}
//        }

//        // Output result to the Console
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.Write("\nThe maximal sum in given array is: ");
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        //if (isAllNegative)
//        //{
//        //    Console.WriteLine(smallest);
//        //}
//        //else
//        //{
//        Console.WriteLine(finalSum);
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.Write("Sequence is: ");
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine(string.Join(",", arrayOfNumbers.Select(x => x.ToString()).ToArray(), currentStartIndex, currentCountElelemnts));
//        //}

//        Console.ReadKey();
//    }
//}