using System;

class FirTree
{
    static void Main()
    {
        int treeHeight = int.Parse(Console.ReadLine()); //tree size
        int dots = (treeHeight - 2);
        for (int i = 1; i <= treeHeight - 1; i++)
        {
            Console.Write(new string('.', dots));
            Console.Write(new string('*', i * 2 - 1));
            Console.Write(new string('.', dots--));
            Console.WriteLine();
        }
        dots = (treeHeight - 2);
        Console.Write(new string('.', dots));
        Console.Write(new string('*', 1));
        Console.Write(new string('.', dots));
        Console.WriteLine();
    }
}

