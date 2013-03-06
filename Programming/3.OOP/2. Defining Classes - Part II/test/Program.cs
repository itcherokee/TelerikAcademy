using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My3DSpace;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Euclidian3D p1 = new Euclidian3D();
            p1.Coordinate3D = new Point3D() { x = 1, y = 1, z = 1 };
            Euclidian3D p2 = new Euclidian3D();
            p2.Coordinate3D = new Point3D() { x = 1, y = 1, z = 5 };
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine(Distance3D.CalcDistance3D(p1,p2));

        }
    }
}
