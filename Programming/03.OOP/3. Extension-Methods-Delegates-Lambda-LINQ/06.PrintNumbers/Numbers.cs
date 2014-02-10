// Task 6: Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
//         Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

namespace MyNumbers
{
    using System;
    using System.Linq;

    public class Numbers
    {
        private const int ArraySize = 200;

        /// <summary>
        /// Returns numbers divisible by 3 and 7 at the same time using LINQ 
        /// </summary>
        /// <param name="arrayOfNumbers">Array of integers</param>
        /// <returns>Array of integers</returns>
        public static int[] DivideLinq(int[] arrayOfNumbers)
        {
            var query = from number in arrayOfNumbers
                        where number % 21 == 0
                        select number;
            return query.ToArray();
        }

        /// <summary>
        /// Returns numbers divisible by 3 and 7 at the same time using extension methods Linq namespace 
        /// </summary>
        /// <param name="arrayOfNumbers">Array of integers</param>
        /// <returns>Array of integers</returns>
        public static int[] DivideExtension(int[] arrayOfNumbers)
        {
            var query = arrayOfNumbers.Where((x) => x % 21 == 0);
            return query.ToArray();
        }

        public static void Main(string[] args)
        {
            int[] sourceArray = new int[ArraySize];
            for (int index = 0; index < ArraySize; index++)
            {
                sourceArray[index] = index;
            }

            // Print result to Console
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('-', 60) + "\nTests methods (LINQ and Extension) to print numbers\ndivisible by 3 and 7 simultaneously  - Task 6\n" + new string('-', 60));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("By using LINQ: " + string.Join(", ", DivideLinq(sourceArray)));
            Console.WriteLine("By using Extension methods: " + string.Join(", ", DivideExtension(sourceArray)));
        }
    }
}
