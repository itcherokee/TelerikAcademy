// Task description is in the solution folder
namespace OneTaskIsNotEnough
{
    using System;
    using System.Linq;

    public class OneTaskIsNotEnoughExec
    {
        public static void Main()
        {
            // Input
            int numberOfLamps = int.Parse(Console.ReadLine());
            string firstMove = Console.ReadLine();
            string secondMove = Console.ReadLine();

            // Task 1
            Console.WriteLine(WhichIsLastLapmTurnedOn(numberOfLamps));

            // Task 2
            Console.WriteLine(IsBounded(firstMove));
            Console.WriteLine(IsBounded(secondMove));
        }

        private static int WhichIsLastLapmTurnedOn(int numberOfLamps)
        {
            int[] oldLamps = new int[numberOfLamps];
            for (int i = 0; i < numberOfLamps; i++)
            {
                oldLamps[i] = i + 1;
            }

            int lampsOffCounter = numberOfLamps;
            int lastLamp = 0;
            int offset = 2;
            int[] lamps = new int[lampsOffCounter];
            int lastElement = numberOfLamps;
            while (lampsOffCounter > 0)
            {
                int index = 0;
                int newIndex = 0;
                while (index < lastElement)
                {
                    if (oldLamps[index] > 0)
                    {
                        lamps[newIndex] = oldLamps[index];
                        newIndex++;
                    }

                    index++;
                }

                lastElement = lampsOffCounter;
                if (lampsOffCounter == 1)
                {
                    lastLamp = lamps[0];
                    break;
                }

                oldLamps = lamps;
                int temp = lampsOffCounter;
                for (int i = 0; i < temp; i += offset)
                {
                    lastLamp = oldLamps[i];
                    oldLamps[i] = -1;
                    lampsOffCounter--;
                }

                offset++;
            }

            return lastLamp;
        }

        private static string IsBounded(string c)
        {
            int r = c.Count(x => x == 'R');
            int l = c.Count(x => x == 'L');
            if (l - r < 0 || l - r > 0)
            {
                return "bounded";
            }

            return "unbounded";
        }
    }
}