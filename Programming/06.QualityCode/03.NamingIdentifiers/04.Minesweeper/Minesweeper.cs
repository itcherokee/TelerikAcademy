namespace Mines
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public static void Main(string[] args)
        {
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

            do
            {
                if (startNewGame)
                {
                    Console.WriteLine("Let's play \"Minesweeper\". Test your luck to find fields without mines." +
                    " Commands: \"top\" - shows champions, \"restart\" - new game, \"exit\" - quit!");
                    DrawBoardOnScreen(gameField);
                    startNewGame = false;
                }

                Console.Write("Type row & column splitted by space (or command): ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    bool isCorrectRowEntered = int.TryParse(command[0].ToString(), out enteredRow);
                    bool isCorrectColumnEntered = int.TryParse(command[2].ToString(), out enteredColumn);
                    bool isEnteredRowIsInBounds = enteredRow <= gameField.GetLength(0);
                    bool isEnteredColumnIsInBounds = enteredColumn <= gameField.GetLength(1);
                    if (isCorrectRowEntered && isCorrectColumnEntered && isEnteredRowIsInBounds && isEnteredColumnIsInBounds)
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScore(currentChampions);
                        break;
                    case "restart":
                        gameField = InitializeBoard();
                        minesField = PutMinesOnBoard();
                        DrawBoardOnScreen(gameField);
                        isMineBelow = false;
                        startNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
                        Console.WriteLine("Dosvidanie....:)");
                        break;
                    case "turn":
                        if (minesField[enteredRow, enteredColumn] != '*')
                        {
                            if (minesField[enteredRow, enteredColumn] == '-')
                            {
                                RevealCell(gameField, minesField, enteredRow, enteredColumn);
                                earnedPoints++;
                            }

                            if (MaximumPoints == earnedPoints)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                DrawBoardOnScreen(gameField);
                            }
                        }
                        else
                        {
                            isMineBelow = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isMineBelow)
                {
                    DrawBoardOnScreen(minesField);
                    Console.Write("\nHrrrrrr! You are dead with {0} points. Type your name: ", earnedPoints);
                    string playerName = Console.ReadLine();
                    Points t = new Points(playerName, earnedPoints);
                    if (currentChampions.Count < 5)
                    {
                        currentChampions.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < currentChampions.Count; i++)
                        {
                            if (currentChampions[i].EarnedPoints < t.EarnedPoints)
                            {
                                currentChampions.Insert(i, t);
                                currentChampions.RemoveAt(currentChampions.Count - 1);
                                break;
                            }
                        }
                    }

                    currentChampions.Sort((Points playerOne, Points playerTwo) => playerTwo.PlayerName.CompareTo(playerOne.PlayerName));
                    currentChampions.Sort((Points playerOne, Points playerTwo) => playerTwo.EarnedPoints.CompareTo(playerOne.EarnedPoints));
                    ShowScore(currentChampions);

                    gameField = InitializeBoard();
                    minesField = PutMinesOnBoard();
                    earnedPoints = 0;
                    isMineBelow = false;
                    startNewGame = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nBRAVOOOS! You have found all {0} cells without mines below!", MaximumPoints);
                    DrawBoardOnScreen(minesField);
                    Console.WriteLine("Type your name: ");
                    string playerName = Console.ReadLine();
                    Points points = new Points(playerName, earnedPoints);
                    currentChampions.Add(points);
                    ShowScore(currentChampions);
                    gameField = InitializeBoard();
                    minesField = PutMinesOnBoard();
                    earnedPoints = 0;
                    isWinner = false;
                    startNewGame = true;
                }
            }
            while (command != "exit");
            Console.Read();
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
