// ********************************
// <copyright file="Point.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Represents a point in 2D or 3D space.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Represents coordinate X of the point.
        /// </summary>
        private double? coordinateX = null;

        /// <summary>
        /// Represents coordinate Y of the point.
        /// </summary>
        private double? coordinateY = null;

        /// <summary>
        /// Represents coordinate Z of the point. 
        /// </summary>
        private double? coordinateZ = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class in 2D space.
        /// </summary>
        /// <param name="coordinateX">Coordinate X of the point.</param>
        /// <param name="coordinateY">Coordinate Y of the point.</param>
        public Point(double coordinateX, double coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class in 3D space.
        /// </summary>
        /// <param name="coordinateX">Coordinate X of the point.</param>
        /// <param name="coordinateY">Coordinate Y of the point.</param>
        /// <param name="coordinateZ">Coordinate Z of the point.</param>
        public Point(double coordinateX, double coordinateY, double coordinateZ)
            : this(coordinateX, coordinateY)
        {
            this.coordinateZ = coordinateZ;
        }

        /// <summary>
        /// Gets or sets coordinate X of the <see cref="Point"/>.
        /// </summary>
        public double? CoordinateX
        {
            get
            {
                return this.coordinateX;
            }

            set
            {
                this.coordinateX = value;
            }
        }

        /// <summary>
        /// Gets or sets coordinate Y of the <see cref="Point"/>.
        /// </summary>
        public double? CoordinateY
        {
            get
            {
                return this.coordinateY;
            }

            set
            {
                this.coordinateY = value;
            }
        }

        /// <summary>
        /// Gets or sets coordinate Z of the <see cref="Point"/>.
        /// </summary>
        public double? CoordinateZ
        {
            get
            {
                return this.coordinateZ;
            }

            set
            {
                this.coordinateZ = value;
            }
        }
    }
}
