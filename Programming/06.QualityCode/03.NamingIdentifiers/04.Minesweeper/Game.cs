using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mines
{
    class Game
    {
                    IRenderer renderer = new Renderer();


            string command = string.Empty;
            char[,] gameField = InitializeBoard();
            char[,] minesField = PutMinesOnBoard();
            int earnedPoints = 0;
            bool isMineBelow = false;
            List<Points> currentChampions = new List<Points>(6);
            int enteredRow = 0;
            int enteredColumn = 0;
            bool startNewGame = true;
            const int MaximumPoints = 35;
            bool isWinner = false;

           
        public Game()
        {
            Engine engine = new Engine();
        }

        public void Start()
        {
            engine.Run();            
        }


        private static void ShowScore(List<Points> champions)
        {
            Console.WriteLine("\nPoints:");
            if (champions.Count > 0)
            {
                for (int i = 0; i < champions.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, champions[i].PlayerName, champions[i].EarnedPoints);
                }
            }
            else
            {
                Console.WriteLine("Empty position!");
            }

            Console.WriteLine();
        }

        private static void RevealCell(char[,] playBoard, char[,] minesBoard, int row, int column)
        {
            char numberOfMinesAround = CalculateNearMines(minesBoard, row, column);
            minesBoard[row, column] = numberOfMinesAround;
            playBoard[row, column] = numberOfMinesAround;
        }

        private static void DrawBoardOnScreen(char[,] gammingBoard)
        {
            int boardRows = gammingBoard.GetLength(0);
            int boardColumns = gammingBoard.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int index = 0; index < boardRows; index++)
            {
                Console.Write("{0} | ", index);
                for (int j = 0; j < boardColumns; j++)
                {
                    Console.Write(string.Format("{0} ", gammingBoard[index, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] InitializeBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutMinesOnBoard()
        {
            int numberOfBoardRows = 5;
            int numberOfBoardColumns = 10;
            int numberOfMines = 15;
            char[,] minesPositionOnBoard = new char[numberOfBoardRows, numberOfBoardColumns];

            // clears mines field
            for (int rowIndex = 0; rowIndex < numberOfBoardRows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < numberOfBoardColumns; colIndex++)
                {
                    minesPositionOnBoard[rowIndex, colIndex] = '-';
                }
            }

            // generate mines
            List<int> minesBag = new List<int>();
            while (minesBag.Count < numberOfMines)
            {
                Random generator = new Random();
                int minePosition = generator.Next(50);
                if (!minesBag.Contains(minePosition))
                {
                    minesBag.Add(minePosition);
                }
            }

            // place mines on playboard
            foreach (int currentMine in minesBag)
            {
                int currentRow = currentMine / numberOfBoardColumns;
                int currentColumn = currentMine % numberOfBoardColumns;
                if (currentColumn == 0 && currentMine != 0)
                {
                    currentRow--;
                    currentColumn = numberOfBoardColumns;
                }
                else
                {
                    currentColumn++;
                }

                minesPositionOnBoard[currentRow, currentColumn - 1] = '*';
            }

            return minesPositionOnBoard;
        }

        private static char CalculateNearMines(char[,] minesBoard, int currentRow, int currentColumn)
        {
            int minesAroundNumber = 0;
            int rows = minesBoard.GetLength(0);
            int columns = minesBoard.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (minesBoard[currentRow - 1, currentColumn] == '*')
                {
                    minesAroundNumber++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (minesBoard[currentRow + 1, currentColumn] == '*')
                {
                    minesAroundNumber++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (minesBoard[currentRow, currentColumn - 1] == '*')
                {
                    minesAroundNumber++;
                }
            }

            if (currentColumn + 1 < columns)
            {
                if (minesBoard[currentRow, currentColumn + 1] == '*')
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (minesBoard[currentRow - 1, currentColumn - 1] == '*')
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < columns))
            {
                if (minesBoard[currentRow - 1, currentColumn + 1] == '*')
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn - 1 >= 0))
            {
                if (minesBoard[currentRow + 1, currentColumn - 1] == '*')
                {
                    minesAroundNumber++;
                }
            }

            if ((currentRow + 1 < rows) && (currentColumn + 1 < columns))
            {
                if (minesBoard[currentRow + 1, currentColumn + 1] == '*')
                {
                    minesAroundNumber++;
                }
            }

            return char.Parse(minesAroundNumber.ToString());
        }
    }
}
