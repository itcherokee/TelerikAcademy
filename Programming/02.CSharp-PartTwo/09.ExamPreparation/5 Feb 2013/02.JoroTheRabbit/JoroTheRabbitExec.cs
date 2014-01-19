// Task description is in the solution folder
namespace JoroTheRabbit
{
    using System;
    using System.Linq;

    public class JoroTheRabbitExec
    {
        public static void Main()
        {
            short[] terrain = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse).ToArray();
            short maxJumps = 0;
            int[] visited = new int[terrain.Length];

            // uniqueMark is used to mark uniquely visited cells during each round+step
            short uniqueMark = 0;
            for (short position = 0; position < terrain.Length; position++)
            {
                for (short step = 1; step < terrain.Length; step++)
                {
                    uniqueMark++;
                    short currentJumps = 1;
                    short currentValue = terrain[position];
                    visited[position] = uniqueMark;
                    int currentIndex = position;
                    while (true)
                    {
                        // Next step position index
                        currentIndex += step;

                        // Rotate array and adjust to correct index from beggining
                        if (currentIndex > terrain.Length - 1)
                        {
                            currentIndex = currentIndex - terrain.Length;
                        }

                        if (visited[currentIndex] != uniqueMark)
                        {
                            if (terrain[currentIndex] <= currentValue)
                            {
                                break;
                            }

                            currentJumps++;
                            currentValue = terrain[currentIndex];
                            visited[currentIndex] = uniqueMark;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (maxJumps < currentJumps)
                    {
                        maxJumps = currentJumps;
                    }
                }
            }

            Console.WriteLine(maxJumps);
        }
    }
}
