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