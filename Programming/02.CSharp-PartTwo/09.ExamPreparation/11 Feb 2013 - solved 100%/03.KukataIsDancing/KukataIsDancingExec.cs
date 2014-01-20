// Task definition is in the solution folder
namespace KukataIsDancing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class KukataIsDancingExec
    {
        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public static void Main()
        {
            string[,] cube = new[,] { { "RED", "BLUE", "RED" }, { "BLUE", "GREEN", "BLUE" }, { "RED", "BLUE", "RED" } };
            List<char[]> dances = new List<char[]>();
            byte numberOfDances = byte.Parse(Console.ReadLine());
            for (int index = 0; index < numberOfDances; index++)
            {
                char[] moves = Console.ReadLine().Select(x => x).ToArray();
                dances.Add(moves);
            }

            for (int dance = 0; dance < dances.Count; dance++)
            {
                Position position = new Position(1, 1);
                byte move = 0;
                Direction direction = Direction.Up;
                while (move < dances[dance].Length)
                {
                    switch (dances[dance][move])
                    {
                        case 'L':
                            switch (direction)
                            {
                                case Direction.Up:
                                    direction = Direction.Left;
                                    break;
                                case Direction.Down:
                                    direction = Direction.Right;
                                    break;
                                case Direction.Left:
                                    direction = Direction.Down;
                                    break;
                                case Direction.Right:
                                    direction = Direction.Up;
                                    break;
                            }

                            break;
                        case 'R':
                            switch (direction)
                            {
                                case Direction.Up:
                                    direction = Direction.Right;
                                    break;
                                case Direction.Down:
                                    direction = Direction.Left;
                                    break;
                                case Direction.Left:
                                    direction = Direction.Up;
                                    break;
                                case Direction.Right:
                                    direction = Direction.Down;
                                    break;
                            }

                            break;
                        case 'W':
                            switch (direction)
                            {
                                case Direction.Up:
                                    if (position.Row == 0)
                                    {
                                        position.Row = 2;
                                    }
                                    else
                                    {
                                        position.Row--;
                                    }

                                    break;
                                case Direction.Down:
                                    if (position.Row == 2)
                                    {
                                        position.Row = 0;
                                    }
                                    else
                                    {
                                        position.Row++;
                                    }

                                    break;
                                case Direction.Left:
                                    if (position.Column == 0)
                                    {
                                        position.Column = 2;
                                    }
                                    else
                                    {
                                        position.Column--;
                                    }

                                    break;
                                case Direction.Right:
                                    if (position.Column == 2)
                                    {
                                        position.Column = 0;
                                    }
                                    else
                                    {
                                        position.Column++;
                                    }

                                    break;
                            }

                            break;
                    }

                    move++;
                }

                Console.WriteLine(cube[position.Row, position.Column]);
            }
        }

        private class Position
        {
            public Position(byte row, byte column)
            {
                this.Row = row;
                this.Column = column;
            }

            public byte Row
            {
                get;
                set;
            }

            public byte Column
            {
                get;
                set;
            }
        }
    }
}