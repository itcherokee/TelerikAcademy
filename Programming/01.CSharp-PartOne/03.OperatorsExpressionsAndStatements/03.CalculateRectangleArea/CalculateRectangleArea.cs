using System;

/// <summary>
/// Task: "3. Write an expression that calculates rectangle’s area by given width and height."
/// </summary>
public class CalculateRectangleArea
{
    public static void Main()
    {
        Console.Title = "Calculate Rectangle Area";
        float rectangleWidth = EnterValue("Width");
        float rectangleHeight = EnterValue("Height");
        double rectangleArea = 0.0;
        if ((rectangleWidth * rectangleHeight) <= double.MaxValue)
        {
            rectangleArea = rectangleWidth * rectangleHeight;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Rectangle Width  = {0,10:F2} cm.", rectangleWidth);
            Console.WriteLine("Rectangle Height = {0,10:F2} cm.", rectangleHeight);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nRectangle Area   = {0,10:F2} square cm.", rectangleArea);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Calculateda area is too big as number to be shown!");
        }

        Console.ReadKey();
    }

    private static float EnterValue(string value)
    {
        float result = 0.0f;
        bool isValidInput = false;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the {0} of Rectangle in cm: ", value);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = float.TryParse(Console.ReadLine(), out result);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered not a number! Try again (press a key).");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);
        Console.Clear();
        return result;
    }
}