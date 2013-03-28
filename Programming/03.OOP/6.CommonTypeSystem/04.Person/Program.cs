// Create a class Person with two fields – name and age. Age can be left unspecified 
// (may contain null value. Override ToString() to display the information of a person
// and if age is not specified – to say so. Write a program to test this functionality.

namespace MyPerson
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Person personOne = new Person("Goshko", 23);
            Console.WriteLine(personOne);
            Person personTwo = new Person("Peshko");
            Console.WriteLine(personTwo);
        }
    }
}
