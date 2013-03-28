using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    //Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
    //The dwarf is (O). 
    //Ensure a constant game speed by Thread.Sleep(150).

    struct Pawn //define properties of rocks and player
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public string rockPrint;
    }
    static Pawn player = new Pawn();
    static List<Pawn> rocks = new List<Pawn>();

    static void DrawItemOnScreen(Pawn item)
    {
        Console.SetCursorPosition(item.x, item.y);
        Console.ForegroundColor = item.color;
        Console.Write(item.rockPrint);
    }

    private static void DrawMessageOnScreen(string message)
    {
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2 - 1);
        Console.Write(message);
        Console.SetCursorPosition((Console.WindowWidth - 14) / 2, Console.WindowHeight / 2 + 1);
        Console.Write("<press Enter>");
        Console.ReadLine();
    }

    static void DrawPlayground()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, 1);
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.Write(new string('=', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Press \"Q\" to exit");
        Console.ForegroundColor = ConsoleColor.White;
        DrawItemOnScreen(player);
        foreach (Pawn item in rocks)
        {
            DrawItemOnScreen(item);
        }
    }

    private static void InitializePlayer()
    {
        player.x = (Console.WindowWidth - 1) / 2;
        player.y = Console.WindowHeight - 3;
        player.color = ConsoleColor.Yellow;
        player.rockPrint = "(0)";
    }

    static void Main()
    {
        char[] fallingRocksType = new char[11] { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';' };
        int maxRocksSize = 3;
        int maxRocks = 3;
        int lives = 5;
        int playerSize = 3;
        Console.CursorVisible = false;
        Console.BufferWidth = Console.WindowWidth = 60;
        Console.BufferHeight = Console.WindowHeight = 20;
        InitializePlayer();
        Random generateRocks = new Random();
        // Main loop of game
        while (true)
        {
            // Generate rocks on first line + their size
            int rockSize = generateRocks.Next(1, maxRocksSize);
            int maxRocksPerLine = generateRocks.Next(1, maxRocks);
            for (int item = 0; item <= maxRocksPerLine; item++)
            {
                Pawn rockItem = new Pawn();
                char rockType = fallingRocksType[generateRocks.Next(0, 11)];
                rockItem.x = generateRocks.Next(0, Console.WindowWidth);
                rockItem.y = 1;
                rockItem.color = (ConsoleColor)generateRocks.Next(2, 15);
                if ((rockItem.x + rockSize) > Console.WindowWidth - 1)
                {
                    rockSize -= Console.WindowWidth - 1 - rockItem.x;
                }
                rockItem.rockPrint = new string(rockType, rockSize);
                rocks.Add(rockItem);
            }
            // Player control + Game exit
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);
                if ((pressedKey.Key == ConsoleKey.LeftArrow) && (player.x > 0))
                {
                    player.x--;
                }
                if ((pressedKey.Key == ConsoleKey.RightArrow) && (player.x < Console.WindowWidth - 3))
                {
                    player.x++;
                }
                if (pressedKey.Key == ConsoleKey.Q)
                {
                    Environment.Exit(0);
                }
            }
            // Move rocks one position down (y+1)
            List<Pawn> movedRocks = new List<Pawn>();
            for (int item = 0; item <= rocks.Count - 1; item++)
            {
                Pawn movedRock = new Pawn();
                movedRock.x = rocks[item].x;
                movedRock.y = rocks[item].y + 1;
                movedRock.color = rocks[item].color;
                movedRock.rockPrint = rocks[item].rockPrint;
                if (movedRock.y < Console.WindowHeight - 2)
                {
                    movedRocks.Add(movedRock);
                }
                // Check for hit with player
                if (movedRock.y - 1 == player.y)
                {
                    if (((movedRock.x <= player.x) && (movedRock.x + movedRock.rockPrint.Length - 1 >= player.x)) ||
                    ((movedRock.x >= player.x) && (movedRock.x + movedRock.rockPrint.Length - 1 <= player.x + playerSize - 1)) ||
                    ((movedRock.x >= player.x) && (movedRock.x <= player.x + playerSize - 1)))
                    {
                        // Draw dead player
                        player.rockPrint = "[X]";
                        player.color = ConsoleColor.Red;
                        DrawItemOnScreen(player);  // Draw hited player
                        rocks.Clear(); // clear all rocks 
                        InitializePlayer();
                        lives--;
                        if (lives < 1)
                        {
                            DrawMessageOnScreen("GAME OVER !");
                            return;
                        }
                        else
                        {
                            DrawMessageOnScreen("You have lost life!");
                        }
                    }
                }
            }
            rocks = movedRocks;
            Console.Clear();
            DrawPlayground();
            Console.SetCursorPosition((Console.WindowWidth - 7) / 2, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Lives: {0}", lives);
            Thread.Sleep(150);
        }
    }




}