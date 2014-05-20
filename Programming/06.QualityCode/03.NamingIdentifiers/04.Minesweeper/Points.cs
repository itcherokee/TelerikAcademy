namespace Mines
{
    public class Points
    {
        public Points(string playerName = "unknown", int pontsEarned = 0)
        {
            this.PlayerName = playerName;
            this.EarnedPoints = pontsEarned;
        }

        public string PlayerName { get; set; }

        public int EarnedPoints { get; set; }
    }
}