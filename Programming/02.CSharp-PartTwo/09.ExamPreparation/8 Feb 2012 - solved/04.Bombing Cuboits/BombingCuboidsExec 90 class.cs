// This solution is using classes for representing bombs & points
/*
namespace BombingCuboits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class BombingCuboitsExec
    {
        private static SortedDictionary<char, int> destroyedBricks = new SortedDictionary<char, int>();

        public static void Main()
        {
            // Data input
            // 1.Cuboid
            byte[] dimensions = Console.ReadLine().Split().Select(byte.Parse).ToArray();
            byte width = dimensions[0];
            byte height = dimensions[1];
            byte depth = dimensions[2];
            char[,,] cuboid = new char[height, width, depth];

            // 2.Bricks' color
            for (int h = height - 1; h >= 0; h--)
            {
                string[] colors = Console.ReadLine().Split();
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cuboid[h, w, d] = colors[d][w];
                    }
                }
            }

            // 3.Number of bombs
            byte bombNumber = byte.Parse(Console.ReadLine());

            // 4.Bombs' coordinates and power (w - column,h - row[oposite],d - depth,p - power)
            Bomb[] bombsP = new Bomb[bombNumber];
            for (int b = 0; b < bombNumber; b++)
            {
                byte[] lineBomb = Console.ReadLine().Split().Select(byte.Parse).ToArray();
                Bomb bomb = new Bomb();
                bomb.Width = lineBomb[0];
                bomb.Height = Convert.ToByte(height - 1 - lineBomb[1]);
                bomb.Depth = lineBomb[2];
                bomb.Power = lineBomb[3];
                bombsP[b] = bomb;
            }

            // Start bombing
            for (int index = 0; index < bombNumber; index++)
            {
                // Bomb is blown
                CalculateDamage(cuboid, bombsP[index]);
                ForceGravity(cuboid);
            }

            // Output to Console the result
            // Sum colors = cubes destroyed and output to screen
            Console.WriteLine(destroyedBricks.Sum(x => x.Value));

            // Show colors + number per color
            foreach (var color in destroyedBricks)
            {
                Console.WriteLine("{0} {1}", color.Key.ToString().ToUpper(), color.Value);
            }
        }

        // Enforce the Gravity over cuboid
        private static void ForceGravity(char[,,] cuboid)
        {
            for (int cubDepth = 0; cubDepth < cuboid.GetLength(2); cubDepth++)
            {
                for (int cubColumn = cuboid.GetLength(1) - 1; cubColumn >= 0; cubColumn--)
                {
                    char[] newColumn = new char[cuboid.GetLength(0)];
                    int columnRow = newColumn.Length - 1;
                    for (int cubRow = cuboid.GetLength(0) - 1; cubRow >= 0; cubRow--)
                    {
                        // Find all CAPS and fill them in new array from bottom the way they have been discovered - moving up
                        if ((byte)cuboid[cubRow, cubColumn, cubDepth] >= 65 &&
                            (byte)cuboid[cubRow, cubColumn, cubDepth] <= 90)
                        {
                            newColumn[columnRow] = cuboid[cubRow, cubColumn, cubDepth];
                            columnRow--;
                        }
                    }

                    for (int cubRow = cuboid.GetLength(0) - 1; cubRow >= 0; cubRow--)
                    {
                        // Find all SMALL and fill them in new array from last CAPS the way they have been discovered - moving up
                        if ((byte)cuboid[cubRow, cubColumn, cubDepth] >= 97 &&
                                (byte)cuboid[cubRow, cubColumn, cubDepth] <= 122)
                        {
                            newColumn[columnRow] = cuboid[cubRow, cubColumn, cubDepth];
                            columnRow--;
                        }
                    }

                    // Copy temp array (gravity ordered) to cuboid column
                    for (int row = 0; row < cuboid.GetLength(0); row++)
                    {
                        cuboid[row, cubColumn, cubDepth] = newColumn[row];
                    }
                }
            }
        }

        // Calculates what damages caused the blown bomb and apply to cuboid
        private static void CalculateDamage(char[,,] cuboid, Bomb bomb)
        {
            Point cube = new Point();
            for (byte row = 0; row < cuboid.GetLength(0); row++)
            {
                for (byte column = 0; column < cuboid.GetLength(1); column++)
                {
                    for (byte depth = 0; depth < cuboid.GetLength(2); depth++)
                    {
                        cube.Width = column;
                        cube.Height = row;
                        cube.Depth = depth;
                        double distance = Distance(bomb, cube);
                        if (distance <= bomb.Power && ((byte)cuboid[row, column, depth] >= 65 &&
                            (byte)cuboid[row, column, depth] <= 90))
                        {
                            cuboid[row, column, depth] = cuboid[row, column, depth].ToString().ToLower()[0];
                            if (destroyedBricks.ContainsKey(cuboid[row, column, depth]))
                            {
                                // color exist, so we increment by one
                                destroyedBricks[cuboid[row, column, depth]]++;
                            }
                            else
                            {
                                // color is first met, so we add it and set it's value to 1
                                destroyedBricks.Add(cuboid[row, column, depth], 1);
                            }
                        }
                    }
                }
            }
        }

        // Calculates distance between two points in Euclidian 3D space
        private static double Distance(Point bomb, Point cube)
        {
            int pq1 = (bomb.Height - cube.Height) * (bomb.Height - cube.Height);
            int pq2 = (bomb.Width - cube.Width) * (bomb.Width - cube.Width);
            int pq3 = (bomb.Depth - cube.Depth) * (bomb.Depth - cube.Depth);
            return Math.Sqrt(pq1 + pq2 + pq3);
        }

        public class Point
        {
            public byte Width { get; set; }
            public byte Height { get; set; }
            public byte Depth { get; set; }
        }

        public class Bomb : Point
        {
            public byte Power { get; set; }
        }
    }
}
*/