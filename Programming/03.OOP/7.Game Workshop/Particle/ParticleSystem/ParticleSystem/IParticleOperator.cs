namespace ParticleSystem
{
    using System.Collections.Generic;

    public interface IParticleOperator
    {
        IEnumerable<Particle> OperateOn(Particle p);

        void TickEnded();
    }
}