namespace IEnumerableExt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Test
    {
        static void Main(string[] args)
        {
            // Tests IEnumerable<T>'s extension methods - Task 2
            Console.WriteLine("\n" + new string('-', 50) + "\nTests IEnumerable<T>'s extension methods - Task 2\n" + new string('-', 50));

            List<int> enumerable = new List<int>() { 2, 3, 8, 6, 7, 5 };
            List<string> a = new List<string>() { "a" };
            Console.WriteLine("Elements: " + string.Join(", ", enumerable));

            // Sum
            Console.WriteLine("Sum of all elements is: {0}", enumerable.sum());

            // Product
            Console.WriteLine("Product of all elements is: {0}", enumerable.product());

            // Average
            Console.WriteLine("Average of all elements is: {0}", enumerable.average());

            // Min & Max  - works with dates as well
            Console.WriteLine("Min element is: {0}", enumerable.min());
            Console.WriteLine("Max element is: {0}", enumerable.max());
            List<DateTime> enumerableDate = new List<DateTime>() 
                            { new DateTime(1099, 1, 21), 
                              new DateTime(2000, 12, 31), 
                              new DateTime(1000, 2, 2) };
            Console.WriteLine("Dates are: \n\t" + string.Join("\n\t", enumerableDate));
            Console.WriteLine("Min Date is: {0}", enumerableDate.min());
            Console.WriteLine("Max Date is: {0}", enumerableDate.max());
        }
    }
}
