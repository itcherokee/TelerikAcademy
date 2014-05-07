namespace SizeCalculations
{
    using System;

    /// <summary>
    /// Class represents the dimensions of the 2D shape.
    /// </summary>
    public class Size
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="initialWidth">Width of the shape in centimeters.</param>
        /// <param name="initialHeight">Height of the shape in centimeters.</param>
        public Size(double initialWidth, double initialHeight)
        {
            this.Width = initialWidth;
            this.Height = initialHeight;
        }

        /// <summary>
        /// Gets or sets Height of the shape in centimeters.
        /// </summary>
        /// <value>Double value, representing centimeters.</value>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets Width of the shape in centimeters.
        /// </summary>
        /// <value>Double value, representing centimeters.</value>
        public double Width { get; set; }
    }
}
