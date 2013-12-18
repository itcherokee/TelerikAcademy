using System;

public class MaximalSumInSquare
{
    // Write a program that reads a rectangular matrix of size N x M 
    // and finds in it the square 3 x 3 that has maximal sum of its elements.

    public static void Main()
    {
        int[,] matrix = { { 333, 1, 3, 3, 2, 1 }, 
                          { 333, 3, 10, 10, 10, 33 }, 
                          { 4, 6, 10, 10, 10, 33 },
                          { 0, 0, 10, 10, 10, 3333 } };

        int maxSum = int.MinValue;
        int tempSum = 0;
        int startRow = -1;
        int startCol = -1;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)
            {
                tempSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                    matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                    matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (maxSum < tempSum)
                {
                    maxSum = tempSum;
                    startRow = row;
                    startCol = col;
                }

                maxSum = maxSum < tempSum ? tempSum : maxSum;
            }
        }

        Console.WriteLine("Maximal sum is: {0}", maxSum);
        Console.WriteLine("Square (3x3) start at row/col: {0}/{1}", startRow, startCol);
    }
}