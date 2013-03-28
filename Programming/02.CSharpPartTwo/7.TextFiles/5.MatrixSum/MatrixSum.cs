using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class MatrixSum
{
    // Write a program that reads a text file containing a square matrix of numbers and finds 
    // in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line 
    // in the input file contains the size of matrix N. Each of the next N lines contain N numbers 
    // separated by space. The output should be a single number in a separate text file. 

    public static void Main()
    {
        Console.Title = "Load matrix from a file and find maximal sum";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        string inputPath = Environment.CurrentDirectory + "\\Input.txt";
        string outputPath = Environment.CurrentDirectory + "\\Output.txt";
        int[,] matrixOfNumbers;
        int sizeOfMatrix = 0;
        try
        {
            StreamReader reader = new StreamReader(inputPath, Encoding.GetEncoding("Windows-1251"));
            using (reader)
            {
                sizeOfMatrix = int.Parse(reader.ReadLine());
                matrixOfNumbers = new int[sizeOfMatrix, sizeOfMatrix];
                string[] lineWithNumbers;
                for (int row = 0; row < sizeOfMatrix; row++)
                {
                    lineWithNumbers = reader.ReadLine().Trim().Split();
                    for (int col = 0; col < sizeOfMatrix; col++)
                    {
                        matrixOfNumbers[row, col] = int.Parse(lineWithNumbers[col]);
                    }
                }

                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding("Windows-1251")))
                {
                    writer.WriteLine(FindMaxSum(matrixOfNumbers));
                }

                Console.WriteLine("Done. Check the folder (bin\\Debug) content");
            }
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
            Console.Error.WriteLine("Something went terribly wrong.");
        }
    }

    public static int FindMaxSum(int[,] matrix)
    {
        int maxSum = int.MinValue;
        int tempSum = 0;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                tempSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                maxSum = maxSum < tempSum ? tempSum : maxSum;
            }
        }

        return maxSum;
    }
}