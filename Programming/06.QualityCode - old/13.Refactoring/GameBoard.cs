namespace Game
{
    using System;
    using System.Text;

    public class GameBoard
    {
        private readonly int boardSize;
        private int[,] board;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameBoard" /> class.
        /// </summary>
        public GameBoard(int gameBoardSize)
        {
            this.boardSize = gameBoardSize;
            this.board = new int[this.boardSize, this.boardSize];
        }

        /// <summary>
        /// Gets or sets the game board.
        /// </summary>
        /// <value>The game board1.</value>
        public int[,] Board
        {
            get
            {
                return this.board;
            }

            set
            {
                this.board = value;
            }
        }

        /// <summary>
        /// Indexer for of the <see cref="Board"/>.
        /// </summary>
        /// <param name="indexRow">Row index.</param>
        /// <param name="indexColumn">Column index.</param>
        /// <returns>Value at the cell where indexes points.</returns>
        public int this[int indexRow, int indexColumn]
        {
            get
            {
                return this.board[indexRow, indexColumn];
            }

            set
            {
                this.board[indexRow, indexColumn] = value;
            }
        }

        /// <summary>
        /// Checks does the pointer has reached the boundaries.
        /// </summary>
        /// <returns>True or False.</returns>
        public bool CheckBoundaries(int currentRow, int currentColumn)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < directionX.Length; i++)
            {
                if (currentRow + directionX[i] >= this.boardSize || currentRow + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (currentColumn + directionY[i] >= this.boardSize || currentColumn + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }
            }

            for (int i = 0; i < directionX.Length; i++)
            {
                if (this.Board[currentRow + directionX[i], currentColumn + directionY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Changes direction of pointer move.
        /// </summary>
        /// <returns>new Directions by row & column.</returns>
        public Tuple<int, int> ChangeDirection(int currentDirectionX, int currentDirectionY)
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int changeDirection = 0;
            for (int count = 0; count < directionX.Length; count++)
            {
                if (directionX[count] == currentDirectionX && directionY[count] == currentDirectionY)
                {
                    changeDirection = count;
                    break;
                }
            }

            if (changeDirection == directionX.Length - 1)
            {
                return new Tuple<int, int>(directionX[0], directionY[0]);
            }

            return new Tuple<int, int>(directionX[changeDirection + 1], directionY[changeDirection + 1]);
        }

        /// <summary>
        /// Find next empty cell - not yet filled up.
        /// </summary>
        /// <returns>first empty coordinates by row & column.</returns>
        public Tuple<int, int> FindEmptyCell()
        {
            Tuple<int, int> emptyCell;
            for (int row = 0; row < this.boardSize; row++)
            {
                for (int column = 0; column < this.boardSize; column++)
                {
                    if (this.Board[row, column] == 0)
                    {
                        emptyCell = new Tuple<int, int>(row, column);
                        return emptyCell;
                    }
                }
            }

            // no more empty cells
            emptyCell = new Tuple<int, int>(-1, -1);
            return emptyCell;
        }

        /// <summary>
        /// Returns formated matrix of the board's cell values.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int row = 0; row < this.boardSize; row++)
            {
                for (int column = 0; column < this.boardSize; column++)
                {
                    output.Append(string.Format("{0,3}", this.board[row, column]));
                }

                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }
    }
}
