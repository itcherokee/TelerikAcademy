namespace Bombs
{
    public class Player
    {
        public Player(string name = "unknown", int points = 0)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}
