// Task 4: {...} 
// Create a static class PathStorage with static methods to save and load paths from a text file. 
// Use a file format of your choice.

namespace Euclidian3DSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class PathStorage
    {
        private static string fileName = "coordinates.txt";
        private static string path = Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + fileName;

        /// <summary>
        /// Saves the 3D-points located in the list of points in 3Dspace to a text file.
        /// </summary>
        /// <param name="points">Reference to a list of 3D-coordinates.</param>
        public static void Save(IEnumerable<Point3D> points)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (var coordinate in points)
                {
                    writer.WriteLine(coordinate.X + "\t" + coordinate.Y + "\t" + coordinate.Z);
                }
            }
        }

        /// <summary>
        /// Loads the 3D-points located in the text file to a list of points in 3Dspace. 
        /// </summary>
        /// <returns>Returns an <param name="Path"/> list of Point3D objects, representing points in space.</returns>
        public static Path Load()
        {
            // temporary string array to hold the string line returned by reading a single line from text file

            // instantiates the List to be returned
            var listCoordinates = new Path();
            
            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                while (reader.Peek() > -1)
                {
                    // declate an struct that is going to hold the 3 parts of the single 3D-coordinate {x,y,z}
                    Point3D point = new Point3D();
                    try
                    {
                        var line = reader.ReadLine();
                        if (line != null)
                        {
                            string[] lineWithCoordinates = line.Trim().Split((char)9);

                            // convert each component of 3D-coordinate to daouble and add it to the List of 3-D coordinates
                            point.X = double.Parse(lineWithCoordinates[0]);
                            point.Y = double.Parse(lineWithCoordinates[1]);
                            point.Z = double.Parse(lineWithCoordinates[2]);
                            listCoordinates.Add(point);
                        }
                    }
                    catch
                    {
                        // handling exception if some of the coordinates are not numbers
                        throw new ArgumentOutOfRangeException("There are values which are not valid coordinates in the text file!.");
                    }
                }
            }

            return listCoordinates;
        }
    }
}
