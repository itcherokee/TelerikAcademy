using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WalkInMatrixTest
{
    /// <summary>
    ///This is a test class for GameBoardTest and is intended
    ///to contain all GameBoardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GameBoardTest
    {
        /// <summary>
        ///A test for GameBoard Constructor
        ///</summary>
        [TestMethod()]
        public void GameBoardConstructorTest()
        {
            int gameBoardSize = 20;
            GameBoard target = new GameBoard(gameBoardSize);
            Assert.AreEqual(gameBoardSize, target.Board.GetLength(0));
        }

        /// <summary>
        ///A test for ChangeDirection
        ///</summary>
        [TestMethod()]
        public void ChangeDirectionCurrentDownAndRightTest()
        {
            int gameBoardSize = 6;
            GameBoard target = new GameBoard(gameBoardSize);
            int currentDirectionX = 1;
            int currentDirectionY = 1;
            Tuple<int, int> expected = new Tuple<int, int>(1, 0);
            Tuple<int, int> actual = target.ChangeDirection(currentDirectionX, currentDirectionY);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CheckBoundaries
        ///</summary>
        [TestMethod()]
        public void CheckBoundariesDownRightCornerTest()
        {
            int gameBoardSize = 6;
            GameBoard target = new GameBoard(gameBoardSize);
            int currentRow = 5;
            int currentColumn = 5;
            bool expected = true;
            bool actual = target.CheckBoundaries(currentRow, currentColumn);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FindEmptyCell
        ///</summary>
        [TestMethod()]
        public void FindEmptyCellTest()
        {
            int gameBoardSize = 6;
            GameBoard target = new GameBoard(gameBoardSize);
            Tuple<int, int> expected = new Tuple<int, int>(0, 0);
            Tuple<int, int> actual = target.FindEmptyCell();
            Assert.AreEqual(expected, actual);
        }
    }
}
