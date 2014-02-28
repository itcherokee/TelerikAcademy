namespace BalkanSuperHero.Interfaces
{
    // Implementaer has the ability to die and to be removed from the gameplay,
    public interface IDiable
    {
        int IsDead
        {
            get;
            set;
        }

        void Die();
    }
}
