// Task 3: Write a static class with a static method to calculate the distance between two points in the 3D space.

namespace Euclidian3DSpace
{
    using System;

    public static class Distance3D
    {
        /// <summary>
        /// Calculates the distance between two 3D-coordinates using separate values for each coordinate.
        /// </summary>
        /// <param name="x1">Point 1 - X coordinate</param>
        /// <param name="y1">Point 1 - Y coordinate</param>
        /// <param name="z1">Point 1 - Z coordinate</param>
        /// <param name="x2">Point 2 - X coordinate</param>
        /// <param name="y2">Point 2 - Y coordinate</param>
        /// <param name="z2">Point 2 - Z coordinate</param>
        /// <returns></returns>
        public static double Distance(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            // return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2));
            return Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)) + ((z1 - z2) * (z1 - z2)));
        }

        /// <summary>
        /// Calculates the distance between two 3D-coordinates using two Point3D type coordinates.
        /// </summary>
        /// <param name="firstPoint">First 3D point coordinates</param>
        /// <param name="secondPoint">Second 3D point coordinates</param>
        /// <returns></returns>
        public static double Distance(Point3D firstPoint, Point3D secondPoint)
        {
            double axisXDistance = firstPoint.X - secondPoint.X;
            double axisYDistance = firstPoint.Y - secondPoint.Y;
            double axisZDistance = firstPoint.Z - secondPoint.Z;
            return Math.Sqrt((axisXDistance * axisXDistance) + (axisYDistance * axisYDistance) + (axisZDistance * axisZDistance));
        }
    }
}
