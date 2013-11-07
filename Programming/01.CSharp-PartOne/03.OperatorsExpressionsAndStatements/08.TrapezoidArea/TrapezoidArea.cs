using System;

/// <summary>
/// Task: "8. Write an expression that calculates trapezoid's area by given sides a and b and height h."
/// </summary>
public class TrapezoidArea
{
    public static void Main()
    {
        Console.Title = "Calculation of trapezoid area";
        Trapezoid trapezoid = new Trapezoid();
        trapezoid.BottomBase = EnterValue("a - botton base");
        trapezoid.UpperBase = EnterValue("b - upper base");
        trapezoid.Height = EnterValue("h - height");
        Console.WriteLine("The area of trapezoid with the given parameters is S={0} (square cm.)", trapezoid.GetArea().ToString());
        Console.ReadKey();
    }

    private static double EnterValue(string value)
    {
        double result = 0.0f;
        bool isValidInput = false;
        do
        {
            Console.Write("Enter the \"{0}\" of Trapezoid in cm: ", value);
            isValidInput = double.TryParse(Console.ReadLine(), out result);
            if (isValidInput != true)
            {
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
