// Implement an indexer this[row, col] to access the inner matrix cells.

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

        public int Cols
        {
            get
            {
                return this.cols;
            }
        }

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

        #endregion
    }
}