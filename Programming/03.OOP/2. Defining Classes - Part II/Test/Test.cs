// Test code for evaluating all methods in the homework

namespace Test
{
    using System;
    using System.IO;
    using Euclidian3DSpace;
    using GenericListCollection;
    using GenericMatrix;
    using VersionAttribute;

    public class Test
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Test for Tasks: 1, 2, 3, 4 - Euclidian 3D space\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Tasks 1, 2, 3, 4 tests

            // Creating two objects of type Point3D
            Point3D p1 = new Point3D() { X = 1, Y = 1, Z = 1 };
            Point3D p2 = new Point3D() { X = 13.9, Y = 1, Z = 5 };
            Console.WriteLine("Point 1 coordinates: " + p1.ToString());
            Console.WriteLine("Point 2 coordinates: " + p2.ToString());
            Console.WriteLine("Distance between two points is: {0}", Distance3D.Distance(p1, p2));

            // Creating object of type Path and load points into it
            // (it is necessary to use namespace to distinguish it from IO.Path)
            Euclidian3DSpace.Path listOfPoints = new Euclidian3DSpace.Path { p1, p2 };
            listOfPoints.Add(new Point3D(10, 10, 10.2));

            // Save to file the list of 3D points
            try
            {
                PathStorage.Save(listOfPoints);
                Console.WriteLine("3D points list has been saved to file!");
            }
            catch (IOException)
            {
                throw new IOException("There were problem writing coordinates to file!");
            }

            // Clear list of points
            Console.Write("Lets clear the list with points: ");
            listOfPoints.Clear();
            if (listOfPoints.Count == 0)
            {
                Console.WriteLine("There are no any points in the list!");
            }

            // Load from file the list of points
            try
            {
                listOfPoints = PathStorage.Load();
                Console.WriteLine("3D points has been loaded from file into list!");
            }
            catch (IOException)
            {
                throw new IOException("There were problem reading coordinates from file!");
            }

            // Output to Console the loaded list
            Console.WriteLine("Loaded list:");
            foreach (var coordinate in listOfPoints)
            {
                Console.WriteLine(coordinate.ToString());
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress a key to continue with next tasks tests...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Test for Tasks: 5, 6, 7 - GenericList<T>\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Tasks 5, 6 & 7 tests

            // Create list
            GenericList<int> myList = new GenericList<int>();

            // Test elements addition to list
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);

            Console.Write("Test foreach capability: ");
            foreach (var element in myList)
            {
                Console.Write(element);
                Console.Write(" ");
            }

            // Test clear list
            Console.Write("\nTest clear list: ");
            myList.Clear();
            Console.WriteLine(myList.ToString());

            // Test ToString() overriding
            Console.WriteLine("\nTest ToString() overriding:");
            myList.Add(0);
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            Console.WriteLine(myList.ToString());

            // Test indexer (read & write)
            Console.Write("Test indexer - element[0] = {0}, after change = ", myList[0]);
            myList[0] = 100;
            Console.WriteLine(myList[0].ToString());

            // Test InsertAt method
            Console.Write("Test InsertAt() - insert 40000 at index 2: ");
            myList.InsertAt(40000, 2);
            Console.WriteLine(string.Join(", ", myList));

            // Test RemoveAt method
            Console.Write("Test RemoveAt() - remove element at position 0: ");
            myList.RemoveAt(0);
            Console.WriteLine(string.Join(", ", myList));

            // Test Find method
            Console.WriteLine("Test Find() - index of the element with value 4 is : " + myList.Find(4));

            // Test Min<T>() and Max<T>() method
            Console.WriteLine("Test Min<T>() and Max<T>():\nMin element: " + myList.Min());
            Console.WriteLine("Max element: " + myList.Max());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress a key to continue with next tasks tests...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Test for Tasks: 8, 9 ,10 - Matrix<T>\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Tasks 8, 9 & 10 tests

            // test constructors
            Matrix<int> m1 = new Matrix<int>(4); // square matrix
            Matrix<int> m2 = new Matrix<int>(5, 4); // dimensions
            Matrix<int> m3 = new Matrix<int>(new int[3, 5]); // other matrix structure - array

            // Next line if uncommented will cause exception because DateTime is not allowed as type
            // Matrix<DateTime> m4 = new Matrix<DateTime>(3); 

            // Test indexer
            Console.WriteLine("Value at position [{0},{1}] is {2}", 3, 5, m3[3, 5]);
            m3[3, 5] = 10;
            Console.WriteLine("Value at position [{0},{1}] after change is {2}", 3, 5, m3[3, 5]);

            // Test matrix addition & substraction
            Matrix<int> matrixOne = new Matrix<int>(new[,] { { 1, 3, 0 }, { 3, 1, 1 }, { 0, 2, 1 } });
            Matrix<int> matrixTwo = new Matrix<int>(new[,] { { 2, 3, 0 }, { 2, 1, 2 }, { 4, 2, 1 } });
            Matrix<int> addResult = matrixOne + matrixTwo;
            Matrix<int> subResult = matrixOne - matrixTwo;

            // Test multiplication
            Matrix<int> multiplyOne = new Matrix<int>(new[,] { { 1, 3 }, { 3, 1 }, { 0, 2 } });
            Matrix<int> multiplyTwo = new Matrix<int>(new[,] { { 2, 3 }, { 2, 1 } });
            Matrix<int> mulResult = multiplyOne * multiplyTwo;

            // Test true operator
            Matrix<int> zero = new Matrix<int>(new[,] { { 0, 0 }, { 0, 0 } });
            Console.WriteLine(zero ? "Matrix is non-zero one." : "Matrix is zero one.");
            zero[1, 1] = 1;
            Console.WriteLine(zero ? "Matrix is non-zero one." : "Matrix is zero one.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress a key to continue with next tasks tests...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Test for Tasks: 11 - User-defined Attributes\n");
            Console.ForegroundColor = ConsoleColor.White;

            // Task 11 test
            Type type = typeof(TestAttributeClass);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in allAttributes)
            {
                Console.WriteLine("Current class version: {0}", attribute.Version);
            }
        }
    }
}