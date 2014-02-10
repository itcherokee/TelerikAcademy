namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;

    public class Test
    {
        public static void Main(string[] args)
        {
            // Tests IEnumerable<T>'s extension methods - Task 2
            Console.WriteLine("\n" + new string('-', 50) + "\nTests IEnumerable<T>'s extension methods - Task 2\n" + new string('-', 50));

            List<int> enumerable = new List<int>() { 2, 3, 8, 6, 7, 5 };
            List<string> a = new List<string>() { "a" };
            Console.WriteLine("Elements: " + string.Join(", ", enumerable));

            // Sum
            Console.WriteLine("Sum of all elements is: {0}", enumerable.Sum());

            // Product
            Console.WriteLine("Product of all elements is: {0}", enumerable.Product());

            // Average
            Console.WriteLine("Average of all elements is: {0}", enumerable.Average());

            // Min & Max  - works with dates as well
            Console.WriteLine("Min element is: {0}", enumerable.Min());
            Console.WriteLine("Max element is: {0}", enumerable.Max());
            var enumerableDate = new List<DateTime>() 
                            { 
                                new DateTime(1099, 1, 21), 
                                new DateTime(2000, 12, 31), 
                                new DateTime(1000, 2, 2) 
                            };
            Console.WriteLine("Dates are: \n\t" + string.Join("\n\t", enumerableDate));
            Console.WriteLine("Min Date is: {0}", enumerableDate.Min());
            Console.WriteLine("Max Date is: {0}", enumerableDate.Max());
        }
    }
}
