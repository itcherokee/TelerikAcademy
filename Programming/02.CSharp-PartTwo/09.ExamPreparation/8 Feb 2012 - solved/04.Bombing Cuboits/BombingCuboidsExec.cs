// This solution use arrays for bombs. Other one is using classes.

using System.Globalization;
using System.Text;

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
            char[, ,] cuboid = new char[height, width, depth];

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
            byte[][] bombs = new byte[bombNumber][]; // will hold: row, column, depth, power
            for (int b = 0; b < bombNumber; b++)
            {
                byte[] lineBomb = Console.ReadLine().Split().Select(byte.Parse).ToArray();
                bombs[b] = new byte[4];
                bombs[b][0] = Convert.ToByte(height - 1 - lineBomb[1]);
                bombs[b][1] = lineBomb[0];
                bombs[b][2] = lineBomb[2];
                bombs[b][3] = lineBomb[3];
            }

            // Start bombing
            for (int index = 0; index < bombNumber; index++)
            {
                // Bomb is blown
                CalculateDamage(cuboid, bombs[index]);
                ForceGravity(cuboid);
            }

            StringBuilder output = new StringBuilder();

            // Output to Console the result
            output.AppendLine(destroyedBricks.Sum(x => x.Value).ToString());

            // Show colors + number per color
            foreach (var color in destroyedBricks)
            {
                output.Append(string.Format("{0} {1}\n", color.Key.ToString() .ToUpperInvariant(), color.Value));
            }

            Console.Write(output.ToString());
        }

        // Counts number of colors destroyed (only SMALL letters) in the cuboid
        private static SortedDictionary<char, int> CountColors(char[, ,] cuboid)
        {
            SortedDictionary<char, int> colors = new SortedDictionary<char, int>();
            for (int row = 0; row < cuboid.GetLength(0); row++)
            {
                for (int column = 0; column < cuboid.GetLength(1); column++)
                {
                    for (int depth = 0; depth < cuboid.GetLength(2); depth++)
                    {
                        if ((byte)cuboid[row, column, depth] >= 97 &&
                               (byte)cuboid[row, column, depth] <= 122)
                        {
                            if (colors.ContainsKey(cuboid[row, column, depth]))
                            {
                                // color exist, so we increment by one
                                colors[cuboid[row, column, depth]]++;
                            }
                            else
                            {
                                // color is first met, so we add it and set it's value to 1
                                colors.Add(cuboid[row, column, depth], 1);
                            }
                        }
                    }
                }
            }

            return colors;
        }

        // Enforce the Gravity over cuboid
        private static void ForceGravity(char[, ,] cuboid)
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
        private static void CalculateDamage(char[, ,] cuboid, byte[] bomb)
        {
            // Point cube = new Point();
            for (byte row = 0; row < cuboid.GetLength(0); row++)
            {
                for (byte column = 0; column < cuboid.GetLength(1); column++)
                {
                    for (byte depth = 0; depth < cuboid.GetLength(2); depth++)
                    {
                        double distance = Distance(bomb, row, column, depth);
                        if (distance <= bomb[3] && ((byte)cuboid[row, column, depth] >= 65 &&
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
        private static double Distance(byte[] bomb, byte row, byte column, byte depth)
        {
            int pq1 = (bomb[0] - row) * (bomb[0] - row);
            int pq2 = (bomb[1] - column) * (bomb[1] - column);
            int pq3 = (bomb[2] - depth) * (bomb[2] - depth);
            return Math.Sqrt(pq1 + pq2 + pq3);
        }
    }
}