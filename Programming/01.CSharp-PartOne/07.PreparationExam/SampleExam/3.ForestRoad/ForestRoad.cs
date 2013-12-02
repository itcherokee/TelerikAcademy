using System;

public class ForestRoad
{
    public static void Main()
    {
        int numberInput = int.Parse(Console.ReadLine());
        bool direction = true;
        int pathMark = 1;
        int row = 1;
        string mapRow = string.Empty;
        do
        {
            for (int i = 1; i <= numberInput; i++)
            {
                if (pathMark == i)
                {
                    mapRow += '*';
                }
                else
                {
                    mapRow += '.';
                }
            }

            Console.WriteLine(mapRow);
            if (direction)
            {
                pathMark++;
            }
            else
            {
                pathMark--;
            }

            if (pathMark == numberInput)
            {
                direction = false;
            }
            else if (pathMark == 1)
            {
                direction = true;
            }

            row++;
            mapRow = string.Empty;
        }
        while (row != (2 * numberInput));
    }
}
