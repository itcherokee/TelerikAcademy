using System;

namespace Mines
{
    public class Engine
    {
        private IRenderer renderer;
        private IUserControl userControl;
        private Messages messages = new Messages();

        public Engine(IRenderer renderer, IUserControl userControl)
        {
            this.renderer = renderer;
            this.userControl = userControl;
        }

        public void Run()
        {
            do
            {
                if (startNewGame)
                {
                    renderer.PrintMessage(messages.Intro);
                    DrawBoardOnScreen(gameField);
                    startNewGame = false;
                }

                renderer.PrintMessage(messages.Play);
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
                        renderer.PrintMessage(messages.Exit);
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
                        renderer.PrintMessage(messages.Error);
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
        }
    }
}
