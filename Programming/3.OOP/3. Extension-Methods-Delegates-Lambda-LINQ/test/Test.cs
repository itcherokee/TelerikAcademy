namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using StringBuilderExt;
    using IEnumerableExt;

    class Test
    {
        static void Main(string[] args)
        {
            #region SubString
            // Tests StringBuilder's extension methods - Task 1
            StringBuilder test = new StringBuilder("Ala bala nica");
            Console.WriteLine("Substring 1: {0}", test.SubString(9, 4));
            Console.WriteLine("Substring 2: {0}", test.SubString(4));
            #endregion

            #region IEnumerable<T>
            // Tests IEnumerable<T>'s extension methods - Task 2

            List<int> enumerable = new List<int>();
            enumerable.Add(2);
            enumerable.Add(3);

            // Sum
            Console.WriteLine("Sum of all elements is: {0}", enumerable.sum());

            // Product
            Console.WriteLine("Product of all elements is: {0}", enumerable.product());

            // Average
            Console.WriteLine("Average of all elements is: {0}", enumerable.average());

            // Min & Max  - working with dates as well
            Console.WriteLine("Min element is: {0}", enumerable.min());
            Console.WriteLine("Max element is: {0}", enumerable.max());
            List<DateTime> enumerableDate = new List<DateTime>();
            enumerableDate.Add(new DateTime(1999, 1, 1));
            enumerableDate.Add(new DateTime(2000, 2, 2));
            enumerableDate.Add(new DateTime(1000, 2, 2));
            Console.WriteLine("Min Date is: {0}", enumerableDate.min());
            Console.WriteLine("Max Date is: {0}", enumerableDate.max());
            
            #endregion

            #region

            #endregion

        }
    }
}
