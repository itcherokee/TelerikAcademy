using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _05.Help_Doge
{
    class Program
    {
        private static void Main(string[] args)
        {
            // N (vertical - row), M (horizontal - column)
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] grid = new int[dimensions[0], dimensions[1]];
            // Fx (vertical - row), Fy (horizontal - column)
            int[] food = Console.ReadLine().Split().Select(int.Parse).ToArray();
            grid[food[0], food[1]] = 1; // 1 is for food

            // enemies
            int numberOfEnemies = int.Parse(Console.ReadLine());

            // enemies locations
            int[] coordinates = new int[2];

            for (int i = 0; i < numberOfEnemies; i++)
            {
                coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                grid[coordinates[0], coordinates[1]] = 2; // 2 is for enemy
            }

            // calculate shortes path
            int dogX = 0;
            int dogY = 0;
            int routeCounters = 0;

            // Check does food is surrounded by enemies
            bool leftBorder = food[1] == 0 ? true : false;
            bool rightBorder = food[1] == dimensions[1] ? true : false;
            bool topBorder = food[0] == 0 ? true : false;
            bool bottomBorder = food[0] == dimensions[0] ? true : false;
            int topPossibilities = topBorder ? 0 : leftBorder && rightBorder ? 1 : leftBorder ^ rightBorder ? 2 : 3;
            int bottomPossibilities = bottomBorder ? 0 : leftBorder && rightBorder ? 1 : leftBorder ^ rightBorder ? 2 : 3;
            int leftPossibilities = leftBorder ? 0 : topBorder && bottomBorder ? 1 : topBorder ^ bottomBorder ? 2 : 3;
            int rightPossibilities = rightBorder ? 0 : topBorder && bottomBorder ? 1 : topBorder ^ bottomBorder ? 2 : 3;

            if (topPossibilities + bottomPossibilities + leftPossibilities + rightPossibilities == 0)
            {
                Console.WriteLine(0);
            }

            Console.WriteLine(1);


            while (dogX != food[0] && dogY != food[1])
            {

            }

            int currentX = 0;
            int currentY = 1;
            while (true)
            {
                while (dogX != food[0] && dogY != food[1])
                {
                    if()
                }
            }
        }

        private static bool CheckIsOnlyOneDirection(int[,] grid, int x, int y, Direction goingTo)
        {
            switch (goingTo)
            {
                case Direction.Right:
                    if (grid[x + 1, y] != 0 ^ grid[x, y + 1] != 0)
                    {
                        return 
                    }
                    break;
            }
            {

            }

        }

        enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }
    }
}
