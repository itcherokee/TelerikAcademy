// Task 8:  Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
// Task 9:  Implement an indexer this[row, col] to access the inner matrix cells.
// Task 10: Implement the operators + and - (addition and subtraction of matrices of the same size) 
//          and * for matrix multiplication. Throw an exception when the operation cannot be performed. 
//          Implement the true operator (check for non-zero elements).

namespace GenericMatrix
{
    using System;

    public class Matrix<T> where T : struct
    {
        private readonly T[,] matrix;
        private readonly int rows;
        private readonly int columns;

        #region Constructors

        /// <summary>
        /// Instantiates a matrix by making clone copy from existing matrix
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(T[,] matrix)
            : this()
        {
            this.matrix = (T[,])matrix.Clone();
            this.rows = this.matrix.GetLength(0);
            this.columns = this.matrix.GetLength(1);
        }

        /// <summary>
        /// Instantiates a matrix with fixed dimensions.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        public Matrix(int rows, int cols)
            : this()
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentOutOfRangeException("Matrix can not be with negative or zero values for number of rows and/or columns!");
            }

            this.rows = rows;
            this.columns = cols;
            this.matrix = new T[this.Rows, this.Columns];
        }

        /// <summary>
        /// Instantiates a square matrix
        /// </summary>
        /// <param name="size">Size of Rows = Cols</param>
        public Matrix(int size)
            : this(size, size)
        {
        }

        /// <summary>
        /// Private parameterless constructor called by other constructor just to check for type incompitablity,
        /// DateTime is value type, but not usefull for matrix.
        /// </summary>
        private Matrix()
        {
            if (typeof(T) == typeof(DateTime))
            {
                throw new ArgumentException("Matrix can not hold values of type DateTime.");
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns Columns of a matrix
        /// </summary>
        public int Columns
        {
            get
            {
                return this.columns;
            }
        }

        /// <summary>
        /// Returns Rows of a matrix
        /// </summary>
        public int Rows
        {
            get
            {
                return this.rows;
            }
        }

        #endregion

        #region Indexer

        /// <summary>
        /// Indexer of the matrix elements
        /// </summary>
        /// <param name="row">Row index.</param>
        /// <param name="col">Column index.</param>
        /// <returns>Matrix's element.</returns>
        public T this[int row, int col]
        {
            get
            {
                // check if provided index is out of range
                if (this.IsInRange(row, col))
                {
                    return this.matrix[row - 1, col - 1];
                }

                throw new IndexOutOfRangeException("Non exisitng element (index) requested!");
            }

            set
            {
                // check if provided index is out of range
                if (this.IsInRange(row, col))
                {
                    this.matrix[row - 1, col - 1] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("An attempt to change non existing element!");
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds two matrixes. They should be of the same matrix type.
        /// </summary>
        /// <param name="matrixOne">First matrix</param>
        /// <param name="matrixTwo">Second matrix</param>
        /// <returns></returns>
        public static Matrix<T> operator +(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Rows == matrixTwo.Rows && matrixOne.Columns == matrixTwo.Columns)
            {
                Matrix<T> newArray = new Matrix<T>(matrixOne.Rows, matrixOne.Columns);
                for (int i = 0; i < matrixOne.Rows; i++)
                {
                    for (int j = 0; j < matrixOne.Columns; j++)
                    {
                        newArray[i + 1, j + 1] = (dynamic)matrixOne[i + 1, j + 1] + matrixTwo[i + 1, j + 1];
                    }
                }

                return newArray;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Both matrixes should be of the same size!");
            }
        }

        /// <summary>
        /// Substracts two matrixes.
        /// </summary>
        /// <param name="matrixOne">First matrix</param>
        /// <param name="matrixTwo">Second matrix</param>
        /// <returns></returns>
        public static Matrix<T> operator -(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Rows == matrixTwo.Rows && matrixOne.Columns == matrixTwo.Columns)
            {
                Matrix<T> newArray = new Matrix<T>(matrixOne.Rows, matrixOne.Columns);
                for (int i = 0; i < matrixOne.Rows; i++)
                {
                    for (int j = 0; j < matrixOne.Columns; j++)
                    {
                        newArray[i + 1, j + 1] = (dynamic)matrixOne[i + 1, j + 1] - matrixTwo[i + 1, j + 1];
                    }
                }

                return newArray;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Both matrixes should be of the same size!");
            }
        }

        /// <summary>
        /// Multiplies two matrixes. Columns number of first matrix must be equal to Rows number of second matrix
        /// </summary>
        /// <param name="matrixOne"></param>
        /// <param name="matrixTwo"></param>
        /// <returns></returns>
        public static Matrix<T> operator *(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Columns == matrixTwo.Rows)
            {
                Matrix<T> newArray = new Matrix<T>(matrixOne.Rows, matrixTwo.Columns);
                for (int k = 0; k < matrixOne.Rows; k++)
                {
                    for (int i = 0; i < matrixTwo.Columns; i++)
                    {
                        for (int j = 0; j < matrixOne.Columns; j++)
                        {
                            newArray[k + 1, i + 1] += (dynamic)matrixOne[k + 1, j + 1] * matrixTwo[j + 1, i + 1];
                        }
                    }
                }

                return newArray;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of columns in first matrix must be equal to number of rows in second matrix!");
            }
        }

        /// <summary>
        /// Checks does matrix is zero one (true overload).
        /// </summary>
        /// <param name="matrixOne">Matrix to be checked is it zero one</param>
        /// <returns>True - if matrix is zero one</returns>
        public static bool operator true(Matrix<T> matrixOne)
        {
            return CheckForZero(matrixOne);
        }

        /// <summary>
        /// Checks does matrix is zero one (false overload).
        /// </summary>
        /// <param name="matrixOne">Matrix to be checked is it zero one</param>
        /// <returns>False - if matrix is non-zero one</returns>
        public static bool operator false(Matrix<T> matrixOne)
        {
            return CheckForZero(matrixOne);
        }

        // Algorythm to check for zero matrix
        private static bool CheckForZero(Matrix<T> matrixOne)
        {
            for (int row = 0; row < matrixOne.Rows; row++)
            {
                for (int col = 0; col < matrixOne.Columns; col++)
                {
                    if (!matrixOne[row + 1, col + 1].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if index is within boundaries of matrix
        /// /// </summary>
        private bool IsInRange(int row, int col)
        {
            return ((row > 0 && row <= this.matrix.GetLength(0)) && (col > 0 && col <= this.matrix.GetLength(1))) ? true : false;
        }

        #endregion
    }
}