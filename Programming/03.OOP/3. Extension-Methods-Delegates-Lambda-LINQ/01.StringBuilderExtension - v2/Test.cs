namespace StringBuilderExtension
{
    using System;
    using System.Text;

    public class Test
    {
        public static void Main()
        {
            // Tests StringBuilder's extension methods - Task 1
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n" + new string('-', 50) + "\nTests StringBuilder's extension methods - Task 1\n" + new string('-', 50));
            Console.ForegroundColor = ConsoleColor.Green;
            var sentence = new StringBuilder("Ala bala nica");
            Console.WriteLine("Original string: {0}", sentence);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Substring (index=9, count=4): {0}", sentence.SubString(9, 4));
            Console.WriteLine("Substring (index=4): {0}", sentence.SubString(4));
        }
    }
}