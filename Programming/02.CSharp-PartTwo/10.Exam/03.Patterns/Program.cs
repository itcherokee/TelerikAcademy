using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int i = 0; i < size; i++)
                {
                    matrix[row, i] = input[i];
                }

            }

            // search for pattern

            BigInteger maxSum = 0;
            bool isFound = false;
            BigInteger tempSum = 0;
            for (int row = 0; row < matrix.GetLength(0) - 6; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 4; col++)
                {
                    // A = B -1, B = C – 1, C = D – 1, D = F – 1, F = E – 1, E = G - 1
                    int A = matrix[row, col];
                    int B = matrix[row, col + 1];
                    int C = matrix[row, col + 2];
                    int D = matrix[row + 1, col + 2];
                    int F = matrix[row + 2, col + 2];
                    int E = matrix[row + 2, col + 3];
                    int G = matrix[row + 2, col + 4];

                    if ((A == (B - 1)) && (B == (C - 1)) && (C == (D - 1)) && (D == (F - 1)) && (F == (E - 1)) && (E == (G - 1)))
                    {
                        isFound = true;
                        tempSum = A + B + C + D + F + E + G;
                    }
                    else
                        //tempSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        //    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        //    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                        //if (maxSum < tempSum)
                        //{
                        //    maxSum = tempSum;
                        //    //startRow = row;
                        //    //startCol = col;
                        //}

                        maxSum = maxSum < tempSum ? tempSum : maxSum;
                }
            }
            if (isFound)
            {
                Console.WriteLine("YES {0}", maxSum);
            }
            else
            {
                maxSum = 0;
                for (int i = 0; i < size; i++)
                {
                    maxSum += matrix[i, i];
                }

                Console.WriteLine("NO {0}", maxSum);
            }
        }
    }
}
