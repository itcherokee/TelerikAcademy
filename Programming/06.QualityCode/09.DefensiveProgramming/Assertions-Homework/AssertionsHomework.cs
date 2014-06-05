﻿// Task 1:  Add assertions in the code from the project "Assertions-Homework" to ensure 
//          all possible preconditions and postconditions are checked.

namespace AssertionsHomework
{
    using System;

    public class AssertionsHomework
    {
        public static void Main()
        {
            int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            Sort.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            Sort.SelectionSort(new int[0]); // Test sorting empty array
            Sort.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(Search.BinarySearch(arr, -1000));
            Console.WriteLine(Search.BinarySearch(arr, 0));
            Console.WriteLine(Search.BinarySearch(arr, 17));
            Console.WriteLine(Search.BinarySearch(arr, 10));
            Console.WriteLine(Search.BinarySearch(arr, 1000));
        }
    }
}