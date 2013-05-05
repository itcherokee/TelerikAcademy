// ********************************
// <copyright file="GraphicsUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Methods
{
    using System;

    /// <summary>
    /// Contains utils to manage graphics points & objects.
    /// </summary>
    public class GraphicsUtils
    {
        /// <summary>
        /// Calculates area of a triangle by Heron's formula.
        /// </summary>
        /// <param name="sideA">Side 'a' of triangle.</param>
        /// <param name="sideB">Side 'b' of triangle.</param>
        /// <param name="sideC">Side 'c' of triangle.</param>
        /// <returns>Calculated area of the triangle.</returns>
        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA > 0 && sideB > 0 && sideC > 0)
            {
                double semiparameter = (sideA + sideB + sideC) / 2;
                double semiSideA = semiparameter - sideA;
                double semiSideB = semiparameter - sideB;
                double semiSideC = semiparameter - sideC;
                double area = Math.Sqrt(semiparameter * semiSideA * semiSideB * semiSideC);
                return area;
            }
            else
            {
                throw new ArgumentOutOfRangeException("All values should be positive.");
            }
        }

        /// <summary>
        /// Calculates distance between two points in 2D space.
        /// </summary>
        /// <param name="x1">X coordinate of point One.</param>
        /// <param name="y1">Y coordinate of point One.</param>
        /// <param name="x2">X coordinate of point Two.</param>
        /// <param name="y2">Y coordinate of point Two.</param>
        /// <returns>Distance between two points.</returns>
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            return distance;
        }

        /// <summary>
        /// Checks does two points are horizontal to each other.
        /// </summary>
        /// <param name="y1">Y coordinate of point One.</param>
        /// <param name="y2">Y coordinate of point Two.</param>
        /// <returns>True or false.</returns>
        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        /// <summary>
        /// Checks does two points are vertical to each other.
        /// </summary>
        /// <param name="x1">X coordinate of point One.</param>
        /// <param name="x2">X coordinate of point Two.</param>
        /// <returns>True or false.</returns>
        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }
    }
}
