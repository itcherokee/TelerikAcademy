// Task definition is in the solution folder
namespace GreedyDwarf
{
    using System;
    using System.Linq;

    public class GreedyDwarfExec
    {
        public static void Main()
        {
            int[] valley = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numberOfPatterns = int.Parse(Console.ReadLine());
            int maxCoins = int.MinValue;
            for (int index = 0; index < numberOfPatterns; index++)
            {
                int?[] currentValley = new int?[valley.Length];
                for (int i = 0; i < valley.Length; i++)
                {
                    currentValley[i] = valley[i];
                }

                var pattern = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var currentPositionInValley = 0;
                int currentPatternIndex = 0;
                int currentSumOfCoins = currentValley[0].Value;
                currentValley[0] = null;
                while (currentPositionInValley >= 0 && currentPositionInValley < currentValley.Length)
                {
                    if (currentPatternIndex >= pattern.Length)
                    {
                        currentPatternIndex = 0;
                    }

                    currentPositionInValley += pattern[currentPatternIndex];
                    if (currentPositionInValley < 0 || currentPositionInValley >= currentValley.Length)
                    {
                        break;
                    }

                    if (currentPositionInValley < 0 || currentPositionInValley > currentValley.Length)
                    {
                        break;
                    }

                    currentPatternIndex++;
                    if (currentValley[currentPositionInValley].HasValue)
                    {
                        currentSumOfCoins += currentValley[currentPositionInValley].Value;
                        currentValley[currentPositionInValley] = null;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentSumOfCoins > maxCoins)
                {
                    maxCoins = currentSumOfCoins;
                }
            }

            Console.WriteLine(maxCoins);
        }
    }
}