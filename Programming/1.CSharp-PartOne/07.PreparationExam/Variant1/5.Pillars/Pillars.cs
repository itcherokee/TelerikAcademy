using System;
//using System.Text;

class Pillars
{
    static void Main()
    {
        byte[,] cells = new byte[9, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 },
        {0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0}};
        byte inputNumber = 0;
        byte mask = 1;
        int modifiedMask = 0;
        int result = 0;
        for (int row = 0; row <= 7; row++)
        {
            inputNumber = byte.Parse(Console.ReadLine());

            for (int col = 7; col >= 0; col--)
            {
                modifiedMask = mask << col;
                result = modifiedMask & inputNumber;
                if (result > 0) { cells[row, col] = 1; }
                result = result >> col;
                cells[8, col] += (byte)result;
            }
        }
        byte sumRight = 0;
        byte sumLeft = 0;
        for (sbyte pillar = 7; pillar >= 0; pillar--)
        {
            for (int i = 0; i < pillar; i++)
            {
                sumRight += cells[8, i];
            }
            for (int i = pillar + 1; i <= 7; i++)
            {
                sumLeft += cells[8, i];
            }
            if (sumLeft == sumRight)
            {
                Console.WriteLine(pillar);
                Console.WriteLine(sumRight);
                return;
            }
            sumLeft = 0;
            sumRight = 0;
        }
        Console.WriteLine("No");
    }
}
