namespace BalkanSuperHero.Interfaces
{
    // Implementers could actively participate in battles
    public interface IFightable
    {
        int Attack
        {
            get;
            set;
        }

        int Defence
        {
            get;
            set;
        }

        void Equip();
    }
}
