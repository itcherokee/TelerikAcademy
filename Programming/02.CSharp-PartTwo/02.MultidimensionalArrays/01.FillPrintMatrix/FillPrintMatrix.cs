using System;

/// <summary>
/// Task: "01. Write a program that fills and prints a matrix of size (n, n)."
/// </summary>
public class FillPrintMatrix
{
    public static void Main()
    {
        Console.Title = "Fill and print matrixes with pattern";
        int matrixSize = EnterData("Enter size of matrix [2..10]: ");
        int counter = 1;
        int[,,] complexMatrix = new int[4, matrixSize, matrixSize];

        // First matrix - loads it into 0 dimension of complex array
        for (int column = 0; column < matrixSize; column++)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                complexMatrix[0, row, column] = counter++;
            }
        }

        // Second matrix - loads it into 1 dimension of complex array
        Direction move = Direction.Down;
        counter = 1;
        for (int column = 0; column < matrixSize; column++)
        {
            switch (move)
            {
                case Direction.Down:
                    // Filling column in Down direction
                    for (int row = 0; row < matrixSize; row++)
                    {
                        complexMatrix[1, row, column] = counter++;
                        move = Direction.Up;
                    }

                    break;
                case Direction.Up:
                    // Filling column in Up direction
                    for (int row = matrixSize - 1; row >= 0; row--)
                    {
                        complexMatrix[1, row, column] = counter++;
                        move = Direction.Down;
                    }

                    break;
            }
        }

        // Third matrix - loads it into 2 dimension of complex array
        int startRow = matrixSize - 1;
        int startColumn = 0;
        counter = 1;
        bool notOutOfBoard = false;
        int currentRow = 0;
        int currentColumn = 0;
        for (int i = 1; i <= (2 * matrixSize) - 1; i++)
        {
            currentRow = startRow;
            currentColumn = startColumn;
            notOutOfBoard = true;
            do
            {
                complexMatrix[2, currentRow, currentColumn] = counter++;
                currentRow++;
                currentColumn++;

                // check cursor for out of boundaries of the matrix
                if (startRow > 0)
                {
                    if (currentRow == matrixSize)
                    {
                        notOutOfBoard = false;
                    }
                }
                else
                {
                    if (currentColumn == matrixSize)
                    {
                        notOutOfBoard = false;
                    }
                }
            }
            while (notOutOfBoard);

            // modify starting row and coloumn
            if (startRow == 0)
            {
                startColumn++;
            }
            else if (startRow > 0)
            {
                startRow--;
            }
        }

        // * Forth matrix - loads it into 3 dimension of complex array
        // Setup borders of the matrix
        int leftBorder = 1;
        int rightBorder = matrixSize - 1;
        int topBorder = 0;
        int bottomBorder = matrixSize - 1;
        currentRow = leftBorder - 1;
        currentColumn = topBorder;

        // Start by moving down
        move = Direction.Down;
        for (int index = 1; index <= matrixSize * matrixSize; index++)
        {
            complexMatrix[3, currentRow, currentColumn] = index;
            switch (move)
            {
                case Direction.Down:
                    if (currentRow == bottomBorder)
                    {
                        bottomBorder--;
                        move = Direction.Right;
                        currentColumn++;
                    }
                    else
                    {
                        currentRow++;
                    }

                    break;
                case Direction.Right:
                    if (currentColumn == rightBorder)
                    {
                        rightBorder--;
                        move = Direction.Up;
                        currentRow--;
                    }
                    else
                    {
                        currentColumn++;
                    }

                    break;
                case Direction.Up:
                    if (currentRow == topBorder)
                    {
                        topBorder++;
                        move = Direction.Left;
                        currentColumn--;
                    }
                    else
                    {
                        currentRow--;
                    }

                    break;
                case Direction.Left:
                    if (currentColumn == leftBorder)
                    {
                        leftBorder++;
                        move = Direction.Down;
                        currentRow++;
                    }
                    else
                    {
                        currentColumn--;
                    }

                    break;
            }
        }

        // Output to Console of complex array - each dimension
        for (int dimension = 0; dimension < 4; dimension++)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                Console.WriteLine(new string('-', (matrixSize * 4) + matrixSize + 1));
                for (int column = 0; column < matrixSize; column++)
                {
                    Console.Write("|{0,3} ", complexMatrix[dimension, row, column]);
                }

                Console.WriteLine('|');
            }

            Console.WriteLine(new string('-', (matrixSize * 4) + matrixSize + 1) + "\n");
        }

        Console.ReadKey();
    }

    // Handles user input
    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput || enteredValue > 10 || enteredValue < 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                isValidInput = false;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}