// ********************************
// <copyright file="GraphicsUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Class containing utils for calculations in 2D & 3D space.
    /// </summary>
    public static class GraphicsUtils
    {
        /// <summary>
        /// Calculates distance between two <see cref="Point"/>s in space (2D & 3D). 
        /// If coordinateZ property in one or both points is set to <see cref="null"/>,
        /// calculation is done in 2D space else in 3D space.
        /// </summary>
        /// <param name="pointOne">Coordinates of the first <see cref="Point"/>.</param>
        /// <param name="pointTwo">Coordinates of the second <see cref="Point"/>.</param>
        /// <returns>Distance between two <see cref="Point"/>s.</returns>
        public static double CalculateDistance(Point pointOne, Point pointTwo)
        {
            double distance;
            double deltaX = pointTwo.CoordinateX.Value - pointOne.CoordinateX.Value;
            double deltaY = pointTwo.CoordinateY.Value - pointOne.CoordinateY.Value;
            if (pointOne.CoordinateZ.HasValue && pointTwo.CoordinateZ.HasValue)
            {
                double deltaZ = pointTwo.CoordinateZ.Value - pointOne.CoordinateZ.Value;
                distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
            }
            else
            {
                distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            }

            return distance;
        }

        /// <summary>
        /// Calculates the volume of square shape by using coordinates of the four <see cref="Point"/>s.
        /// </summary>
        /// <param name="pointOne">Coordinates of the first <see cref="Point"/>.</param>
        /// <param name="pointTwo">Coordinates of the second <see cref="Point"/>.</param>
        /// <param name="pointThree">Coordinates of the third <see cref="Point"/>.</param>
        /// <param name="pointFour">Coordinates of the fourth <see cref="Point"/>.</param>
        /// <returns>Returns the volume of square shape.</returns>
        public static double CalcVolume(Point pointOne, Point pointTwo, Point pointThree, Point pointFour)
        {
            double sideA = CalculateDistance(pointOne, pointTwo);
            double sideB = CalculateDistance(pointOne, pointThree);
            double sideC = CalculateDistance(pointOne, pointFour);
            double volume = sideA * sideB * sideC;
            return volume;
        }

        /// <summary>
        /// Calculates distance between <see cref="Point"/> and center of coordinate system.
        /// </summary>
        /// <param name="point">Coordinates of the <see cref="Point"/>.</param>
        /// <returns>Distance between <see cref="Point"/> and center.</returns>
        public static double CalcDistanceToCenter(Point point)
        {
            Point center;
            if (point.CoordinateZ.HasValue)
            {
                center = new Point(0, 0, 0);
            }
            else
            {
                center = new Point(0, 0);
            }

            double distance = CalculateDistance(center, point);
            return distance;
        }
    }
}
