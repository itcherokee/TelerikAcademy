using System;

class CalculateRectangleArea
{
    //Write an expression that calculates rectangle’s area by given width and height

    static float EnterValue(string value)
    {
        // Management of the input from Console 
        float result = 0.0f;
        bool wrongInput = false;
        do
        {
            Console.Write("Enter the {0} of Rectangle in cm: ", value);
            wrongInput = float.TryParse(Console.ReadLine(), out result);
            if (wrongInput != true)
            {
                Console.WriteLine("You have entered not a number! Try again (press a key).");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!wrongInput);
        Console.Clear();
        return result;
    }

    static void Main()
    {
        float rectangleWidth = 0.0f;
        float rectangleHeight = 0.0f;
        double rectangleArea = 0.0;
        Console.Title = "Calculate Rectangle Area";
        rectangleWidth = EnterValue("Width");
        rectangleHeight = EnterValue("Height");
        if ((rectangleWidth * rectangleHeight) <= double.MaxValue)
        {
            rectangleArea = rectangleWidth * rectangleHeight;
            Console.WriteLine("Rectangle Width = {0,10:F2} cm.", rectangleWidth);
            Console.WriteLine("Rectangle Width = {0,10:F2} cm.", rectangleHeight);
            Console.WriteLine();
            Console.WriteLine("Rectangle Area  = {0,10:F2} square cm.", rectangleArea);
        }
        else
        {
            Console.WriteLine("Calculateda area is too big as number to be shown!");
        }
        Console.ReadKey();
    }


}