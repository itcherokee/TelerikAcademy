using System;

public class BatGoikoTower
{
    public static void Main()
    {
        // user input
        int height = int.Parse(Console.ReadLine());

        int crossIncrement = 1;
        int crossLine = 1;
        for (int towerHeight = 0; towerHeight < height; towerHeight++)
        {
            // Left part of tower
            Console.Write(new string('.', height - towerHeight - 1));
            Console.Write("/");

            // Check and put crossbeams at left side
            if (towerHeight == crossLine)
            {
                Console.Write(new string('-', towerHeight * 2));
                crossIncrement++;
                crossLine += crossIncrement;
            }
            else
            {
                Console.Write(new string('.', towerHeight * 2));
            }

            // Right part of tower
            Console.Write("\\");
            Console.WriteLine(new string('.', height - towerHeight - 1));
        }
    }
}