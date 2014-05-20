namespace Mines
{
    using System;

    public class Minesweeper
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Console.Read();
        }
    }
}
