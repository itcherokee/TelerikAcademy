namespace StringBuilderExt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Test
    {
        static void Main(string[] args)
        {
            // Tests StringBuilder's extension methods - Task 1
            Console.WriteLine("\n" + new string('-', 50) + "\nTests StringBuilder's extension methods - Task 1\n" + new string('-', 50));

            StringBuilder test = new StringBuilder("Ala bala nica");
            Console.WriteLine("Original string: {0}", test.ToString());
            Console.WriteLine("Substring (index=9, count=4): {0}", test.SubString(9, 4));
            Console.WriteLine("Substring (index=4): {0}", test.SubString(4));
        }
    }
}
