// Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. Add a static property to return the point O.

namespace My3DSpace
{
    using System;
    using System.Text;

    /// <summary>
    /// Defines representation of 3D-coordinate in Euclidian 3D space.
    /// </summary>
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        /// <summary>
        /// Converts Euclidian 3D-coordinate to special formated representation of System.string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("3D point coordinates:\n");
            output.Append(string.Format("X = {0}\n", this.X.ToString()));
            output.Append(string.Format("Y = {0}\n", this.Y.ToString()));
            output.Append(string.Format("Z = {0}\n", this.Z.ToString()));
            return output.ToString();
        }
    }

    public class Euclidian3D
    {
        /// <summary>
        /// Represents the 3D-coordinate in Euclidian 3D space.
        /// </summary>
        public Point3D Coordinate3D { get; set; }

        private static readonly Point3D coordinateCenter;

        /// <summary>
        /// Read-only. Represents 3D-coordinates of the center - O{0,0,0} of Euclidian 3D space
        /// </summary>
        public static Point3D CoordinateCenter
        {
            get { return coordinateCenter; }
        }

        /// <summary>
        /// Default static constructor of Euclidian3d class. Initialize the static read-only field coordinateCenter to {0,0,0}
        /// </summary>
        static Euclidian3D()
        {
            coordinateCenter = new Point3D();
            coordinateCenter.X = 0.0d;
            coordinateCenter.Y = 0.0d;
            coordinateCenter.Z = 0.0d;
        }
    }
}
