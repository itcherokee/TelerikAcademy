using System.Collections.Generic;
using BalkanSuperHero.GameObjects;

namespace BalkanSuperHero.Interfaces
{
    public interface IRenderer
    {
        object Device { get; }

        void InitializeRenderer(int width, int height);

        void ProcessForDrawing(IEnumerable<Sprite> objects);

        void UpdateAll(IEnumerable<Sprite> objects);

    }
}
