using System;

public class MissCat
{
    public static void Main()
    {
        int numberOfJudges = int.Parse(Console.ReadLine());
        int[] cats = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        byte vote = 0;
        for (int i = 1; i <= numberOfJudges; i++)
        {
            vote = byte.Parse(Console.ReadLine());
            cats[vote - 1]++;
        }

        int winnerCat = 0;
        int index = 0;
        for (int i = 9; i >= 0; i--)
        {
            if (winnerCat <= cats[i])
            {
                winnerCat = cats[i];
                index = i;
            }
        }

        Console.WriteLine(index + 1);
    }
}