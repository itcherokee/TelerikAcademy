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

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
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

            // use MeteoriteBall instead of Ball
            MeteoriteBall theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theMeteoriteBall);

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

            Engine gameEngine = new Engine(renderer, keyboard, 200);

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
