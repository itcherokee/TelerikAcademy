﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            Random generator = new Random();
            int randomBlock = 0;
            for (int i = startCol; i < endCol; i++)
            {
                if (i!=7)
                {
                    randomBlock = generator.Next(1, 101);
                    if (randomBlock < 80)
                    {
                        // draw destructable Block
                        Block currBlock = new Block(new MatrixCoords(startRow, i));
                        engine.AddObject(currBlock);
                    }
                    else
                    {
                        // draw unpassableBlock
                        UnpassableBlock currBlock = new UnpassableBlock(new MatrixCoords(startRow, i));
                        engine.AddObject(currBlock);
                    }
                }
                else
                {
                    // drawing exploadingBlock
                    ExploadingBlock currBlock = new ExploadingBlock(new MatrixCoords(startRow, i));
                    engine.AddObject(currBlock);
                }
            }

            // Top Border draw
            for (int i = 0; i < WorldCols - 1; i++)
            {
                IndestructibleBlock topBorder = new IndestructibleBlock(new MatrixCoords(1, i));
                engine.AddObject(topBorder);
            }

            // left & right borders draw
            for (int i = 1; i < WorldRows; i++)
            {
                IndestructibleBlock leftBorder = new IndestructibleBlock(new MatrixCoords(i, 0));
                IndestructibleBlock rightBorder = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(leftBorder);
                engine.AddObject(rightBorder);
            }

            // test Gift
            Gift theGift = new Gift(new MatrixCoords(5, 15));
            engine.AddObject(theGift);

            // use UnstoppableBall (Meteorite one)
            UnstoppableBall theUnstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theUnstoppableBall);

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 500);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}