namespace SingletonPattern
{
    using System;

    public class SingletonDemo
    {
        public static void Main()
        {
            // creates first instance of the class Singleton
            Singleton s1 = Singleton.Instance();

            // instance of the class Singleton is already created, so the variable s2 gets reference to it instead of creating new instance
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            Console.ReadKey();
        }
    }
}
