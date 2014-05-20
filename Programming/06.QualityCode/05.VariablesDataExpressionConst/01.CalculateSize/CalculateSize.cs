// Task 1:  Refactor the following code to use proper variable naming and simplified expressions.

namespace SizeCalculations
{
    using System;

    /// <summary>
    /// Code that calculates size (width, height) of an shape after rotation on specified angle.
    /// </summary>
    public class CalculateSize
    {
        /// <summary>
        /// Main executable routine of the code.
        /// </summary>
        public static void Main()
        {
            const double RotationAngle = 20.1;
            const double WidthInCentimeters = 3.4;
            const double HeightInCentimeters = 4.5;

            var initialShape = new Shape(WidthInCentimeters, HeightInCentimeters);
            Shape shapeSizeAfterRotation =  initialShape.GetRotatedShape(RotationAngle); 

            Console.WriteLine("Initial size of the shape: width={0}cm., height={1}cm.", 
                initialShape.Width, initialShape.Height);
            Console.WriteLine("Shape size after rotation on {0} degrees: width={1:N2}cm., height={2:N2}cm.", 
                RotationAngle, shapeSizeAfterRotation.Width, shapeSizeAfterRotation.Height);
        }
    }
}