using System;

/// <summary>
/// Task: "We are given a matrix of strings of size N x M. Sequences in the matrix we define 
/// as sets of several neighbor elements located on the same line, column or diagonal. 
/// Write a program that finds the longest sequence of equal strings in the matrix."
/// 
/// Note: If there are more than one longest sequence (same size), the first occurance (detected)
///       is reported as longest.
/// </summary>
public class Sequences
{
    // Keeps the longest sequence discovered - coordinates as well as count
    private static Sequence finalSequence;

    public static void Main()
    {
        Console.Title = "Longest sequence of equal strings in array";

        // string[,] matrix =
        // {
        //    { "1", "1", "1", "4", "4" },
        //    { "1", "1", "9", "7", "3" },
        //    { "9", "9", "1", "8", "2" },
        //    { "3", "3", "3", "1", "3" },
        //    { "1", "5", "3", "1", "1" },
        // };
        string[,] matrix =
        {
            { "44", "33", "66", "21", "21", "21", "21" }, 
            { "11", "44", "11", "33", "11", "21", "21" }, 
            { "11", "11", "44", "33", "21", "21", "21" }, 
            { "11", "11", "11", "21", "11", "21", "21" }, 
            { "11", "11", "21", "33", "44", "21", "21" }, 
            { "11", "21", "11", "33", "11", "44", "21" }, 
            { "21", "21", "11", "21", "21", "21", "44" }
        };

        SearchHorizontals(matrix);
        SearchVerticals(matrix);
        SearchDiagonals(matrix);
        Print(matrix, finalSequence);
        Console.ReadKey();
    }

    // Search for sequences in horizontals
    private static void SearchHorizontals(string[,] matrix)
    {
        var sequence = new Sequence();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                sequence.StartRow = row;
                sequence.EndRow = row;
                sequence.StartColumn = column;
                sequence.EndColumn = column;
                if (column != matrix.GetLength(1) - 1)
                {
                    int tempSequenceNumber = 1;
                    for (int localCol = column + 1; localCol < matrix.GetLength(1); localCol++)
                    {
                        if (matrix[row, localCol - 1] == matrix[row, localCol])
                        {
                            tempSequenceNumber++;
                            if (finalSequence.MaxCount < tempSequenceNumber)
                            {
                                finalSequence.StartRow = sequence.StartRow;
                                finalSequence.StartColumn = sequence.StartColumn;
                                finalSequence.EndColumn = localCol;
                                finalSequence.EndRow = sequence.EndRow;
                                finalSequence.MaxCount = tempSequenceNumber;
                            }
                        }
                        else
                        {
                            sequence.StartColumn = localCol;
                        }
                    }
                }
            }
        }
    }

    // Search for sequences in verticals
    private static void SearchVerticals(string[,] matrix)
    {
        var sequence = new Sequence();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                sequence.StartRow = row;
                sequence.EndRow = row;
                sequence.StartColumn = column;
                sequence.EndColumn = column;
                if (row != matrix.GetLength(0) - 1)
                {
                    int tempSequenceNumber = 1;
                    for (int localRow = row + 1; localRow < matrix.GetLength(0); localRow++)
                    {
                        if (matrix[localRow - 1, column] == matrix[localRow, column])
                        {
                            tempSequenceNumber++;
                            if (finalSequence.MaxCount < tempSequenceNumber)
                            {
                                finalSequence.StartRow = sequence.StartRow;
                                finalSequence.StartColumn = sequence.StartColumn;
                                finalSequence.EndColumn = sequence.EndColumn;
                                finalSequence.EndRow = localRow;
                                finalSequence.MaxCount = tempSequenceNumber;
                            }
                        }
                        else
                        {
                            sequence.StartRow = localRow;
                        }
                    }
                }
            }
        }
    }

    // Search for sequences in diagonals - both directions
    private static void SearchDiagonals(string[,] matrix)
    {
        var sequence = new Sequence();

        // top-left to bottom-right direction
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                sequence.StartRow = row;
                sequence.EndRow = row;
                sequence.StartColumn = column;
                sequence.EndColumn = column;
                int tempSequenceNumber = 1;
                if ((row < matrix.GetLength(0) - 1) && (column < matrix.GetLength(1) - 1))
                {
                    int currentRow = row;
                    int currentCol = column;
                    do
                    {
                        currentRow++;
                        currentCol++;
                        if (matrix[currentRow - 1, currentCol - 1] == matrix[currentRow, currentCol])
                        {
                            tempSequenceNumber++;
                            if (finalSequence.MaxCount < tempSequenceNumber)
                            {
                                finalSequence.StartRow = sequence.StartRow;
                                finalSequence.StartColumn = sequence.StartColumn;
                                finalSequence.EndColumn = currentCol;
                                finalSequence.EndRow = currentRow;
                                finalSequence.MaxCount = tempSequenceNumber;
                            }
                        }
                        else
                        {
                            sequence.StartRow = currentRow;
                            sequence.StartColumn = currentCol;
                        }
                    }
                    while ((currentRow < matrix.GetLength(0) - 1) && (currentCol < matrix.GetLength(1) - 1));
                }
            }
        }

        // top-rigth to bottom-left direction
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
            {
                sequence.StartRow = row;
                sequence.EndRow = row;
                sequence.StartColumn = column;
                sequence.EndColumn = column;
                int tempSequenceNumber = 1;
                if (row < matrix.GetLength(0) - 1 && column > 0)
                {
                    int currentRow = row;
                    int currentCol = column;
                    do
                    {
                        currentRow++;
                        currentCol--;
                        if (matrix[currentRow - 1, currentCol + 1] == matrix[currentRow, currentCol])
                        {
                            tempSequenceNumber++;
                            if (finalSequence.MaxCount < tempSequenceNumber)
                            {
                                finalSequence.StartRow = sequence.StartRow;
                                finalSequence.StartColumn = sequence.StartColumn;
                                finalSequence.EndColumn = currentCol;
                                finalSequence.EndRow = currentRow;
                                finalSequence.MaxCount = tempSequenceNumber;
                            }
                        }
                        else
                        {
                            sequence.StartRow = currentRow;
                            sequence.StartColumn = currentCol;
                        }
                    }
                    while (currentRow < matrix.GetLength(0) - 1 && currentCol > 0);
                }
            }
        }
    }

    // Output to Console the result
    private static void Print(string[,] matrix, Sequence sequence)
    {
        Console.WriteLine("Longest sequence: ");
        if (sequence.MaxCount == 1)
        {
            Console.WriteLine("There are only single instances of strings (no repeating).");
        }
        else
        {
            // Calculate all sequence coordinates
            var sequenceCoordinates = new int[2, sequence.MaxCount];
            if (sequence.StartRow == sequence.EndRow && sequence.StartColumn < sequence.EndColumn)
            {
                // horizontal
                for (int i = 0; i < sequence.MaxCount; i++)
                {
                    sequenceCoordinates[0, i] = sequence.StartRow;
                    sequenceCoordinates[1, i] = sequence.StartColumn + i;
                }
            }
            else if (sequence.StartRow < sequence.EndRow && sequence.StartColumn == sequence.EndColumn)
            {
                // vertical
                for (int i = 0; i < sequence.MaxCount; i++)
                {
                    sequenceCoordinates[0, i] = sequence.StartRow + i;
                    sequenceCoordinates[1, i] = sequence.StartColumn;
                }
            }
            else if (sequence.StartRow < sequence.EndRow)
            {
                if (sequence.StartColumn < sequence.EndColumn)
                {
                    // diagonal top-right
                    for (int i = 0; i < sequence.MaxCount; i++)
                    {
                        sequenceCoordinates[0, i] = sequence.StartRow++;
                        sequenceCoordinates[1, i] = sequence.StartColumn++;
                    }
                }
                else if (sequence.StartColumn > sequence.EndColumn)
                {
                    // diagonal top-left
                    for (int i = 0; i < sequence.MaxCount; i++)
                    {
                        sequenceCoordinates[0, i] = sequence.StartRow++;
                        sequenceCoordinates[1, i] = sequence.StartColumn--;
                    }
                }
            }

            // Outputs the colored matrix with discovered sequence
            int sequenceCounter = 0;
            Console.ForegroundColor = ConsoleColor.White;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (sequenceCounter < sequence.MaxCount)
                    {
                        if (row == sequenceCoordinates[0, sequenceCounter] && column == sequenceCoordinates[1, sequenceCounter])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            sequenceCounter++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(" {0,3} ", matrix[row, column]);
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    internal struct Sequence
    {
        internal int StartRow;
        internal int StartColumn;
        internal int EndRow;
        internal int EndColumn;
        internal int MaxCount;
    }
}