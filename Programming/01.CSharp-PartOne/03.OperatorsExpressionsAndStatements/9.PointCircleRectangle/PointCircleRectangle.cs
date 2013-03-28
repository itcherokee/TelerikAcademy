using System;

class PointCircleRectangle
{
    // Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
    // and out of the rectangle R(top=1, left=-1, width=6, height=2).


    // Input from Console management
    static double EnterData(string pointCoordinate)
    {
        bool correctPointValue = false;
        double enteredValue = 0.0d;
        do
        {
            Console.Write("Please enter value for \"{0}\" coordinate of a point: ", pointCoordinate);
            correctPointValue = double.TryParse(Console.ReadLine(), out enteredValue);
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
        double pointX = 0.0d;
        double pointY = 0.0d;
        double rectLeftUpX = -1.0d;
        double rectLeftUpY = 1.0d;
        double rectRightDownX = 5.0d;
        double rectRightDownY = -1.0d;
        double circleX = 1.0d;
        double circleY = 1.0d;
        double circleR = 3.0d;
        Console.Title = "Point within a circle and outside rectangle";
        pointX = EnterData("X");
        pointY = EnterData("Y");
        if (((((pointX - circleX) * (pointX - circleX)) + ((pointY - circleY) * (pointY - circleY))) <= (circleR * circleR))
            && ((pointX < rectLeftUpX) || (pointX > rectRightDownX) || (pointY > rectLeftUpY) || (pointY < rectRightDownY)))
        {
            Console.WriteLine("Point is within circle and outside rectangle.");
        }
        else
        {
            Console.WriteLine("Point is not covering the task condition \n(point is both in circle and rectangle or only in rectangle or outside both)");
        }
        Console.ReadKey();
    }
}