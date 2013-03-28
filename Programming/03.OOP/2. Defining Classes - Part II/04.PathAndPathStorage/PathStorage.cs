// Create a static class PathStorage with static methods to save and load paths from a text file. Use a file format of your choice.

namespace My3DSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public static class PathStorage
    {
        private static string path = Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "coordinates.txt";

        /// <summary>
        /// Saves the 3D-coordinates located in the list of points in 3Dspace to a text file
        /// </summary>
        /// <param name="points">Reference to a list of 3D-coordinates</param>
        public static void Save3DPaths(List<Point3D> points)
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
        /// Loads the 3D-coordinates located in the text file to a list of points in 3Dspace. Returns a List of Point3D coordinates.
        /// </summary>
        /// <param name="points">Reference to the list of 3D-coordinates where data to be loaded</param>
        public static List<Point3D> Load3DPaths()
        {
            // temporary string array to hold the string line returned by reading a single line from text file
            string[] lineOfCoordinates = new string[3];

            // instantiates the List to be returned
            List<Point3D> listCoordinates = new List<Point3D>();

            using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
            {
                while (reader.Peek() > -1)
                {
                    // declate an struct that is going to hold the 3 parts of the single 3D-coordinate {x,y,z}
                    Point3D coordinates = Euclidian3D.CoordinateCenter;
                    try
                    {
                        lineOfCoordinates = reader.ReadLine().Trim().Split((char)9);

                        // convert each component of 3D-coordinate to daouble and add it to the List of 3-D coordinates
                        coordinates.X = double.Parse(lineOfCoordinates[0]);
                        coordinates.Y = double.Parse(lineOfCoordinates[1]);
                        coordinates.Z = double.Parse(lineOfCoordinates[2]);
                        listCoordinates.Add(coordinates);
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
