namespace Game
{
    using System;

    public class Engine
    {
        private int counter = 1;
        private int row = 0;
        private int column = 0;
        private int directionX = 1;
        private int directionY = 1;
        private readonly GameBoard board;
        private readonly int gameBoardSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine" /> class.
        /// </summary>
        public Engine(int gameBoardSize)
        {
            this.board = new GameBoard(gameBoardSize);
            this.gameBoardSize = gameBoardSize;
        }

        private bool IsEmptyOrMinMaxRowColumn()
        {
            bool isMinOrMaxRow = this.row + this.directionX >= this.gameBoardSize || this.row + this.directionX < 0;
            bool isMinOrMaxColumn = this.column + this.directionY >= this.gameBoardSize || this.column + this.directionY < 0;
            if (isMinOrMaxRow || isMinOrMaxColumn || this.board[this.row + this.directionX, this.column + this.directionY] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Real engine of the calculations.
        /// </summary>
        /// <returns>Calculated and filled up matrix of the board.</returns>
        public string CalculateAndFill()
        {
            while (this.counter <= this.gameBoardSize * this.gameBoardSize)
            {
                this.board[this.row, this.column] = this.counter;

                if (!this.board.CheckBoundaries(this.row, this.column))
                {
                    this.counter++;
                    break;
                }

                if (this.IsEmptyOrMinMaxRowColumn())
                {
                    while (this.IsEmptyOrMinMaxRowColumn())
                    {
                        Tuple<int, int> delta = this.board.ChangeDirection(this.directionX, this.directionY);
                        this.directionX = delta.Item1;
                        this.directionY = delta.Item2;
                    }
                }

                this.row += this.directionX;
                this.column += this.directionY;
                this.counter++;
            }

            Tuple<int, int> emptyCell = this.board.FindEmptyCell();
            this.row = emptyCell.Item1;
            this.column = emptyCell.Item2;

            if (this.row != 0 && this.column != 0)
            {
                this.directionX = 1;
                this.directionY = 1;
                while (true)
                {
                    this.board[this.row, this.column] = this.counter;
                    if (!this.board.CheckBoundaries(this.row, this.column))
                    {
                        this.counter++;
                        break;
                    }

                    if (this.IsEmptyOrMinMaxRowColumn())
                    {
                        while (this.IsEmptyOrMinMaxRowColumn())
                        {
                            Tuple<int, int> delta = this.board.ChangeDirection(this.directionX, this.directionY);
                            this.directionX = delta.Item1;
                            this.directionY = delta.Item2;
                        }
                    }

                    this.row += this.directionX;
                    this.column += this.directionY;
                    this.counter++;
                }
            }

            return board.ToString();
        }
    }
}
