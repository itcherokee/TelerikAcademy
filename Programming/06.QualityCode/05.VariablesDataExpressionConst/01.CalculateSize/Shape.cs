
namespace SizeCalculations
{
    using System;

    /// <summary>
    /// Class represents 2D shape.
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="initialWidth">Width of the shape in centimeters.</param>
        /// <param name="initialHeight">Height of the shape in centimeters.</param>
        public Shape(double initialWidth, double initialHeight)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
        }

        /// <summary>
        /// Gets or sets Height of the shape in centimeters.
        /// </summary>
        /// <value>Double value, represented in centimeters.</value>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets Width of the shape in centimeters.
        /// </summary>
        /// <value>Double value, represented in centimeters.</value>
        public double Width { get; set; }

        /// <summary>
        /// Calculates the Height and Width of the instance shape after rotation on some degrees angle.
        /// </summary>
        /// <param name="rotationAngle">Angle in degrees to rotate the shape.</param>
        /// <returns>New instance of Shape object with changed size after rotation.</returns>
        public Shape GetRotatedShape(double rotationAngle)
        {
            double calculatedSinus = Math.Abs(Math.Sin(rotationAngle));
            double calculatedCosinus = Math.Abs(Math.Cos(rotationAngle));
            double calculatedWidth = (calculatedCosinus * this.Width) + (calculatedSinus * this.Height);
            double calculatedHeight = (calculatedSinus * this.Width) + (calculatedCosinus * this.Height);
            return new Shape(calculatedWidth, calculatedHeight); ;
        }
    }
}
