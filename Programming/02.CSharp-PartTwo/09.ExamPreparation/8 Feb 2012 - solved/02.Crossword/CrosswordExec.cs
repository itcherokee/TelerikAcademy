namespace Crossword
{
    using System;
    using System.Linq;
    using System.Text;

    public class CrosswordExec
    {
        private static int[] patterns;
        private static string[] words;
        private static StringBuilder winner = new StringBuilder(36);
        private static StringBuilder verticalWord = new StringBuilder(6);

        public static void Main()
        {
            // Read input
            int size = int.Parse(Console.ReadLine());
            if (size < 1 || size > 6)
            {
                Console.WriteLine("NO SOLUTION!");
                return;
            }
            int numberOfWords = 2 * size;
            words = new string[numberOfWords];
            for (int index = 0; index < numberOfWords; index++)
            {
                words[index] = Console.ReadLine();
            }

            Array.Sort(words);

            // Generate all possible variations of words using index pattern (int) - faster
            patterns = new int[numberOfWords];

            Variate(0, size, numberOfWords);

            // There is no any variations that fulfill requirements
            Console.WriteLine("NO SOLUTION!");
        }

        private static bool Validate(int[] possibleVariation, int size, string[] words)
        {
            var matrix = new string[size];
            for (int index = 0; index < possibleVariation.Length; index++)
            {
                for (int i = 0; i < size; i++)
                {
                    matrix[i] = words[possibleVariation[i]];
                }

                // Check verticals are existing words
                bool includeVariation = true;
                verticalWord.Clear();
                for (int columns = 0; columns < size; columns++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        verticalWord.Append(matrix[i][columns]);
                       }

                    if (!words.Contains(verticalWord.ToString()))
                    {
                        includeVariation = false;
                        break;
                    }

                    verticalWord.Clear();
                }

                if (includeVariation)
                {
                    winner.Clear();
                    winner.Append(string.Join("", matrix));
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Calculates the possible variations.
        /// </summary>
        /// <param name="cuurentBound">Current bound of the variation (up to now).</param>
        /// <param name="variationSize">The total size of the variation to be constructed.</param>
        /// <param name="upperBound">The size of the numbers range that is initialy provided.</param>
        /// <param name="patterns">Array that will contain all possible pattarns.</param>
        private static void Variate(int cuurentBound, int variationSize, int upperBound)
        {
            if (variationSize == cuurentBound)
            {
                int[] variation = new int[variationSize];
                for (int index = 0; index < variationSize; index++)
                {
                    variation[index] = patterns[index];

                }

                bool result = Validate(variation, variationSize, words);
                if (result)
                {
                    int squareOfSize = variationSize * variationSize;
                    StringBuilder output = new StringBuilder();
                    output.Append(winner[0]);
                    for (int row = 1; row < squareOfSize; row++)
                    {
                        if (row % variationSize == 0)
                        {
                            output.AppendLine();
                        }

                        output.Append(winner[row]);
                    }

                    Console.WriteLine(output.ToString());
                    Environment.Exit(0);
                }

                return;
            }

            for (int index = 0; index < upperBound; index++)
            {
                patterns[cuurentBound] = index;
                Variate(cuurentBound + 1, variationSize, upperBound);
            }
        }
    }
}