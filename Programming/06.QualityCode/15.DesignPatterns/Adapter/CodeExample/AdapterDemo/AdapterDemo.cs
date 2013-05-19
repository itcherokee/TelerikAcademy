namespace AdapterPattern
{
    using System;

    public class AdapterDemo
    {
        public static void Main()
        {
            // Create adapter and place a request 
            Target target = new Adapter();
            target.Request();

            // Wait for user 
            Console.Read();
        }
    }
}
