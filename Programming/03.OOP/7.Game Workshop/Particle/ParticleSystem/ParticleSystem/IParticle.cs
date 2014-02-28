namespace ParticleSystem
{
    using System.Collections.Generic;

    public interface IParticle
    {
        MatrixCoords Position { get; }

        bool Exists { get; }

        IEnumerable<IParticle> Update();
    }
}