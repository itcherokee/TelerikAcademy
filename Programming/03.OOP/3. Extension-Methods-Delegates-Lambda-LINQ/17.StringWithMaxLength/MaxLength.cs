// Task 17: Write a program to return the string with maximum length from an array of strings. Use LINQ.

namespace StringWithMaxLength
{
    using System;
    using System.Linq;

    public class MaxLength
    {
        public static void Main()
        {
            var words = new[] { "123456", "123", "123456", "1234567890", "12", "123", "12345678" };

            var query = (from longest in words
                         where longest.Length == words.Max(m => m.Length)
                         select longest).SingleOrDefault();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWords in array: {0}\n", string.Join(", ", words));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Longest word is: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(query);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}