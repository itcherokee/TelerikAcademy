// Task description is in the solution folder
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
            int[] sizes = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            // Create cuboid
            char[,] cuboid = new char[sizes[1] + 1, 2 * (sizes[0] + 1) + 2 * (sizes[2] - 1)];

            // Read player 1 moves and parse
            string playerOneMoves = ParseMoves(Console.ReadLine().Trim());

            // Read player 2 moves and parse
            string playerTwoMoves = ParseMoves(Console.ReadLine().Trim());

            // Initialize players
            int pointX = sizes[0] / 2;
            int pointY = sizes[1] / 2;
            Player playerOne = new Player(pointX, pointY, Direction.Right, cuboid.GetLength(1), cuboid.GetLength(0));
            cuboid[playerOne.Y, playerOne.X] = 'r';


            pointX = sizes[0] + sizes[2] + sizes[0] / 2;
            Player playerTwo = new Player(pointX, pointY, Direction.Left, cuboid.GetLength(1), cuboid.GetLength(0));
            cuboid[playerTwo.Y, playerTwo.X] = 'b';

            // Game engine
            int moveIndex = 0;
            while (true)
            {

                // Check direction of player 1
                if (!playerOneMoves[moveIndex].Equals('M'))
                {
                    playerOne.Turn(playerOneMoves[moveIndex]);
                }

                // Check direction of player 2
                if (!playerTwoMoves[moveIndex].Equals('M'))
                {
                    playerTwo.Turn(playerTwoMoves[moveIndex]);
                }

                // Move player 1
                playerOne.Move();
                if (!playerOne.IsCrashed && cuboid[playerOne.Y, playerOne.X].Equals('\0'))
                {
                    cuboid[playerOne.Y, playerOne.X] = 'r';
                }
                else
                {
                    playerOne.IsCrashed = true;
                }

                // Move player 2
                playerTwo.Move();
                if (!playerTwo.IsCrashed && cuboid[playerTwo.Y, playerTwo.X].Equals('\0'))
                {
                    cuboid[playerTwo.Y, playerTwo.X] = 'b';
                }
                else if (playerOne.X == playerTwo.X && playerOne.Y == playerTwo.Y)
                {
                    playerOne.IsCrashed = true;
                    playerTwo.IsCrashed = true;

                }
                else
                {
                    playerTwo.IsCrashed = true;
                }

                // Check for crashes else occupy cell in the board
                if (playerOne.IsCrashed && playerTwo.IsCrashed)
                {
                    Console.WriteLine("DRAW");
                    break;
                }

                if (playerOne.IsCrashed && !playerTwo.IsCrashed)
                {
                    Console.WriteLine("BLUE");
                    break;
                }

                if (!playerOne.IsCrashed && playerTwo.IsCrashed)
                {
                    Console.WriteLine("RED");
                    break;
                }

                moveIndex++;
            }

            // Calculate red player distance&  Print result
            Console.WriteLine(CalculateRedDistance(playerOne));
        }

        private static string ParseMoves(string originalMoves)
        {
            StringBuilder moves = new StringBuilder();
            int index = 0;
            while (index < originalMoves.Length)
            {
                if (char.IsDigit(originalMoves[index]))
                {
                    var tempIndex = 0;
                    while (char.IsDigit(originalMoves[index+tempIndex]))
                    {
                        tempIndex++;
                    }

                    moves.Append(new string('M', int.Parse(originalMoves.Substring(index, tempIndex))));
                    index += tempIndex + 1;
                }
                else
                {
                    moves.Append(originalMoves[index]);
                    index++;
                }
            }

            return moves.ToString();
        }


        private class Player
        {
            public Player(int x, int y, Direction direction, int width, int height)
            {
                this.StartX = x;
                this.StartY = y;
                this.X = StartX;
                this.Y = StartY;
                this.Direction = direction;
                this.IsCrashed = false;
            }

            public static int BoardWidth { get; set; }
            public static int BoardHeight { get; set; }
            public int StartX { get; set; }
            public int StartY { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsCrashed { get; set; }
            public Direction Direction { get; set; }

            public void Turn(char command)
            {
                switch (command)
                {
                    case 'R':
                        switch (this.Direction)
                        {
                            case Direction.Up:
                                this.Direction = Direction.Right;
                                break;
                            case Direction.Down:
                                this.Direction = Direction.Left;
                                break;
                            case Direction.Left:
                                this.Direction = Direction.Up;
                                break;
                            case Direction.Right:
                                this.Direction = Direction.Down;
                                break;
                        }

                        break;

                    case 'L':
                        switch (this.Direction)
                        {
                            case Direction.Up:
                                this.Direction = Direction.Left;
                                break;
                            case Direction.Down:
                                this.Direction = Direction.Right;
                                break;
                            case Direction.Left:
                                this.Direction = Direction.Down;
                                break;
                            case Direction.Right:
                                this.Direction = Direction.Up;
                                break;
                        }

                        break;
                }
            }

            public void Move()
            {
                switch (this.Direction)
                {
                    case Direction.Up:
                        if (this.Y == 0)
                        {
                            IsCrashed = true;
                            //this.Y = -1;
                        }
                        else
                        {
                            this.Y--;
                        }

                        break;
                    case Direction.Down:
                        if (this.Y == BoardHeight - 1)
                        {
                            IsCrashed = true;
                            //this.Y = -1;
                        }
                        else
                        {
                            this.Y++;
                        }

                        break;
                    case Direction.Left:
                        if (this.X == 0)
                        {
                            this.X = BoardWidth - 1;
                        }
                        else
                        {
                            this.X--;
                        }

                        break;
                    case Direction.Right:
                        if (this.X == BoardWidth - 1)
                        {
                            this.X = 0;
                        }
                        else
                        {
                            this.X++;
                        }
                        break;
                }
            }
        }

        private static int CalculateRedDistance(Player red)
        {
            return Math.Abs(red.Y - red.StartY) + Math.Abs(red.X - red.StartX);
        }
    }
}