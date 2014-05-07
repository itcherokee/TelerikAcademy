// ********************************
// <copyright file="Circle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Abstraction
{
    using System;

    /// <summary>
    /// Represents the circle shape object.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Circle's object radius.
        /// </summary>
        private double radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Circle radius value.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="radius"/> is zero or a negative value.</exception>
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the circle radius value.
        /// </summary>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Circle radius can't be equal to zero or be of negative value!");
                }

                this.radius = value;
            }
        }

        /// <summary>
        /// Calculates circle perimeter
        /// </summary>
        /// <returns>Circle's perimeter</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Calculates circle's surface
        /// </summary>
        /// <returns>Circle's surface</returns>
        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
