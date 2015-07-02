namespace Bombs
{
    using System;
    using System.Collections.Generic;

    internal class Game
    {
        private const int Rows = 5;
        private const int Columns = 10;
        private const int NumberOfBombs = 15;
        private const int InitialCountOfPlayers = 6;
        private const char NoBombSymbol = '-';
        private const char BombSymbol = '*';
        private readonly List<Player> players;

        private char[,] board;
        private char[,] bombsOnBoard;
        private int points;
        private int currentRow;
        private int currentColumn;

        public Game()
        {
            this.players = new List<Player>(InitialCountOfPlayers);
            this.InitializeGame();
        }

        public void Start()
        {
            bool isGameOver = false;

            do
            {
                Console.Write(Messages.Command);
                var command = this.ParseCommand(Console.ReadLine());
                isGameOver = this.ProccessCommand(command);
            }
            while (!isGameOver);

            Console.WriteLine(Messages.Trademark);
            Console.Read();
        }

        private string ParseCommand(string inputCommand)
        {
            var command = string.Empty;
            var processedCommand = inputCommand.Trim().Split(',');
            if (processedCommand.Length >= 2)
            {
                if (int.TryParse(processedCommand[0], out this.currentRow)
                    && int.TryParse(processedCommand[1], out this.currentColumn)
                    && this.currentRow <= this.board.GetLength(0)
                    && this.currentColumn <= this.board.GetLength(1))
                {
                    command = "turn";
                }
            }
            else if (processedCommand.Length == 1)
            {
                command = processedCommand[0];
            }
            else
            {
                command = "invalid";
            }

            return command;
        }

        private bool ProccessCommand(string command)
        {
            switch (command)
            {
                case "top":
                    this.ShowScore(this.players);
                    break;
                case "restart":
                    this.InitializeGame();
                    break;
                case "exit":
                    Console.WriteLine(Messages.Goodbye);
                    return true;
                    break;
                case "turn":
                    this.ProcessTurnCommand();
                    break;
                default:
                    Console.WriteLine(Messages.InvalidCommand);
                    break;
            }

            return false;
        }

        private void ProcessTurnCommand()
        {
            if (this.bombsOnBoard[this.currentRow, this.currentColumn] != BombSymbol)
            {
                if (this.bombsOnBoard[this.currentRow, this.currentColumn] == NoBombSymbol)
                {
                    this.RevealCell();
                    this.points++;
                }

                if (((Rows * Columns) - NumberOfBombs) == this.points)
                {
                    this.AnnounceWinner();
                    this.InitializeGame();
                }
                else
                {
                    this.DrawBoardOnScreen(this.board);
                }
            }
            else
            {
                this.DrawBoardOnScreen(this.bombsOnBoard);
                Console.Write(Messages.Dead, this.points);
                Console.Write(Messages.Nickname, this.points);

                this.ManageScoreBoard();
                this.ShowScore(this.players);
                this.InitializeGame();
            }
        }

        private void ManageScoreBoard()
        {
            Player player = new Player(Console.ReadLine(), this.points);
            if (this.players.Count < 5)
            {
                this.players.Add(player);
            }
            else
            {
                for (int i = 0; i < this.players.Count; i++)
                {
                    if (this.players[i].Points < player.Points)
                    {
                        this.players.Insert(i, player);
                        this.players.RemoveAt(this.players.Count - 1);
                        break;
                    }
                }
            }

            this.players.Sort((playerOne, playerTwo) => playerTwo.Points.CompareTo(playerOne.Points));
        }

        private void AnnounceWinner()
        {
            Console.WriteLine(Messages.Winner);
            this.DrawBoardOnScreen(this.bombsOnBoard);
            Console.WriteLine(Messages.Nickname);
            string name = Console.ReadLine();
            Player player = new Player(name, this.points);
            this.players.Add(player);
            this.ShowScore(this.players);
        }

        private void InitializeGame()
        {
            Console.WriteLine(Messages.WelcomeMessage);
            this.points = 0;
            this.board = this.InitializeBoard();
            this.bombsOnBoard = this.PlantBombsOnPlayBoard();
            this.DrawBoardOnScreen(this.board);
        }

        private void ShowScore(List<Player> champions)
        {
            Console.WriteLine("\nPoints:");
            if (champions.Count > 0)
            {
                for (int i = 0; i < champions.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, champions[i].Name, champions[i].Points);
                }
            }
            else
            {
                Console.WriteLine("Empty position!");
            }

            Console.WriteLine();
        }

        private void RevealCell()
        {
            char numberOfMinesAround = this.CalculateBombsAround(this.bombsOnBoard, this.currentRow, this.currentColumn);
            this.bombsOnBoard[this.currentRow, this.currentColumn] = numberOfMinesAround;
            this.board[this.currentRow, this.currentColumn] = numberOfMinesAround;
        }

        private void DrawBoardOnScreen(char[,] playBoard)
        {
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < Rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(string.Format("{0} ", playBoard[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private char[,] InitializeBoard()
        {
            char[,] board = new char[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private char[,] PlantBombsOnPlayBoard()
        {
            char[,] minesPositionOnBoard = new char[Rows, Columns];

            // clears mines field
            for (int rowIndex = 0; rowIndex < Rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < Columns; colIndex++)
                {
                    minesPositionOnBoard[rowIndex, colIndex] = NoBombSymbol;
                }
            }

            // generate mines
            List<int> minesBag = new List<int>();
            while (minesBag.Count < NumberOfBombs)
            {
                Random generator = new Random();
                int minePosition = generator.Next(50);
                if (!minesBag.Contains(minePosition))
                {
                    minesBag.Add(minePosition);
                }
            }

            // place mines on playboard
            foreach (int mine in minesBag)
            {
                int row = mine / Columns;
                int column = mine % Columns;
                if (column == 0 && mine != 0)
                {
                    row--;
                    column = Columns;
                }
                else
                {
                    column++;
                }

                minesPositionOnBoard[row, column - 1] = BombSymbol;
            }

            return minesPositionOnBoard;
        }

        private char CalculateBombsAround(char[,] minesBoard, int currentRow, int currentColumn)
        {
            int minesAroundNumber = 0;
            int rows = minesBoard.GetLength(0);
            int columns = minesBoard.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (minesBoard[currentRow - 1, currentColumn] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (minesBoard[currentRow + 1, currentColumn] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (minesBoard[currentRow, currentColumn - 1] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            if (currentColumn + 1 < columns)
            {
                if (minesBoard[currentRow, currentColumn + 1] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (minesBoard[currentRow - 1, currentColumn - 1] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < columns))
            {
                if (minesBoard[currentRow - 1, currentColumn + 1] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn - 1 >= 0))
            {
                if (minesBoard[currentRow + 1, currentColumn - 1] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn + 1 < columns))
            {
                if (minesBoard[currentRow + 1, currentColumn + 1] == BombSymbol)
                {
                    minesAroundNumber++;
                }
            }

            return char.Parse(minesAroundNumber.ToString());
        }
    }
}
