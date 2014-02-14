namespace MyShape.Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        /// <summary>
        /// Instantiates an object of Shape subclasses (Shape is an abstract and due to that is not instaniatable).
        /// </summary>
        /// <param name="height">Height of the shape.</param>
        /// <param name="width">Width of the shape.</param>
        protected Shape(double height = 0.0, double width = 0.0)
        {
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Gets and sets Width of the shape.
        /// </summary>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value >= 0.0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative values are not acceptable!");
                }
            }
        }

        /// <summary>
        /// Gets and sets Height of the shape.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value >= 0.0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative values are not acceptable!");
                }
            }
        }

        /// <summary>
        /// Abstract method calculating surface area of the shape.
        /// </summary>
        /// <returns>Area of the shape.</returns>
        public abstract double CalculateSurface();
    }
}