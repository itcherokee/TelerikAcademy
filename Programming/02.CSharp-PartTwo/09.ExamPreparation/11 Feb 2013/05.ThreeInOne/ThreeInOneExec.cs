// Task definition is in the solution folder
namespace ThreeInOne
{
    using System;
    using System.Linq;

    public class ThreeInOneExec
    {
        public static void Main()
        {
            // input
            byte[] points = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();
            byte[] cakes = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();
            Array.Sort(cakes);
            byte numberOfFriends = byte.Parse(Console.ReadLine());
            int[] resources = Console.ReadLine().Split().Select(int.Parse).ToArray();

            // Task 1
            var winnerIndex = FindCardWinner(points);
            Console.WriteLine(winnerIndex);

            // Task 2
            var mineCakesSize = FindMineCakes(cakes, numberOfFriends);
            Console.WriteLine(mineCakesSize);

            // Task 3
            var exchanges = BuyBeer(resources);
            Console.WriteLine(exchanges); // Task 3
        }

        private static int FindCardWinner(byte[] points)
        {
            int winnerCounter = 0;
            int winnerIndex = -1;
            int winnerPoints = -1;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] <= 21)
                {
                    if (points[i] > winnerPoints)
                    {
                        winnerIndex = i;
                        winnerPoints = points[i];
                        winnerCounter = 1;
                    }
                    else if (points[i] == winnerPoints)
                    {
                        winnerCounter++;
                    }
                }

                if (winnerCounter > 1 && i == points.Length - 1)
                {
                    winnerIndex = -1;
                    break;
                }
            }

            return winnerIndex;
        }

        private static int FindMineCakes(byte[] cakes, byte numberOfFriends)
        {
            int mineCakesSize = 0;
            for (int i = cakes.Length - 1; i >= 0; i -= numberOfFriends + 1)
            {
                mineCakesSize += cakes[i];
            }

            return mineCakesSize;
        }

        private static int BuyBeer(int[] resources)
        {
            int exchanges = -1;

            // Check does we have enough money
            int mineTotalBronze = resources[2] + (9 * (resources[1] + (9 * resources[0])));
            int beerTotalBronze = resources[5] + (9 * (resources[4] + (9 * resources[3])));
            if (mineTotalBronze >= beerTotalBronze)
            {
                exchanges = 0;
                bool buy = false;
                if (resources[0] < resources[3] || resources[1] < resources[4] || resources[2] < resources[5])
                {
                    while (!buy)
                    {
                        bool sellGold = false;
                        bool sellSilver = false;
                        bool sellBronze = false;

                        // If gold is more, we can sell it
                        if (resources[0] > resources[3])
                        {
                            sellGold = true;
                        }

                        // if silver is more, we can sell it
                        if (resources[1] > resources[4])
                        {
                            sellSilver = true;
                        }

                        // If bronze is more, we can sell it
                        if (resources[2] > resources[5])
                        {
                            sellBronze = true;
                        }

                        int needGold = resources[0] - resources[3];
                        int needSilver = resources[1] - resources[4];
                        int needBronze = resources[2] - resources[5];

                        if (needGold < 0 && sellSilver)
                        {
                            // Sell silver for gold
                            resources[1] -= 11;
                            resources[0]++;
                            exchanges++;
                        }
                        else if (needGold < 0 && sellBronze)
                        {
                            // Sell bronze for gold (through silver)
                            resources[2] -= 11;
                            resources[1]++;
                            exchanges++;
                        }
                        else if (needSilver < 0 && sellGold)
                        {
                            // Sell gold for silver
                            resources[0]--;
                            resources[1] += 9;
                            exchanges++;
                        }
                        else if (needSilver < 0 && sellBronze)
                        {
                            // Sell bronze for silver
                            resources[2] -= 11;
                            resources[1]++;
                            exchanges++;
                        }
                        else if (needBronze < 0 && sellSilver)
                        {
                            // Sell silver for bronze
                            resources[1]--;
                            resources[2] += 9;
                            exchanges++;
                        }
                        else if (needBronze < 0 && sellGold)
                        {
                            // Sell gold for bronze (through silver)
                            resources[0]--;
                            resources[1] += 9;
                            exchanges++;
                        }

                        if (resources[0] >= resources[3] && resources[1] >= resources[4] && resources[2] >= resources[5])
                        {
                            buy = true;
                        }
                    }
                }
            }

            return exchanges;
        }
    }
}
