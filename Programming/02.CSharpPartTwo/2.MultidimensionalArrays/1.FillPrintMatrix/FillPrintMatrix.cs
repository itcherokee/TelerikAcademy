using System;

public class FillPrintMatrix
{
    // Write a program that fills and prints a matrix of size (n, n)
    public static void Main()
    {
        int inputSize = 0;
        bool noError = false;
        // management of console input
        do
        {
            Console.Write("Enter size of matrix [2..10]: ");
            noError = int.TryParse(Console.ReadLine(), out inputSize);
            if ((!noError) || (inputSize < 2) || (inputSize > 10))
            {
                Console.WriteLine("There was something wrong with your input!");
                Console.WriteLine("Try again <press Enter>....");
                noError = false;
                Console.ReadLine();
                Console.Clear();
            }
        } 
        while (!noError);
        int counter = 1;
        int[,,] complexArray = new int[4, inputSize, inputSize];

        // first matrix load
        for (int cols = 0; cols < inputSize; cols++)
        {
            for (int rows = 0; rows < inputSize; rows++)
            {
                complexArray[0, rows, cols] = counter++;
            }
        }

        // second matrix load
        bool direction = true;
        counter = 1;
        for (int cols = 0; cols < inputSize; cols++)
        {
            if (direction)
            {
                for (int rows = 0; rows < inputSize; rows++)
                {
                    complexArray[1, rows, cols] = counter;
                    counter++;
                }
            }
            else
            {
                for (int rows = inputSize - 1; rows >= 0; rows--)
                {
                    complexArray[1, rows, cols] = counter;
                    counter++;
                }
            }
            // turn the direction
            direction = !direction;
        }

        // third matrix load
        int startRow = inputSize - 1;
        int startCol = 0;
        counter = 1;
        bool notOutOfBoard = false;
        int row = 0;
        int col = 0;
        for (int i = 1; i <= (2 * inputSize) - 1; i++)
        {
            row = startRow;
            col = startCol;
            notOutOfBoard = true;
            do
            {
                complexArray[2, row, col] = counter++;
                row++;
                col++;
                // check cursor for out of boundaries of the matrix
                if (startRow > 0)
                {
                    if (row == inputSize)
                    {
                        notOutOfBoard = false;
                    }
                }
                else
                {
                    if (col == inputSize)
                    {
                        notOutOfBoard = false;
                    }
                }
            } 
            while (notOutOfBoard);
            // modify starting row and coloumn
            if (startRow == 0)
            {
                startCol++;
            }
            else if (startRow > 0)
            {
                startRow--;
            }
        }

        // forth matrix load
        counter = 1;
        int borderLeft = 1;
        int borderRight = inputSize - 1;
        int borderUp = 0;
        int borderDown = inputSize - 1;
        row = borderLeft - 1;
        col = borderUp;
        int goThatWay = 1; // 1-down; 2 -right; 3 - up; 4 - left
        for (int i = 1; i <= inputSize * inputSize; i++)
        {
            complexArray[3, row, col] = i;
            switch (goThatWay)
            {
                case 1: //go down
                    if (row == borderDown)
                    {
                        borderDown--;
                        goThatWay = 2;
                        col++;
                    }
                    else
                    {
                        row++;
                    }

                    break;
                case 2: // go right                    
                    if (col == borderRight)
                    {
                        borderRight--;
                        goThatWay = 3;
                        row--;
                    }
                    else
                    {
                        col++;
                    }

                    break;
                case 3: // go up                   
                    if (row == borderUp)
                    {
                        borderUp++;
                        goThatWay = 4;
                        col--;
                    }
                    else
                    {
                        row--;
                    }

                    break;
                case 4: // go left                    
                    if (col == borderLeft)
                    {
                        borderLeft++;
                        goThatWay = 1;
                        row++;
                    }
                    else
                    {
                        col--;
                    }

                    break;
            }
        }

        // array print - 4 matrixes
        for (int dimension = 0; dimension < 4; dimension++)
        {
            for (int rows = 0; rows < inputSize; rows++)
            {
                Console.WriteLine(new string('-', (inputSize * 4) + inputSize + 1));
                for (int cols = 0; cols < inputSize; cols++)
                {
                    Console.Write("|{0,3} ", complexArray[dimension, rows, cols]);
                }

                Console.WriteLine('|');
            }

            Console.WriteLine(new string('-', (inputSize * 4) + inputSize + 1));
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
