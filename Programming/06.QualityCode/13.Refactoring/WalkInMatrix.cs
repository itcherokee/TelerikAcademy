namespace Game
{
    using System;

    class WalkInMatrix
    {
        static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int size = 0;
            while (!int.TryParse(input, out size) || size < 0 || size > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            Engine engine = new Engine(size);
            Console.WriteLine(engine.CalculateAndFill());            
        }
    }
}
