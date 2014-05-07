// ********************************
// <copyright file="Rectangle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Abstraction
{
    using System;

    /// <summary>
    /// Represents rectangle shape object.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Rectangle's width.
        /// </summary>
        private double width;

        /// <summary>
        /// Rectangle's height.
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">Rectangle width value.</param>
        /// <param name="height">Rectangle height value.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="Width"/> or <paramref name="Height"/> are zero or a negative value.</exception> 
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Gets or sets rectangle's width value.
        /// </summary>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle width can't be equal to zero or be of negative value!");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets rectangle's height value.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rectangle height can't be equal to zero or be of negative value!");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Calculates rectangle's perimeter.
        /// </summary>
        /// <returns>Rectangle's perimeter.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Calculates rectangle's surface.
        /// </summary>
        /// <returns>Rectangle's surface.</returns>
        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
