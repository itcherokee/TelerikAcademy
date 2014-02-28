using System;
using System.Collections.Generic;
using BalkanSuperHero.GameObjects;

namespace BalkanSuperHero.GameEngine
{
    public class Engine
    {
        private Game game;
        private bool gameOver;
        private int startTick;


        public Engine(Game game)
        {
            this.game = game;
            this.gameOver = false;
            this.startTick = 0;
        }

        public void Run(Game game)
        {
            //load and initialize game assets
            //   Game_Init();

            while (!this.gameOver)
            {
                //update timer
                int currentTick = System.Environment.TickCount;

                //let gameplay code update 
                //    Game_Update(currentTick - this.startTick);

                //refresh at 60 FPS
                if (currentTick > startTick + 16)
                {
                    //update timing 
                    this.startTick = currentTick;

                    // draw board and items
                    game.DrawAll();

                    // process input 
                    game.HandleInput();

                    // Updates all objects on the playground
                    game.UpdateAll();
                }

                //frameCount += 1;
                //if (currentTick > frameTimer + 1000)
                //{
                //    frameTimer = currentTick;
                //    frameRate = frameCount;
                //    frameCount = 0;
                //}
            }

            //free memory and shut down
            game.Shutdown();
        }
    }
}
