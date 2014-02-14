// Task 3:  Define a class InvalidRangeException<T> that holds information about an error condition related 
//          to invalid range. It should hold error message and a range definition [start … end].
//          Write a sample application that demonstrates the InvalidRangeException<int> and 
//          InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates 
//          in the range [1.1.1980 … 31.12.2013].

namespace MyRangeException
{
    using System;
    using System.Linq;
    using System.Reflection;
    using RangeException;

    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter 3 integers.");
                for (int counter = 0; counter < 3; counter++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Number {0}: ", counter);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int input = Read(Console.ReadLine().Trim(), 1, 10);
                    Console.WriteLine("You have entered number: {0}", input);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please enter 3 dates.");
                for (int counter = 0; counter < 3; counter++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Number {0}: ", counter);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    DateTime input = Read(Console.ReadLine().Trim(), new DateTime(2000, 1, 1), new DateTime(2014, 01, 10));
                    Console.WriteLine("You have entered date: {0}", input);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("Exception: {0} (Range: {1}..{2})", ex.Message, ex.Start, ex.End));
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("Exception: {0} (Range: {1}..{2})", ex.Message, ex.Start, ex.End));
            }
        }

        /// <summary>
        /// Generic method that parses the string value to respective type observing specified range of values.
        /// </summary>
        /// <typeparam name="T">Expected ValuType.</typeparam>
        /// <param name="inputValue">String input value.</param>
        /// <param name="start">Minimum range value.</param>
        /// <param name="end">Maximal range value.</param>
        /// <returns>ValueType value.</returns>
        private static T Read<T>(string inputValue, T start, T end) where T : struct, IComparable<T>, IComparable
        {
            Type type = typeof(T);
            MethodInfo methodInfo = type
                                    .GetMethods(BindingFlags.Public | BindingFlags.Static)
                                    .FirstOrDefault(m => m.Name == "Parse");
            if (methodInfo == null)
            {
                throw new ApplicationException("Unable to find Parse method!");
            }

            var returnValue = (T)methodInfo.Invoke(null, new object[] { inputValue });
            if (returnValue.CompareTo(start) < 0 || returnValue.CompareTo(end) > 0)
            {
                throw new InvalidRangeException<T>("Value used is out of range!", start, end);
            }

            return (T)returnValue;
        }
    }
}