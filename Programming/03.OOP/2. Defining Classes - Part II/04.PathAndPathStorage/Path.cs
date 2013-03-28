// Create a class Path to hold a sequence of points in the 3D space. 

namespace My3DSpace
{
    using System;
    using System.Collections.Generic;

    public class Path
    {
        /// <summary>
        /// Represents a list with 3D-coordinates 
        /// </summary>
        public List<Point3D> Points { get; set; }

        /// <summary>
        /// Constructor that instantiates the List of 3D-coordinates
        /// </summary>
        public Path()
        {
            this.Points = new List<Point3D>();
        }

        /// <summary>
        /// Constructor that instantiates the List of 3D-coordinates and add first 3D-coordinate to the list 
        /// </summary>
        /// <param name="coordinate">3D-coordinate to be added as first member in the list</param>
        public Path(Point3D coordinate)
            : this()
        {
            this.Points.Add(coordinate);
        }
    }
}
