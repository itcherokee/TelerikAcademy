// Refactor the following code to use proper variable naming and simplified expressions

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
            Size initialShapeSize = new Size(3.4, 4.5);
            double angle = 20.1;
            Size shapeSizeAfterRotation = GetRotatedSize(initialShapeSize, angle);
            Console.WriteLine("Initial size of the shape: width={0}cm., height={1}cm.", initialShapeSize.Width, initialShapeSize.Height);
            Console.WriteLine("Shape size after rotation on {0} degrees: width={1:N2}cm., height={2:N2}cm.", angle, shapeSizeAfterRotation.Width, shapeSizeAfterRotation.Height);
        }

        /// <summary>
        /// Calculates the Height and Width of the shape after rotation on some degrees angle.
        /// </summary>
        /// <param name="currentSize">Current sizes (height and width) of a shape represented in Size object.</param>
        /// <param name="rotationAngle">Angle in degrees to rotate the shape.</param>
        /// <returns>Size object with after rotation sizes of the shape.</returns>
        public static Size GetRotatedSize(Size currentSize, double rotationAngle)
        {
            double calculatedSinus = Math.Abs(Math.Sin(rotationAngle));
            double calculatedCosinus = Math.Abs(Math.Cos(rotationAngle));
            double calculatedWidth = (calculatedCosinus * currentSize.Width) + (calculatedSinus * currentSize.Height);
            double calculatedHeight = (calculatedSinus * currentSize.Width) + (calculatedCosinus * currentSize.Height);
            Size resultantSize = new Size(calculatedWidth, calculatedHeight);
            return resultantSize;
        }
    }
}