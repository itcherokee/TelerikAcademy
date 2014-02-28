using BalkanSuperHero.GameObjects;

namespace BalkanSuperHero.Interfaces
{
    // Implentaers can colide with other objects
    public interface IColideable
    {
        int CanColideWith
        {
            get;
            set;
        }

        void Respond();

        bool IsColiding(ref Sprite sprite);
    }
}
