// Task 2:  Implement a set of extension methods for IEnumerable<T> that implement the following 
//          group functions: sum, product, min, max, average.

namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableUtils
    {
        /// <summary>
        /// Calculates the sum of the elements in collection
        /// </summary>
        /// <typeparam name="T">Type parameter of the elements</typeparam>
        /// <param name="input">Parameter holding the reference to the element's type</param>
        /// <returns>Sum of the collection elements values. If type parameter is DateTime or collection is empty, returns default(T)</returns>
        public static T Sum<T>(this IEnumerable<T> input) where T : struct
        {
            // checks for empty collection
            if (input != null)
            {
                // Checks for DateTime type. If it's DateTime, returns default value for DateTime (01/01/00 00:00:00)
                if (typeof(T) != typeof(DateTime))
                {
                    T sumValue = default(T);
                    foreach (var item in input)
                    {
                        sumValue = sumValue + (dynamic)item;
                    }

                    return sumValue;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Calculates the product of the elements in collection
        /// </summary>
        /// <typeparam name="T">Type parameter of the elements</typeparam>
        /// <param name="input">Parameter holding the reference to the element's type</param>
        /// <returns>Product of the collection elements values. If type parameter is DateTime or collection is empty, returns default(T)</returns>
        public static T Product<T>(this IEnumerable<T> input) where T : struct
        {
            // checks for empty collection
            if (input != null)
            {
                // Checks for DateTime type. If it's DateTime, returns default value for DateTime (01/01/00 00:00:00)
                if (typeof(T) != typeof(DateTime))
                {
                    var productValue = default(T) + (dynamic)1;
                    foreach (T item in input)
                    {
                        productValue = productValue * (dynamic)item;
                    }

                    return productValue;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Calculates the min element in collection
        /// </summary>
        /// <typeparam name="T">Type parameter of the elements</typeparam>
        /// <param name="input">Parameter holding the reference to the element's type</param>
        /// <returns>Min element in the collection</returns>
        public static T Min<T>(this IEnumerable<T> input) where T : struct, IComparable, IComparable<T>
        {
            // checks for empty collection
            if (input != null)
            {
                {
                    dynamic minElement = input.ElementAt(0);
                    foreach (T item in input)
                    {
                        if (minElement.CompareTo(item) > 0)
                        {
                            minElement = item;
                        }
                    }

                    return minElement;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Calculates the max element in collection
        /// </summary>
        /// <typeparam name="T">Type parameter of the elements</typeparam>
        /// <param name="input">Parameter holding the reference to the element's type</param>
        /// <returns>Max element in the collection</returns>
        public static T Max<T>(this IEnumerable<T> input) where T : struct, IComparable, IComparable<T>
        {
            // checks for empty collection
            if (input != null)
            {
                {
                    dynamic minElement = input.First();
                    foreach (T item in input)
                    {
                        if (minElement.CompareTo(item) < 0)
                        {
                            minElement = item;
                        }
                    }

                    return minElement;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Calculates the average of the elements in collection
        /// </summary>
        /// <typeparam name="T">Type parameter of the elements</typeparam>
        /// <param name="input">Parameter holding the reference to the element's type</param>
        /// <returns>Average of the collection elements values, if type parameter is DateTime, returns default(Decimal)</returns>
        public static decimal Average<T>(this IEnumerable<T> input) where T : struct
        {
            // checks for empty collection
            if (input != null)
            {
                // Checks for DateTime type. If it's DateTime, returns default value for Decimal (0.0)
                if (typeof(T) != typeof(DateTime))
                {
                    // using decimal for average return type
                    decimal averageValue = 0.0m;
                    int countValues = 0;
                    foreach (var item in input)
                    {
                        averageValue = averageValue + (dynamic)item;
                        countValues++;
                    }

                    return averageValue / (decimal)countValues;
                }
            }

            return 0.0m;
        }
    }
}
