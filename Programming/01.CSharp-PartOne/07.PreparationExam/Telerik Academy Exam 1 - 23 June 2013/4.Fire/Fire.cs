using System;

public class Fire
{
    public static void Main()
    {
        // Console input
        int width = int.Parse(Console.ReadLine());

        // Prints upper part of fire
        int halfFireWidth = width / 2;
        for (int upFireHeight = 0; upFireHeight < halfFireWidth; upFireHeight++)
        {
            Console.Write(new string('.', halfFireWidth - upFireHeight - 1));
            Console.Write("#");
            Console.Write(new string('.', upFireHeight));
            Console.Write(new string('.', upFireHeight));
            Console.Write("#");
            Console.WriteLine(new string('.', halfFireWidth - upFireHeight - 1));
        }

        // Prints bottom part of fire
        for (int upFireHeight = 0; upFireHeight < halfFireWidth; upFireHeight++)
        {
            if (upFireHeight < width / 4)
            {
                Console.Write(new string('.', upFireHeight));
                Console.Write("#");
                Console.Write(new string('.', halfFireWidth - upFireHeight - 1));
                Console.Write(new string('.', halfFireWidth - upFireHeight - 1));
                Console.Write("#");
                Console.WriteLine(new string('.', upFireHeight));
            }
        }

        // Print top of the torch
        Console.WriteLine(new string('-', width));

        // Prints torch body
        int halfWidth = width / 2;
        for (int torchHeight = 0; torchHeight < halfWidth; torchHeight++)
        {
            Console.Write(new string('.', torchHeight));
            Console.Write(new string('\\', halfWidth - torchHeight));
            Console.Write(new string('/', halfWidth - torchHeight));
            Console.WriteLine(new string('.', torchHeight));
        }
    }
}
