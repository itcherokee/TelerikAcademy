using System;

public class Program
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.Write(new string('.', number));
        Console.WriteLine(new string('*', number));
        for (int index = 0; index < number - 1; index++)
        {
            Console.Write(new string('.', number - index - 1));
            Console.Write("*");
            Console.Write(new string('.', index));
            Console.Write(new string('.', number - 1));
            Console.WriteLine("*");
        }

        Console.Write(new string('*', number * 2));
    }
}