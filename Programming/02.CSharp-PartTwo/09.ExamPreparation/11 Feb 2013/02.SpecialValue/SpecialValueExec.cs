// Task definition is in the solution folder
namespace SpecialValue
{
    using System;
    using System.Linq;

    public class SpecialValueExec
    {
        public static void Main()
        {
            short numberOfLines = short.Parse(Console.ReadLine());
            short[][] lines = new short[numberOfLines][];
            short[][] visited = new short[numberOfLines][];
            for (int line = 0; line < numberOfLines; line++)
            {
                lines[line] = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(short.Parse).ToArray();
                visited[line] = new short[lines[line].Length];
            }

            short row = 0;
            short uniqueMark = 1;
            int maxResult = -1;
            bool negativeEnd = false;
            for (short column = 0; column < lines[0].Length; column++)
            {
                row = 0;
                int path = 1;
                int cellValue = lines[0][column];
                visited[row][column] = uniqueMark;
                while (true)
                {
                    if (cellValue >= 0)
                    {
                        row++;
                        if (row >= lines.GetLength(0))
                        {
                            row = 0;
                        }

                        if (visited[row][cellValue] == uniqueMark)
                        {
                            break;
                        }

                        path++;
                        visited[row][cellValue] = uniqueMark;
                        cellValue = lines[row][cellValue];
                    }
                    else
                    {
                        negativeEnd = true;
                        break;
                    }
                }

                uniqueMark++;
                int result = 0;
                if (cellValue < 0)
                {
                    result = path + Math.Abs(cellValue);
                    if (maxResult < result)
                    {
                        maxResult = result;
                    }
                }
            }

            if (negativeEnd)
            {
                Console.WriteLine(maxResult);
            }
        }
    }
}