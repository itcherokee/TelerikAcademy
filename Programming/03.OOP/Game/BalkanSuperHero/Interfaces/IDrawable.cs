using System;
using BalkanSuperHero.Structs;

namespace BalkanSuperHero.Interfaces
{
    public interface IDrawable
    {
        PointF Position { get; set; }

        Object Picture { get; set; }

        Point Size { get; set; }

        void Update();
    }
}
