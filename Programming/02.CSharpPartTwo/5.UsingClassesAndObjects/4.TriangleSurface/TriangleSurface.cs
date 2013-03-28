using System;

public class TriangleSurface
{
    // Write methods that calculate the surface of a triangle by given:
    // Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

    public static void Main()
    {
        Triangle calculation = new Triangle();
        double sideA = 3;
        double sideB = 4;
        double sideC = 5;
        double altitude = 4;
        double angle = 90.0;
        Console.WriteLine("Three methods for calculating Triangle's area.");
        Console.WriteLine("Side-Altitude: {0:F1}", calculation.CalculateTriangleSideAltitude(sideA, altitude));
        Console.WriteLine("Three Sides method: {0:F1}", calculation.CalculateTriangleThreeSides(sideA, sideB, sideC));
        Console.WriteLine("Side-Angle-Side method: {0:F1}", calculation.CalculateTriangleSideAngleSide(sideA, sideB, angle));
    }

    internal class Triangle
    {
        internal double CalculateTriangleSideAltitude(double side, double altitude)
        {
            return side * altitude / 2;
        }

        internal double CalculateTriangleThreeSides(double sideOne, double sideTwo, double sideThree)
        {
            double semiPerim = (sideOne + sideTwo + sideThree) / 2;
            return Math.Sqrt(semiPerim * (semiPerim - sideOne) * (semiPerim - sideTwo) * (semiPerim - sideThree));
        }

        internal double CalculateTriangleSideAngleSide(double sideOne, double sideTwo, double angleSides)
        {
            // for sin function, value must be converted from degrees to radians
            return (sideOne * sideTwo) / 2 * Math.Sin(Math.PI * angleSides / 180);
        }
    }
}