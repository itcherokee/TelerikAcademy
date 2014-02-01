// Implement the operators + and - (addition and subtraction of matrices of the same size) 
// and * for matrix multiplication. Throw an exception when the operation cannot be performed. 
// Implement the true operator (check for non-zero elements).

namespace MyMatrix
{
    using System;

    public class GenericMatrix<T> where T : struct
    {
        #region Fields

        private T[,] matrix;
        private readonly int rows;
        private readonly int cols;

        #endregion

        #region Constructors

        /// <summary>
        /// Private parameterless constructor called by other constructor just to check for type incompitablity
        /// </summary>
        private GenericMatrix()
        {
            if (typeof(T) == typeof(DateTime))
            {
                throw new ArgumentOutOfRangeException("Matrix can not hold values of type DateTime.");
            }
        }

        /// <summary>
        /// Instantiates a matrix by making clone copy from existing matrix
        /// </summary>
        /// <param name="matrix"></param>
        public GenericMatrix(T[,] matrix)
            : this()
        {
            this.matrix = (T[,])matrix.Clone();
            this.rows = this.matrix.GetLength(0);
            this.cols = this.matrix.GetLength(1);
        }

        /// <summary>
        /// Instantiates a matrix
        /// </summary>
        /// <param name="rows">Rows size</param>
        /// <param name="cols">Cols size</param>
        public GenericMatrix(int rows, int cols)
            : this()
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException("Matrix can not be with negative values for rows and/or columns!");
            }

            this.rows = rows;
            this.cols = cols;
            this.matrix = new T[this.Rows, this.Cols];
        }

        /// <summary>
        /// Instantiates a square matrix
        /// </summary>
        /// <param name="size">Size of Rows = Cols</param>
        public GenericMatrix(int size)
            : this(size, size)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns Columns of a matrix
        /// </summary>
        public int Cols
        {
            get
            {
                return this.cols;
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
        /// <param name="row">Row value</param>
        /// <param name="col">Column value</param>
        /// <returns>Matrix's element</returns>
        public T this[int row, int col]
        {
            get
            {
                // check if provided index is out of range
                if (!this.IsInRange(row, col))
                {
                    throw new IndexOutOfRangeException("Non exisitng element (index) requested!");
                }

                return this.matrix[row - 1, col - 1];
            }

            set
            {
                // check if provided index is out of range
                if (!this.IsInRange(row, col))
                {
                    throw new IndexOutOfRangeException("An attempt to change non existing element!");
                }

                this.matrix[row - 1, col - 1] = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns true if index is within boundaries of matrix
        /// /// </summary>
        private bool IsInRange(int row, int col)
        {
            return ((row > 0 && row <= this.matrix.GetLength(0)) && (col > 0 && col <= this.matrix.GetLength(1))) ? true : false;
        }

        /// <summary>
        /// Adds two matrixes. They should be of the same matrix type.
        /// </summary>
        /// <param name="matrixOne">First matrix</param>
        /// <param name="matrixTwo">Second matrix</param>
        /// <returns></returns>
        public static GenericMatrix<T> operator +(GenericMatrix<T> matrixOne, GenericMatrix<T> matrixTwo)
        {
            if (matrixOne.Rows == matrixTwo.Rows && matrixOne.Cols == matrixTwo.Cols)
            {
                GenericMatrix<T> newArray = new GenericMatrix<T>(matrixOne.Rows, matrixOne.Cols);
                for (int i = 0; i < matrixOne.Rows; i++)
                {
                    for (int j = 0; j < matrixOne.Cols; j++)
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
        public static GenericMatrix<T> operator -(GenericMatrix<T> matrixOne, GenericMatrix<T> matrixTwo)
        {
            if (matrixOne.Rows == matrixTwo.Rows && matrixOne.Cols == matrixTwo.Cols)
            {
                GenericMatrix<T> newArray = new GenericMatrix<T>(matrixOne.Rows, matrixOne.Cols);
                for (int i = 0; i < matrixOne.Rows; i++)
                {
                    for (int j = 0; j < matrixOne.Cols; j++)
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
        public static GenericMatrix<T> operator *(GenericMatrix<T> matrixOne, GenericMatrix<T> matrixTwo)
        {
            if (matrixOne.Cols == matrixTwo.Rows)
            {
                GenericMatrix<T> newArray = new GenericMatrix<T>(matrixOne.Rows, matrixTwo.Cols);
                for (int k = 0; k < matrixOne.Rows; k++)
                {
                    for (int i = 0; i < matrixTwo.Cols; i++)
                    {
                        for (int j = 0; j < matrixOne.Cols; j++)
                        {
                            newArray[k + 1, i + 1] += (dynamic)matrixOne[k + 1, j + 1] * matrixTwo[j + 1, i + 1];
                        }
                    }
                }

                return newArray;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Columns number of first matrix must be equal to Rows number of second matrix!");
            }
        }

        /// <summary>
        /// Checks does matrix is zero one (true overload).
        /// </summary>
        /// <param name="matrixOne">Matrix to be checked is it zero one</param>
        /// <returns>True - if matrix is zero one</returns>
        public static bool operator true(GenericMatrix<T> matrixOne)
        {
            for (int row = 0; row < matrixOne.Rows; row++)
            {
                for (int col = 0; col < matrixOne.Cols; col++)
                {
                    if (!matrixOne[row + 1, col + 1].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks does matrix is zero one (false overload).
        /// </summary>
        /// <param name="matrixOne">Matrix to be checked is it zero one</param>
        /// <returns>False - if matrix is non-zero one</returns>
        public static bool operator false(GenericMatrix<T> matrixOne)
        {
            for (int row = 0; row < matrixOne.Rows; row++)
            {
                for (int col = 0; col < matrixOne.Cols; col++)
                {
                    if (!matrixOne[row + 1, col + 1].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}