using System;
using ClassMatrix;

public class ProgramMatrix
{
    // * Write a class Matrix, to holds a matrix of integers. Overload the operators for adding, 
    // subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().

    // SEE Matrix.cs for the implementation of requested Class
    // this is only the test program

    public static void Main()
    {
        Matrix testArrayOne = new Matrix(2, 2);

        // load test values
        for (int i = testArrayOne.NumberOfRows - 1; i >= 0; i--)
        {
            for (int j = 0; j < testArrayOne.NumberOfColumns; j++)
            {
                testArrayOne[i, j] = (i * j) + (1 * i) + j + 3;
            }
        }

        Matrix testArrayTwo = new Matrix(2, 2);

        //load test values
        for (int i = testArrayTwo.NumberOfRows - 1; i >= 0; i--)
        {
            for (int j = 0; j < testArrayTwo.NumberOfColumns; j++)
            {
                testArrayTwo[i, j] = (i * j) + (1 * j * j) + 5;
            }
        }

        // print source matrices
        Console.WriteLine("First matrix:");
        Console.WriteLine(testArrayOne.ToString());
        Console.WriteLine("Second matrix:");
        Console.WriteLine(testArrayTwo.ToString());

        // matrix addition test
        Matrix resultMatrix = testArrayOne + testArrayTwo;
        Console.WriteLine("Addition result:");
        Console.WriteLine(resultMatrix.ToString());

        // matrix substraction test
        resultMatrix = testArrayOne - testArrayTwo;
        Console.WriteLine("Substraction result:");
        Console.WriteLine(resultMatrix.ToString());

        // matrix multiplying test
        resultMatrix = testArrayOne * testArrayTwo;
        Console.WriteLine("Multiplying result:");
        Console.WriteLine(resultMatrix.ToString());
    }
}
