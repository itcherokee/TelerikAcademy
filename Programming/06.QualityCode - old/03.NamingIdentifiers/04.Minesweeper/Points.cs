namespace Mines
{
    using System;

    public class Points
    {
        public Points(string playerName, int pontsEarned)
        {
            this.PlayerName = playerName;
            this.EarnedPoints = pontsEarned;
        }

        public string PlayerName { get; set; }

        public int EarnedPoints { get; set; }
    }
}
