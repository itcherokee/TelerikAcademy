// Write a static class with a static method to calculate the distance between two points in the 3D space.

namespace My3DSpace
{
    using System;

    public static class Distance3D
    {
        /// <summary>
        /// Calculates the distance between two 3D-coordinates using separate values for each coordinate
        /// </summary>
        /// <param name="x1">Point 1 - X coordinate</param>
        /// <param name="y1">Point 1 - Y coordinate</param>
        /// <param name="z1">Point 1 - Z coordinate</param>
        /// <param name="x2">Point 2 - X coordinate</param>
        /// <param name="y2">Point 2 - Y coordinate</param>
        /// <param name="z2">Point 2 - Z coordinate</param>
        /// <returns></returns>
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            // return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2) + Math.Pow((z1 - z2), 2));
            return Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)) + ((z1 - z2) * (z1 - z2)));
        }

        /// <summary>
        /// Calculates the distance between two 3D-coordinates using two Point3D points
        /// </summary>
        /// <param name="firstPoint">First 3D point</param>
        /// <param name="secondPoint">Second 3D point</param>
        /// <returns></returns>
        public static double CalcDistance3D(Point3D firstPoint, Point3D secondPoint)
        {
            double xPoints = firstPoint.x - secondPoint.x;
            double yPoints = firstPoint.y - secondPoint.y;
            double zPoints = firstPoint.z - secondPoint.z;
            return Math.Sqrt((xPoints * xPoints) + (yPoints * yPoints) + (zPoints * zPoints));
        }
    }
}
