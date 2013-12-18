//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

///// <summary>
///// Task: "Write a program that sorts an array of strings using the quick sort algorithm."
///// </summary>
//public class QuickSort
//{
//    public static void Main()
//    {
//        string[] values = { "2", "5", "6", "54", "0", "4" };

//    }

//    public static void Sort(int[] numbers, int left, int right)
//    {
//        // ако списъкът има два или повече елемента
//        if (left < right)
//        {
//            // Вижте секцията "Избор на главен елемент" по-долу за възможните варианти
//            // choose any pivotIndex such that left ≤ pivotIndex ≤ right
//            int pivot = 0;

//            // Намерете списъците с по-малките и по-големите елементи, както и позицията на избрания главен елемент
//            int newPivot = Partition(numbers, left, right, pivot);

//            // Рекурсивно сортирайте елементите, по-малки от главния елемент
//            Sort(numbers, left, newPivot - 1);

//            // Рекурсивно сортирайте елементите, по-малки или равни на главния елемент
//            Sort(numbers, newPivot + 1, right);
//        }
//    }

//    public static int Partition(int[] numbers, int left, int right, int pivot)
//    {
//        int pivotElement = numbers[pivot];
//        numbers[pivot] ^= numbers[right];
//        numbers[right] ^= numbers[pivot];
//        numbers[pivot] ^= numbers[right];
//        int storeIndex = left;
//        for (int i = left; i < right - 1; i++)
//        {
//            if (numbers[i] < pivotElement)
//            {
//                numbers[i] ^= numbers[storeIndex];
//                numbers[storeIndex] ^= numbers[i];
//                numbers[i] ^= numbers[storeIndex];
//                storeIndex++;
//            }
//        }

//        numbers[storeIndex] ^= numbers[right];
//        numbers[right] ^= numbers[storeIndex];
//        numbers[storeIndex] ^= numbers[right];
//        return storeIndex;
//    }
//}