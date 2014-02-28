namespace BalkanSuperHero.Interfaces
{
    // Everything that implements that interface has the abbility to heal.
    public interface IHealable
    {
        int Mana
        {
            get;
            set;
        }

        void Heal();
    }
}
