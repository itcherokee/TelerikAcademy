using System;

/// <summary>
/// Task: "6. Write an expression that checks if given point (x,  y) is within a circle K(O, 5)."
/// </summary>
public class PointWithinCircle
{
    public static void Main()
    {
        Console.Title = "Point within a circle?";
        Console.WriteLine("Circle coordinates are set as (0,0) with radius of 5 by definition.");
        Circle circle = new Circle(5);
        Console.WriteLine("Let set the coordinates of the point:");
        Point point = new Point();
        point.X = InputData("X");
        point.Y = InputData("Y");
        if (((point.X * point.X) + (point.Y * point.Y)) <= (circle.Radius * circle.Radius))
        {
            Console.WriteLine("Point with coordinates ({0},{1}) is WITHIN a given circle [(0,0),5].", point.X, point.Y);
        }
        else
        {
            Console.WriteLine("Point with coordinates ({0},{1}) is OUTSIDE a given circle ((0,0),5).", point.X, point.Y);
        }

        Console.ReadKey();
    }

    private static int InputData(string message)
    {
        bool isValidInput = false;
        int inputValue = 0;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please enter integer value for \"{0}\": ", message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out inputValue);
            if (isValidInput)
            {
                isValidInput = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered incorrect number (not integer) or symbol(s). Try again (press key).");
                Console.ReadKey();
            }
        }
        while (!isValidInput);

        return inputValue;
    }
}
