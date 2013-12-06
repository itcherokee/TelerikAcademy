using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Eggcelent
{
    public static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());

        // top
        Console.Write('.');
        Console.Write(new string('.', n));
        Console.Write(new string('*', n - 1));
        Console.Write(new string('.', n));
        Console.WriteLine('.');

        // upper part
        for (int index = 0; index <= n - 2; index += 2)
        {
            Console.Write(".");

            Console.Write(new string('.', n - 2 - index));
            Console.Write('*');
            Console.Write(new string('.', index + 1));

            Console.Write(new string('.', n - 1));

            Console.Write(new string('.', index + 1));
            Console.Write('*');
            Console.Write(new string('.', n - 2 - index));

            Console.WriteLine(".");
        }
        if (n > 4)
        {
            for (int i = 0; i < n / 2 - 2; i++)
            {
                Console.WriteLine(".*" + new string('.', (n - 1) * 3) + "*.");

            }

        }
        // middle-up
        Console.Write(".*");
        string temp = "";
        for (int index = 0; index < n - 1; index++)
        {
            if (index % 2 == 0)
            {
                temp += "@";
            }
            else
            {
                temp += ".";
            }
        }
        Console.Write(temp);
        temp = "";
        for (int index = 0; index < n - 1; index++)
        {
            if (index % 2 == 1)
            {
                temp += "@";
            }
            else
            {
                temp += ".";
            }
        }
        Console.Write(temp);
        temp = ""; for (int index = 0; index < n - 1; index++)
        {
            if (index % 2 == 0)
            {
                temp += "@";
            }
            else
            {
                temp += ".";
            }
        }
        Console.Write(temp);
        Console.WriteLine("*.");


        // middle-down
        Console.Write(".*");
        temp = "";
        for (int index = 0; index < n - 1; index++)
        {
            if (index % 2 == 0)
            {
                temp += ".";
            }
            else
            {
                temp += "@";
            }
        }
        Console.Write(temp);
        temp = "";
        for (int index = 0; index < n - 1; index++)
        {
            if (index % 2 == 1)
            {
                temp += ".";
            }
            else
            {
                temp += "@";
            }
        }
        Console.Write(temp);
        temp = ""; for (int index = 0; index < n - 1; index++)
        {
            if (index % 2 == 0)
            {
                temp += ".";
            }
            else
            {
                temp += "@";
            }
        }
        Console.Write(temp);
        Console.WriteLine("*.");

        if (n > 4)
        {
            for (int i = 0; i < n / 2 - 2; i++)
            {
                Console.WriteLine(".*" + new string('.', (n - 1) * 3) + "*.");

            }

        }

        // bottom part
        for (int index = n - 2; index >= 0; index -= 2)
        {
            Console.Write(".");

            Console.Write(new string('.', n - 2 - index));
            Console.Write('*');
            Console.Write(new string('.', index + 1));

            Console.Write(new string('.', n - 1));

            Console.Write(new string('.', index + 1));
            Console.Write('*');
            Console.Write(new string('.', n - 2 - index));

            Console.WriteLine(".");
        }


        // bottom
        Console.Write('.');
        Console.Write(new string('.', n));
        Console.Write(new string('*', n - 1));
        Console.Write(new string('.', n));
        Console.WriteLine('.');

    }
}