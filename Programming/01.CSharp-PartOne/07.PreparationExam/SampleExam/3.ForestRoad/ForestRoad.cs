using System;

class ForestRoad
{

    static void Main()
    {
        //var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        int numberInput = int.Parse(Console.ReadLine());
        //if ((numberInput < 2) || (numberInput > 79)) { return; }
        bool direction = true;
        int pathMark = 1;
        int row = 1;
        string mapRow = "";
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
            mapRow = "";
        } while (row != (2 * numberInput));
        //stopwatch.Stop();
        //Console.WriteLine(stopwatch.Elapsed);
    }
}
