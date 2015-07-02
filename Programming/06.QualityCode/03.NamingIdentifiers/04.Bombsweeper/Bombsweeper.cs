namespace Bombs
{
    using System;

    public class BombSweeper
    {
        public static void Main()
        {
            Game game = new Game();
            game.Start();
            Console.Read();
        }
    }
}
