using System;
using TriangleMath;

/// <summary>
/// Task: "4. Write methods that calculate the surface of a triangle by given: 
///         - Side and an altitude to it; 
///         - Three sides; 
///         - Two sides and an angle between them. 
/// Use System.Math"
/// </summary>
public class TriangleSurface
{
    public static void Main()
    {
        Console.Title = "Calculating surface of Triangle";
        Console.ForegroundColor = ConsoleColor.White;

        // Side and altitude to it
        Triangle sideAltitude = new Triangle(sideA: 3, altitudeSideA: 4, noSideBAndSideCAndAngle: true);
        Console.Write("Area by side ({0}cm.) and altitude ({1}cm.) = ", sideAltitude.SideA, sideAltitude.AltitudeSideA);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0} sq.cm.\n", sideAltitude.AreaSideAltitude());

        // Three sides
        Triangle threeSides = new Triangle(sideA: 3, sideB: 4, sideC: 5);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Area by side A ({0}cm.), side B ({1}cm.) and side C ({2}cm.) = ", threeSides.SideA, threeSides.SideB, threeSides.SideC);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0} sq.cm.\n", threeSides.AreaThreeSides());

        // Two sides and angle between them
        Triangle twoSidesAngle = new Triangle(sideA: 3, sideB: 4, angleSiseASideB: 90.0f);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Area by side A ({0}cm.), side B ({1}cm.) and angle ({2}\u00B0) = ", twoSidesAngle.SideA, twoSidesAngle.SideB, twoSidesAngle.AngleSideASideB);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0} sq.cm.\n", twoSidesAngle.AreaSideAngleSide());
    }
}