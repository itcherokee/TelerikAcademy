namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 1: Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed). 
    /// You are not allowed to edit any existing class.
    /// </summary>
    public class ChaoticParticle : Particle
    {
        protected readonly Random Generator = new Random();

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed)
            : base(position, speed)
        {
        }

        public override IEnumerable<Particle> Update()
        {
            this.Speed = new MatrixCoords(this.Generator.Next(-5, 6), this.Generator.Next(-5, 6));
            return base.Update();
        }

        public override char[,] GetImage()
        {
            return new[,] { { 'x' } };
        }
    }
}
