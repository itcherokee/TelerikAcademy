namespace BalkanSuperHero.Interfaces
{
    // Everything that implements that interface has the abbility to heal in certain time period.
    public interface IAutoHealable : BalkanSuperHero.Interfaces.IHealable
    {
        void AutoHeal();
    }
}
