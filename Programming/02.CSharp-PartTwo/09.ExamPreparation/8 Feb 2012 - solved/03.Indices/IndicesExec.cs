using System.Text;

namespace Indices
{
    using System;
    using System.Linq;

    public class IndicesExec
    {
        public static void Main()
        {
            // Read input
            int size = int.Parse(Console.ReadLine());
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).Take(size).ToArray<int>();
            bool[] visitedIndexes = new bool[size];
            int currentIndex = 0;
            int cycleStartIndex = -1;
            int endIndex = -1;
            //  bool cycleStarted = false;

            // Loop until current index is out of range
            while (currentIndex < indexes.Length && currentIndex >= 0)
            {
                int nextIndex = indexes[currentIndex];
                visitedIndexes[currentIndex] = true;
                if (nextIndex >= indexes.Length || nextIndex < 0)
                {
                    endIndex = currentIndex;
                    break;
                }

                if (visitedIndexes[nextIndex] && currentIndex > nextIndex)
                {
                    // Cycle found
                    cycleStartIndex = nextIndex;
                    endIndex = currentIndex;
                    break;
                }

                currentIndex = nextIndex;
            }

            // Output to Console
            currentIndex = 0;
            bool cycleStarted = false;
            StringBuilder output = new StringBuilder();
            while (currentIndex < indexes.Length && currentIndex >= 0)
            {
                int nextIndex = indexes[currentIndex];
                if (cycleStartIndex != -1)
                {
                    if (currentIndex == cycleStartIndex)
                    {
                        //Console.Write("(");
                        //Console.Write(currentIndex);
                        output.Append("(");
                        output.Append(currentIndex);
                        cycleStarted = true;
                    }
                    else if (endIndex == currentIndex && cycleStarted)
                    {
                        //Console.Write(currentIndex);
                        //Console.WriteLine(")");
                        output.Append(currentIndex);
                        output.Append(")");
                        break;
                    }
                    else
                    {
                        // Console.Write(currentIndex);
                        output.Append(currentIndex);
                    }

                    if (nextIndex != cycleStartIndex)
                    {
                        // Console.Write(" ");
                        output.Append(" ");
                    }
                }
                else if (cycleStartIndex == -1)
                {
                    // Console.Write(currentIndex);
                    output.Append(currentIndex);
                    if (currentIndex != endIndex)
                    {
                        // Console.Write(" ");
                        output.Append(" ");
                    }
                }

                if (nextIndex >= indexes.Length || nextIndex < 0)
                {
                    break;
                }

                currentIndex = nextIndex;
            }

            Console.WriteLine(output.ToString());
        }
    }
}
