using System;
using ClassMatrix;

/// <summary>
/// Task: "6. * Write a class Matrix, to holds a matrix of integers. Overload the operators 
/// for adding, subtracting and multiplying of matrices, indexer for accessing the matrix
/// content and ToString()."
/// 
/// Note:  SEE Matrix.cs for the implementation of requested Class, this is only the test program.
/// 
/// Note: If you want to test the class with different matrices, you can change their sizes. 
///       You can also set not allowed sizes for the required operations to see how the class react 
///       in such input data. 
/// </summary>
public class ProgramMatrix
{
    public static void Main()
    {
        Matrix matrixOne = new Matrix(3, 3);

        // Load test values into First matrix
        for (int i = matrixOne.RowsCount - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrixOne.ColumnsCount; j++)
            {
                matrixOne[i, j] = (i * j) + (1 * i) + j + 3;
            }
        }

        Matrix matrixTwo = new Matrix(3, 3);

        // Load test values into Second matrix
        for (int i = matrixTwo.RowsCount - 1; i >= 0; i--)
        {
            for (int j = 0; j < matrixTwo.ColumnsCount; j++)
            {
                matrixTwo[i, j] = (i * j) + (1 * j * j) + 5;
            }
        }

        // Output to Console - initial data
        Console.WindowHeight = 30;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Initial data:\n=============");
        Print(matrixOne, "First matrix:");
        Print(matrixTwo, "Second matrix:");

        // Calculations with Matrix class and output to Console the results
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Calculated data:\n================");
        Matrix resultMatrix;

        // Addition test
        try
        {
            resultMatrix = matrixOne + matrixTwo;
            Print(resultMatrix, "Addition result:");
        }
        catch (ArgumentException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
        }

        // Substraction test
        try
        {
            resultMatrix = matrixOne - matrixTwo;
            Print(resultMatrix, "Substraction result:");
        }
        catch (ArgumentException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
        }

        // Multiplying test
        try
        {
            resultMatrix = matrixOne * matrixTwo;
            Print(resultMatrix, "Multiplying result:");
        }
        catch (ArgumentException e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
        }

        Console.ReadKey();
    }

    private static void Print(Matrix matrix, string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.Yellow;

        // Usage of overloaded ToString() method in Matrix class
        Console.WriteLine(matrix.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }
}