using System;

class TrapezoidArea
{
    //Write an expression that calculates trapezoid's area by given sides a and b and height h.

    static double EnterValue(string value)
    {
        // Management of the input from Console - entering data
        double result = 0.0f;
        bool wrongInput = false;
        do
        {
            Console.Write("Enter the \"{0}\" of Trapezoid in cm: ", value);
            wrongInput = double.TryParse(Console.ReadLine(), out result);
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
        double trapezoidAreaCalc = 0.0;
        double trapezoidBottomBase = 0.0;
        double trapezoidUpperBase = 0.0;
        double trapezoidHeight = 0.0;
        Console.Title = "Calculation of trapezoid area";
        trapezoidBottomBase = EnterValue("a");
        trapezoidUpperBase = EnterValue("b");
        trapezoidHeight = EnterValue("h");
        trapezoidAreaCalc = ((trapezoidBottomBase + trapezoidUpperBase) / 2) * trapezoidHeight;
        Console.WriteLine("The area of trapezoid with the given parameters is S={0} (square cm.)", trapezoidAreaCalc.ToString());
        Console.ReadKey();
    }
}
