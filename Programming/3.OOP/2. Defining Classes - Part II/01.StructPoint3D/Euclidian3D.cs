/// Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. Implement the ToString() to enable printing a 3D point.

namespace My3DSpace
{
    using System;
    using System.Text;

    public class Euclidian3D
    {
        /// <summary>
        /// Defines representation of 3D-coordinate in Euclidian 3D space.
        /// </summary>
        internal struct Point3D
        {
            internal double X;
            internal double Y;
            internal double Z;
        }

        /// <summary>
        /// Represents the 3D-coordinate in Euclidian 3D space.
        /// </summary>
        public Point3D Coordinate3D { get; set; }

        /// <summary>
        /// Converts Euclidian 3D-coordinate of this instance to special formated representation of System.string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("3D point coordinates:\n");
            output.Append(string.Format("X = {0}\n", this.Coordinate3D.X.ToString()));
            output.Append(string.Format("Y = {0}\n", this.Coordinate3D.Y.ToString()));
            output.Append(string.Format("Z = {0}\n", this.Coordinate3D.Z.ToString()));
            return output.ToString();
        }
    }
}
