namespace ClassMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        private readonly int[,] matrix;
        private int rows;
        private int columns;

        // constructor
        public Matrix(int rows, int columns)
        {
            this.matrix = new int[rows, columns];
            this.RowsCount = rows;
            this.ColumnsCount = columns;
        }

        // number of Rows and Columns
        public int RowsCount
        {
            get
            {
                return this.rows;
            }

            set
            {
                if (value >= 0)
                {
                    this.rows = value;
                }
            }
        }

        public int ColumnsCount
        {
            get
            {
                return this.columns;
            }

            set
            {
                if (value >= 0)
                {
                    this.columns = value;
                }
            }
        }

        // Indexer
        public int this[int rowIndex, int columnIndex]
        {
            get { return this.matrix[rowIndex, columnIndex]; }
            set { this.matrix[rowIndex, columnIndex] = value; }
        }

        // Addition operator
        public static Matrix operator +(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix newMatrix;
            if (matrixOne.ColumnsCount == matrixTwo.ColumnsCount && matrixOne.RowsCount == matrixTwo.RowsCount)
            {
                newMatrix = new Matrix(matrixOne.RowsCount, matrixOne.ColumnsCount);
                for (int row = 0; row < matrixOne.RowsCount; row++)
                {
                    for (int column = 0; column < matrixOne.ColumnsCount; column++)
                    {
                        newMatrix[row, column] = matrixOne[row, column] + matrixTwo[row, column];
                    }
                }
            }
            else
            {
                throw new ArgumentException("Addition not possible - Two matrices are not of the same type!.");
            }

            return newMatrix;
        }

        // Subtracting operator
        public static Matrix operator -(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix newMatrix;
            if (matrixOne.ColumnsCount == matrixTwo.ColumnsCount && matrixOne.RowsCount == matrixTwo.RowsCount)
            {
                newMatrix = new Matrix(matrixOne.RowsCount, matrixOne.ColumnsCount);
                for (int row = 0; row < matrixOne.RowsCount; row++)
                {
                    for (int column = 0; column < matrixOne.ColumnsCount; column++)
                    {
                        newMatrix[row, column] = matrixOne[row, column] - matrixTwo[row, column];
                    }
                }
            }
            else
            {
                throw new ArgumentException("Substraction not possible - Two matrices are not of the same type!.");
            }

            return newMatrix;
        }

        // Multiplying operator
        public static Matrix operator *(Matrix matrixOne, Matrix matrixTwo)
        {
            Matrix newMatrix;
            if (matrixOne.RowsCount == matrixTwo.ColumnsCount)
            {
                newMatrix = new Matrix(matrixOne.RowsCount, matrixTwo.ColumnsCount);
                for (int row = 0; row < matrixOne.RowsCount; row++)
                {
                    for (int columnM2 = 0; columnM2 < matrixTwo.ColumnsCount; columnM2++)
                    {
                        for (int columnM1 = 0; columnM1 < matrixOne.ColumnsCount; columnM1++)
                        {
                            newMatrix[row, columnM2] += matrixOne[row, columnM1] * matrixTwo[columnM1, columnM2];
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Multiplication not possible - Number of columns of first matrix is not equal to number of rows of the second!");
            }

            return newMatrix;
        }

        // ToString overload
        public override string ToString()
        {
            StringBuilder outputMatrix = new StringBuilder();
            for (int row = 0; row < this.RowsCount; row++)
            {
                for (int column = 0; column < this.ColumnsCount; column++)
                {
                    outputMatrix.Append(this.matrix[row, column] + " ");
                }

                outputMatrix.Append("\n");
            }

            return outputMatrix.ToString();
        }
    }
}
