// Task 1-2:    Take the VS solution "Abstraction" and refactor its code to provide good abstraction. Move the properties 
//              and methods from the class Figure to their correct place. Move the common methods to the base class's interface. 
//              Remove all duplicated code (properties / methods / other code).
//              Establish good encapsulation in the classes from the VS solution "Abstraction". Ensure that incorrect values 
//              cannot be assigned in the internal state of the classes.

namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            var circle = new Circle(5);
            Console.WriteLine("I am a circle (radius = {0}). " + "Perimeter = {1:f2}. Surface = {2:f2}.", circle.Radius, circle.CalcPerimeter(), circle.CalcSurface());
            var rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle (width={0}; height={1}). " + "Perimeter = {2:f2}. Surface = {3:f2}.", rect.Width, rect.Height, rect.CalcPerimeter(), rect.CalcSurface());
        }
    }
}
