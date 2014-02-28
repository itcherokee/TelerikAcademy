namespace BalkanSuperHero.Interfaces
{
    public interface ISelfMovable : IMovable
    {
        int Path
        {
            get;
            set;
        }

        void GeneratePath();
    }
}
