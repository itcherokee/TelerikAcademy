// Refactor the following code to apply variable usage and naming best practices

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TaskTwo
{
    public class Class1
    {
        public void PrintStatistics(double[] arr, int count)
        {
            double max, tmp;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            PrintMax(max);
            tmp = 0;
            max = 0;
            for (int i = 0; i < count; i++)
            {
                if (arr[i] < max)
                {
                    max = arr[i];
                }
            }
            PrintMin(max);

            tmp = 0;
            for (int i = 0; i < count; i++)
            {
                tmp += arr[i];
            }
            PrintAvg(tmp / count);
        }

    }
}
