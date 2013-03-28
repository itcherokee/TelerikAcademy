using System;

class CircleAreaAndPerimeter
{
    static void Main()
    {
        //Write a program that reads the radius r of a circle and prints its perimeter and area.

        Console.Title = "Perimeter and Area of a circle";
        Console.Write("Enter the circle radius in order to calculate area and perimeter (cm):");
        float radius;
        radius = float.Parse(Console.ReadLine());
        double perimeter, area;
        perimeter = 2d * Math.PI * radius;
        area = Math.PI * radius * radius;
        Console.WriteLine("The Area is: {0:F5} square cm.", area);
        Console.WriteLine("The Perimeter is: {0:F5} cm.", perimeter);
        Console.ReadKey();
    }
}
