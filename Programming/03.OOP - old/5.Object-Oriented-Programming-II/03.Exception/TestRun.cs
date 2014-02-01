// Define a class InvalidRangeException<T> that holds information about an error 
// condition related to invalid range. It should hold error message and a range definition [start … end].
// Write a sample application that demonstrates the InvalidRangeException<int> and
// InvalidRangeException<DateTime> by entering numbers in the range [1..100] and 
// dates in the range [1.1.1980 … 31.12.2013].

namespace MyException
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            InvalidRangeException<int> intException = new InvalidRangeException<int>("Invalid integer used!", 1, 100);
            InvalidRangeException<DateTime> dateException = new InvalidRangeException<DateTime>("Invalid Data used!", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));

            Console.WriteLine("Please enter 3 integers.");
            int input;
            for (int i = 0; i < 3; i++)
            {
                input = int.Parse(Console.ReadLine());
                if (input >= intException.Min && input <= intException.Max)
                {
                    Console.WriteLine("You have entered number: {0}", input);
                }
                else
                {
                    throw intException;
                }
            }

            Console.WriteLine("Please enter 3 dates.");
            DateTime date;
            for (int i = 0; i < 3; i++)
            {
                date = DateTime.Parse(Console.ReadLine());
                if (date.Year >= dateException.Min.Year && date.Year <= dateException.Max.Year)
                {
                    Console.WriteLine("You have entered date: {0}", date.Date);
                }
                else
                {
                    throw dateException;
                }
            }
        }
    }
}
