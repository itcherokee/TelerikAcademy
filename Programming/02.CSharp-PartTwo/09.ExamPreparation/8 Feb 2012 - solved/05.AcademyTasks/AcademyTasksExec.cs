namespace AcademyTasks
{
    using System;
    using System.Linq;

    public static class AcademyTasksExec
    {
        public static void Main()
        {
            // Console input
            short[] pleasantness = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse).ToArray();
            short variety = short.Parse(Console.ReadLine().Trim());
            bool[] tasks = new bool[pleasantness.Length];
            bool maxPleasantnessFound = false;
            bool minPleasantnessFound = false;
            int max = pleasantness[0];
            int maxIndex = 0;
            int min = pleasantness[0];
            int minIndex = 0;
            bool varietyFound = false;

            // Find first Min and Max pleasantness between tasks that fullfill the variety
            for (int i = 1; i < tasks.Length; i++)
            {
                if (pleasantness[i] < min)
                {
                    min = pleasantness[i];
                    minIndex = i;
                }

                if (pleasantness[i] > max)
                {
                    max = pleasantness[i];
                    maxIndex = i;
                }

                if (max - min >= variety)
                {
                    // Min & Max has been found before end of array
                    varietyFound = true;
                    break;
                }
            }

            // Mark which tasks need to be solved
            int tasksToSolveCounter = 0;
            if (varietyFound)
            {
                int index = 0;
                do
                {
                    if (index == minIndex)
                    {
                        minPleasantnessFound = true;
                        tasks[index] = true;
                        tasksToSolveCounter++;
                        index++;
                        continue;
                    }

                    if (index == maxIndex)
                    {
                        maxPleasantnessFound = true;
                        tasks[index] = true;
                        tasksToSolveCounter++;
                        index++;
                        continue;
                    }

                    if (index != 0 && tasks[index - 1])
                    {
                        index++;
                        continue;
                    }

                    tasks[index] = true;
                    tasksToSolveCounter++;
                    index++;
                }
                while (!(minPleasantnessFound && maxPleasantnessFound));
            }
            else
            {
                tasksToSolveCounter = pleasantness.Length;
            }

            // Output to Console the result
            Console.WriteLine(tasksToSolveCounter);
        }
    }
}
