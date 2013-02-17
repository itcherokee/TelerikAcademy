using System;

public class Sequences
{
    // We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several 
    // neighbor elements located on the same line, column or diagonal. Write a program that finds the longest 
    // sequence of equal strings in the matrix. 
    public static void Main()
    {
        string[,] matrix = new string[7, 7] { { "44", "33", "66", "21", "21", "21", "21"},
                                              { "11", "44", "11", "33", "11", "21", "21"},
                                              { "11", "11", "44", "33", "11", "21", "21"},
                                              { "11", "11", "11", "44", "11", "21", "21"},
                                              { "11", "11", "11", "33", "44", "21", "21"},
                                              { "11", "11", "11", "33", "11", "44", "21"},
                                              { "33", "21", "11", "21", "21", "21", "44"} };

        string longestSequenceString = string.Empty;
        int longestSequenceNumber = 0;
        string tempSequenceString = string.Empty;
        int tempSequenceNumber = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                // search horizontal
                if (col != matrix.GetLength(1) - 1)
                {
                    tempSequenceNumber = 1;
                    tempSequenceString = matrix[row, col];
                    for (int localCol = col + 1; localCol < matrix.GetLength(1); localCol++)
                    {
                        if (matrix[row, localCol - 1] == matrix[row, localCol])
                        {
                            tempSequenceNumber++;
                        }

                        AssignSequence(ref longestSequenceString, ref longestSequenceNumber, tempSequenceString, tempSequenceNumber);
                        if (matrix[row, localCol - 1] != matrix[row, localCol])
                        {
                            break;
                        }
                    }
                }

                // search vertical
                if (row != matrix.GetLength(0) - 1)
                {
                    tempSequenceNumber = 1;
                    tempSequenceString = matrix[row, col];
                    for (int localRow = row + 1; localRow < matrix.GetLength(0); localRow++)
                    {
                        if (matrix[localRow - 1, col] == matrix[localRow, col])
                        {
                            tempSequenceNumber++;
                        }

                        AssignSequence(ref longestSequenceString, ref longestSequenceNumber, tempSequenceString, tempSequenceNumber);
                        if (matrix[localRow - 1, col] != matrix[localRow, col])
                        {
                            break;
                        }
                    }
                }

                //search diagonal
                tempSequenceNumber = 1;
                tempSequenceString = matrix[row, col];
                if ((row < matrix.GetLength(0) - 1) && (col < matrix.GetLength(1) - 1))
                {
                    int currentRow = row;
                    int currentCol = col;
                    do
                    {
                        currentRow++;
                        currentCol++;
                        if (matrix[currentRow - 1, currentCol - 1] == matrix[currentRow, currentCol])
                        {
                            tempSequenceNumber++;
                        }

                        if (matrix[currentRow - 1, currentCol - 1] != matrix[currentRow, currentCol])
                        {
                            break;
                        }
                    }
                    while ((currentRow < matrix.GetLength(0) - 1) && (currentCol < matrix.GetLength(1) - 1));
                    AssignSequence(ref longestSequenceString, ref longestSequenceNumber, tempSequenceString, tempSequenceNumber);
                }
            }
        }

        // print on screen the result
        Console.Write("Longest sequence: ");
        if (longestSequenceNumber == 1)
        {
            Console.WriteLine("There are only single instances of strings (no repeating).");
        }
        else
        {
            for (int i = 1; i <= longestSequenceNumber; i++)
            {
                Console.Write(longestSequenceString);
                if (i < longestSequenceNumber)
                {
                    Console.Write(", ");
                }
            }
        }

        Console.WriteLine();
    }

    // if new longer result -> assign values to final variables
    private static void AssignSequence(ref string longestSequenceString, ref int longestSequenceNumber, string tempSequenceString, int tempSequenceNumber)
    {
        if (longestSequenceNumber < tempSequenceNumber)
        {
            longestSequenceString = tempSequenceString;
            longestSequenceNumber = tempSequenceNumber;
        }
    }
}