// Task 1: Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
//         Implement the ToString() to enable printing a 3D point.
// Task 2: Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}. 
//         Add a static property to return the point O.

namespace Euclidian3DSpace
{
    using System.Text;

    /// <summary>
    /// Defines representation of 3D-coordinate point in Euclidian 3D space.
    /// </summary>
    public struct Point3D
    {
        private static readonly Point3D CoordinateCenter;

        /// <summary>
        /// Static constructor initializing the static field <paramref name="center"/>
        /// pointing to the center of Euclidian 3D space.
        /// </summary>
        static Point3D()
        {
            CoordinateCenter.X = 0;
            CoordinateCenter.Y = 0;
            CoordinateCenter.Z = 0;
        }

        /// <summary>
        /// Instantiates a point in Eucliaidan 3D space.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = x;
            this.Z = z;
        }

        public static Point3D CenterPoint
        {
            get { return CoordinateCenter; }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        /// <summary>
        /// Converts Euclidian 3D-coordinate to special formated representation of System.string
        /// </summary>
        /// <returns>3D point coordinates.</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            // output.Append("3D point coordinates: (");
            output.Append(string.Format("(X = {0}, Y = {1}, Z = {2})", this.X, this.Y, this.Z));

            // output.Append(string.Format("Y = {0}, ", this.Y));
            // output.Append(string.Format("Z = {0})", this.Z));
            return output.ToString();
        }
    }
}