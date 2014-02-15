namespace MyBitArray64
{
    using System;

    public class Test
    {
        public static void Main()
        {
            BitArray64 numberOne = new BitArray64(18446744073709551615);
            BitArray64 numberTwo = new BitArray64(100);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Both sequences of bits are the same object: {0}", ReferenceEquals(numberOne, numberTwo));
            Console.WriteLine("Both sequences of bits are with same bits: {0}\n", numberOne.Equals(numberTwo));
            numberTwo[20] = 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Number {0} as bits:", numberTwo.Value);
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var bit in numberTwo)
            {
                Console.Write(bit);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nNumber {0} as bits:", numberOne.Value);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(numberOne);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}