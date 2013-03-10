using System;
using System.Collections.Generic;
using System.IO;
using My3DSpace;
using GenericClass;
using MyMatrix;
using MyAttribute;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tests for first 4 projects
            #region Projects 1, 2, 3, 4 tests
            //Euclidian3D p1 = new Euclidian3D();
            //p1.Coordinate3D = new Point3D() { X = 1, Y = 1, Z = 1 };
            //Euclidian3D p2 = new Euclidian3D();
            //p2.Coordinate3D = new Point3D() { X = 13, Y = 1, Z = 5 };
            //Console.WriteLine(p1.Coordinate3D.ToString());
            //Console.WriteLine(p2.Coordinate3D.ToString());
            //My3DSpace.Path listOfCoordinates = new My3DSpace.Path(p1.Coordinate3D);
            //listOfCoordinates.Points.Add(p2.Coordinate3D);
            //try
            //{
            //    PathStorage.Save3DPaths(listOfCoordinates.Points);
            //}
            //catch (IOException)
            //{

            //    throw new IOException("There were problem writing coordinates to file!");
            //}
            //Console.WriteLine();
            //listOfCoordinates.Points.Clear();
            //if (listOfCoordinates.Points.Count ==0)
            //{
            //    Console.WriteLine("There are no elements in the list with 3D-coordinates!");
            //    Console.WriteLine();
            //}
            //try
            //{
            //    listOfCoordinates.Points = PathStorage.Load3DPaths();
            //}
            //catch (IOException)
            //{

            //    throw new IOException("There were problem reading coordinates from file!");
            //}
            //foreach (var coordinate in listOfCoordinates.Points)
            //{
            //    Console.WriteLine(coordinate.ToString());
            //}
            #endregion

            // Tests for 5th & 6th projects (GenericList))
            #region Projects 5, 6 & 7 tests
            // test constructor
            GenericList<int> myList = new GenericList<int>();
            // test elements addition to list
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);
            myList.Add(7);
            myList.Add(8);
            // test ToString() overriding
            Console.WriteLine(myList.ToString());
            Console.WriteLine(string.Join(", ", myList));
            // test indexer (read & write)
            Console.WriteLine(myList[0].ToString());
            myList[0] = 100;
            Console.WriteLine(myList[0].ToString());
            // test InsertAt method
            myList.InsertAt(40000, 2);
            Console.WriteLine(string.Join(", ", myList));
            // Test RemoveAt method
            myList.RemoveAt(0);
            Console.WriteLine(string.Join(", ", myList));
            // test Find method
            Console.WriteLine("Index of the element with value 4 is : " + myList.Find(4));
            // test clear list
            //myList.Clear();
            Console.WriteLine(string.Join(", ", myList));
            // test Min<T>() and Max<T>() method
            Console.WriteLine("Min element: " + myList.Min<int>());
            Console.WriteLine("Max element: " + myList.Max<int>());

            #endregion

            // Tests for 8, 9 & 10 projects (GenericMatrix)
            #region Projects 8, 9 & 10 tests

            // test creation of matrix
            GenericMatrix<int> m1 = new GenericMatrix<int>(4); // square matrix
            GenericMatrix<int> m2 = new GenericMatrix<int>(5, 4);
            int[,] temp = new int[3, 5];
            GenericMatrix<int> m3 = new GenericMatrix<int>(temp);
            // GenericMatrix<DateTime> m4 = new GenericMatrix<DateTime>(3); // will cause exception because DateTime is not allowed as type

            // test indexer
            Console.WriteLine(m3[3, 5]);
            m3[3, 5] = 10;
            Console.WriteLine(m3[3, 5]);

            // test matrix addition & substraction
            int[,] add1 = new int[3, 3] { { 1, 3, 0 }, { 3, 1, 1 }, { 0, 2, 1 } };
            int[,] add2 = new int[3, 3] { { 2, 3, 0 }, { 2, 1, 2 }, { 4, 2, 1 } };
            GenericMatrix<int> addG1 = new GenericMatrix<int>(add1);
            GenericMatrix<int> addG2 = new GenericMatrix<int>(add2);
            GenericMatrix<int> addResult = addG1 + addG2;
            GenericMatrix<int> subResult = addG1 - addG2;

            //test multiplication
            int[,] mul1 = new int[3, 2] { { 1, 3 }, { 3, 1 }, { 0, 2 } };
            int[,] mul2 = new int[2, 2] { { 2, 3 }, { 2, 1 } };
            GenericMatrix<int> mulG1 = new GenericMatrix<int>(mul1);
            GenericMatrix<int> mulG2 = new GenericMatrix<int>(mul2);
            GenericMatrix<int> mulResult = mulG1 * mulG2;

            //test true operator
            int[,] zero = new int[2, 2] { { 0, 0 }, { 0, 0 } };
            GenericMatrix<int> zeroG = new GenericMatrix<int>(zero);
            Console.WriteLine(zeroG ? "Matrix is zero one." : "Matrix is non-zero one.");
            zeroG[1, 1] = 1;
            Console.WriteLine(zeroG ? "Matrix is zero one." : "Matrix is non-zero one.");

            #endregion

            // Test for 11 project (User-defined Attributes)
            #region Project 11 test

            Type type = typeof(TestAttributeClass);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in allAttributes)
            {
                Console.WriteLine("Current class version: {0}", attribute.VersionAttr);
            }

            #endregion
        }
    }
}
