using System;

/// <summary>
/// Task: "Write a program that reads a rectangular matrix of size N x M and 
/// finds in it the square 3 x 3 that has maximal sum of its elements."
/// </summary>
public class MaximalSumInSquare
{
    public static void Main()
    {
        Console.Title = "Maximal sum in 3x3 square";
        int[,] matrix =
        {
            { 333, 1, 3, 3, 2, 1 }, { 333, 3, 10, 10, 10, 33 }, 
            { 4, 6, 10, 10, 10, 33 }, { 0, 0, 10, 10, 10, 3333 }
        };

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

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Original matrix:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Print(matrix);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Maximal sum is: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(maxSum);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Square (3x3) start at row={0} and column={1} and is:", startRow, startCol);
        Console.ForegroundColor = ConsoleColor.Green;
        Print(matrix, startRow, startCol, 3, 3);
    }

    private static void Print(int[,] matrix, int startRow = 0, int startColumn = 0, int sizeRow = 0, int sizeColumn = 0)
    {
        if (sizeRow == 0)
        {
            sizeRow = matrix.GetLength(0);
        }

        if (sizeColumn == 0)
        {
            sizeColumn = matrix.GetLength(1);
        }

        for (int row = startRow; row < startRow + sizeRow; row++)
        {
            Console.WriteLine(new string('-', (sizeColumn * 5) + sizeColumn + 1));
            for (int column = startColumn; column < startColumn + sizeColumn; column++)
            {
                Console.Write("|{0,4} ", matrix[row, column]);
            }

            Console.WriteLine('|');
        }

        Console.WriteLine(new string('-', (sizeColumn * 5) + sizeColumn + 1) + "\n");
    }
}