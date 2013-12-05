using System;

public class MathExpression
{
    public static void Main()
    {
        double n = double.Parse(Console.ReadLine());
        double m = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());
        double chislitel = (n * n) + (1 / (m * p)) + 1337;
        double delitel = n - (128.523123123 * p);
        int angle = ((int)m) % 180;
        double result = (chislitel / delitel) + Math.Sin(angle);
        Console.WriteLine("{0:F6}", result);
    }
}