// Task definition is in the solution folder
namespace Tron3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    enum Direction
    {
        North,
        East,
        South,
        West,
    }

    public class Tron3DExec
    {
        public static void Main()
        {
            // x, y, z
            byte[] dimensions = Console.ReadLine().Split().Select(byte.Parse).ToArray();
            byte[,] playboard = new byte[dimensions[0], dimensions[1] * 2 + dimensions[2] * 2];

            string PlayerOneMoves;
            string PlayerTwoMoves;

        }
    }

    internal class Player
    {
        byte startPositionX;
        byte startPositionY;
        byte currentPositionX;
        byte currentPositionY;
        Direction direction;



    }


}
