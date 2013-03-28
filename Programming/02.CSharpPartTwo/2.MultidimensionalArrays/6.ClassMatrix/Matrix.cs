namespace ClassMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        private int[,] arrayOfInt;
        private int rows;
        private int columns;

        // constructor
        public Matrix(int initialRows, int initialColumns)
        {
            this.arrayOfInt = new int[initialRows, initialColumns];
            this.NumberOfRows = initialRows;
            this.NumberOfColumns = initialColumns;
        }

        // number of Rows and Columns
        public int NumberOfRows
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

        public int NumberOfColumns
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

        // indexer for access
        public int this[int rowIndex, int columnIndex]
        {
            get { return this.arrayOfInt[rowIndex, columnIndex]; }
            set { this.arrayOfInt[rowIndex, columnIndex] = value; }
        }

        // addition operator
        public static Matrix operator +(Matrix matrixOne, Matrix matrixTwo)
        {
            if (matrixOne.NumberOfColumns == matrixTwo.NumberOfColumns && matrixOne.NumberOfRows == matrixTwo.NumberOfRows)
            {
                Matrix newArray = new Matrix(matrixOne.NumberOfRows, matrixOne.NumberOfColumns);
                for (int i = 0; i < matrixOne.NumberOfRows; i++)
                {
                    for (int j = 0; j < matrixOne.NumberOfColumns; j++)
                    {
                        newArray[i, j] = matrixOne[i, j] + matrixTwo[i, j];
                    }
                }

                return newArray;
            }

            return null;
        }

        // subtracting operator
        public static Matrix operator -(Matrix matrixOne, Matrix matrixTwo)
        {
            if (matrixOne.NumberOfColumns == matrixTwo.NumberOfColumns && matrixOne.NumberOfRows == matrixTwo.NumberOfRows)
            {
                Matrix newArray = new Matrix(matrixOne.NumberOfRows, matrixOne.NumberOfColumns);
                for (int i = 0; i < matrixOne.NumberOfRows; i++)
                {
                    for (int j = 0; j < matrixOne.NumberOfColumns; j++)
                    {
                        newArray[i, j] = matrixOne[i, j] - matrixTwo[i, j];
                    }
                }

                return newArray;
            }

            return null;
        }

        // multiplying operator
        public static Matrix operator *(Matrix matrixOne, Matrix matrixTwo)
        {
            if (matrixOne.NumberOfRows == matrixTwo.NumberOfColumns)
            {
                Matrix newArray = new Matrix(matrixOne.NumberOfRows, matrixTwo.NumberOfColumns);
                for (int k = 0; k < matrixOne.NumberOfRows; k++)
                {
                    for (int i = 0; i < matrixTwo.NumberOfColumns; i++)
                    {
                        for (int j = 0; j < matrixOne.NumberOfColumns; j++)
                        {
                            newArray[k, i] += matrixOne[k, j] * matrixTwo[j, i];
                        }
                    }
                }

                return newArray;
            }

            return null;
        }

        // ToString overload
        public override string ToString()
        {
            StringBuilder outputMatrix = new StringBuilder();
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    outputMatrix.Append(this.arrayOfInt[i, j] + " ");
                }

                outputMatrix.Append("\n");
            }

            return outputMatrix.ToString();
        }
    }
}
