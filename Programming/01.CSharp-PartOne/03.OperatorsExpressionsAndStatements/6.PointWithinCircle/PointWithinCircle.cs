using System;

class PointWithinCircle
{
    // Write an expression that checks if given point (x,y) is within a circle K((0,0),5).

    // Input data management
    static int EnterData(string pointCoordinate)
    {
        bool correctPointValue = false;
        int enteredValue = 0;
        do
        {
            Console.Write("Please enter value for \"{0}\" coordinate of a point (integer):", pointCoordinate);
            correctPointValue = int.TryParse(Console.ReadLine(), out enteredValue);
            if (correctPointValue)
            { correctPointValue = true; }
            else
            {
                Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!correctPointValue);
        Console.Clear();
        return enteredValue;
    }

    static void Main()
    {
        int pointX = 0;
        int pointY = 0;
        int radius = 5;
        bool wrongInput = false;
        Console.Title = "Point within a circle?";
        do
        {
            pointX = EnterData("X");
            pointY = EnterData("Y");
        } while (wrongInput);
        if (((pointX * pointX) + (pointY * pointY)) <= (radius * radius))
        {
            Console.WriteLine("Point with coordinates ({0},{1}) is WITHIN a given circle ((0,0),5).", pointX, pointY);
        }
        else
        {
            Console.WriteLine("Point with coordinates ({0},{1}) is OUTSIDE a given circle ((0,0),5).", pointX, pointY);
        }
        Console.ReadKey();
    }
}
