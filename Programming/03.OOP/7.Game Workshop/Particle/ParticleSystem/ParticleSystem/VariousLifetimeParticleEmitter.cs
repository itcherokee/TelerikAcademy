namespace ParticleSystem
{
    using System;

    public class VariousLifetimeParticleEmitter : ParticleEmitter
    {
        private const int MaxParticleLifetime = 7;

        public VariousLifetimeParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randomGenerator) :
            base(position, speed, randomGenerator)
        {
        }

        protected override Particle GetNewParticle(MatrixCoords position, MatrixCoords speed)
        {
            bool createDying = this.RandomGenerator.Next() % 2 == 0;
            if (createDying)
            {
                return new DyingParticle(position, speed, this.RandomGenerator.Next(MaxParticleLifetime));
            }

            return base.GetNewParticle(position, speed);
        }
    }
}