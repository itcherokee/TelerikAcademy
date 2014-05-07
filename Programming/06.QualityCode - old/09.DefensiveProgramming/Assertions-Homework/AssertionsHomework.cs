// Add assertions in the code from the project "Assertions-Homework" to ensure 
// all possible preconditions and postconditions are checked.

namespace AssertionsHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null && arr.Length > 0, "Input array to be sort, can not be null or empty!");
            Debug.Assert(arr.Length != 1, "Input array to be sort is already sorted as contains only 1 element!");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "\"arr\" can not be null!");
            Debug.Assert(arr.Length > 0, "\"arr\" can not be empty!");
            Debug.Assert(value != null, "\"value\" can not be null!");

            int result = BinarySearch(arr, value, 0, arr.Length - 1);

            Debug.Assert(arr.Length > 0, "\"arr\" must not be empty!");

            return result;
        }

        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            SelectionSort(new int[0]); // Test sorting empty array
            SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "\"arr\" can not be null!");
            Debug.Assert(arr.Length > 0, "\"arr\" can not be empty!");
            Debug.Assert(value != null, "\"value\" can not be null!");
            Debug.Assert(startIndex < arr.Length, "StartIndex can not be bigger then the number of elements in array!");
            Debug.Assert(startIndex >= 0, "StartIndex can not be negative value!");
            Debug.Assert(endIndex < arr.Length, "EndIndex can not be bigger then the number of elements in array!");
            Debug.Assert(endIndex >= startIndex, "EndIndex can not be smaller then the startIndex!");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    Debug.Assert(midIndex < arr.Length, "midIndex can not be bigger then the number of elements in array!");
                    Debug.Assert(midIndex >= 0, "midIndex can not be negative value!");

                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    Debug.Assert(arr[midIndex].CompareTo(value) < 0, "Search is running in the right side of array, but should run in left side!");

                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    Debug.Assert(arr[midIndex].CompareTo(value) >= 0, "Search is running in the left side of array, but should run in right side!");

                    // Search on the left half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
        {
            Debug.Assert(arr != null || arr.Length > 0, "Input array, can not be null or empty!");
            Debug.Assert(startIndex < arr.Length, "StartIndex can not be bigger then the number of elements in array!");
            Debug.Assert(startIndex >= 0, "StartIndex can not be negative value!");
            Debug.Assert(endIndex < arr.Length, "EndIndex can not be bigger then the number of elements in array!");
            Debug.Assert(endIndex >= startIndex, "EndIndex can not be smaller then the startIndex!");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            Debug.Assert(minElementIndex >= 0, "minElementIndex can not be of negative value!");

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, "\"x\" reference can not be null!");
            Debug.Assert(y != null, "\"y\" reference can not be null!");

            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}