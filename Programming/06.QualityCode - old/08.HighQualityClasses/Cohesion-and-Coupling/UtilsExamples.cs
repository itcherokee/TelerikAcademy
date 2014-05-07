// Take the VS solution "Cohesion-and-Coupling" and refactor its code to follow the principles of good abstraction, 
// loose coupling and strong cohesion. Split the class Utils to other classes that have strong cohesion and are 
// loosely coupled internally.

namespace CohesionAndCoupling
{
    using System;

    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Point pointOne = new Point(1, -2);
            Point pointTwo = new Point(3, 4);
            Console.WriteLine("Distance in the 2D space = {0:f2}", GraphicsUtils.CalculateDistance(pointOne, pointTwo));
            pointOne = new Point(5, 2, -1);
            pointTwo = new Point(3, -6, 4);
            Console.WriteLine("Distance in the 3D space = {0:f2}", GraphicsUtils.CalculateDistance(pointOne, pointTwo));

            pointOne = new Point(0, 0, 0);
            pointTwo = new Point(1, 0, 0);
            Point pointThree = new Point(0, 1, 0);
            Point pointFour = new Point(0, 0, 1);
            Point farPoint = new Point(1, 1, 1);

            Console.WriteLine("Volume = {0:f2}", GraphicsUtils.CalcVolume(pointOne, pointTwo, pointThree, pointFour));
            Console.WriteLine("Diagonal XYZ = {0:f2}", GraphicsUtils.CalcDistanceToCenter(farPoint));
            Console.WriteLine("Diagonal XY = {0:f2}", GraphicsUtils.CalcDistanceToCenter(pointTwo));
            Console.WriteLine("Diagonal XZ = {0:f2}", GraphicsUtils.CalcDistanceToCenter(pointFour));
            Console.WriteLine("Diagonal YZ = {0:f2}", GraphicsUtils.CalculateDistance(pointThree, pointFour));
        }
    }
}
