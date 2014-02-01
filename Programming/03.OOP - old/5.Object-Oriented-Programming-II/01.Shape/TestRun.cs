// Define abstract class Shape with only one abstract method CalculateSurface() 
// and fields width and height. Define two new classes Triangle and Rectangle that 
// implement the virtual method and return the surface of the figure (height*width 
// for rectangle and height*width/2 for triangle). Define class Circle and suitable
// constructor so that at initialization height must be kept equal to width and
// implement the CalculateSurface() method. Write a program that tests the behavior of  
// the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.

namespace MyShape
{
    using System;

    public class TestRun
    {
        public static void Main()
        {
            Random generator = new Random();
            Shape[] shapes = new Shape[10];
            Shape shape = null;
            for (int i = 0; i < 10; i++)
            {
                switch (generator.Next(1, 4))
                {
                    case 1:
                        shape = new Triangle(generator.Next(50), generator.Next(50));
                        break;
                    case 2:
                        shape = new Rectangle(generator.Next(50), generator.Next(50));
                        break;
                    case 3:
                        shape = new Circle(generator.Next(50));
                        break;
                }

                shapes[i] = shape;
            }

            foreach (var item in shapes)
            {
                if (item is Triangle)
                {
                    Console.WriteLine("Traingle surface: {0:F}", item.CalculateSurface());
                }
                else if (item is Rectangle)
                {
                    Console.WriteLine("Rectangle surface: {0:F}", item.CalculateSurface());
                }
                else
                {
                    Console.WriteLine("Circle surface: {0:F}", item.CalculateSurface());
                }
            }
        }
    }
}
