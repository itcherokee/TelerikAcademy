using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Task: "5. Write a program that reads a text file containing a square matrix of numbers and finds 
/// in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line 
/// in the input file contains the size of matrix N. Each of the next N lines contain N numbers 
/// separated by space. The output should be a single number in a separate text file. "
/// </summary>
public class MatrixSum
{
    public static void Main()
    {
        Console.Title = "Load matrix from a file and find maximal sum";
        const int MatrixSize = 3;
        const string FileInput = "input.txt";
        const string FileOutput = "output.txt";
        string inputPath = Environment.CurrentDirectory + "\\" + FileInput;
        string outputPath = Environment.CurrentDirectory + "\\" + FileOutput;
        var encoding = Encoding.GetEncoding("Windows-1251");
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generate matrix
            GenerateMatrixFile(FileInput, MatrixSize);
            using (var reader = new StreamReader(inputPath, encoding))
            {
                // Loads full matrix from file into memory
                int sizeOfMatrix = int.Parse(reader.ReadLine());
                int[,] matrixOfNumbers = new int[sizeOfMatrix, sizeOfMatrix];
                for (int row = 0; row < sizeOfMatrix; row++)
                {
                    string[] lineWithNumbers = reader.ReadLine().Trim().Split();
                    for (int column = 0; column < sizeOfMatrix; column++)
                    {
                        matrixOfNumbers[row, column] = int.Parse(lineWithNumbers[column]);
                    }
                }

                using (var writer = new StreamWriter(outputPath, false, encoding))
                {
                    writer.WriteLine(FindMaxSum(matrixOfNumbers));
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Done. Check program folder for result (file: {0})", FileOutput);
        }
        catch (ArgumentException)
        {
            Console.Error.WriteLine("The selected encoding is not availbale.");
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("File not found.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Directory not found.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Something went terribly wrong with I/O.");
        }
        catch (Exception)
        {
            Console.Error.WriteLine("General fault protection error. :)");
        }

        Console.ReadKey();
    }

    // Discover and calculate the max avai;able sum in 2x2 square
    public static int FindMaxSum(int[,] matrix)
    {
        int maxSum = int.MinValue;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                maxSum = maxSum < currentSum ? currentSum : maxSum;
            }
        }

        return maxSum;
    }

    // Generates matrix - new text file
    private static void GenerateMatrixFile(string fileName, int matrixSize)
    {
        var numbers = new int[matrixSize];
        Random generator = new Random();
        using (var writer = new StreamWriter(fileName, false))
        {
            writer.WriteLine(matrixSize);
            for (int row = 0; row < matrixSize; row++)
            {
                for (int column = 0; column < matrixSize; column++)
                {
                    numbers[column] = generator.Next(0, 20);
                }

                writer.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}