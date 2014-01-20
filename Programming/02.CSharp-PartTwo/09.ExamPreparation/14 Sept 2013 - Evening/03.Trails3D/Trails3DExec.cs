// Task description is in the solution folder

using System.Data;

namespace Trails3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Trails3DExec
    {
        private enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }

        public static void Main()
        {
            // X, Y, Z
            int[] cuboidSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        }

        private class Player
        {
            public int Row
            {
                get;
                set;
            }

            public int Column
            {
                get;
                set;
            }

            public Direction direction
            {
                get;
                set;
            }
        }
    }
}